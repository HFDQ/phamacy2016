using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace BugsBox.Pharmacy.IServices
{
    [ServiceContract(Namespace = "http://www.bugsbox.bugsbox/PharmacyDatabaseServcie", SessionMode = SessionMode.Allowed
        )]
    public partial interface IPharmacyDatabaseService
    {
        [OperationContract]
        void ReportHeart();
    }
}
  
