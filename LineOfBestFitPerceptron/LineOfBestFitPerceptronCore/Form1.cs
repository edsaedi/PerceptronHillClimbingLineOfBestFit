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

            random = new Random();

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

            //gfx.FillEllipse(Brushes.Black, location.X - 5, location.Y - 5, 10, 10);
            dataPoints.Add((location.X - 5, location.Y - 5));
            Graph();
            //canvasPictureBox.Image = canvas;
        }

        public static decimal LinearEquationSolver(decimal x, decimal M, decimal B)
        {
            return (x * M) + B;
        }

        public static double MeanSquaredError(double[] output, double[] desiredOutput)
        {
            if (output.Length != desiredOutput.Length || output.Length == 0)
            {
                throw new ArgumentException();
            }
            //return Math.Pow(desiredOutput - output, 2);

            double error = 0;

            for (int i = 0; i < output.Length; i++)
            {
                error += Math.Pow(desiredOutput[i] - output[i], 2);
            }

            return error / output.Length;
        }

        public static double MeanSquaredError(double output, double desiredOutput)
        {
            return Math.Pow((desiredOutput - output), 2);
        }

        double RegressionError(List<(decimal, decimal)> points)
        {
            //error is mean of the squares of residuals
            //where the residual is y actual - y predicted from x actual
            double[] yValues = points.Select(p => (double)p.Item2).ToArray();
            return MeanSquaredError(points.Select(p => (double)p.Item1).Select(x => perceptron.Compute(new double[] { x })).ToArray(), yValues);
        }

        private void LinearRegression_Click(object sender, EventArgs e)
        {

            perceptron = new Perceptron(1, 0.1, random, MeanSquaredError);

            //Rest of the code for the linear regression. Use the library we have.

            LinearRegression.Enabled = false;

            //You need to fix this:
            int iterations = 0;
            while (iterations <= 1000000 && perceptron.GetError(DoubleConversion(dataPoints), SingleConversion(dataPoints, 2)) > 1)
            {
                perceptron.TrainWithHillClimbing(DoubleConversion(dataPoints), SingleConversion(dataPoints, 2), perceptron.GetError(DoubleConversion(dataPoints), SingleConversion(dataPoints, 2)));
                iterations++;
            }

            //keep in mind that the bias is the y-intercept and the weights are the slope
            //make sure to repeat the hill climbing until you get within a certain amount of error or iterations

            GraphLine();


            LinearRegression.Enabled = true;


        }


        private double[][] DoubleConversion(List<(decimal, decimal)> list)
        {
            return (list.Select(p => (double)p.Item1).Select(x => new double[] { x }).ToArray());
        }

        private double[] SingleConversion(List<(decimal, decimal)> list, int itemNumber = 1)
        {
            if (itemNumber == 1)
            {
                return list.Select(p => (double)p.Item1).ToArray();
            }

            return list.Select(p => (double)p.Item2).ToArray();
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

        public void GraphLine()
        {
            decimal slope = (decimal)perceptron.weights[0];
            //there is only one value in our weights array and that is the slope.
            decimal yIntercept = (decimal)perceptron.bias;
            //the bias is the y-intercept

            gfx.DrawLine(new Pen(Color.Black), new Point(0, (int)LinearEquationSolver(0, slope, yIntercept)), new Point(canvasPictureBox.Width, (int)LinearEquationSolver(canvasPictureBox.Width, slope, yIntercept)));

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
