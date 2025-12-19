using OpenCvSharp;
using Tesseract;
using System.Net.Http;

namespace EliteAI.OCR;

/// <summary>
/// OCR engine wrapper using Tesseract for text recognition in Elite Dangerous UI elements.
/// </summary>
public class OCREngine : IDisposable
{
    private readonly TesseractEngine _engine;
    private bool _disposed;

    private const string TessdataUrl = "https://github.com/tesseract-ocr/tessdata/raw/main/eng.traineddata";

    public OCREngine(string tessDataPath = "./tessdata", string language = "eng")
    {
        // Ensure tessdata exists
        EnsureTessdata(tessDataPath, language).Wait();

        // Initialize Tesseract engine
        _engine = new TesseractEngine(tessDataPath, language, EngineMode.Default);

        // Configure for Elite Dangerous UI
        // White text on dark background, clean sans-serif font
        _engine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ()-.,");
    }

    /// <summary>
    /// Ensures tessdata exists, downloads if necessary
    /// </summary>
    private static async Task EnsureTessdata(string tessDataPath, string language)
    {
        // Create directory if it doesn't exist
        if (!Directory.Exists(tessDataPath))
        {
            Console.WriteLine($"[OCR] Creating tessdata directory: {tessDataPath}");
            Directory.CreateDirectory(tessDataPath);
        }

        var trainedDataFile = Path.Combine(tessDataPath, $"{language}.traineddata");

        // Check if trained data file exists
        if (File.Exists(trainedDataFile))
        {
            Console.WriteLine($"[OCR] Tessdata already exists: {trainedDataFile}");
            return;
        }

        // Download it
        Console.WriteLine($"[OCR] Downloading tessdata for language: {language}");
        Console.WriteLine($"[OCR] From: {TessdataUrl}");

        try
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(2);

            var response = await client.GetAsync(TessdataUrl);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(trainedDataFile, data);

            Console.WriteLine($"[OCR] Successfully downloaded tessdata to: {trainedDataFile}");
            Console.WriteLine($"[OCR] File size: {data.Length / 1024} KB");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[OCR] Failed to download tessdata: {ex.Message}");
            throw new Exception($"Failed to download Tesseract trained data. Please manually download from {TessdataUrl} and place in {tessDataPath}", ex);
        }
    }

    /// <summary>
    /// Performs OCR on an OpenCV Mat image.
    /// </summary>
    /// <param name="image">Image to perform OCR on</param>
    /// <returns>Recognized text, or null if no text found</returns>
    public string? ExtractText(Mat image)
    {
        if (image.Empty())
            return null;

        // Convert Mat to byte array
        using var encoded = new Mat();
        Cv2.ImEncode(".png", image, out var buffer);

        // Create Pix from byte array
        using var pix = Pix.LoadFromMemory(buffer);

        // Perform OCR
        using var page = _engine.Process(pix);
        var text = page.GetText();

        return string.IsNullOrWhiteSpace(text) ? null : text.Trim();
    }

    /// <summary>
    /// Extracts text with confidence score.
    /// </summary>
    public (string text, float confidence)? ExtractTextWithConfidence(Mat image)
    {
        if (image.Empty())
            return null;

        using var encoded = new Mat();
        Cv2.ImEncode(".png", image, out var buffer);

        using var pix = Pix.LoadFromMemory(buffer);
        using var page = _engine.Process(pix);

        var text = page.GetText();
        var confidence = page.GetMeanConfidence();

        if (string.IsNullOrWhiteSpace(text))
            return null;

        return (text.Trim(), confidence);
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _engine?.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}
