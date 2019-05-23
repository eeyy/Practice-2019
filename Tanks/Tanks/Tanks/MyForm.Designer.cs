namespace Tanks
{
    partial class MyForm
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.timerForWorkProgram = new System.Windows.Forms.Timer(this.components);
            this.lbCount = new System.Windows.Forms.Label();
            this.timerForCreateTank = new System.Windows.Forms.Timer(this.components);
            this.timerForDirecTank = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerForBullet = new System.Windows.Forms.Timer(this.components);
            this.btnShowReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1082, 936);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.CausesValidation = false;
            this.btnNewGame.Location = new System.Drawing.Point(500, 1033);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(107, 36);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // timerForWorkProgram
            // 
            this.timerForWorkProgram.Enabled = true;
            this.timerForWorkProgram.Interval = 30;
            this.timerForWorkProgram.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(34, 1033);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(52, 20);
            this.lbCount.TabIndex = 2;
            this.lbCount.Text = "Count";
            // 
            // timerForCreateTank
            // 
            this.timerForCreateTank.Enabled = true;
            this.timerForCreateTank.Interval = 2000;
            this.timerForCreateTank.Tick += new System.EventHandler(this.timerForTank_Tick_1);
            // 
            // timerForDirecTank
            // 
            this.timerForDirecTank.Enabled = true;
            this.timerForDirecTank.Interval = 600;
            this.timerForDirecTank.Tick += new System.EventHandler(this.timerForDirecTank_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timerForBullet
            // 
            this.timerForBullet.Enabled = true;
            this.timerForBullet.Interval = 1000;
            this.timerForBullet.Tick += new System.EventHandler(this.timerForBullet_Tick);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(959, 1033);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(116, 36);
            this.btnShowReport.TabIndex = 3;
            this.btnShowReport.Text = "Show report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 1104);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MyForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Timer timerForWorkProgram;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Timer timerForCreateTank;
        private System.Windows.Forms.Timer timerForDirecTank;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerForBullet;
        private System.Windows.Forms.Button btnShowReport;
    }
}

