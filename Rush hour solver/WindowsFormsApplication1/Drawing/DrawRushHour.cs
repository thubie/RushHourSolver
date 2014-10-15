using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class DrawRushHour
    {
        #region private

        private Bitmap previous;
        private Bitmap next;
        List<GameStateNode> steps = new List<GameStateNode>();
        int currentState = 0;
        private const string HORZS = "5678ABCDEFGX";    //Horizontal cars
        private const string VERTS = "0123LMNOPQR";     //Vertical cars
        private const string LONGS = "012345678";       //Length cars 3
        private const string SHORTS = "ABCDEFGLMNOPQY"; //Length cars 2    
        private const char GOAL_CAR = 'X';              //Goal car
        GameStateNode initialState;
        #endregion

        //Constructor
        public DrawRushHour(string initialState)
        {
            previous = new Bitmap(300, 300);
            next = new Bitmap(300, 300);
            this.initialState = new GameStateNode(initialState);
            steps.Add(new GameStateNode(initialState));
            InitGrid();     
        }

        //update game state so we can draw new puzzle
        public void updateInitial(GameStateNode initialState)
        {
            currentState = 0;
            this.initialState = initialState;
            this.steps = new List<GameStateNode>();
            this.steps.Add(this.initialState);
            DrawNext(next);
            DrawGrid(next);
            DrawPrevious(previous);
            DrawGrid(previous);   
        }

        //Set the List of game states
        public void setGameStates(List<GameStateNode>steps)
        {
            this.steps = steps;
            this.steps.Insert(0, initialState);
        }

        //Initialize grid
        private void InitGrid()
        {
            DrawNext(next);
            DrawGrid(next);
            DrawPrevious(previous);
            DrawGrid(previous);
        }

        //Return Next
        public Bitmap GetNext()
        {
            if (steps.Count == 1)
            {
                MessageBox.Show("Need a solution first!");
            }
            if (currentState >= 0 && currentState < steps.Count)
            {
                currentState++;
            }
            previous = next;
            DrawNext(next);
            DrawGrid(next);

            return next;
        }

        //Return previous 
        public Bitmap GetPrevious()
        {
            if (steps.Count == 1)
            {
                MessageBox.Show("Need a solution first!");
            }

            if (currentState > 0 && currentState <= steps.Count)
            {
                currentState--;
                DrawPrevious(previous);
                DrawGrid(previous);
            }
            return previous;
        }

        public Bitmap GetStart()
        {
            currentState = 0;
            return previous;
        }

        #region Drawing
        //Draw grid
        private void DrawGrid(Bitmap input)
        {
            for (int i = 0; i < 300; i++) //horizontal lines
            {
                for (int j = 0; j < 300; j++) //Vertical lines
                {
                    if ((i == 0 || j == 0) || (i == 49 || j == 49) || (i == 99 || j == 99) || (i == 149 || j == 149) || (i == 199 || j == 199) || (i == 249 || j == 249) || (i == 299 || j == 299))
                    {
                        input.SetPixel(i, j, Color.Black);
                    }
                }
            }
        }

        //Draw board Colors
        private void DrawBoard(Bitmap input, string gamestate)
        {
            for (int i = 0; i < 6; i++) //loop for reading the string and sectors
            {
                for (int j = 0; j < 6; j++)
                {
                    char color = gamestate[j * 6 + i]; //Get the color character 
                    DrawSection(input, color, i, j);
                }
            }
        }

        //Draw section
        private void DrawSection(Bitmap input, char c, int sectionI, int sectionJ)
        {

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    //Check special characters
                    if (c == 'X')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Red);
                    }

                    if (c == '.')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Transparent);
                    }

                    //check Long Horizontal
                    if (c == '0')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Blue);
                    }
                    if (c == '1')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.BlanchedAlmond);
                    }

                    if (c == '2')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.BlueViolet);
                    }
                    if (c == '3')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Purple);
                    }

                    //Check Long Vertical
                    if (c == '5')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Orange);
                    }
                    if (c == '6')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Yellow);
                    }

                    if (c == '7')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Orchid);
                    }
                    if (c == '8')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.PaleGreen);
                    }

                    //check short horizontal

                    if (c == 'A')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.PaleTurquoise);
                    }
                    if (c == 'B')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.PaleVioletRed);
                    }

                    if (c == 'C')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Green);
                    }
                    if (c == 'D')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.GreenYellow);
                    }

                    if (c == 'E')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.MediumSlateBlue);
                    }
                    if (c == 'F')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.IndianRed);
                    }

                    if (c == 'G')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Indigo);
                    }

                    //Check Short vertical
                    if (c == 'L')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.LightSkyBlue);
                    }

                    if (c == 'M')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.LightSteelBlue);
                    }
                    if (c == 'N')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.LimeGreen);
                    }

                    if (c == 'O')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Magenta);
                    }
                    if (c == 'P')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.Maroon);
                    }
                    if (c == 'Q')
                    {
                        input.SetPixel((i + sectionI * 50), (j + sectionJ * 50), Color.MediumAquamarine);
                    }
                }
            }
        }

        //Draw previous
        public void DrawPrevious(Bitmap input)
        {
            if (currentState >= 0)
                DrawBoard(input, steps[currentState].gameState);
            else
                return;
        }

        //Draw Next
        public void DrawNext(Bitmap input)
        {
            if (currentState <= steps.Count - 1)
                DrawBoard(input, steps[currentState].gameState);
            else
                return;
        }
        #endregion
    }
}
