namespace CLIENT
{
    partial class Painting
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.BClear = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BWhite = new System.Windows.Forms.Button();
            this.BRed = new System.Windows.Forms.Button();
            this.BYellow = new System.Windows.Forms.Button();
            this.BOrange = new System.Windows.Forms.Button();
            this.BGreen = new System.Windows.Forms.Button();
            this.BBlue = new System.Windows.Forms.Button();
            this.BBlack = new System.Windows.Forms.Button();
            this.BChooseColor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.BSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1006, 570);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // BClear
            // 
            this.BClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BClear.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClear.Location = new System.Drawing.Point(0, 454);
            this.BClear.Name = "BClear";
            this.BClear.Size = new System.Drawing.Size(200, 58);
            this.BClear.TabIndex = 1;
            this.BClear.Text = "Clear";
            this.BClear.UseVisualStyleBackColor = true;
            this.BClear.Click += new System.EventHandler(this.BClear_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BWhite);
            this.flowLayoutPanel1.Controls.Add(this.BRed);
            this.flowLayoutPanel1.Controls.Add(this.BYellow);
            this.flowLayoutPanel1.Controls.Add(this.BOrange);
            this.flowLayoutPanel1.Controls.Add(this.BGreen);
            this.flowLayoutPanel1.Controls.Add(this.BBlue);
            this.flowLayoutPanel1.Controls.Add(this.BBlack);
            this.flowLayoutPanel1.Controls.Add(this.BChooseColor);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 107);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 89);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // BWhite
            // 
            this.BWhite.BackColor = System.Drawing.Color.White;
            this.BWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BWhite.Location = new System.Drawing.Point(3, 3);
            this.BWhite.Name = "BWhite";
            this.BWhite.Size = new System.Drawing.Size(30, 30);
            this.BWhite.TabIndex = 0;
            this.BWhite.UseVisualStyleBackColor = false;
            this.BWhite.Click += new System.EventHandler(this.BWhite_Click);
            // 
            // BRed
            // 
            this.BRed.BackColor = System.Drawing.Color.Red;
            this.BRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRed.Location = new System.Drawing.Point(39, 3);
            this.BRed.Name = "BRed";
            this.BRed.Size = new System.Drawing.Size(30, 30);
            this.BRed.TabIndex = 1;
            this.BRed.UseVisualStyleBackColor = false;
            this.BRed.Click += new System.EventHandler(this.BWhite_Click);
            // 
            // BYellow
            // 
            this.BYellow.BackColor = System.Drawing.Color.Yellow;
            this.BYellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BYellow.Location = new System.Drawing.Point(75, 3);
            this.BYellow.Name = "BYellow";
            this.BYellow.Size = new System.Drawing.Size(30, 30);
            this.BYellow.TabIndex = 2;
            this.BYellow.UseVisualStyleBackColor = false;
            this.BYellow.Click += new System.EventHandler(this.BWhite_Click);
            // 
            // BOrange
            // 
            this.BOrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BOrange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BOrange.Location = new System.Drawing.Point(111, 3);
            this.BOrange.Name = "BOrange";
            this.BOrange.Size = new System.Drawing.Size(30, 30);
            this.BOrange.TabIndex = 3;
            this.BOrange.UseVisualStyleBackColor = false;
            this.BOrange.Click += new System.EventHandler(this.BWhite_Click);
            // 
            // BGreen
            // 
            this.BGreen.BackColor = System.Drawing.Color.Lime;
            this.BGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGreen.Location = new System.Drawing.Point(147, 3);
            this.BGreen.Name = "BGreen";
            this.BGreen.Size = new System.Drawing.Size(30, 30);
            this.BGreen.TabIndex = 4;
            this.BGreen.UseVisualStyleBackColor = false;
            this.BGreen.Click += new System.EventHandler(this.BWhite_Click);
            // 
            // BBlue
            // 
            this.BBlue.BackColor = System.Drawing.Color.Blue;
            this.BBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBlue.Location = new System.Drawing.Point(3, 39);
            this.BBlue.Name = "BBlue";
            this.BBlue.Size = new System.Drawing.Size(30, 30);
            this.BBlue.TabIndex = 5;
            this.BBlue.UseVisualStyleBackColor = false;
            this.BBlue.Click += new System.EventHandler(this.BWhite_Click);
            // 
            // BBlack
            // 
            this.BBlack.BackColor = System.Drawing.Color.Black;
            this.BBlack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBlack.Location = new System.Drawing.Point(39, 39);
            this.BBlack.Name = "BBlack";
            this.BBlack.Size = new System.Drawing.Size(30, 30);
            this.BBlack.TabIndex = 6;
            this.BBlack.UseVisualStyleBackColor = false;
            this.BBlack.Click += new System.EventHandler(this.BWhite_Click);
            // 
            // BChooseColor
            // 
            this.BChooseColor.BackColor = System.Drawing.Color.White;
            this.BChooseColor.Location = new System.Drawing.Point(75, 39);
            this.BChooseColor.Name = "BChooseColor";
            this.BChooseColor.Size = new System.Drawing.Size(30, 30);
            this.BChooseColor.TabIndex = 7;
            this.BChooseColor.UseVisualStyleBackColor = false;
            this.BChooseColor.Click += new System.EventHandler(this.BChooseColor_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.trackBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 107);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choice of thickness";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar.Location = new System.Drawing.Point(0, 51);
            this.trackBar.Maximum = 20;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(200, 56);
            this.trackBar.TabIndex = 0;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // BSave
            // 
            this.BSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSave.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSave.Location = new System.Drawing.Point(0, 512);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(200, 58);
            this.BSave.TabIndex = 4;
            this.BSave.Text = " Save";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.BClear);
            this.panel2.Controls.Add(this.BSave);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(806, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 570);
            this.panel2.TabIndex = 5;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(0, 196);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox.Size = new System.Drawing.Size(200, 258);
            this.richTextBox.TabIndex = 5;
            this.richTextBox.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Painting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1006, 570);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox);
            this.Name = "Painting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Paint";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Painting_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button BClear;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BWhite;
        private System.Windows.Forms.Button BRed;
        private System.Windows.Forms.Button BYellow;
        private System.Windows.Forms.Button BOrange;
        private System.Windows.Forms.Button BGreen;
        private System.Windows.Forms.Button BBlue;
        private System.Windows.Forms.Button BBlack;
        private System.Windows.Forms.Button BChooseColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}