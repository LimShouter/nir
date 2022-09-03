using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;

namespace FontConversion;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class FontConverter
{
    public void Convert()
    {
        var fontReading = new FontReading();
        var fontVision = new FontVision();
        var img = fontVision.DrawText("c", new Font(fontReading.GetFontFamilyByName("Sans"),14),Color.Black,Color.White);
        img.Save('c'+".jpg",ImageFormat.Jpeg);
    }
}