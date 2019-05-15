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
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }


        private int KolobokCount = 0;
        private int AppleCount = 0;
        private int TankCount = 0;
        private int BulletColCount = 0;
        private int BulletTankCount = 0;
        private int row = 0;


        
        public void UpdateData(Point coordinatesKolobok, Point[] arrPointsApple, List<Tank> listTanks, List<Bullet> listBulletKolobok, List<Bullet> listBulletTank)
        {
            if (coordinatesKolobok != null)
                KolobokCount = 1;
            if (arrPointsApple != null)
                AppleCount = arrPointsApple.Length;
            if (listTanks != null)
                TankCount = listTanks.Count;
            if (listBulletKolobok != null)
                BulletColCount = listBulletKolobok.Count;
            if (listBulletTank != null)
                BulletTankCount = listBulletTank.Count;

            int N = 1, M = 3;
            for (int i = 0; i <= AppleCount + TankCount + BulletColCount + BulletTankCount; i++)
            {
                N++;
            }

            dataGridView1.RowCount = N;
            dataGridView1.ColumnCount = M;

            UpdateKolobok(coordinatesKolobok);
            UpdateApple(arrPointsApple);
            UpdateTanks(listTanks);
            UpdateBullet(listBulletKolobok);
            if (listBulletTank != null)
                UpdateBullet(listBulletTank);
            row = 0;
        }

       


        private void UpdateKolobok(Point coordinatesKolobok)
        {
            for (int i = row; i < KolobokCount; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (j == 0)
                        dataGridView1.Rows[i].Cells[j].Value = "Kolobok";
                    else
                    if (j == 1)
                        dataGridView1.Rows[i].Cells[j].Value = coordinatesKolobok.X;
                    else
                        dataGridView1.Rows[i].Cells[j].Value = coordinatesKolobok.Y;
                }
            }
            row++;
        }

        private void UpdateApple(Point[] arrPointsApple)
        {
            for (int i = row; i < row + AppleCount; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (j == 0)
                        dataGridView1.Rows[i].Cells[j].Value = "Apple";
                    else
                    if (j == 1)
                        dataGridView1.Rows[i].Cells[j].Value = arrPointsApple[i - row].X;
                    else
                        dataGridView1.Rows[i].Cells[j].Value = arrPointsApple[i - row].Y;
                }
                
            }
            row += AppleCount;
        }

        private void UpdateTanks(List<Tank> listTanks)
        {
            for (int i = row; i < row + TankCount; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (j == 0)
                        dataGridView1.Rows[i].Cells[j].Value = "Tank";
                    else
                    if (j == 1)
                        dataGridView1.Rows[i].Cells[j].Value = listTanks[i - row].x;
                    else
                        dataGridView1.Rows[i].Cells[j].Value = listTanks[i - row].y;
                }
                
            }
            row += TankCount;
        }

        private void UpdateBullet(List<Bullet> listBullet)
        {
            for (int i = row; i < row + listBullet.Count; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (j == 0)
                        dataGridView1.Rows[i].Cells[j].Value = "Bullet";
                    else
                    if (j == 1)
                        dataGridView1.Rows[i].Cells[j].Value = listBullet[i - row].x;
                    else
                        dataGridView1.Rows[i].Cells[j].Value = listBullet[i - row].y;
                }
                
            }
            row += listBullet.Count;
        }
    }
}
