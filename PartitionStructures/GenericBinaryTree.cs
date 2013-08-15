namespace Luschny.Tree
{
    /**
     * Binaerer Knoten
     * 
     * Speichert den Wert des Knoten
     * und enthaelt die Zeiger auf den rechten und linken Teilbaum
     * 
     * @author Peter Luschny
     * @version 1.0, 2001-01-04
     */

    public class BinaryNode<A>
    {
        public A value;               // Wert des Knoten
        public BinaryNode<A> left;    // linke  Teilbaumwurzel
        public BinaryNode<A> right;   // rechte Teilbaumwurzel

        /**
         * Ein Knoten hat stets einen Wert
         * aber anfaenglich keine Kinder
         * 
         * @param Wert des Knoten
         */

        public BinaryNode(A value)
        {
            this.value = value;
        }
    }

    /**
     * Ein binaerer Baum ist eine Kette von Knoten,
     * wobei jeder Knoten einen Wert (ein Datenelement) enthaelt
     * und Verweise auf die am Knoten haengenden Unterbaeume,
     * von denen ein Knoten maximal zwei haben kann.
     * Betrachtet man die Beziehungen lokal, spricht man auch vom
     * Elternknoten und dem linken bzw. rechten Kindknoten.
     * Jeder Knoten im Baum hat einen eindeutigen Elternknoten
     * - mit einer Ausnahme: die Wurzel des Baums hat keinen Elternknoten.
     * 
     * @author Peter Luschny
     * @version 1.0, 2000-12-10
     */

    public class BinaryTree<A>
    {
        // BaumWurzel
        private BinaryNode<A> root;

        /**
         * Konstruiert einen (leeren) Binärbaum.
         * 
         */

        public BinaryTree() { }

        /**
         * Liefert die Wurzel des Baums.
         * 
         * @return Baumwurzel
         */

        public Node GetRoot()
        {
            Node wurzel = new Node();
            wurzel.node = root;

            return wurzel;
        }

        /**
         * Liefert den linken Kindknoten.
         * 
         * @param parent betrachteter Elternknoten
         * @return Wurzel des linken Teilbaums
         */

        public Node GetLeftChild(Node parent)
        {
            Node child = new Node();
            if (parent.IsValid())
            {
                child.node = parent.node.left;
            }

            return child;
        }

        /**
         * Liefert den rechten Kindknoten.
         * 
         * @param parent betrachteter Elternknoten
         * @return Wurzel des rechten Teilbaums
         */

        public Node GetRightChild(Node parent)
        {
            Node child = new Node();
            if (parent.IsValid())
            {
                child.node = parent.node.right;
            }

            return child;
        }

        /**
         * Setzt den Wert der Wurzel des Baums.
         * 
         * @param value Wert
         */

        public void SetRoot(A value)
        {
            if (root == null)
            {
                root = new BinaryNode<A>(value);
            }
        }

        /**
         * Setzt den Wert des linken Kindknotens.
         * 
         * @param value Wert
         * @param parent Elternknoten
         */

        public void SetLeftChild(A value, Node parent)
        {
            if (root == null)
            {
                return;
            }

            BinaryNode<A> child = new BinaryNode<A>(value);
            child.right = parent.node.left;
            parent.node.left = child;
        }

        public Node CreateLeftChild(A value, Node parent)
        {
            SetLeftChild(value, parent);
            return GetLeftChild(parent);
        }

        /**
         * Setzt den Wert des rechten Kindknotens.
         * 
         * @param value Wert
         * @param parent Elternknoten
         */

        public void SetRightChild(A value, Node parent)
        {
            if (root == null)
            {
                return;
            }

            BinaryNode<A> child = new BinaryNode<A>(value);
            child.right = parent.node.right;
            parent.node.right = child;
        }

        public Node CreateRightChild(A value, Node parent)
        {
            SetRightChild(value, parent);
            return GetRightChild(parent);
        }

        /**
         * Loescht alle Knoten im Baum.
         */

        public void ClearTree()
        {
            Remove(GetRoot());
            root = null;
        }

        /**
         * Loescht den Knoten und alle seine Kinderknoten.
         * 
         * @param parent Wurzel des zu loeschenden Teilbaums
         */

        private void Remove(Node parent)
        {
            if (parent.IsValid())
            {
                Remove(GetLeftChild(parent));
                Remove(GetRightChild(parent));
                parent.Delete();
            }
        }

        /**
         * Liefert den Wert eines Knoten.
         * 
         * @param pos betrachteter Knoten
         * @return Wert des Knoten
         */

        public A GetValue(Node pos)
        {
            if (pos.IsValid())
            {
                return pos.node.value;
            }
            else
            {
                throw new System.NullReferenceException();
            }
        }

        /**
         * Ersetzt den Wert des Knoten durch den angereichten Wert.
         * 
         * @param value neuer Wert
         * @param pos zu veraendernder Knoten
         */

        public void ReplaceValue(A value, Node pos)
        {
            if (pos.IsValid())
            {
                pos.node.value = value;
            }
        }

        /**
         * Liefert die Anzahl der Knoten im Teilbaum.
         * 
         * @param parent Wurzel des betrachteten Teilbaums
         * @return Anzahl der Knoten im Teilbaum
         */

        public int Count(Node parent)
        {
            if (parent.IsValid())
            {
                return Count(GetLeftChild(parent))
                        + Count(GetRightChild(parent)) + 1;
            }
            else
            {
                return 0;
            }
        }

        /**
         * Ein Node ist (ein Zeiger auf) ein Grundelement eines Binaeren Baums.
         * 
         * @author Peter Luschny
         * @version 1.0, 2000-12-10
         */

        public class Node
        {
            // worauf ein Node zeigt
            public BinaryNode<A> node;

            /**
             * Erzeugt Zeiger auf einen Knoten eines BinaryTrees.
             */

            public Node() { }

            /**
             * Ein Node ist gueltig, wenn er auf ein Baumelement zeigt.
             * 
             * @return das Resultat dieser Pruefung
             */

            public bool IsValid()
            {
                return node != null;
            }

            /**
             * Loescht den Node, macht ihn ungueltig.
             */

            public void Delete()
            {
                node = null;
            }
        }
    }

}