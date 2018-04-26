using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class IndustoryProductCertificateBusinessHandler
    {
        private bool SaveIndustoryproducCertification(IndustoryProductCertificate entity)
        {
            this.Save(entity);
            this.Save();
            return true;
        }

        private IndustoryProductCertificate GetIndustoryProductCertificationById(Guid Id)
        {
            return this.Queryable.FirstOrDefault(r => r.Id == Id);
        }

        public bool AddIndustoryProductCertification(IndustoryProductCertificate entity)
        {
            this.Add(entity);
            return true;
        }
    }
}
