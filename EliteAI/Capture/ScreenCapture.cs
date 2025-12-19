using OpenCvSharp;
using ScreenCapture.NET;

namespace EliteAI.Capture;

public static class ScreenCapture
{
    private static readonly DX11ScreenCaptureService CaptureService = new();
    private static readonly GraphicsCard Card = CaptureService.GetGraphicsCards().First();
    private static readonly Display Display = CaptureService.GetDisplays(Card).First();
    private static readonly DX11ScreenCapture Capture = CaptureService.GetScreenCapture(Display);
    private static readonly ICaptureZone Zone = Capture.RegisterCaptureZone(0, 0, Display.Width, Display.Height);

    public static int ScreenWidth => Display.Width;
    public static int ScreenHeight => Display.Height;

    public static Mat GetFrame()
    {
        Capture.CaptureScreen();

        using (Zone.Lock())
        {
            var image = Zone.Image;
            var rawBuffer = Zone.RawBuffer;

            // Create Mat from captured buffer (BGRA format from DX11)
            unsafe
            {
                fixed (byte* ptr = rawBuffer)
                {
                    using var bgraMat = Mat.FromPixelData(Display.Height, Display.Width, MatType.CV_8UC4, (IntPtr)ptr);

                    // Convert BGRA to BGR for standard OpenCV processing
                    var bgrMat = new Mat();
                    Cv2.CvtColor(bgraMat, bgrMat, ColorConversionCodes.BGRA2BGR);

                    return bgrMat;
                }
            }
        }
    }
}