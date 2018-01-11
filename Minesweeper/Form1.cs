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
            //
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SweepGrid = new Grid(10, 10, 30);
            SweepGrid.Draw(g, 0, 0);
            PuusyBoi = true;
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SweepGrid = new Grid(16, 16, 30);
            SweepGrid.Draw(g, 0, 0);
            UgandanKnuckles = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (SweepGrid != null)
            {
                Graphics g = this.CreateGraphics();
                SweepGrid.Draw(g, 0, 0);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {   

                //finding out what cell is clicked
                int X = (e.X) / 30;
                int Y = (e.Y - 20) / 30;

                //if clicked outside grid, roast whoever did that
                if (PuusyBoi == true)
	            {
		            if (Y < 0 |Y > 9 | X < 0 | X > 9 )
                    {
                    MessageBox.Show("stop doing shit u monkey");
                    }

	            }
                if (UgandanKnuckles == true)
	            {
                    if (Y < 0 |Y > 15 | X < 0 | X > 15 )
                    {
                        MessageBox.Show("stop doing shit u monkey");
                    }
                }
                else //putting everyting into an else statement so game doesnt break by someone clicking out of bounds of grid
                {


                }
            }
        }
    }
}
