using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Minesweeper
{
   public class Grid
    {
       //private fields
       private Tile[,] mGrid;
       private int mRows, mColumns;
       private int mTileSize;


       //Constructors

       public Grid(int Rows, int Columns, int TileSize)
       {
            this.mRows = Rows;
            this.mColumns = Columns;
            this.mTileSize = TileSize;

            mGrid = new Tile[this.mRows, this.mColumns];

            for (int i = 0; i < this.mRows; i++)
            {
                for (int j = 0; j < this.mColumns; j++)
                {
                    mGrid[i, j] = new Tile();
                }
            }

            int eBombs = 10;
            int iBombs = 40;
            for (int i = 0; i < mGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mGrid.GetLength(1); j++)
                {
                    if (mGrid.GetLength(0) == 10)
                    {
                        if (eBombs > 0)
                        {
                            mGrid[i, j].Bomb = true;
                            eBombs--;
                            mGrid[i, j].BackgroundColour = Color.Black;

                        }
                    }
                    if (mGrid.GetLength(0) == 16)
                    {
                        if (iBombs > 0)
                        {
                            mGrid[i, j].Bomb = true;
                            iBombs--;
                            mGrid[i, j].BackgroundColour = Color.Black;
                        }
                    }
                }
            }

            Color Temp;
            Random Index = new Random();
            for (int i = 0; i < mGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mGrid.GetLength(1); j++)
                {
                    int Row = Index.Next(0, mGrid.GetLength(0) - 1);
                        int Column = Index.Next(0, mGrid.GetLength(1) - 1);


                        Temp = mGrid[i, j].BackgroundColour;
                        mGrid[i, j].BackgroundColour = mGrid[Row, Column].BackgroundColour;
                        mGrid[Row, Column].BackgroundColour = Temp;
                }   
            }
            BombCount(0);
            for (int i = 0; i < mGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mGrid.GetLength(1); j++)
                {
                    if (mGrid[i,j].BombCount > 0)
                    {
                         
                    }
                }
            }
       }

       //Methods

       //Gets tile location
       public Tile GetTile(int Row, int Columns)
       {
           return mGrid[Row, Columns];
       }

       public void Draw(Graphics g, int X, int Y)
       {
           int pX = X;
           int pY = Y;

           for (int i = 0; i < this.mRows; i++)
           {

               pY = Y + (i * this.mTileSize);

               for (int j = 0; j < this.mColumns; j++)
               {
                   pX = X + (j * this.mTileSize);
                   mGrid[i, j].Draw(g, pX, pY);

               }
           }
       }
       public int BombCount(int Bombs)
       {
           for (int i = 0; i < mGrid.GetLength(0); i++)
           {
               for (int j = 0; j < mGrid.GetLength(1); j++)
               {
                   if (i == 0)
                   {
                       if (j==0)
                       {
                           if (mGrid[i, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                       }
                       else if (j == mGrid.GetLength(1) - 1)
                       {
                           if (mGrid[i + 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }

                       }
                       else
                       {
                           if (mGrid[i, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                       }
                       
                   }
                   else if (i == mGrid.GetLength(0) - 1)
                   {
                       if (j == 0)
                       {
                           if (mGrid[i - 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i - 1, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                       }
                       if (j == mGrid.GetLength(1) - 1)
                       {
                           if (mGrid[i - 1, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i - 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                       }
                       else
                       {
                           if (mGrid[i - 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i - 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i - 1, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                       }
                   }
                   else
                   {
                       if (j == 0)
                       {
                           if (mGrid[i - 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i - 1, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                       }
                       else if (j == mGrid.GetLength(1) - 1)
                       {
                           if (mGrid[i - 1, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i - 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                          
                       }
                       else
                       {
                           if (mGrid[i - 1, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i - 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i - 1, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j - 1].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j].Bomb == true)
                           {
                               Bombs++;
                           }
                           if (mGrid[i + 1, j + 1].Bomb == true)
                           {
                               Bombs++;
                           }
 
                       }
                   }
                  
                   
                   mGrid[i, j].BombCount = Bombs;
               }
               Bombs = 0;
           }
           return Bombs;
           
       }

    }
}
