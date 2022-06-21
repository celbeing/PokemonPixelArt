
namespace replace
{
    partial class MainClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainClient));
            this.MainClient_Label_Title = new System.Windows.Forms.Label();
            this.MainClient_Label_Version = new System.Windows.Forms.Label();
            this.MainClient_Button_LayoutSetting = new System.Windows.Forms.Button();
            this.MainClient_Button_ClassSetting = new System.Windows.Forms.Button();
            this.MainClient_Button_Replacement = new System.Windows.Forms.Button();
            this.MainClient_Label_Sign = new System.Windows.Forms.Label();
            this.MainClient_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // MainClient_Label_Title
            // 
            this.MainClient_Label_Title.AutoSize = true;
            this.MainClient_Label_Title.Font = new System.Drawing.Font("DOSMyungjo", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainClient_Label_Title.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainClient_Label_Title.Location = new System.Drawing.Point(0, 15);
            this.MainClient_Label_Title.Name = "MainClient_Label_Title";
            this.MainClient_Label_Title.Size = new System.Drawing.Size(380, 64);
            this.MainClient_Label_Title.TabIndex = 0;
            this.MainClient_Label_Title.Text = "자리 바꾸기";
            this.MainClient_Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainClient_Label_Version
            // 
            this.MainClient_Label_Version.AutoSize = true;
            this.MainClient_Label_Version.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainClient_Label_Version.Location = new System.Drawing.Point(331, 79);
            this.MainClient_Label_Version.Name = "MainClient_Label_Version";
            this.MainClient_Label_Version.Size = new System.Drawing.Size(27, 12);
            this.MainClient_Label_Version.TabIndex = 1;
            this.MainClient_Label_Version.Text = "v1.0";
            // 
            // MainClient_Button_LayoutSetting
            // 
            this.MainClient_Button_LayoutSetting.AccessibleDescription = "";
            this.MainClient_Button_LayoutSetting.Location = new System.Drawing.Point(292, 121);
            this.MainClient_Button_LayoutSetting.Name = "MainClient_Button_LayoutSetting";
            this.MainClient_Button_LayoutSetting.Size = new System.Drawing.Size(75, 23);
            this.MainClient_Button_LayoutSetting.TabIndex = 2;
            this.MainClient_Button_LayoutSetting.Text = "교실 설정";
            this.MainClient_ToolTip.SetToolTip(this.MainClient_Button_LayoutSetting, "교실의 책상 배치를 설정합니다.");
            this.MainClient_Button_LayoutSetting.UseVisualStyleBackColor = true;
            // 
            // MainClient_Button_ClassSetting
            // 
            this.MainClient_Button_ClassSetting.Location = new System.Drawing.Point(292, 150);
            this.MainClient_Button_ClassSetting.Name = "MainClient_Button_ClassSetting";
            this.MainClient_Button_ClassSetting.Size = new System.Drawing.Size(75, 23);
            this.MainClient_Button_ClassSetting.TabIndex = 3;
            this.MainClient_Button_ClassSetting.Text = "학급 설정";
            this.MainClient_ToolTip.SetToolTip(this.MainClient_Button_ClassSetting, "학급 인원 수, 학생 이름, 성별, 같이 앉히면 안되는 사람 등\r\n자리 배치시 고려 사항을 설정합니다.");
            this.MainClient_Button_ClassSetting.UseVisualStyleBackColor = true;
            // 
            // MainClient_Button_Replacement
            // 
            this.MainClient_Button_Replacement.Location = new System.Drawing.Point(292, 179);
            this.MainClient_Button_Replacement.Name = "MainClient_Button_Replacement";
            this.MainClient_Button_Replacement.Size = new System.Drawing.Size(75, 23);
            this.MainClient_Button_Replacement.TabIndex = 4;
            this.MainClient_Button_Replacement.Text = "자리 배치";
            this.MainClient_ToolTip.SetToolTip(this.MainClient_Button_Replacement, "자리를 배치합니다.");
            this.MainClient_Button_Replacement.UseVisualStyleBackColor = true;
            // 
            // MainClient_Label_Sign
            // 
            this.MainClient_Label_Sign.AutoSize = true;
            this.MainClient_Label_Sign.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.MainClient_Label_Sign.Location = new System.Drawing.Point(9, 178);
            this.MainClient_Label_Sign.Name = "MainClient_Label_Sign";
            this.MainClient_Label_Sign.Size = new System.Drawing.Size(221, 24);
            this.MainClient_Label_Sign.TabIndex = 5;
            this.MainClient_Label_Sign.Text = "인디스쿨:전라남도교육지원청\r\n티스토리:https://celbeing.tistory.com/";
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 214);
            this.Controls.Add(this.MainClient_Label_Sign);
            this.Controls.Add(this.MainClient_Button_Replacement);
            this.Controls.Add(this.MainClient_Button_ClassSetting);
            this.Controls.Add(this.MainClient_Button_LayoutSetting);
            this.Controls.Add(this.MainClient_Label_Version);
            this.Controls.Add(this.MainClient_Label_Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(395, 253);
            this.MinimumSize = new System.Drawing.Size(395, 253);
            this.Name = "MainClient";
            this.Text = "자리바꾸기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainClient_Label_Title;
        private System.Windows.Forms.Label MainClient_Label_Version;
        private System.Windows.Forms.Button MainClient_Button_LayoutSetting;
        private System.Windows.Forms.Button MainClient_Button_ClassSetting;
        private System.Windows.Forms.Button MainClient_Button_Replacement;
        private System.Windows.Forms.Label MainClient_Label_Sign;
        private System.Windows.Forms.ToolTip MainClient_ToolTip;
    }
}

