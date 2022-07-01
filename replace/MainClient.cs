using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace replace
{
    public partial class MainClient : Form
    {
        int row, col;
        bool[,] desk = new bool[10, 10];
        bool[,] link_vertical = new bool[10, 10];
        bool[,] link_horizontal = new bool[10, 10];
        string[] preset = new string[103];
        /* 
         * [0] ClassData,(row),(column),(deskcount)
         * [1] DeskData,(desk1),(desk2),(...)
         * [2] StudentData,(studentcount)
         * [3] (name1),(properties)
         * [.]
         * [102] (name100),(properties)
         */

        public MainClient()
        {
            InitializeComponent();
            if (File.Exists(Application.StartupPath + "\\replace_setting.csv"))
            {
                // 파일 불러와서 로드 시켜놓기
            }
            else
            {
                MainClient_Label_CurrentSetting.ForeColor = Color.DarkGray;
                MainClient_Label_CurrentSetting.Text = "설정된 데이터가 없습니다.\r\n교실과 학급 데이터를 설정해주세요.";
            }
        }
        public void get_ClassData(int row, int col, bool[,] desk, bool[,] link_vertical, bool[,] link_horizontal)
        {
            this.row = row;
            this.col = col;
            this.desk = desk;
            this.link_vertical = link_vertical;
            this.link_horizontal = link_horizontal;
            /*
             * row            : 책상 세로 배치
             * col            : 책상 가로 배치
             * desk           : 책상 수
             * link_vertical  : 좌우 연결된 자리
             * link_horizontal: 전후 연결된 자리
             */
        }

        private void MainClient_Button_StudentSetting_Click(object sender, EventArgs e)
        {
            /*
            ClassSetting StudentSetting_Client = new StudentSetting();
            StudentSetting_Client.data_handler += get_ClassData;
            StudentSetting_Client.ShowDialog();
            */

            // csv파일 만들기
            if (File.Exists(Application.StartupPath + "\\preset.csv"))
            {
                // 파일 데이터 변경하기
            }
            else
            {
                // 새 파일 만들고 저장하기
            }
        }

        private void MainClient_Button_ClassSetting_Click(object sender, EventArgs e)
        {
            ClassSetting ClassSetting_Client = new ClassSetting();
            ClassSetting_Client.data_handler += get_ClassData;
            ClassSetting_Client.ShowDialog();

            // csv파일 만들기
            if(File.Exists(Application.StartupPath + "\\replace_setting.csv"))
            {
                // 파일 데이터 변경하기
            }
            else
            {
                // 새 파일 만들고 저장하기
            }
        }
    }
}
