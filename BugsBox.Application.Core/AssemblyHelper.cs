using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BugsBox.Application.Core
{
    /// <summary>
    /// 程序集助手
    /// </summary>
    public static class AssemblyHelper
    { 
        public static AT GetAssembly<AT>(Assembly assembly)
            where AT : Attribute
        {
            if (assembly == null) return default(AT);
            return assembly.GetCustomAttributes(false)
             .FirstOrDefault(t => t == typeof(AT)) as AT;
        }
//[assembly: AssemblyTitle("BugsBox.Application.Core")]
        public static string GetAssemblyTitle(Assembly assembly)
        {
            var AssemblyTitle = GetAssembly<AssemblyTitleAttribute>(assembly);
            if (AssemblyTitle== null)
            {
                return string.Empty;
            }
            return AssemblyTitle.Title;
        }
//[assembly: AssemblyDescription("")]
        public static string GetAssemblyDescription(Assembly assembly)
        {
            var AssemblyDescription = GetAssembly<AssemblyDescriptionAttribute>(assembly);
            if (AssemblyDescription == null)
            {
                return string.Empty;
            }
            return AssemblyDescription.Description;
        }
//[assembly: AssemblyConfiguration("")]
//[assembly: AssemblyCompany("")]
        public static string GetAssemblyCompany(Assembly assembly)
        {
            var AssemblyCompany = GetAssembly<AssemblyCompanyAttribute>(assembly);
            if (AssemblyCompany == null)
            {
                return string.Empty;
            }
            return AssemblyCompany.Company;
        }
//[assembly: AssemblyProduct("BugsBox.Application.Core")]
        public static string GetAssemblyProduct(Assembly assembly)
        {
            var AssemblyProduct = GetAssembly<AssemblyProductAttribute>(assembly);
            if (AssemblyProduct == null)
            {
                return string.Empty;
            }
            return AssemblyProduct.Product;
        }
//[assembly: AssemblyCopyright("Copyright ©  2013")]
        public static string GetAssemblyCopyright(Assembly assembly)
        {
            var AssemblyCopyright = GetAssembly<AssemblyCopyrightAttribute>(assembly);
            if (AssemblyCopyright == null)
            {
                return string.Empty;
            }
            return AssemblyCopyright.Copyright;
        }
//[assembly: AssemblyTrademark("")]
        public static string GetAssemblyTrademark(Assembly assembly)
        {
            var AssemblyTrademark = GetAssembly<AssemblyTrademarkAttribute>(assembly);
            if (AssemblyTrademark == null)
            {
                return string.Empty;
            }
            return AssemblyTrademark.Trademark;
        }
//[assembly: AssemblyCulture("")]  

//[assembly: AssemblyVersion("1.0.0.0")]
        public static string GetAssemblyVersion(Assembly assembly)
        {
            var AssemblyVersion = GetAssembly<AssemblyVersionAttribute>(assembly);
            if (AssemblyVersion == null)
            {
                return string.Empty;
            }
            return AssemblyVersion.Version;
        }
//[assembly: AssemblyFileVersion("1.0.0.0")]
        public static string GetAssemblyFileVersion(Assembly assembly)
        {
            var AssemblyFileVersion = GetAssembly<AssemblyFileVersionAttribute>(assembly);
            if (AssemblyFileVersion == null)
            {
                return string.Empty;
            }
            return AssemblyFileVersion.Version;
        }
    }
}
