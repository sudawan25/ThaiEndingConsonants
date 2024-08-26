using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThaiEndingConsonants
{
    public partial class Form7 : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;

        public Form7()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();

            this.Resize += new EventHandler(Form7_Resize);
        }

        private void Form7_Resize(object sender, EventArgs e)
        {
             ResizeControls();
        }

        private void ResizeControls()
        {
            try
            {
                // กำหนดระยะห่าง
                int horizontalSpacing = 20;
                int verticalSpacing = 50;
                int rowSpacing = 40;
                int pictureBoxSize = 50; // ขนาดของ PictureBox3, PictureBox4, และ PictureBox5
                int buttonWidth = (this.ClientSize.Width - 3 * horizontalSpacing) / 2;
                int buttonHeight = (this.ClientSize.Height - 2 * verticalSpacing - rowSpacing) / 3;

                // ขนาดของ PictureBox5 เท่ากับ PictureBox4
                pictureBox5.Size = new Size(pictureBoxSize, pictureBoxSize);

                // แถวที่ 1: PictureBox5 และ Label1 ติดกัน กึ่งกลางหน้าจอ
                int totalWidthRow1 = pictureBox5.Width + horizontalSpacing + label1.Width;
                int centerXRow1 = (this.ClientSize.Width - totalWidthRow1) / 2;

                pictureBox5.Location = new Point(centerXRow1, verticalSpacing);
                label1.Location = new Point(pictureBox5.Right + horizontalSpacing, verticalSpacing);

                // ขนาดของ Label1
                label1.Size = new Size(this.ClientSize.Width - pictureBox5.Width - 2 * horizontalSpacing, pictureBoxSize);

                // แถวที่ 2: PictureBox1 และ PictureBox2 กึ่งกลางหน้าจอ
                int totalHeight = this.ClientSize.Height - pictureBox5.Bottom - verticalSpacing - buttonHeight - verticalSpacing - rowSpacing;
                int pictureBox1Height = totalHeight;

                pictureBox1.Size = new Size((this.ClientSize.Width - 3 * horizontalSpacing) / 2, pictureBox1Height);
                pictureBox2.Size = new Size((this.ClientSize.Width - 3 * horizontalSpacing) / 2, pictureBox1Height);

                int totalWidthRow2 = pictureBox1.Width + horizontalSpacing + pictureBox2.Width;
                int centerXRow2 = (this.ClientSize.Width - totalWidthRow2) / 2;

                pictureBox1.Location = new Point(centerXRow2, pictureBox5.Bottom + rowSpacing * 2);
                pictureBox2.Location = new Point(pictureBox1.Right + horizontalSpacing, pictureBox5.Bottom + rowSpacing * 2);

                // แถวที่ 3: ชุดที่ 1 (PictureBox3 และ Button1) และชุดที่ 2 (PictureBox4 และ Button2)
                button1.Size = new Size(buttonWidth, buttonHeight);
                button2.Size = new Size(buttonWidth, buttonHeight);

                // ขนาดของ PictureBox3 และ PictureBox4
                pictureBox3.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox4.Size = new Size(pictureBoxSize, pictureBoxSize);

                int setSpacing = 50; // ระยะห่างระหว่างชุดที่ 1 และชุดที่ 2
                int set1Width = pictureBox3.Width + horizontalSpacing + button1.Width;
                int set2Width = pictureBox4.Width + horizontalSpacing + button2.Width;

                // ตำแหน่งของ PictureBox3 และ Button1 (ชุดที่ 1)
                int totalWidthRow3 = set1Width + setSpacing + set2Width;
                int startXRow3 = (this.ClientSize.Width - totalWidthRow3) / 2;

                //pictureBox3.Location = new Point(startXRow3, this.ClientSize.Height - pictureBox3.Height - verticalSpacing - buttonHeight);
                pictureBox3.Location = new Point(150, 650);
                button1.Location = new Point(pictureBox3.Right + horizontalSpacing, pictureBox3.Top);

                //pictureBox4.Location = new Point(startXRow3 + set1Width + setSpacing, this.ClientSize.Height - pictureBox4.Height - verticalSpacing - buttonHeight);
                pictureBox4.Location = new Point(900, 650);
                button2.Location = new Point(pictureBox4.Right + horizontalSpacing, pictureBox4.Top);

                // ปรับขนาดฟอนต์ของ Label และ Button
                float fontSize = this.ClientSize.Height / 20; // ปรับขนาดฟอนต์เป็น 1/20 ของความสูงฟอร์ม
                float btnSize = this.ClientSize.Height / 30; // ปรับขนาดฟอนต์เป็น 1/30 ของความสูงฟอร์ม

                label1.Font = new Font(label1.Font.FontFamily, fontSize, label1.Font.Style);
                button1.Font = new Font(button1.Font.FontFamily, btnSize, button1.Font.Style);
                button2.Font = new Font(button2.Font.FontFamily, btnSize, button2.Font.Style);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        public void ApplyCustomFont()
        {
            // Apply the font to the controls
            if (privateFonts.Families.Length > 0)
            {
                Font customFont = new Font(privateFonts.Families[0], 12F);
                this.btnBackToForm1.Font = customFont;
                this.button1.Font = customFont;
                this.button2.Font = customFont;
                this.label1.Font = customFont;
            }
        }

        public void LoadCustomFont()
        {
            // Load the font from file
            string fontPath = System.IO.Path.Combine(Application.StartupPath, "Fonts", "Mali-Regular.ttf");
            privateFonts.AddFontFile(fontPath);

        }

        private void btnBackToForm1_Click(object sender, EventArgs e)
        {
            try
            {
                selectPage form7 = new selectPage();
                form7.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            privateFonts.Dispose();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\1.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                Form5 f5 = new Form5();
                this.Hide();
                f5.Show();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\4.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\5.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
