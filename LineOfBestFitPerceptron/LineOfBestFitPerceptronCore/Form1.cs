using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PerceptronHillClimberLibrary;

namespace LineOfBestFitPerceptronCore
{
    public partial class Form1 : Form
    {
        public static List<(decimal, decimal)> dataPoints;
        Bitmap canvas;
        Graphics gfx;
        int originX;
        int originY;
        HashSet<Point> uniqueDataPoints = new HashSet<Point>();
        Perceptron perceptron;
        Random random;

        public Form1()
        {
            InitializeComponent();

            dataPoints = new List<(decimal, decimal)>();
            canvas = new Bitmap(canvasPictureBox.Width, canvasPictureBox.Height);
            originX = canvasPictureBox.Width / 2;
            originY = canvasPictureBox.Width / 2;
            gfx = Graphics.FromImage(canvas);
            Graph();

            xValue.Minimum = -originX + 5;
            xValue.Maximum = originX - 5;
            yValue.Minimum = -originY + 5;
            yValue.Maximum = originY - 5;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void canvasPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var location = e.Location;
            //this makes sure that you do not have duplicates
            if (uniqueDataPoints.Add(location) == false)
            {
                return;
            }

            gfx.FillEllipse(Brushes.Black, location.X - 5, location.Y - 5, 10, 10);
            dataPoints.Add((location.X - 5, location.Y - 5));
            canvasPictureBox.Image = canvas;
        }

        public static decimal LinearEquationSolver(decimal x, decimal M, decimal B)
        {
            return (x * M) + B;
        }

        public static double MeanSquaredError(double output, double desiredOutput)
        {
            return Math.Pow(desiredOutput - output, 2);
        }




        private void LinearRegression_Click(object sender, EventArgs e)
        {
            perceptron = new Perceptron(1, 0.1, random, MeanSquaredError);

            //Rest of the code for the linear regression. Use the library we have.
        }



        public void Graph()
        {
            gfx.Clear(Color.White);
            gfx.DrawLine(new Pen(Color.Black), new Point(0, originY), new Point(canvasPictureBox.Width, originY));
            gfx.DrawLine(new Pen(Color.Black), new Point(originX, 0), new Point(originX, canvasPictureBox.Height));

            foreach (var point in dataPoints)
            {
                gfx.FillEllipse(Brushes.Black, (float)point.Item1, (float)point.Item2, 10, 10);
            }

            canvasPictureBox.Image = canvas;
        }


        //Add this. Errors come from LinearEquationSolver

        //public void DrawLine()
        //{
        //    var yInitial = (int)LinearEquationSolver(0);
        //    var yFinal = (int)LinearEquationSolver(canvasPictureBox.Width);
        //    gfx.DrawLine(new Pen(Color.Red), new Point(0, yInitial), new Point(canvasPictureBox.Width, yFinal));
        //    canvasPictureBox.Image = canvas;

        //    canvasPictureBox.Invalidate();
        //}

    }
}
