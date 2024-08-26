using NAudio.Wave;
using System;
using System.CodeDom;
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
    public partial class Form6 : Form
    {
        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private int _page = 0;
        ModelClass model = new ModelClass();
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;
        SetTextShow setTextShow = new SetTextShow();

        public Form6(int page)
        {
            InitializeComponent();
            _page = page;
            LoadCustomFont();
            ApplyCustomFont();

            this.Resize += Form6_Resize;
        }

        private void Form6_Resize(object sender, EventArgs e)
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
                label2.MaximumSize = new System.Drawing.Size(label2.Width + 550, 0);

                // คุณอาจต้องการปรับตำแหน่งของ Label ตามที่ต้องการ
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
                pictureBox14.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox7.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox8.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox9.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox10.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox11.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox12.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);
                pictureBox13.Size = new Size(pictureBoxSizeImage, pictureBoxSizeImage);



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

        private SetTextShow SetText(int Selectpage)
        {
            try
            {
                switch (Selectpage)
                {
                    case 1 :
                        setTextShow.ConsonantsHead = "แม่กง ใช้ ง สะกด";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\แม่กงใช้งสะกด.mp3";
                        
                        setTextShow.ConsonantsDetail = "ตัวอย่างคำในแม่กง";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\ตัวอย่างคำในแม่กง.mp3";

                        setTextShow.Consonants1 = "ลิง";
                        setTextShow.Consonants1_image = Properties.Resources.monkey_309461_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\ลิง.mp3";

                        setTextShow.Consonants2 = "สีม่วง";
                        setTextShow.Consonants2_image = Properties.Resources.eggplant_2924511_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\สีม่วง.mp3";


                        setTextShow.Consonants3 = "กางเกง";
                        setTextShow.Consonants3_image = Properties.Resources.clothes_1294974_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\กางเกง.mp3";

                        setTextShow.Consonants4 = "รองเท้า";
                        setTextShow.Consonants4_image = Properties.Resources.shoes_6329388_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\รองเท้า.mp3";

                        setTextShow.Consonants5 = "สอง";
                        setTextShow.Consonants5_image = Properties.Resources.boy_1299263_1280;
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\สอง.mp3"; ;

                        setTextShow.Consonants6 = "กวาง";
                        setTextShow.Consonants6_image = Properties.Resources.deer_48419_1280;
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\กวาง.mp3"; ;
                        break;
                    case 2:
                        setTextShow.ConsonantsHead = "แม่กม ใช้ ม สะกด";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กม\\แม่กมใช้มสะกด.mp3";
                        
                        setTextShow.ConsonantsDetail = "ตัวอย่างคำในแม่กม";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กม\\ตัวอย่างคำในแม่กม.mp3";

                        setTextShow.Consonants1 = "ส้ม";
                        setTextShow.Consonants1_image = Properties.Resources.orange_42394_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กม\\ส้ม.mp3";

                        setTextShow.Consonants2 = "ส้อม";
                        setTextShow.Consonants2_image = Properties.Resources.fork_149488_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กม\\ส้อม.mp3";

                        setTextShow.Consonants3 = "กลม";
                        setTextShow.Consonants3_image = Properties.Resources.buttons_154563_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กม\\กลม.mp3";

                        setTextShow.Consonants4 = "พัดลม";
                        setTextShow.Consonants4_image = Properties.Resources.fan_154868_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กม\\พัดลม.mp3";

                        setTextShow.Consonants5 = "มะขาม";
                        setTextShow.Consonants5_image = Properties.Resources.tamarind_154393_1280;
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กม\\มะขาม.mp3";

                        setTextShow.Consonants6 = "นม";
                        setTextShow.Consonants6_image = Properties.Resources.milk_576439_1280;
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กม\\นม.mp3";
                        break;
                    case 3:
                        setTextShow.ConsonantsHead = "แม่เกย ใช้ ย สะกด";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกย\\แม่เกยใช้ยสะกด.mp3";

                        setTextShow.ConsonantsDetail = "ตัวอย่างคำในแม่เกย";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกย\\ตัวอย่างคำในแม่เกย.mp3";

                        setTextShow.Consonants1 = "สร้อย";
                        setTextShow.Consonants1_image = Properties.Resources.pearls_1084303_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกย\\สร้อย.mp3";

                        setTextShow.Consonants2 = "ยาย";
                        setTextShow.Consonants2_image = Properties.Resources.man_1989145_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกย\\ยาย.mp3";

                        setTextShow.Consonants3 = "ผู้ชาย";
                        setTextShow.Consonants3_image = Properties.Resources.men_2687628_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกย\\ผู้ชาย.mp3";

                        setTextShow.Consonants4 = "ด้าย";
                        setTextShow.Consonants4_image = Properties.Resources.string_152761_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกย\\ด้าย.mp3";

                        setTextShow.Consonants5 = "กล้วย";
                        setTextShow.Consonants5_image = Properties.Resources.bananas_311788_1280;
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกย\\กล้วย.mp3";

                        setTextShow.Consonants6 = "กระต่าย";
                        setTextShow.Consonants6_image = Properties.Resources.rabbit_3550456_1280;
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกย\\กระต่าย.mp3";
                        break;
                    case 4:
                        setTextShow.ConsonantsHead = "แม่เกอว ใช้ ว สะกด";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกอว\\แม่เกอวใช้วสะกด.mp3";

                        setTextShow.ConsonantsDetail = "ตัวอย่างคำในแม่เกอว";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกอว\\ตัวอย่างคำในแม่เกอว.mp3";

                        setTextShow.Consonants1 = "แมว";
                        setTextShow.Consonants1_image = Properties.Resources.kitties_304268_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกอว\\แมว.mp3";

                        setTextShow.Consonants2 = "สีเขียว";
                        setTextShow.Consonants2_image = Properties.Resources.alien_2029727_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกอว\\สีเขียว.mp3";

                        setTextShow.Consonants3 = "นิ้ว";
                        setTextShow.Consonants3_image = Properties.Resources.cartoon_2029827_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกอว\\นิ้ว.mp3";

                        setTextShow.Consonants4 = "ว่าว";
                        setTextShow.Consonants4_image = Properties.Resources.dragon_986389_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกอว\\ว่าว.mp3";

                        setTextShow.Consonants5 = "ดาว";
                        setTextShow.Consonants5_image = Properties.Resources.icons_1293736_1280;
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกอว\\ดาว.mp3";

                        setTextShow.Consonants6 = "แก้ว";
                        setTextShow.Consonants6_image = Properties.Resources.orange_juice_6927663_1280;
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่เกอว\\แก้ว.mp3";

                        break;
                    case 5:
                        setTextShow.ConsonantsHead = "แม่กก มีตัวสะกด ก ข ค ฆ";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กก\\แม่กก.mp3";

                        setTextShow.ConsonantsDetail = "ตัวอย่างคำแม่กก";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กก\\ตัวอย่างคำแม่กก.mp3";

                        setTextShow.Consonants1 = "เด็ก";
                        setTextShow.Consonants1_image = Properties.Resources.asian_1294104_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กก\\เด็ก.mp3";

                        setTextShow.Consonants2 = "หมวก";
                        setTextShow.Consonants2_image = Properties.Resources.cap_304059_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กก\\หมวก.mp3";

                        setTextShow.Consonants3 = "พริก";
                        setTextShow.Consonants3_image = Properties.Resources.red_peppers_296655_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กก\\พริก.mp3";

                        setTextShow.Consonants4 = "นก";
                        setTextShow.Consonants4_image = Properties.Resources.wren_7747032_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กก\\นก.mp3";

                        setTextShow.Consonants5 = "ปีก";
                        setTextShow.Consonants5_image = Properties.Resources.wings_3335888_1280;
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กก\\ปีก.mp3";

                        setTextShow.Consonants6 = "สุนัข";
                        setTextShow.Consonants6_image = Properties.Resources.dog_8585844_1280;
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กก\\สุนัข.mp3";
                        break;
                    case 6:
                        setTextShow.ConsonantsHead = "แม่กด มีตัวสะกด จ ช ซ ฎ ฏ ฐ ฑ ฒ ด ต ถ ท ธ ศ ษ ส";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กด\\แม่กด.mp3";

                        setTextShow.ConsonantsDetail = "ตัวอย่างคำแม่กด";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กด\\ตัวอย่างคำแม่กด.mp3";

                        setTextShow.Consonants1 = "กระโดด";
                        setTextShow.Consonants1_image = Properties.Resources.cartoon_2027156_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กด\\กระโดด.mp3";

                        setTextShow.Consonants2 = "ชายหาด";
                        setTextShow.Consonants2_image = Properties.Resources.sand_305497_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กด\\ชายหาด.mp3";

                        setTextShow.Consonants3 = "ตำรวจ";
                        setTextShow.Consonants3_image = Properties.Resources.comic_characters_2024758_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กด\\ตำรวจ.mp3";

                        setTextShow.Consonants4 = "อูฐ";
                        setTextShow.Consonants4_image = Properties.Resources.camel_7746330_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กด\\อูฐ.mp3";

                        setTextShow.Consonants5 = "เพชร";
                        setTextShow.Consonants5_image = Properties.Resources.diamond_158431_1280; 
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กด\\เพชร.mp3";

                        setTextShow.Consonants6 = "โทรทัศน์";
                        setTextShow.Consonants6_image = Properties.Resources.tv_310801_1280; 
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กด\\โทรทัศน์.mp3";
                        break;
                    case 7:
                        setTextShow.ConsonantsHead = "แม่กน มีตัวสะกด ญ ณ น ร ล ฬ";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กน\\แม่กน.mp3";

                        setTextShow.ConsonantsDetail = "ตัวอย่างคำแม่กน";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กน\\ตัวอย่างคำแม่กน.mp3";

                        setTextShow.Consonants1 = "จาน";
                        setTextShow.Consonants1_image = Properties.Resources.plate_159469_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กน\\จาน.mp3";

                        setTextShow.Consonants2 = "ถนน";
                        setTextShow.Consonants2_image = Properties.Resources.cars_5970663_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กน\\ถนน.mp3";

                        setTextShow.Consonants3 = "ปฏิทิน";
                        setTextShow.Consonants3_image = Properties.Resources.calendar_159098_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กน\\ปฏิทิน.mp3";

                        setTextShow.Consonants4 = "พยาบาล";
                        setTextShow.Consonants4_image = Properties.Resources.man_1954300_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กน\\พยาบาล.mp3";

                        setTextShow.Consonants5 = "วาฬ";
                        setTextShow.Consonants5_image = Properties.Resources.whale_36828_1280;
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กน\\วาฬ.mp3";

                        setTextShow.Consonants6 = "เหรียญ";
                        setTextShow.Consonants6_image = Properties.Resources.coins_42776_1280;
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กน\\เหรียญ.mp3";

                        break;
                    case 8:
                        setTextShow.ConsonantsHead = "แม่กบ มีตัวสะกด บ ป พ ฟ ภ";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กบ\\แม่กบ.mp3";

                        setTextShow.ConsonantsDetail = "ตัวอย่างคำแม่กบ";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กบ\\ตัวอย่างคำแม่กบ.mp3";

                        setTextShow.Consonants1 = "กบ";
                        setTextShow.Consonants1_image = Properties.Resources.frog_2644410_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กบ\\กบ.mp3";

                        setTextShow.Consonants2 = "ตะเกียบ";
                        setTextShow.Consonants2_image = Properties.Resources.bowl_2029454_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กบ\\ตะเกียบ.mp3";

                        setTextShow.Consonants3 = "ไมโครเวฟ";
                        setTextShow.Consonants3_image = Properties.Resources.microwave_29056_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กบ\\ไมโครเวฟ.mp3";

                        setTextShow.Consonants4 = "รูป";
                        setTextShow.Consonants4_image = Properties.Resources.polaroid_2315182_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กบ\\รูป.mp3";

                        setTextShow.Consonants5 = "ยีราฟ";
                        setTextShow.Consonants5_image = Properties.Resources.giraffe_40035_1280;
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กบ\\ยีราฟ.mp3";

                        setTextShow.Consonants6 = "โทรศัพท์";
                        setTextShow.Consonants6_image = Properties.Resources.telephone_388838_1280;
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กบ\\โทรศัพท์.mp3";

                        break;
                    default:
                        setTextShow.ConsonantsHead = "แม่กง ใช้ ง สะกด";
                        setTextShow.ConsonantsHead_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\แม่กงใช้งสะกด.mp3";

                        setTextShow.ConsonantsDetail = "ตัวอย่างคำในแม่กง";
                        setTextShow.ConsonantsDetail_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\ตัวอย่างคำในแม่กง.mp3";

                        setTextShow.Consonants1 = "ลิง";
                        setTextShow.Consonants1_image = Properties.Resources.monkey_309461_1280;
                        setTextShow.Consonants1_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\ลิง.mp3";

                        setTextShow.Consonants2 = "สีม่วง";
                        setTextShow.Consonants2_image = Properties.Resources.eggplant_2924511_1280;
                        setTextShow.Consonants2_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\สีม่วง.mp3";


                        setTextShow.Consonants3 = "กางเกง";
                        setTextShow.Consonants3_image = Properties.Resources.clothes_1294974_1280;
                        setTextShow.Consonants3_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\กางเกง.mp3";

                        setTextShow.Consonants4 = "รองเท้า";
                        setTextShow.Consonants4_image = Properties.Resources.shoes_6329388_1280;
                        setTextShow.Consonants4_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\รองเท้า.mp3";

                        setTextShow.Consonants5 = "สอง";
                        setTextShow.Consonants5_image = Properties.Resources.boy_1299263_1280;
                        setTextShow.Consonants5_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\สอง.mp3"; ;

                        setTextShow.Consonants6 = "กวาง";
                        setTextShow.Consonants6_image = Properties.Resources.deer_48419_1280;
                        setTextShow.Consonants6_audio = "E:\\All\\ReadProject\\ThaiEndingConsonants\\ThaiEndingConsonants\\Audio\\แม่กง\\กวาง.mp3"; ;
                        break;
                }
                return setTextShow;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new SetTextShow();
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

        private void btnBackToForm2_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 form4 = new Form4();
                form4.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                SetTextShow textShow = SetText(_page);
                this.label1.Text = textShow.ConsonantsHead;
                this.label2.Text = textShow.ConsonantsDetail;
                this.label3.Text = textShow.Consonants1;
                this.label4.Text = textShow.Consonants2;
                this.label5.Text = textShow.Consonants3;
                this.label6.Text = textShow.Consonants4;
                this.label7.Text = textShow.Consonants5;
                this.label8.Text = textShow.Consonants6;

                this.pictureBox1.Image = textShow.Consonants1_image;
                this.pictureBox2.Image = textShow.Consonants2_image;
                this.pictureBox3.Image = textShow.Consonants3_image;
                this.pictureBox4.Image = textShow.Consonants4_image;
                this.pictureBox5.Image = textShow.Consonants5_image;
                this.pictureBox6.Image = textShow.Consonants6_image;

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
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                audioFileReader = new AudioFileReader(setTextShow.ConsonantsHead_audio);
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                audioFileReader = new AudioFileReader(setTextShow.ConsonantsDetail_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants1_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants2_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants3_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants4_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants6_audio);
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
                audioFileReader = new AudioFileReader(setTextShow.Consonants5_audio);
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
