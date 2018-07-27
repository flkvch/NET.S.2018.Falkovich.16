using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinaryTree<T> 
    {
        private Node<T> root;
        private IComparer<T> comparer;
        public int NumOfElements { get; private set; }

        public BinaryTree()
        {
            root = null;
            NumOfElements = 0;
            comparer = Comparer<T>.Default;
        }

        public BinaryTree(IComparer<T> comparer) : this()
        {
            this.comparer = comparer;
        }

        #region Base Methods
        public Node<T> Find(T element)
        {
            return Find(element, root);
        }

        public void Insert(T element)
        {
            if (root == null)
            {
                root = new Node<T>(element);
                NumOfElements++;
                return;
            }

            Insert(element, root);
        }
      
        public void Remove(T element)
        {
            if(root == null)
            {
                return;
            }

            Remove(element, root);
        }
        #endregion

        #region Traverse

        public IEnumerable<T> PreOrder()
        {
            if (root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            return PreOrder(root);
        }

        public IEnumerable<T> InOrder()
        {
            if (root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            return InOrder(root);
        }
      
        public IEnumerable<T> PostOrder()
        {
            if (ReferenceEquals(root, null))
            {
                throw new InvalidOperationException("Tree is empty!");
            }

            return PostOrder(root);
        }
        #endregion

        #region Private base methods
        private Node<T> Find(T element, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (comparer.Compare(node.Value, element) == 0)
            {
                return node;
            }

            if (comparer.Compare(node.Value, element) > 0)
            {
                return Find(element, node.Left);
            }
            else
            {
                return Find(element, node.Right);
            }
        }

        private void Insert(T element, Node<T> node)
        {
            if (comparer.Compare(node.Value, element) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(element);
                    NumOfElements++;
                }
                else
                {
                    Insert(element, node.Left);
                }
            }

            if (comparer.Compare(node.Value, element) <= 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(element);
                    NumOfElements++;
                }
                else
                {
                    Insert(element, node.Right);
                }
            }
        }

        private void Remove(T element, Node<T> node)
        {
            if (comparer.Compare(node.Value, element) > 0)
            {
                Remove(element, node.Left);
            }

            if (comparer.Compare(node.Value, element) < 0)
            {
                Remove(element, node.Right);
            }

            if (comparer.Compare(node.Value, element) == 0)
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                    return;
                }

                if (node.Left == null)
                {
                    node = node.Right;
                    node.Right = null;
                    NumOfElements--;
                    return;
                }

                if (node.Right == null)
                {
                    node = node.Left;
                    node.Left = null;
                    NumOfElements--;
                    return;
                }

                if (node.Right.Left == null)
                {
                    node = node.Right;
                    node.Right = null;
                    NumOfElements--;
                    return;
                }
                else
                {
                    Node<T> theMostLeft = FindTheMostLeft(node.Right);
                    node.Value = theMostLeft.Value;
                    Remove(theMostLeft.Value);
                }
            }
        }

        private Node<T> FindTheMostLeft(Node<T> node)
        {
            if (node.Left != null)
            {
                FindTheMostLeft(node.Left);
            }

            return node;
        }
        #endregion

        #region Private Traverce methods

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
            {
                foreach (var element in PreOrder(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (var element in PreOrder(node.Right))
                {
                    yield return element;
                }
            }
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var element in InOrder(node.Left))
                {
                    yield return element;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var element in InOrder(node.Right))
                {
                    yield return element;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var element in PostOrder(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (var element in PostOrder(node.Right))
                {
                    yield return element;
                }
            }

            yield return node.Value;
        }
        #endregion

    }
}
