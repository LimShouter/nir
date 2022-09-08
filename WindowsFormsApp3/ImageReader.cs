using System.Drawing;
using WindowsFormsApp3.Properties;

namespace WindowsFormsApp3
{
    public class ImageReader
    {
        public Bitmap GetArial(int id)
        {
            return Resources.Arial[id];
        }

        // public Bitmap Compare()
        // {
        //     
        // }
        
        public Bitmap Zoom(Bitmap image,int k)
        {
            if (k <= 1) return image;
            Bitmap img = new Bitmap(image);
            int width = img.Width;
            int height = img.Height;
            Bitmap zoomImg = new Bitmap(width * k, height * k);
            Graphics g = Graphics.FromImage(zoomImg);
 
            for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                Color color = img.GetPixel(i, j);
                g.FillRectangle(new SolidBrush(color), i * k, j * k, k, k);
            }
            return zoomImg;
        }
        
    }
}