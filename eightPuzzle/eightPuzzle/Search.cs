using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eightPuzzle
{
    class Search
    {
        public Search()
        {

        }

        public static bool containsChild(List<Node> list, Node c)
        {
            bool isContainChild = false;
            for(int i=0;i<list.Count;i++)
            {
                if(list[i].isSamePuzzle(c.puzzle))
                {
                    isContainChild = true;
                    break;
                }
            }
            return isContainChild;
        }
        public List<Node> BFS(Node root)
        {
            Node currentNode;
            bool goalFound = false;
            List<Node> Path = new List<Node>();
            List<Node> frontier = new List<Node>();
            List<Node> explored = new List<Node>();
            frontier.Add(root);
            while(frontier.Count>0 && !goalFound)
            {
                currentNode = frontier[0];
                frontier.RemoveAt(0);
                //same as dequeue
                explored.Add(currentNode);
                if(currentNode.isGoal())
                {
                    Console.WriteLine("goal found by BFS");
                    goalFound = true;
                    this.pathTrace(Path, currentNode);
                }
                currentNode.ExpandNode();
                currentNode.displayPuzzle();
                foreach(var x in currentNode.children)
                {
                    if (!containsChild(frontier, x) && !containsChild(explored, x))
                    {
                        frontier.Add(x);
                    }
                }

            }
            return Path;
        }

        /*
        public List<Node> BFS(Node root)
        {
            List<Node> Path = new List<Node>();
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            openList.Add(root);
            bool goolFound = false;

            while (openList.Count > 0 && !goolFound)
            {
                Node currentNode = openList[0];
                closedList.Add(currentNode);
                openList.RemoveAt(0);

                currentNode.ExpandNode();
                currentNode.displayPuzzle();
                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.isGoal())
                    {
                        Console.WriteLine("Goal found....");
                        goolFound = true;
                        this.pathTrace(Path, currentChild);
                    }
                    if (!containsChild(openList, currentChild) && !containsChild(closedList, currentChild))
                    {
                        openList.Add(currentChild);
                    }
                }
            }
            return Path;
        }

    */
        public List<Node> DFS(Node root)
        {
            Node currentNode;
            bool goalFound = false;
            List<Node> Path = new List<Node>();
            List<Node> frontier = new List<Node>();
            List<Node> explored = new List<Node>();
            frontier.Add(root);
            while (frontier.Count > 0 && !goalFound)
            {
                currentNode = frontier[frontier.Count - 1];
                frontier.RemoveAt(frontier.Count - 1);
                //same as pop
                explored.Add(currentNode);
                if (currentNode.isGoal())
                {
                    Console.WriteLine("goal found by BFS");
                    goalFound = true;
                    this.pathTrace(Path, currentNode);
                }
                currentNode.ExpandNode();
                currentNode.displayPuzzle();
                foreach (var x in currentNode.children)
                {
                    if (!containsChild(frontier, x) && !containsChild(explored, x))
                    {
                        frontier.Add(x);
                    }
                }

            }
            return Path;
        }
        public void pathTrace(List<Node> path,Node n)
        {
            Console.WriteLine("tracing path...");
            Node currentNode = n;
            path.Add(currentNode);
            while (currentNode.parent !=null)
            {
                currentNode = currentNode.parent;
                path.Add(currentNode);
            }
        }


    }
}
