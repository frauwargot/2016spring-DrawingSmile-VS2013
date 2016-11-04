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

namespace PolinaVargot_Lab_due_June2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //create a bitmap. Give its same dimentions as picturebox1
            bmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //create Graphics object for the bitmap
            g = Graphics.FromImage(bmap);//graphics object provides a list of
            //draw... methods
        }
        Bitmap bmap;
        Graphics g;
        Random rand = new Random();
        private Point GetRandonPoint(Bitmap map)
        {
            //make sure to generate x and y within the biunderies of the
            //inmage or bitmap
            int x = rand.Next(map.Width - 5);
            int y = rand.Next(map.Height - 5);
            //crqte a point
            Point p = new Point(x, y);
            return p;
        }
        private Color GetRAndomColor()
        {
            int red = rand.Next(256);
            int green = rand.Next(256);
            int blue = rand.Next(256);
            int alpha = rand.Next(256);
            Color color = Color.FromArgb(alpha, red, green, blue);
            return color;
        }
        private void btnDrawAFace_Click(object sender, EventArgs e)
        {
            //1 point
            Point face;
            
            //width and heigh
            int width;
            int heigh;
            do
            {
                face = GetRandonPoint(bmap);
                width = rand.Next(1, bmap.Width - face.X-5);
                heigh = width;
            } while ((face.Y + heigh >= bmap.Height)||(heigh<=3));
            
            //get a pen

            //draw
            Color color = GetRAndomColor();
            SolidBrush brush = new SolidBrush(color);
            g.FillEllipse(brush, face.X, face.Y, width, heigh);

            //eye1
            SolidBrush brushWhite = new SolidBrush(Color.White);
            Point eyes = new Point(face.X+width/4, face.Y+heigh/4);
            g.FillEllipse(brushWhite, eyes.X, eyes.Y, width / 4, heigh / 4);

            SolidBrush brushBlack = new SolidBrush(Color.Black);
            Point eyesBlack = new Point(eyes.X + width / 20, eyes.Y + heigh / 20);
            g.FillEllipse(brushBlack, eyesBlack.X, eyesBlack.Y, width / 6, heigh / 6);

            //eye2  
           
            Point eyes2nd = new Point(((width / 2) + eyes.X - width / 4), (face.Y + heigh / 4));
            g.FillEllipse(brushWhite, eyes2nd.X, eyes2nd.Y, width / 4, heigh / 4);
            Point eyesBlack2nd = new Point(eyes2nd.X + width / 20, eyes2nd.Y + heigh / 20);
            g.FillEllipse(brushBlack, eyesBlack2nd.X, eyesBlack2nd.Y, width / 6, heigh / 6);
            //apply
            

            //nose
            Point p1 = new Point(face.X+width/2, face.Y+heigh/2);
            Point p2 = new Point(face.X+width*3 / 5, face.Y+heigh*3 / 5);
            Point p3 = new Point(face.X + width / 2, face.Y + heigh * 2 / 3);
            //2. get a pen. get the linewidth and color
            Pen pen = new Pen(Color.Black, 2);
            //3. use the graphics draw methods
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p2, p3);

            //apply the bitmap to the picturebox
            pictureBox1.Image = bmap;

            //mouth
            //1 point
            Point mouthPoint = new Point(eyes.X+width*1/20, eyes.Y+heigh*1/4);
            Point mouthWhite = new Point(mouthPoint.X + width / 14, mouthPoint.Y + width / 10);
            //draw            
            SolidBrush brushMouth = new SolidBrush(Color.Red);
            SolidBrush brushMouthWhite = new SolidBrush(Color.White);
            g.FillPie(brushMouth, mouthPoint.X, mouthPoint.Y, width * 3 / 7, heigh * 3 / 7, 0, 180);
            g.FillPie(brushMouthWhite, mouthWhite.X, mouthWhite.Y, width*2/7, heigh*2/7, 0, 180);
            //apply
            pictureBox1.Image = bmap;

        }
    }
}
