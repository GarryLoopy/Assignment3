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


    }
}
