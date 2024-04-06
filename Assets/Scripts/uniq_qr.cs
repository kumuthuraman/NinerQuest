using QRCoder;
using System.Drawing;
using System.IO;

public class QRCodeGenerator
{
    public static void GenerateQRCode(string inputString, string filePath)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputString, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);

        // Save the QR code image to a file
        qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
    }
}


