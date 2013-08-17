/// -------  ToujoursEnBeta
/// Author & Copyright : Peter Luschny
/// License: Creative Commons Attribution-ShareAlike 3.0
/// Comments mail to: peter(at)luschny.de
/// Created: 2013-08-16

namespace Luschny.Tree
{
    using System;
    using System.Collections.Generic;
    using Tour = Luschny.Tree.BinaryTreeTraversal<System.Collections.Generic.List<int>>;
    using PartitionTree = Luschny.Tree.BinaryTree<System.Collections.Generic.List<int>>;
    using Partition = System.Collections.Generic.List<int>;
    using OeisPartition = System.Tuple<string, Luschny.Tree.PartitionTreeShowcase.Traversal, Luschny.Tree.PartitionTreeShowcase.Visitor, Luschny.Tree.PartitionTreeShowcase.Direction>;

    public static class PartitionTreeShowcase
    {
        // Provides the set of values by which a binary tree can be enumerated.

        public enum Traversal
        {
            PreOrder, InOrder, PostOrder, LevelOrder, BranchOrder
        }

        public enum Visitor
        {
            Partition, Conjugate, Reverse, ReverseConjugate
        }

        public enum Direction
        {
            RightLeft, // clockwise traversal
            LeftRight  // counterclockwise traversal
        }

        public static OeisPartition[] oeis = {
            new OeisPartition("A228100 (Fenner-Loizou tree, level order)",
                Traversal.PostOrder, Visitor.Conjugate, Direction.RightLeft),
            new OeisPartition("A036036 (Hindenburg, Abramowitz-Stegun)",
                Traversal.PreOrder,  Visitor.ReverseConjugate, Direction.LeftRight),
            new OeisPartition("A080577 (Mathematica, Sage, Magma)",
                Traversal.PostOrder, Visitor.Partition, Direction.RightLeft),
            new OeisPartition("A080576 (Maple)",
                Traversal.PreOrder,  Visitor.Reverse,   Direction.LeftRight),
            new OeisPartition("A036037", 
                Traversal.PreOrder,  Visitor.Conjugate, Direction.LeftRight),
            new OeisPartition("A182937", 
                Traversal.PreOrder,  Visitor.Partition, Direction.RightLeft),
            new OeisPartition("A193073", 
                Traversal.PreOrder,  Visitor.Partition, Direction.LeftRight)
        };

        public delegate bool Filter(Partition x);
        private static Filter filter;

        public static void Traverse(Tour tour, Traversal tm, Visitor vm, Direction d, Filter f = null)
        {
            WriteHeader(tm.ToString() + " - " + vm.ToString() + " - " + d.ToString());

            if (f == null) filter = v => true; else filter = f;

            switch (vm)
            {
                case Visitor.Partition: tour.visit = StandardPartition; break;
                case Visitor.Conjugate: tour.visit = ConjugatedPartition; break;
                case Visitor.Reverse: tour.visit = ReversedPartition; break;
                case Visitor.ReverseConjugate: tour.visit = ReversedConjugatedPartition; break;
                default: tour.visit = PrintPartition; break;
            }

            switch (tm)
            {
                case Traversal.PreOrder:
                    if (d == Direction.LeftRight) tour.PreorderLRTraversal();
                    else tour.PreorderRLTraversal();
                    break;
                case Traversal.InOrder:
                    if (d == Direction.LeftRight) tour.InorderLRTraversal();
                    else tour.InorderRLTraversal();
                    break;
                case Traversal.PostOrder:
                    if (d == Direction.LeftRight) tour.PostorderLRTraversal();
                    else tour.PostorderRLTraversal();
                    break;
                case Traversal.LevelOrder:
                    if (d == Direction.LeftRight) tour.LevelorderLRTraversal();
                    else tour.LevelorderRLTraversal();
                    break;
                case Traversal.BranchOrder:
                    if (d == Direction.LeftRight) tour.BranchorderLRTraversal();
                    else tour.BranchorderRLTraversal();
                    break;
            }
        }

        public static void ShowAllTraversals(PartitionTree tree)
        {
            Console.WriteLine("All traversals of a partition tree");
            Console.Write("Number of nodes:  ");
            Console.WriteLine(tree.Count(tree.GetRoot()));
            Console.WriteLine("===========================");

            var tour = new Tour(tree);

            foreach (Traversal traversal in Enum.GetValues(typeof(Traversal)))
            {
                foreach (Visitor visitor in Enum.GetValues(typeof(Visitor)))
                {
                    foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                    {
                        Traverse(tour, traversal, visitor, direction);
                    }
                }
            }

            tree.ClearTree();
            Console.WriteLine();
            Console.WriteLine("Tree cleared ... done!");
        }

        //////////////////// Visitors

        // Standard visitor
        private static void StandardPartition(Partition p)
        {
            PrintPartition(p); 
        }

        // Conjugate visitor
        private static void ConjugatedPartition(Partition partition)
        {
            var p = Partitions.Conjugate(partition);
            PrintPartition(p); 
        }

        // Reverse visitor
        private static void ReversedPartition(Partition partition)
        {
            var p = Partitions.Reverse(partition);
            PrintPartition(p); 
        }

        // Reverse-conjugate visitor
        private static void ReversedConjugatedPartition(Partition partition)
        {
            var p = Partitions.Reverse(Partitions.Conjugate(partition));
            PrintPartition(p); 
        }

        ////////////////////////// Text/Format

        private static void PrintPartition(Partition p)
        {
            if (filter(p))
            {
                string ps = ToString(p);
                WriteLine(ps);
            }
        }

        private static string ToString(Partition partition)
        {
            var builder = new System.Text.StringBuilder();
            foreach (var part in partition)
            {
                builder.Append(part).Append(",");
            }
            return builder.ToString();
        }

        private static void WriteHeader(string name)
        {
            WriteLine(name);
        }

        static void OeisPartitions()
        {
            var t = Partitions.PartitionTree(6);
            var tour = new Tour(t);

            Console.WriteLine("A228100 (Fenner-Loizou tree, level order)");
            Traverse(tour, Traversal.PostOrder, Visitor.Conjugate, Direction.RightLeft);
            //Traverse(tour, Traversal.LevelOrder, Visitor.Partition, Direction.LeftRight);
            Console.ReadLine();

            Console.WriteLine("A036036 (Hindenburg, Abramowitz-Stegun)");
            Traverse(tour, Traversal.PreOrder, Visitor.ReverseConjugate, Direction.LeftRight);
            //Traverse(tour, Traversal.BranchOrder, Visitor.ReverseConjugate, Direction.RightLeft);
            Console.ReadLine();

            Console.WriteLine("A080577 (Mathematica, Sage, Magma)");
            Traverse(tour, Traversal.PostOrder, Visitor.Partition, Direction.RightLeft);
            //Traverse(tour, Traversal.LevelOrder, Visitor.Conjugate, Direction.LeftRight);
            Console.ReadLine();

            Console.WriteLine("A080576 (Maple)");
            Traverse(tour, Traversal.PreOrder, Visitor.Reverse, Direction.LeftRight);
            //Traverse(tour, Traversal.BranchOrder, Visitor.Reverse, Direction.RightLeft);
            Console.ReadLine();

            Console.WriteLine("A036037");
            Traverse(tour, Traversal.PreOrder, Visitor.Conjugate, Direction.LeftRight);
            //Traverse(tour, Traversal.BranchOrder, Visitor.Conjugate, Direction.RightLeft);
            Console.ReadLine();

            Console.WriteLine("A182937");
            Traverse(tour, Traversal.PreOrder, Visitor.Partition, Direction.RightLeft);
            //Traverse(tour, Traversal.BranchOrder, Visitor.Partition, Direction.LeftRight);
            Console.ReadLine();

            Console.WriteLine("A193073");
            Traverse(tour, Traversal.PreOrder, Visitor.Partition, Direction.LeftRight);
            //Traverse(tour, Traversal.BranchOrder, Visitor.Partition, Direction.RightLeft);
            Console.ReadLine();

            ShowAllTraversals(t);
            Console.ReadLine();

            // Prime-encodings
            // A036035, A059901, A063008, A227955, A228099 
        }

        public delegate void Printer(string text);
        private static Printer WriteLine;
        public static void SetPrinter(Printer writer)
        {
            WriteLine = writer;
        }

        static void Main()
        {
            WriteLine = Console.WriteLine;
            OeisPartitions();
        }
    }

}
