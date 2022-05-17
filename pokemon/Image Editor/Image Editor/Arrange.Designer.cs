
namespace Image_Editor_Client
{
    partial class Arrange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arrange));
            this.Label_text = new System.Windows.Forms.Label();
            this.Label_row = new System.Windows.Forms.Label();
            this.Textbox_row = new System.Windows.Forms.TextBox();
            this.Button_submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label_text
            // 
            this.Label_text.AutoSize = true;
            this.Label_text.Location = new System.Drawing.Point(12, 12);
            this.Label_text.Name = "Label_text";
            this.Label_text.Size = new System.Drawing.Size(233, 12);
            this.Label_text.TabIndex = 3;
            this.Label_text.Text = "한 줄에 배치할 조각의 개수를 입력하세요.";
            // 
            // Label_row
            // 
            this.Label_row.AutoSize = true;
            this.Label_row.Location = new System.Drawing.Point(112, 48);
            this.Label_row.Name = "Label_row";
            this.Label_row.Size = new System.Drawing.Size(17, 12);
            this.Label_row.TabIndex = 2;
            this.Label_row.Text = "개";
            // 
            // Textbox_row
            // 
            this.Textbox_row.Location = new System.Drawing.Point(12, 43);
            this.Textbox_row.Name = "Textbox_row";
            this.Textbox_row.Size = new System.Drawing.Size(100, 21);
            this.Textbox_row.TabIndex = 0;
            // 
            // Button_submit
            // 
            this.Button_submit.Location = new System.Drawing.Point(170, 42);
            this.Button_submit.Name = "Button_submit";
            this.Button_submit.Size = new System.Drawing.Size(75, 23);
            this.Button_submit.TabIndex = 1;
            this.Button_submit.Text = "확인";
            this.Button_submit.UseVisualStyleBackColor = true;
            this.Button_submit.Click += new System.EventHandler(this.Button_submit_Click);
            // 
            // Arrange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 75);
            this.Controls.Add(this.Button_submit);
            this.Controls.Add(this.Textbox_row);
            this.Controls.Add(this.Label_row);
            this.Controls.Add(this.Label_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(273, 114);
            this.MinimumSize = new System.Drawing.Size(273, 114);
            this.Name = "Arrange";
            this.Text = "조각 배치 설정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_text;
        private System.Windows.Forms.Label Label_row;
        private System.Windows.Forms.TextBox Textbox_row;
        private System.Windows.Forms.Button Button_submit;
    }
}