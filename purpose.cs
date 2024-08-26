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
    public partial class purpose : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();

        public purpose()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();

            this.Resize += Purpose_Resize; ;
        }

        private void Purpose_Resize(object sender, EventArgs e)
        {
            try
            {
                float fontSize1 = this.ClientSize.Height / 20; // ปรับขนาดฟอนต์เป็น 1/20 ของความสูงฟอร์ม
                label1.Font = new Font(label1.Font.FontFamily, fontSize1, label1.Font.Style);


                float fontSize = this.ClientSize.Height / 35;
                label2.Font = new Font(label2.Font.FontFamily, fontSize, label2.Font.Style);
                label3.Font = new Font(label3.Font.FontFamily, fontSize, label3.Font.Style);
                label4.Font = new Font(label4.Font.FontFamily, fontSize, label4.Font.Style);
                label5.Font = new Font(label5.Font.FontFamily, fontSize, label5.Font.Style);
                label6.Font = new Font(label6.Font.FontFamily, fontSize, label6.Font.Style);
                label7.Font = new Font(label7.Font.FontFamily, fontSize, label7.Font.Style);
                label8.Font = new Font(label8.Font.FontFamily, fontSize, label8.Font.Style);
                label9.Font = new Font(label9.Font.FontFamily, fontSize, label9.Font.Style);
                label10.Font = new Font(label10.Font.FontFamily, fontSize, label10.Font.Style);
                label11.Font = new Font(label11.Font.FontFamily, fontSize, label11.Font.Style);
                label12.Font = new Font(label12.Font.FontFamily, fontSize, label12.Font.Style);
                label13.Font = new Font(label13.Font.FontFamily, fontSize, label13.Font.Style);
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
                selectPage selectPage = new selectPage();
                selectPage.Show();
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

        public void ApplyCustomFont()
        {
            // Apply the font to the controls
            if (privateFonts.Families.Length > 0)
            {
                Font customFont1 = new Font(privateFonts.Families[0], 12F);
                this.label1.Font = customFont1;

                Font customFont = new Font(privateFonts.Families[0], 10F);
                this.btnBackToForm2.Font = customFont;
                this.label2.Font = customFont;
                this.label3.Font = customFont;
                this.label4.Font = customFont;
                this.label5.Font = customFont;
                this.label6.Font = customFont;
                this.label7.Font = customFont;
                this.label8.Font = customFont;
                this.label9.Font = customFont;
                this.label10.Font = customFont;
                this.label11.Font = customFont;
                this.label12.Font = customFont;
                this.label13.Font = customFont;
                this.btnBackToForm2.Font = customFont;
            }
        }

        public void LoadCustomFont()
        {
            // Load the font from file
            string fontPath = System.IO.Path.Combine(Application.StartupPath, "Fonts", "Mali-Regular.ttf");
            privateFonts.AddFontFile(fontPath);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
