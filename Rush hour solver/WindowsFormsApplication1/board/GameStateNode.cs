using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    class GameStateNode : IComparable<GameStateNode>
    {
        public string gameState;
        public int g_score;
        public int h_score;

        public GameStateNode parent = null;

        public GameStateNode(string gameState)
        {
            this.gameState = gameState;
            this.g_score = 0;
            this.h_score = 0;
        }
        
        #region Getters and Setters 

        public int getScore()
        {
            return g_score + h_score;
        }

        public string getGameState()
        {
            return gameState;
        }

        public void setGamestate(string gameState)
        {
            this.gameState = gameState;
        }

        public void setGscore(int g_score)
        {
            this.g_score = g_score;
        }

        public int getGscore()
        {
            return g_score;
        }

        public void setHscore(int h_score)
        {
            this.h_score = h_score;
        }

        public int getHscore()
        {
            return h_score;
        }

        public void setParent(GameStateNode parent)
        {
            this.parent = parent;
        }
        #endregion

        public int Compare(GameStateNode y)
        {
            return this.getScore() - y.getScore();
        }

        //public int CompareTo(GameStateNode compare)
        //{
        //    return this.getScore() - compare.getScore();
        //}

        public int CompareTo(GameStateNode other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;

            // The temperature comparison depends on the comparison of 
            // the underlying Double values. 
            return this.getScore().CompareTo(other.getScore());
        }
    }
}
