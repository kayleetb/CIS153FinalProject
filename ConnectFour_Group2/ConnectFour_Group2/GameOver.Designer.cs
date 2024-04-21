namespace ConnectFour_Group2
{
    partial class GameOver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOver));
            this.lbl_gameOutCome = new System.Windows.Forms.Label();
            this.btn_playAgain = new System.Windows.Forms.Button();
            this.btn_reviewGame = new System.Windows.Forms.Button();
            this.btn_StatsGO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_gameOutCome
            // 
            this.lbl_gameOutCome.AutoSize = true;
            this.lbl_gameOutCome.Location = new System.Drawing.Point(374, 97);
            this.lbl_gameOutCome.Name = "lbl_gameOutCome";
            this.lbl_gameOutCome.Size = new System.Drawing.Size(51, 20);
            this.lbl_gameOutCome.TabIndex = 0;
            this.lbl_gameOutCome.Text = "label1";
            // 
            // btn_playAgain
            // 
            this.btn_playAgain.Location = new System.Drawing.Point(306, 297);
            this.btn_playAgain.Name = "btn_playAgain";
            this.btn_playAgain.Size = new System.Drawing.Size(194, 123);
            this.btn_playAgain.TabIndex = 1;
            this.btn_playAgain.Text = "Play Again";
            this.btn_playAgain.UseVisualStyleBackColor = true;
            this.btn_playAgain.Click += new System.EventHandler(this.btn_playAgain_Click);
            // 
            // btn_reviewGame
            // 
            this.btn_reviewGame.Location = new System.Drawing.Point(528, 297);
            this.btn_reviewGame.Name = "btn_reviewGame";
            this.btn_reviewGame.Size = new System.Drawing.Size(194, 123);
            this.btn_reviewGame.TabIndex = 2;
            this.btn_reviewGame.Text = "Review Game";
            this.btn_reviewGame.UseVisualStyleBackColor = true;
            this.btn_reviewGame.Click += new System.EventHandler(this.btn_reviewGame_Click);
            // 
            // btn_StatsGO
            // 
            this.btn_StatsGO.Location = new System.Drawing.Point(81, 297);
            this.btn_StatsGO.Name = "btn_StatsGO";
            this.btn_StatsGO.Size = new System.Drawing.Size(194, 123);
            this.btn_StatsGO.TabIndex = 3;
            this.btn_StatsGO.Text = "Game Statistics";
            this.btn_StatsGO.UseVisualStyleBackColor = true;
            this.btn_StatsGO.Click += new System.EventHandler(this.btn_StatsGO_Click);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 477);
            this.Controls.Add(this.btn_StatsGO);
            this.Controls.Add(this.btn_reviewGame);
            this.Controls.Add(this.btn_playAgain);
            this.Controls.Add(this.lbl_gameOutCome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameOver";
            this.Text = "GameOver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameOver_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_gameOutCome;
        private System.Windows.Forms.Button btn_playAgain;
        private System.Windows.Forms.Button btn_reviewGame;
        private System.Windows.Forms.Button btn_StatsGO;
    }
}