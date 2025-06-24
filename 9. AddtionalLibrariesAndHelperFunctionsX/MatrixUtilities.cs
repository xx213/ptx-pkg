using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// A static class containing functions related to matrix operations.
    /// </summary>
    public static class MatrixUtilities
    {
        /// <summary>
        /// Transposes a List of string arrays.
        /// </summary>
        /// <param name="inputList">The input List to be transposed.</param>
        /// <returns>The transposed List.</returns>
        public static List<string[]> TransposeList(List<string[]> inputList)
        {
            try
            {
                if (inputList == null || inputList.Count == 0)
                {
                    return new List<string[]>();
                }

                int numRows = inputList.Count;
                int numCols = inputList[0].Length;

                List<string[]> transposedList = new List<string[]>();

                for (int col = 0; col < numCols; col++)
                {
                    string[] transposedRow = new string[numRows];

                    for (int row = 0; row < numRows; row++)
                    {
                        // Check if indices are within bounds
                        if (row < inputList.Count && col < inputList[row].Length)
                        {
                            transposedRow[row] = inputList[row][col];
                        }
                        else
                        {
                            // Use default value when indices are out of bounds
                            transposedRow[row] = ErrorMessages.ewmNA;
                        }
                    }

                    transposedList.Add(transposedRow);
                }

                return transposedList;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error during transposition: {ex.Message}");
                return null; // or throw a more specific exception, depending on your needs
            }
        }
        /// <summary>
        /// Gets or sets the transposed list.
        /// </summary>
        [JsonProperty("transposedList")]
        public static List<string[]> TransposedList { get; set; }





    }
    public class DeepCopyHelper
    {
        public static List<T[]> DeepCopyList<T>(List<T[]> originalList)
        {
            List<T[]> copiedList = new List<T[]>();

            foreach (T[] array in originalList)
            {
                T[] newArray = new T[array.Length];
                Array.Copy(array, newArray, array.Length);
                copiedList.Add(newArray);
            }

            return copiedList;
        }

        public static List<T> DeepCopyList<T>(List<T> originalList)
        {
            List<T> copiedList = new List<T>(originalList);
            return copiedList;
        }

        public static T DeepCopy<T>(T originalObject)
        {
            if (originalObject == null)
                throw new ArgumentNullException(nameof(originalObject));

            // For reference types, check if T implements ICloneable
            if (typeof(T).IsClass && typeof(ICloneable).IsAssignableFrom(typeof(T)))
            {
                // If T implements ICloneable, use its Clone method
                return (T)((ICloneable)originalObject).Clone();
            }

            // For arrays, use Array.Clone
            if (typeof(T).IsArray)
            {
                return (T)(object)((Array)(object)originalObject).Clone();
            }

            // For other types, throw an exception or use a custom deep copy mechanism
            throw new NotSupportedException($"Deep copy is not supported for type '{typeof(T)}'.");
        }


    }
}
