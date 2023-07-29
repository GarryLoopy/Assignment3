using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Assignment3.Tests
{
    //public static class SerializationHelper
    //{
    //    /// <summary>
    //    /// Serializes (encodes) users
    //    /// </summary>
    //    /// <param name="users">List of users</param>
    //    /// <param name="fileName"></param>
    //    public static void SerializeUsers(ILinkedListADT users, string fileName)
    //    {
    //        DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
    //        using (FileStream stream = File.Create(fileName))
    //        {
    //            serializer.WriteObject(stream, users);
    //        }
    //    }

    //    /// <summary>
    //    /// Deserializes (decodes) users
    //    /// </summary>
    //    /// <param name="fileName"></param>
    //    /// <returns>List of users</returns>
    //    public static ILinkedListADT DeserializeUsers(string fileName)
    //    {
    //        DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
    //        using (FileStream stream = File.OpenRead(fileName))
    //        {
    //            return (ILinkedListADT)serializer.ReadObject(stream);
    //        }
    //    }
    //}

    /// <summary>
    /// Represents a serializable class
    /// </summary>
    public class SLLSerializableClass
    {
        // The users
        public User[]? Users { get; set; }

        /// <summary>
        /// Converts the user[] to a Singly Linked List
        /// </summary>
        /// <returns>The Single linked list</returns>
        public ILinkedListADT? ConvertToSLL()
        {
            SLL newSLL = new SLL();

            newSLL.CopyFromArray(Users);
            return newSLL;
        }
    }

    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName">The path of the file</param>
        public static void SerializeUsers(SLL users, string fileName)
        {
            SLLSerializableClass serializableClass = new SLLSerializableClass()
            {
                Users = users.CopyToArray()
            };

            string jsonString = JsonSerializer.Serialize(serializableClass);

            File.WriteAllText(fileName, jsonString);
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName">The path of the file</param>
        /// <returns>List of users</returns>
        public static ILinkedListADT? DeserializeUsers(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            SLLSerializableClass serializableClass = JsonSerializer.Deserialize<SLLSerializableClass>(jsonString);

            return serializableClass.ConvertToSLL();
        }
    }
}
