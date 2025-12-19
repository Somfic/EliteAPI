using EliteAI.Capture;
using EliteAI.Input;
using OpenCvSharp;

namespace EliteAI.UI;

/// <summary>
/// Target detection system that finds aiming targets using multiple methods.
/// Priority: Template-based target marker, then navball target dot.
/// </summary>
public class Target
{
    private readonly NavballDetector _detector;
    private readonly ScreenRegions _regions;
    private readonly int _screenWidth;
    private readonly int _screenHeight;

    public Target(ScreenRegions regions, int screenWidth, int screenHeight, double[] navballRegionBounds)
    {
        _regions = regions;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
        _detector = new NavballDetector(screenWidth, screenHeight, navballRegionBounds);
    }

    /// <summary>
    /// Gets the best available target to aim at.
    /// Tries target marker first, falls back to navball target dot.
    /// </summary>
    /// <param name="fullScreen">Full screen capture</param>
    /// <returns>
    /// x,y coordinates as percentages from -1 to 1, where (0,0) is centered.
    /// Returns null if no target detected.
    /// Also returns the source name ("Target" or "Navball") for debugging.
    /// </returns>
    public (float x, float y, string source)? AimAtTarget(Mat fullScreen)
    {
        // Priority 1: Try to detect the Target (destination marker)
        var targetResult = GetTargetMarker(fullScreen);
        if (targetResult.HasValue)
            return (targetResult.Value.x, targetResult.Value.y, "Target");

        // Priority 2: Fall back to navball
        var navballResult = GetNavballTarget(fullScreen);
        if (navballResult.HasValue)
            return (navballResult.Value.x, navballResult.Value.y, "Navball");

        return null;
    }

    private const double MinTargetArea = 200.0; // Minimum area in pixels to detect target marker
    private const float TargetHorizontalOffsetPercent = -0.05f; // Offset right to compensate for text on left

    /// <summary>
    /// Gets the target marker (destination indicator) position using orange color detection.
    /// The target marker is a quarter circle, orange against black background.
    /// Uses contour detection to find the largest contiguous orange region.
    /// </summary>
    /// <param name="fullScreen">Full screen capture</param>
    /// <returns>
    /// x,y coordinates as percentages from -1 to 1 relative to screen center.
    /// Returns null if target marker not detected.
    /// </returns>
    public (float x, float y)? GetTargetMarker(Mat fullScreen)
    {
        // Get the target search region
        var targetRegion = _regions.Regions[RegionName.Target];
        var targetRect = targetRegion.GetRect(_screenWidth, _screenHeight);

        using var searchRegion = new Mat(fullScreen, targetRect);

        // Filter for orange (the target marker is orange)
        using var orangeFiltered = Filters.FilterByColor(searchRegion, Filters.Orange2ColorRange);

        // Find contours to identify grouped pixels (not scattered UI elements)
        Cv2.FindContours(orangeFiltered, out var contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        if (contours.Length == 0)
        {
            Console.WriteLine("[Target] No orange contours detected");
            return null;
        }

        // Find the largest contour (the target marker should be the biggest orange region)
        var largestContour = contours.OrderByDescending(c => Cv2.ContourArea(c)).First();
        var area = Cv2.ContourArea(largestContour);

        // Require minimum area to filter out small UI elements
        if (area < MinTargetArea)
        {
            Console.WriteLine($"[Target] Largest orange contour too small: {area:F0} px (min: {MinTargetArea})");
            return null;
        }

        // Calculate center of mass of the largest contour
        var moments = Cv2.Moments(largestContour);

        if (moments.M00 == 0)
        {
            Console.WriteLine("[Target] Invalid moments for largest contour");
            return null;
        }

        // Get center of the orange quarter-circle in region coordinates
        var targetCenterInRegion = new Point2f(
            (float)(moments.M10 / moments.M00),
            (float)(moments.M01 / moments.M00)
        );

        // Convert to screen coordinates
        var targetCenterX = targetRect.X + targetCenterInRegion.X;
        var targetCenterY = targetRect.Y + targetCenterInRegion.Y;

        // Calculate offset from screen center
        var screenCenterX = _screenWidth / 2f;
        var screenCenterY = _screenHeight / 2f;

        // Normalize to -1 to 1 range (using half screen width/height as reference)
        var normalizedX = (targetCenterX - screenCenterX) / (screenCenterX * 0.5f);
        var normalizedY = (targetCenterY - screenCenterY) / (screenCenterY * 0.5f);

        // Apply horizontal offset to compensate for text pulling center of mass left
        normalizedX += TargetHorizontalOffsetPercent;

        Console.WriteLine($"[Target] Orange contour detected (area: {area:F0} px, contours: {contours.Length}) at ({normalizedX:F2}, {normalizedY:F2})");
        return (normalizedX, normalizedY);
    }

    /// <summary>
    /// Gets the navball target indicator dot position relative to the navball center.
    /// </summary>
    /// <param name="fullScreen">Full screen capture</param>
    /// <returns>
    /// x,y coordinates as percentages from -1 to 1, where (0,0) is the center of the navball.
    /// Returns null if navball or target dot not detected.
    /// </returns>
    public (float x, float y)? GetNavballTarget(Mat fullScreen)
    {
        // Find the navball circle using Hough transform
        var navballCircle = _detector.FindNavball(fullScreen);
        if (navballCircle == null)
            return null;

        // Extract a region around the detected navball
        var center = navballCircle.Center;
        var radius = navballCircle.Radius;

        // Create a region slightly larger than the circle to capture the dot
        var regionSize = (int)(radius * 2.2);
        var regionLeft = (int)(center.X - regionSize / 2);
        var regionTop = (int)(center.Y - regionSize / 2);

        // Ensure region is within screen bounds
        regionLeft = Math.Max(0, Math.Min(regionLeft, _screenWidth - regionSize));
        regionTop = Math.Max(0, Math.Min(regionTop, _screenHeight - regionSize));

        var navballRect = new Rect(regionLeft, regionTop, regionSize, regionSize);
        using var navballRegion = new Mat(fullScreen, navballRect);

        // Filter for blue (the target dot is blue)
        using var blueFiltered = Filters.FilterByColor(navballRegion, Filters.BlueColorRange);

        // Calculate average position of all blue pixels (center of mass)
        var moments = Cv2.Moments(blueFiltered, true);

        if (moments.M00 == 0)
            return null;

        var targetDotCenter = new Point2f(
            (float)(moments.M10 / moments.M00),
            (float)(moments.M01 / moments.M00)
        );

        // Convert to screen coordinates
        var dotScreenX = regionLeft + targetDotCenter.X;
        var dotScreenY = regionTop + targetDotCenter.Y;

        // Calculate offset from navball center
        var offsetX = dotScreenX - center.X;
        var offsetY = dotScreenY - center.Y;

        // Normalize to -1 to 1 range (relative to navball radius)
        var normalizedX = offsetX / radius;
        var normalizedY = offsetY / radius;

        // Clamp to reasonable range
        normalizedX = Math.Max(-1, Math.Min(1, normalizedX));
        normalizedY = Math.Max(-1, Math.Min(1, normalizedY));

        return ((float)normalizedX, (float)normalizedY);
    }

    /// <summary>
    /// Gets the detected navball circle (for debugging/visualization)
    /// </summary>
    public DetectedCircle? GetNavballCircle(Mat fullScreen)
    {
        return _detector.FindNavball(fullScreen);
    }

    /// <summary>
    /// Gets the search region rectangle for navball detection
    /// </summary>
    public Rect SearchRegion => _detector.SearchRegion;

    /// <summary>
    /// Continuously aligns the ship to the target until Escape is pressed.
    /// Uses autopilot to automatically aim at detected targets.
    /// </summary>
    /// <param name="deadzone">Deadzone threshold (default: 0.05 = 5%)</param>
    public void Align(float deadzone = 0.05f)
    {
        AlignUntil(() => false, deadzone);
    }

    /// <summary>
    /// Aligns the ship to the target until a predicate returns true or Escape is pressed.
    /// Uses autopilot to automatically aim at detected targets.
    /// </summary>
    /// <param name="exitCondition">Function that returns true when alignment should stop</param>
    /// <param name="deadzone">Deadzone threshold (default: 0.05 = 5%)</param>
    public void AlignUntil(Func<bool> exitCondition, float deadzone = 0.05f)
    {
        var autopilot = new SimpleAutopilot(deadzone: deadzone);

        Console.WriteLine("[Target] Starting alignment... Press ESC to stop.");

        try
        {
            while (true)
            {
                using var frame = EliteAI.Capture.ScreenCapture.GetFrame();

                // Get the best available target
                var aimResult = AimAtTarget(frame);

                if (aimResult.HasValue)
                {
                    var (x, y, source) = aimResult.Value;
                    autopilot.Update(x, y);
                    Console.WriteLine($"[Target] {source}: ({x:F2}, {y:F2})");
                }
                else
                {
                    Console.WriteLine("[Target] No target detected");
                    autopilot.Stop();
                }

                // Check exit condition
                if (exitCondition())
                {
                    Console.WriteLine("[Target] Exit condition met, stopping alignment");
                    break;
                }

                // Check for ESC key
                var key = Cv2.WaitKey(1);
                if (key == 27) // ESC
                {
                    Console.WriteLine("[Target] ESC pressed, stopping alignment");
                    break;
                }
            }
        }
        finally
        {
            autopilot.Stop();
            Cv2.DestroyAllWindows();
            Console.WriteLine("[Target] Alignment stopped");
        }
    }
}
