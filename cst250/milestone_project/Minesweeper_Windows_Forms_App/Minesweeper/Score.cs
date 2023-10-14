using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Score
    {
        private double score;
        private string difficulty;
        private int mapSize;
        private string now;

        public Score(double score, string difficulty, int mapSize, string now)
        {
            this.score = score;
            this.now = now;
            this.difficulty = difficulty;
            this.mapSize = mapSize;
        }

        public string GetDate() { return this.now; }
        public string GetDifficulty() { return this.difficulty; }
        public double GetScore() { return this.score; }

        public override string ToString()
        {
            return score + " | " + difficulty + " | " + mapSize + " | " + now;
        }
    }
}
