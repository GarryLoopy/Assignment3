using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    /// <summary>
    /// Represents a node class
    /// </summary>
    /// <typeparam name="T">Type of node</typeparam>
    internal class Node<T>
    {
        // The value of the node
        T value;

        // The next node
        Node<T> next;

        /// <summary>
        /// Getter and setter for value
        /// </summary>
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Getter and setter for next
        /// </summary>
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        /// Represents the constructor for the node
        /// </summary>
        /// <param name="value">The value of the node</param>
        public Node(T value)
        {
            this.value = value;
            next = null;
        }
    }
}
