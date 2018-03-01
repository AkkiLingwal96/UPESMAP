using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        int[] color = new int[14];
        int V = 14;
        /* A utility function to check if the current color assignment
           is safe for vertex v */
        bool isSafe(int v, int[,] graph, int[] color, int c)
        {
            for (int i = 0; i < V; i++)
                if (graph[v, i] == 1 && c == color[i])
                    return false;
            return true;
        }

        bool graphColoringUtil(int[,] graph, int m, int[] color, int v)
        {
            /* base case: If all vertices are assigned a color then
               return true */
            if (v == V)
                return true;

            /* Consider this vertex v and try different colors */
            for (int c = 1; c <= m; c++)
            {
                /* Check if assignment of color c to v is fine*/
                if (isSafe(v, graph, color, c))
                {
                    color[v] = c;

                    /* recur to assign colors to rest of the vertices */
                    if (graphColoringUtil(graph, m, color, v + 1) == true)
                        return true;

                    /* If assigning color c doesn't lead to a solution
                       then remove it */
                    color[v] = 0;
                }
            }

            /* If no color can be assigned to this vertex then return false */
            return false;
        }

        bool graphColoring(int[,] graph, int m)
        {
            // Initialize all color values as 0. This initialization is needed
            // correct functioning of isSafe()
            for (int i = 0; i < V; i++)
                color[i] = 0;
            if (graphColoringUtil(graph, m, color, 0) == false)
            {
                Console.WriteLine("Solution does not exist");
                return false;
            }
            return true;
        }

            int[,] graph = new int[14, 14]  {
         //   1  2  3  4  5  6  7  8  9  10 11 12 13 14
      /*1*/  {0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
      /*2*/  {1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
      /*3*/  {1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
      /*4*/  {1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
      /*5*/  {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
      /*6*/  {0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
      /*7*/  {0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0},
      /*8*/  {0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0},
      /*9 */ {0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
     /*10*/  {0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1},
     /*11*/  {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0},
     /*12*/  {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0},
     /*13*/  {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1},
     /*14*/  {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
             };

        private void button1_Click(object sender, EventArgs e)
        {
            graphColoring(graph, 3);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Font fnt = new Font("Verdana", 14);
            Brush red = new SolidBrush(Color.Red);
            Brush green = new SolidBrush(Color.Green);
            Brush blue = new SolidBrush(Color.Blue);
            Pen pn = new Pen(Color.Black);

            //Lines

            g.DrawLine(pn, 30, 350, 80, 140);
            g.DrawLine(pn, 50, 350, 80, 300);
            g.DrawLine(pn, 50, 350, 80, 440);
            g.DrawLine(pn, 100, 120, 100, 300);
            g.DrawLine(pn, 130, 310, 150, 310);
            g.DrawLine(pn, 130, 140, 150, 140);
            g.DrawLine(pn, 130, 450, 150, 450);
            g.DrawLine(pn, 170, 120, 170, 100);
            g.DrawLine(pn, 170, 400, 170, 430);
            g.DrawLine(pn, 170, 330, 170, 350);
            g.DrawLine(pn, 170, 150, 230, 190);
            g.DrawLine(pn, 170, 280, 230, 190);
            g.DrawLine(pn, 170, 370, 230, 370);
            g.DrawLine(pn, 170, 440, 230, 370);
            g.DrawLine(pn, 240, 210, 300, 370);
            g.DrawLine(pn, 270, 370, 290, 370);
            g.DrawLine(pn, 270, 210, 370, 350);
            g.DrawLine(pn, 270, 205, 430, 350);
            g.DrawLine(pn, 340, 370, 360, 370);
            g.DrawLine(pn, 410, 370, 430, 370);


            int ch;
            for(int i=0; i < V; i++)
            {
                ch = color[i];
                switch(i)
                {
                    case 0:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 10, 350, 50, 50);
                            g.DrawString("B1", fnt, new SolidBrush(Color.Black), 10, 350);
                        } else if(ch == 2)
                        {
                            g.FillRectangle(green, 10, 350, 50, 50);
                            g.DrawString("B1", fnt, new SolidBrush(Color.Black), 10, 350);
                        } else
                        {
                            g.FillRectangle(blue, 10, 350, 50, 50);
                            g.DrawString("B1", fnt, new SolidBrush(Color.Black), 10, 350);
                        }
                        break;
                    case 1:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 80, 120, 50, 50);
                            g.DrawString("B6", fnt, new SolidBrush(Color.Black), 80, 120);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 80, 120, 50, 50);
                            g.DrawString("B6", fnt, new SolidBrush(Color.Black), 80, 120);
                        }
                        else
                        {
                            g.FillRectangle(blue, 80, 120, 50, 50);
                            g.DrawString("B6", fnt, new SolidBrush(Color.Black), 80, 120);
                        }
                        break;
                    case 2:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 80, 280, 50, 50);
                            g.DrawString("B2", fnt, new SolidBrush(Color.Black), 80, 280);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 80, 280, 50, 50);
                            g.DrawString("B2", fnt, new SolidBrush(Color.Black), 80, 280);
                        }
                        else
                        {
                            g.FillRectangle(blue, 80, 280, 50, 50);
                            g.DrawString("B2", fnt, new SolidBrush(Color.Black), 80, 280);
                        }
                        break;
                    case 3:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 80, 430, 50, 50);
                            g.DrawString("B4", fnt, new SolidBrush(Color.Black), 80, 430);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 80, 430, 50, 50);
                            g.DrawString("B4", fnt, new SolidBrush(Color.Black), 80, 430);
                        }
                        else
                        {
                            g.FillRectangle(blue, 80, 430, 50, 50);
                            g.DrawString("B4", fnt, new SolidBrush(Color.Black), 80, 430);
                        }
                        break;
                    case 4:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 150, 50, 50, 50);
                            g.DrawString("B9", fnt, new SolidBrush(Color.Black), 150, 50);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 150, 50, 50, 50);
                            g.DrawString("B9", fnt, new SolidBrush(Color.Black), 150, 50);
                        }
                        else
                        {
                            g.FillRectangle(blue, 150, 50, 50, 50);
                            g.DrawString("B9", fnt, new SolidBrush(Color.Black), 150, 50);
                        }
                        break;
                    case 5:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 150, 120, 50, 50);
                            g.DrawString("B7", fnt, new SolidBrush(Color.Black), 150, 120);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 150, 120, 50, 50);
                            g.DrawString("B7", fnt, new SolidBrush(Color.Black), 150, 120);
                        }
                        else
                        {
                            g.FillRectangle(blue, 150, 120, 50, 50);
                            g.DrawString("B7", fnt, new SolidBrush(Color.Black), 150, 120);
                        }
                        break;
                    case 6:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 150, 280, 50, 50);
                            g.DrawString("B3", fnt, new SolidBrush(Color.Black), 150, 280);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 150, 280, 50, 50);
                            g.DrawString("B3", fnt, new SolidBrush(Color.Black), 150, 280);
                        }
                        else
                        {
                            g.FillRectangle(blue, 150, 280, 50, 50);
                            g.DrawString("B3", fnt, new SolidBrush(Color.Black), 150, 280);
                        }
                        break;
                    case 7:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 150, 350, 50, 50);
                            g.DrawString("Cafe", fnt, new SolidBrush(Color.Black), 150, 350);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 150, 350, 50, 50);
                            g.DrawString("Cafe", fnt, new SolidBrush(Color.Black), 150, 350);
                        }
                        else
                        {
                            g.FillRectangle(blue, 150, 350, 50, 50);
                            g.DrawString("Cafe", fnt, new SolidBrush(Color.Black), 150, 350);
                        }
                        break;
                    case 8:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 150, 430, 50, 50);
                            g.DrawString("B5", fnt, new SolidBrush(Color.Black), 150, 430);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 150, 430, 50, 50);
                            g.DrawString("B5", fnt, new SolidBrush(Color.Black), 150, 430);
                        }
                        else
                        {
                            g.FillRectangle(blue, 150, 430, 50, 50);
                            g.DrawString("B5", fnt, new SolidBrush(Color.Black), 150, 430);
                        }
                        break;
                    case 9:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 220, 190, 50, 50);
                            g.DrawString("GC", fnt, new SolidBrush(Color.Black), 220, 190);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 220, 190, 50, 50);
                            g.DrawString("GC", fnt, new SolidBrush(Color.Black), 220, 190);
                        }
                        else
                        {
                            g.FillRectangle(blue, 220, 190, 50, 50);
                            g.DrawString("GC", fnt, new SolidBrush(Color.Black), 220, 190);
                        }
                        break;
                    case 10:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 220, 350, 50, 50);
                            g.DrawString("Amp", fnt, new SolidBrush(Color.Black), 220, 350);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 220, 350, 50, 50);
                            g.DrawString("Amp", fnt, new SolidBrush(Color.Black), 220, 350);
                        }
                        else
                        {
                            g.FillRectangle(blue, 220, 350, 50, 50);
                            g.DrawString("Amp", fnt, new SolidBrush(Color.Black), 220, 350);
                        }
                        break;
                    case 11:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 290, 350, 50, 50);
                            g.DrawString("B8", fnt, new SolidBrush(Color.Black), 290, 350);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 290, 350, 50, 50);
                            g.DrawString("B8", fnt, new SolidBrush(Color.Black), 290, 350);
                        }
                        else
                        {
                            g.FillRectangle(blue, 290, 350, 50, 50);
                            g.DrawString("B8", fnt, new SolidBrush(Color.Black), 290, 350);
                        }
                        break;
                    case 12:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 360, 350, 50, 50);
                            g.DrawString("B10", fnt, new SolidBrush(Color.Black), 360, 350);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 360, 350, 50, 50);
                            g.DrawString("B10", fnt, new SolidBrush(Color.Black), 360, 350);
                        }
                        else
                        {
                            g.FillRectangle(blue, 360, 350, 50, 50);
                            g.DrawString("B10", fnt, new SolidBrush(Color.Black), 360, 350);
                        }
                        break;
                    case 13:
                        if (ch == 1)
                        {
                            g.FillRectangle(red, 430, 350, 50, 50);
                            g.DrawString("B11", fnt, new SolidBrush(Color.Black), 430, 350);
                        }
                        else if (ch == 2)
                        {
                            g.FillRectangle(green, 430, 350, 50, 50);
                            g.DrawString("B11", fnt, new SolidBrush(Color.Black), 430, 350);
                        }
                        else
                        {
                            g.FillRectangle(blue, 430, 350, 50, 50);
                            g.DrawString("B11", fnt, new SolidBrush(Color.Black), 430, 350);
                        }
                        break;

                }
            } 
        }

    }
}
