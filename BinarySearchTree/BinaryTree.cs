using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary Search Tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public class BinaryTree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        public BinaryTree()
        {
            root = null;
            NumOfElements = 0;
            comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public BinaryTree(IComparer<T> comparer) : this()
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        /// <value>
        /// The number of elements.
        /// </value>
        public int NumOfElements { get; private set; }

        #region Base Methods

        /// <summary>
        /// Determines whether [contains] [the specified element].
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified element]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T element)
        {
            return Find(element, root) != null;
        }

        /// <summary>
        /// Inserts the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
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

        /// <summary>
        /// Removes the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Remove(T element)
        {
            if (root == null) 
            {
                return;
            }

            Remove(element, root);
        }
        #endregion

        #region Traverse

        /// <summary>
        /// Traverse in the pre order.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">The tree is empty.</exception>
        public IEnumerable<T> PreOrder()
        {
            if (root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            return PreOrder(root);
        }

        /// <summary>
        /// Traverse in the in order.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">The tree is empty.</exception>
        public IEnumerable<T> InOrder()
        {
            if (root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            return InOrder(root);
        }

        /// <summary>
        /// Traverse in the post order.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Tree is empty!</exception>
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

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }
        #endregion   
    }
}
