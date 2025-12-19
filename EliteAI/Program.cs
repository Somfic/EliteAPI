using OpenCvSharp;
using EliteAI.Capture;
using EliteAI.OCR;
using EliteAI.UI;

// Create OCR engine (auto-downloads tessdata on first run)
using var ocrEngine = new OCREngine();

// Create left panel handler
var leftPanel = new LeftPanel(
    ocrEngine,
    EliteAI.Capture.ScreenCapture.ScreenWidth,
    EliteAI.Capture.ScreenCapture.ScreenHeight);

Console.WriteLine("=== Elite Dangerous Left Panel Navigator ===");
Console.WriteLine("This tool helps you select systems/stations in the left navigation panel.");
Console.WriteLine();

while (true)
{
    Console.WriteLine("\n--- Main Menu ---");
    Console.WriteLine("1. Select by name (search)");
    Console.WriteLine("2. Select by index (position)");
    Console.WriteLine("3. Test panel detection (debug)");
    Console.WriteLine("3.5. Test OCR (single capture)");
    Console.WriteLine("3.6. Test OCR (real-time)");
    Console.WriteLine("4. Run autopilot (target detection)");
    Console.WriteLine("q. Quit");
    Console.Write("\nEnter choice: ");

    var choice = Console.ReadLine()?.Trim().ToLower();

    switch (choice)
    {
        case "1":
            SelectByName();
            break;

        case "2":
            SelectByIndex();
            break;

        case "3":
            TestPanelDetection();
            break;

        case "3.5":
            TestHighlightedVsNonHighlighted();
            break;

        case "3.6":
            TestOcrRealtime();
            break;

        case "4":
            Console.WriteLine("\nLaunching full autopilot (with debug visualization)...");
            EliteAI.AutopilotProgram.Run();
            break;

        case "q":
            Console.WriteLine("Exiting...");
            return;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

void SelectByName()
{
    Console.Write("\nEnter system/station name to search for: ");
    var searchName = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(searchName))
    {
        Console.WriteLine("No name entered.");
        return;
    }

    Console.WriteLine($"\nSearching for '{searchName}' in left panel...");
    Console.WriteLine("Make sure you're in the game with the left panel accessible!");
    Console.WriteLine("Starting in 3 seconds...");
    Thread.Sleep(3000);

    try
    {
        var found = leftPanel.Select(searchName);

        if (found)
        {
            Console.WriteLine($"\n✓ Successfully selected '{searchName}'!");
        }
        else
        {
            Console.WriteLine($"\n✗ '{searchName}' not found in first 20 items");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n✗ Error: {ex.Message}");
    }
}

void SelectByIndex()
{
    Console.Write("\nEnter item index (0-based, 0 = first item): ");
    var input = Console.ReadLine()?.Trim();

    if (!int.TryParse(input, out var index) || index < 0)
    {
        Console.WriteLine("Invalid index. Please enter a positive number.");
        return;
    }

    Console.WriteLine($"\nSelecting item at index {index}...");
    Console.WriteLine("Make sure you're in the game with the left panel accessible!");
    Console.WriteLine("Starting in 3 seconds...");
    Thread.Sleep(3000);

    try
    {
        leftPanel.SelectByIndex(index);
        Console.WriteLine($"\n✓ Selected item at index {index}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n✗ Error: {ex.Message}");
    }
}

void TestPanelDetection()
{
    Console.WriteLine("\nTesting panel detection...");
    Console.WriteLine("This will capture the screen and show what items are detected.");
    Console.WriteLine("Make sure the left panel is open!");
    Console.WriteLine("Starting in 3 seconds...");
    Thread.Sleep(3000);

    try
    {
        using var frame = EliteAI.Capture.ScreenCapture.GetFrame();

        // Draw left panel regions
        var frameWithRegions = frame.Clone();
        Cv2.Rectangle(frameWithRegions, leftPanel.NavPanelRect, new Scalar(255, 0, 255), 2);  // Magenta - full panel
        Cv2.Rectangle(frameWithRegions, leftPanel.ItemListRect, new Scalar(255, 255, 0), 2);  // Cyan - item list

        // Try to get current selection
        var selection = leftPanel.GetCurrentSelection(frame);

        if (selection != null)
        {
            Console.WriteLine($"\n✓ Detected highlighted item:");
            Console.WriteLine($"  Text: '{selection.Text}'");
            Console.WriteLine($"  Confidence: {selection.Confidence:F2}");
            Console.WriteLine($"  Location: ({selection.Location.X}, {selection.Location.Y})");

            // Draw selection on frame
            var selectionRect = new Rect(
                leftPanel.ItemListRect.X + selection.Location.X,
                leftPanel.ItemListRect.Y + selection.Location.Y,
                selection.Image.Width,
                selection.Image.Height
            );
            Cv2.Rectangle(frameWithRegions, selectionRect, Scalar.LimeGreen, 3);

            // Show the cropped selection
            Cv2.ImShow("Detected Selection", selection.Image);
        }
        else
        {
            Console.WriteLine("\n✗ No highlighted item detected");
            Console.WriteLine("Make sure:");
            Console.WriteLine("  1. The left panel is open");
            Console.WriteLine("  2. An item is highlighted/selected");
            Console.WriteLine("  3. You're in the game (not in menu)");
        }

        // Show full frame with regions
        using var resized = new Mat();
        Cv2.Resize(frameWithRegions, resized, new Size(), 0.5, 0.5);
        Cv2.ImShow("Panel Regions", resized);

        Console.WriteLine("\nPress any key in the image window to continue...");
        Cv2.WaitKey(0);
        Cv2.DestroyAllWindows();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n✗ Error: {ex.Message}");
    }
}

void TestHighlightedVsNonHighlighted()
{
    Console.WriteLine("\nTesting OCR with single capture...");
    Console.WriteLine("This will show OCR results with rotation correction and icon filtering.");
    Console.WriteLine("Make sure the left panel is open!");
    Console.WriteLine("Starting in 3 seconds...");
    Thread.Sleep(3000);

    try
    {
        leftPanel.TestHighlightedDetection();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n✗ Error: {ex.Message}");
    }
}

void TestOcrRealtime()
{
    Console.WriteLine("\nStarting real-time OCR visualization...");
    Console.WriteLine("This will continuously show OCR results as you navigate.");
    Console.WriteLine("Make sure the left panel is open!");
    Console.WriteLine("Starting in 3 seconds...");
    Thread.Sleep(3000);

    try
    {
        leftPanel.TestHighlightedDetectionRealtime();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n✗ Error: {ex.Message}");
    }
}
