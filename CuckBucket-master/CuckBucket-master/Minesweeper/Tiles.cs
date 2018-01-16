using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Minesweeper
{
   public class Tile
    {
       private int mSize;
       private Bitmap mBackgroundColour;
       private Bitmap mForegroundColour;
       private Color mBorderColour;
       private bool mBomb;
       private int mBombCount;
       private bool mClick;
       Rectangle Padding = new Rectangle(0, 0, 30, 30);

       public Tile()
       {
           this.mSize = 30;
           this.mBackgroundColour = Resource1._76px_Minesweeper_0_svg;
           this.mForegroundColour = Resource1._76px_Minesweeper_unopened_square_svg;
           this.mBorderColour = Color.White;
           
       }

       public Tile(int Size, Bitmap BackgroundColour, Color BorderColour)
       {
           this.mSize = Size;
           this.mBackgroundColour = BackgroundColour;
           this.mBorderColour = BorderColour;
           this.mForegroundColour = ForegroundColour;
       }

       //Methods 
       public void Draw(Graphics g, int X, int Y)
       {
           //will draw a cell on graphics object
           //x and y represent the location of 
           //top left corner of the cell

           //create a pen and a brush to draw with
           Pen BorderPen = new Pen(this.mBorderColour);
           TextureBrush BackBrush = new TextureBrush(this.mForegroundColour);

           //draw cell
           g.FillRectangle(BackBrush, X, Y - 30, this.mSize, this.mSize);
           g.DrawRectangle(BorderPen, X, Y + 30, this.mSize, this.mSize);
            

           //dispose of drawing objects
           BorderPen.Dispose();
           BackBrush.Dispose();

       }

       public int Size
        {
            set { this.mSize = value; }
            get { return this.mSize; }
        }

        public Bitmap BackgroundColour
        {
            set { this.mBackgroundColour = value; }
            get { return this.mBackgroundColour; }

        }

        public Bitmap ForegroundColour
        {
            set { this.mForegroundColour = value; }
            get { return this.mForegroundColour; }

        }

        public Color BorderColour
        {
            set { this.mBorderColour = value; }
            get { return this.mBorderColour; }

        }
       
        public bool Bomb
        {
            set { this.mBomb = value; }
            get { return this.mBomb; }

        }
        public bool Click
        {
            set { this.mClick = value; }
            get { return this.mClick; }

        }
        public int BombCount
        {
            set { this.mBombCount = value; }
            get { return this.mBombCount; }
        }

    }
}
