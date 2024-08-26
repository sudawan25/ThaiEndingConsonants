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
using System.Media;
using NAudio.Wave;

namespace ThaiEndingConsonants
{
    public partial class Form5 : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private Label l1;
        private Label l2;
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;

        public Form5()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();

            this.Resize += Form5_Resize;
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            ResizeControls();
        }

        private void ResizeControls()
        {
            try
            {
                // กำหนดความกว้างของ Label ให้เท่ากับความกว้างของ Panel (หรือ Form)
                label1.Width = panel1.ClientSize.Width;
                label2.Width = panel1.ClientSize.Width;

                // อัปเดตข้อความให้ Wrap ตามขนาดใหม่
                label1.MaximumSize = new System.Drawing.Size(label1.Width + 200, 0);
                label2.MaximumSize = new System.Drawing.Size(label2.Width - 20, 0);

                // คุณอาจต้องการปรับตำแหน่งของ Label ตามที่ต้องการ
                label1.Location = new Point(150, label1.Location.Y);
                label2.Location = new Point(150, label2.Location.Y);

                int pictureBoxSize = 50;
                // ขนาดของ PictureBox5 เท่ากับ PictureBox4
                pictureBox1.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox2.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox3.Size = new Size(pictureBoxSize, pictureBoxSize);


                // ปรับขนาดฟอนต์ของ Label 
                float fontSize = this.ClientSize.Height / 20; // ปรับขนาดฟอนต์เป็น 1/20 ของความสูงฟอร์ม

                label1.Font = new Font(label1.Font.FontFamily, fontSize, label1.Font.Style);
                label2.Font = new Font(label2.Font.FontFamily, fontSize, label2.Font.Style);
                label3.Font = new Font(label3.Font.FontFamily, fontSize, label3.Font.Style);


            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
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
            if (privateFonts.Families.Length > 0)
            {
                Font customFont = new Font(privateFonts.Families[0], 12F);
                this.label1.Font = customFont;
                this.label2.Font = customFont;
                this.label3.Font = customFont;
                this.btnBackToForm2.Font = customFont;
            }
        }

        public void LoadCustomFont()
        {
            string fontPath = System.IO.Path.Combine(Application.StartupPath, "Fonts", "Mali-Regular.ttf");
            privateFonts.AddFontFile(fontPath);
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

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\1.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ล้างทรัพยากรเมื่อฟอร์มถูกปิด
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            waveOut?.Dispose();
            audioFileReader?.Dispose();
            base.OnFormClosing(e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\2.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\3.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
