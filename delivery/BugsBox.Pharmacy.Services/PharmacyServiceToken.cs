using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BugsBox.Pharmacy
{
    internal sealed class PharmacyServiceToken
    {
        public string Name { get;private set; }
        public string Pwd { get; private set; }

        private PharmacyServiceToken()
        {
            Name = "asdf;asdf;asdfasdf";
            Pwd = ".lasdlsadflsadfdfs"; 

        }


        public static readonly PharmacyServiceToken Token = new PharmacyServiceToken();

    }
}
