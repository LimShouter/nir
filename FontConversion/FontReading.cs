using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace FontConversion;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class FontReading
{
    private readonly PrivateFontCollection _privateFontCollection = new PrivateFontCollection();

    public FontFamily GetFontFamilyByName(string name)
    {
        return _privateFontCollection.Families.FirstOrDefault(x => x.Name == name,FontFamily.GenericSerif);
    }

    public void AddFont(string fullFileName)
    {
        AddFont(File.ReadAllBytes(fullFileName));
    }

    private void AddFont(byte[] fontBytes)
    {
        var handle = GCHandle.Alloc(fontBytes, GCHandleType.Pinned);
        IntPtr pointer = handle.AddrOfPinnedObject();
        try
        {
            _privateFontCollection.AddMemoryFont(pointer, fontBytes.Length);
        }
        finally
        {
            handle.Free();
        }
    }
}