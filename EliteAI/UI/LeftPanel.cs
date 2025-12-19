using EliteAI.Capture;
using EliteAI.Input;
using EliteAI.OCR;
using OpenCvSharp;

namespace EliteAI.UI;

/// <summary>
/// Represents a highlighted/selected item detected in the UI
/// </summary>
public class HighlightedItem
{
    public Mat Image { get; init; } = null!;
    public Point Location { get; init; }
    public string? Text { get; init; }
    public float Confidence { get; init; }
}

/// <summary>
/// Handles the left navigation panel in Elite Dangerous.
/// Uses OCR and image detection to find and select systems/stations.
/// Based on EDAPGui's approach.
/// </summary>
public class LeftPanel
{
    private readonly OCREngine _ocr;
    private readonly int _screenWidth;
    private readonly int _screenHeight;

    // Region definitions (normalized coordinates 0.0 to 1.0)
    private readonly Rect _navPanelRect;      // Full left panel area
    private readonly Rect _itemListRect;      // List of systems/stations

    // Minimum size for highlighted items at 1920x1080
    private const int BaseItemWidth = 500;
    private const int BaseItemHeight = 35;

    public LeftPanel(OCREngine ocr, int screenWidth, int screenHeight)
    {
        _ocr = ocr;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        // Define regions (based on EDAPGui measurements)
        // Nav panel: 11% to 70% width, 21% to 86% height
        _navPanelRect = new Rect(
            (int)(0.11 * screenWidth),
            (int)(0.21 * screenHeight),
            (int)((0.70 - 0.11) * screenWidth),
            (int)((0.86 - 0.21) * screenHeight)
        );

        // Item list region (within nav panel)
        // Location panel: 22.18% to 80% of panel width, 30% to 100% of panel height
        _itemListRect = new Rect(
            (int)(_navPanelRect.X + 0.2218 * _navPanelRect.Width),
            (int)(_navPanelRect.Y + 0.30 * _navPanelRect.Height),
            (int)((_navPanelRect.Width * (0.80 - 0.2218))),
            (int)(_navPanelRect.Height * 0.70)
        );
    }

    /// <summary>
    /// Detects the highlighted (selected) item in an image.
    /// Uses HSV masking to find solid orange/blue rectangles (Elite's selection highlight).
    /// Based on EDAPGui's get_highlighted_item_in_image method.
    /// </summary>
    /// <param name="image">Image to search</param>
    /// <param name="minWidth">Minimum width in pixels</param>
    /// <param name="minHeight">Minimum height in pixels</param>
    /// <returns>Highlighted item if found, null otherwise</returns>
    public HighlightedItem? GetHighlightedItem(Mat image, int minWidth, int minHeight)
    {
        if (image.Empty())
            return null;

        // Convert to HSV color space
        using var hsv = new Mat();
        Cv2.CvtColor(image, hsv, ColorConversionCodes.BGR2HSV);

        // Create mask for bright areas (highlighted selections are bright orange/blue)
        // Lower: H=0, S=100, V=180
        // Upper: H=255, S=255, V=255
        var lowerRange = new Scalar(0, 100, 180);
        var upperRange = new Scalar(255, 255, 255);

        using var mask = new Mat();
        Cv2.InRange(hsv, lowerRange, upperRange, mask);

        using var masked = new Mat();
        Cv2.BitwiseAnd(image, image, masked, mask);

        // Convert to grayscale
        using var gray = new Mat();
        Cv2.CvtColor(masked, gray, ColorConversionCodes.BGR2GRAY);

        // Slight blur to remove thin lines
        using var blurred = new Mat();
        Cv2.GaussianBlur(gray, blurred, new Size(3, 3), 0);

        // Threshold to create binary image
        using var thresh = new Mat();
        Cv2.Threshold(blurred, thresh, 0, 255, ThresholdTypes.Otsu);

        // Find contours
        Cv2.FindContours(thresh, out var contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        // Find first contour matching minimum size
        foreach (var contour in contours)
        {
            var rect = Cv2.BoundingRect(contour);

            // Check if item meets minimum size (allow 90% tolerance)
            if (rect.Width > (minWidth * 0.9) && rect.Height > (minHeight * 0.9))
            {
                // Crop to the highlighted rectangle
                var cropped = new Mat(image, rect);

                // Perform OCR on the cropped region
                var ocrResult = _ocr.ExtractTextWithConfidence(cropped);

                return new HighlightedItem
                {
                    Image = cropped.Clone(),
                    Location = new Point(rect.X, rect.Y),
                    Text = ocrResult?.text,
                    Confidence = ocrResult?.confidence ?? 0f
                };
            }
        }

        return null;
    }

    /// <summary>
    /// Gets the currently highlighted item in the navigation panel.
    /// </summary>
    public HighlightedItem? GetCurrentSelection(Mat fullScreen)
    {
        // Extract item list region
        using var listRegion = new Mat(fullScreen, _itemListRect);

        // Calculate scaled minimum size based on resolution
        var scaleX = _screenWidth / 1920.0;
        var scaleY = _screenHeight / 1080.0;

        // Use scaleX for both dimensions (station UI scales based on width)
        var minWidth = (int)(BaseItemWidth * scaleX);
        var minHeight = (int)(BaseItemHeight * scaleX);

        return GetHighlightedItem(listRegion, minWidth, minHeight);
    }

    /// <summary>
    /// Opens the left navigation panel.
    /// </summary>
    public void OpenPanel()
    {
        Console.WriteLine("[LeftPanel] Opening navigation panel");

        // Reset view and focus
        Keyboard.Press('H');  // HeadLookReset
        System.Threading.Thread.Sleep(100);

        // Open UI focus
        Keyboard.Press('F');  // UIFocus
        System.Threading.Thread.Sleep(100);

        // Navigate left to open left panel
        Keyboard.Press('A');  // UI_Left
        System.Threading.Thread.Sleep(300);

        // Exit UI focus mode
        Keyboard.Press('F');
        System.Threading.Thread.Sleep(100);
    }

    /// <summary>
    /// Navigates to the top of the list.
    /// </summary>
    public void GoToTop(int repeatCount = 20)
    {
        Console.WriteLine("[LeftPanel] Navigating to top of list");
        for (int i = 0; i < repeatCount; i++)
        {
            Keyboard.Press('W');  // UI_Up
            System.Threading.Thread.Sleep(50);
        }
    }

    /// <summary>
    /// Navigates down one item in the list.
    /// </summary>
    public void NavigateDown()
    {
        Keyboard.Press('S');  // UI_Down
        System.Threading.Thread.Sleep(100);
    }

    /// <summary>
    /// Selects the currently highlighted item.
    /// </summary>
    public void SelectCurrent()
    {
        Console.WriteLine("[LeftPanel] Selecting current item");
        Keyboard.Press('E');  // UI_Select
        System.Threading.Thread.Sleep(300);
    }

    /// <summary>
    /// Closes the left panel.
    /// </summary>
    public void ClosePanel()
    {
        Console.WriteLine("[LeftPanel] Closing navigation panel");
        Keyboard.Press('Q');  // UI_Back
        System.Threading.Thread.Sleep(100);
        Keyboard.Press('H');  // HeadLookReset
    }

    /// <summary>
    /// Test method to visualize the entire left panel with OCR detection
    /// Shows the original panel with detected text bounding boxes and rotation correction
    /// </summary>
    public void TestHighlightedDetection()
    {
        Console.WriteLine("[LeftPanel] Capturing entire left panel...");

        // Capture current screen
        using var screen = EliteAI.Capture.ScreenCapture.GetFrame();

        // Extract the entire item list region
        using var itemListRegion = new Mat(screen, _itemListRect);

        Console.WriteLine($"[LeftPanel] Panel size: {itemListRegion.Width}x{itemListRegion.Height}");

        // Detect rotation angle
        var rotationAngle = DetectRotationAngle(itemListRegion);
        Console.WriteLine($"[LeftPanel] Detected rotation angle: {rotationAngle:F2} degrees");

        // Create deskewed version
        using var deskewed = RotateImage(itemListRegion, -rotationAngle);

        // Detect and filter icons
        using var iconsFiltered = FilterIcons(deskewed, out var iconMask);

        // Run OCR on all versions and visualize
        var originalWithOcr = RunOcrAndVisualize(itemListRegion, $"1. Original (rotated {rotationAngle:F2}°)");
        var deskewedWithOcr = RunOcrAndVisualize(deskewed, "2. Deskewed");
        var filteredWithOcr = RunOcrAndVisualize(iconsFiltered, "3. Icons Filtered");

        Cv2.ImShow($"1. Original (rotated {rotationAngle:F2}°) + OCR", originalWithOcr);
        Cv2.ImShow("2. Deskewed + OCR", deskewedWithOcr);
        Cv2.ImShow("3. Icons Filtered + OCR", filteredWithOcr);
        Cv2.ImShow("4. Icon Mask (what gets removed)", iconMask);

        Console.WriteLine("[LeftPanel] Press any key in the image windows to continue...");
        Cv2.WaitKey(0);
        Cv2.DestroyAllWindows();
    }

    /// <summary>
    /// Real-time OCR visualization - continuously processes and displays OCR results
    /// Press ESC to stop
    /// </summary>
    public void TestHighlightedDetectionRealtime()
    {
        Console.WriteLine("[LeftPanel] Starting real-time OCR visualization...");
        Console.WriteLine("[LeftPanel] Press ESC to stop");

        while (true)
        {
            // Capture current screen
            using var screen = EliteAI.Capture.ScreenCapture.GetFrame();

            // Extract the entire item list region
            using var itemListRegion = new Mat(screen, _itemListRect);

            // Detect rotation angle
            var rotationAngle = DetectRotationAngle(itemListRegion);

            // Create deskewed version
            using var deskewed = RotateImage(itemListRegion, -rotationAngle);

            // Detect and filter icons
            using var iconsFiltered = FilterIcons(deskewed, out var iconMask);

            // Run OCR and visualize the final result
            var filteredWithOcr = RunOcrAndVisualize(iconsFiltered, "Real-time OCR");

            Cv2.ImShow("Real-time OCR (Icons Filtered)", filteredWithOcr);
            Cv2.ImShow("Icon Mask", iconMask);

            // Check for ESC key
            var key = Cv2.WaitKey(1);
            if (key == 27) // ESC
            {
                Console.WriteLine("[LeftPanel] Stopping real-time OCR");
                break;
            }
        }

        Cv2.DestroyAllWindows();
    }

    /// <summary>
    /// Two-pass OCR approach: Find text lines first, then crop icons from the left of each line
    /// </summary>
    private Mat FilterIcons(Mat image, out Mat iconMask)
    {
        Console.WriteLine("[LeftPanel] Two-pass icon filtering...");

        const int iconCropWidth = 40; // Pixels to crop from left of each text line

        // Create mask showing what we're removing
        iconMask = new Mat(image.Size(), MatType.CV_8UC1, Scalar.White);

        // Pass 1: Detect text line bounding boxes
        var textLineBounds = DetectTextLineBounds(image);

        Console.WriteLine($"[LeftPanel] Found {textLineBounds.Count} text lines, cropping {iconCropWidth}px from left of each");

        // Create filtered version - crop icons from each detected text line
        var result = image.Clone();

        foreach (var bounds in textLineBounds)
        {
            // Calculate how much to crop (don't crop more than the width allows)
            var cropWidth = Math.Min(iconCropWidth, bounds.Width - 10); // Leave at least 10px of text

            if (cropWidth > 0)
            {
                // Mark this region in the mask
                var cropRect = new Rect(bounds.X, bounds.Y, cropWidth, bounds.Height);
                Cv2.Rectangle(iconMask, cropRect, Scalar.Black, -1);

                // Blank it out in the result
                Cv2.Rectangle(result, cropRect, Scalar.White, -1);

                Console.WriteLine($"  Cropped {cropWidth}px from line at ({bounds.X}, {bounds.Y})");
            }
        }

        return result;
    }

    /// <summary>
    /// Detects text line bounding boxes using Tesseract (first pass)
    /// </summary>
    private List<Rect> DetectTextLineBounds(Mat image)
    {
        var bounds = new List<Rect>();

        // Convert to bytes for Tesseract
        Cv2.ImEncode(".png", image, out var buffer);
        using var pix = Tesseract.Pix.LoadFromMemory(buffer);

        // Create a temporary engine
        using var engine = new Tesseract.TesseractEngine("./tessdata", "eng", Tesseract.EngineMode.Default);
        using var page = engine.Process(pix);

        // Iterate through text lines
        using var iterator = page.GetIterator();
        iterator.Begin();

        do
        {
            if (iterator.TryGetBoundingBox(Tesseract.PageIteratorLevel.TextLine, out var lineBounds))
            {
                bounds.Add(new Rect(lineBounds.X1, lineBounds.Y1, lineBounds.Width, lineBounds.Height));
            }
        } while (iterator.Next(Tesseract.PageIteratorLevel.TextLine));

        return bounds;
    }

    /// <summary>
    /// Detects the rotation angle of text in an image using OpenCV edge detection
    /// </summary>
    private float DetectRotationAngle(Mat image)
    {
        // Convert to grayscale
        using var gray = new Mat();
        Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

        // Apply threshold to get binary image
        using var binary = new Mat();
        Cv2.Threshold(gray, binary, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);

        // Invert if needed (text should be white on black)
        var meanVal = Cv2.Mean(binary).Val0;
        if (meanVal > 127)
        {
            Cv2.BitwiseNot(binary, binary);
        }

        // Find contours of text
        Cv2.FindContours(binary, out var contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        if (contours.Length == 0)
            return 0;

        // Get angles from the largest contours
        var angles = new List<double>();
        foreach (var contour in contours.OrderByDescending(c => Cv2.ContourArea(c)).Take(10))
        {
            if (Cv2.ContourArea(contour) < 100)
                continue;

            var minRect = Cv2.MinAreaRect(contour);
            var angle = minRect.Angle;

            // Normalize angle to -45 to 45 range
            if (angle < -45)
                angle += 90;
            if (angle > 45)
                angle -= 90;

            angles.Add(angle);
        }

        if (angles.Count == 0)
            return 0;

        // Return median angle
        angles.Sort();
        var medianAngle = angles[angles.Count / 2];

        return (float)medianAngle;
    }

    /// <summary>
    /// Rotates an image by the specified angle
    /// </summary>
    private Mat RotateImage(Mat image, float angleDegrees)
    {
        // Get rotation matrix
        var center = new Point2f(image.Width / 2f, image.Height / 2f);
        var rotationMatrix = Cv2.GetRotationMatrix2D(center, angleDegrees, 1.0);

        // Rotate the image
        var rotated = new Mat();
        Cv2.WarpAffine(image, rotated, rotationMatrix, image.Size(), InterpolationFlags.Linear, BorderTypes.Constant, Scalar.Black);

        return rotated;
    }

    /// <summary>
    /// Runs OCR on an image and draws bounding boxes with detected text
    /// </summary>
    private Mat RunOcrAndVisualize(Mat image, string windowTitle)
    {
        Console.WriteLine($"[LeftPanel] Running OCR on {windowTitle}...");

        var result = image.Clone();

        // Convert to bytes for Tesseract
        Cv2.ImEncode(".png", image, out var buffer);
        using var pix = Tesseract.Pix.LoadFromMemory(buffer);

        // Create a temporary engine for detailed analysis
        using var engine = new Tesseract.TesseractEngine("./tessdata", "eng", Tesseract.EngineMode.Default);
        engine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ()-.,");

        using var page = engine.Process(pix);

        // Iterate through detected text regions at LINE level
        using var iterator = page.GetIterator();
        iterator.Begin();

        int lineCount = 0;

        do
        {
            if (iterator.TryGetBoundingBox(Tesseract.PageIteratorLevel.TextLine, out var bounds))
            {
                var text = iterator.GetText(Tesseract.PageIteratorLevel.TextLine);
                var confidence = iterator.GetConfidence(Tesseract.PageIteratorLevel.TextLine);

                if (!string.IsNullOrWhiteSpace(text))
                {
                    lineCount++;

                    // Draw bounding box
                    var rect = new Rect(bounds.X1, bounds.Y1, bounds.Width, bounds.Height);

                    // Color based on confidence: Green (high) -> Yellow (medium) -> Red (low)
                    Scalar color;
                    if (confidence > 80)
                        color = Scalar.LimeGreen;
                    else if (confidence > 60)
                        color = Scalar.Yellow;
                    else
                        color = Scalar.Red;

                    Cv2.Rectangle(result, rect, color, 2);

                    // Draw text label with full line text
                    var label = $"{text.Trim()} ({confidence:F0}%)";
                    var labelSize = Cv2.GetTextSize(label, HersheyFonts.HersheySimplex, 0.5, 1, out var baseline);

                    // Draw background for text label
                    var labelPos = new Point(bounds.X1, bounds.Y1 - 8);
                    Cv2.Rectangle(result,
                        new Rect(labelPos.X, labelPos.Y - labelSize.Height - 2, labelSize.Width, labelSize.Height + 4),
                        Scalar.Black, -1);

                    Cv2.PutText(result, label, new Point(labelPos.X, labelPos.Y - 2),
                        HersheyFonts.HersheySimplex, 0.5, color, 1);

                    Console.WriteLine($"  Line {lineCount}: '{text.Trim()}' ({confidence:F0}%)");
                }
            }
        } while (iterator.Next(Tesseract.PageIteratorLevel.TextLine));

        Console.WriteLine($"[LeftPanel] {windowTitle}: Detected {lineCount} lines");

        return result;
    }

    /// <summary>
    /// Searches for and selects a system or station by name.
    /// Handles panel opening/closing automatically.
    /// </summary>
    /// <param name="name">Name to search for (case-insensitive)</param>
    /// <param name="maxAttempts">Maximum number of items to check (default: 20)</param>
    /// <returns>True if found and selected, false otherwise</returns>
    public bool Select(string name, int maxAttempts = 20)
    {
        Console.WriteLine($"[LeftPanel] Selecting: {name}");

        try
        {
            OpenPanel();
            System.Threading.Thread.Sleep(500);

            var searchName = name.ToUpperInvariant();

            // Search through the list
            for (int i = 0; i < maxAttempts; i++)
            {
                // Capture current screen
                using var screen = EliteAI.Capture.ScreenCapture.GetFrame();

                // Get highlighted item
                var item = GetCurrentSelection(screen);

                if (item != null && item.Text != null)
                {
                    Console.WriteLine($"[LeftPanel] Item {i}: '{item.Text}' (confidence: {item.Confidence:F2})");

                    // Show what OCR is working with
                    Cv2.ImShow("Highlighted (Orange BG, Black Text)", item.Image);
                    Cv2.WaitKey(1);

                    // Check if this is our target
                    var itemTextUpper = item.Text.ToUpperInvariant();
                    if (itemTextUpper.Contains(searchName) || searchName.Contains(itemTextUpper))
                    {
                        Console.WriteLine($"[LeftPanel] Found match: '{item.Text}'");

                        // Select it
                        SelectCurrent();
                        System.Threading.Thread.Sleep(200);

                        // Select again to plot route/set destination
                        SelectCurrent();

                        Cv2.DestroyWindow("Highlighted (Orange BG, Black Text)");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine($"[LeftPanel] Item {i}: No text detected");
                }

                // Move to next item
                NavigateDown();
                System.Threading.Thread.Sleep(150);
            }

            Cv2.DestroyWindow("Highlighted (Orange BG, Black Text)");

            Console.WriteLine($"[LeftPanel] '{name}' not found in first {maxAttempts} items");
            return false;
        }
        finally
        {
            System.Threading.Thread.Sleep(500);
            ClosePanel();
        }
    }

    /// <summary>
    /// Selects an item by index (0-based).
    /// Faster than searching by name if position is known.
    /// Handles panel opening/closing automatically.
    /// </summary>
    public void SelectByIndex(int index)
    {
        Console.WriteLine($"[LeftPanel] Selecting item at index {index}");

        try
        {
            OpenPanel();
            System.Threading.Thread.Sleep(500);

            GoToTop();
            System.Threading.Thread.Sleep(200);

            // Navigate down to the desired index
            for (int i = 0; i < index; i++)
            {
                NavigateDown();
            }

            System.Threading.Thread.Sleep(100);

            // Select it
            SelectCurrent();
            System.Threading.Thread.Sleep(200);

            // Select again to plot route/set destination
            SelectCurrent();
        }
        finally
        {
            System.Threading.Thread.Sleep(500);
            ClosePanel();
        }
    }

    public Rect NavPanelRect => _navPanelRect;
    public Rect ItemListRect => _itemListRect;
}
