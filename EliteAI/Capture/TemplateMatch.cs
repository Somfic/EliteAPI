using OpenCvSharp;

namespace EliteAI.Capture;

public class TemplateMatch
{
    public Point Location { get; init; }
    public double Confidence { get; init; }
    public Size TemplateSize { get; init; }

    public Rect BoundingBox => new(Location, TemplateSize);
}

public static class TemplateMatcher
{
    /// <summary>
    /// Preprocesses an image for template matching using CLAHE histogram equalization.
    /// Matches EDAPGui's approach for improved contrast.
    /// </summary>
    public static Mat PreprocessForMatching(Mat source, bool applyClipLimit = true)
    {
        // Convert to grayscale if needed
        var gray = source.Channels() == 1 ? source.Clone() : new Mat();
        if (source.Channels() > 1)
        {
            Cv2.CvtColor(source, gray, ColorConversionCodes.BGR2GRAY);
        }

        // Apply CLAHE (Contrast Limited Adaptive Histogram Equalization)
        // Same parameters as EDAPGui: clipLimit=2.0, tileGridSize=(8,8)
        if (applyClipLimit)
        {
            using var clahe = Cv2.CreateCLAHE(clipLimit: 2.0, tileGridSize: new Size(8, 8));
            var equalized = new Mat();
            clahe.Apply(gray, equalized);

            if (source.Channels() > 1)
                gray.Dispose();

            return equalized;
        }

        return gray;
    }

    public static TemplateMatch? FindTemplate(Mat source, Mat template, double threshold = 0.8, TemplateMatchModes method = TemplateMatchModes.CCoeffNormed, bool preprocessSource = true, bool returnBestMatchRegardless = false)
    {
        using var processedSource = preprocessSource ? PreprocessForMatching(source) : source.Clone();
        using var processedTemplate = template.Channels() == 1 ? template.Clone() : PreprocessForMatching(template, false);

        using var result = new Mat();
        Cv2.MatchTemplate(processedSource, processedTemplate, result, method);

        Cv2.MinMaxLoc(result, out _, out var maxVal, out _, out var maxLoc);

        // For some methods, lower is better
        var confidence = method is TemplateMatchModes.SqDiff or TemplateMatchModes.SqDiffNormed
            ? 1 - maxVal
            : maxVal;

        // Return best match regardless of threshold if requested (for debugging)
        if (returnBestMatchRegardless || confidence >= threshold)
        {
            return new TemplateMatch
            {
                Location = maxLoc,
                Confidence = confidence,
                TemplateSize = processedTemplate.Size()
            };
        }

        return null;
    }

    public static IEnumerable<TemplateMatch> FindAllTemplates(Mat source, Mat template, double threshold = 0.8, TemplateMatchModes method = TemplateMatchModes.CCoeffNormed, bool preprocessSource = true)
    {
        using var processedSource = preprocessSource ? PreprocessForMatching(source) : source.Clone();
        using var processedTemplate = template.Channels() == 1 ? template.Clone() : PreprocessForMatching(template, false);

        using var result = new Mat();
        Cv2.MatchTemplate(processedSource, processedTemplate, result, method);

        var matches = new List<TemplateMatch>();

        for (int y = 0; y < result.Rows; y++)
        {
            for (int x = 0; x < result.Cols; x++)
            {
                var value = result.At<float>(y, x);
                var confidence = method is TemplateMatchModes.SqDiff or TemplateMatchModes.SqDiffNormed
                    ? 1 - value
                    : value;

                if (confidence >= threshold)
                {
                    matches.Add(new TemplateMatch
                    {
                        Location = new Point(x, y),
                        Confidence = confidence,
                        TemplateSize = processedTemplate.Size()
                    });
                }
            }
        }

        // Remove overlapping matches, keep only the best ones
        return RemoveOverlaps(matches, processedTemplate.Size());
    }

    /// <summary>
    /// Multi-channel template matching similar to EDAPGui's match_template_in_region_x3.
    /// Tests H, S, V channels separately and returns the best result.
    /// More robust to perspective changes and lighting variations.
    /// </summary>
    public static TemplateMatch? FindTemplateMultiChannel(Mat source, Mat template, double threshold = 0.8, TemplateMatchModes method = TemplateMatchModes.CCoeffNormed, bool returnBestMatchRegardless = false)
    {
        // Validate that template is smaller than source
        if (template.Width > source.Width || template.Height > source.Height)
        {
            return null;
        }

        // Convert both source and template to HSV
        using var sourceHsv = new Mat();
        using var templateHsv = new Mat();

        if (source.Channels() == 3)
        {
            Cv2.CvtColor(source, sourceHsv, ColorConversionCodes.BGR2HSV);
        }
        else
        {
            // If already grayscale, just use it directly as a single channel
            return FindTemplate(source, template, threshold, method, preprocessSource: false, returnBestMatchRegardless);
        }

        if (template.Channels() == 3)
        {
            Cv2.CvtColor(template, templateHsv, ColorConversionCodes.BGR2HSV);
        }
        else
        {
            return FindTemplate(source, template, threshold, method, preprocessSource: false, returnBestMatchRegardless);
        }

        // Split into H, S, V channels
        var sourceChannels = Cv2.Split(sourceHsv);
        var templateChannels = Cv2.Split(templateHsv);

        TemplateMatch? bestMatch = null;

        try
        {
            // Test each channel separately and keep the best match
            for (int i = 0; i < 3; i++)
            {
                using var result = new Mat();
                Cv2.MatchTemplate(sourceChannels[i], templateChannels[i], result, method);

                Cv2.MinMaxLoc(result, out _, out var maxVal, out _, out var maxLoc);

                var confidence = method is TemplateMatchModes.SqDiff or TemplateMatchModes.SqDiffNormed
                    ? 1 - maxVal
                    : maxVal;

                if (bestMatch == null || confidence > bestMatch.Confidence)
                {
                    bestMatch = new TemplateMatch
                    {
                        Location = maxLoc,
                        Confidence = confidence,
                        TemplateSize = templateChannels[i].Size()
                    };
                }
            }
        }
        finally
        {
            // Dispose all channels
            foreach (var channel in sourceChannels)
                channel.Dispose();
            foreach (var channel in templateChannels)
                channel.Dispose();
        }

        // Return best match regardless of threshold if requested
        if (returnBestMatchRegardless || (bestMatch != null && bestMatch.Confidence >= threshold))
        {
            return bestMatch;
        }

        return null;
    }

    private static IEnumerable<TemplateMatch> RemoveOverlaps(List<TemplateMatch> matches, Size templateSize)
    {
        var sorted = matches.OrderByDescending(m => m.Confidence).ToList();
        var result = new List<TemplateMatch>();

        foreach (var match in sorted)
        {
            var overlaps = result.Any(r =>
                Math.Abs(r.Location.X - match.Location.X) < templateSize.Width * 0.5 &&
                Math.Abs(r.Location.Y - match.Location.Y) < templateSize.Height * 0.5);

            if (!overlaps)
                result.Add(match);
        }

        return result;
    }
}
