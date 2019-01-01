namespace PokerGameClient
{
    partial class MainClientForm
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
            this.lBGameRooms = new System.Windows.Forms.ListBox();
            this.tBUserName = new System.Windows.Forms.TextBox();
            this.bLogin = new System.Windows.Forms.Button();
            this.lbRoomPlayers = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bReady = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lBGameRooms
            // 
            this.lBGameRooms.FormattingEnabled = true;
            this.lBGameRooms.Location = new System.Drawing.Point(150, 94);
            this.lBGameRooms.Name = "lBGameRooms";
            this.lBGameRooms.Size = new System.Drawing.Size(129, 95);
            this.lBGameRooms.TabIndex = 0;
            // 
            // tBUserName
            // 
            this.tBUserName.Location = new System.Drawing.Point(12, 123);
            this.tBUserName.Name = "tBUserName";
            this.tBUserName.Size = new System.Drawing.Size(100, 20);
            this.tBUserName.TabIndex = 1;
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(25, 149);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(75, 23);
            this.bLogin.TabIndex = 2;
            this.bLogin.Text = "Login";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.Login_Click);
            // 
            // lbRoomPlayers
            // 
            this.lbRoomPlayers.FormattingEnabled = true;
            this.lbRoomPlayers.Location = new System.Drawing.Point(285, 94);
            this.lbRoomPlayers.Name = "lbRoomPlayers";
            this.lbRoomPlayers.Size = new System.Drawing.Size(120, 95);
            this.lbRoomPlayers.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bReady
            // 
            this.bReady.Location = new System.Drawing.Point(294, 195);
            this.bReady.Name = "bReady";
            this.bReady.Size = new System.Drawing.Size(75, 23);
            this.bReady.TabIndex = 5;
            this.bReady.Text = "Ready";
            this.bReady.UseVisualStyleBackColor = true;
            this.bReady.Click += new System.EventHandler(this.Ready_Click);
            // 
            // MainClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bReady);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbRoomPlayers);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.tBUserName);
            this.Controls.Add(this.lBGameRooms);
            this.Name = "MainClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lBGameRooms;
        private System.Windows.Forms.TextBox tBUserName;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.ListBox lbRoomPlayers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bReady;
    }
}

