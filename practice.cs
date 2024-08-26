using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaiEndingConsonants.Properties;

namespace ThaiEndingConsonants
{
    public partial class practice : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();

        public practice()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();

            this.Resize += Practice_Resize;
        }

        private void Practice_Resize(object sender, EventArgs e)
        {
            try
            {
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
                selectPage selectPage = new selectPage();
                selectPage.Show();
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

        private void btn_Minimize_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                // เปิด SaveFileDialog เพื่อให้ผู้ใช้เลือกตำแหน่งที่ต้องการบันทึกไฟล์
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "Save PDF File";
                    saveFileDialog.FileName = "แบบฝึกหัดจับคู่คำและรูปภาพ.pdf"; // กำหนดชื่อไฟล์เริ่มต้น

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // เข้าถึงไฟล์ PDF จาก Resources
                            byte[] pdfData = Properties.Resources.pp_1; // ใช้ชื่อไฟล์ที่คุณเพิ่มเข้าไปใน Resources

                            // เขียนไฟล์ไปยังตำแหน่งที่ผู้ใช้เลือก
                            File.WriteAllBytes(saveFileDialog.FileName, pdfData);

                            MessageBox.Show("ดาวน์โหลดไฟล์ PDF สำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"เกิดข้อผิดพลาดในการดาวน์โหลดไฟล์: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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
                // เปิด SaveFileDialog เพื่อให้ผู้ใช้เลือกตำแหน่งที่ต้องการบันทึกไฟล์
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "Save PDF File";
                    saveFileDialog.FileName = "แบบฝึกหัดคัดไทย.pdf"; // กำหนดชื่อไฟล์เริ่มต้น

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // เข้าถึงไฟล์ PDF จาก Resources
                            byte[] pdfData = Properties.Resources.pp_1; // ใช้ชื่อไฟล์ที่คุณเพิ่มเข้าไปใน Resources

                            // เขียนไฟล์ไปยังตำแหน่งที่ผู้ใช้เลือก
                            File.WriteAllBytes(saveFileDialog.FileName, pdfData);

                            MessageBox.Show("ดาวน์โหลดไฟล์ PDF สำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"เกิดข้อผิดพลาดในการดาวน์โหลดไฟล์: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //แบบฝึกหัดแยกคำตามมาตรา
            try
            {
                // เปิด SaveFileDialog เพื่อให้ผู้ใช้เลือกตำแหน่งที่ต้องการบันทึกไฟล์
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "Save PDF File";
                    saveFileDialog.FileName = "แบบฝึกหัดแยกคำตามมาตรา.pdf"; // กำหนดชื่อไฟล์เริ่มต้น

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // เข้าถึงไฟล์ PDF จาก Resources
                            byte[] pdfData = Properties.Resources.pp_1; // ใช้ชื่อไฟล์ที่คุณเพิ่มเข้าไปใน Resources

                            // เขียนไฟล์ไปยังตำแหน่งที่ผู้ใช้เลือก
                            File.WriteAllBytes(saveFileDialog.FileName, pdfData);

                            MessageBox.Show("ดาวน์โหลดไฟล์ PDF สำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"เกิดข้อผิดพลาดในการดาวน์โหลดไฟล์: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
