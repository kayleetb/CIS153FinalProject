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
            this.btn_singlePlayer = new System.Windows.Forms.Button();
            this.btn_twoPlayer = new System.Windows.Forms.Button();
            this.btn_Stats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_singlePlayer
            // 
            this.btn_singlePlayer.Location = new System.Drawing.Point(173, 422);
            this.btn_singlePlayer.Name = "btn_singlePlayer";
            this.btn_singlePlayer.Size = new System.Drawing.Size(127, 73);
            this.btn_singlePlayer.TabIndex = 0;
            this.btn_singlePlayer.Text = "Single Player";
            this.btn_singlePlayer.UseVisualStyleBackColor = true;
            this.btn_singlePlayer.Click += new System.EventHandler(this.btn_singlePlayer_Click);
            // 
            // btn_twoPlayer
            // 
            this.btn_twoPlayer.Location = new System.Drawing.Point(357, 422);
            this.btn_twoPlayer.Name = "btn_twoPlayer";
            this.btn_twoPlayer.Size = new System.Drawing.Size(127, 73);
            this.btn_twoPlayer.TabIndex = 1;
            this.btn_twoPlayer.Text = "Two Player";
            this.btn_twoPlayer.UseVisualStyleBackColor = true;
            this.btn_twoPlayer.Click += new System.EventHandler(this.btn_twoPlayer_Click);
            // 
            // btn_Stats
            // 
            this.btn_Stats.Location = new System.Drawing.Point(536, 422);
            this.btn_Stats.Name = "btn_Stats";
            this.btn_Stats.Size = new System.Drawing.Size(132, 69);
            this.btn_Stats.TabIndex = 2;
            this.btn_Stats.Text = "Game Statistics";
            this.btn_Stats.UseVisualStyleBackColor = true;
            this.btn_Stats.Click += new System.EventHandler(this.btn_Stats_Click);
            // 
            // WelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 623);
            this.Controls.Add(this.btn_Stats);
            this.Controls.Add(this.btn_twoPlayer);
            this.Controls.Add(this.btn_singlePlayer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to Connect Four";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_singlePlayer;
        private System.Windows.Forms.Button btn_twoPlayer;
        private System.Windows.Forms.Button btn_Stats;
    }
}

