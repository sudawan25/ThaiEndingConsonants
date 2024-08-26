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
    public partial class objectiveProgram : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();

        public objectiveProgram()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();

            this.Resize += ObjectiveProgram_Resize;
        }

        private void ObjectiveProgram_Resize(object sender, EventArgs e)
        {
            try
            {
                float fontSize1 = this.ClientSize.Height / 20; // ปรับขนาดฟอนต์เป็น 1/20 ของความสูงฟอร์ม
                label1.Font = new Font(label1.Font.FontFamily, fontSize1, label1.Font.Style);

                float fontSize = this.ClientSize.Height / 35; // ปรับขนาดฟอนต์เป็น 1/20 ของความสูงฟอร์ม
                label2.Font = new Font(label2.Font.FontFamily, fontSize, label2.Font.Style);
                label3.Font = new Font(label3.Font.FontFamily, fontSize, label3.Font.Style);
                label4.Font = new Font(label4.Font.FontFamily, fontSize, label4.Font.Style);
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
                Font customFont = new Font(privateFonts.Families[0], 12F);
                this.btnBackToForm2.Font = customFont;
                this.label1.Font = customFont;
                this.label2.Font = customFont;
                this.label3.Font = customFont;
                this.label4.Font = customFont;
                this.btnBackToForm2.Font = customFont;
            }
        }

        public void LoadCustomFont()
        {
            // Load the font from file
            string fontPath = System.IO.Path.Combine(Application.StartupPath, "Fonts", "Mali-Regular.ttf");
            privateFonts.AddFontFile(fontPath);

        }
    }
}
