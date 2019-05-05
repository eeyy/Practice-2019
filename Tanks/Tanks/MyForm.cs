using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            CreateBitmapAtRuntime();
            button1.PreviewKeyDown += new PreviewKeyDownEventHandler(button1_PreviewKeyDown);
            button1.KeyDown += new KeyEventHandler(button1_KeyDown);
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }

        void button1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    MyForm_KeyDown(e.KeyCode);
                    break;
                case Keys.Up:
                    MyForm_KeyDown();
                    break;
                case Keys.Right:
                    MyForm_KeyDown();
                    break;
                case Keys.Left:
                    MyForm_KeyDown();
                    break;
            }
        }


        public void CreateBitmapAtRuntime()
        {
            pictureBox1.Size = new Size(210, 110);
            this.Controls.Add(pictureBox1);

            Bitmap flag = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int red = 0;
            int white = 11;
            while (white <= 100)
            {
                flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }

            pictureBox1.Image = flag;

        }
        public int j = 10; 
        private void MyForm_KeyDown() 
        {
                Bitmap flag = new Bitmap(200, 100);
                Graphics flagGraphics = Graphics.FromImage(flag);
                flagGraphics.FillRectangle(Brushes.Blue, 20, j, 20, 20);
                j += 1;
                pictureBox1.Image = flag;
        }
    }
}