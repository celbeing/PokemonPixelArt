using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Editor_Client
{
    public partial class Arrange : Form
    {
        int merge_row = 1;
        public delegate void ArrangeDataHandler(int r);
        public event ArrangeDataHandler Arrange_Data_Send;
        public Arrange()
        {
            InitializeComponent();
            this.Textbox_row.Text = merge_row.ToString();
        }

        private void Button_submit_Click(object sender, EventArgs e)
        {
            try
            {
                merge_row = int.Parse(Textbox_row.Text);
                if (merge_row > 0)
                {
                    this.Arrange_Data_Send(merge_row);
                    this.Close();
                }
                else MessageBox.Show("0 이상의 자연수를 입력하세요.");
            }
            catch
            {
                MessageBox.Show("0 이상의 자연수를 입력하세요.");
            }
        }
    }
}
