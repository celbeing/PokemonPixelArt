
namespace Image_Editor
{
    partial class Size
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
            this.Label_text = new System.Windows.Forms.Label();
            this.Label_width = new System.Windows.Forms.Label();
            this.Label_height = new System.Windows.Forms.Label();
            this.Button_Submit = new System.Windows.Forms.Button();
            this.Textbox_width = new System.Windows.Forms.TextBox();
            this.Textbox_height = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label_text
            // 
            this.Label_text.AutoSize = true;
            this.Label_text.Location = new System.Drawing.Point(12, 12);
            this.Label_text.Name = "Label_text";
            this.Label_text.Size = new System.Drawing.Size(217, 12);
            this.Label_text.Text = "이미지 조각 하나의 크기를 지정합니다.";
            // 
            // Label_width
            // 
            this.Label_width.AutoSize = true;
            this.Label_width.Location = new System.Drawing.Point(12, 40);
            this.Label_width.Name = "Label_width";
            this.Label_width.Size = new System.Drawing.Size(29, 12);
            this.Label_width.Text = "가로";
            // 
            // Label_height
            // 
            this.Label_height.AutoSize = true;
            this.Label_height.Location = new System.Drawing.Point(12, 73);
            this.Label_height.Name = "Label_height";
            this.Label_height.Size = new System.Drawing.Size(29, 12);
            this.Label_height.Text = "세로";
            // 
            // Button_Submit
            // 
            this.Button_Submit.Location = new System.Drawing.Point(154, 67);
            this.Button_Submit.Name = "Button_Submit";
            this.Button_Submit.Size = new System.Drawing.Size(75, 23);
            this.Button_Submit.TabIndex = 2;
            this.Button_Submit.Text = "확인";
            this.Button_Submit.UseVisualStyleBackColor = true;
            this.Button_Submit.Click += new System.EventHandler(this.Button_Submit_Click);
            // 
            // Textbox_width
            // 
            this.Textbox_width.Location = new System.Drawing.Point(41, 36);
            this.Textbox_width.Name = "Textbox_width";
            this.Textbox_width.Size = new System.Drawing.Size(100, 21);
            this.Textbox_width.TabIndex = 0;
            // 
            // Textbox_height
            // 
            this.Textbox_height.Location = new System.Drawing.Point(41, 69);
            this.Textbox_height.Name = "Textbox_height";
            this.Textbox_height.Size = new System.Drawing.Size(100, 21);
            this.Textbox_height.TabIndex = 1;
            // 
            // Size
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 102);
            this.Controls.Add(this.Textbox_height);
            this.Controls.Add(this.Textbox_width);
            this.Controls.Add(this.Button_Submit);
            this.Controls.Add(this.Label_height);
            this.Controls.Add(this.Label_width);
            this.Controls.Add(this.Label_text);
            this.MaximumSize = new System.Drawing.Size(257, 141);
            this.MinimumSize = new System.Drawing.Size(257, 141);
            this.Name = "Size";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "이미지 크기 지정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_text;
        private System.Windows.Forms.Label Label_width;
        private System.Windows.Forms.Label Label_height;
        private System.Windows.Forms.Button Button_Submit;
        private System.Windows.Forms.TextBox Textbox_width;
        private System.Windows.Forms.TextBox Textbox_height;
    }
}