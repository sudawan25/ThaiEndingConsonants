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
    public partial class Form2 : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;

        public Form2()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();
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

        private void btnBackToForm1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
