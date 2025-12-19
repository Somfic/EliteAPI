using OpenCvSharp;

namespace EliteAI.Capture;

/// <summary>
/// Represents a detected circle from Hough Circle Transform
/// </summary>
public class DetectedCircle
{
    public Point2f Center { get; init; }
    public float Radius { get; init; }
}

/// <summary>
/// Navball/compass detector using Hough Circle Transform.
/// Much more robust than template matching since the navball is a circular shape.
/// </summary>
public class NavballDetector
{
    private readonly int _screenWidth;
    private readonly int _screenHeight;
    private readonly Rect _searchRegion;

    // Temporal smoothing
    private DetectedCircle? _lastDetectedCircle = null;
    private int _notDetectedFrames = 0;
    private const int MaxMissedFrames = 5; // Allow up to 5 frames of missed detection before losing track

    public NavballDetector(int screenWidth, int screenHeight, double[] regionBounds)
    {
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        // Convert normalized bounds to pixel coordinates
        var left = (int)(regionBounds[0] * screenWidth);
        var top = (int)(regionBounds[1] * screenHeight);
        var right = (int)(regionBounds[2] * screenWidth);
        var bottom = (int)(regionBounds[3] * screenHeight);

        _searchRegion = new Rect(left, top, right - left, bottom - top);
    }

    /// <summary>
    /// Finds the navball using Hough Circle Transform with temporal smoothing.
    /// </summary>
    /// <param name="fullScreen">Full screen capture</param>
    /// <returns>Circle if found, null otherwise</returns>
    public DetectedCircle? FindNavball(Mat fullScreen)
    {
        // Extract the navball region
        using var regionMat = new Mat(fullScreen, _searchRegion);

        // Filter for orange color to isolate the navball's orange elements
        using var orangeFiltered = Filters.FilterByColor(regionMat, Filters.OrangeColorRange);

        // Debug: Show the filtered result
        Cv2.ImShow("Navball Orange Filtered", orangeFiltered);

        // Apply Gaussian blur to reduce noise
        using var blurred = new Mat();
        Cv2.GaussianBlur(orangeFiltered, blurred, new Size(9, 9), 2);

        // Detect circles using Hough Circle Transform
        // Parameters tuned for the navball which has clear circular edges
        // Expected radius: ~34 pixels
        var circles = Cv2.HoughCircles(
            blurred,
            HoughModes.Gradient,
            dp: 1,              // Inverse ratio of accumulator resolution
            minDist: 50,        // Minimum distance between circle centers
            param1: 50,         // Canny edge detection threshold (lower = more edges)
            param2: 20,         // Accumulator threshold for circle detection (lower = more circles)
            minRadius: 25,      // Minimum circle radius (lowered from 25)
            maxRadius: 45       // Maximum circle radius (increased from 45)
        );

        Console.WriteLine($"[Navball] Hough detected {circles.Length} circles");
        if (circles.Length > 0)
        {
            for (int i = 0; i < Math.Min(3, circles.Length); i++)
            {
                Console.WriteLine($"  Circle {i}: center=({circles[i].Center.X:F1}, {circles[i].Center.Y:F1}), radius={circles[i].Radius:F1}");
            }
        }

        DetectedCircle? detectedCircle = null;

        if (circles.Length > 0)
        {
            // If we have a previous detection, find the circle closest to it
            if (_lastDetectedCircle != null && circles.Length > 1)
            {
                var bestCircle = circles[0];
                var minDistance = float.MaxValue;

                foreach (var c in circles)
                {
                    var screenPos = new Point2f(_searchRegion.X + c.Center.X, _searchRegion.Y + c.Center.Y);
                    var distance = Math.Sqrt(
                        Math.Pow(screenPos.X - _lastDetectedCircle.Center.X, 2) +
                        Math.Pow(screenPos.Y - _lastDetectedCircle.Center.Y, 2));

                    if (distance < minDistance)
                    {
                        minDistance = (float)distance;
                        bestCircle = c;
                    }
                }

                detectedCircle = new DetectedCircle
                {
                    Center = new Point2f(_searchRegion.X + bestCircle.Center.X, _searchRegion.Y + bestCircle.Center.Y),
                    Radius = bestCircle.Radius
                };
            }
            else
            {
                // Use the first (strongest) circle
                var circle = circles[0];
                detectedCircle = new DetectedCircle
                {
                    Center = new Point2f(_searchRegion.X + circle.Center.X, _searchRegion.Y + circle.Center.Y),
                    Radius = circle.Radius
                };
            }

            // Smooth the position with previous detection
            if (_lastDetectedCircle != null)
            {
                const float smoothingFactor = 0.7f; // 0.7 = use 70% new, 30% old
                detectedCircle = new DetectedCircle
                {
                    Center = new Point2f(
                        _lastDetectedCircle.Center.X * (1 - smoothingFactor) + detectedCircle.Center.X * smoothingFactor,
                        _lastDetectedCircle.Center.Y * (1 - smoothingFactor) + detectedCircle.Center.Y * smoothingFactor
                    ),
                    Radius = _lastDetectedCircle.Radius * (1 - smoothingFactor) + detectedCircle.Radius * smoothingFactor
                };
            }

            _lastDetectedCircle = detectedCircle;
            _notDetectedFrames = 0;
        }
        else
        {
            // Not detected this frame
            _notDetectedFrames++;

            // If we recently had a detection, keep returning it for a few frames
            if (_notDetectedFrames <= MaxMissedFrames && _lastDetectedCircle != null)
            {
                detectedCircle = _lastDetectedCircle;
            }
            else
            {
                _lastDetectedCircle = null;
            }
        }

        return detectedCircle;
    }

    /// <summary>
    /// Gets the search region rectangle
    /// </summary>
    public Rect SearchRegion => _searchRegion;
}
