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
        /// Tests the Split() method of the Singly Linked List
        /// </summary>
        [Test]
        public void TestSplit()
        {
            // Holds split Singly Linked Lists
            SLL[] retrievedSLL = new SLL[2];

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
                retrievedSLL = singlyLinkedList.Split(0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }

            // Checks for length of both Singly Linked Lists
            Assert.That(retrievedSLL[0].Count(), Is.EqualTo(1));
            Assert.That(retrievedSLL[1].Count(), Is.EqualTo(1));

            // Checks that each value of Singly Linked List is valid
            Assert.IsTrue(retrievedSLL[0].GetValue(0).Equals(testUser));
            Assert.IsTrue(retrievedSLL[1].GetValue(0).Equals(newTestUser));
        }

        [Test]
        public void TestJoin()
        {
            User testUser = new User(1, "", "", "");
            User newTestUser = new User(0, "", "", "");

            // Should look like: newTestUser -> null
            SLL newSLL = new SLL();
            newSLL.AddLast(newTestUser);
            // Should look like: testUser -> null
            singlyLinkedList.AddLast(testUser);

            // Should look like: testUser -> newTestUser -> null
            singlyLinkedList.Join(newSLL);

            try
            {
                Assert.That(singlyLinkedList.Count(), Is.EqualTo(2));
                // Call Get Value to confirm
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }

        }

    }
}
