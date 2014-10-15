namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.previous = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Solve = new System.Windows.Forms.Button();
            this.StepsTaken = new System.Windows.Forms.Label();
            this.stepscount = new System.Windows.Forms.Label();
            this.statesExplored = new System.Windows.Forms.Label();
            this.StatesCount = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Label();
            this.TimeCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(77, 314);
            this.previous.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(56, 19);
            this.previous.TabIndex = 1;
            this.previous.Text = "previous";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(137, 314);
            this.next.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(56, 19);
            this.next.TabIndex = 2;
            this.next.Text = "next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "puzzle 1",
            "puzzle 2",
            "puzzle 3",
            "puzzle 4",
            "puzzle 5",
            "puzzle 6",
            "puzzle 7",
            "puzzle 8"});
            this.listBox1.Location = new System.Drawing.Point(313, 10);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(107, 199);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Solve
            // 
            this.Solve.Location = new System.Drawing.Point(343, 265);
            this.Solve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(56, 19);
            this.Solve.TabIndex = 4;
            this.Solve.Text = "Solve";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.Solve_Click);
            // 
            // StepsTaken
            // 
            this.StepsTaken.AutoSize = true;
            this.StepsTaken.Location = new System.Drawing.Point(245, 316);
            this.StepsTaken.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StepsTaken.Name = "StepsTaken";
            this.StepsTaken.Size = new System.Drawing.Size(70, 13);
            this.StepsTaken.TabIndex = 5;
            this.StepsTaken.Text = "Steps taken: ";
            // 
            // stepscount
            // 
            this.stepscount.AutoSize = true;
            this.stepscount.Location = new System.Drawing.Point(315, 316);
            this.stepscount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stepscount.Name = "stepscount";
            this.stepscount.Size = new System.Drawing.Size(0, 13);
            this.stepscount.TabIndex = 6;
            // 
            // statesExplored
            // 
            this.statesExplored.AutoSize = true;
            this.statesExplored.Location = new System.Drawing.Point(245, 339);
            this.statesExplored.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statesExplored.Name = "statesExplored";
            this.statesExplored.Size = new System.Drawing.Size(83, 13);
            this.statesExplored.TabIndex = 7;
            this.statesExplored.Text = "States explored:";
            // 
            // StatesCount
            // 
            this.StatesCount.AutoSize = true;
            this.StatesCount.Location = new System.Drawing.Point(328, 339);
            this.StatesCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatesCount.Name = "StatesCount";
            this.StatesCount.Size = new System.Drawing.Size(0, 13);
            this.StatesCount.TabIndex = 8;
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Location = new System.Drawing.Point(245, 364);
            this.Timer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(72, 13);
            this.Timer.TabIndex = 9;
            this.Timer.Text = "Time needed:";
            // 
            // TimeCounter
            // 
            this.TimeCounter.AutoSize = true;
            this.TimeCounter.Location = new System.Drawing.Point(325, 364);
            this.TimeCounter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeCounter.Name = "TimeCounter";
            this.TimeCounter.Size = new System.Drawing.Size(0, 13);
            this.TimeCounter.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 225);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Heuristics";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Blocking",
            "Null",
            "ToGoal"});
            this.comboBox1.Location = new System.Drawing.Point(328, 240);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.Text = "Blocking";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 399);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeCounter);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.StatesCount);
            this.Controls.Add(this.statesExplored);
            this.Controls.Add(this.stepscount);
            this.Controls.Add(this.StepsTaken);
            this.Controls.Add(this.Solve);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.next);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "RushHourSolver";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Solve;
        private System.Windows.Forms.Label StepsTaken;
        private System.Windows.Forms.Label stepscount;
        private System.Windows.Forms.Label statesExplored;
        private System.Windows.Forms.Label StatesCount;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Label TimeCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

