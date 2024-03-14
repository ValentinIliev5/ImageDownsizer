using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Image_Downsizer
{
    public partial class DownsizerForm : Form
    {
        int percentage = 10;
        Bitmap image;
        public DownsizerForm()
        {
            InitializeComponent();
        }

        private void addImgB_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if(ofd.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    string filepath = ofd.FileName;
                    image = new Bitmap(filepath);
                    imgSizeLabel.Text = $"Original Image size: {image.Width} x {image.Height}";
                    wantedSizeLabel.Text = $"Wanted Size : {image.Width * percentage / 100} x {image.Height * percentage / 100}";

                    imagePB.Image = image;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void percentTB_Scroll(object sender, EventArgs e)
        {
            //10,20,25,33,40,50,60,66,75,80,90   //11 items
            switch (percentTB.Value)
            {
                case 0: percentage = 10; break;
                case 1: percentage = 20; break;
                case 2: percentage = 25; break;
                case 3: percentage = 33; break;
                case 4: percentage = 40; break;
                case 5: percentage = 50; break;
                case 6: percentage = 60; break;
                case 7: percentage = 66; break;
                case 8: percentage = 75; break;
                case 9: percentage = 80; break;
                case 10: percentage = 90; break;
                default:
                    break;
            }

            percentageLabel.Text = $"{percentage}%";
            if (image!=null)
            {
                wantedSizeLabel.Text = $"Wanted Size : {image.Width * percentage / 100} x {image.Height * percentage / 100}";
                if(percentage==33)
                {
                    wantedSizeLabel.Text = $"Wanted Size : {image.Width /3} x {image.Height /3}";
                }
                if (percentage == 66)
                {
                    wantedSizeLabel.Text = $"Wanted Size : {image.Width*2 / 3} x {image.Height*2 / 3}";
                }
            }

        }

        private void startResizingButton_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                var rect = new Rectangle(0, 0, image.Width, image.Height);
                BitmapData oldImagebitmapData = image.LockBits(rect, ImageLockMode.ReadWrite, image.PixelFormat);
                IntPtr oldImagePtr = oldImagebitmapData.Scan0;

                int bytes = Math.Abs(oldImagebitmapData.Stride) * image.Height;
                byte[] bgrValues = new byte[bytes];

                Marshal.Copy(oldImagePtr, bgrValues, 0, bytes); // 3 bytes B0 G1 R2

                image.UnlockBits(oldImagebitmapData);

                int halfHeight = (image.Height + image.Height % 2) / 2;
                int halfWidth = (image.Width + image.Width % 2) / 2;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                Console.WriteLine(sw.Elapsed.TotalSeconds);

                Solvers.MTSolver.Solve(percentage, bgrValues,image.Height,image.Width);
                MessageBox.Show(sw.Elapsed.TotalSeconds.ToString()+" seconds","MultiThread");

                sw.Restart();

                Solvers.STSolver.Solve(percentage, bgrValues,image.Height,image.Width);
                MessageBox.Show(sw.Elapsed.TotalSeconds.ToString()+" seconds", "SingleThread");
            }
        }
    }
}