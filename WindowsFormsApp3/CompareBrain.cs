using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp3
{
    public static class CompareBrain
    {
        public static float[] Analyze(Bitmap bitmap)
        {
            float[] results = new float[10];
            ImageReader reader = new ImageReader();
            BitmapComparer comparer = new BitmapComparer();
            for (int i = 0; i < 10; i++)
            {
                var map = reader.Zoom(reader.GetArial(i), 2);
                results[i] = comparer.Compare(map,bitmap);
            }
            return results;
        }
    }
}