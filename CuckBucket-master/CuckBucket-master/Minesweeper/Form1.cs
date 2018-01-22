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
        int Time = -1;
        int Bombs;
        int Win;

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
            Bombs = 10;
            Time = -1;
            MessageBox.Show("Welcome to Minesweeper! \n\nMinesweeper is a simple puzzle game that challenges your cognitive abilities! " +
            "\n\nMinesweeper is fairly simple. Click anywhere on the grid to open that tile." + 
            " If the tile is a bomb, you lose the game! If the tile is a blank space, then multiple tiles that are connected and are also blank will open." + 
            "Some tiles are numbers. This number indicates how many bombs are in a 3x3 grid AROUND the tile you clicked." +  
            "\n\nRight clicking a tile, will place a flag on that tile. Right clicking on the flag will then place a question mark on that tile." + 
            " Place a flag when you believe that there is a bomb on that certain tile. \n(HINT: Use the numbers to help you figure this out)" + 
            "\n\nPlacing a flag will lower the bomb counter, and if you have successfully placed a flag on each bomb, you win!" +
            "\n\nYour score is calculated by how long you take to finish the game" + 
            "\n\nGoodluck!!" ,"How to Play");
            TimerScore.Enabled = true;
            PuusyBoi = true;
            UgandanKnuckles = false;
            lblBombs.Text = "Bombs: " + Bombs;
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SweepGrid = new Grid(16, 16, 30);
            SweepGrid.Draw(g, 0, 30);
            Bombs = 40;
            Time = -1;
            MessageBox.Show("Welcome to Minesweeper! \n\nMinesweeper is a simple puzzle game that challenges your cognitive abilities! " +
            "\n\nMinesweeper is fairly simple. Click anywhere on the grid to open that tile." +
            " If the tile is a bomb, you lose the game! If the tile is a blank space, then multiple tiles that are connected and are also blank will open." +
            "Some tiles are numbers. This number indicates how many bombs are in a 3x3 grid AROUND the tile you clicked." +
            "\n\nRight clicking a tile, will place a flag on that tile. Right clicking on the flag will then place a question mark on that tile." +
            " Place a flag when you believe that there is a bomb on that certain tile. \n(HINT: Use the numbers to help you figure this out)" +
            "\n\nPlacing a flag will lower the bomb counter, and if you have successfully placed a flag on each bomb, you win!" +
            "\n\nYour score is calculated by how long you take to finish the game" +
            "\n\nGoodluck!!", "How to Play");
            TimerScore.Enabled = true;
            UgandanKnuckles = true;
            PuusyBoi = false;
            lblBombs.Text = "Bombs: " + Bombs;
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
            //finding out what cell is clicked
                int X = (e.X) / 30;
                int Y = (e.Y) / 30;

            if (e.Button == MouseButtons.Right)
            {
                //if clicked outside grid, roast whoever did that
                if (PuusyBoi == true)
                {
                    if (Y < 0 | Y > 8 | X < 0 | X > 8)
                    {
                        MessageBox.Show("stop doing shit u monkey");
                    }
                    else
                    {
                        if (SweepGrid.GetTile(Y, X).Flag == false && SweepGrid.GetTile(Y, X).Quest == false && SweepGrid.GetTile(Y, X).Click == false)
                        {

                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._76px_Minesweeper_flag_svg;
                            Bombs--;
                            lblBombs.Text = "Bombs: " + Bombs;
                            SweepGrid.GetTile(Y, X).Flag = true;
                            this.Refresh();
                        }
                        else if (SweepGrid.GetTile(Y, X).Flag == true)
                        {
                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._76px_Minesweeper_questionmark_svg;
                            Bombs++;
                            lblBombs.Text = "Bombs: " + Bombs;
                            SweepGrid.GetTile(Y, X).Flag = false;
                            SweepGrid.GetTile(Y, X).Quest = true;
                            this.Refresh();
                        }

                        else if (SweepGrid.GetTile(Y, X).Quest == true)
                        {
                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._76px_Minesweeper_unopened_square_svg;
                            SweepGrid.GetTile(Y, X).Quest = false;
                            this.Refresh();
                        }

                       
                       


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
                        if (SweepGrid.GetTile(Y, X).Flag == false && SweepGrid.GetTile(Y, X).Quest == false && SweepGrid.GetTile(Y, X).Click == false)
                        {

                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._76px_Minesweeper_flag_svg;
                            Bombs--;
                            lblBombs.Text = "Bombs: " + Bombs;
                            SweepGrid.GetTile(Y, X).Flag = true;
                            this.Refresh();
                        }
                        else if (SweepGrid.GetTile(Y, X).Flag == true)
                        {
                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._76px_Minesweeper_questionmark_svg;
                            Bombs++;
                            lblBombs.Text = "Bombs: " + Bombs;
                            SweepGrid.GetTile(Y, X).Flag = false;
                            SweepGrid.GetTile(Y, X).Quest = true;
                            this.Refresh();
                        }

                        else if (SweepGrid.GetTile(Y, X).Quest == true)
                        {
                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._76px_Minesweeper_unopened_square_svg;
                            SweepGrid.GetTile(Y, X).Quest = false;
                            this.Refresh();
                        }





                    }
                }

            }



            if (e.Button == MouseButtons.Left)
            {   

                

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
                        
                        if (SweepGrid.GetTile(Y,X).Bomb == true && SweepGrid.GetTile(Y,X).Click == false)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    if (SweepGrid.GetTile(i,j).Bomb ==  true)
                                    {
                                        SweepGrid.GetTile(i, j).ForegroundColour = Resource1.Bomb;
                                    }
                                    SweepGrid.GetTile(i, j).Click = true;
                                }
                            }
                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._1200x630bb;

                            //mesasge box that theyre trash and put options to restart
                            TimerScore.Stop();
                            this.Refresh();
                            MessageBox.Show("Dang flabit! You lost! Try again");
                        }

                        if (Bombs == 0)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    if (SweepGrid.GetTile(Y, X).Bomb == true && SweepGrid.GetTile(Y, X).Flag == true)
                                    {
                                        Win++;
                                    }
                                    if (Win == 10)
                                    {
                                        if (SweepGrid.GetTile(i, j).Bomb == true)
                                        {
                                            SweepGrid.GetTile(i, j).ForegroundColour = Resource1.Bomb;
                                        }
                                        SweepGrid.GetTile(i, j).Click = true;
                                        //message box
                                        this.Refresh();
                                    }
                                }
                            }
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

                        if (SweepGrid.GetTile(Y, X).Bomb == true && SweepGrid.GetTile(Y, X).Click == false)
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                for (int j = 0; j < 16; j++)
                                {
                                    if (SweepGrid.GetTile(i, j).Bomb == true)
                                    {
                                        SweepGrid.GetTile(i, j).ForegroundColour = Resource1.Bomb;
                                    }
                                    SweepGrid.GetTile(i, j).Click = true;
                                }
                            }
                            SweepGrid.GetTile(Y, X).ForegroundColour = Resource1._1200x630bb;

                            //mesasge box that theyre trash and put options to restart
                            TimerScore.Stop();
                            this.Refresh();
                            MessageBox.Show("Dang flabit! You lost! Try again");
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
                if (SweepGrid.GetTile(r, c).Flag == true)
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
                if (SweepGrid.GetTile(r, c).Flag == true)
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

                    ClearSpace(r - 1, c);    //down

                    ClearSpace(r, c - 1);    //left    
                }
                return;

            }

        }

        private void TimerScore_Tick(object sender, EventArgs e)
        {
            Time++;
            lblScore.Text = ("Time: " + Time);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Minesweeper! \n\nMinesweeper is a simple puzzle game that challenges your cognitive abilities! " +
            "\n\nMinesweeper is fairly simple. Click anywhere on the grid to open that tile." +
            " If the tile is a bomb, you lose the game! If the tile is a blank space, then multiple tiles that are connected and are also blank will open." +
            "Some tiles are numbers. This number indicates how many bombs are in a 3x3 grid AROUND the tile you clicked." +
            "\n\nRight clicking a tile, will place a flag on that tile. Right clicking on the flag will then place a question mark on that tile." +
            " Place a flag when you believe that there is a bomb on that certain tile. \n(HINT: Use the numbers to help you figure this out)" +
            "\n\nPlacing a flag will lower the bomb counter, and if you have successfully placed a flag on each bomb, you win!" +
            "\n\nYour score is calculated by how long you take to finish the game" +
            "\n\nGoodluck!!", "How to Play");
        }

       
    }
}
