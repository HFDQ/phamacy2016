using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class SetSpeicalDrugRecordBusinessHandler
    {
        public void CreateSetSpeicalDrugRecords(SetSpeicalDrugRecord item)
        {
            try
            {
                base.Add(item);
            }
            catch (Exception ex)
            {
                this.HandleException("方法CreateSetSpeicalDrugRecords出错！！！", ex);
            }
        }

        public List<SetSpeicalDrugRecord> GetSetSpeicalDrugRecords()
        {
            try
            {
                List<SetSpeicalDrugRecord> item = this.Queryable.ToList();
                return item;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<SetSpeicalDrugRecord>>("方法GetSetSpeicalDrugRecords出错！！！", ex); 
            }
        }
    }
}
