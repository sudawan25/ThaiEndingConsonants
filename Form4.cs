using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThaiEndingConsonants
{
    public partial class Form4 : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;

        public Form4()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();

            this.Resize += Form4_Resize;
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            try
            {
                // กำหนดความกว้างของ Label ให้เท่ากับความกว้างของ Panel (หรือ Form)
                label1.Width = panel1.ClientSize.Width;
                label2.Width = panel1.ClientSize.Width;
                label3.Width = panel1.ClientSize.Width;
                label4.Width = panel1.ClientSize.Width;
                label5.Width = panel1.ClientSize.Width;
                label6.Width = panel1.ClientSize.Width;
                label7.Width = panel1.ClientSize.Width;

                // อัปเดตข้อความให้ Wrap ตามขนาดใหม่
                label2.MaximumSize = new System.Drawing.Size(label2.Width + 150, 0);
                label3.MaximumSize = new System.Drawing.Size(label3.Width + 200, 0);
                label4.MaximumSize = new System.Drawing.Size(label4.Width + 200, 0);

                label6.MaximumSize = new System.Drawing.Size(label6.Width + 70, 0);
                label7.MaximumSize = new System.Drawing.Size(label7.Width + 30, 0);

                // คุณอาจต้องการปรับตำแหน่งของ Label ตามที่ต้องการ
                label2.Location = new Point(150, label2.Location.Y);
                label3.Location = new Point(150, label3.Location.Y);
                label4.Location = new Point(250, label4.Location.Y);
                label6.Location = new Point(350, label6.Location.Y);
                label7.Location = new Point(350, label7.Location.Y);


                pictureBox1.Location = new Point(pictureBox1.Location.X + 50, pictureBox1.Location.Y);
                pictureBox2.Location = new Point(pictureBox2.Location.X + 50, pictureBox2.Location.Y);
                pictureBox3.Location = new Point(pictureBox3.Location.X + 50, pictureBox3.Location.Y);
                pictureBox4.Location = new Point(pictureBox4.Location.X + 50, pictureBox4.Location.Y);
                pictureBox5.Location = new Point(pictureBox5.Location.X + 50, pictureBox5.Location.Y);
                pictureBox6.Location = new Point(pictureBox6.Location.X + 50, pictureBox6.Location.Y);
                pictureBox7.Location = new Point(pictureBox7.Location.X + 50, pictureBox7.Location.Y);
                pictureBox8.Location = new Point(pictureBox8.Location.X + 50, pictureBox8.Location.Y);

                int pictureBoxSizeImage = 50;
                int pictureBoxSize = 150;
                // ขนาดของ PictureBox5 เท่ากับ PictureBox4
                pictureBox1.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox2.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox3.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox4.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox5.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox6.Size = new Size(pictureBoxSize, pictureBoxSize);

                //ลำโพง
                pictureBox9.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox10.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox11.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox12.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox13.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox14.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox15.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);



                // ปรับขนาดฟอนต์ของ Label 
                float fontSize = this.ClientSize.Height / 20; // ปรับขนาดฟอนต์เป็น 1/20 ของความสูงฟอร์ม

                label1.Font = new Font(label1.Font.FontFamily, fontSize, label1.Font.Style);
                label2.Font = new Font(label2.Font.FontFamily, fontSize, label2.Font.Style);
                label3.Font = new Font(label3.Font.FontFamily, fontSize, label3.Font.Style);
                label4.Font = new Font(label4.Font.FontFamily, fontSize, label4.Font.Style);
                label5.Font = new Font(label5.Font.FontFamily, fontSize, label5.Font.Style);
                label6.Font = new Font(label6.Font.FontFamily, fontSize, label6.Font.Style);
                label7.Font = new Font(label7.Font.FontFamily, fontSize, label7.Font.Style);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnBackToForm2_Click(object sender, EventArgs e)
        {
            try
            {
                Form7 form7 = new Form7();
                form7.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void ApplyCustomFont()
        {
            // Apply the font to the controls
            if (privateFonts.Families.Length > 0)
            {
                Font customFont = new Font(privateFonts.Families[0], 12F);
                this.btnBackToForm2.Font = customFont;
                this.label1.Font = customFont;
                this.label2.Font = customFont;
                this.label3.Font = customFont;
                this.label4.Font = customFont;
                this.label5.Font = customFont;
                this.label6.Font = customFont;
                this.label7.Font = customFont;
            }
        }

        public void LoadCustomFont()
        {
            // Load the font from file
            string fontPath = System.IO.Path.Combine(Application.StartupPath, "Fonts", "Mali-Regular.ttf");
            privateFonts.AddFontFile(fontPath);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 form6 = new Form6(1);
                form6.Show();
                this.Close();
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
                Form6 form6 = new Form6(2);
                form6.Show();
                this.Close();
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
                Form6 form6 = new Form6(3);
                form6.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 form6 = new Form6(4);
                form6.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 form6 = new Form6(5);
                form6.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 form6 = new Form6(6);
                form6.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 form6 = new Form6(7);
                form6.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 form6 = new Form6(8);
                form6.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\4-4.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\4-1.mp3");
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

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\4-2.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\4-3.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\4-5.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\4-6.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\4-7.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
