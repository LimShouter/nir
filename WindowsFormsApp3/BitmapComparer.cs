using System.Drawing;

namespace WindowsFormsApp3
{
    public class BitmapComparer
    {
        public float Compare(Bitmap bm1, Bitmap bm2)
        {
            if (bm1 == null || bm2 == null) return -2;
            if (bm1.Size != bm2.Size) return -1;

            float result;
            float count = 0;
            for (int i = 0; i < bm1.Height; i++)
            {
                for (int j = 0; j < bm1.Width; j++)
                {
                    if (bm1.GetPixel(j,i).Equals(bm2.GetPixel(j,i)))
                    {
                        count++;
                    }
                }
            }

            return count / (bm1.Height*bm1.Width);
        }
    }
}