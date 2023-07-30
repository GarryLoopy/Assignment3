using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    [TestFixture]
    internal class LinkedListTests
    {
        SLL singlyLinkedList;

        [SetUp]
        public void SetUp()
        {
            singlyLinkedList = new SLL();
        }

        [TearDown]
        public void TearDown()
        {
            singlyLinkedList.Clear();
        }

        /// <summary>
        /// Tests the split method of SLL
        /// </summary>
        [Test]
        public void TestSplit()
        {
            // Test users
            User testUser = new User(1, "", "", "");
            User newTestUser = new User(0, "", "", "");

            // Should look like testUser -> newTestUser -> null
            singlyLinkedList.AddLast(testUser);
            singlyLinkedList.AddLast(newTestUser);


            //Should look like:
            // SLL[0] = testUser -> null
            // SLL[1] = newTestUser -> null
            try
            {
                SLL[] retrievedSLL = singlyLinkedList.Split(0);

                // Checks if both SLL's contains a node each
                Assert.That(retrievedSLL[0].Count(), Is.EqualTo(1));
                Assert.That(retrievedSLL[1].Count(), Is.EqualTo(1));

                // Checks if both SLL's contains the proper user
                Assert.IsTrue(retrievedSLL[0].GetValue(0).Equals(testUser));
                Assert.IsTrue(retrievedSLL[1].GetValue(0).Equals(testUser));

            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Tests the join method of SLL
        /// </summary>
        [Test]
        public void TestJoin()
        {
            // Test users
            User testUser = new User(1, "", "", "");
            User newTestUser = new User(0, "", "", "");

            // Create new SLL
            // Should look like: newTestUser -> null
            SLL newSLL = new SLL();
            newSLL.AddLast(newTestUser);

            // Should look like: testUser -> null
            singlyLinkedList.AddLast(testUser);

            // Should look like: testUser -> newTestUser -> null
            singlyLinkedList.Join(newSLL);

            try
            {
                // Checks if singly linked list length equals to 2
                Assert.That(singlyLinkedList.Count(), Is.EqualTo(2));

                // Checks if each index's contain the proper users
                Assert.IsTrue(singlyLinkedList.GetValue(0).Equals(testUser));
                Assert.IsTrue(singlyLinkedList.GetValue(1).Equals(newTestUser));

            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TestSort()
        {
            User user0 = new User(0, "HHHH", "", "");
            User user1 = new User(1, "BBBB", "", "");
            User user2 = new User(2, "CCCC", "", "");
            User user3 = new User(3, "PPPP", "", "");


            // Should look like: user3 -> user0 -> user2 -> user1 -> null
            singlyLinkedList.AddLast(user3);
            singlyLinkedList.AddLast(user0);
            singlyLinkedList.AddLast(user2);
            singlyLinkedList.AddLast(user1);

            // Should look like:  user1 -> user2 -> user0 -> user3 -> null
            singlyLinkedList.Sort();

            try
            {
                // Checks for length
                Assert.That(singlyLinkedList.Count(),Is.EqualTo(4));

                // Checks if nodes are in proper order
                Assert.IsTrue(singlyLinkedList.GetValue(0).Equals(user1));
                Assert.IsTrue(singlyLinkedList.GetValue(1).Equals(user2));
                Assert.IsTrue(singlyLinkedList.GetValue(2).Equals(user0));
                Assert.IsTrue(singlyLinkedList.GetValue(3).Equals(user3));

            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        /// <summary>
        /// Tests the reverse order method of SLL
        /// </summary>
        [Test]
        public void TestReverseOrder()
        {
            // Test users
            User user0 = new User(0, "", "", "");
            User user1 = new User(1, "", "", "");
            User user2 = new User(2, "", "", "");
            User user3 = new User(3, "", "", "");

            // Should look like: testUser -> user0 -> user1 -> user2 -> user3 -> null
            singlyLinkedList.AddLast(user0);
            singlyLinkedList.AddLast(user1);
            singlyLinkedList.AddLast(user2);
            singlyLinkedList.AddLast(user3);

            // Should look like: user3 -> user2 -> user1 -> user0 -> testUser -> null
            singlyLinkedList.ReverseOrder();

            try
            {
                // Checks for length
                Assert.That(singlyLinkedList.Count(), Is.EqualTo(4));

                // Checks for each node
                Assert.IsTrue(singlyLinkedList.GetValue(0).Equals(user3));
                Assert.IsTrue(singlyLinkedList.GetValue(1).Equals(user2));
                Assert.IsTrue(singlyLinkedList.GetValue(2).Equals(user1));
                Assert.IsTrue(singlyLinkedList.GetValue(3).Equals(user0));

            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Tests the get value method of SLL
        /// </summary>
        [Test] 
        public void TestGetValue()
        {
            // Test users
            User user0 = new User(0, "", "", "");
            User user1 = new User(1, "", "", "");

            // Should look like user0 -> user1 -> null
            singlyLinkedList.AddLast(user0);
            singlyLinkedList.AddLast(user1);

            try
            {
                // Checks for length
                Assert.That(singlyLinkedList.Count(), Is.EqualTo(2));

                // Checks if each node is valid
                Assert.IsTrue(singlyLinkedList.GetValue(0).Equals(user0));
                Assert.IsTrue(singlyLinkedList.GetValue(1).Equals(user1));
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        /// <summary>
        /// Tests the remove method of SLL
        /// </summary>
        [Test]
        public void TestRemove()
        {
            // Test user's
            User user0 = new User(0, "", "", "");
            User user1 = new User(1, "", "", "");
            User user2 = new User(2, "", "", "");

            // Should look like user0 -> user1 -> user2 -> null
            singlyLinkedList.AddLast(user0);
            singlyLinkedList.AddLast(user1);
            singlyLinkedList.AddLast(user2);

            try
            {
                // Should look like user0 -> user2 -> null
                singlyLinkedList.Remove(1);

                // Checks for length
                Assert.That(singlyLinkedList.Count(), Is.EqualTo(2));

                // Checks for nodes
                Assert.IsTrue(singlyLinkedList.GetValue(0).Equals(user0));
                Assert.IsTrue(singlyLinkedList.GetValue(1).Equals(user2));
            }
            catch (IndexOutOfRangeException ex)
            { 
                Assert.Fail(ex.Message); 
            }
        }

        /// <summary>
        /// AddFirst Test
        /// </summary>
        [Test]
        public void TestAddFirst()
        {
            // Test user's
            User user0 = new User(0, "", "", "");
            User user1 = new User(1, "", "", "");
            User user2 = new User(2, "", "", "");

            singlyLinkedList.AddFirst(user2);
            singlyLinkedList.AddFirst(user1);
            singlyLinkedList.AddFirst(user0);

            try
            {
                // Check if singly linked list length equals to 3
                Assert.That(singlyLinkedList.Count(), Is.EqualTo(3));

                // Check if each index contains the proper users
                Assert.IsTrue(singlyLinkedList.GetValue(0).Equals(user0));
                Assert.IsTrue(singlyLinkedList.GetValue(1).Equals(user1));
                Assert.IsTrue(singlyLinkedList.GetValue(2).Equals(user2));
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// RemoveFirst Test
        /// </summary>
        [Test]
        public void TestRemoveFirst()
        {
            // Test user's
            User user0 = new User(0, "", "", "");
            User user1 = new User(1, "", "", "");
            User user2 = new User(2, "", "", "");

            singlyLinkedList.AddLast(user0);
            singlyLinkedList.AddLast(user1);
            singlyLinkedList.AddLast(user2);

            try
            {
                singlyLinkedList.RemoveFirst();

                // Check if singly linked list length equals to 2
                Assert.That(singlyLinkedList.Count(), Is.EqualTo(2));

                // Check if the first user has been removed
                Assert.IsTrue(singlyLinkedList.GetValue(0).Equals(user1));
                Assert.IsTrue(singlyLinkedList.GetValue(1).Equals(user2));

            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Replace Test
        /// </summary>
        [Test]
        public void TestReplace()
        {
            // Test user's
            User user0 = new User(0, "", "", "");
            User user1 = new User(1, "", "", "");
            User user2 = new User(2, "", "", "");

            singlyLinkedList.AddLast(user0);
            singlyLinkedList.AddLast(user1);
            singlyLinkedList.AddLast(user2);

            User newUser = new User(3, "", "", "");

            try
            {
                singlyLinkedList.Replace(newUser, 1);

                // Check if singly linked list length still equals to 3
                Assert.That(singlyLinkedList.Count(), Is.EqualTo(3));

                // Check if the user at index 1 has been replaced
                Assert.IsTrue(singlyLinkedList.GetValue(1).Equals(newUser));

                // Checks for the other users
                Assert.IsTrue(singlyLinkedList.GetValue(0).Equals(user0));
                Assert.IsTrue(singlyLinkedList.GetValue(2).Equals(user2));
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// CopyToArray Test
        /// </summary>
        [Test]
        public void TestCopyToArray()
        {
            // Test user's
            User user0 = new User(0, "", "", "");
            User user1 = new User(1, "", "", "");
            User user2 = new User(2, "", "", "");

            singlyLinkedList.AddLast(user0);
            singlyLinkedList.AddLast(user1);
            singlyLinkedList.AddLast(user2);

            try
            {
                User[] array = singlyLinkedList.CopyToArray();

                // Check if the array length is 3
                Assert.That(array.Length, Is.EqualTo(3));

                // Check if the array contains the correct users in order
                Assert.IsTrue(array[0].Equals(user0));
                Assert.IsTrue(array[1].Equals(user1));
                Assert.IsTrue(array[2].Equals(user2));
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }
        }


    }
}
