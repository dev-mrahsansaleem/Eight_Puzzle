using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eightPuzzle
{
    class Node
    {
        //public static int puzzleSize=9;
        public static int puzzleSize;
        //public int columns = 3;
        public int columns;

        public List<Node> children = new List<Node>();
        public Node parent;
        public int[] puzzle;
        public int x = 0;
        public string action = "";
        public Node(int[] myPuzzle, int ps, int col)
        {
            puzzleSize = ps;
            columns = col;
            puzzle = new int[puzzleSize];
            setPuzzle(myPuzzle);
        }
        public void setPuzzle(int[] p)
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                this.puzzle[i] = p[i];
            }
        }
        public void copyPuzzle(int[] a, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                a[i] = b[i];
            }
        }
        public void wait()
        {
            for (int i = 0; i < 9000000; i++)
                Console.Write("");
        }
        public void ExpandNode()
        {
            for (int i = 0; i < this.puzzle.Length; i++)
            {
                if (this.puzzle[i] == 0)
                    x = i;
            }
            this.moveToRight(this.puzzle, x);

            this.moveToLeft(this.puzzle, x);

            this.moveToUp(this.puzzle, x);

            this.moveToDown(this.puzzle, x);

        }
        public void moveToRight(int[] p, int i)
        {
            if (i % this.columns < this.columns - 1)
            {
                int[] pc = new int[puzzleSize];
                copyPuzzle(pc, p);

                int temp = pc[i + 1];
                pc[i + 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc,puzzleSize,this.columns);
                child.action = "right";
                this.children.Add(child);

                child.parent = this;
            }

        }
        public void moveToLeft(int[] p, int i)
        {
            if (i % this.columns > 0)
            {
                int[] pc = new int[puzzleSize];
                copyPuzzle(pc, p);

                int temp = pc[i - 1];
                pc[i - 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc, puzzleSize, this.columns);
                child.action = "left";
                this.children.Add(child);

                child.parent = this;
            }
        }
        public void moveToUp(int[] p, int i)
        {
            if (i - this.columns >= 0)
            {
                int[] pc = new int[puzzleSize];
                copyPuzzle(pc, p);

                int temp = pc[i - this.columns];
                pc[i - this.columns] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc, puzzleSize, this.columns);
                child.action = "up";
                this.children.Add(child);

                child.parent = this;
            }
        }
        public void moveToDown(int[] p, int i)
        {
            if (i + this.columns < puzzle.Length)
            {
                int[] pc = new int[puzzleSize];
                copyPuzzle(pc, p);

                int temp = pc[i + this.columns];
                pc[i + this.columns] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc, puzzleSize, this.columns);
                child.action = "down";
                this.children.Add(child);

                child.parent = this;
            }
        }
        public bool isGoal()
        {
            bool isGoal = true;
            int m = this.puzzle[0];

            for (int i = 1; i < puzzle.Length; i++)
            {
                if (m > this.puzzle[i])
                {
                    isGoal = false;
                    break;
                }
                m = this.puzzle[i];
            }
            return isGoal;
        }
        public void displayPuzzle()
        {
            Console.WriteLine();
            int m = 0;
            for(int i=0;i<this.columns;i++)
            {
                for(int j = 0; j < this.columns; j++)
                {
                    Console.Write(" " + this.puzzle[m].ToString() + " |");
                    m++;
                }
                Console.WriteLine();
            }
        }
        public bool isSamePuzzle(int[] p)
        {
            bool samePuzzle = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (this.puzzle[i] != p[i])
                {
                    samePuzzle = false;
                    break;
                }
            }
            return samePuzzle;
        }




        //ends here class scope
    }
}
