using System.Windows.Forms;
using System.Drawing;
namespace GameSwiper
{
    partial class Form1
    {
        public int FieldRows { get; set; }
        public int FieldCols { get; set; }
        public int FieldMines { get; set; }
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            PlayGround = new DataGridView();
            Column1 = new DataGridViewButtonColumn();
            Difficulty_Label = new Label();
            Difficulty = new ComboBox();
            ResetGameButtom = new Button();
            ExitButtom = new Button();
            FlagCounter_Label = new Label();
            FlagCounter_TextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PlayGround).BeginInit();
            SuspendLayout();
            // 
            // PlayGround
            // 
            PlayGround.AllowUserToResizeColumns = false;
            PlayGround.AllowUserToResizeRows = false;
            PlayGround.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PlayGround.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            PlayGround.Location = new Point(143, 24);
            PlayGround.Name = "PlayGround";
            PlayGround.ReadOnly = true;
            PlayGround.RowHeadersWidth = 51;
            PlayGround.RowTemplate.Height = 29;
            PlayGround.Size = new Size(650, 486);
            PlayGround.TabIndex = 0;
            PlayGround.CellMouseClick += DataGridView1_CellMouseClick;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            Column1.DefaultCellStyle = dataGridViewCellStyle1;
            Column1.FlatStyle = FlatStyle.Popup;
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Difficulty_Label
            // 
            Difficulty_Label.AutoSize = true;
            Difficulty_Label.Location = new Point(12, 1);
            Difficulty_Label.Name = "Difficulty_Label";
            Difficulty_Label.Size = new Size(120, 20);
            Difficulty_Label.TabIndex = 3;
            Difficulty_Label.Text = "Choose difficulty";
            // 
            // Difficulty
            // 
            Difficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            Difficulty.Items.AddRange(new object[] { "Easy", "Normal", "Hard" });
            Difficulty.Location = new Point(9, 24);
            Difficulty.Name = "Difficulty";
            Difficulty.Size = new Size(119, 28);
            Difficulty.TabIndex = 4;
            Difficulty.SelectedIndexChanged += Difficulty_SelectedIndexChanged;
            // 
            // ResetGameButtom
            // 
            ResetGameButtom.Location = new Point(9, 386);
            ResetGameButtom.Name = "ResetGameButtom";
            ResetGameButtom.Size = new Size(119, 42);
            ResetGameButtom.TabIndex = 5;
            ResetGameButtom.Text = "Reset Game";
            ResetGameButtom.UseVisualStyleBackColor = true;
            ResetGameButtom.Click += ResetGame_Click;
            // 
            // ExitButtom
            // 
            ExitButtom.Location = new Point(9, 444);
            ExitButtom.Name = "ExitButtom";
            ExitButtom.Size = new Size(119, 37);
            ExitButtom.TabIndex = 6;
            ExitButtom.Text = "Exit";
            ExitButtom.UseVisualStyleBackColor = true;
            ExitButtom.Click += ExitButtom_Click;
            // 
            // FlagCounter_Label
            // 
            FlagCounter_Label.AutoSize = true;
            FlagCounter_Label.Location = new Point(13, 94);
            FlagCounter_Label.Name = "FlagCounter_Label";
            FlagCounter_Label.Size = new Size(91, 20);
            FlagCounter_Label.TabIndex = 7;
            FlagCounter_Label.Text = "Flag counter";
            // 
            // FlagCounter_TextBox
            // 
            FlagCounter_TextBox.Enabled = false;
            FlagCounter_TextBox.Location = new Point(9, 126);
            FlagCounter_TextBox.Name = "FlagCounter_TextBox";
            FlagCounter_TextBox.Size = new Size(119, 27);
            FlagCounter_TextBox.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 522);
            Controls.Add(FlagCounter_TextBox);
            Controls.Add(FlagCounter_Label);
            Controls.Add(ExitButtom);
            Controls.Add(ResetGameButtom);
            Controls.Add(Difficulty);
            Controls.Add(Difficulty_Label);
            Controls.Add(PlayGround);
            Name = "Form1";
            Text = "Mine Swiper";
            ((System.ComponentModel.ISupportInitialize)PlayGround).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private DataGridView PlayGround;
        private Label Difficulty_Label;
        private ComboBox Difficulty;
        private Button ResetGameButtom;
        private DataGridViewButtonColumn Column1;
        private Button ExitButtom;
        private Label FlagCounter_Label;
        private TextBox FlagCounter_TextBox;
    }
}