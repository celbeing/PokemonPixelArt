
namespace Image_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.merge = new System.Windows.Forms.Button();
            this.separate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // merge
            // 
            this.merge.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.merge.Location = new System.Drawing.Point(12, 12);
            this.merge.Name = "merge";
            this.merge.Size = new System.Drawing.Size(381, 111);
            this.merge.TabIndex = 0;
            this.merge.Text = "병합";
            this.merge.UseVisualStyleBackColor = true;
            this.merge.Click += new System.EventHandler(this.merge_Click);
            // 
            // separate
            // 
            this.separate.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.separate.Location = new System.Drawing.Point(12, 137);
            this.separate.Name = "separate";
            this.separate.Size = new System.Drawing.Size(381, 111);
            this.separate.TabIndex = 1;
            this.separate.Text = "분리";
            this.separate.UseVisualStyleBackColor = true;
            this.separate.Click += new System.EventHandler(this.separate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 260);
            this.Controls.Add(this.separate);
            this.Controls.Add(this.merge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "이미지 변환기";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button merge;
        private System.Windows.Forms.Button separate;
    }
}

