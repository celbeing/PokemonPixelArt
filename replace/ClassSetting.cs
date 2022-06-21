using System;
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
    public partial class ClassSetting : Form
    {
        int column, row;
        bool[,] DeskActive = new bool[10, 10];
        bool allActive = true;
        PictureBox[,] Desk = new PictureBox[10, 10];
        public ClassSetting()
        {
            InitializeComponent();
            column = 6; row = 4;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DeskActive[i, j] = true;
                    Desk[i, j] = new PictureBox();
                    Desk[i, j].Image = replace.Properties.Resources.desk_sprite;
                    Desk[i, j].Name = $"ClassSetting_Desk_R{i}C{j}";
                    Desk[i, j].Size = new Size(40, 30);
                    Desk[i, j].Location = new Point(32 + j * 60, 32 + i * 50);
                    Desk[i, j].Margin = new Padding(0);
                    Desk[i, j].Visible = true;
                    Desk[i, j].Click += Desk_Click;
                    ClassSetting_TableLayout.Controls.Add(Desk[i, j], j * 2 + 1, i * 2 + 1);
                }
            }
        }
        private void Desk_Click(object sender, EventArgs e)
        {
            PictureBox desk = sender as PictureBox;
            string[] desklocation = desk.Name.Remove(0, 19).Split('C');
            int deskRow = int.Parse(desklocation[0]);
            int deskCol = int.Parse(desklocation[1]);
            if (DeskActive[deskRow, deskCol])
            {
                DeskActive[deskRow, deskCol] = false;
                desk.Image = replace.Properties.Resources.desk_lock_sprite;
            }
            else
            {
                DeskActive[deskRow, deskCol] = true;
                desk.Image = replace.Properties.Resources.desk_sprite;
            }
        }

        private void ClassSetting_Load(object sender, EventArgs e)
        {

        }

        private void ClassSetting_PictureBox_Desk_Click(object sender, EventArgs e)
        {
            if (allActive)
            {
                allActive = false;
                ClassSetting_PictureBox_Desk.Image = replace.Properties.Resources.desk_lock_sprite;
            }
            else
            {
                allActive = true;
                ClassSetting_PictureBox_Desk.Image = replace.Properties.Resources.desk_sprite;
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DeskActive[i, j] = allActive;
                    if (DeskActive[i, j])
                        Desk[i, j].Image = replace.Properties.Resources.desk_sprite;
                    else Desk[i, j].Image = replace.Properties.Resources.desk_lock_sprite;
                }
            }
        }

        private void ClassSetting_Button_Apply_Click(object sender, EventArgs e)
        {
            column = (int)ClassSetting_ColumnUpdown.Value;
            row = (int)ClassSetting_RowUpdown.Value;
            ClassSetting_TableLayout.Size = new System.Drawing.Size(column * 60, row * 50);
            ClassSetting_Label_Column.Location = new System.Drawing.Point(60, row * 50 + 28);
            ClassSetting_ColumnUpdown.Location = new System.Drawing.Point(74, row * 50 + 24);
            ClassSetting_Label_Row.Location = new System.Drawing.Point(12, row * 50 + 28);
            ClassSetting_RowUpdown.Location = new System.Drawing.Point(26, row * 50 + 24);
            ClassSetting_Button_Apply.Location = new System.Drawing.Point(114, row * 50 + 23);
            ClassSetting_PictureBox_Desk.Location = new System.Drawing.Point(192, row * 50 + 20);
            if (column > 4)
            {
                ClassSetting_Button_Submit.Location = new System.Drawing.Point(column * 60 - 63, row * 50 + 23);
                this.ClientSize = new System.Drawing.Size(column * 60 + 24, row * 50 + 59);
            }
            else
            {
                ClassSetting_Button_Submit.Location = new System.Drawing.Point(237, row * 50 + 23);
                this.ClientSize = new System.Drawing.Size(324, row * 50 + 59);
            }
        }
    }
}
