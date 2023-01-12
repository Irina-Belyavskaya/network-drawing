namespace CLIENT
{
    partial class Connection
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BConnect = new System.Windows.Forms.Button();
            this.BCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBPort = new System.Windows.Forms.TextBox();
            this.TBIPAdress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BConnect
            // 
            this.BConnect.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BConnect.Location = new System.Drawing.Point(67, 252);
            this.BConnect.Name = "BConnect";
            this.BConnect.Size = new System.Drawing.Size(167, 69);
            this.BConnect.TabIndex = 0;
            this.BConnect.Text = "Connect to the ROOM";
            this.BConnect.UseVisualStyleBackColor = true;
            this.BConnect.Click += new System.EventHandler(this.BConnect_Click);
            // 
            // BCreate
            // 
            this.BCreate.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCreate.Location = new System.Drawing.Point(451, 252);
            this.BCreate.Name = "BCreate";
            this.BCreate.Size = new System.Drawing.Size(170, 69);
            this.BCreate.TabIndex = 1;
            this.BCreate.Text = "Create the ROOM";
            this.BCreate.UseVisualStyleBackColor = true;
            this.BCreate.Click += new System.EventHandler(this.BCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Paint with your freinds!";
            // 
            // TBUserName
            // 
            this.TBUserName.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBUserName.Location = new System.Drawing.Point(310, 178);
            this.TBUserName.Name = "TBUserName";
            this.TBUserName.Size = new System.Drawing.Size(175, 31);
            this.TBUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Your name:";
            // 
            // TBPort
            // 
            this.TBPort.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPort.Location = new System.Drawing.Point(310, 141);
            this.TBPort.Name = "TBPort";
            this.TBPort.Size = new System.Drawing.Size(108, 31);
            this.TBPort.TabIndex = 5;
            this.TBPort.Text = "7000";
            // 
            // TBIPAdress
            // 
            this.TBIPAdress.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBIPAdress.Location = new System.Drawing.Point(310, 104);
            this.TBIPAdress.Name = "TBIPAdress";
            this.TBIPAdress.Size = new System.Drawing.Size(175, 31);
            this.TBIPAdress.TabIndex = 6;
            this.TBIPAdress.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(182, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(182, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "IP adress:";
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(695, 344);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBIPAdress);
            this.Controls.Add(this.TBPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BCreate);
            this.Controls.Add(this.BConnect);
            this.Name = "Connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Paint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BConnect;
        private System.Windows.Forms.Button BCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBPort;
        private System.Windows.Forms.TextBox TBIPAdress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

