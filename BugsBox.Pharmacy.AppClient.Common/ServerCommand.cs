
using BugsBox.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BugsBox.Pharmacy.AppClient.Common
{
    [DataContract(Namespace = "http://www.dqinfo.net/2017/dqinfo")]
    public class ServerCommand : Command
    {
        public override object Execute()
        {
            return new ServiceProxy().Excute(this);
        }
    }
}
