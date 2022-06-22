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
        bool[,] LinkActive_v = new bool[9, 10];
        bool[,] LinkActive_h = new bool[10, 9];
        bool allActive = true;
        PictureBox[,] Desk = new PictureBox[10, 10];
        PictureBox[,] LinkV = new PictureBox[9, 10];
        PictureBox[,] LinkH = new PictureBox[10, 9];
        PictureBox[,] Cent = new PictureBox[9, 9];
        PictureBox[] PenV = new PictureBox[10];
        PictureBox[] PenH = new PictureBox[10];
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
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    LinkActive_v[i, j] = false;
                    LinkV[i, j] = new PictureBox();
                    LinkV[i, j].Image = replace.Properties.Resources.unchain_vertical;
                    LinkV[i, j].Name = $"ClassSetting_LinkV_R{i}C{j}";
                    LinkV[i, j].Size = new Size(40, 20);
                    LinkV[i, j].Location = new Point(32 + j * 60, 62 + i * 50);
                    LinkV[i, j].Margin = new Padding(0);
                    LinkV[i, j].Visible = true;
                    LinkV[i, j].Click += LinkV_Click;
                    ClassSetting_TableLayout.Controls.Add(LinkV[i, j], j * 2 + 1, i * 2 + 2);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    LinkActive_h[i, j] = false;
                    LinkH[i, j] = new PictureBox();
                    LinkH[i, j].Image = replace.Properties.Resources.unchain_horizontal;
                    LinkH[i, j].Name = $"ClassSetting_LinkH_R{i}C{j}";
                    LinkH[i, j].Size = new Size(20, 40);
                    LinkH[i, j].Location = new Point(72 + j * 60, 32 + i * 50);
                    LinkH[i, j].Margin = new Padding(0);
                    LinkH[i, j].Visible = true;
                    LinkH[i, j].Click += LinkH_Click;
                    ClassSetting_TableLayout.Controls.Add(LinkH[i, j], j * 2 + 2, i * 2 + 1);
                }
            }
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Cent[i, j] = new PictureBox();
                    Cent[i, j].Image = replace.Properties.Resources.center;
                    Cent[i, j].Name = $"ClassSetting_Cent_R{i}C{j}";
                    Cent[i, j].Size = new Size(20, 20);
                    Cent[i, j].Location = new Point(72 + j * 60, 62 + i * 50); ;
                    Cent[i, j].Margin = new Padding(0);
                    Cent[i, j].Visible = true;
                    Cent[i, j].Click += Cent_Click;
                    ClassSetting_TableLayout.Controls.Add(Cent[i, j], j * 2 + 2, i * 2 + 2);
                }
            }
            for(int i = 0; i < 10; i++)
            {
                PenH[i] = new PictureBox();
                PenH[i].Image = replace.Properties.Resources.pencil_horizontal;
                PenH[i].Name = $"ClassSetting_Pen_R{i}";
                PenH[i].Size = new Size(20, 20);
                PenH[i].Location = new Point(12, 62 + i * 50);
                PenH[i].Margin = new Padding(0);
                PenH[i].Visible = true;
                PenH[i].Click += PenH_Click;
                ClassSetting_TableLayout.Controls.Add(PenH[i], 0, i * 2 + 2);

                PenV[i] = new PictureBox();
                PenV[i].Image = replace.Properties.Resources.pencil_vertical;
                PenV[i].Name = $"ClassSetting_Pen_C{i}";
                PenV[i].Size = new Size(20, 20);
                PenV[i].Location = new Point(72 + i * 60, 12);
                PenV[i].Margin = new Padding(0);
                PenV[i].Visible = true;
                PenV[i].Click += PenV_Click;
                ClassSetting_TableLayout.Controls.Add(PenV[i], i * 2 + 2, 0);
            }
        }
        private void PenH_Click(object sender, EventArgs e)
        {
            PictureBox pen = sender as PictureBox;
            int penRow = int.Parse(pen.Name.Remove(0, 18));
            bool check = true;
            for (int i = 0; i < 10; i++)
            {
                if (LinkActive_v[penRow, i]) continue;
                else { check = false; break; }
            }
            if (check)
            {
                for(int i = 0; i < 10; i++)
                {
                    LinkActive_v[penRow, i] = false;
                    LinkV[penRow, i].Image = replace.Properties.Resources.unchain_vertical;
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    LinkActive_v[penRow, i] = true;
                    LinkV[penRow, i].Image = replace.Properties.Resources.chain_vertical;
                }
            }
        }
        private void PenV_Click(object sender, EventArgs e)
        {
            PictureBox pen = sender as PictureBox;
            int penCol = int.Parse(pen.Name.Remove(0, 18));
            bool check = true;
            for (int i = 0; i < 10; i++)
            {
                if (LinkActive_h[i, penCol]) continue;
                else { check = false; break; }
            }
            if (check)
            {
                for (int i = 0; i < 10; i++)
                {
                    LinkActive_h[i, penCol] = false;
                    LinkH[i, penCol].Image = replace.Properties.Resources.unchain_horizontal;
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    LinkActive_h[i, penCol] = true;
                    LinkH[i, penCol].Image = replace.Properties.Resources.chain_horizontal;
                }
            }
        }
        private void Cent_Click(object sender, EventArgs e)
        {
            PictureBox cent = sender as PictureBox;
            string[] centlocation = cent.Name.Remove(0, 19).Split('C');
            int centRow = int.Parse(centlocation[0]);
            int centCol = int.Parse(centlocation[1]);
            if (LinkActive_h[centRow, centCol] && LinkActive_h[centRow + 1, centCol] &&
                LinkActive_v[centRow, centCol] && LinkActive_v[centRow, centCol + 1])
            {
                LinkActive_h[centRow, centCol] = false;
                LinkActive_h[centRow + 1, centCol] = false;
                LinkActive_v[centRow, centCol] = false;
                LinkActive_v[centRow, centCol + 1] = false;
                LinkH[centRow, centCol].Image = replace.Properties.Resources.unchain_horizontal;
                LinkH[centRow + 1, centCol].Image = replace.Properties.Resources.unchain_horizontal;
                LinkV[centRow, centCol].Image = replace.Properties.Resources.unchain_vertical;
                LinkV[centRow, centCol + 1].Image = replace.Properties.Resources.unchain_vertical;
            }
            else
            {
                LinkActive_h[centRow, centCol] = true;
                LinkActive_h[centRow + 1, centCol] = true;
                LinkActive_v[centRow, centCol] = true;
                LinkActive_v[centRow, centCol + 1] = true;
                LinkH[centRow, centCol].Image = replace.Properties.Resources.chain_horizontal;
                LinkH[centRow + 1, centCol].Image = replace.Properties.Resources.chain_horizontal;
                LinkV[centRow, centCol].Image = replace.Properties.Resources.chain_vertical;
                LinkV[centRow, centCol + 1].Image = replace.Properties.Resources.chain_vertical;
            }
        }
        private void LinkH_Click(object sender, EventArgs e)
        {
            PictureBox link_h = sender as PictureBox;
            string[] linklocation = link_h.Name.Remove(0, 20).Split('C');
            int linkRow = int.Parse(linklocation[0]);
            int linkCol = int.Parse(linklocation[1]);
            if (LinkActive_h[linkRow, linkCol])
            {
                LinkActive_h[linkRow, linkCol] = false;
                link_h.Image = replace.Properties.Resources.unchain_horizontal;
            }
            else
            {
                LinkActive_h[linkRow, linkCol] = true;
                link_h.Image = replace.Properties.Resources.chain_horizontal;
            }
        }
        private void LinkV_Click(object sender, EventArgs e)
        {
            PictureBox link_v = sender as PictureBox;
            string[] linklocation = link_v.Name.Remove(0, 20).Split('C');
            int linkRow = int.Parse(linklocation[0]);
            int linkCol = int.Parse(linklocation[1]);
            if (LinkActive_v[linkRow, linkCol])
            {
                LinkActive_v[linkRow, linkCol] = false;
                link_v.Image = replace.Properties.Resources.unchain_vertical;
            }
            else
            {
                LinkActive_v[linkRow, linkCol] = true;
                link_v.Image = replace.Properties.Resources.chain_vertical;
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
