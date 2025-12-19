using OpenCvSharp;
using EliteAI.Capture;
using EliteAI.Input;

namespace EliteAI;

/// <summary>
/// Autopilot program with navball/target detection and flight control
/// </summary>
public class AutopilotProgram
{
    public static void Run()
    {
        var regions = new ScreenRegions(
            EliteAI.Capture.ScreenCapture.ScreenWidth,
            EliteAI.Capture.ScreenCapture.ScreenHeight);

        // Only load templates for non-navball regions (navball uses circle detection)
        regions.LoadTemplates();

        // Create target detector (handles both target marker and navball)
        var target = regions.CreateTarget();

        // Create autopilot (0.05 = 5% deadzone)
        var autopilot = new SimpleAutopilot(deadzone: 0.05f);
        bool autopilotEnabled = false;

        // Create global hotkey for 'P' (VK_P = 0x50)
        var toggleHotkey = new GlobalHotkey(0x50);

        Console.WriteLine("Press 'P' to toggle autopilot (works from any window!), 'q' to quit");

        while (true)
        {
            using var frame = EliteAI.Capture.ScreenCapture.GetFrame();

            // Get the best available target (tries target marker first, falls back to navball)
            var aimResult = target.AimAtTarget(frame);

            // Visualization: Draw navball if detected
            var navballCircle = target.GetNavballCircle(frame);
            if (navballCircle != null)
            {
                // Draw the detected navball circle
                Cv2.Circle(frame, (Point)navballCircle.Center, (int)navballCircle.Radius, Scalar.LimeGreen, 2);
                Cv2.Circle(frame, (Point)navballCircle.Center, 2, Scalar.Red, 3); // Center point

                // If using navball for aiming, show the target dot
                if (aimResult.HasValue && aimResult.Value.source == "Navball")
                {
                    var (x, y, _) = aimResult.Value;
                    var targetScreenX = navballCircle.Center.X + (x * navballCircle.Radius);
                    var targetScreenY = navballCircle.Center.Y + (y * navballCircle.Radius);

                    Cv2.Circle(frame, new Point((int)targetScreenX, (int)targetScreenY), 5, Scalar.Cyan, -1);

                    // Show blue filter debug window
                    var center = navballCircle.Center;
                    var radius = navballCircle.Radius;
                    var regionSize = (int)(radius * 2.2);
                    var regionLeft = (int)(center.X - regionSize / 2);
                    var regionTop = (int)(center.Y - regionSize / 2);
                    regionLeft = Math.Max(0, Math.Min(regionLeft, EliteAI.Capture.ScreenCapture.ScreenWidth - regionSize));
                    regionTop = Math.Max(0, Math.Min(regionTop, EliteAI.Capture.ScreenCapture.ScreenHeight - regionSize));

                    var debugRect = new Rect(regionLeft, regionTop, regionSize, regionSize);
                    using var navballRegion = new Mat(frame, debugRect);
                    using var blueFiltered = Filters.FilterByColor(navballRegion, Filters.BlueColorRange);
                    Cv2.ImShow("Blue Filtered (Target Dot)", blueFiltered);
                }
            }

            // Visualization: Draw target marker if detected (regardless of being used)
            var targetMarkerPos = target.GetTargetMarker(frame);
            if (targetMarkerPos.HasValue)
            {
                var (x, y) = targetMarkerPos.Value;
                var screenCenterX = EliteAI.Capture.ScreenCapture.ScreenWidth / 2f;
                var screenCenterY = EliteAI.Capture.ScreenCapture.ScreenHeight / 2f;

                // Calculate target position from normalized coordinates
                var targetScreenX = screenCenterX + (x * screenCenterX * 0.5f);
                var targetScreenY = screenCenterY + (y * screenCenterY * 0.5f);

                // Draw the detected target marker (magenta circle)
                Cv2.Circle(frame, new Point((int)targetScreenX, (int)targetScreenY), 10, Scalar.Magenta, 3);

                // Draw crosshair at screen center
                Cv2.Line(frame, new Point((int)screenCenterX - 20, (int)screenCenterY),
                         new Point((int)screenCenterX + 20, (int)screenCenterY), Scalar.Yellow, 2);
                Cv2.Line(frame, new Point((int)screenCenterX, (int)screenCenterY - 20),
                         new Point((int)screenCenterX, (int)screenCenterY + 20), Scalar.Yellow, 2);
            }

            // Debug: Show Target search region and filtered view
            var targetRegion = regions.Regions[RegionName.Target];
            var targetRect = targetRegion.GetRect(EliteAI.Capture.ScreenCapture.ScreenWidth, EliteAI.Capture.ScreenCapture.ScreenHeight);
            Cv2.Rectangle(frame, targetRect, Scalar.Orange, 1);

            // Show the orange-filtered region being used for detection
            using var targetSearchRegion = new Mat(frame, targetRect);
            using var orangeFiltered = Filters.FilterByColor(targetSearchRegion, Filters.Orange2ColorRange);
            Cv2.ImShow("Target Orange Filtered", orangeFiltered);

            // Update autopilot with the best available target
            if (aimResult.HasValue)
            {
                var (x, y, source) = aimResult.Value;

                if (autopilotEnabled)
                {
                    autopilot.Update(x, y);
                    Console.WriteLine($"{source}: Target=({x:F2}, {y:F2}) | AUTOPILOT ACTIVE");
                }
                else
                {
                    Console.WriteLine($"{source}: Target=({x:F2}, {y:F2})");
                }
            }
            else
            {
                Console.WriteLine("No target detected");
                if (autopilotEnabled)
                    autopilot.Stop();
            }

            // Draw region bounds
            var searchRect = target.SearchRegion;
            Cv2.Rectangle(frame, searchRect, new Scalar(0, 255, 255), 1);

            // Draw autopilot status
            var statusLabel = autopilotEnabled ? "AUTOPILOT: ON (P to disable)" : "AUTOPILOT: OFF (P to enable)";
            Cv2.PutText(frame, statusLabel, new Point(10, 30),
                HersheyFonts.HersheySimplex, 0.7, autopilotEnabled ? Scalar.LimeGreen : Scalar.Red, 2);

            // Show full screen at 50% size
            using var resizedFrame = new Mat();
            Cv2.Resize(frame, resizedFrame, new Size(), 0.5, 0.5);
            Cv2.ImShow("NavBall Target Detection", resizedFrame);

            // Check for global hotkey press
            if (toggleHotkey.WasPressed())
            {
                autopilotEnabled = !autopilotEnabled;
                if (!autopilotEnabled)
                    autopilot.Stop();
                Console.WriteLine($"Autopilot {(autopilotEnabled ? "ENABLED" : "DISABLED")}");
            }

            // Wait 1ms for key press (for 'q' to quit)
            var key = Cv2.WaitKey(1);

            // Break on 'q' or ESC
            if (key is 'q' or 27) break;
        }

        // Clean up
        autopilot.Stop();
        regions.DisposeTemplates();
        Cv2.DestroyAllWindows();
        Console.WriteLine("Autopilot stopped.");
    }
}
