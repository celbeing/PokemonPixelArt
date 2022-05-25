
namespace Pokemon_Drawing_ver2
{
    partial class Main_Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Client));
            this.tab_control = new System.Windows.Forms.TabControl();
            this.search = new System.Windows.Forms.TabPage();
            this.label_signature = new System.Windows.Forms.Label();
            this.check_search_desktop = new System.Windows.Forms.CheckBox();
            this.combo_search_pokemon_difficulty = new System.Windows.Forms.ComboBox();
            this.label_search_pokemon_data = new System.Windows.Forms.Label();
            this.combo_search_pokemon_form = new System.Windows.Forms.ComboBox();
            this.button_search_out = new System.Windows.Forms.Button();
            this.button_search_pokemon = new System.Windows.Forms.Button();
            this.image_search_pokemon = new System.Windows.Forms.PictureBox();
            this.textbox_number = new System.Windows.Forms.TextBox();
            this.label_search_pokemon = new System.Windows.Forms.Label();
            this.random = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.check_random_desktop = new System.Windows.Forms.CheckBox();
            this.combo_random_pokemon_difficulty = new System.Windows.Forms.ComboBox();
            this.label_random_pokemon_data = new System.Windows.Forms.Label();
            this.combo_random_pokemon_form = new System.Windows.Forms.ComboBox();
            this.check_gen8 = new System.Windows.Forms.CheckBox();
            this.check_gen7 = new System.Windows.Forms.CheckBox();
            this.check_gen6 = new System.Windows.Forms.CheckBox();
            this.check_gen5 = new System.Windows.Forms.CheckBox();
            this.check_gen4 = new System.Windows.Forms.CheckBox();
            this.check_gen3 = new System.Windows.Forms.CheckBox();
            this.check_gen2 = new System.Windows.Forms.CheckBox();
            this.check_gen1 = new System.Windows.Forms.CheckBox();
            this.button_random_out = new System.Windows.Forms.Button();
            this.button_random_pokemon = new System.Windows.Forms.Button();
            this.image_random_pokemon = new System.Windows.Forms.PictureBox();
            this.label_random_pokemon = new System.Windows.Forms.Label();
            this.tab_control.SuspendLayout();
            this.search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_search_pokemon)).BeginInit();
            this.random.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_random_pokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.search);
            this.tab_control.Controls.Add(this.random);
            this.tab_control.Location = new System.Drawing.Point(12, 12);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(436, 270);
            this.tab_control.TabIndex = 0;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.Transparent;
            this.search.Controls.Add(this.label_signature);
            this.search.Controls.Add(this.check_search_desktop);
            this.search.Controls.Add(this.combo_search_pokemon_difficulty);
            this.search.Controls.Add(this.label_search_pokemon_data);
            this.search.Controls.Add(this.combo_search_pokemon_form);
            this.search.Controls.Add(this.button_search_out);
            this.search.Controls.Add(this.button_search_pokemon);
            this.search.Controls.Add(this.image_search_pokemon);
            this.search.Controls.Add(this.textbox_number);
            this.search.Controls.Add(this.label_search_pokemon);
            this.search.Location = new System.Drawing.Point(4, 22);
            this.search.Name = "search";
            this.search.Padding = new System.Windows.Forms.Padding(3);
            this.search.Size = new System.Drawing.Size(428, 244);
            this.search.TabIndex = 0;
            this.search.Text = "포켓몬 찾기";
            // 
            // label_signature
            // 
            this.label_signature.AutoSize = true;
            this.label_signature.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_signature.Location = new System.Drawing.Point(6, 208);
            this.label_signature.Name = "label_signature";
            this.label_signature.Size = new System.Drawing.Size(221, 24);
            this.label_signature.TabIndex = 11;
            this.label_signature.Text = "인디스쿨:전라남도교육지원청\r\n티스토리:https://celbeing.tistory.com/";
            // 
            // check_search_desktop
            // 
            this.check_search_desktop.AutoSize = true;
            this.check_search_desktop.Location = new System.Drawing.Point(229, 219);
            this.check_search_desktop.Name = "check_search_desktop";
            this.check_search_desktop.Size = new System.Drawing.Size(112, 16);
            this.check_search_desktop.TabIndex = 10;
            this.check_search_desktop.Text = "바탕화면에 저장";
            this.check_search_desktop.UseVisualStyleBackColor = true;
            // 
            // combo_search_pokemon_difficulty
            // 
            this.combo_search_pokemon_difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_search_pokemon_difficulty.FormattingEnabled = true;
            this.combo_search_pokemon_difficulty.Location = new System.Drawing.Point(301, 33);
            this.combo_search_pokemon_difficulty.Name = "combo_search_pokemon_difficulty";
            this.combo_search_pokemon_difficulty.Size = new System.Drawing.Size(121, 20);
            this.combo_search_pokemon_difficulty.TabIndex = 9;
            this.combo_search_pokemon_difficulty.Visible = false;
            this.combo_search_pokemon_difficulty.SelectedIndexChanged += new System.EventHandler(this.combo_search_pokemon_difficulty_SelectedIndexChanged);
            // 
            // label_search_pokemon_data
            // 
            this.label_search_pokemon_data.AutoSize = true;
            this.label_search_pokemon_data.Location = new System.Drawing.Point(284, 174);
            this.label_search_pokemon_data.Name = "label_search_pokemon_data";
            this.label_search_pokemon_data.Size = new System.Drawing.Size(11, 12);
            this.label_search_pokemon_data.TabIndex = 8;
            this.label_search_pokemon_data.Text = "-";
            this.label_search_pokemon_data.Visible = false;
            // 
            // combo_search_pokemon_form
            // 
            this.combo_search_pokemon_form.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_search_pokemon_form.FormattingEnabled = true;
            this.combo_search_pokemon_form.Location = new System.Drawing.Point(301, 6);
            this.combo_search_pokemon_form.Name = "combo_search_pokemon_form";
            this.combo_search_pokemon_form.Size = new System.Drawing.Size(121, 20);
            this.combo_search_pokemon_form.TabIndex = 7;
            this.combo_search_pokemon_form.Visible = false;
            this.combo_search_pokemon_form.SelectedIndexChanged += new System.EventHandler(this.combo_search_pokemon_form_SelectedIndexChanged);
            // 
            // button_search_out
            // 
            this.button_search_out.Location = new System.Drawing.Point(347, 215);
            this.button_search_out.Name = "button_search_out";
            this.button_search_out.Size = new System.Drawing.Size(75, 23);
            this.button_search_out.TabIndex = 6;
            this.button_search_out.Text = "저장하기";
            this.button_search_out.UseVisualStyleBackColor = true;
            this.button_search_out.Visible = false;
            this.button_search_out.Click += new System.EventHandler(this.button_search_out_Click);
            // 
            // button_search_pokemon
            // 
            this.button_search_pokemon.Location = new System.Drawing.Point(144, 37);
            this.button_search_pokemon.Name = "button_search_pokemon";
            this.button_search_pokemon.Size = new System.Drawing.Size(75, 23);
            this.button_search_pokemon.TabIndex = 3;
            this.button_search_pokemon.Text = "찾기";
            this.button_search_pokemon.UseVisualStyleBackColor = true;
            this.button_search_pokemon.Click += new System.EventHandler(this.button_search_pokemon_Click);
            // 
            // image_search_pokemon
            // 
            this.image_search_pokemon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_search_pokemon.Location = new System.Drawing.Point(286, 59);
            this.image_search_pokemon.Name = "image_search_pokemon";
            this.image_search_pokemon.Size = new System.Drawing.Size(138, 114);
            this.image_search_pokemon.TabIndex = 4;
            this.image_search_pokemon.TabStop = false;
            // 
            // textbox_number
            // 
            this.textbox_number.Location = new System.Drawing.Point(38, 37);
            this.textbox_number.Name = "textbox_number";
            this.textbox_number.Size = new System.Drawing.Size(100, 21);
            this.textbox_number.TabIndex = 1;
            // 
            // label_search_pokemon
            // 
            this.label_search_pokemon.AutoSize = true;
            this.label_search_pokemon.Location = new System.Drawing.Point(6, 6);
            this.label_search_pokemon.Name = "label_search_pokemon";
            this.label_search_pokemon.Size = new System.Drawing.Size(173, 48);
            this.label_search_pokemon.TabIndex = 5;
            this.label_search_pokemon.Text = "포켓몬을 검색합니다.\r\n포켓몬의 번호로 검색해주세요.\r\n\r\n  No.";
            // 
            // random
            // 
            this.random.BackColor = System.Drawing.Color.Transparent;
            this.random.Controls.Add(this.label1);
            this.random.Controls.Add(this.check_random_desktop);
            this.random.Controls.Add(this.combo_random_pokemon_difficulty);
            this.random.Controls.Add(this.label_random_pokemon_data);
            this.random.Controls.Add(this.combo_random_pokemon_form);
            this.random.Controls.Add(this.check_gen8);
            this.random.Controls.Add(this.check_gen7);
            this.random.Controls.Add(this.check_gen6);
            this.random.Controls.Add(this.check_gen5);
            this.random.Controls.Add(this.check_gen4);
            this.random.Controls.Add(this.check_gen3);
            this.random.Controls.Add(this.check_gen2);
            this.random.Controls.Add(this.check_gen1);
            this.random.Controls.Add(this.button_random_out);
            this.random.Controls.Add(this.button_random_pokemon);
            this.random.Controls.Add(this.image_random_pokemon);
            this.random.Controls.Add(this.label_random_pokemon);
            this.random.Location = new System.Drawing.Point(4, 22);
            this.random.Name = "random";
            this.random.Padding = new System.Windows.Forms.Padding(3);
            this.random.Size = new System.Drawing.Size(428, 244);
            this.random.TabIndex = 4;
            this.random.Text = "포켓몬 뽑기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(6, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "인디스쿨:전라남도교육지원청\r\n티스토리:https://celbeing.tistory.com/";
            // 
            // check_random_desktop
            // 
            this.check_random_desktop.AutoSize = true;
            this.check_random_desktop.Location = new System.Drawing.Point(229, 219);
            this.check_random_desktop.Name = "check_random_desktop";
            this.check_random_desktop.Size = new System.Drawing.Size(112, 16);
            this.check_random_desktop.TabIndex = 20;
            this.check_random_desktop.Text = "바탕화면에 저장";
            this.check_random_desktop.UseVisualStyleBackColor = true;
            // 
            // combo_random_pokemon_difficulty
            // 
            this.combo_random_pokemon_difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_random_pokemon_difficulty.FormattingEnabled = true;
            this.combo_random_pokemon_difficulty.Location = new System.Drawing.Point(301, 33);
            this.combo_random_pokemon_difficulty.Name = "combo_random_pokemon_difficulty";
            this.combo_random_pokemon_difficulty.Size = new System.Drawing.Size(121, 20);
            this.combo_random_pokemon_difficulty.TabIndex = 19;
            this.combo_random_pokemon_difficulty.Visible = false;
            this.combo_random_pokemon_difficulty.SelectedIndexChanged += new System.EventHandler(this.combo_random_pokemon_difficulty_SelectedIndexChanged);
            // 
            // label_random_pokemon_data
            // 
            this.label_random_pokemon_data.AutoSize = true;
            this.label_random_pokemon_data.Location = new System.Drawing.Point(284, 174);
            this.label_random_pokemon_data.Name = "label_random_pokemon_data";
            this.label_random_pokemon_data.Size = new System.Drawing.Size(11, 12);
            this.label_random_pokemon_data.TabIndex = 18;
            this.label_random_pokemon_data.Text = "-";
            this.label_random_pokemon_data.Visible = false;
            // 
            // combo_random_pokemon_form
            // 
            this.combo_random_pokemon_form.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_random_pokemon_form.FormattingEnabled = true;
            this.combo_random_pokemon_form.Location = new System.Drawing.Point(301, 6);
            this.combo_random_pokemon_form.Name = "combo_random_pokemon_form";
            this.combo_random_pokemon_form.Size = new System.Drawing.Size(121, 20);
            this.combo_random_pokemon_form.TabIndex = 17;
            this.combo_random_pokemon_form.Visible = false;
            this.combo_random_pokemon_form.SelectedIndexChanged += new System.EventHandler(this.combo_random_pokemon_form_SelectedIndexChanged);
            // 
            // check_gen8
            // 
            this.check_gen8.AutoSize = true;
            this.check_gen8.Checked = true;
            this.check_gen8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_gen8.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_gen8.Location = new System.Drawing.Point(100, 153);
            this.check_gen8.Name = "check_gen8";
            this.check_gen8.Size = new System.Drawing.Size(144, 16);
            this.check_gen8.TabIndex = 16;
            this.check_gen8.Text = "8세대(가라르, 히스이)";
            this.check_gen8.UseVisualStyleBackColor = true;
            this.check_gen8.CheckedChanged += new System.EventHandler(this.check_gen8_CheckedChanged);
            // 
            // check_gen7
            // 
            this.check_gen7.AutoSize = true;
            this.check_gen7.Checked = true;
            this.check_gen7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_gen7.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_gen7.Location = new System.Drawing.Point(100, 131);
            this.check_gen7.Name = "check_gen7";
            this.check_gen7.Size = new System.Drawing.Size(100, 16);
            this.check_gen7.TabIndex = 15;
            this.check_gen7.Text = "7세대(알로라)";
            this.check_gen7.UseVisualStyleBackColor = true;
            this.check_gen7.CheckedChanged += new System.EventHandler(this.check_gen7_CheckedChanged);
            // 
            // check_gen6
            // 
            this.check_gen6.AutoSize = true;
            this.check_gen6.Checked = true;
            this.check_gen6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_gen6.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_gen6.Location = new System.Drawing.Point(100, 109);
            this.check_gen6.Name = "check_gen6";
            this.check_gen6.Size = new System.Drawing.Size(100, 16);
            this.check_gen6.TabIndex = 14;
            this.check_gen6.Text = "6세대(칼로스)";
            this.check_gen6.UseVisualStyleBackColor = true;
            this.check_gen6.CheckedChanged += new System.EventHandler(this.check_gen6_CheckedChanged);
            // 
            // check_gen5
            // 
            this.check_gen5.AutoSize = true;
            this.check_gen5.Checked = true;
            this.check_gen5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_gen5.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_gen5.Location = new System.Drawing.Point(100, 87);
            this.check_gen5.Name = "check_gen5";
            this.check_gen5.Size = new System.Drawing.Size(88, 16);
            this.check_gen5.TabIndex = 13;
            this.check_gen5.Text = "5세대(하나)";
            this.check_gen5.UseVisualStyleBackColor = true;
            this.check_gen5.CheckedChanged += new System.EventHandler(this.check_gen5_CheckedChanged);
            // 
            // check_gen4
            // 
            this.check_gen4.AutoSize = true;
            this.check_gen4.Checked = true;
            this.check_gen4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_gen4.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_gen4.Location = new System.Drawing.Point(6, 153);
            this.check_gen4.Name = "check_gen4";
            this.check_gen4.Size = new System.Drawing.Size(88, 16);
            this.check_gen4.TabIndex = 12;
            this.check_gen4.Text = "4세대(신오)";
            this.check_gen4.UseVisualStyleBackColor = true;
            this.check_gen4.CheckedChanged += new System.EventHandler(this.check_gen4_CheckedChanged);
            // 
            // check_gen3
            // 
            this.check_gen3.AutoSize = true;
            this.check_gen3.Checked = true;
            this.check_gen3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_gen3.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_gen3.Location = new System.Drawing.Point(6, 131);
            this.check_gen3.Name = "check_gen3";
            this.check_gen3.Size = new System.Drawing.Size(88, 16);
            this.check_gen3.TabIndex = 11;
            this.check_gen3.Text = "3세대(호연)";
            this.check_gen3.UseVisualStyleBackColor = true;
            this.check_gen3.CheckedChanged += new System.EventHandler(this.check_gen3_CheckedChanged);
            // 
            // check_gen2
            // 
            this.check_gen2.AutoSize = true;
            this.check_gen2.Checked = true;
            this.check_gen2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_gen2.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_gen2.Location = new System.Drawing.Point(6, 109);
            this.check_gen2.Name = "check_gen2";
            this.check_gen2.Size = new System.Drawing.Size(88, 16);
            this.check_gen2.TabIndex = 10;
            this.check_gen2.Text = "2세대(성도)";
            this.check_gen2.UseVisualStyleBackColor = true;
            this.check_gen2.CheckedChanged += new System.EventHandler(this.check_gen2_CheckedChanged);
            // 
            // check_gen1
            // 
            this.check_gen1.AutoSize = true;
            this.check_gen1.Checked = true;
            this.check_gen1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_gen1.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_gen1.Location = new System.Drawing.Point(6, 87);
            this.check_gen1.Name = "check_gen1";
            this.check_gen1.Size = new System.Drawing.Size(88, 16);
            this.check_gen1.TabIndex = 9;
            this.check_gen1.Text = "1세대(관동)";
            this.check_gen1.UseVisualStyleBackColor = true;
            this.check_gen1.CheckedChanged += new System.EventHandler(this.check_gen1_CheckedChanged);
            // 
            // button_random_out
            // 
            this.button_random_out.Location = new System.Drawing.Point(347, 215);
            this.button_random_out.Name = "button_random_out";
            this.button_random_out.Size = new System.Drawing.Size(75, 23);
            this.button_random_out.TabIndex = 8;
            this.button_random_out.Text = "저장하기";
            this.button_random_out.UseVisualStyleBackColor = true;
            this.button_random_out.Visible = false;
            this.button_random_out.Click += new System.EventHandler(this.button_random_out_Click);
            // 
            // button_random_pokemon
            // 
            this.button_random_pokemon.Location = new System.Drawing.Point(127, 57);
            this.button_random_pokemon.Name = "button_random_pokemon";
            this.button_random_pokemon.Size = new System.Drawing.Size(75, 23);
            this.button_random_pokemon.TabIndex = 5;
            this.button_random_pokemon.Text = "뽑기";
            this.button_random_pokemon.UseVisualStyleBackColor = true;
            this.button_random_pokemon.Click += new System.EventHandler(this.button_random_pokemon_Click);
            // 
            // image_random_pokemon
            // 
            this.image_random_pokemon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_random_pokemon.Location = new System.Drawing.Point(286, 59);
            this.image_random_pokemon.Name = "image_random_pokemon";
            this.image_random_pokemon.Size = new System.Drawing.Size(138, 114);
            this.image_random_pokemon.TabIndex = 6;
            this.image_random_pokemon.TabStop = false;
            // 
            // label_random_pokemon
            // 
            this.label_random_pokemon.AutoSize = true;
            this.label_random_pokemon.Location = new System.Drawing.Point(6, 6);
            this.label_random_pokemon.Name = "label_random_pokemon";
            this.label_random_pokemon.Size = new System.Drawing.Size(285, 48);
            this.label_random_pokemon.TabIndex = 7;
            this.label_random_pokemon.Text = "무작위로 포켓몬을 하나 뽑습니다.\r\n세대를 선택해 뽑을 수 있습니다.\r\n뽑힌 포켓몬의 형태는 자유롭게 선택할 수 있습니다.\r\n(색이 다른 포켓몬 " +
    "등장 확률 = 0.1%)";
            // 
            // Main_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 294);
            this.Controls.Add(this.tab_control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main_Client";
            this.Text = "포켓몬 뽑기 v2.01";
            this.tab_control.ResumeLayout(false);
            this.search.ResumeLayout(false);
            this.search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_search_pokemon)).EndInit();
            this.random.ResumeLayout(false);
            this.random.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_random_pokemon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.TabPage search;
        private System.Windows.Forms.Label label_search_pokemon;
        private System.Windows.Forms.PictureBox image_search_pokemon;
        private System.Windows.Forms.TextBox textbox_number;
        private System.Windows.Forms.Button button_search_pokemon;
        private System.Windows.Forms.ComboBox combo_search_pokemon_form;
        private System.Windows.Forms.ComboBox combo_search_pokemon_difficulty;
        private System.Windows.Forms.Label label_search_pokemon_data;
        private System.Windows.Forms.Button button_search_out;

        private System.Windows.Forms.TabPage random;
        private System.Windows.Forms.PictureBox image_random_pokemon;
        private System.Windows.Forms.Label label_random_pokemon;
        private System.Windows.Forms.Button button_random_pokemon;
        private System.Windows.Forms.CheckBox check_gen1;
        private System.Windows.Forms.CheckBox check_gen2;
        private System.Windows.Forms.CheckBox check_gen3;
        private System.Windows.Forms.CheckBox check_gen4;
        private System.Windows.Forms.CheckBox check_gen5;
        private System.Windows.Forms.CheckBox check_gen6;
        private System.Windows.Forms.CheckBox check_gen7;
        private System.Windows.Forms.CheckBox check_gen8;
        private System.Windows.Forms.ComboBox combo_random_pokemon_form;
        private System.Windows.Forms.ComboBox combo_random_pokemon_difficulty;
        private System.Windows.Forms.Label label_random_pokemon_data;
        private System.Windows.Forms.Button button_random_out;
        private System.Windows.Forms.CheckBox check_search_desktop;
        private System.Windows.Forms.CheckBox check_random_desktop;
        private System.Windows.Forms.Label label_signature;
        private System.Windows.Forms.Label label1;
    }
}

