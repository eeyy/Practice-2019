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
            this.button1 = new System.Windows.Forms.Button();
            this.timerForWorkProgram = new System.Windows.Forms.Timer(this.components);
            this.lbCount = new System.Windows.Forms.Label();
            this.timerForTank = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1082, 913);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, 952);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = true;
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
            this.lbCount.Location = new System.Drawing.Point(34, 952);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(52, 20);
            this.lbCount.TabIndex = 2;
            this.lbCount.Text = "Count";
            // 
            // timerForTank
            // 
            this.timerForTank.Enabled = true;
            this.timerForTank.Interval = 2000;
            this.timerForTank.Tick += new System.EventHandler(this.timerForTank_Tick_1);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 1009);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerForWorkProgram;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Timer timerForTank;
    }
}

