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
        AppleController appleController = new AppleController();
        TankController tankController = new TankController();
        KolobokView kolobokView = new KolobokView();
        AppleView appleView = new AppleView();
        TankView tankView = new TankView();
        FoneView foneView = new FoneView();
        private Point coordinatesKolobok = Point.Empty;
        private Point coordinatesTank = Point.Empty;
        private Point[] arrPointsApple = { };
        private Point[] arrPointsTank = { };

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

            arrPointsApple = appleController.CreateArrCoordinateApple(packmanController.arrCoordinateHurdles, packmanController.kolobok);
            pictureBox1.Image = appleView.CreateViewApple(arrPointsApple, pictureBox1).Image;

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            packmanController.GoKolobok();
            coordinatesKolobok = packmanController.GetCoodinateKolobok();

            arrPointsApple = packmanController.CheckEatKolobok(arrPointsApple);//Возвращает новый массив после съедания
            pictureBox1.Image = appleView.RemoveViewApple(packmanController.RemoveApple(), pictureBox1).Image;//удаляет картинку яблока
            arrPointsApple = appleController.AddApple(arrPointsApple, packmanController.arrCoordinateHurdles, packmanController.kolobok);//Добавляет новое яблоко

            pictureBox1.Image = appleView.CreateViewApple(arrPointsApple, pictureBox1).Image;
            pictureBox1.Image = kolobokView.CreateViewKolobok(coordinatesKolobok, pictureBox1).Image;
            ///CodeTanks
            arrPointsTank = tankController.GoTank(arrPointsTank, packmanController.arrCoordinateHurdles);
            pictureBox1.Image = tankView.CreateViewTank(arrPointsTank, pictureBox1).Image;
            ////////////
            lbCount.Text = "Count: " + packmanController.kolobok.score.ToString();//Показывает счёт игры
            GC.Collect();//сборщик мусора

        }

        //private void timerForTank_Tick(object sender, EventArgs e)
        //{
        //    lb.Text = "qsadasdasd";
        //    var arrToList = new List<Point>(arrPointsTank);
        //    arrToList.Add(tankController.CreateTank(packmanController.arrCoordinateHurdles, packmanController.kolobok, arrPointsApple, arrPointsTank));
        //    arrPointsTank = arrToList.ToArray();

        //    pictureBox1.Image = tankView.CreateViewTank(arrPointsTank, pictureBox1).Image;
        //}

        private void timerForTank_Tick_1(object sender, EventArgs e)
        {
            var arrToList = new List<Point>(arrPointsTank);
            arrToList.Add(tankController.CreateTank(packmanController.arrCoordinateHurdles, packmanController.kolobok, arrPointsApple, arrPointsTank));
            arrPointsTank = arrToList.ToArray();
            
        }
    }
}
