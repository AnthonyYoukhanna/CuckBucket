using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Grid SweepGrid;
        bool PuusyBoi;
        bool UgandanKnuckles;

        public Form1()
        {
            InitializeComponent();
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SweepGrid = new Grid(9, 9, 30);
            SweepGrid.Draw(g, 0, 30);
            PuusyBoi = true;
            UgandanKnuckles = false;
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SweepGrid = new Grid(16, 16, 30);
            SweepGrid.Draw(g, 0, 30);
            UgandanKnuckles = true;
            PuusyBoi = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (SweepGrid != null)
            {
                Graphics g = this.CreateGraphics();
                SweepGrid.Draw(g, 0, 30);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {   

                //finding out what cell is clicked
                int X = (e.X) / 30;
                int Y = (e.Y) / 30;

                //if clicked outside grid, roast whoever did that
                if (PuusyBoi == true)
                {
                    if (Y < 0 | Y > 8 | X < 0 | X > 8)
                    {
                        MessageBox.Show("stop doing shit u monkey");
                    }
                    else
                    {
                        //Change(Y, X);
                        ClearSpace(Y, X);
                        this.Refresh();
                    }


                }





                if (UgandanKnuckles == true)
                {
                    if (Y < 0 | Y > 15 | X < 0 | X > 15)
                    {
                        MessageBox.Show("stop doing shit u monkey");
                    }
                    else
                    {
                        //Change(Y, X);
                        ClearSpace(Y, X);
                        this.Refresh();
                    }
                }
            }
        }

    //    ///////////////////////////////////////////////////////////////////////////////////////
    //    public void Fuck(int i, int j)
    //    {

    //        //change image
    //        if (SweepGrid.GetTile(i, j).BombCount == 1)
    //        {
    //            SweepGrid.GetTile(i, j).BackgroundColour = Resource1._76px_Minesweeper_1_svg;
    //        }
    //        if (SweepGrid.GetTile(i, j).BombCount == 2)
    //        {
    //            SweepGrid.GetTile(i, j).BackgroundColour = Resource1._76px_Minesweeper_2_svg;
    //        }
    //        if (SweepGrid.GetTile(i, j).BombCount == 3)
    //        {
    //            SweepGrid.GetTile(i, j).BackgroundColour = Resource1._76px_Minesweeper_3_svg;
    //        }
    //        if (SweepGrid.GetTile(i, j).BombCount == 4)
    //        {
    //            SweepGrid.GetTile(i, j).BackgroundColour = Resource1.Minesweeper_4_svg;
    //        }
    //        if (SweepGrid.GetTile(i, j).BombCount == 5)
    //        {
    //            SweepGrid.GetTile(i, j).BackgroundColour = Resource1._76px_Minesweeper_5_svg;
    //        }
    //        if (SweepGrid.GetTile(i, j).BombCount == 6)
    //        {
    //            SweepGrid.GetTile(i, j).BackgroundColour = Resource1._76px_Minesweeper_6_svg;
    //        }
    //        if (SweepGrid.GetTile(i, j).BombCount == 7)
    //        {
    //            SweepGrid.GetTile(i, j).BackgroundColour = Resource1._76px_Minesweeper_7_svg;
    //        }
    //        if (SweepGrid.GetTile(i, j).BombCount == 8)
    //        {
    //            SweepGrid.GetTile(i, j).BackgroundColour = Resource1._76px_Minesweeper_8_svg;
    //        }


    //    }

    ///// ////////////////////////////////////////////////////////////////////
    //    public int Change(int i, int j)
    //    {
    //        if (i < 0 || j < 0 || i >= 9 || j >= 9)
    //        {
    //            return SweepGrid.GetTile(i, j).BombCount;
    //        }
    //        if (SweepGrid.GetTile(i,j).Bomb == true)
    //        {
    //            return 0;
    //        }
    //        if (SweepGrid.GetTile(i, j).BackgroundColour == Resource1._76px_Minesweeper_0_svg)
    //        {
    //            if (SweepGrid.GetTile(i + 1, j).BackgroundColour == Resource1.Bomb)
    //            {
    //                return SweepGrid.GetTile(i, j).BombCount++;
    //            }
    //            if (SweepGrid.GetTile(i + 1, j + 1).BackgroundColour == Resource1.Bomb)
    //            {
    //                return SweepGrid.GetTile(i, j).BombCount++;
    //            }
    //            if (SweepGrid.GetTile(i + 1, j - 1).BackgroundColour == Resource1.Bomb)
    //            {
    //                return SweepGrid.GetTile(i, j).BombCount++;
    //            }
    //            if (SweepGrid.GetTile(i - 1, j).BackgroundColour == Resource1.Bomb)
    //            {
    //                return SweepGrid.GetTile(i, j).BombCount++;
    //            }
    //            if (SweepGrid.GetTile(i - 1, j + 1).BackgroundColour == Resource1.Bomb)
    //            {
    //                return SweepGrid.GetTile(i, j).BombCount++;
    //            }
    //            if (SweepGrid.GetTile(i - 1, j - 1).BackgroundColour == Resource1.Bomb)
    //            {
    //                return SweepGrid.GetTile(i, j).BombCount++;
    //            }
    //            if (SweepGrid.GetTile(i, j + 1).BackgroundColour == Resource1.Bomb)
    //            {
    //                return SweepGrid.GetTile(i, j).BombCount++;
    //            }
    //            if (SweepGrid.GetTile(i, j - 1).BackgroundColour == Resource1.Bomb)
    //            {
    //                return SweepGrid.GetTile(i, j).BombCount++;
    //            }
    //            Fuck(i, j);
    //        }

          
    //            return 0;
               
        
    //    }
       
        public void ClearSpace(int r, int c)
        {
            ////////////////////////////////////////////////////
            //Easy
            if (PuusyBoi == true)
            {
                if (r < 0 || c < 0 || r >= 9 || c >= 9)
                {
                    return;
                }
                if (SweepGrid.GetTile(r, c).Click == true)
                {
                    return;
                }

                if (SweepGrid.GetTile(r, c).Click == false)
                {
                    SweepGrid.GetTile(r, c).ForegroundColour = SweepGrid.GetTile(r, c).BackgroundColour;
                    
                    SweepGrid.GetTile(r, c).Click = true;
                    //Change image here

                    ClearSpace(r + 1, c);    //up

                    ClearSpace(r, c + 1);    //right

                    ClearSpace(r - 1, c);    //down

                    ClearSpace(r, c - 1);    //left

                    

                    
                }
                return;
            }

            ////////////////////////////////////////////////////
            //Intermediate Difficulty

            if (UgandanKnuckles == true)
            {
                if (r < 0 || c < 0 || r >= 16 || c >= 16)
                {
                    return;
                }
                if (SweepGrid.GetTile(r, c).Click == true)
                {
                    return;
                }

                if (SweepGrid.GetTile(r, c).Click == false)
                {
                    SweepGrid.GetTile(r, c).ForegroundColour = SweepGrid.GetTile(r, c).BackgroundColour;

                    SweepGrid.GetTile(r, c).Click = true;
                    //Change image here

                    ClearSpace(r + 1, c);    //up

                    ClearSpace(r, c + 1);    //right

                    ClearSpace(r, c - 1);    //left

                    ClearSpace(r - 1, c);    //down
                }
            }
            return;



        }

       
    }
}
