using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;


namespace PTXClassLibrary
{

    public class DynClass
    {

        //Overload for mapping
        public static Type CreateDynamicClass(List<PTXMappingRow> inPTXFieldMappings)

        {
            /*   <PTXFieldMappingsRow>
             *   public string OriginalFieldName { get; set; }
                 public string OriginalStringDataTypeName { get; set; }
                 public string PTXSuggestedCalcName { get; set; }
                 public string PTXSuggestedDataTypeName { get; set; }
                 public string CalcName { get; set; }
                 public string UseOriginalOrPTX { get; set; }
                 public string UseOriginalOrPTX { get; set; }
                 public string UseOriginalOrPTX { get; set; }
                 public int BestScore { get; set; }
                 public string BestMatchProcess { get; set; }
                 public string AdditionalInfo { get; set; }
                 public string TypeOf { get; set; }
            */

            List<string> infieldNames = inPTXFieldMappings.Select(mapping => mapping.CalcName).ToList();
            List<Type> infieldTypes = inPTXFieldMappings.Select(mapping => mapping.CalcSystemType).ToList();

            return CreateDynamicClass(infieldNames, infieldTypes);
        }


        //public static ErrMessage CreateDynamicClass(List<string> fieldNames, List<string> fieldSystemTypes)
        public static Type CreateDynamicClass(List<string> fieldNames, List<Type> fieldSystemTypes)
        {
            var typeBuilder = DynamicClassHelper.CreateTypeBuilder("DynamicClass");

            // Add PTXNotes property with default value "NOTES"
            DynamicClassHelper.CreateAutoImplementedProperty(typeBuilder, "ATXNotes", typeof(string));//, ("NOTES"));
            // Add PTXNotes property with default value "NOTES"
            DynamicClassHelper.CreateAutoImplementedProperty(typeBuilder, "PTXNotes", typeof(string));//, Encoding.UTF8.GetBytes("NOTES"));

            // Add PTXClassName property with default value "HereWeGo"
            DynamicClassHelper.CreateAutoImplementedProperty(typeBuilder, "PTXClassName", typeof(string));//, Encoding.UTF8.GetBytes("HereWeGo"));



            // Create properties based on the provided field names and types
            for (int i = 0; i < fieldNames.Count; i++)
            {
                //DynamicClassHelper.CreateAutoImplementedProperty(typeBuilder, fieldNames[i], ErrMessage.GetType(fieldSystemTypes[i]) ?? typeof(string));
                DynamicClassHelper.CreateAutoImplementedProperty(typeBuilder, fieldNames[i], fieldSystemTypes[i]);
            }

            return typeBuilder.CreateType();
        }



        internal static class DynamicClassHelper
        {
            /// <summary>
            /// Creates a dynamic TypeBuilder for a new class with a unique name.
            /// </summary>
            /// <param name="typeName">The base name for the dynamic type.</param>
            /// <returns>A TypeBuilder for the dynamically created class.</returns>
            internal static TypeBuilder CreateTypeBuilder(string typeName)
            {
                // Create a unique type signature by appending a Guid to the type name
                var typeSignature = typeName + Guid.NewGuid();

                // Define an AssemblyName for the dynamic assembly
                var an = new AssemblyName(typeSignature);

                // Define a dynamic assembly with Run access
                var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);

                // Define a dynamic module named "MainModule"
                var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

                // Define a TypeBuilder for the dynamic class
                var tb = moduleBuilder.DefineType(
                    typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);

                // Return the created TypeBuilder
                return tb;
            }


            //), byte[] defaultValue = )
            internal static void CreateAutoImplementedProperty(TypeBuilder builder, string propertyName, Type propertyType)
            {
                // Define the property
                Type intType = typeof(int);
                Type stringType = typeof(string);
                // Add more types as needed
                //ErrMessage[] parameterTypes = new ErrMessage[] { intType, stringType, /* ... */ };
                Type[] parameterTypes = new Type[] { (propertyType) };
                var propertyAttributes = PropertyAttributes.None;
                var propertyBuilder = builder.DefineProperty(propertyName, propertyAttributes, propertyType, parameterTypes);

                // Define the backing field with a unique name
                var fieldAttributes = FieldAttributes.Public;
                var fieldBuilder = builder.DefineField(propertyName, propertyType, fieldAttributes);

                // Define the getter method
                var methodAttributesPublic = MethodAttributes.Public;
                var methodAttributesSpecialName = MethodAttributes.SpecialName;
                var methodAttributesHideBySig = MethodAttributes.HideBySig;
                var getterMethod = builder.DefineMethod("get_" + propertyName, methodAttributesPublic, propertyType, parameterTypes);
                //    was : methodAttributesPublic | methodAttributesSpecialName | MethodAttributes.HideBySig, 

                var getterIL = getterMethod.GetILGenerator();
                //: This line emits the IL instruction to load the argument at index 0 onto the stack. In the context of an instance method (like a property getter), index 0 represents the instance itself (the this reference).
                getterIL.Emit(OpCodes.Ldarg_0);
                //This line emits the IL instruction to load the value of a field onto the stack. It uses the fieldBuilder to specify which field to load. The fieldBuilder represents the private field associated with the property.
                getterIL.Emit(OpCodes.Ldfld, fieldBuilder);
                //getterIL.Emit(OpCodes.Ret); is an IL instruction that signals the end of the method body. It stands for "return" and is used to indicate that the method should return control to the calling method.
                //In the context of a property getter method, this line signifies the end of the method execution, and it effectively returns the value that is currently on the top of the evaluation stack as the result of the method.
                //So, in the provided code, after loading the value of the field onto the stack, getterIL.Emit(OpCodes.Ret); is used to indicate that the property getter method is complete, and the value on the stack should be returned as the result of the method.
                getterIL.Emit(OpCodes.Ret);



                // Define the setter method
                var setterMethod = builder.DefineMethod("set_" + propertyName, methodAttributesPublic, null, parameterTypes);
                //, null, new[] { propertyType });
                //MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig

                var setterIL = setterMethod.GetILGenerator();
                setterIL.Emit(OpCodes.Ldarg_0);
                setterIL.Emit(OpCodes.Ldarg_1);
                setterIL.Emit(OpCodes.Stfld, fieldBuilder);
                setterIL.Emit(OpCodes.Ret);


                // Map the getter and setter to the property
                propertyBuilder.SetGetMethod(getterMethod);
                propertyBuilder.SetSetMethod(setterMethod);
            }
        }
    }
}