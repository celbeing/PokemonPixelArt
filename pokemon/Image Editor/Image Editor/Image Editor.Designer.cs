
namespace Image_Editor
{
    partial class Image_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Editor));
            this.Button_merge = new System.Windows.Forms.Button();
            this.Button_separate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_merge
            // 
            this.Button_merge.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button_merge.Location = new System.Drawing.Point(12, 12);
            this.Button_merge.Name = "Button_merge";
            this.Button_merge.Size = new System.Drawing.Size(360, 120);
            this.Button_merge.TabIndex = 0;
            this.Button_merge.Text = "병합";
            this.Button_merge.UseVisualStyleBackColor = true;
            this.Button_merge.Click += new System.EventHandler(this.Button_merge_Click);
            // 
            // Button_separate
            // 
            this.Button_separate.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button_separate.Location = new System.Drawing.Point(12, 144);
            this.Button_separate.Name = "Button_separate";
            this.Button_separate.Size = new System.Drawing.Size(360, 120);
            this.Button_separate.TabIndex = 1;
            this.Button_separate.Text = "분리";
            this.Button_separate.UseVisualStyleBackColor = true;
            this.Button_separate.Click += new System.EventHandler(this.Button_separate_Click);
            // 
            // Image_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 276);
            this.Controls.Add(this.Button_separate);
            this.Controls.Add(this.Button_merge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(400, 315);
            this.Name = "Image_Editor";
            this.Text = "이미지 변환기";
            this.Load += new System.EventHandler(this.Image_Editor_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Size_Change);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_merge;
        private System.Windows.Forms.Button Button_separate;
    }
}

