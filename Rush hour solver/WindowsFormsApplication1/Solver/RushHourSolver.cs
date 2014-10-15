///////////////////////////////////////////////////////
//Author: Thubie de Jong                             //
//Based on Java code from:http://ideone.com/el8rc    //
///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using NGenerics.DataStructures.Queues;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    class RushHourSolver
    {
        #region private members
        const int N = 6;         //Horizontal size
        const int M = 6;         //Vertical size
        const int GOAL_R = 2;    //Row where goal is 
        const int GOAL_C = 5;    //Column where goal is

        public Dictionary<string, string> predecessorMap; //Save game states(strings)and their previous state
        private Queue<string> queue;    //Queue for Breadth first Search
        private Stack<string> stack;    //Stack for depth first search
        List<GameStateNode> nextStates = new List<GameStateNode>();


        private const string HORZS = "5678ABCDEFGX";    //Horizontal cars
        private const string VERTS = "0123LMNOPQR";     //Vertical cars
        private const string LONGS = "01235678";       //Length cars 3
        private const string SHORTS = "ABCDEFGLMNOPQX"; //Length cars 2    
        private const char GOAL_CAR = 'X';              //Goal car
        const char EMPTY = '.';                         //Empty space, where cars can slide to
        const char VOID = '@';                          //represents everything out of bound
        #endregion

        #region Constructor(s)
        public RushHourSolver()
        {
            predecessorMap = new Dictionary<string, string>();
            queue = new Queue<string>();
            stack = new Stack<string>();
        }
        #endregion

        #region Helper Methods

        //2D to 1D index transformation(row major) 
        private int rc2i(int r, int c)
        {
            return r * N + c;               
        }

        //Check if an entity is of a given type
        bool isType(char entity, string type)
        {
            return type.IndexOf(entity) != -1;
        }

        //Finds the length of a car
        int length(char car)
        {
            if (isType(car, LONGS))
            {
                return 3;
            }
            else if (isType(car, SHORTS))
            {
                return 2;
            }
            else
                throw new Exception();
        }

        //Check if inbound
        bool inBound(int v, int max)
        {
            return (v >= 0) && (v < max);
        }

        //in given state returns the entity at a given coordinate,possible out of bound
        char at(string state, int r, int c)
        {
            return (inBound(r, M) && inBound(c, N)) ? state[rc2i(r, c)] : VOID;
        }

        //check if a given state is a goal state
        bool isGoal(string state)
        {
            return at(state, GOAL_R, GOAL_C) == GOAL_CAR; 
        }


        //In a given state, starting from given coordinate, toward the given direction
        //counts how many empty space there are(origin inclusive)
        //dr is direction row is either 1 for down or -1 for up
        //dc is direction column is either 1 for right and -1 for left
        int countSpaces(string state, int r, int c, int dr, int dc)
        {
            int k = 0;
            while (at(state, r + k * dr, c + k * dc) == EMPTY)
            {
                k++;
            }
            return k;
        }

        #endregion

        #region Methods

        //In a given state, from a given origin coordinate,attempts to find a car of a given type
        //at a given distance in a given direction. if found, slide it in the opposite direction
        //one spot at a time,exactly n times,proposing those states to the breadth first search
        //
        //example given
        //  direction = -->
        //  ___n___
        // /       \
        //...o.....c
        //   \____/
        //    distance
        void slide(string current, int r, int c, string type, int distance, int dr, int dc, int n)
        {
            r += (distance * dr);
            c += (distance * dc);
            char car = at(current, r, c);
            if (!isType(car, type))
                return;
            int L = length(car);
            StringBuilder sb = new StringBuilder(current);
            for (int i = 0; i < n; i++)
            {
                r -= dr;
                c -= dc;
                sb[rc2i(r, c)] = car;
                sb[rc2i(r + L * dr, c + L * dc)] = EMPTY;
                proposeAstar(sb.ToString(), current);
                current = sb.ToString();
            }
        }

        //explores a given state; searches for next level states in the breadth first search
        //
        //let(r,c) be the intersection point of this cross:

        //          @       nU = 3      '@' is not a car, 'B' and 'X' are of the wrong type;
        //          .       nD = 1      only '2' can slide to the right up to 5 spaces
        //        2.....B   nL = 2
        //          X       nR = 4
        //
        //The n? counts how many spaces are there in a given direction, origin inclusive.
        //Cars matching the type will then slide on these "alleys".
        void explore(string current)
        {
            for (int r = 0; r < M; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    if (at(current, r, c) != EMPTY)
                        continue;
                    int nU = countSpaces(current, r, c, -1, 0);
                    int nD = countSpaces(current, r, c, +1, 0);
                    int nL = countSpaces(current, r, c, 0, -1);
                    int nR = countSpaces(current, r, c, 0, +1);
                    slide(current, r, c, VERTS, nU, -1, 0, nU + nD - 1);
                    slide(current, r, c, VERTS, nD, +1, 0, nU + nD - 1);
                    slide(current, r, c, HORZS, nL, 0, -1, nL + nR - 1);
                    slide(current, r, c, HORZS, nR, 0, +1, nL + nR - 1);
                }
            }
        }

        #endregion

        #region A* search

        private void proposeAstar(string next, string prev)
        {
            if (!predecessorMap.ContainsKey(next))
            {
                predecessorMap.Add(next, prev);
                nextStates.Add(new GameStateNode(next));
            }

        }

        public List<GameStateNode> AstarSolve(GameStateNode startState,BaseHeuristics heuristics)
        {
            predecessorMap.Clear();
            return Astar(startState,heuristics);
        }

        private List<GameStateNode> Astar(GameStateNode startstate,BaseHeuristics heuristics)
        {
            PriorityQueue<GameStateNode,int>openSet = new PriorityQueue<GameStateNode,int>(PriorityQueueType.Minimum);
            List<GameStateNode> closedSet = new List<GameStateNode>();
            //The current node we are working on
            GameStateNode current = null;

            //save the f,g and h values
            int f_score = 0;

            //add start to open set
            openSet.Add(startstate);
            
            //The main loop to find the shortest route
            while (openSet.Count != 0)
            {
                nextStates.Clear();
                current = openSet.Dequeue();
                openSet.Remove(current);
                //If we found the goal reconstruct the path
                if(isGoal(current.getGameState()))
                {
                    openSet.Clear();
                    closedSet.Clear();
                    return ReconstructPath(current);
                }

                closedSet.Clear();
                
                //Get the list off next Game state the node has
                explore(current.getGameState());

                //For each GameStateNode in Next Game States 
                for (int i = 0; i < nextStates.Count; i++)
                {
                    GameStateNode nextState = nextStates[i];
                    //Calculate the G cost for current state
                    nextState.setGscore(current.getGscore() + 1);
                    //Calculate the H cost for current state
                    nextState.setHscore(heuristics.CalculateHeuristics(nextState));

                    if (closedSet.Contains(nextState))
                        continue;

                    if (openSet.Contains(nextState) && (nextState.getScore() > f_score))
                    {
                        nextState.setParent(null); 
                        openSet.Remove(nextState);
                    }

                    if (predecessorMap.ContainsKey(nextState.getGameState()) && (nextState.getScore() < f_score))
                    {
                        nextState.setParent(null);
                        predecessorMap.Remove(nextState.getGameState());
                        closedSet.Remove(nextState);
                    }

                    if (!(openSet.Contains(nextState)) && !(closedSet.Contains(nextState)))
                    {
                        f_score = nextState.getScore();
                        openSet.Add(nextState,nextState.getScore());
                        nextState.setParent(current);
                    }

                }
            }
            return null;
        }

        private List<GameStateNode> ReconstructPath(GameStateNode node)
        {
        //List to store the correct path
        List<GameStateNode>path = new List<GameStateNode>();
        
        //Loop to find the path
        while(node.parent!=null)
        {
            //Add node              
            path.Add(node);            
            //change node to current node it's parent till we find start 
            //Because it doesn't have a parent.            
            node = node.parent;
        }
        //Reverse path so we go from Start to end instead of end to start.
        path.Reverse();
        return path;  
    }
        
        #endregion
    }
}
