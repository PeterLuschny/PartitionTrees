/// -------  ToujoursEnBeta
/// Author & Copyright : Peter Luschny
/// License: Creative Commons Attribution-ShareAlike 3.0
/// Comments mail to: peter(at)luschny.de
/// Created: 2013-08-16

namespace Luschny.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BinTree = BinaryTree<System.Collections.Generic.List<int>>;
    using Paar = System.Tuple<BinaryTree<System.Collections.Generic.List<int>>.Node, Luschny.Tree.Partitions.Partition>;

    public class Partitions
    {
        public class Partition
        {
            public int[] head;
            public int headLen;
            public int num1s;

            public Partition(Partition p, bool left)
            {
                this.headLen = left ? p.headLen + 1 : p.headLen;
                this.head = new int[this.headLen];

                for (int i = 0; i < p.headLen; i++)
                    this.head[i] = p.head[i];

                if (left)
                {
                    head[p.headLen] = 2;
                    this.num1s = p.num1s - 2;
                }
                else
                {
                    head[p.headLen - 1] += 1;
                    this.num1s = p.num1s - 1;
                }
            }

            public Partition(int n)
            {
                this.head = new int[0];
                this.headLen = 0;
                this.num1s = n;
            }
        }

        public static int GeneratePartitions(int n)
        {
            int count = 1;
            var p = new Partition(n);
            var queue = new Queue<Partition>();
            queue.Enqueue(p);
            Publish(p, p, count);

            while (queue.Count > 0)
            {
                p = queue.Dequeue();

                if (p.num1s != 1)
                {
                    var q = new Partition(p, true);
                    if (1 <= q.num1s) { queue.Enqueue(q); }
                    Publish(p, q, ++count);
                }

                if (p.headLen == 1
                || (p.headLen > 1
                && (p.head[p.headLen - 1] != p.head[p.headLen - 2])))
                {
                    var q = new Partition(p, false);
                    if (1 <= q.num1s) { queue.Enqueue(q); }
                    Publish(p, q, ++count);
                }
            }

            return count;
        }

        public static BinTree PartitionTree(int n)
        {
            // int count = 1;
            var p = new Partition(n);

            var tree = new BinTree();
            int[] arr1 = Enumerable.Repeat(1, n).ToArray();
            tree.SetRoot(new List<int>(arr1));
            var root = tree.GetRoot();

            var queue = new Queue<Paar>();
            var w = new Paar(root, p);

            queue.Enqueue(w);
            // Publish(p, p, count);

            while (queue.Count > 0)
            {
                var t = queue.Dequeue();
                var parent = t.Item1;
                var part = t.Item2;

                if (part.num1s != 1)
                {
                    var q = new Partition(part, true);
                    var list = PartitionToList(q.head, q.num1s);
                    var leftChild = tree.CreateLeftChild(list, parent);
                    // Publish(part, q, ++count);

                    if (1 <= q.num1s)
                    {
                        var paar = new Paar(leftChild, q);
                        queue.Enqueue(paar);
                    }
                }

                if (part.headLen == 1
                || (part.headLen > 1
                && (part.head[part.headLen - 1] != part.head[part.headLen - 2])))
                {
                    var q = new Partition(part, false);
                    var list = PartitionToList(q.head, q.num1s);
                    var rightChild = tree.CreateRightChild(list, parent);
                    // Publish(part, q, ++count);

                    if (1 <= q.num1s)
                    {
                        var paar = new Paar(rightChild, q);
                        queue.Enqueue(paar);
                    }
                }
            }
            return tree;
        }

        private static List<int> PartitionToList(int[] head, int num1s)
        {
            var l = new List<int>(head);
            for (var i = 0; i < num1s; i++)
            {
                l.Add(1);
            }
            return l;
        }

        private static void PrintPartition(Partition p)
        {
            foreach (int part in p.head)
            {
                Console.Write(part + " ");
            }
            for (var i = 0; i < p.num1s; i++)
            {
                Console.Write("1" + " ");
            }
        }

        private static void Publish(Partition p, Partition q, int count)
        {
            Console.Write("[" + count + "] ");
            PrintPartition(p);
            Console.Write("  ->  ");
            PrintPartition(q);
            Console.WriteLine();
        }

        ///////////////////// PrimeEncoding

        private static int[] primes =
            new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };

        private static string PrimeEncoding(Partition p)
        {
            int i = 0;
            long z = 1;

            foreach (int part in p.head)
            {
                z *= (long)Math.Pow(primes[i++], part);
            }
            for (var j = 0; j < p.num1s; j++)
            {
                z *= primes[i++];
            }
           
            return z.ToString();
        }

        ////////////////////////////////
        public static List<int> Conjugate(List<int> p)
        {
            var l = p.Count;
            var c = new List<int>();
            var t = Enumerable.Repeat(l, p[l - 1]);
            c.AddRange(t);
            for (int i = l - 1; i > 0; i--)
            {
                var d = p[i - 1] - p[i];
                t = Enumerable.Repeat(i, d);
                c.AddRange(t);
            }
            return c;
        }

        public static List<int> Reverse(List<int> p)
        {
            var l = p.Count;
            var r = new List<int>(l);
            for (int i = l - 1; i >= 0; i--)
            {
                r.Add(p[i]);
            }
            return r;
        }

        // Filter-predicate returns true if a partition has singletons.
        public static bool SingletonFree(List<int> p)
        {
            return p[0] != 1 && p[p.Count - 1] != 1;
        }
    }

}
