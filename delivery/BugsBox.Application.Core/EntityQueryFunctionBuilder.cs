using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BugsBox.Application.Core
{
    public static class EntityQueryFunctionBuilder
    {
        private static Type NotMappedAttributeType = typeof (NotMappedAttribute);

        #region 基本方法

        public static string GetTypeCodeString(Type type)
        {
            if (type == typeof(int))
            {
                return "int";
            }
            if (type == typeof(bool))
            {
                return "bool";
            }
            if (type == typeof(decimal))
            {
                return "decimal";
            }
            if (type == typeof(void))
            {
                return "void";
            }
            if (type.IsGenericType)
            {
                string args = string.Empty;
                string original = null;
                var genericArguments = type.GetGenericArguments();
                var iType = type.GetGenericTypeDefinition().UnderlyingSystemType;
                original = iType.Name.Replace("`" + genericArguments.Length, "");
                for (int i = 0; i < genericArguments.Length; i++)
                {

                    var genericArgument = genericArguments[i].Name;
                    args += genericArgument;
                    original = original.Replace(genericArgument, "");
                    if (i < genericArguments.Length - 1)
                    {
                        args += ",";
                    }

                }
                args = original.Replace(args.Replace(",", ""), "") + "<" + args + ">";
                return args;
            }
            else
            {
                return type.Name;
            }
        }

        public static bool NeedGenerateProperty(PropertyInfo entitypropertyInfo)
        {
            if (entitypropertyInfo == null)
                return false;
            if (
                entitypropertyInfo.GetCustomAttributes(true)
                    .Where(a => a is NotMappedAttribute)
                    .Count()<=0)
                return true;
            else
            {
                return false;
            }
        }

        #endregion

        static Dictionary<Type, string> CanQueryTypes = new Dictionary<Type, string>();
        static Dictionary<Type, string> CanQueryModelTypes = new Dictionary<Type, string>();

        static EntityQueryFunctionBuilder()
        {
            CanQueryTypes.Add(typeof(string), "string");
            CanQueryTypes.Add(typeof(DateTime), "DateTime");
            CanQueryTypes.Add(typeof(int), "int");
            CanQueryTypes.Add(typeof(decimal), "decimal");
            CanQueryTypes.Add(typeof(bool), "bool");

            CanQueryModelTypes.Add(typeof(string), "string");
            CanQueryModelTypes.Add(typeof(DateTime), "DateTime");
            CanQueryModelTypes.Add(typeof(int), "int");
            CanQueryModelTypes.Add(typeof(decimal), "decimal");
            CanQueryModelTypes.Add(typeof(bool), "bool");
            CanQueryModelTypes.Add(typeof(Guid), "Guid");
        }

        private const string queryInterfaceStringFormat = @"
        [OperationContract]
	    [FaultContract(typeof(ServiceExceptionDetail))]
        List<{EntityName}> Query{EntityName}s({Parameters}out string msg)";

        public static string BuildQueryInterfaceString(Type etype)
        {
            try
            {
                List<PropertyInfo> fieldinfoList = etype.GetProperties()
                                                   .Where(
                                                       t =>
                                                       t.CanRead && t.CanWrite &&
                                                       CanQueryTypes.ContainsKey(t.PropertyType)
                                                       && NeedGenerateProperty(t)
                                                       && t.Name.LastIndexOf("Id") != t.Name.Length - 2
                                                       )
                                                   .ToList();
                StringBuilder sb = new StringBuilder();
                StringBuilder psb = new StringBuilder();
                fieldinfoList.ForEach(propertyInfo =>
                    {
                        if (!(propertyInfo.Name == "Deleted" || propertyInfo.Name == "DeleteTime"))
                        {
                            if (propertyInfo.PropertyType == typeof(int)
                                || propertyInfo.PropertyType == typeof(DateTime)
                                  || propertyInfo.PropertyType == typeof(decimal)
                                )
                            {
                                psb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + "from," + CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + "to,");
                            }
                            else if (propertyInfo.PropertyType == typeof(string))
                            {
                                psb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + ",");
                            }
                            else if (propertyInfo.PropertyType == typeof(bool))
                            {
                                psb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + ",bool query" + propertyInfo.Name.ToLower() + ",");

                            }
                        }

                    });
                string pString = psb.ToString();
                pString = queryInterfaceStringFormat.Replace("{EntityName}", etype.Name).Replace("{Parameters}", pString);
                return pString;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private const string queryFuctionStringFormat = @" 
        public List<{EntityName}> Query{EntityName}s({Parameters}out string msg)
        {   msg=string.Empty;
            try
            {
                var queryBuilder = QueryBuilder.Create<{EntityName}>(); 
{CodeString}
                return HandlerFactory.{EntityName}BusinessHandler.Fetch(queryBuilder.Expression).ToList();
            }
            catch(Exception ex)
            {
                msg = ""调用{EntityDescription}业务逻辑:查询实体({EntityDescription})失败"";
                return this.HandleException<List<{EntityName}>>(msg, ex);
            }
        }";

        public static string BuildQueryFuctionString(Type etype)
        {
            try
            {
                List<PropertyInfo> fieldinfoList = etype.GetProperties()
                                                   .Where(
                                                       t =>
                                                       t.CanRead && t.CanWrite &&
                                                       CanQueryTypes.ContainsKey(t.PropertyType)
                                                        && NeedGenerateProperty(t)
                                                       && t.Name.LastIndexOf("Id") != t.Name.Length - 2
                                                       )
                                                   .ToList();
                StringBuilder sb = new StringBuilder();
                StringBuilder psb = new StringBuilder();
                fieldinfoList.ForEach(propertyInfo =>
                {
                    if (!(propertyInfo.Name == "Deleted" || propertyInfo.Name == "DeleteTime"))
                    {
                        if (propertyInfo.PropertyType == typeof(int)
                            //|| propertyInfo.PropertyType == typeof(DateTime)
                            || propertyInfo.PropertyType == typeof(decimal)
                            )
                        {
                            sb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() +
                                      "from," + CanQueryTypes[propertyInfo.PropertyType] + " " +
                                      propertyInfo.Name.ToLower() + "to,");

                            psb.Append("                if(" + propertyInfo.Name.ToLower() + "to==" +
                                       propertyInfo.Name.ToLower() + "from){//From==To执行==" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + "from);" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                            psb.Append("                else if(" + propertyInfo.Name.ToLower() + "to>" +
                                       propertyInfo.Name.ToLower() + "from){//From<To执行Between" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Between(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + "from," + propertyInfo.Name.ToLower() + "to);" +
                                       Environment.NewLine);
                            psb.Append("                }//From>To不参与条件" + Environment.NewLine);

                        }
                        else if (propertyInfo.PropertyType == typeof(DateTime))
                        {
                            sb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() +
                                     "from," + CanQueryTypes[propertyInfo.PropertyType] + " " +
                                     propertyInfo.Name.ToLower() + "to,");

                            psb.Append("                if(" + propertyInfo.Name.ToLower() + "to!=default(DateTime)&&" +
                                       propertyInfo.Name.ToLower() + "from!=default(DateTime)){//From==To执行==" + Environment.NewLine);

                            psb.Append("                if(" + propertyInfo.Name.ToLower() + "to==" +
                                       propertyInfo.Name.ToLower() + "from){//From==To执行==" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + "from);" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                            psb.Append("                else if(" + propertyInfo.Name.ToLower() + "to>" +
                                       propertyInfo.Name.ToLower() + "from){//From<To执行Between" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Between(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + "from," + propertyInfo.Name.ToLower() + "to);" +
                                       Environment.NewLine);
                            psb.Append("                }}//From>To不参与条件" + Environment.NewLine);
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            psb.Append("                if(!string.IsNullOrEmpty(" + propertyInfo.Name.ToLower() +
                                       ")){//非null且非empty参与like条件" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Like(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + ");" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);

                            sb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + ",");
                        }
                        else if (propertyInfo.PropertyType == typeof(bool))
                        {
                            sb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() +
                                      ",bool query" + propertyInfo.Name.ToLower() + ",");

                            psb.Append("                if(query" + propertyInfo.Name.ToLower() + "){//enabeQuery参与查询条件" +
                                       Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + ");" + Environment.NewLine);
                            psb.Append("}" + Environment.NewLine);

                        }
                    }

                });
                string pString = psb.ToString();
                pString = queryFuctionStringFormat.Replace("{EntityName}", etype.Name).Replace("{CodeString}", pString)
                                                  .Replace("{Parameters}", sb.ToString())
                                                  .Replace("{EntityDescription}", EntityExtensions.GetDescription(etype));
                return pString;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        private const string queryPageInterfaceStringFormat = @"
        [OperationContract]
	    [FaultContract(typeof(ServiceExceptionDetail))]
        List<{EntityName}> QueryPaged{EntityName}s({Parameters}int index,int size,out PagerInfo pager)";

        public static string BuildQueryPageInterfaceString(Type etype)
        {
            try
            {
                List<PropertyInfo> fieldinfoList = etype.GetProperties()
                                                   .Where(
                                                       t =>
                                                       t.CanRead && t.CanWrite &&
                                                       CanQueryTypes.ContainsKey(t.PropertyType)
                                                       && NeedGenerateProperty(t)
                                                       && t.Name.LastIndexOf("Id") != t.Name.Length - 2
                                                       )
                                                   .ToList();
                StringBuilder sb = new StringBuilder();
                StringBuilder psb = new StringBuilder();
                fieldinfoList.ForEach(propertyInfo =>
                {
                    if (!(propertyInfo.Name == "Deleted" || propertyInfo.Name == "DeleteTime"))
                    {
                        if (propertyInfo.PropertyType == typeof(int)
                            || propertyInfo.PropertyType == typeof(DateTime)
                              || propertyInfo.PropertyType == typeof(decimal)
                            )
                        {
                            psb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + "from," + CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + "to,");
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            psb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + ",");
                        }
                        else if (propertyInfo.PropertyType == typeof(bool))
                        {
                            psb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + ",bool query" + propertyInfo.Name.ToLower() + ",");

                        }
                    }

                });
                string pString = psb.ToString();
                pString = queryPageInterfaceStringFormat.Replace("{EntityName}", etype.Name).Replace("{Parameters}", pString);
                return pString;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private const string queryPageFuctionStringFormat = @" 
        public List<{EntityName}> QueryPaged{EntityName}s({Parameters}int index,int size,out PagerInfo pager)
        {   
            pager = PagerInfo.Validate(new PagerInfo {Index = index, Size = size});
            try
            {
                var order = EntityOrderDictionary.GetOrder<{EntityName}>();
                var queryBuilder = QueryBuilder.Create<{EntityName}>(); 
{CodeString}
                return HandlerFactory.{EntityName}BusinessHandler.Fetch(queryBuilder.Expression, order, pager).ToList();
            }
            catch(Exception ex)
            {
                pager=new PagerInfo();  
                return this.HandleException<List<{EntityName}>>(""调用{EntityDescription}业务逻辑:查询实体({EntityDescription})失败"", ex);
            }
        }";

        public static string BuildQueryPageFuctionString(Type etype)
        {
            try
            {
                List<PropertyInfo> fieldinfoList = etype.GetProperties()
                                                   .Where(
                                                       t =>
                                                       t.CanRead && t.CanWrite &&
                                                       CanQueryTypes.ContainsKey(t.PropertyType)
                                                       && NeedGenerateProperty(t)
                                                       && t.Name.LastIndexOf("Id") != t.Name.Length - 2
                                                       )
                                                   .ToList();
                StringBuilder sb = new StringBuilder();
                StringBuilder psb = new StringBuilder();
                fieldinfoList.ForEach(propertyInfo =>
                {
                    if (!(propertyInfo.Name == "Deleted" || propertyInfo.Name == "DeleteTime"))
                    {
                        if (propertyInfo.PropertyType == typeof (int)
                            //|| propertyInfo.PropertyType == typeof (DateTime)
                            || propertyInfo.PropertyType == typeof (decimal)
                            )
                        {
                            sb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() +
                                      "from," + CanQueryTypes[propertyInfo.PropertyType] + " " +
                                      propertyInfo.Name.ToLower() + "to,");

                            psb.Append("                if(" + propertyInfo.Name.ToLower() + "to==" +
                                       propertyInfo.Name.ToLower() + "from){//From==To执行==" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + "from);" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                            psb.Append("                else if(" + propertyInfo.Name.ToLower() + "to>" +
                                       propertyInfo.Name.ToLower() + "from){//From>To执行Between" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Between(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + "from," + propertyInfo.Name.ToLower() + "to);" +
                                       Environment.NewLine);
                            psb.Append("                }//From<To不参与条件" + Environment.NewLine);

                        }
                        else if (propertyInfo.PropertyType == typeof(DateTime))
                        {
                            sb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() +
                                     "from," + CanQueryTypes[propertyInfo.PropertyType] + " " +
                                     propertyInfo.Name.ToLower() + "to,");


                            psb.Append("                if(" + propertyInfo.Name.ToLower() + "to!=default(DateTime)&&" +
                                       propertyInfo.Name.ToLower() + "from!=default(DateTime)){//From==To执行==" + Environment.NewLine);

                            psb.Append("                if(" + propertyInfo.Name.ToLower() + "to==" +
                                       propertyInfo.Name.ToLower() + "from){//From==To执行==" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + "from);" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                            psb.Append("                else if(" + propertyInfo.Name.ToLower() + "to>" +
                                       propertyInfo.Name.ToLower() + "from){//From>To执行Between" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Between(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + "from," + propertyInfo.Name.ToLower() + "to);" +
                                       Environment.NewLine);
                            psb.Append("                }}//From<To不参与条件" + Environment.NewLine);
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            psb.Append("                if(!string.IsNullOrEmpty(" + propertyInfo.Name.ToLower() +
                                       ")){//非null且非empty参与like条件" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Like(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + ");" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);

                            sb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() + ",");
                        }
                        else if (propertyInfo.PropertyType == typeof(bool))
                        {
                            sb.Append(CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name.ToLower() +
                                      ",bool query" + propertyInfo.Name.ToLower() + ",");

                            psb.Append("                if(query" + propertyInfo.Name.ToLower() + "){//enabeQuery参与查询条件" +
                                       Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", " +
                                       propertyInfo.Name.ToLower() + ");" + Environment.NewLine);
                            psb.Append("}" + Environment.NewLine);

                        }
                    }

                });
                string pString = psb.ToString();
                pString = queryPageFuctionStringFormat.Replace("{EntityName}", etype.Name).Replace("{CodeString}", pString)
                                                  .Replace("{Parameters}", sb.ToString())
                                                  .Replace("{EntityDescription}", EntityExtensions.GetDescription(etype));
                return pString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        } 

        public static string BuildQueryModelPropertyString(Type etype)
        {
            try
            {
                List<PropertyInfo> fieldinfoList = etype.GetProperties()
                                   .Where(
                                       t =>
                                       t.CanRead && t.CanWrite &&
                                       CanQueryModelTypes.ContainsKey(t.PropertyType)
                                       && NeedGenerateProperty(t)
                                       && t.Name.LastIndexOf("Id") != 0
                                       )
                                   .ToList();
                StringBuilder ps = new StringBuilder();
                ps.Append(Environment.NewLine);
                fieldinfoList.ForEach(propertyInfo =>
                {
                    if (!(propertyInfo.Name == "Deleted" || propertyInfo.Name == "DeleteTime"))
                    {
                        if (propertyInfo.PropertyType == typeof(int)
                            || propertyInfo.PropertyType == typeof(DateTime)
                            || propertyInfo.PropertyType == typeof(decimal)
                            )
                        {
                            ps.Append("        [DataMember]\r\n\t\tpublic " + CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name + "From;" + Environment.NewLine);
                            ps.Append("        [DataMember]\r\n\t\tpublic " + CanQueryTypes[propertyInfo.PropertyType] + " " + propertyInfo.Name + "To;" + Environment.NewLine); 

                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            ps.Append("        [DataMember]\r\n\t\tpublic string " + propertyInfo.Name + ";" + Environment.NewLine); 
                        }
                        else if (propertyInfo.PropertyType == typeof(bool))
                        {
                            ps.Append("        [DataMember]\r\n\t\tpublic bool " + propertyInfo.Name + ";" + Environment.NewLine);
                            ps.Append("        [DataMember]\r\n\t\tpublic bool Query" + propertyInfo.Name + "=false;" + Environment.NewLine); 

                        }
                        else if (propertyInfo.PropertyType == typeof (Guid))
                        {
                            ps.Append("        [DataMember]\r\n\t\tpublic Guid " + propertyInfo.Name + ";" + Environment.NewLine); 
                        }
                    }

                }); 

               return ps.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private const string SearchEntitiesByQueryModelFunctionCodeFormat = @" 
            try
            {
                message=string.Empty;
                var order = EntityOrderDictionary.GetOrder<{EntityName}>();
                var queryBuilder = QueryBuilder.Create<{EntityName}>(); 
{CodeString}
                return HandlerFactory.{EntityName}BusinessHandler.Fetch(queryBuilder.Expression, order).ToList();
            }
            catch(Exception ex)
            {  
                message=""调用{EntityDescription}业务逻辑:通查询Model查询实体({EntityDescription})失败"";
                return this.HandleException<List<{EntityName}>>(message, ex);
            }";

        public static string BuildSearchEntitiesByQueryModelFunctionCode(Type etype)
        {
            try
            {
                List<PropertyInfo> fieldinfoList = etype.GetProperties()
                                                   .Where(
                                                       t =>
                                                       t.CanRead && t.CanWrite &&
                                                       CanQueryModelTypes.ContainsKey(t.PropertyType)
                                                       && NeedGenerateProperty(t)
                                                       && t.Name.LastIndexOf("Id") !=0
                                                       )
                                                   .ToList(); 
                StringBuilder psb = new StringBuilder();
                fieldinfoList.ForEach(propertyInfo =>
                {
                    if (!(propertyInfo.Name == "Deleted" || propertyInfo.Name == "DeleteTime"))
                    {
                        if (propertyInfo.PropertyType == typeof(int)
                            //|| propertyInfo.PropertyType == typeof(DateTime)
                            || propertyInfo.PropertyType == typeof(decimal)
                            )
                        {

                            psb.Append("                if(qModel." + propertyInfo.Name + "To==" +
                                       "qModel." + propertyInfo.Name + "From){//From==To执行==" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + "From);" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                            psb.Append("                else if(qModel." + propertyInfo.Name + "To>qModel." +
                                       propertyInfo.Name + "From){//From<To执行Between" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Between(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + "From,qModel." + propertyInfo.Name + "To);" +
                                       Environment.NewLine);
                            psb.Append("                }//From>To不参与条件" + Environment.NewLine);

                        }
                        else if (propertyInfo.PropertyType == typeof (DateTime))
                        {
                            psb.Append("                if(qModel." + propertyInfo.Name + "To!=default(DateTime)&&" +
                                     "qModel." + propertyInfo.Name + "From!=default(DateTime)){" + Environment.NewLine);
                            psb.Append("                if(qModel." + propertyInfo.Name + "To==" +
                                       "qModel." + propertyInfo.Name + "From){//From==To执行==" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + "From);" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                            psb.Append("                else if(qModel." + propertyInfo.Name + "To>qModel." +
                                       propertyInfo.Name + "From){//From<To执行Between" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Between(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + "From,qModel." + propertyInfo.Name + "To);" +
                                       Environment.NewLine);
                            psb.Append("                }//From>To不参与条件" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            psb.Append("                if(!string.IsNullOrEmpty(qModel." + propertyInfo.Name +
                                       ")){//非null且非empty参与like条件" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Like(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + ");" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine); 
                           
                        }
                        else if (propertyInfo.PropertyType == typeof(bool))
                        {
                            psb.Append("                if(qModel.Query" + propertyInfo.Name + "){//enabeQuery参与查询条件" +
                                       Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + ");" + Environment.NewLine);
                            psb.Append("}" + Environment.NewLine);

                        }else if (propertyInfo.PropertyType == typeof(Guid))
                        {
                            psb.Append("                if(qModel." + propertyInfo.Name + "!=default(Guid)){//非null且非empty参与like条件" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + ");" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);

                        }
                    }

                });
                string pString = psb.ToString();
                pString = SearchEntitiesByQueryModelFunctionCodeFormat
                    .Replace("{EntityName}", etype.Name)
                    .Replace("{CodeString}", pString)
                    .Replace("{EntityDescription}", EntityExtensions.GetDescription(etype)); 
                return pString;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        //BuildSearchPagedEntitiesByQueryModelFunctionCode
        private const string SearchPagedEntitiesByQueryModelFunctionCodeFormat = @" 
            pager = PagerInfo.Validate(new PagerInfo {Index = index, Size = size});
            try
            {
                var order = EntityOrderDictionary.GetOrder<{EntityName}>();
                var queryBuilder = QueryBuilder.Create<{EntityName}>(); 
{CodeString}
                return HandlerFactory.{EntityName}BusinessHandler.Fetch(queryBuilder.Expression, order, pager).ToList();
            }
            catch(Exception ex)
            {
                pager=new PagerInfo(); 
                return this.HandleException<List<{EntityName}>>(""调用{EntityDescription}业务逻辑:通过查询Model分页查询实体({EntityDescription})失败"", ex);
            }";

        public static string BuildSearchPagedEntitiesByQueryModelFunctionCode(Type etype)
        {
            try
            {
                List<PropertyInfo> fieldinfoList = etype.GetProperties()
                                                   .Where(
                                                       t =>
                                                       t.CanRead && t.CanWrite &&
                                                       CanQueryModelTypes.ContainsKey(t.PropertyType)
                                                       && NeedGenerateProperty(t)
                                                       && t.Name.LastIndexOf("Id") != 0
                                                       )
                                                   .ToList();
                StringBuilder psb = new StringBuilder();
                fieldinfoList.ForEach(propertyInfo =>
                {
                    if (!(propertyInfo.Name == "Deleted" || propertyInfo.Name == "DeleteTime"))
                    {
                        if (propertyInfo.PropertyType == typeof(int)
                            //|| propertyInfo.PropertyType == typeof(DateTime)
                            || propertyInfo.PropertyType == typeof(decimal)
                            )
                        {

                            psb.Append("                if(qModel." + propertyInfo.Name + "To==" +
                                       "qModel." + propertyInfo.Name + "From){//From==To执行==" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + "From);" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                            psb.Append("                else if(qModel." + propertyInfo.Name + "To>qModel." +
                                       propertyInfo.Name + "From){//From<To执行Between" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Between(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + "From,qModel." + propertyInfo.Name + "To);" +
                                       Environment.NewLine);
                            psb.Append("                }//From>To不参与条件" + Environment.NewLine);

                        }
                        else if (propertyInfo.PropertyType == typeof(DateTime))
                        {
                            psb.Append("                if(qModel." + propertyInfo.Name + "To!=default(DateTime)&&" +
                                     "qModel." + propertyInfo.Name + "From!=default(DateTime)){" + Environment.NewLine);
                            psb.Append("                if(qModel." + propertyInfo.Name + "To==" +
                                       "qModel." + propertyInfo.Name + "From){//From==To执行==" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + "From);" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                            psb.Append("                else if(qModel." + propertyInfo.Name + "To>qModel." +
                                       propertyInfo.Name + "From){//From<To执行Between" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Between(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + "From,qModel." + propertyInfo.Name + "To);" +
                                       Environment.NewLine);
                            psb.Append("                }//From>To不参与条件" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            psb.Append("                if(!string.IsNullOrEmpty(qModel." + propertyInfo.Name +
                                       ")){//非null且非empty参与like条件" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Like(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + ");" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);

                        }
                        else if (propertyInfo.PropertyType == typeof(bool))
                        {
                            psb.Append("                if(qModel.Query" + propertyInfo.Name + "){//enabeQuery参与查询条件" +
                                       Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + ");" + Environment.NewLine);
                            psb.Append("}" + Environment.NewLine);

                        }
                        else if (propertyInfo.PropertyType == typeof(Guid))
                        {
                            psb.Append("                if(qModel." + propertyInfo.Name + "!=default(Guid)){//非null且非empty参与like条件" + Environment.NewLine);
                            psb.Append("                    queryBuilder.Equals(a => a." + propertyInfo.Name + ", qModel." +
                                       propertyInfo.Name + ");" + Environment.NewLine);
                            psb.Append("                }" + Environment.NewLine);

                        }
                    }

                });
                string pString = psb.ToString();
                pString = SearchPagedEntitiesByQueryModelFunctionCodeFormat
                    .Replace("{EntityName}", etype.Name)
                    .Replace("{CodeString}", pString)
                    .Replace("{EntityDescription}", EntityExtensions.GetDescription(etype)); 

                return pString;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


    }
}
