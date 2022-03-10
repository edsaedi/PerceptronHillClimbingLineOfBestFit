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

namespace LineOfBestFitPerceptronCoreNormalization
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


            //Please delete this later:
            dataPoints.Add((314, 79));
            dataPoints.Add((230, 281));
            dataPoints.Add((248, 360));
            dataPoints.Add((296, 165));

            Graph();
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

        public static double MeanSquaredError(double output, double desiredOutput)
        {
            return Math.Pow((desiredOutput - output), 2);
        }

        public decimal NormalizePoint(decimal min, decimal max, decimal nMin, decimal nMax, decimal value)
        {
            decimal part1 = (value - min) / (max - min);
            decimal part2 = (nMax - nMin);
            decimal part12 = part1 * part2;
            return part12 + nMin;
        }

        public decimal UnNormalizePoint(decimal min, decimal max, decimal nMin, decimal nMax, decimal value)
        {
            decimal part1 = (value - nMin) / (nMax - nMin);
            decimal part2 = (max) - (min);
            decimal part12 = part1 * part2;
            return part12 + min;
        }


        public List<(decimal, decimal)> NormalizeData(decimal nMinX, decimal nMaxX, decimal nMinY, decimal nMaxY, List<(decimal, decimal)> dataPoints)
        {
            decimal minX = dataPoints.Select(p => p.Item1).Min();
            decimal maxX = dataPoints.Select(p => p.Item1).Max();

            decimal minY = dataPoints.Select(p => p.Item2).Min();
            decimal maxY = dataPoints.Select(p => p.Item2).Max();

            //nMin and nMax are the minimum and maximums that you want as a programmer

            List<(decimal, decimal)> normalizedPoints = new List<(decimal, decimal)>();
            foreach ((decimal x, decimal y) in dataPoints)
            {
                normalizedPoints.Add((NormalizePoint(minX, maxX, nMinX, nMaxX, x), NormalizePoint(minY, maxY, nMinY, nMaxY, y)));
            }

            //Algorithm part
            return normalizedPoints;
        }

        public List<(decimal, decimal)> UnNormalizeData(decimal minX, decimal maxX, decimal minY, decimal maxY, List<(decimal, decimal)> normalizedData)
        {
            decimal nMinX = normalizedData.Select(p => p.Item1).Min();
            decimal nMaxX = normalizedData.Select(p => p.Item1).Max();

            decimal nMinY = normalizedData.Select(p => p.Item2).Min();
            decimal nMaxY = normalizedData.Select(p => p.Item2).Max();

            List<(decimal, decimal)> unNormalizedPoints = new List<(decimal, decimal)>();
            foreach ((decimal x, decimal y) in normalizedData)
            {
                unNormalizedPoints.Add((UnNormalizePoint(minX, maxX, nMinX, nMaxX, x), UnNormalizePoint(minY, maxY, nMinY, nMaxY, y)));
            }

            return unNormalizedPoints;
        }

        private void LinearRegression_Click(object sender, EventArgs e)
        {

            perceptron = new Perceptron(1, 0.1, random, MeanSquaredError);

            //Rest of the code for the linear regression. Use the library we have.

            LinearRegression.Enabled = false;

            int iterations = 0;

            //var doubleConversion = DoubleConversion(dataPoints);

            //var singleConversion = SingleConversion(dataPoints, 2);


            //while (iterations <= 1000000 && perceptron.GetError(doubleConversion, singleConversion) > 0.001)
            //{
            //    perceptron.TrainWithHillClimbing(doubleConversion, singleConversion, perceptron.GetError(doubleConversion, singleConversion));

            //    iterations++;
            //}

            //GraphLine();

            var normalizedPoints = NormalizeData(0, 1, 0, 1, dataPoints);

            var doubleConversion = DoubleConversion(normalizedPoints);

            var singleConversion = SingleConversion(normalizedPoints, 2);


            while (iterations <= 10000000 && perceptron.GetError(doubleConversion, singleConversion) > 0.001)
            {
                perceptron.TrainWithHillClimbing(doubleConversion, singleConversion, perceptron.GetError(doubleConversion, singleConversion));

                iterations++;

            }

            GraphNormalized(normalizedPoints);

            //GraphLineNormalized();
            GraphLineNormalized2();

            IterationCount.Text = iterations.ToString();

            //keep in mind that the bias is the y-intercept and the weights are the slope
            //make sure to repeat the hill climbing until you get within a certain amount of error or iterations



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

        public void GraphNormalized(List<(decimal, decimal)> normalizedPoints)
        {
            gfx.Clear(Color.White);

            //Axes lines
            gfx.DrawLine(new Pen(Color.Black), new Point(0, originY), new Point(canvasPictureBox.Width, originY));
            gfx.DrawLine(new Pen(Color.Black), new Point(originX, 0), new Point(originX, canvasPictureBox.Height));

            decimal minY = dataPoints.Select(p => p.Item2).Min();
            decimal maxY = dataPoints.Select(p => p.Item2).Max();

            decimal minX = dataPoints.Select(p => p.Item1).Min();
            decimal maxX = dataPoints.Select(p => p.Item1).Max();


            var unNormalizedPoints = UnNormalizeData(minX, maxX, minY, maxY, normalizedPoints);

            foreach (var point in unNormalizedPoints)
            {
                gfx.FillEllipse(Brushes.Black, (float)point.Item1, (float)point.Item2, 10, 10);
            }

            canvasPictureBox.Image = canvas;
        }

        public void GraphLineNormalized()
        {
            decimal slope = (decimal)perceptron.weights[0];
            //Note that if the function is increasing, it will have a negative slope because the y-coordinates are flipped in this type of window forms.
            //Remeber that the coordinate (0,0) is at the top left corner with x increasing as it moves to the right and y increasing as it moves down.
            //there is only one value in our weights array and that is the slope.
            decimal yInterceptNormalized = (decimal)perceptron.bias;
            //decimal yIntercept = UnNormalizePoint(0, canvasPictureBox.Height, 0, 1, yInterceptNormalized);

            decimal min = dataPoints.Select(p => p.Item2).Min();
            decimal max = dataPoints.Select(p => p.Item2).Max();

            var test = NormalizePoint(200, 600, 0, 1, -50);
            var untest = UnNormalizePoint(0, 999, 0, 1, test);

            //decimal yIntercept = UnNormalizePoint(min, max, 0, 1, yInterceptNormalized);

            //the bias is the y-intercept

            //var pointA = new Point(0, (int)LinearEquationSolver(-canvasPictureBox.Width / 2, slope, yIntercept));
            //var pointB = new Point(canvasPictureBox.Width, (int)LinearEquationSolver(canvasPictureBox.Width / 2, slope, yIntercept));

            var pointA = new Point(0, (int)LinearEquationSolver(-canvasPictureBox.Width / 2, slope, yInterceptNormalized));
            var pointB = new Point(canvasPictureBox.Width, (int)LinearEquationSolver(canvasPictureBox.Width / 2, slope, yInterceptNormalized));


            gfx.DrawLine(new Pen(Color.Black), pointA, pointB); ;

            canvasPictureBox.Image = canvas;
        }

        public void GraphLineNormalized2()
        {
            decimal slopeNormalized = (decimal)perceptron.weights[0];
            //Note that if the function is increasing, it will have a negative slope because the y-coordinates are flipped in this type of window forms.
            //Remeber that the coordinate (0,0) is at the top left corner with x increasing as it moves to the right and y increasing as it moves down.
            //there is only one value in our weights array and that is the slope.
            decimal yInterceptNormalized = (decimal)perceptron.bias;
            //decimal yIntercept = UnNormalizePoint(0, canvasPictureBox.Height, 0, 1, yInterceptNormalized);

            decimal minX = dataPoints.Select(p => p.Item1).Min();
            decimal maxX = dataPoints.Select(p => p.Item1).Max();

            decimal minY = dataPoints.Select(p => p.Item2).Min();
            decimal maxY = dataPoints.Select(p => p.Item2).Max();

            var pointAN = new Point(0, (int)LinearEquationSolver(0, slopeNormalized, yInterceptNormalized));
            var pointBN = new Point(1, (int)LinearEquationSolver(1, slopeNormalized, yInterceptNormalized));

            var pointA = new Point((int)UnNormalizePoint(minX, maxX, 0, 1, pointAN.X), (int)UnNormalizePoint(minY, maxY, 0, 1, pointAN.Y));
            var pointB = new Point((int)UnNormalizePoint(minX, maxX, 0, 1, pointBN.X), (int)UnNormalizePoint(minY, maxY, 0, 1, pointBN.Y));

            gfx.DrawLine(new Pen(Color.Black), pointA, pointB); ;

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
    }
}
