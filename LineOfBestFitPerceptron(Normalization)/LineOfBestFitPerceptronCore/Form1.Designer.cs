
namespace LineOfBestFitPerceptronCoreNormalization
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvasPictureBox = new System.Windows.Forms.PictureBox();
            this.slopeLabel = new System.Windows.Forms.Label();
            this.yInterceptLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.RandomAdd = new System.Windows.Forms.Button();
            this.LinearRegression = new System.Windows.Forms.Button();
            this.xValue = new System.Windows.Forms.NumericUpDown();
            this.yValue = new System.Windows.Forms.NumericUpDown();
            this.Iterations = new System.Windows.Forms.Label();
            this.IterationCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValue)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasPictureBox
            // 
            this.canvasPictureBox.Location = new System.Drawing.Point(46, 44);
            this.canvasPictureBox.Name = "canvasPictureBox";
            this.canvasPictureBox.Size = new System.Drawing.Size(449, 382);
            this.canvasPictureBox.TabIndex = 0;
            this.canvasPictureBox.TabStop = false;
            this.canvasPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvasPictureBox_MouseClick);
            // 
            // slopeLabel
            // 
            this.slopeLabel.AutoSize = true;
            this.slopeLabel.Enabled = false;
            this.slopeLabel.Location = new System.Drawing.Point(518, 73);
            this.slopeLabel.Name = "slopeLabel";
            this.slopeLabel.Size = new System.Drawing.Size(39, 15);
            this.slopeLabel.TabIndex = 1;
            this.slopeLabel.Text = "Slope:";
            this.slopeLabel.Visible = false;
            // 
            // yInterceptLabel
            // 
            this.yInterceptLabel.AutoSize = true;
            this.yInterceptLabel.Enabled = false;
            this.yInterceptLabel.Location = new System.Drawing.Point(520, 118);
            this.yInterceptLabel.Name = "yInterceptLabel";
            this.yInterceptLabel.Size = new System.Drawing.Size(69, 15);
            this.yInterceptLabel.TabIndex = 2;
            this.yInterceptLabel.Text = "Y-intercept:";
            this.yInterceptLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(668, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input a point:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(631, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "x:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(631, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "y:";
            this.label3.Visible = false;
            // 
            // Add
            // 
            this.Add.Enabled = false;
            this.Add.Location = new System.Drawing.Point(631, 143);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(141, 79);
            this.Add.TabIndex = 8;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Visible = false;
            // 
            // RandomAdd
            // 
            this.RandomAdd.Enabled = false;
            this.RandomAdd.Location = new System.Drawing.Point(631, 228);
            this.RandomAdd.Name = "RandomAdd";
            this.RandomAdd.Size = new System.Drawing.Size(141, 79);
            this.RandomAdd.TabIndex = 9;
            this.RandomAdd.Text = "Add a Random Point";
            this.RandomAdd.UseVisualStyleBackColor = true;
            this.RandomAdd.Visible = false;
            // 
            // LinearRegression
            // 
            this.LinearRegression.Location = new System.Drawing.Point(631, 325);
            this.LinearRegression.Name = "LinearRegression";
            this.LinearRegression.Size = new System.Drawing.Size(141, 79);
            this.LinearRegression.TabIndex = 10;
            this.LinearRegression.Text = "Regress";
            this.LinearRegression.UseVisualStyleBackColor = true;
            this.LinearRegression.Click += new System.EventHandler(this.LinearRegression_Click);
            // 
            // xValue
            // 
            this.xValue.Enabled = false;
            this.xValue.Location = new System.Drawing.Point(652, 66);
            this.xValue.Name = "xValue";
            this.xValue.Size = new System.Drawing.Size(120, 23);
            this.xValue.TabIndex = 11;
            this.xValue.Visible = false;
            // 
            // yValue
            // 
            this.yValue.Enabled = false;
            this.yValue.Location = new System.Drawing.Point(652, 92);
            this.yValue.Name = "yValue";
            this.yValue.Size = new System.Drawing.Size(120, 23);
            this.yValue.TabIndex = 12;
            this.yValue.Visible = false;
            // 
            // Iterations
            // 
            this.Iterations.AutoSize = true;
            this.Iterations.Location = new System.Drawing.Point(518, 182);
            this.Iterations.Name = "Iterations";
            this.Iterations.Size = new System.Drawing.Size(59, 15);
            this.Iterations.TabIndex = 13;
            this.Iterations.Text = "Iterations:";
            // 
            // IterationCount
            // 
            this.IterationCount.AutoSize = true;
            this.IterationCount.Location = new System.Drawing.Point(518, 206);
            this.IterationCount.Name = "IterationCount";
            this.IterationCount.Size = new System.Drawing.Size(13, 15);
            this.IterationCount.TabIndex = 14;
            this.IterationCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IterationCount);
            this.Controls.Add(this.Iterations);
            this.Controls.Add(this.yValue);
            this.Controls.Add(this.xValue);
            this.Controls.Add(this.LinearRegression);
            this.Controls.Add(this.RandomAdd);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yInterceptLabel);
            this.Controls.Add(this.slopeLabel);
            this.Controls.Add(this.canvasPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvasPictureBox;
        private System.Windows.Forms.Label slopeLabel;
        private System.Windows.Forms.Label yInterceptLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button RandomAdd;
        private System.Windows.Forms.Button LinearRegression;
        private System.Windows.Forms.NumericUpDown xValue;
        private System.Windows.Forms.NumericUpDown yValue;
        private System.Windows.Forms.Label Iterations;
        private System.Windows.Forms.Label IterationCount;
    }
}

