using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class MyForm : Form
    {
        PackmanController packmanController = new PackmanController();
        BulletController bulletController = new BulletController();
        AppleController appleController = new AppleController();
        TankController tankController = new TankController();

        KolobokView kolobokView = new KolobokView();
        BulletView bulletView = new BulletView();
        AppleView appleView = new AppleView();
        TankView tankView = new TankView();
        FoneView foneView = new FoneView();

        private Point coordinatesKolobok = Point.Empty;
        private Point coordinatesTank = Point.Empty;
        private Point[] arrPointsApple = { };
        private Point[] arrPointsHurdles = { };
        private List<Tank> listTanks = new List<Tank>();
        private List<Bullet> listBullet = new List<Bullet>();
        private int count = 1;

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
            btnNewGame.PreviewKeyDown += new PreviewKeyDownEventHandler(btnNewGame_PreviewKeyDown);
            btnNewGame.KeyDown += new KeyEventHandler(btnNewGame_KeyDown);
            
        }

        private void btnNewGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Right:
                case Keys.Left:
                case Keys.NumPad0:
                    e.IsInputKey = true;
                    break;
            }
        }

        void btnNewGame_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.NumPad0:
                    MyForm_KeyDown(e.KeyCode);
                    break;
            }
        }

       


        private void MyForm_KeyDown(Keys keys)
        {
            
            if (keys == Keys.NumPad0 & count == 1)
            {
                bulletController.CreateBullet(packmanController.kolobok);
                count *= -1;
            }
            packmanController.KeyDown(keys);
            kolobokView.EditImageKolobok(keys);
            pictureBox1.Image = kolobokView.CreateViewKolobok(coordinatesKolobok, pictureBox1).Image;
        }











        private void Form1_Load(object sender, EventArgs e)
        {
           

            arrPointsHurdles = packmanController.CreateArrCoordinateHurdles();
            pictureBox1.Image = foneView.CreateViewFone(arrPointsHurdles);

            arrPointsApple = appleController.CreateArrCoordinateApple(packmanController.arrCoordinateHurdles, packmanController.kolobok);
            pictureBox1.Image = appleView.CreateViewApple(arrPointsApple, pictureBox1).Image;
            lbCount.Focus();
           
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
            ///Танки
            listTanks = tankController.GoTank(packmanController.arrCoordinateHurdles);
            pictureBox1.Image = tankView.CreateViewTank(listTanks, pictureBox1).Image;
            ///

            ///Снаряды колобка
            pictureBox1.Image = bulletController.GoBullet(packmanController.arrCoordinateHurdles, pictureBox1).Image;
            listBullet = bulletController.GetListBullet();
            pictureBox1.Image = bulletView.CreateViewBullet(listBullet, pictureBox1).Image;
            ///
            lbCount.Text = "Count: " + packmanController.kolobok.score.ToString();//Показывает счёт игры
            GC.Collect();//сборщик мусора
            
        }

       

        private void timerForTank_Tick_1(object sender, EventArgs e)
        {
            if (listTanks.Count <= 5)
            tankController.CreateTank(packmanController.arrCoordinateHurdles, packmanController.kolobok, arrPointsApple);
        }

        private void timerForDirecTank_Tick(object sender, EventArgs e)
        {
            tankController.EditDerection();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            tankController.checkAccidentTankToTank();
            if (tankController.checkAccidentTankToKolobok(packmanController.kolobok))
            {
                pictureBox1.Image = kolobokView.GameOver(coordinatesKolobok, pictureBox1).Image;
                timerForWorkProgram.Stop();
            }
            //
            pictureBox1.Image = bulletController.checkAccidentTankToBullet(listTanks, pictureBox1).Image;
            listBullet = bulletController.GetListBullet();
            //

        }

        private void timerForBullet_Tick(object sender, EventArgs e)
        {
            count *= -1;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            timerForWorkProgram.Start();

            //фон
            pictureBox1.Image = foneView.CreateViewFone(arrPointsHurdles);
            //

            //колобок
            pictureBox1.Image = kolobokView.ResetViewKolobok(coordinatesKolobok, pictureBox1).Image;
            packmanController.ResetKolobok();
            kolobokView.EditImageKolobok(Keys.Right);
            direction = "RIGHT";
            //

            //яблоки
            for (int i = 0; i < arrPointsApple.Length; i++)
            {
                pictureBox1.Image = appleView.RemoveViewApple(arrPointsApple[i], pictureBox1).Image;
            }
            arrPointsApple = appleController.CreateArrCoordinateApple(packmanController.arrCoordinateHurdles, packmanController.kolobok);
            pictureBox1.Image = appleView.CreateViewApple(arrPointsApple, pictureBox1).Image;
            //

            //танки
            for (int i = 0; i < listTanks.Count; i++)
            {
                pictureBox1.Image = tankView.RemoveViewTank(listTanks[i], pictureBox1).Image;
            }
            listTanks.RemoveRange(0, listTanks.Count);
            if (listTanks.Count <= 5)
                tankController.CreateTank(packmanController.arrCoordinateHurdles, packmanController.kolobok, arrPointsApple);
            //

            //снаряды
            for (int i = 0; i < listBullet.Count; i++)
            {
                pictureBox1.Image = bulletView.RemoveViewBullet(listBullet[i], pictureBox1).Image;
            }
            listBullet.RemoveRange(0, listBullet.Count);
            //
        }
    }
}