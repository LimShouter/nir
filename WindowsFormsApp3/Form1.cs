using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp3.Properties;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private readonly Bitmap _pictureBitmap;
        private readonly Pen _pen = new Pen(Color.Black,3f);
        private readonly Graphics _graphics;
        private Point _startPoint;
        public Form1()
        {                             
            InitializeComponent();
            _pictureBitmap = new Bitmap(100, 140);
            _graphics = Graphics.FromImage(_pictureBitmap);
            _pen.StartCap = LineCap.Round;
            _pen.EndCap = LineCap.Round;
        }

        private void PictureMouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.MouseMove += PicturePaint;
            _startPoint = new Point(e.X, e.Y);
        }

        private void PictureMouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.MouseMove -= PicturePaint;
        }

        private void PicturePaint(object sender,MouseEventArgs e)
        {
            _graphics.DrawLine(_pen,_startPoint,e.Location);
            _startPoint = e.Location;
            RefreshImage();
        }

        private void BrushSizeChanged(object sender, EventArgs e)
        {
            _pen.Width = trackBar1.Value * 2;
        }

        private void ClearBitmap(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            RefreshImage();
        }

        private void RefreshImage()
        {
            _graphics.Save();
            pictureBox1.Image = _pictureBitmap;
        }

        private void Analyze(object sender, MouseEventArgs e)
        {
            var results = CompareBrain.Analyze(_pictureBitmap);
            int max = 0;
            var sb = new StringBuilder();
            for (int i = 0; i < results.Length; i++)
            {
                if (results[max] < results[i])
                {
                    max = i;
                }
                sb.Append(i + ":" + results[i]);
                sb.AppendLine();
            }
            textBox1.Text = sb.ToString();
            textBox2.Text = @"Ответ : " + max;
        }
    }
}