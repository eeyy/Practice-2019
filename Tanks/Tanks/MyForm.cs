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
        PackmanController packmanController = new PackmanController();
        KolobokView kolobokView = new KolobokView();
        FoneView foneView = new FoneView();
        AppleView appleView = new AppleView();
        private Point coordinatesKolobok = Point.Empty;

        private string direction = "RIGHT";
        private string[] arrDirection =
        {
            "UP",
            "DOWN",
            "LEFT",
            "RIGHT"
        };

        public MyForm()
        {
            InitializeComponent();
            button1.PreviewKeyDown += new PreviewKeyDownEventHandler(button1_PreviewKeyDown);
            button1.KeyDown += new KeyEventHandler(button1_KeyDown);
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Right:
                case Keys.Left:
                    e.IsInputKey = true;
                    break;
            }
        }

        void button1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (direction != arrDirection[1])
                    {
                        direction = arrDirection[1];
                        MyForm_KeyDown(e.KeyCode);
                    }
                    break;
                case Keys.Up:
                    if (direction != arrDirection[0])
                    {
                        direction = arrDirection[0];
                        MyForm_KeyDown(e.KeyCode);
                    }
                    break;
                case Keys.Right:
                    if (direction != arrDirection[3])
                    {
                        direction = arrDirection[3];
                        MyForm_KeyDown(e.KeyCode);
                    }
                    break;
                case Keys.Left:
                    if (direction != arrDirection[2])
                    {
                        direction = arrDirection[2];
                        MyForm_KeyDown(e.KeyCode);
                    }
                    break;
            }
        }


        private void MyForm_KeyDown(Keys keys)
        {
            packmanController.KeyDown(keys);
            kolobokView.EditImage(keys);
            pictureBox1.Image = kolobokView.CreateViewKolobok(coordinatesKolobok, pictureBox1).Image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            

            Point[] arrPointsHurdles = packmanController.CreateArrCoordinateHurdles();
            pictureBox1.Image = foneView.CreateViewFone(arrPointsHurdles);

            Point[] arrPointsApple = packmanController.CreateArrCoordinateApple();
            pictureBox1.Image = appleView.CreateViewApple(arrPointsApple, pictureBox1).Image;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            packmanController.GoKolobok();
            coordinatesKolobok = packmanController.GetCoodinateKolobok();
            pictureBox1.Image = kolobokView.CreateViewKolobok(coordinatesKolobok, pictureBox1).Image;
            GC.Collect();//сборщик мусора
        }
    }
}
