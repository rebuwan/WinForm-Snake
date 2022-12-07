namespace TheGame
{
    partial class Form1
    {
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GameState_Panel = new System.Windows.Forms.Panel();
            this.Restart_Button = new System.Windows.Forms.Button();
            this.HighScore_Label = new System.Windows.Forms.Label();
            this.Score_Label = new System.Windows.Forms.Label();
            this.GameState_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameState_Panel
            // 
            this.GameState_Panel.BackColor = System.Drawing.Color.Gainsboro;
            this.GameState_Panel.Controls.Add(this.Restart_Button);
            this.GameState_Panel.Controls.Add(this.HighScore_Label);
            this.GameState_Panel.Controls.Add(this.Score_Label);
            this.GameState_Panel.Location = new System.Drawing.Point(12, 21);
            this.GameState_Panel.Name = "GameState_Panel";
            this.GameState_Panel.Size = new System.Drawing.Size(659, 80);
            this.GameState_Panel.TabIndex = 0;
            // 
            // Restart_Button
            // 
            this.Restart_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Restart_Button.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Restart_Button.Location = new System.Drawing.Point(504, 15);
            this.Restart_Button.Margin = new System.Windows.Forms.Padding(15);
            this.Restart_Button.Name = "Restart_Button";
            this.Restart_Button.Size = new System.Drawing.Size(140, 50);
            this.Restart_Button.TabIndex = 2;
            this.Restart_Button.Text = "Yeniden Başla";
            this.Restart_Button.UseVisualStyleBackColor = true;
            this.Restart_Button.Click += new System.EventHandler(this.Restart_Button_Click);
            // 
            // HighScore_Label
            // 
            this.HighScore_Label.AutoSize = true;
            this.HighScore_Label.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HighScore_Label.Location = new System.Drawing.Point(221, 28);
            this.HighScore_Label.Name = "HighScore_Label";
            this.HighScore_Label.Size = new System.Drawing.Size(133, 29);
            this.HighScore_Label.TabIndex = 1;
            this.HighScore_Label.Text = "High Score: ";
            // 
            // Score_Label
            // 
            this.Score_Label.AutoSize = true;
            this.Score_Label.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Score_Label.Location = new System.Drawing.Point(16, 28);
            this.Score_Label.Name = "Score_Label";
            this.Score_Label.Size = new System.Drawing.Size(83, 29);
            this.Score_Label.TabIndex = 0;
            this.Score_Label.Text = "Score: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(683, 860);
            this.Controls.Add(this.GameState_Panel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GameState_Panel.ResumeLayout(false);
            this.GameState_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Panel GameState_Panel;
        private Label Score_Label;
        private Button Restart_Button;
        private Label HighScore_Label;
    }
}