using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        const string setup1 =   "555L01" +
                                "MAAL01" +
                                "M.XX01" +
                                "BBN..." +
                                ".ON.CC" +
                                ".OEEDD";

        const string setup2 =   "B..333" + 
                                "B333CC" + 
                                "XXBBCC" + 
                                "22BBCC" + 
                                "...B22" + 
                                ".22B..";


        List<GameStateNode> steps;
        DrawRushHour rushHourDrawer;
        RushHourSolver rhs;
        StartStates puzzellist;
        GameStateNode startGameState;

        public Form1()
        {
            InitializeComponent();
            puzzellist = new StartStates();
            startGameState = new GameStateNode(puzzellist.getPuzzle(2));
            rushHourDrawer = new DrawRushHour(puzzellist.getPuzzle(2));
            rhs = new RushHourSolver();
            pictureBox1.Image = rushHourDrawer.GetStart();           
        }

        private void previous_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = rushHourDrawer.GetPrevious();
        }

        private void next_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = rushHourDrawer.GetNext();
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            float start, end;
            
            string heuristic = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (heuristic == "Blocking")
            {
                rushHourDrawer.updateInitial(startGameState);
                pictureBox1.Image = rushHourDrawer.GetStart();
                start = Stopwatch.GetTimestamp();
                this.steps = rhs.AstarSolve(startGameState, new BlockingHeuristics());
                end = Stopwatch.GetTimestamp();
                rushHourDrawer.setGameStates(steps);
                stepscount.Text = this.steps.Count.ToString();
                TimeCounter.Text = ((end - start) / Stopwatch.Frequency).ToString() + " sec";
                StatesCount.Text = rhs.predecessorMap.Count.ToString() + " states";
            }

            if (heuristic == "Null")
            {
                rushHourDrawer.updateInitial(startGameState);
                pictureBox1.Image = rushHourDrawer.GetStart();
                start = Stopwatch.GetTimestamp();
                this.steps = rhs.AstarSolve(startGameState, new NullHeuristics());
                end = Stopwatch.GetTimestamp();
                rushHourDrawer.setGameStates(steps);
                stepscount.Text = this.steps.Count.ToString();
                TimeCounter.Text = ((end - start) / Stopwatch.Frequency).ToString() + " sec";
                StatesCount.Text = rhs.predecessorMap.Count.ToString() + " states";
            }

            if (heuristic == "ToGoal")
            {
                rushHourDrawer.updateInitial(startGameState);
                pictureBox1.Image = rushHourDrawer.GetStart();
                start = Stopwatch.GetTimestamp();
                this.steps = rhs.AstarSolve(startGameState, new ToGoalHeuristics());
                end = Stopwatch.GetTimestamp();
                rushHourDrawer.setGameStates(steps);
                stepscount.Text = this.steps.Count.ToString();
                TimeCounter.Text = ((end - start) / Stopwatch.Frequency).ToString() + " sec";
                StatesCount.Text = rhs.predecessorMap.Count.ToString() + " states";
            }
                
            
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string puzzleSelected = listBox1.SelectedItem.ToString();
            startGameState = new GameStateNode(puzzellist.getPuzzle((int)puzzleSelected[7] - 49));
            rushHourDrawer.updateInitial(startGameState);
            pictureBox1.Image = rushHourDrawer.GetStart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
