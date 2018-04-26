using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BugsBox.Application.Core.Configuration
{
    public class Report
    {

        public bool DisplayKeeper { get; private set; }

        public bool DisplayChecker { get; private set; }

        public void Init(XmlNode section)
        {
            var installationNode = section.SelectSingleNode("Report");
            DisplayKeeper = DQConfig.GetBool(installationNode, "DisplayKeeper");
            DisplayChecker = DQConfig.GetBool(installationNode, "DisplayChecker");

        }
    }
}
