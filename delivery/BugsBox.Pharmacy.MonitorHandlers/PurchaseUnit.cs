using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Common;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.MonitorHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class PurchaseUnit
    {
        BusinessHandlerFactory businessHandlerFactory = new BusinessHandlerFactory(new Db(), null);

        /// <summary>
        /// 
        /// </summary>
        public void UpdateValid()
        {
            try
            {
                var puHandler = businessHandlerFactory.PurchaseUnitBusinessHandler.Queryable.Where(r => !r.Deleted);
                    System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"\b\d{8}\b");
                    string t = string.Empty;
                    foreach (BugsBox.Pharmacy.Models.PurchaseUnit pu in puHandler)
                    {                        
                        DateTime BaseDt = DateTime.Parse("1990/01/01");
                        DateTime dt;
                            
                        System.Text.RegularExpressions.MatchCollection mc = rg.Matches(pu.AttorneyAattorneyDetail);
                        foreach (System.Text.RegularExpressions.Match m in mc)
                        {                               
                            if (DateTime.TryParseExact(m.Value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                BaseDt = dt > BaseDt ? dt : BaseDt;
                            }
                        }
                        if(!pu.Valid)
                            Console.WriteLine(BaseDt.ToLongDateString()+":"+pu.Name+pu.Valid.ToString());
                        if (pu.OutDate > BaseDt)
                        {
                            pu.OutDate = BaseDt;
                        }                            
                        pu.Valid = false;
                        businessHandlerFactory.PurchaseUnitBusinessHandler.Save(pu);
                    }
                    
                    businessHandlerFactory.PurchaseUnitBusinessHandler.Save();                
            }
            catch(Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int NotValid()
        {
            try
            {
                PurchaseUnitBusinessHandler puHandler = businessHandlerFactory.PurchaseUnitBusinessHandler;

                return puHandler.Count(p => !p.Valid && p.Enabled);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return -1;
            }
        }

        public int LockCount()
        {
            PurchaseUnitBusinessHandler handler = businessHandlerFactory.PurchaseUnitBusinessHandler;
            return handler.GetLockPurchaseUnitCount();
        }
    }
}
