namespace Image_Downsizer
{
    public partial class Form1 : Form
    {
        int percentage = 10;
        Bitmap image;
        public Form1()
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

            }

        }

        private void startResizingButton_Click(object sender, EventArgs e)
        {

        }
    }
}