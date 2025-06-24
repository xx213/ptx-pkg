using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace PTXClassLibrary
{
    /// <summary>
    /// List of member and scheme data ListDyn required for the DQA and calcs.
    /// This function contain the data in two formats 
    ///     CalcsDataModels.DataListDyn List<dynamic> used to transfer data
    ///     and 
    ///     dataListStringArr List<String[]> , this is read in, after it has been used, remove.
    ///     dataListDynArr    List<Dynamic[]>, this is used in calculation functions. 
    ///         and List<String>fieldNames[].
    ///         and List<String>dataUIDs[].
    /// Contains conversion functions from Dyn to String[] and Headers.
    /// Non Data items are also required
    /// 
    /// Format CalcsDataModels <string, dynamic>, the values read in will be strings 
    /// dataUID  (eg MemUID, ScmUID)                |  Valid fieldName eg memDOB   | memNino             | Pre88GMPTotDOL.
    /// PTXUID000654                                |  string "25/01/1977"}        | string "AB12345A"   | string "500.00".
    /// A42564                                      |  string "Blah Blah"}         | string "999.99"     | string "SomeText".
    ///
    /// dataListStringArr List<String[]>
    /// dataUID  (eg MemUID, ScmUID)                |  Valid fieldName eg memDOB  | memNino             | Pre88GMPTotDOL.
    /// PTXUID000654                                |  string "25/01/1977"        | string "AB12345A"   | string "500.00".
    /// A42564                                      |  string "Blah Blah"         | string "999.99"     | string "SomeText".
    /// 
    /// Format dataListStringArr <string, dynamic>, 
    /// dataUID  (eg MemUID, ScmUID)                |  Valid fieldName eg memDOB  | memNino             | Pre88GMPTotDOL.
    /// PTXUID000654                                |  datetime 25/01/1977        | string "AB12345A"   | double "500.00"
    /// A42564                                      |  string "Blah Blah"         | string "999.99"     | string "SomeText".
    /// 
    /// 
    /// Row 1 = Valid Fieldnames == fieldHeaders[].
    /// Column 1 = Unique Data row Identifier == dataUIDs[].
    /// Col 2+ and Row 2+ Dynamic values. == dataListDynArr[]
    /// 
    /// </summary>
    public class CalcsDataModels
    {
        // This is the format that is used in calcs, list of Data 
        public List<dynamic[]> CalcDataListDynArr { get; set; }

        // Other Allowable data formats in to the interface
        // This is used to transfer data around, normally as json
        public List<dynamic> InCalcDataListDyn { get; set; }

        // This is the format that normally comes in from json
        public List<string[]> InCalcDataListStringArr { get; set; }

        // This is a v generic format
        public dynamic InCalcDataDyn { get; set; }

        public List<PTXMappingRow> InlistPTXFieldMappings { get; set; }

        
        public CalcsDataModels(List<dynamic[]> dataListDynArr)
        {
            CalcDataListDynArr = dataListDynArr;
        }

        public CalcsDataModels(List<dynamic[]> dataListDynArr, List<PTXMappingRow> inlistPTXFieldMappings)
        {
            CalcDataListDynArr = dataListDynArr;
            InlistPTXFieldMappings = inlistPTXFieldMappings;
        }

        public CalcsDataModels(List<string[]> dataListStringArr)
        {
            InCalcDataListStringArr = dataListStringArr;
            
        }

        public CalcsDataModels(List<string[]> dataListStringArr, List<PTXMappingRow> inlistPTXFieldMappings)
        
            {
            InCalcDataListStringArr = dataListStringArr;
            InlistPTXFieldMappings = inlistPTXFieldMappings;

        }

        public CalcsDataModels(List<dynamic> variableNames, List<dynamic> data)
        {
            // Initialize the list with the variable names as the first row
            CalcDataListDynArr = new List<dynamic[]> { variableNames.ToArray() };

            // Add the data as the second row
            CalcDataListDynArr.Add(data.ToArray());
        }

        public CalcsDataModels(List<dynamic> dataListDyn)
        {
            InCalcDataListDyn = dataListDyn;
           // CalcDataListDynArr = ConvertToDataListDynArr(dataListDyn);
        }

        public CalcsDataModels()
        {
            //Empty model
        }

        // Function to convert List<string[]> to List<dynamic[]>
        private List<dynamic[]> ConvertToDataListDynArr(List<string[]> dataListStringArr)
        {
            return dataListStringArr.Select(arr => arr.Cast<dynamic>().ToArray()).ToList();
        }

        // Function to convert List<dynamic> to List<dynamic[]>
        private List<dynamic[]> ConvertToDataListDynArr(List<dynamic> dataListDyn)
        {
            return dataListDyn.Select(item => new dynamic[] { item }).ToList();
        }


        /// <summary>
        /// Gets the value by field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>The value corresponding to the provided field name.</returns>


        public dynamic GetValueByFieldNameAndUID(string fieldName, string uid)
        {
            // Find index of the field
            int fieldIndex = Array.IndexOf(CalcDataListDynArr[0], fieldName);
            if (fieldIndex == -1)
                throw new ArgumentException("Field name not found.");

            // Find index of the UID
            int uidIndex = -1;
            for (int i = 0; i < CalcDataListDynArr.Count; i++)
            {
                if (CalcDataListDynArr[i][0] == uid)
                {
                    uidIndex = i;
                    break;
                }
            }

            if (uidIndex == -1)
                throw new ArgumentException("UID not found.");

            // Return value at specified field index in row corresponding to UID
            return CalcDataListDynArr[uidIndex][fieldIndex];
        }



        /// <summary>
        /// Gets the List under by UID.
        /// </summary>
        /// <param name="DataUID">The UID eh MemUID.</param>
        /// <returns>The value corresponding to the provided UID.</returns>
        public dynamic GetValueByDataUID(string DataUID)
        {
            int uidIndex = CalcDataListDynArr.Select(row => row[0]).ToList().IndexOf(DataUID);
            if (uidIndex == -1)
                throw new ArgumentException("UID not found.");

            // Get row corresponding to UID and return
            return CalcDataListDynArr[uidIndex];
        }



        /// <summary>
        /// Creates the type of the in dataListDyn collection.
        /// </summary>
        /// <param name="fieldNames">The field names.</param>
        /// <param name="fieldTypes">The field types.</param>
        /// <returns>The created type of CalcsDataModels.</returns>
        public static Type CreateInDataCollection(List<string> fieldNames, List<Type> fieldTypes)
        {
            if (fieldNames.Count != fieldTypes.Count)
                throw new ArgumentException("Field names count must match field types count.");

            var assemblyName = new AssemblyName("InDataAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            var typeBuilder = moduleBuilder.DefineType("InDataCollectionType", TypeAttributes.Public);

            // Define fields
            for (int i = 0; i < fieldNames.Count; i++)
            {
                typeBuilder.DefineField(fieldNames[i], fieldTypes[i], FieldAttributes.Public);
                // Add JsonProperty attribute to each field
                var property = typeBuilder.DefineProperty(fieldNames[i], System.Reflection.PropertyAttributes.None, fieldTypes[i], null);
                var attributeConstructor = typeof(JsonPropertyAttribute).GetConstructor(new[] { typeof(string) });
                var attributeBuilder = new CustomAttributeBuilder(attributeConstructor, new object[] { fieldNames[i] });
                property.SetCustomAttribute(attributeBuilder);
            }

            return typeBuilder.CreateType();
        }
    }


}
