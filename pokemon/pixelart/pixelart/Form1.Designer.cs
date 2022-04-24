
namespace pixelart
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSeparate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.Location = new System.Drawing.Point(10, 10);
            this.pic.Margin = new System.Windows.Forms.Padding(0);
            this.pic.MaximumSize = new System.Drawing.Size(1280, 960);
            this.pic.MinimumSize = new System.Drawing.Size(400, 300);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(400, 300);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("굴림", 10F);
            this.btnLoad.Location = new System.Drawing.Point(160, 313);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Image";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSeparate
            // 
            this.btnSeparate.Font = new System.Drawing.Font("굴림", 10F);
            this.btnSeparate.Location = new System.Drawing.Point(308, 313);
            this.btnSeparate.Name = "btnSeparate";
            this.btnSeparate.Size = new System.Drawing.Size(100, 30);
            this.btnSeparate.TabIndex = 2;
            this.btnSeparate.Text = "separate";
            this.btnSeparate.UseVisualStyleBackColor = true;
            this.btnSeparate.Click += new System.EventHandler(this.btnSeparate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 349);
            this.Controls.Add(this.btnSeparate);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSeparate;
    }
}

