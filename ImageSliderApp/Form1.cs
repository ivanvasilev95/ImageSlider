using System;
using System.Windows.Forms;

namespace ImageSliderApp
{
    public partial class Form1 : Form
    {
        private readonly Slider slider = new Slider();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadPhoto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.slider.Previous();
                this.LoadPhoto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.slider.Next();
                this.LoadPhoto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.slider.LoadPhotos(fbd.SelectedPath);
                    this.LoadPhoto();

                    if (!this.slider.ContainsPhotos)
                        MessageBox.Show("No photos were found.", "Error message");
                }
            }
        }

        private void LoadPhoto()
        {
            var currentPhoto = this.slider.GetPhoto();

            pictureBox1.Image = currentPhoto.Content;
            label1.Text = currentPhoto.Label;

            this.EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            if (!this.slider.ContainsPhotos)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
    }
}
