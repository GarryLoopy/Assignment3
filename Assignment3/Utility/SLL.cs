using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

//--------------------
// Methods and Tests
// Dave:
//  1. IsEmpty
//  2. Count
//  3. Add
//  4. IndexOf
//--------------------
// JJ (Finished):
//  1. Clear
//  2. Contains
//  3. RemoveLast
//  4. AddLast
//--------------------
// Jairo (Finished):
//  1. AddFirst
//  2. RemoveFirst
//  3. Replace
//  4. CopyToArray
//--------------------
// Garry (Finished):
//  1. Split
//  2. Join
//  3. Sort
//  4. ReverseOrder
//  5. GetValue
//  6. Remove
//  7. Serialization (SerializationTests + SerializationHelper)
//  8. Deserialization (SerializationTests + SerializationHelper)
//--------------------


namespace Assignment3
{
    /// <summary>
    /// Represents a singly linked list only for USER type
    /// </summary>
    public class SLL : ILinkedListADT
    {
        // The head of the singly linked list
        Node<User> head;

        // Holds the letters in the alphaber with corresponding int based on ascending order, in lower case
        readonly Dictionary<char, int> alphabet;

        // Holds all the letters in lower case; used for sorting
        const string LETTERS = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Constructor for SLL
        /// </summary>
        public SLL()
        {
            // Sets head to null
            head = null;

            // Creates new dictionary with key as the character and value as the int
            alphabet = new Dictionary<char, int>();

            // Holds the index for each letter
            int letterIndex = 0;

            // Iterate through all the letters and assign letter to an int
            foreach (char letter in LETTERS)
            {
                alphabet[letter] = ++letterIndex;
            }
        }

        // Dave
        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>True if it is empty.</returns>
        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        // JJ
        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            // Set the head to null, clearing the list.
            head = null;
        }

        // JJ
        /// <summary>
        /// Adds to the end of the list.
        /// </summary>
        /// <param name="value">Value to append.</param>
        public void AddLast(User value)
        {
            Node<User> newNode = new Node<User>(value);

            // Check if the linked list is empty.
            if (head == null)
            {
                // If the linked list is empty, set the head to the new node.
                head = newNode;
                return;
            }

            // Create a pointer to the head of the linked list.
            Node<User> current = head;

            // Move the current pointer to the last node in the linked list.
            while (current.Next != null)
            {
                current = current.Next;
            }

            // Set the Next pointer of the last node to the new node.
            current.Next = newNode;
        }

        // Jairo
        /// <summary>
        /// Prepends (adds to beginning) value to the list.
        /// </summary>
        /// <param name="value">Value to store inside element.</param>
        public void AddFirst(User value)
        {
            // Create a new node with the given value.
            Node<User> newNode = new Node<User>(value);

            // Set the Next pointer of the new node to the current head of the linked list.
            newNode.Next = head;

            // Update the head of the linked list to point to the new node, making it the new first node.
            head = newNode;
        }

        // Dave
        /// <summary>
        /// Adds a new element at a specific position.
        /// </summary>
        /// <param name="value">Value that element is to contain.</param>
        /// <param name="index">Index to add new element at.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list.</exception>
        public void Add(User value, int index)
        {
            throw new NotImplementedException();
        }

        // Jairo
        /// <summary>
        /// Replaces the value  at index.
        /// </summary>
        /// <param name="value">Value to replace.</param>
        /// <param name="index">Index of element to replace.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public void Replace(User value, int index)
        {
            // Check if the provided index is out of range (negative or larger than or equal to the number of elements in the list).
            if (index < 0 || index >= Count())
                throw new ArgumentOutOfRangeException("Index is out of range.");

            // Create a pointer to the head of the linked list.
            Node<User> current = head;

            // Move the current pointer to the node at the specified index.
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            // Update the value of the node at the specified index with the new provided value.
            current.Value = value;
        }

        // Dave
        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        /// <returns>Size of list (0 meaning empty)</returns>
        public int Count()
        {
            throw new NotImplementedException();
        }

        // Jairo
        /// <summary>
        /// Removes first element from list
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if list is empty.</exception>
        public void RemoveFirst()
        {
            // Check if the linked list is not empty (i.e., if the head is not null).
            if (head != null)
            {
                // Update the head to point to the next node, effectively skipping the first node.
                head = head.Next;
            }
            // If the linked list is empty, the method does nothing, as there is nothing to remove.
            throw new InvalidOperationException("The list is empty");
        }

        // JJ
        /// <summary>
        /// Removes last element from list
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if list is empty.</exception>
        public void RemoveLast()
        {
            if (head == null)
            {
                // If list is empty
                throw new InvalidOperationException("The list is empty");
            }

            if (head.Next == null)
            {
                // Only one element
                head = null;
                return;
            }

            // Find the second-to-last node.
            Node<User> secondToLast = head;

            // Loop until the second-to-last node is found.
            while (secondToLast.Next.Next != null)
            {
                secondToLast = secondToLast.Next;
            }

            // Remove the last node.
            secondToLast.Next = null;
        }

        /// <summary>
        /// Removes element at index from list, reducing the size.
        /// </summary>
        /// <param name="index">Index of element to remove.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public void Remove(int index)
        {
            // Checks if index is negative or greater than count of linked list
            if (index < 0 || index >= Count())
                throw new ArgumentOutOfRangeException("Index is out of bounds");
            // Checks if linked list is empty
            else if (IsEmpty())
                throw new ArgumentOutOfRangeException("Singly linked list is empty");

            // Remove first node
            if (index == 0)
            {
                RemoveFirst();
                return;
            }
            // Remove last node
            else if (index == Count() - 1)
            {
                RemoveLast();
                return;
            }

            // Create a pointer to the start of the singly linked list
            Node<User> node = head;

            // Iterate through each node until the desired node in front is reached
            for (int i = 0; i < index; i++)
            {
                // Node in front is the ones that needs to be removed
                if (i + 1 >= index)
                    break;

                // Move to next node
                node = node.Next;
            }

            // Set current node's next to two node's in front
            node.Next = node.Next.Next;
        }

        /// <summary>
        /// Gets the value at the specified index.
        /// </summary>
        /// <param name="index">Index of element to get.</param>
        /// <returns>Value of node at index</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public User GetValue(int index)
        {
            // Checks if index is negative or greater than count of linked list
            if (index < 0 || index >= Count())
                throw new IndexOutOfRangeException("Index is out of bounds");
            // Checks if linked list is empty
            else if (IsEmpty())
                throw new IndexOutOfRangeException("Singly linked list is empty");

            // Create a new pointer to the start of the list
            Node<User> node = head;

            // Iterates from 0 to the desired index from the singly linked list
            for (int i = 0; i < index; i++)
            {
                // Go to the next node
                node = node.Next;
            }

            // Return the node value(User)
            return node.Value;
        }

        // Dave
        // Document description: Get the index of an item in the linked list.
        public int IndexOf(User value)
        {
            throw new NotImplementedException();
        }

        // JJ
        /// <summary>
        /// Go through nodes and check if one has value.
        /// </summary>
        /// <param name="value">Value to find index of.</param>
        /// <returns>True if element exists with value.</returns>
        public bool Contains(User value)
        {
            // Create a pointer to the start of the list
            Node<User> current = head;

            // Iterate through each node in the linked list
            while (current != null)
            {
                // Check if the current node's value is equal to the value being searched for
                if (current.Value.Equals(value))
                {
                    return true;
                }

                // Move to the next node
                current = current.Next;
            }

            // If the value was not found, return false
            return false;
        }

        /// <summary>
        /// Reserverses the order of the current nodes in the linked list
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if list is empty</exception>
        public void ReverseOrder()
        {
            // Checks if linked list is empty
            if (IsEmpty())
                throw new InvalidOperationException("Cant sort an empty linked list");
            // Checks if there is only one node in the linked list
            else if (head.Next == null)
                return;

            // Creates a separate node; represents final value of the the node
            Node<User> tail = new Node<User>(head.Value);

            // Create a pointer to head
            Node<User> node = head;

            // Iterate through each node in linked list
            while (node.Next != null)
            {
                // Go to next node
                node = node.Next;

                // Create a new node with the pointer
                Node<User> newNode = new Node<User>(node.Value)
                {
                    // Set the new nodes Next to tail
                    Next = tail
                };

                // Sets the tail to the new node
                tail = newNode;
            }

            // Returns the reversed nodes
            head = tail;
        }

        /// <summary>
        /// Sorts the linked list in ascending order via current user name
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if linked list is empty</exception>
        public void Sort()
        {
            // Checks if linked list is empty
            if (IsEmpty())
            {
                throw new InvalidOperationException("Linked list is empty");
            }
            // Checks if there is only one node in list
            else if (head.Next == null)
                return;

            // Iterates through each nodes in the list
            for (int i = Count() - 1; i > 0; i--)
            {
                // Creates a pointer to head
                Node<User> node = head;
                for (int j = 0; j < i; j++)
                {
                    // Uses the alphabet dictionary to check for corresponding int value; based on ascending order
                    if (alphabet[node.Value.Name.ToLower()[0]] > alphabet[node.Next.Value.Name.ToLower()[0]])
                    {
                        // Uses tuple to switch values
                        (node.Value, node.Next.Value) = (node.Next.Value, node.Value);
                    }
                    // Go to next Node
                    node = node.Next;
                }
            }
        }

        //Jairo
        /// <summary>
        /// Copies the values of each node onto an array of Users
        /// </summary>
        /// <returns>A user array container each user from each nodes</returns>
        /// <exception cref="InvalidOperationException">Thrown if linked list is empty</exception>
        public User[] CopyToArray()
        {
            // Checks if linked list is empty
            if (IsEmpty())
                throw new InvalidOperationException("Linked list is empty");

            // Create an array of User objects with the size equal to the number of elements in the linked list.
            User[] array = new User[Count()];

            // Create a pointer to the head of the linked list.
            Node<User> current = head;

            // Initialize an index variable to keep track of the position in the array.
            int index = 0;

            // Iterate through each node in the linked list until the end is reached.
            while (current != null)
            {
                // Add the value of the current node to the array at the current index.
                array[index++] = current.Value;

                // Move to the next node in the linked list.
                current = current.Next;
            }

            // Return the array containing the values of the linked list nodes.
            return array;
        }

        /// <summary>
        /// Joins the current linked list to the given linked list
        /// </summary>
        /// <param name="singlyLinkedList">The linked list to join</param>
        /// <exception cref="ArgumentNullException">Thrown if given linked list is empty</exception>
        public void Join(SLL singlyLinkedList)
        {
            if (singlyLinkedList.IsEmpty())
                throw new ArgumentNullException("Given linked list is empty");

            if (IsEmpty())
            {
                head.Next = singlyLinkedList.head;
            }

            // Creates a pointer to head
            Node<User> node = head;

            // Iterates through each nodes, before reaching the end
            while (node.Next != null)
            {
                // Go to next node
                node = node.Next;
            }

            // sets the next node to the beginning of the given linked list
            node.Next = singlyLinkedList.head;
        }

        // JJ
        /// <summary>
        /// Splits the singly linked list via given index
        /// </summary>
        /// <param name="index">The index to split the linked list at</param>
        /// <returns>Array containing the two singly linked list</returns>
        /// <exception cref="InvalidOperationException">Thrown when the singly linked list is empty</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the Index is out of range or if there is only one node in the singly linked list</exception>
        public SLL[] Split(int index)
        {
            // Checks if linked list is empty
            if (IsEmpty())
                throw new InvalidOperationException("Singly linked list is empty");
            // Checks if given index is out of range
            else if (index < 0 || index >= Count())
                throw new ArgumentOutOfRangeException("Index is out of range");
            // Checks if there is only one node in linked list
            else if (head.Next == null)
                throw new InvalidOperationException("There is only one node in the singly linked list.");

            // Create a pointer to the beginning of the linked list
            Node<User> node = head;

            // Create containers for the the singly linked lists
            SLL[] array = new SLL[] { new SLL(), new SLL() };

            // Iterate through each node
            for (int i = 0; i < index + 1; i++)
            {
                // Adds the current node to the container
                array[0].AddLast(node.Value);

                // Go to next node
                node = node.Next;
            }

            // Set the remaining nodes to the other container
            array[1].head = node;

            // Return the split singly linked list
            return array;
        }

        /// <summary>
        /// Sets the current values of the Singly Linked List from the given array of users
        /// </summary>
        /// <param name="users">The user[] values</param>
        /// <exception cref="ArgumentException">Thrown when user array is empty</exception>
        public void CopyFromArray(User[] users)
        {
            // Checks if array is empty
            if (users.Length == 0)
                throw new ArgumentException("User array cannot be empty");

            // Runs if array only contains a single item
            if (users.Length == 1)
            {
                head = new Node<User>(users[0]);
                return;
            }

            // Set the head to the first element of array
            head = new Node<User>(users[0]);

            // Create a separate pointer to head
            Node<User> node = head;

            // Iterate though each element in array
            for (int i = 1; i < users.Length; i++)
            {
                // Set the next to the current element; create a new node
                node.Next = new Node<User>(users[i]);

                // Go to next node
                node = node.Next;
            }
        }
    
    }
}
