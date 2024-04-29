namespace ConnectFour_Group2
{
    partial class WelcomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomePage));
            this.btn_singlePlayer = new System.Windows.Forms.Button();
            this.btn_twoPlayer = new System.Windows.Forms.Button();
            this.btn_Stats = new System.Windows.Forms.Button();
            this.lbl_ConnectFour = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_singlePlayer
            // 
            this.btn_singlePlayer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_singlePlayer.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_singlePlayer.Location = new System.Drawing.Point(139, 351);
            this.btn_singlePlayer.Name = "btn_singlePlayer";
            this.btn_singlePlayer.Size = new System.Drawing.Size(174, 96);
            this.btn_singlePlayer.TabIndex = 0;
            this.btn_singlePlayer.Text = "Single Player";
            this.btn_singlePlayer.UseVisualStyleBackColor = false;
            this.btn_singlePlayer.Click += new System.EventHandler(this.btn_singlePlayer_Click);
            // 
            // btn_twoPlayer
            // 
            this.btn_twoPlayer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_twoPlayer.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_twoPlayer.Location = new System.Drawing.Point(344, 351);
            this.btn_twoPlayer.Name = "btn_twoPlayer";
            this.btn_twoPlayer.Size = new System.Drawing.Size(174, 96);
            this.btn_twoPlayer.TabIndex = 1;
            this.btn_twoPlayer.Text = "Two Player";
            this.btn_twoPlayer.UseVisualStyleBackColor = false;
            this.btn_twoPlayer.Click += new System.EventHandler(this.btn_twoPlayer_Click);
            // 
            // btn_Stats
            // 
            this.btn_Stats.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_Stats.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Stats.Location = new System.Drawing.Point(552, 351);
            this.btn_Stats.Name = "btn_Stats";
            this.btn_Stats.Size = new System.Drawing.Size(174, 96);
            this.btn_Stats.TabIndex = 2;
            this.btn_Stats.Text = "Game Statistics";
            this.btn_Stats.UseVisualStyleBackColor = false;
            this.btn_Stats.Click += new System.EventHandler(this.btn_Stats_Click);
            // 
            // lbl_ConnectFour
            // 
            this.lbl_ConnectFour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_ConnectFour.AutoSize = true;
            this.lbl_ConnectFour.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ConnectFour.Font = new System.Drawing.Font("Franklin Gothic Medium", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ConnectFour.ForeColor = System.Drawing.Color.Black;
            this.lbl_ConnectFour.Location = new System.Drawing.Point(45, 181);
            this.lbl_ConnectFour.Name = "lbl_ConnectFour";
            this.lbl_ConnectFour.Size = new System.Drawing.Size(783, 101);
            this.lbl_ConnectFour.TabIndex = 3;
            this.lbl_ConnectFour.Text = "C O N N E C T  F O U R";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ConnectFour_Group2.Properties.Resources.redconnectfourpiece;
            this.pictureBox1.Location = new System.Drawing.Point(125, 196);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ConnectFour_Group2.Properties.Resources.yellowconnectfourpiece;
            this.pictureBox2.Location = new System.Drawing.Point(617, 196);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 73);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // WelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConnectFour_Group2.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(871, 570);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_ConnectFour);
            this.Controls.Add(this.btn_Stats);
            this.Controls.Add(this.btn_twoPlayer);
            this.Controls.Add(this.btn_singlePlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_singlePlayer;
        private System.Windows.Forms.Button btn_twoPlayer;
        private System.Windows.Forms.Button btn_Stats;
        private System.Windows.Forms.Label lbl_ConnectFour;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

