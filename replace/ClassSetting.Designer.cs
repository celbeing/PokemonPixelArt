
namespace replace
{
    partial class ClassSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassSetting));
            this.ClassSetting_Button_Submit = new System.Windows.Forms.Button();
            this.ClassSetting_Label_Row = new System.Windows.Forms.Label();
            this.ClassSetting_Label_Column = new System.Windows.Forms.Label();
            this.ClassSetting_RowUpdown = new System.Windows.Forms.NumericUpDown();
            this.ClassSetting_ColumnUpdown = new System.Windows.Forms.NumericUpDown();
            this.ClassSetting_Button_Apply = new System.Windows.Forms.Button();
            this.ClassSetting_TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ClassSetting_PictureBox_Desk = new System.Windows.Forms.PictureBox();
            this.ClassSetting_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ClassSetting_RowUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassSetting_ColumnUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassSetting_PictureBox_Desk)).BeginInit();
            this.SuspendLayout();
            // 
            // ClassSetting_Button_Submit
            // 
            this.ClassSetting_Button_Submit.Location = new System.Drawing.Point(297, 223);
            this.ClassSetting_Button_Submit.Name = "ClassSetting_Button_Submit";
            this.ClassSetting_Button_Submit.Size = new System.Drawing.Size(75, 23);
            this.ClassSetting_Button_Submit.TabIndex = 0;
            this.ClassSetting_Button_Submit.Text = "확인";
            this.ClassSetting_ToolTip.SetToolTip(this.ClassSetting_Button_Submit, "이 설정을 저장합니다.");
            this.ClassSetting_Button_Submit.UseVisualStyleBackColor = true;
            this.ClassSetting_Button_Submit.Click += new System.EventHandler(this.ClassSetting_Button_Submit_Click);
            // 
            // ClassSetting_Label_Row
            // 
            this.ClassSetting_Label_Row.AutoSize = true;
            this.ClassSetting_Label_Row.Location = new System.Drawing.Point(12, 228);
            this.ClassSetting_Label_Row.Name = "ClassSetting_Label_Row";
            this.ClassSetting_Label_Row.Size = new System.Drawing.Size(17, 12);
            this.ClassSetting_Label_Row.TabIndex = 3;
            this.ClassSetting_Label_Row.Text = "행";
            // 
            // ClassSetting_Label_Column
            // 
            this.ClassSetting_Label_Column.AutoSize = true;
            this.ClassSetting_Label_Column.Location = new System.Drawing.Point(60, 228);
            this.ClassSetting_Label_Column.Name = "ClassSetting_Label_Column";
            this.ClassSetting_Label_Column.Size = new System.Drawing.Size(17, 12);
            this.ClassSetting_Label_Column.TabIndex = 4;
            this.ClassSetting_Label_Column.Text = "열";
            // 
            // ClassSetting_RowUpdown
            // 
            this.ClassSetting_RowUpdown.Location = new System.Drawing.Point(26, 224);
            this.ClassSetting_RowUpdown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ClassSetting_RowUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ClassSetting_RowUpdown.Name = "ClassSetting_RowUpdown";
            this.ClassSetting_RowUpdown.Size = new System.Drawing.Size(34, 21);
            this.ClassSetting_RowUpdown.TabIndex = 5;
            this.ClassSetting_ToolTip.SetToolTip(this.ClassSetting_RowUpdown, "앞, 뒤로 놓이는 책상 수를 조절합니다. (1~10)");
            this.ClassSetting_RowUpdown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ClassSetting_ColumnUpdown
            // 
            this.ClassSetting_ColumnUpdown.Location = new System.Drawing.Point(74, 224);
            this.ClassSetting_ColumnUpdown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ClassSetting_ColumnUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ClassSetting_ColumnUpdown.Name = "ClassSetting_ColumnUpdown";
            this.ClassSetting_ColumnUpdown.Size = new System.Drawing.Size(34, 21);
            this.ClassSetting_ColumnUpdown.TabIndex = 6;
            this.ClassSetting_ToolTip.SetToolTip(this.ClassSetting_ColumnUpdown, "양 옆으로 놓이는 책상 수를 조절합니다. (1~10)");
            this.ClassSetting_ColumnUpdown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // ClassSetting_Button_Apply
            // 
            this.ClassSetting_Button_Apply.Location = new System.Drawing.Point(114, 223);
            this.ClassSetting_Button_Apply.Name = "ClassSetting_Button_Apply";
            this.ClassSetting_Button_Apply.Size = new System.Drawing.Size(75, 23);
            this.ClassSetting_Button_Apply.TabIndex = 7;
            this.ClassSetting_Button_Apply.Text = "책상놓기";
            this.ClassSetting_ToolTip.SetToolTip(this.ClassSetting_Button_Apply, "책상을 배치합니다.");
            this.ClassSetting_Button_Apply.UseVisualStyleBackColor = true;
            this.ClassSetting_Button_Apply.Click += new System.EventHandler(this.ClassSetting_Button_Apply_Click);
            // 
            // ClassSetting_TableLayout
            // 
            this.ClassSetting_TableLayout.ColumnCount = 20;
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ClassSetting_TableLayout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClassSetting_TableLayout.Location = new System.Drawing.Point(12, 12);
            this.ClassSetting_TableLayout.Name = "ClassSetting_TableLayout";
            this.ClassSetting_TableLayout.RowCount = 20;
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ClassSetting_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ClassSetting_TableLayout.Size = new System.Drawing.Size(360, 200);
            this.ClassSetting_TableLayout.TabIndex = 8;
            // 
            // ClassSetting_PictureBox_Desk
            // 
            this.ClassSetting_PictureBox_Desk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassSetting_PictureBox_Desk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClassSetting_PictureBox_Desk.Location = new System.Drawing.Point(192, 220);
            this.ClassSetting_PictureBox_Desk.Margin = new System.Windows.Forms.Padding(0);
            this.ClassSetting_PictureBox_Desk.MaximumSize = new System.Drawing.Size(40, 30);
            this.ClassSetting_PictureBox_Desk.MinimumSize = new System.Drawing.Size(40, 30);
            this.ClassSetting_PictureBox_Desk.Name = "ClassSetting_PictureBox_Desk";
            this.ClassSetting_PictureBox_Desk.Size = new System.Drawing.Size(40, 30);
            this.ClassSetting_PictureBox_Desk.TabIndex = 9;
            this.ClassSetting_PictureBox_Desk.TabStop = false;
            this.ClassSetting_ToolTip.SetToolTip(this.ClassSetting_PictureBox_Desk, "모든 자리를 활성화하거나 비활성화합니다.");
            this.ClassSetting_PictureBox_Desk.Click += new System.EventHandler(this.ClassSetting_PictureBox_Desk_Click);
            // 
            // ClassSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 259);
            this.Controls.Add(this.ClassSetting_PictureBox_Desk);
            this.Controls.Add(this.ClassSetting_TableLayout);
            this.Controls.Add(this.ClassSetting_Button_Apply);
            this.Controls.Add(this.ClassSetting_ColumnUpdown);
            this.Controls.Add(this.ClassSetting_RowUpdown);
            this.Controls.Add(this.ClassSetting_Label_Column);
            this.Controls.Add(this.ClassSetting_Label_Row);
            this.Controls.Add(this.ClassSetting_Button_Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClassSetting";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "교실 설정(24명)";
            ((System.ComponentModel.ISupportInitialize)(this.ClassSetting_RowUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassSetting_ColumnUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassSetting_PictureBox_Desk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClassSetting_Button_Submit;
        private System.Windows.Forms.Label ClassSetting_Label_Row;
        private System.Windows.Forms.Label ClassSetting_Label_Column;
        private System.Windows.Forms.NumericUpDown ClassSetting_RowUpdown;
        private System.Windows.Forms.NumericUpDown ClassSetting_ColumnUpdown;
        private System.Windows.Forms.Button ClassSetting_Button_Apply;
        private System.Windows.Forms.TableLayoutPanel ClassSetting_TableLayout;
        private System.Windows.Forms.PictureBox ClassSetting_PictureBox_Desk;
        private System.Windows.Forms.ToolTip ClassSetting_ToolTip;
    }
}