using System;
using System.Collections.Generic;
using System.Text;

namespace Luschny.Tree
{

    /**
     * Die Klasse TreeTraverse stellt einige Standard Methoden
     * zum Durchlaufen eines binaeren Baums zur Verfügung.
     * Man haette natuerlich auf das Idiom des Iterators zurueckgreifen
     * koennen, aber die Traverse (Idiom "Tour" und "Visite")
     * erscheint mir fuer Baeume das "natuerlichere" Konzept zu sein
     * (seit den Zeiten von L.Euler uebrigens).
     * 
     * @author Peter Luschny
     * @version 1.0, 2001-01-04
     */

    public class BinaryTreeTraversal<A>
    {
        public delegate void Visitor(A x);

        // Der zu durchlaufende Baum.
        private BinaryTree<A> tree;

        // Der default Besucher.
        public Visitor visit = BinaryTreeTraversal<A>.PrintValue;

        // Warteschlange, nur im Fall einer Level-Traverse gebraucht.
        private Queue<BinaryTree<A>.Node> queue;

        // Stack, nur im Fall einer Ast-Traverse gebraucht.
        private Stack<BinaryTree<A>.Node> stack;

        /**
         * Methoden zum Durchlaufen eines binaeren Baumes werden 
         * bereitgestellt.
         * 
         * @param tree der zu durchlaufende Baum
         */

        public BinaryTreeTraversal(BinaryTree<A> tree)
        {
            this.tree = tree;
        }

        /**
         * Traversieren in Praeordnung.
         */

        public void PreorderLRTraversal()
        {
            PreorderLRVisit(tree.GetRoot());
        }

        public void PreorderRLTraversal()
        {
            PreorderRLVisit(tree.GetRoot());
        }

        /**
         * Traversieren in Inordnung.
         */

        public void InorderLRTraversal()
        {
            InorderLRVisit(tree.GetRoot());
        }

        public void InorderRLTraversal()
        {
            InorderRLVisit(tree.GetRoot());
        }

        /**
         * Traversieren in Postordnung.
         */

        public void PostorderLRTraversal()
        {
            PostorderLRVisit(tree.GetRoot());
        }

        public void PostorderRLTraversal()
        {
            PostorderRLVisit(tree.GetRoot());
        }

        /**
         * Traversieren in Levelordnung. 
         * Auch als 'breadth-first traversal' bekannt.
         */

        public void LevelorderLRTraversal()
        {
            queue = new Queue<BinaryTree<A>.Node>();
            LevelorderLRVisit(tree.GetRoot());
        }

        public void LevelorderRLTraversal()
        {
            queue = new Queue<BinaryTree<A>.Node>();
            LevelorderRLVisit(tree.GetRoot());
        }

        /**
         * Traversieren in Astordnung. 
         * Auch als 'depth-first traversal' bekannt.
         */

        public void BranchorderLRTraversal()
        {
            stack = new Stack<BinaryTree<A>.Node>();
            BranchorderLRVisit(tree.GetRoot());
        }

        public void BranchorderRLTraversal()
        {
            stack = new Stack<BinaryTree<A>.Node>();
            BranchorderRLVisit(tree.GetRoot());
        }

        /**
         * rekursiv!
         * 
         * @param parent, der Elterknoten.
         */

        private void PreorderLRVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                visit(tree.GetValue(parent));
                PreorderLRVisit(tree.GetLeftChild(parent));
                PreorderLRVisit(tree.GetRightChild(parent));
            }
        }

        /**
         * rekursiv!
         * 
         * @param parent, der Elterknoten
         */

        private void PreorderRLVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                visit(tree.GetValue(parent));
                PreorderRLVisit(tree.GetRightChild(parent));
                PreorderRLVisit(tree.GetLeftChild(parent));
            }
        }

        /**
         * rekursiv!
         * 
         * @param parent
         */

        private void InorderLRVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                InorderLRVisit(tree.GetLeftChild(parent));
                visit(tree.GetValue(parent));
                InorderLRVisit(tree.GetRightChild(parent));
            }
        }

        private void InorderRLVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                InorderRLVisit(tree.GetRightChild(parent));
                visit(tree.GetValue(parent));
                InorderRLVisit(tree.GetLeftChild(parent));
            }
        }

        /**
         * rekursiv!
         * 
         * @param parent, der Elterknoten.
         */

        private void PostorderLRVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                PostorderLRVisit(tree.GetLeftChild(parent));
                PostorderLRVisit(tree.GetRightChild(parent));
                visit(tree.GetValue(parent));
            }
        }

        private void PostorderRLVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                PostorderRLVisit(tree.GetRightChild(parent));
                PostorderRLVisit(tree.GetLeftChild(parent));
                visit(tree.GetValue(parent));
            }
        }

        /**
         * rekursiv!
         * 
         * @param parent, der Elterknoten.
         */

        private void LevelorderRLVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                var c = tree.GetRightChild(parent);
                if (c.IsValid())
                {
                    queue.Enqueue(c);
                }
                c = tree.GetLeftChild(parent);
                if (c.IsValid())
                {
                    queue.Enqueue(c);
                }

                visit(tree.GetValue(parent));

                if (queue.Count != 0)
                {
                    LevelorderRLVisit(queue.Dequeue());
                }
            }
        }

        private void LevelorderLRVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                var c = tree.GetLeftChild(parent);
                if (c.IsValid())
                {
                    queue.Enqueue(c);
                }
                c = tree.GetRightChild(parent);
                if (c.IsValid())
                {
                    queue.Enqueue(c);
                }

                visit(tree.GetValue(parent));

                if (queue.Count != 0)
                {
                    LevelorderLRVisit(queue.Dequeue());
                }
            }
        }

        private void BranchorderRLVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                var c = tree.GetRightChild(parent);
                if (c.IsValid())
                {
                    stack.Push(c);
                }
                c = tree.GetLeftChild(parent);
                if (c.IsValid())
                {
                    stack.Push(c);
                }

                visit(tree.GetValue(parent));

                if (stack.Count != 0)
                {
                    BranchorderRLVisit(stack.Pop());
                }
            }
        }

        private void BranchorderLRVisit(BinaryTree<A>.Node parent)
        {
            if (parent.IsValid())
            {
                var c = tree.GetLeftChild(parent);
                if (c.IsValid())
                {
                    stack.Push(c);
                }
                c = tree.GetRightChild(parent);
                if (c.IsValid())
                {
                    stack.Push(c);
                }

                visit(tree.GetValue(parent));

                if (stack.Count != 0)
                {
                    BranchorderLRVisit(stack.Pop());
                }
            }
        }

        /**
         * Anreichung des Wertes eines Baumknotens während der Traverse.
         * Hier Console.Write(value.toString()) implementiert.
         * Zum Ueberschreiben durch eine Bearbeitungsfunktion vorgesehen.
         * 
         * @param value Wert (des zu bearbeitenden) Baumknotens
         */

        public static void PrintValue(A list)
        {
            Console.WriteLine();
            if (list is IList<int>)
            {
                var builder = new StringBuilder();
                IList<int> L = (IList<int>)list;

                foreach (var item in L)
                {
                    builder.Append(item).Append(" ");
                }
                string result = builder.ToString();
                Console.Write(result);
            }
            else Console.Write(list.ToString() + " ");
        }
    }
}