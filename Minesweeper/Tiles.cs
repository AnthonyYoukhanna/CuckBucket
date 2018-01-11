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
       private bool mSelected;
       private Color mBackgroundColour;
       private Color mBorderColour;
       private bool mBomb;
       private int mBombCount;
       Rectangle Padding = new Rectangle(0, 0, 30, 30);

       public Tile()
       {
           this.mSize = 30;
           this.mBackgroundColour = Color.Red;
           this.mBorderColour = Color.White;
       }

       public Tile(int Size, Color BackgroundColour, Color BorderColour)
       {
           this.mSize = Size; 
           this.mBackgroundColour = BackgroundColour;
           this.mBorderColour = BorderColour;
       }

       //Methods 
       public void Draw(Graphics g, int X, int Y)
       {
           //will draw a cell on graphics object
           //x and y represent the location of 
           //top left corner of the cell

           //create a pen and a brush to draw with
           Pen BorderPen = new Pen(this.mBorderColour);
           TextureBrush BackBrush = new TextureBrush(Resource1._76px_Minesweeper_unopened_square_svg, Padding);

           //draw cell
           g.FillRectangle(BackBrush, X, Y - 20, this.mSize, this.mSize);
           g.DrawRectangle(BorderPen, X, Y + 20, this.mSize, this.mSize);
            

           //dispose of drawing objects
           BorderPen.Dispose();
           BackBrush.Dispose();

       }

       public int Size
        {
            set { this.mSize = value; }
            get { return this.mSize; }
        }

        public Color BackgroundColour
        {
            set { this.mBackgroundColour = value; }
            get { return this.mBackgroundColour; }

        }

        public Color BorderColour
        {
            set { this.mBorderColour = value; }
            get { return this.mBorderColour; }

        }
       
        public bool Selected
        {
            set { this.mSelected = value; }
            get { return this.mSelected; }

        }
        public bool Bomb
        {
            set { this.mBomb = value; }
            get { return this.mBomb; }

        }
        public int BombCount
        {
            set { this.mBombCount = value; }
            get { return this.mBombCount; }
        }

    }
}
