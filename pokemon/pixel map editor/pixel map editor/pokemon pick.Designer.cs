
namespace pokemon_pixelart_maker
{
    partial class pokemon_pick
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pokemon_pick));
            this.pixel_table = new System.Windows.Forms.DataGridView();
            this.color_table = new System.Windows.Forms.DataGridView();
            this.pokemon = new System.Windows.Forms.PictureBox();
            this.pokemon_table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pixel_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemon_table)).BeginInit();
            this.SuspendLayout();
            // 
            // pixel_table
            // 
            this.pixel_table.AllowUserToAddRows = false;
            this.pixel_table.AllowUserToResizeColumns = false;
            this.pixel_table.AllowUserToResizeRows = false;
            this.pixel_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pixel_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.pixel_table.BackgroundColor = System.Drawing.Color.White;
            this.pixel_table.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pixel_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pixel_table.ColumnHeadersHeight = 10;
            this.pixel_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.pixel_table.ColumnHeadersVisible = false;
            this.pixel_table.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.pixel_table.EnableHeadersVisualStyles = false;
            this.pixel_table.GridColor = System.Drawing.Color.Silver;
            this.pixel_table.Location = new System.Drawing.Point(196, 27);
            this.pixel_table.Name = "pixel_table";
            this.pixel_table.ReadOnly = true;
            this.pixel_table.RowHeadersVisible = false;
            this.pixel_table.RowHeadersWidth = 10;
            this.pixel_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.pixel_table.RowTemplate.Height = 15;
            this.pixel_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.pixel_table.Size = new System.Drawing.Size(800, 603);
            this.pixel_table.TabIndex = 3;
            // 
            // color_table
            // 
            this.color_table.AllowUserToAddRows = false;
            this.color_table.AllowUserToDeleteRows = false;
            this.color_table.AllowUserToResizeColumns = false;
            this.color_table.AllowUserToResizeRows = false;
            this.color_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.color_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.color_table.BackgroundColor = System.Drawing.Color.White;
            this.color_table.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.color_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.color_table.Location = new System.Drawing.Point(22, 227);
            this.color_table.Name = "color_table";
            this.color_table.ReadOnly = true;
            this.color_table.RowHeadersVisible = false;
            this.color_table.RowHeadersWidth = 18;
            this.color_table.RowTemplate.Height = 23;
            this.color_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.color_table.Size = new System.Drawing.Size(150, 400);
            this.color_table.TabIndex = 4;
            // 
            // pokemon
            // 
            this.pokemon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pokemon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pokemon.Location = new System.Drawing.Point(35, 26);
            this.pokemon.Name = "pokemon";
            this.pokemon.Size = new System.Drawing.Size(120, 90);
            this.pokemon.TabIndex = 0;
            this.pokemon.TabStop = false;
            this.pokemon.Click += new System.EventHandler(this.pokemon_Click);
            // 
            // pokemon_table
            // 
            this.pokemon_table.AllowUserToAddRows = false;
            this.pokemon_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pokemon_table.BackgroundColor = System.Drawing.Color.White;
            this.pokemon_table.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pokemon_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pokemon_table.ColumnHeadersVisible = false;
            this.pokemon_table.GridColor = System.Drawing.Color.Silver;
            this.pokemon_table.Location = new System.Drawing.Point(22, 122);
            this.pokemon_table.Name = "pokemon_table";
            this.pokemon_table.RowHeadersVisible = false;
            this.pokemon_table.RowTemplate.Height = 23;
            this.pokemon_table.Size = new System.Drawing.Size(150, 99);
            this.pokemon_table.TabIndex = 6;
            // 
            // pokemon_pick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 660);
            this.Controls.Add(this.pokemon_table);
            this.Controls.Add(this.color_table);
            this.Controls.Add(this.pixel_table);
            this.Controls.Add(this.pokemon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pokemon_pick";
            this.Text = "포켓몬 랜덤 뽑기 (인디스쿨:전라남도교육지원청, 티스토리:https://celbeing.tistory.com/)";
            this.Load += new System.EventHandler(this.pokemon_pick_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pixel_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemon_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pokemon;
        private System.Windows.Forms.DataGridView pixel_table;
        private System.Windows.Forms.DataGridView color_table;
        private System.Windows.Forms.DataGridView pokemon_table;
    }
}

