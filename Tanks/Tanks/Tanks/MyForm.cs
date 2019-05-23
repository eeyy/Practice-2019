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
        BulletTankController bulletTankController = new BulletTankController();
        BulletKolController bulletKolController = new BulletKolController();
        PackmanController packmanController = new PackmanController();
        AppleController appleController = new AppleController();
        TankController tankController = new TankController();

        BulletTankView bulletTankView = new BulletTankView();
        BulletKolView bulletKolView = new BulletKolView();
        KolobokView kolobokView = new KolobokView();
        AppleView appleView = new AppleView();
        TankView tankView = new TankView();
        FoneView foneView = new FoneView();

        private Point coordinatesKolobok = Point.Empty;
        private Point[] arrPointsApple = { };
        private Point[] arrPointsHurdles = { };
        private Point[] arrPointsMonolith = { };
        private Point[] arrPointsRiver = { };
        private List<Tank> listTanks = new List<Tank>();
        private List<Bullet> listBulletKolobok = new List<Bullet>();
        private List<Bullet> listBulletTank = new List<Bullet>();
        private int count = 1;
        private FormReport formReport;

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
            formReport = new FormReport();
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
                bulletKolController.CreateKolobokBullet(packmanController.kolobok);
                count *= -1;
            }
            packmanController.KeyDown(keys);
            kolobokView.EditImageKolobok(keys);
            pictureBox1.Image = kolobokView.CreateViewKolobok(coordinatesKolobok, pictureBox1).Image;
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            arrPointsMonolith = packmanController.CreateArrCoordinateMonolith();
            arrPointsHurdles = packmanController.CreateArrCoordinateHurdles();
            arrPointsRiver = packmanController.CreateArrCoordinateRiver();
            pictureBox1.Image = foneView.CreateViewFone(arrPointsHurdles, arrPointsRiver, arrPointsMonolith);


            arrPointsApple = appleController.CreateArrCoordinateApple(arrPointsHurdles, packmanController.kolobok, arrPointsRiver, arrPointsMonolith);
            pictureBox1.Image = appleView.CreateViewApple(arrPointsApple, pictureBox1).Image;
            lbCount.Focus();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            packmanController.GoKolobok();
            coordinatesKolobok = packmanController.GetCoodinateKolobok();

            arrPointsApple = packmanController.CheckEatKolobok(arrPointsApple);//Возвращает новый массив после съедания
            pictureBox1.Image = appleView.RemoveViewApple(packmanController.RemoveApple(), pictureBox1).Image;//удаляет картинку яблока
            arrPointsApple = appleController.AddApple(arrPointsApple, arrPointsHurdles, packmanController.kolobok, arrPointsRiver, arrPointsMonolith);//Добавляет новое яблоко

            pictureBox1.Image = appleView.CreateViewApple(arrPointsApple, pictureBox1).Image;
            pictureBox1.Image = kolobokView.CreateViewKolobok(coordinatesKolobok, pictureBox1).Image;

            ///Танки
            listTanks = tankController.GoTank(arrPointsHurdles, arrPointsRiver, arrPointsMonolith);
            pictureBox1.Image = tankView.CreateViewTank(listTanks, pictureBox1).Image;
            ///

            ///Река
            pictureBox1.Image = foneView.CreateViewObjectMap(new Bitmap(pictureBox1.Image), arrPointsRiver, Resource1.river);
            ///
            
            ///Снаряды колобка
            //pictureBox1.Image = bulletKolController.GoKolobokBullet(arrPointsHurdles, pictureBox1, arrPointsMonolith).Image;
            listBulletKolobok = bulletKolController.GetListKolobokBullet();

            int numberBullet = bulletKolController.GoKolobokBullet(arrPointsHurdles, pictureBox1, arrPointsMonolith);
            if (listBulletKolobok != null & numberBullet != 99)
            {
                pictureBox1.Image = bulletKolView.RemoveViewBullet(listBulletKolobok[numberBullet], pictureBox1).Image;
                listBulletKolobok.RemoveAt(numberBullet);
            }

            pictureBox1.Image = bulletKolView.CreateViewBullet(listBulletKolobok, pictureBox1).Image;//отрисовка движения снаряда


            int numberHurdles = bulletKolController.GetHurdles();
            if (numberHurdles != 0)
            {//почему-то иногда удаляет два блока
                pictureBox1.Image = bulletKolView.BangHurdles(arrPointsHurdles[numberHurdles], pictureBox1).Image;
                List<Point> n = arrPointsHurdles.ToList();
                n.RemoveAt(numberHurdles);
                arrPointsHurdles = n.ToArray();
                packmanController.SetArrCoordinateHurdles(arrPointsHurdles);
            }
            ///

            ///Снаряды танков
            pictureBox1.Image = bulletTankController.GoTankBullet(arrPointsHurdles, pictureBox1, arrPointsMonolith).Image;
            listBulletTank = bulletTankController.GetListTankBullet();
            pictureBox1.Image = bulletTankView.CreateViewBullet(listBulletTank, pictureBox1).Image;
            ///

            

            lbCount.Text = "Count: " + packmanController.kolobok.score.ToString();//Показывает счёт игры
            GC.Collect();//сборщик мусора
            
        }

       

        private void timerForTank_Tick_1(object sender, EventArgs e)
        {
            if (listTanks.Count <= 5)
            tankController.CreateTank(arrPointsHurdles, packmanController.kolobok, arrPointsApple, arrPointsRiver, arrPointsMonolith);
        }

        private void timerForDirecTank_Tick(object sender, EventArgs e)
        {
            tankController.EditDerection();

            listBulletTank = bulletTankController.CreateTankBullet(listTanks);
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
            pictureBox1.Image = bulletKolController.checkAccidentTankToBullet(listTanks, pictureBox1).Image;
            listBulletKolobok = bulletKolController.GetListKolobokBullet();
            //

            if (bulletTankController.checkAccidentBullToKolobok(packmanController.kolobok))
            {
                pictureBox1.Image = kolobokView.GameOver(coordinatesKolobok, pictureBox1).Image;
                timerForWorkProgram.Stop();
            }

            

            formReport.UpdateData(coordinatesKolobok, arrPointsApple, listTanks, listBulletKolobok, listBulletTank);


        }
        
        private void timerForBullet_Tick(object sender, EventArgs e)
        {
            count *= -1;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            timerForWorkProgram.Start();

            //фон
            arrPointsHurdles = packmanController.CreateArrCoordinateHurdles();
            pictureBox1.Image = foneView.CreateViewFone(arrPointsHurdles, arrPointsRiver, arrPointsMonolith);
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
            arrPointsApple = appleController.CreateArrCoordinateApple(arrPointsHurdles, packmanController.kolobok, arrPointsRiver, arrPointsMonolith);
            pictureBox1.Image = appleView.CreateViewApple(arrPointsApple, pictureBox1).Image;
            //

            //танки
            for (int i = 0; i < listTanks.Count; i++)
            {
                pictureBox1.Image = tankView.RemoveViewTank(listTanks[i], pictureBox1).Image;
            }
            listTanks.RemoveRange(0, listTanks.Count);
            if (listTanks.Count <= 5)
                tankController.CreateTank(arrPointsHurdles, packmanController.kolobok, arrPointsApple, arrPointsRiver, arrPointsMonolith);
            //

            //снаряды колобка и танков
            for (int i = 0; i < listBulletKolobok.Count; i++)
            {
                pictureBox1.Image = bulletKolView.RemoveViewBullet(listBulletKolobok[i], pictureBox1).Image;
            }
            listBulletKolobok.RemoveRange(0, listBulletKolobok.Count);

            for (int i = 0; i < listBulletTank.Count; i++)
            {
                pictureBox1.Image = bulletTankView.RemoveViewBullet(listBulletTank[i], pictureBox1).Image;
            }
            listBulletTank.RemoveRange(0, listBulletTank.Count);
            //
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            
            formReport.Show();
        }
    }
}