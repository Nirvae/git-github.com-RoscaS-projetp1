using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace drawing_robot_simulator
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public const int ZOOMFACTOR = 3;

        public RobotArm Arm_1, Arm_2;
        public PointF i1, i2, ARMPointA;
        public Point SheetCoord;
        public List<Point> DrawPointList = new List<Point>();
        public Bitmap ToDraw;
        public Bitmap BotDraw;

        public Form1()
        {
            InitializeComponent();

            graphicalOverlay.Owner = this;

            ARMPointA.X = Sheet.Left + Sheet.Width + 10 * ZOOMFACTOR;
            ARMPointA.Y = Sheet.Top + Sheet.Height;

            BotDraw = new Bitmap(Sheet.Width, Sheet.Height);
            ToDraw = new Bitmap(Sheet.Width, Sheet.Height);
            Sheet.Image = ToDraw;

            Arm_1 = new RobotArm(168 * ZOOMFACTOR, (float)Math.PI, ARMPointA.X, ARMPointA.Y);
            Arm_2 = new RobotArm(206 * ZOOMFACTOR, (float)Math.PI, Arm_1.PointB.X, Arm_1.PointB.Y);
        }


        //private void Sheet_MouseMove(object sender, MouseEventArgs e)
        //{
        //    SheetCoord = Sheet.PointToClient(Cursor.Position);

        //    if (e.Button == MouseButtons.Left)
        //    {
        //        DrawPointList.Add(SheetCoord);
        //        ToDraw.SetPixel((int)SheetCoord.X, (int)SheetCoord.Y, Color.Black);
        //    }

        //    SheetCoord.X += Sheet.Left;
        //    SheetCoord.Y += Sheet.Top;

        //    int nbIntersections = FindCircleCircleIntersections((float)SheetCoord.X, (float)SheetCoord.Y, (float)Arm_2.armLength, Arm_1.PointA.X, Arm_1.PointA.Y, (float)Arm_1.armLength, out i1, out i2);

        //    Arm_1.PointB = i1;
        //    Arm_2.PointA = Arm_1.PointB;
        //    Arm_2.PointB = SheetCoord;

        //    Sheet.Refresh();

        //    lblDevArm1BaseAxis.Text = "1A: " + (Convert.ToString(Arm_1.PointA));
        //    lblDevArm1RayAxis.Text = "1B: " + (Convert.ToString(Arm_1.PointB));
        //    lblDevArm2BaseAxis.Text = "2A: " + (Convert.ToString(Arm_2.PointA));
        //    lblDevArm2RayAxis.Text = "2B: " + (Convert.ToString(Arm_2.PointB));

        //}

        private int FindCircleCircleIntersections( float cx0, float cy0, float radius0, float cx1, float cy1, float radius1, out PointF intersection1, out PointF intersection2)
        {
            // Find the distance between the centers.
            float dx = cx0 - cx1;
            float dy = cy0 - cy1;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                double a = (radius0 * radius0 - radius1 * radius1 + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                double cx2 = cx0 + a * (cx1 - cx0) / dist;
                double cy2 = cy0 + a * (cy1 - cy0) / dist;

                // Get the points P3.
                intersection1 = new PointF(
                    (float)(cx2 + h * (cy1 - cy0) / dist),
                    (float)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new PointF(
                    (float)(cx2 - h * (cy1 - cy0) / dist),
                    (float)(cy2 + h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }

        private void ImportImageButton_Click(object sender, EventArgs e)
        {
            // Wrap the creation of the OpenFileDialog instance in a using statement,
            // rather than manually calling the Dispose method to ensure proper disposal
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    ThumbnailBox.Image = new Bitmap(dlg.FileName);
                    ToDraw = new Bitmap(dlg.FileName);
                    ToDraw = ResizeImage(ToDraw, BotDraw.Width, BotDraw.Height);
                }
            }
        }

        //test

        private void StartDrawingButton_Click(object sender, EventArgs e)
        {
            Sheet.Image = BotDraw;
            ToDraw = ToBlackAndWhite(ToDraw);
            ThumbnailBox.Image = ToDraw;

            DrawPointList = SortByDistance(DrawPointList);

            foreach (Point P in DrawPointList)
            {
                Point SheetCoord = P;

                BotDraw.SetPixel(SheetCoord.X, SheetCoord.Y, Color.Black);

                SheetCoord.X += Sheet.Left;
                SheetCoord.Y += Sheet.Top;

                int nbIntersections = FindCircleCircleIntersections((float)SheetCoord.X, (float)SheetCoord.Y, (float)Arm_2.armLength, Arm_1.PointA.X, Arm_1.PointA.Y, (float)Arm_1.armLength, out i1, out i2);

                Arm_1.PointB = i1;
                Arm_2.PointA = Arm_1.PointB;
                Arm_2.PointB = SheetCoord;

                Sheet.Refresh();

                lblDevArm1BaseAxis.Text = "1A: " + (Convert.ToString(Arm_1.PointA));
                lblDevArm1RayAxis.Text = "1B: " + (Convert.ToString(Arm_1.PointB));
                lblDevArm2BaseAxis.Text = "2A: " + (Convert.ToString(Arm_2.PointA));
                lblDevArm2RayAxis.Text = "2B: " + (Convert.ToString(Arm_2.PointB));

                Application.DoEvents();
            }
            
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        /// Code from http://stackoverflow.com/users/65387/mpen
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private Bitmap ToBlackAndWhite(Bitmap original)         //Funkction from http://stackoverflow.com/users/472875/user472875 modified to fit my needs
        {
            Bitmap output = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {

                for (int j = 0; j < original.Height; j++)
                {

                    Color c = original.GetPixel(i, j);

                    int average = ((c.R + c.B + c.G) / 3);

                    if (average < 170)
                    {
                        output.SetPixel(i, j, Color.Black);
                        DrawPointList.Add(new Point(i, j));
                    }

                    else
                    {
                        output.SetPixel(i, j, Color.White);
                    }

                }
            }

            return output;
        }

        List<Point> SortByDistance(List<Point> lst)
        {
            List<Point> output = new List<Point>();
            output.Add(lst[NearestPoint(new Point(0, 0), lst)]);
            lst.Remove(output[0]);
            int x = 0;
            for (int i = 0; i < lst.Count + x; i++)
            {
                output.Add(lst[NearestPoint(output[output.Count - 1], lst)]);
                lst.Remove(output[output.Count - 1]);
                x++;

                Application.DoEvents();
            }
            return output;
        }

        int NearestPoint(Point srcPt, List<Point> lookIn)
        {
            KeyValuePair<double, int> smallestDistance = new KeyValuePair<double, int>();
            for (int i = 0; i < lookIn.Count; i++)
            {
                double distance = Math.Sqrt(Math.Pow(srcPt.X - lookIn[i].X, 2) + Math.Pow(srcPt.Y - lookIn[i].Y, 2));
                if (i == 0)
                {
                    smallestDistance = new KeyValuePair<double, int>(distance, i);
                }
                else
                {
                    if (distance < smallestDistance.Key)
                    {
                        smallestDistance = new KeyValuePair<double, int>(distance, i);
                    }
                }
            }
            return smallestDistance.Value;
        }

        private void graphicalOverlay_Paint(object sender, PaintEventArgs e)
        {
            Pen pen;
            pen = new Pen(Color.Red, 5);
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.Clear(Color.White);
            formGraphics.DrawLine(pen, Arm_1.PointA.X, Arm_1.PointA.Y, Arm_1.PointB.X, Arm_1.PointB.Y);
            pen.Color = Color.Blue;
            formGraphics.DrawLine(pen, Arm_2.PointA.X, Arm_2.PointA.Y, Arm_2.PointB.X, Arm_2.PointB.Y);

            if (CheckBoxDevMod.Checked)
            {
                pen = new Pen(Color.Red, 3);
                formGraphics.DrawEllipse(pen, Arm_1.PointA.X - (float)Arm_1.armLength, Arm_1.PointA.Y - (float)Arm_1.armLength, 2 * (float)Arm_1.armLength, 2 * (float)Arm_1.armLength);
                pen.Color = Color.Blue;
                formGraphics.DrawEllipse(pen, Arm_2.PointB.X - (float)Arm_2.armLength, Arm_2.PointB.Y - (float)Arm_2.armLength, 2 * (float)Arm_2.armLength, 2 * (float)Arm_2.armLength);
            }


            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-10, -10);

            pen = new Pen(Color.Red, 5);
            e.Graphics.DrawLine(pen, Arm_1.PointA.X, Arm_1.PointA.Y, Arm_1.PointB.X, Arm_1.PointB.Y);
            pen = new Pen(Color.Blue, 5);
            e.Graphics.DrawLine(pen, Arm_2.PointA.X, Arm_2.PointA.Y, Arm_2.PointB.X, Arm_2.PointB.Y);

            if (CheckBoxDevMod.Checked)
            {
                pen = new Pen(Color.Red, 3);
                e.Graphics.DrawEllipse(pen, Arm_1.PointA.X - (float)Arm_1.armLength, Arm_1.PointA.Y - (float)Arm_1.armLength, 2 * (float)Arm_1.armLength, 2 * (float)Arm_1.armLength);
                pen.Color = Color.Blue;
                e.Graphics.DrawEllipse(pen, Arm_2.PointB.X - (float)Arm_2.armLength, Arm_2.PointB.Y - (float)Arm_2.armLength, 2 * (float)Arm_2.armLength, 2 * (float)Arm_2.armLength);
            }

            pen.Dispose();
            e.Dispose();
            formGraphics.Dispose();

        }
    }
}
