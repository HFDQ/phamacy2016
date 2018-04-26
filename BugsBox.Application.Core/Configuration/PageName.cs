using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BugsBox.Application.Core.Configuration
{
    public class ReturnOrderPageName
    {
        public string qualityTabPage { get; set; }
        public string generalMangerTabPage { get; set; }
        public string tabPage1 { get; set; }

        public string Field1 { get; set; }

        public string Field2 { get; set; }

        public string Field3 { get; set; }

        public void Init(XmlNode section)
        {
            var installationNode = section.SelectSingleNode("ReturnOrderPageName");
            if (installationNode != null)
            {
                qualityTabPage = DQConfig.GetString(installationNode, "qualityTabPage");
                generalMangerTabPage = DQConfig.GetString(installationNode, "generalMangerTabPage");
                tabPage1 = DQConfig.GetString(installationNode, "tabPage1");
                Field1 = DQConfig.GetString(installationNode, "field1");
                Field2 = DQConfig.GetString(installationNode, "field2");
                Field3 = DQConfig.GetString(installationNode, "field3");


            }
        }


    }
}
