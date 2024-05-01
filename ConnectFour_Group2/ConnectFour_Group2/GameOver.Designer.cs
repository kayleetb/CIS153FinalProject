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
            this.lbl_gameOutcome = new System.Windows.Forms.Label();
            this.btn_playAgain = new System.Windows.Forms.Button();
            this.btn_reviewGame = new System.Windows.Forms.Button();
            this.btn_StatsGO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_gameOutcome
            // 
            this.lbl_gameOutcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_gameOutcome.AutoSize = true;
            this.lbl_gameOutcome.BackColor = System.Drawing.Color.ForestGreen;
            this.lbl_gameOutcome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_gameOutcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_gameOutcome.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gameOutcome.ForeColor = System.Drawing.Color.White;
            this.lbl_gameOutcome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_gameOutcome.Location = new System.Drawing.Point(184, 159);
            this.lbl_gameOutcome.Name = "lbl_gameOutcome";
            this.lbl_gameOutcome.Size = new System.Drawing.Size(519, 49);
            this.lbl_gameOutcome.TabIndex = 0;
            this.lbl_gameOutcome.Text = "    P L A Y E R  \"\"  W O N !     ";
            this.lbl_gameOutcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_playAgain
            // 
            this.btn_playAgain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_playAgain.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_playAgain.Location = new System.Drawing.Point(317, 294);
            this.btn_playAgain.Name = "btn_playAgain";
            this.btn_playAgain.Size = new System.Drawing.Size(176, 98);
            this.btn_playAgain.TabIndex = 1;
            this.btn_playAgain.Text = "Play Again";
            this.btn_playAgain.UseVisualStyleBackColor = false;
            this.btn_playAgain.Click += new System.EventHandler(this.btn_playAgain_Click);
            // 
            // btn_reviewGame
            // 
            this.btn_reviewGame.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_reviewGame.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reviewGame.Location = new System.Drawing.Point(539, 294);
            this.btn_reviewGame.Name = "btn_reviewGame";
            this.btn_reviewGame.Size = new System.Drawing.Size(176, 98);
            this.btn_reviewGame.TabIndex = 2;
            this.btn_reviewGame.Text = "Review Game";
            this.btn_reviewGame.UseVisualStyleBackColor = false;
            this.btn_reviewGame.Click += new System.EventHandler(this.btn_reviewGame_Click);
            // 
            // btn_StatsGO
            // 
            this.btn_StatsGO.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_StatsGO.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StatsGO.Location = new System.Drawing.Point(92, 294);
            this.btn_StatsGO.Name = "btn_StatsGO";
            this.btn_StatsGO.Size = new System.Drawing.Size(176, 98);
            this.btn_StatsGO.TabIndex = 3;
            this.btn_StatsGO.Text = "Game Statistics";
            this.btn_StatsGO.UseVisualStyleBackColor = false;
            this.btn_StatsGO.Click += new System.EventHandler(this.btn_StatsGO_Click);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::ConnectFour_Group2.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(815, 510);
            this.Controls.Add(this.btn_StatsGO);
            this.Controls.Add(this.btn_reviewGame);
            this.Controls.Add(this.btn_playAgain);
            this.Controls.Add(this.lbl_gameOutcome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Game Over";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_gameOutcome;
        private System.Windows.Forms.Button btn_playAgain;
        private System.Windows.Forms.Button btn_reviewGame;
        private System.Windows.Forms.Button btn_StatsGO;
    }
}