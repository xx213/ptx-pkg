using System.Collections.Generic;
using System.Reflection;
using System;

namespace PTXClassLibrary
{
    public class AssemblyInfo
    {
        public string Version { get; set; }
        public string Company { get; set; }
        public string Product { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Configuration { get; set; }
        public string Trademark { get; set; }
        public string Culture { get; set; }
        public string FileVersion { get; set; }
    }

    internal static class AssemblyInfoList
    {
        internal static List<string> assemblyInfoList = new List<string>();

        static AssemblyInfoList()
        {
            // Populate assemblyInfoList with assembly items
            assemblyInfoList.Add("Version: " + GetProjectVersion());
            assemblyInfoList.Add("Company: " + GetAssemblyCompany());
            assemblyInfoList.Add("Product: " + GetAssemblyProduct());
            assemblyInfoList.Add("Title: " + GetAssemblyTitle());
            assemblyInfoList.Add("Description: " + GetAssemblyDescription());
            assemblyInfoList.Add("Configuration: " + GetAssemblyConfiguration());
            assemblyInfoList.Add("Trademark: " + GetAssemblyTrademark());
            assemblyInfoList.Add("Culture: " + GetAssemblyCulture());
            assemblyInfoList.Add("File Version: " + GetAssemblyFileVersion());
        }

        // Convert assemblyInfoList to AssemblyInfo object
        public static AssemblyInfo GetAssemblyInfoDTO()
        {
            return new AssemblyInfo
            {
                Version = GetProjectVersion(),
                Company = GetAssemblyCompany(),
                Product = GetAssemblyProduct(),
                Title = GetAssemblyTitle(),
                Description = GetAssemblyDescription(),
                Configuration = GetAssemblyConfiguration(),
                Trademark = GetAssemblyTrademark(),
                Culture = GetAssemblyCulture(),
                FileVersion = GetAssemblyFileVersion()
            };
        }

        // Methods to get assembly items
        private static string GetProjectVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;
            return version.ToString();
        }

        private static string GetAssemblyCompany()
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;
        }

        private static string GetAssemblyProduct()
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;
        }

        private static string GetAssemblyTitle()
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
        }

        private static string GetAssemblyDescription()
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
        }

        private static string GetAssemblyConfiguration()
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyConfigurationAttribute>().Configuration;
        }

        private static string GetAssemblyTrademark()
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTrademarkAttribute>().Trademark;
        }

        private static string GetAssemblyCulture()
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCultureAttribute>().Culture;
        }

        private static string GetAssemblyFileVersion()
        {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
        }
    }
}
