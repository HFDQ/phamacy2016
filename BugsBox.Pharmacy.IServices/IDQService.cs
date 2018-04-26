using BugsBox.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace BugsBox.Pharmacy.IServices
{
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypeHelper))]
    [ServiceContract]
    public interface IDQService
    {
        [OperationContract]
        bool Ping();

        [OperationContract]
        object Excute(Command cmd);
    }
}
