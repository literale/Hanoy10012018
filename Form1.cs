using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Hanoy10012018
{
    public partial class Form1 : Form
    {
        MyStack[] ArSt = new MyStack[3];
        // Bitmap gBitmap = new Bitmap(900, 600);
        Graphics gBitmap;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < 3; i++)
                ArSt[i] = new MyStack();
            for (int i = n; i > 0; i--)
            {
                ArSt[0].PushStack(i);
            }
                Drawing();
                Hanoj(0, 1, 2, n);

            
        }
         void Hanoj(int d1, int d2, int d3, int k)
        {
            if (k>0)
            {
                Hanoj(d1, d3, d2, k - 1);
                int e = ArSt[d1].PopStack();
                ArSt[d2].PushStack(e);
                Drawing();
                Hanoj(d3, d2, d1, k - 1);
            }
        }

        void Drawing()
        {
            int[] x0 = { 100, 300, 500 };
            int y0 = 290;
            int yH = 50;
            int w = 15;
            int h = 13;
            int e;
            
            Pen MyPen0 = new Pen(Color.DarkSlateBlue);
            gBitmap = this.CreateGraphics();
            gBitmap.Clear(Color.White);
            gBitmap.DrawLine(MyPen0, x0[0], y0, x0[0], yH);
            gBitmap.DrawLine(MyPen0, x0[1], y0, x0[1], yH);
            gBitmap.DrawLine(MyPen0, x0[2], y0, x0[2], yH);
            for (int i = 0; i<=2; i++)
            {
                MyStack tmp = new MyStack();
                while (!ArSt[i].StackIsEmpty())
                {
                    e = ArSt[i].PopStack();
                    tmp.PushStack(e);

                }
                int y = y0;
                while (!tmp.StackIsEmpty())
                {
                    e = tmp.PopStack();
                    ArSt[i].PushStack(e);
                    gBitmap.FillEllipse(Brushes.DarkBlue, x0[i] - e * w, y, 2 * e * w, h);
                    y -= h;
                }
            }
            Thread.Sleep(250);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gBitmap.Clear(Color.White);
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
