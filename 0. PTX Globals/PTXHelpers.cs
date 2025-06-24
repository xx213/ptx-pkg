using System;
using System.Collections.Generic;
using System.Linq;


namespace PTXClassLibrary
{
    /// <summary>
    /// Helper class for common operations.
    /// </summary>
    public static class PTXHelpers
    {
        /// <summary>
        /// Retrieves a specific item by its ID from a list.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="id">The ID of the item to retrieve.</param>
        /// <returns>The item with the specified ID, or null if not found.</returns>
        public static T GetByID<T>(List<T> list, string id) where T : IIDentifiable
        {
            return list.Find(item => item.ID == id);
        }

        /// <summary>
        /// Represents an identifiable object.
        /// </summary>
        public interface IIDentifiable
        {
            string ID { get; }
        }

        public static dynamic GenerateRandomDynamicValue()
        {
            Random random = new Random();
            double rand = random.NextDouble();
            dynamic randomValue;

            if (rand < .25)
            {
                // Generate random DateTime
                randomValue = DateTime.Now.AddDays(random.NextDouble() * 100 - 50);
            }
            else if (rand < 0.5)
            { // Generate random string
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                randomValue = new string(Enumerable.Repeat(chars, 10)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            else if (rand < 0.75)
            {

                // Generate random double
                randomValue = random.NextDouble() * 100;
            }
            else
            { // Generate random int
                randomValue = random.Next(100);
            }

            return randomValue;
        }
    }
}