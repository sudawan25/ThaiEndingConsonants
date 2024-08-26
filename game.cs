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
    public partial class game : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();

        // List เก็บมาตราตัวสะกด
        List<string> wordList = new List<string> { "ลิง", "กางเกง", "ส้ม", "นม", "สร้อย", "กล้วย", "แมว", "ดาว", "พริก", "สุนัข", "อูฐ", "โทรทัศน์" };
        // List เก็บภาพที่สอดคล้อง
        List<Image> imageList = new List<Image>();

        // สถานะการคลิกปัจจุบัน
        Button firstClicked = null;
        Button secondClicked = null;

        public game()
        {
            InitializeComponent();
            LoadCustomFont();
            ApplyCustomFont();

            LoadImages();
            AssignButtons();
        }

        // โหลดภาพและเพิ่มไปยัง imageList
        private void LoadImages()
        {
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\monkey-309461_12801.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\clothes-1294974_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\orange-42394_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\milk-576439_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\pearls-1084303_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\bananas-311788_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\kitties-304268_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\icons-1293736_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\red-peppers-296655_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\dog-8585844_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\camel-7746330_1280.png"));
            imageList.Add(Image.FromFile("E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Resources\\tv-310801_1280.png"));
        }

        // สุ่มและกำหนดมาตราตัวสะกดและภาพไปยัง Button หรือ PictureBox
        private void AssignButtons()
        {
            try
            {
                // เคลียร์ปุ่มทั้งหมดก่อนสร้างใหม่
                this.tableLayoutPanel1.Controls.Clear();

                List<object> mixedItems = new List<object>();
                mixedItems.AddRange(wordList);
                mixedItems.AddRange(imageList);

                Random rand = new Random();
                mixedItems = mixedItems.OrderBy(x => rand.Next()).ToList();

                // สร้าง Button และกำหนดค่าลงใน TableLayoutPanel
                for (int i = 0; i < mixedItems.Count; i++)
                {
                    Button btn = new Button();
                    btn.Width = 150;
                    btn.Height = 150;
                    btn.Margin = new Padding(10);
                    btn.Tag = mixedItems[i];
                    btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom| AnchorStyles.Left | AnchorStyles.Right;
                    btn.Click += Button_Click;

                    if (mixedItems[i] is Image)
                    {
                        btn.BackgroundImage = (Image)mixedItems[i];
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = "";
                    }
                    else
                    {
                        btn.Text = mixedItems[i].ToString();
                        btn.Font = new Font(privateFonts.Families[0], 20, FontStyle.Bold);
                    }

                    tableLayoutPanel1.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                Button clickedButton = sender as Button;

                if (clickedButton == null || clickedButton == firstClicked)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedButton;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedButton;
                secondClicked.ForeColor = Color.Black;

                // ตรวจสอบว่าจับคู่กันได้หรือไม่
                bool isMatch = false;

                if (firstClicked.Tag is string && secondClicked.Tag is Image)
                {
                    if (wordList.IndexOf(firstClicked.Text) == imageList.IndexOf((Image)secondClicked.Tag))
                    {
                        isMatch = true;
                    }
                }
                else if (secondClicked.Tag is string && firstClicked.Tag is Image)
                {
                    if (wordList.IndexOf(secondClicked.Text) == imageList.IndexOf((Image)firstClicked.Tag))
                    {
                        isMatch = true;
                    }
                }

                if (isMatch)
                {
                    // เปลี่ยนสีของปุ่มเป็นสีเทาและทำให้ไม่สามารถกดได้
                    firstClicked.BackColor = Color.Gray;
                    secondClicked.BackColor = Color.Gray;
                    firstClicked.Enabled = false;
                    secondClicked.Enabled = false;

                    // ตรวจสอบว่าจับคู่ทั้งหมดสำเร็จหรือไม่
                    if (AllButtonsDisabled())
                    {
                        MessageBox.Show("คุณจับคู่ถูกทั้งหมดแล้ว! เริ่มเกมใหม่");
                        AssignButtons(); // เริ่มเกมใหม่
                    }
                }
                else
                {
                    // รีเซ็ตสีปุ่มหลังจากจับคู่ผิด
                    firstClicked.ForeColor = Color.Black;
                    secondClicked.ForeColor = Color.Black;
                }

                // รีเซ็ตการคลิก
                firstClicked = null;
                secondClicked = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ฟังก์ชันตรวจสอบว่าปุ่มทั้งหมดถูกปิดใช้งานหรือไม่
        private bool AllButtonsDisabled()
        {
            try
            {
                foreach (Control control in panel1.Controls[0].Controls)
                {
                    Button btn = control as Button;
                    if (btn != null && btn.Enabled)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
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
                //this.label1.Font = customFont;
                //this.label2.Font = customFont;
                //this.label3.Font = customFont;
                //this.label4.Font = customFont;
                //this.label5.Font = customFont;
                //this.label6.Font = customFont;
                //this.label7.Font = customFont;
                //this.label8.Font = customFont;
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
    }
}
