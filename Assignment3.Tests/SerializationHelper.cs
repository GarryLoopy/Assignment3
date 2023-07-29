using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assignment3.Tests
{
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
