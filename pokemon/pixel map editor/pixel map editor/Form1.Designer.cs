
namespace pixel_map_editor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pokemon = new System.Windows.Forms.PictureBox();
            this.load_image = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.pixel_table = new System.Windows.Forms.DataGridView();
            this.color_table = new System.Windows.Forms.DataGridView();
            this.random = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixel_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_table)).BeginInit();
            this.SuspendLayout();
            // 
            // pokemon
            // 
            this.pokemon.Location = new System.Drawing.Point(35, 26);
            this.pokemon.Name = "pokemon";
            this.pokemon.Size = new System.Drawing.Size(120, 90);
            this.pokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pokemon.TabIndex = 0;
            this.pokemon.TabStop = false;
            this.pokemon.Click += new System.EventHandler(this.pokemon_Click);
            // 
            // load_image
            // 
            this.load_image.Location = new System.Drawing.Point(58, 122);
            this.load_image.Name = "load_image";
            this.load_image.Size = new System.Drawing.Size(75, 23);
            this.load_image.TabIndex = 1;
            this.load_image.Text = "load";
            this.load_image.UseVisualStyleBackColor = true;
            this.load_image.Click += new System.EventHandler(this.load_image_Click);
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(58, 151);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 2;
            this.create.Text = "create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // pixel_table
            // 
            this.pixel_table.AllowUserToAddRows = false;
            this.pixel_table.AllowUserToResizeColumns = false;
            this.pixel_table.AllowUserToResizeRows = false;
            this.pixel_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pixel_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.pixel_table.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.pixel_table.Location = new System.Drawing.Point(196, 27);
            this.pixel_table.Name = "pixel_table";
            this.pixel_table.ReadOnly = true;
            this.pixel_table.RowHeadersVisible = false;
            this.pixel_table.RowHeadersWidth = 10;
            this.pixel_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.pixel_table.RowTemplate.Height = 15;
            this.pixel_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.pixel_table.Size = new System.Drawing.Size(800, 600);
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
            this.color_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.color_table.Location = new System.Drawing.Point(22, 227);
            this.color_table.Name = "color_table";
            this.color_table.RowHeadersVisible = false;
            this.color_table.RowHeadersWidth = 18;
            this.color_table.RowTemplate.Height = 23;
            this.color_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.color_table.Size = new System.Drawing.Size(150, 400);
            this.color_table.TabIndex = 4;
            // 
            // random
            // 
            this.random.Location = new System.Drawing.Point(58, 180);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(75, 23);
            this.random.TabIndex = 5;
            this.random.Text = "random";
            this.random.UseVisualStyleBackColor = true;
            this.random.Click += new System.EventHandler(this.random_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 655);
            this.Controls.Add(this.random);
            this.Controls.Add(this.color_table);
            this.Controls.Add(this.pixel_table);
            this.Controls.Add(this.create);
            this.Controls.Add(this.load_image);
            this.Controls.Add(this.pokemon);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixel_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pokemon;
        private System.Windows.Forms.Button load_image;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.DataGridView pixel_table;
        private System.Windows.Forms.DataGridView color_table;
        private System.Windows.Forms.Button random;
    }
}

