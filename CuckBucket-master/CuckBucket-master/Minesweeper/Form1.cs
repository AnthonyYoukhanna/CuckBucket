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
                        
                        ClearSpace(Y, X);
                        
                        if (SweepGrid.GetTile(Y,X).Bomb == true)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    if (SweepGrid.GetTile(i,j).Bomb ==  true)
                                    {
                                        SweepGrid.GetTile(i, j).ForegroundColour = Resource1.Bomb;
                                    }
                                }
                            }
                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._1200x630bb;

                            //mesasge box that theyre trash and put options to restart

                        }

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
                        
                        if (SweepGrid.GetTile(Y, X).Bomb == true)
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                for (int j = 0; j < 16; j++)
                                {
                                    if (SweepGrid.GetTile(i, j).Bomb == true)
                                    {
                                        SweepGrid.GetTile(i, j).ForegroundColour = Resource1.Bomb;
                                    }
                                }
                            }

                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._1200x630bb;

                            //mesasge box that theyre trash and put options to restart
                        }


                        this.Refresh();

                    }
                }
            }
        }

       
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
                if (SweepGrid.GetTile(r, c).BombCount > 0)
                {
                    SweepGrid.GetTile(r, c).ForegroundColour = SweepGrid.GetTile(r, c).BackgroundColour;

                    SweepGrid.GetTile(r, c).Click = true;
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
                if (SweepGrid.GetTile(r, c).Bomb == true)
                {
                    return;
                }
                if (SweepGrid.GetTile(r, c).BombCount > 0)
                {
                    SweepGrid.GetTile(r, c).ForegroundColour = SweepGrid.GetTile(r, c).BackgroundColour;

                    SweepGrid.GetTile(r, c).Click = true;
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
