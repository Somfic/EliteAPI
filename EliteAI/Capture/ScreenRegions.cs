using EliteAI.UI;
using OpenCvSharp;

namespace EliteAI.Capture;

/// <summary>
/// Elite Dangerous UI region names
/// </summary>
public enum RegionName
{
    NavBall,
    Target,
    TargetOccluded,
    Sun,
    Disengage,
    Sco,
    Fss,
    MissionDest,
    Missions,
    NavPoint
}

/// <summary>
/// Represents a rectangular region of the screen with optional filtering.
/// Coordinates are in normalized form (0.0 to 1.0) relative to screen dimensions.
/// </summary>
public class ScreenRegion
{
    public RegionName Name { get; init; }

    /// <summary>
    /// Rectangle bounds in normalized coordinates [Left, Top, Right, Bottom]
    /// Values range from 0.0 to 1.0 where 1.0 = screen width/height
    /// </summary>
    public double[] Bounds { get; init; } = [0, 0, 1, 1];

    /// <summary>
    /// Optional filter to apply to the region before processing
    /// </summary>
    public Func<Mat, Mat>? Filter { get; init; }

    /// <summary>
    /// Template file name (without path) for this region, if applicable
    /// </summary>
    public string? TemplateName { get; init; }

    /// <summary>
    /// Loaded template image (set by ScreenRegions.LoadTemplates())
    /// </summary>
    internal Mat? Template { get; set; }

    /// <summary>
    /// Confidence threshold for template matching (0.0 to 1.0)
    /// </summary>
    public double Threshold { get; init; } = 0.7;

    /// <summary>
    /// Whether this template should use compass scaling (for HUD elements that scale differently)
    /// </summary>
    public bool UseCompassScale { get; init; } = false;

    /// <summary>
    /// Whether to use multi-channel (HSV) matching instead of grayscale matching.
    /// More robust to perspective changes and lighting variations.
    /// </summary>
    public bool UseMultiChannelMatching { get; init; } = false;

    /// <summary>
    /// Whether to apply CLAHE equalization to the template during loading.
    /// Should be true if the filter uses equalization.
    /// </summary>
    public bool EqualizeTemplate { get; init; } = false;

    /// <summary>
    /// Gets the absolute rectangle in pixels for the given screen dimensions
    /// </summary>
    public Rect GetRect(int screenWidth, int screenHeight)
    {
        var left = (int)(Bounds[0] * screenWidth);
        var top = (int)(Bounds[1] * screenHeight);
        var right = (int)(Bounds[2] * screenWidth);
        var bottom = (int)(Bounds[3] * screenHeight);

        return new Rect(left, top, right - left, bottom - top);
    }
}

/// <summary>
/// Manages screen regions for Elite Dangerous UI elements.
/// Based on EDAPGui's region definitions.
/// </summary>
public class ScreenRegions
{
    private readonly int _screenWidth;
    private readonly int _screenHeight;

    public Dictionary<RegionName, ScreenRegion> Regions { get; }

    public ScreenRegions(int screenWidth, int screenHeight)
    {
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        Regions = new Dictionary<RegionName, ScreenRegion>
        {
            [RegionName.NavBall] = new()
            {
                Name = RegionName.NavBall,
                Bounds = [0.30, 0.65, 0.47, 0.9],
                Filter = Filters.Equalize,
                TemplateName = "compass.png",
                Threshold = 0.35,  // Match EDAPGui's compass_match_thresh
                UseCompassScale = true,
                EqualizeTemplate = true  // Apply CLAHE to template to match filtered region
            },
            [RegionName.Target] = new()
            {
                Name = RegionName.Target,
                Bounds = [0.1, 0.27, 0.9, 0.70],  // Large region for ship pointing
                Filter = img => Filters.FilterByColor(img, Filters.Orange2ColorRange),
                TemplateName = "destination.png",
                Threshold = 0.3  // Accept 30% - finds correct location despite text noise
            },
            [RegionName.TargetOccluded] = new()
            {
                Name = RegionName.TargetOccluded,
                Bounds = [0.33, 0.27, 0.66, 0.70],
                Filter = img => Filters.FilterByColor(img, Filters.TargetOccludedRange),
                TemplateName = "target_occluded.png",
                Threshold = 0.6
            },
            [RegionName.Sun] = new()
            {
                Name = RegionName.Sun,
                Bounds = [0.30, 0.30, 0.70, 0.68],
                Filter = img => Filters.FilterSun(img),
                Threshold = 0.5
            },
            [RegionName.Disengage] = new()
            {
                Name = RegionName.Disengage,
                Bounds = [0.42, 0.65, 0.60, 0.80],
                Filter = img => Filters.FilterByColor(img, Filters.BlueScoColorRange),
                TemplateName = "sc-disengage.png",
                Threshold = 0.65
            },
            [RegionName.Sco] = new()
            {
                Name = RegionName.Sco,
                Bounds = [0.42, 0.65, 0.60, 0.80],
                Filter = img => Filters.FilterByColor(img, Filters.BlueScoColorRange),
                Threshold = 0.65
            },
            [RegionName.Fss] = new()
            {
                Name = RegionName.Fss,
                Bounds = [0.5045, 0.7545, 0.532, 0.7955],
                Filter = Filters.Equalize,
                TemplateName = "elw-template.png",
                Threshold = 0.65,
                EqualizeTemplate = true
            },
            [RegionName.MissionDest] = new()
            {
                Name = RegionName.MissionDest,
                Bounds = [0.46, 0.38, 0.65, 0.86],
                Filter = Filters.Equalize,
                TemplateName = "dest-sirius-atmos-HL.png",
                Threshold = 0.7,
                EqualizeTemplate = true
            },
            [RegionName.Missions] = new()
            {
                Name = RegionName.Missions,
                Bounds = [0.50, 0.78, 0.65, 0.85],
                Filter = Filters.Equalize,
                TemplateName = "completed-missions.png",
                Threshold = 0.7,
                EqualizeTemplate = true
            },
            [RegionName.NavPoint] = new()
            {
                Name = RegionName.NavPoint,
                Bounds = [0.25, 0.36, 0.60, 0.85],
                Filter = Filters.Equalize,
                TemplateName = "navpoint.png",
                Threshold = 0.7,
                UseCompassScale = true,
                EqualizeTemplate = true
            }
        };
    }

    /// <summary>
    /// Loads templates for all regions that have a TemplateName defined.
    /// Templates are loaded as grayscale and scaled to match current screen resolution.
    /// Templates are designed for 3440x1440 baseline resolution.
    /// </summary>
    /// <param name="templatesDirectory">Directory containing template images (default: "./Templates")</param>
    public void LoadTemplates(string? templatesDirectory = null)
    {
        // Try to find templates directory intelligently
        templatesDirectory ??= FindTemplatesDirectory();

        // Calculate scale factors based on baseline resolution 3440x1440
        const double baselineWidth = 3440.0;
        const double baselineHeight = 1440.0;

        var scaleX = _screenWidth / baselineWidth;
        var scaleY = _screenHeight / baselineHeight;

        // Compass elements use scaleX for both dimensions (matching EDAPGui)
        var compassScale = scaleX;

        foreach (var region in Regions.Values)
        {
            if (region.TemplateName != null)
            {
                var templatePath = Path.Combine(templatesDirectory, region.TemplateName);
                if (File.Exists(templatePath))
                {
                    // Load template as color if using multi-channel matching, otherwise grayscale
                    var loadMode = region.UseMultiChannelMatching ? ImreadModes.Color : ImreadModes.Grayscale;
                    using var originalTemplate = Cv2.ImRead(templatePath, loadMode);

                    // Determine which scale to use
                    var scale = region.UseCompassScale ? compassScale : scaleX;
                    var scaleFactorX = region.UseCompassScale ? compassScale : scaleX;
                    var scaleFactorY = region.UseCompassScale ? compassScale : scaleY;

                    // Scale the template to match current screen resolution
                    using var scaledTemplate = new Mat();
                    Cv2.Resize(originalTemplate, scaledTemplate, new Size(), scaleFactorX, scaleFactorY, InterpolationFlags.Linear);

                    // Apply CLAHE equalization to template if specified (to match equalized regions)
                    if (region.EqualizeTemplate)
                    {
                        region.Template = Filters.Equalize(scaledTemplate);
                    }
                    else
                    {
                        region.Template = scaledTemplate.Clone();
                    }
                }
                else
                {
                    throw new FileNotFoundException($"Template file not found: {templatePath}");
                }
            }
        }
    }

    private static string FindTemplatesDirectory()
    {
        // Try several common locations
        var possiblePaths = new[]
        {
            "./Templates",                                          // Current directory
            Path.Combine(AppContext.BaseDirectory, "Templates"),   // Output directory
            Path.Combine(Directory.GetCurrentDirectory(), "EliteAI", "Templates"), // Project root
            Path.Combine(Directory.GetCurrentDirectory(), "Templates") // Alternative
        };

        foreach (var path in possiblePaths)
        {
            if (Directory.Exists(path))
            {
                return path;
            }
        }

        throw new DirectoryNotFoundException(
            $"Templates directory not found. Searched in: {string.Join(", ", possiblePaths)}");
    }

    /// <summary>
    /// Creates a NavballDetector for detecting the navball/compass using Hough Circle Transform.
    /// </summary>
    /// <returns>A new NavballDetector instance</returns>
    public NavballDetector CreateNavballDetector()
    {
        var navballRegion = Regions[RegionName.NavBall];
        return new NavballDetector(_screenWidth, _screenHeight, navballRegion.Bounds);
    }

    /// <summary>
    /// Creates a Target detector for finding aim targets (destination marker or navball dot).
    /// </summary>
    /// <returns>A new Target instance</returns>
    public UI.Target CreateTarget()
    {
        var navballRegion = Regions[RegionName.NavBall];
        return new UI.Target(this, _screenWidth, _screenHeight, navballRegion.Bounds);
    }

    /// <summary>
    /// Disposes all loaded templates.
    /// </summary>
    public void DisposeTemplates()
    {
        foreach (var region in Regions.Values)
        {
            region.Template?.Dispose();
            region.Template = null;
        }
    }

    /// <summary>
    /// Extracts a region from the full screen capture
    /// </summary>
    public Mat GetRegion(Mat fullScreen, RegionName regionName)
    {
        if (!Regions.TryGetValue(regionName, out var region))
            throw new ArgumentException($"Region '{regionName}' not found", nameof(regionName));

        var rect = region.GetRect(_screenWidth, _screenHeight);
        return new Mat(fullScreen, rect);
    }

    /// <summary>
    /// Extracts and filters a region from the full screen capture
    /// </summary>
    public Mat GetFilteredRegion(Mat fullScreen, RegionName regionName)
    {
        if (!Regions.TryGetValue(regionName, out var region))
            throw new ArgumentException($"Region '{regionName}' not found", nameof(regionName));

        var rect = region.GetRect(_screenWidth, _screenHeight);
        var regionMat = new Mat(fullScreen, rect);

        if (region.Filter != null)
        {
            var filtered = region.Filter(regionMat);
            regionMat.Dispose();
            return filtered;
        }

        return regionMat;
    }

    /// <summary>
    /// Finds the template in the specified region. Combines region extraction, filtering, and template matching.
    /// </summary>
    /// <param name="fullScreen">Full screen capture</param>
    /// <param name="regionName">Region to search in</param>
    /// <param name="threshold">Confidence threshold (0.0 to 1.0), or null to use region's default</param>
    /// <param name="method">Template matching method</param>
    /// <param name="returnBestMatchRegardless">If true, returns best match even if below threshold (for debugging)</param>
    /// <returns>Template match if found and above threshold, null otherwise</returns>
    public TemplateMatch? FindTemplate(
        Mat fullScreen,
        RegionName regionName,
        double? threshold = null,
        TemplateMatchModes method = TemplateMatchModes.CCoeffNormed,
        bool returnBestMatchRegardless = false)
    {
        if (!Regions.TryGetValue(regionName, out var region))
            throw new ArgumentException($"Region '{regionName}' not found", nameof(regionName));

        if (region.Template == null)
            throw new InvalidOperationException($"Template not loaded for region '{regionName}'. Call LoadTemplates() first.");

        // Use region's threshold if not specified
        threshold ??= region.Threshold;

        using var regionMat = GetFilteredRegion(fullScreen, regionName);

        // Use multi-channel matching if specified for this region
        if (region.UseMultiChannelMatching)
        {
            return TemplateMatcher.FindTemplateMultiChannel(regionMat, region.Template, threshold.Value, method, returnBestMatchRegardless);
        }

        // Don't preprocess source since the filter already did it
        return TemplateMatcher.FindTemplate(regionMat, region.Template, threshold.Value, method, preprocessSource: false, returnBestMatchRegardless);
    }

    /// <summary>
    /// Finds all instances of the template in the specified region.
    /// </summary>
    public IEnumerable<TemplateMatch> FindAllTemplates(
        Mat fullScreen,
        RegionName regionName,
        double? threshold = null,
        TemplateMatchModes method = TemplateMatchModes.CCoeffNormed)
    {
        if (!Regions.TryGetValue(regionName, out var region))
            throw new ArgumentException($"Region '{regionName}' not found", nameof(regionName));

        if (region.Template == null)
            throw new InvalidOperationException($"Template not loaded for region '{regionName}'. Call LoadTemplates() first.");

        // Use region's threshold if not specified
        threshold ??= region.Threshold;

        using var regionMat = GetFilteredRegion(fullScreen, regionName);

        // Don't preprocess source since the filter already did it
        return TemplateMatcher.FindAllTemplates(regionMat, region.Template, threshold.Value, method, preprocessSource: false);
    }
}

/// <summary>
/// Image filters for screen regions, matching EDAPGui's filter implementations.
/// </summary>
public static class Filters
{
    // HSV color ranges for filtering (matches EDAPGui values)
    public static readonly (Scalar Lower, Scalar Upper) Orange2ColorRange =
        (new Scalar(16, 165, 220), new Scalar(98, 255, 255));

    public static readonly (Scalar Lower, Scalar Upper) TargetOccludedRange =
        (new Scalar(16, 31, 85), new Scalar(26, 160, 212));

    public static readonly (Scalar Lower, Scalar Upper) BlueScoColorRange =
        (new Scalar(10, 0, 0), new Scalar(100, 150, 255));

    public static readonly (Scalar Lower, Scalar Upper) OrangeColorRange =
        (new Scalar(0, 130, 123), new Scalar(25, 235, 220));

    public static readonly (Scalar Lower, Scalar Upper) BlueColorRange =
        (new Scalar(0, 28, 170), new Scalar(180, 100, 255));

    public static readonly (Scalar Lower, Scalar Upper) FssColorRange =
        (new Scalar(95, 210, 70), new Scalar(105, 255, 120));

    /// <summary>
    /// Applies CLAHE histogram equalization for improved contrast.
    /// Matches EDAPGui's equalize filter.
    /// </summary>
    public static Mat Equalize(Mat image)
    {
        // Convert to grayscale if needed
        var gray = image.Channels() == 1 ? image.Clone() : new Mat();
        if (image.Channels() > 1)
        {
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
        }

        // Create CLAHE object (clipLimit=2.0, tileGridSize=(8,8))
        using var clahe = Cv2.CreateCLAHE(clipLimit: 2.0, tileGridSize: new Size(8, 8));
        var equalized = new Mat();
        clahe.Apply(gray, equalized);

        if (image.Channels() > 1)
            gray.Dispose();

        return equalized;
    }

    /// <summary>
    /// Filters image based on HSV color range.
    /// Pixels within range become white, others black.
    /// </summary>
    public static Mat FilterByColor(Mat image, (Scalar Lower, Scalar Upper) colorRange)
    {
        // Convert BGR to HSV
        using var hsv = new Mat();
        Cv2.CvtColor(image, hsv, ColorConversionCodes.BGR2HSV);

        // Apply color range filter
        var filtered = new Mat();
        Cv2.InRange(hsv, colorRange.Lower, colorRange.Upper, filtered);

        return filtered;
    }

    /// <summary>
    /// Sun filter - converts to grayscale and applies threshold.
    /// Used to detect bright stars/suns in the view.
    /// </summary>
    public static Mat FilterSun(Mat image, int threshold = 25)
    {
        // Convert to grayscale
        using var gray = new Mat();
        Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

        // Apply threshold (set low to 25 to pick up dull red Class L stars)
        var filtered = new Mat();
        Cv2.Threshold(gray, filtered, threshold, 255, ThresholdTypes.Binary);

        return filtered;
    }

    /// <summary>
    /// Calculates the percentage of white pixels in a binary image.
    /// Used with FilterSun to determine sun brightness percentage.
    /// </summary>
    public static int CalculateWhitePercent(Mat binaryImage)
    {
        var white = Cv2.CountNonZero(binaryImage);
        var total = binaryImage.Rows * binaryImage.Cols;
        return (int)((white / (double)total) * 100);
    }
}

/// <summary>
/// Helper methods for drawing template matches on frames.
/// </summary>
public static class MatchDrawer
{
    /// <summary>
    /// Draws a template match on the frame with a bounding box and label.
    /// </summary>
    /// <param name="frame">The frame to draw on</param>
    /// <param name="match">The template match to draw</param>
    /// <param name="regionName">Name of the region (used for label)</param>
    /// <param name="regionRect">The region's absolute position on screen</param>
    /// <param name="color">Color of the bounding box and text (default: lime green)</param>
    /// <param name="thickness">Thickness of the bounding box (default: 2)</param>
    /// <param name="drawRegionBounds">Whether to draw the region boundary for debugging (default: false)</param>
    public static void DrawMatch(
        Mat frame,
        TemplateMatch match,
        RegionName regionName,
        Rect regionRect,
        Scalar? color = null,
        int thickness = 2,
        bool drawRegionBounds = false)
    {
        color ??= Scalar.LimeGreen;

        // Translate match location to full screen coordinates
        var screenLocation = new Point(
            regionRect.X + match.Location.X,
            regionRect.Y + match.Location.Y);

        var boundingBox = new Rect(screenLocation, match.TemplateSize);

        // Draw bounding box around match
        Cv2.Rectangle(frame, boundingBox, color.Value, thickness);

        // Draw label above the match
        var label = $"{regionName} {match.Confidence:P0}";
        var textSize = Cv2.GetTextSize(label, HersheyFonts.HersheySimplex, 0.6, 2, out var baseline);
        var textOrigin = screenLocation - new Point(0, 5);

        // Draw text background for better visibility
        var bgRect = new Rect(
            textOrigin.X - 2,
            textOrigin.Y - textSize.Height - 2,
            textSize.Width + 4,
            textSize.Height + baseline + 4);
        Cv2.Rectangle(frame, bgRect, Scalar.Black, -1);

        // Draw text
        Cv2.PutText(frame, label, textOrigin,
            HersheyFonts.HersheySimplex, 0.6, color.Value, 2);

        // Optionally draw region boundary for debugging
        if (drawRegionBounds)
        {
            Cv2.Rectangle(frame, regionRect, new Scalar(0, 255, 255), 1);
        }
    }

    /// <summary>
    /// Draws multiple template matches on the frame.
    /// </summary>
    public static void DrawMatches(
        Mat frame,
        IEnumerable<TemplateMatch> matches,
        RegionName regionName,
        Rect regionRect,
        Scalar? color = null,
        int thickness = 2,
        bool drawRegionBounds = false)
    {
        foreach (var match in matches)
        {
            DrawMatch(frame, match, regionName, regionRect, color, thickness, drawRegionBounds);
        }
    }
}
