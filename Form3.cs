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
using static ThaiEndingConsonants.ModelClass;

namespace ThaiEndingConsonants
{
    public partial class Form3 : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;
        SetTextShow setTextShow = new SetTextShow();

        public Form3()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();

            this.Resize += new EventHandler(Form3_Resize);
        }

        private void Form3_Resize(object sender, EventArgs e)
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
                label8.Width = panel1.ClientSize.Width;

                // อัปเดตข้อความให้ Wrap ตามขนาดใหม่
                label1.MaximumSize = new System.Drawing.Size(label1.Width + 200, 0);
                label2.MaximumSize = new System.Drawing.Size(label2.Width + 70, 0);

                // คุณอาจต้องการปรับตำแหน่งของ Label ตามที่ต้องการ
                label1.Location = new Point(150, label1.Location.Y);
                label2.Location = new Point(250, label2.Location.Y);

                int pictureBoxSizeImage = 50;
                int pictureBoxSize = 350;
                // ขนาดของ PictureBox5 เท่ากับ PictureBox4
                pictureBox1.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox2.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox3.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox4.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox5.Size = new Size(pictureBoxSize, pictureBoxSize);
                pictureBox6.Size = new Size(pictureBoxSize, pictureBoxSize);

                //ลำโพง
                pictureBox7.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox8.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox9.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox10.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox11.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox12.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox13.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox14.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);


                // ปรับขนาดฟอนต์ของ Label 
                float fontSize = this.ClientSize.Height / 20; // ปรับขนาดฟอนต์เป็น 1/20 ของความสูงฟอร์ม

                label1.Font = new Font(label1.Font.FontFamily, fontSize, label1.Font.Style);
                label2.Font = new Font(label2.Font.FontFamily, fontSize, label2.Font.Style);
                label3.Font = new Font(label3.Font.FontFamily, fontSize, label3.Font.Style);
                label4.Font = new Font(label4.Font.FontFamily, fontSize, label4.Font.Style);
                label5.Font = new Font(label5.Font.FontFamily, fontSize, label5.Font.Style);
                label6.Font = new Font(label6.Font.FontFamily, fontSize, label6.Font.Style);
                label7.Font = new Font(label7.Font.FontFamily, fontSize, label7.Font.Style);
                label8.Font = new Font(label8.Font.FontFamily, fontSize, label8.Font.Style);
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
                this.label8.Font = customFont;
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

        private void Form3_Load(object sender, EventArgs e)
        {
            
            setTextShow.ConsonantsHead = "แม่ ก กา คืออะไร";
            setTextShow.ConsonantsDetail = "มาตรา ก กา หรือแม่ ก กา คือ คำหรือพยางค์ที่มีพยัญชนะต้นประสมกับสระโดยไม่มีตัวสะกด เช่น  หมู วัว  มือ  งู กา ปลา";
            
            setTextShow.Consonants1 = "หมู";
            setTextShow.Consonants1_image = Properties.Resources.ai_generated_8670831_1280;
            setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\หมู.mp3";
            
            setTextShow.Consonants2 = "วัว";
            setTextShow.Consonants2_image = Properties.Resources.animal_6895748_1280;
            setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\วัว.mp3";
            
            setTextShow.Consonants3 = "มือ";
            setTextShow.Consonants3_image = Properties.Resources.hand_8238233_1280;
            setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\มือ.mp3";
            
            setTextShow.Consonants4 = "งู";
            setTextShow.Consonants4_image = Properties.Resources.animals_1295060_1280;
            setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\งู.mp3";
            
            setTextShow.Consonants5 = "กา";
            setTextShow.Consonants5_image = Properties.Resources.crow_5756600_1280;
            setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\กา.mp3";
            
            setTextShow.Consonants6 = "ปลา";
            setTextShow.Consonants6_image = Properties.Resources.dolphin_3321762_1280;
            setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\ปลา.mp3";

            this.label1.Text = setTextShow.ConsonantsHead;
            this.label2.Text = setTextShow.ConsonantsDetail;

            this.label3.Text = setTextShow.Consonants1;
            this.label4.Text = setTextShow.Consonants2;
            this.label5.Text = setTextShow.Consonants3;
            this.label6.Text = setTextShow.Consonants4;
            this.label7.Text = setTextShow.Consonants5;
            this.label8.Text = setTextShow.Consonants6;

            this.pictureBox1.Image = setTextShow.Consonants1_image;
            this.pictureBox2.Image = setTextShow.Consonants2_image;
            this.pictureBox3.Image = setTextShow.Consonants3_image;
            this.pictureBox4.Image = setTextShow.Consonants4_image;
            this.pictureBox5.Image = setTextShow.Consonants5_image;
            this.pictureBox6.Image = setTextShow.Consonants6_image;

            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);

            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox6);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                // สร้าง WaveOut และ AudioFileReader ใหม่
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\6.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants1_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants2_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants4_audio);
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants3_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants6_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants5_audio);
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
