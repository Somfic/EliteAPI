using EliteAI.OCR;
using EliteAI.UI;

namespace EliteAI;

/// <summary>
/// Example usage of the simplified EliteAI API.
/// These examples show how to use the high-level methods for common tasks.
/// </summary>
public static class Examples
{
    /// <summary>
    /// Example 1: Select a system in the left panel by name
    /// </summary>
    public static void SelectSystem()
    {
        using var ocr = new OCREngine();
        var leftPanel = new LeftPanel(
            ocr,
            EliteAI.Capture.ScreenCapture.ScreenWidth,
            EliteAI.Capture.ScreenCapture.ScreenHeight);

        // Simple one-liner to select a system/station
        leftPanel.Select("Robigo");
    }

    /// <summary>
    /// Example 2: Select by index (faster if you know the position)
    /// </summary>
    public static void SelectByIndex()
    {
        using var ocr = new OCREngine();
        var leftPanel = new LeftPanel(
            ocr,
            EliteAI.Capture.ScreenCapture.ScreenWidth,
            EliteAI.Capture.ScreenCapture.ScreenHeight);

        // Select the 3rd item in the list
        leftPanel.SelectByIndex(2); // 0-based
    }

    /// <summary>
    /// Example 3: Align to target (runs until ESC is pressed)
    /// </summary>
    public static void AlignToTarget()
    {
        var regions = new EliteAI.Capture.ScreenRegions(
            EliteAI.Capture.ScreenCapture.ScreenWidth,
            EliteAI.Capture.ScreenCapture.ScreenHeight);

        regions.LoadTemplates();
        var target = regions.CreateTarget();

        // Simple one-liner to align
        target.Align();

        regions.DisposeTemplates();
    }

    /// <summary>
    /// Example 4: Align until a condition is met
    /// </summary>
    public static void AlignUntilCondition()
    {
        var regions = new EliteAI.Capture.ScreenRegions(
            EliteAI.Capture.ScreenCapture.ScreenWidth,
            EliteAI.Capture.ScreenCapture.ScreenHeight);

        regions.LoadTemplates();
        var target = regions.CreateTarget();

        // Align for 10 seconds, then stop
        var startTime = DateTime.Now;
        target.AlignUntil(() => (DateTime.Now - startTime).TotalSeconds > 10);

        regions.DisposeTemplates();
    }

    /// <summary>
    /// Example 5: Complete mission workflow
    /// Select destination, then align to it
    /// </summary>
    public static void SelectAndAlignWorkflow()
    {
        // Step 1: Set up components
        using var ocr = new OCREngine();
        var leftPanel = new LeftPanel(
            ocr,
            EliteAI.Capture.ScreenCapture.ScreenWidth,
            EliteAI.Capture.ScreenCapture.ScreenHeight);

        var regions = new EliteAI.Capture.ScreenRegions(
            EliteAI.Capture.ScreenCapture.ScreenWidth,
            EliteAI.Capture.ScreenCapture.ScreenHeight);

        regions.LoadTemplates();
        var target = regions.CreateTarget();

        // Step 2: Select destination
        if (leftPanel.Select("Sirius Atmospherics"))
        {
            Console.WriteLine("Destination selected!");

            // Step 3: Align to target
            System.Threading.Thread.Sleep(1000); // Wait for UI to update
            target.Align();
        }
        else
        {
            Console.WriteLine("Destination not found!");
        }

        regions.DisposeTemplates();
    }
}
