using BugsBox.Application.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.AppClient
{
    public class BugsBoxApplication
    {
        private static BugsBoxApplication instance = new BugsBoxApplication();

        public void Init()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            string xmlFile = AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml";
            doc.Load(xmlFile);
            System.Xml.XmlNodeList NodeList = doc.SelectNodes("/SalePriceType/SaleOutInventoryChecker");
            FirstChecker = NodeList[0].Attributes[0].Value.ToString();
            SecondChecker = NodeList[0].Attributes[1].Value.ToString();
            InventoryKeeper = NodeList[0].Attributes[2].Value.ToString();
            Config = ConfigurationManager.GetSection("DQConfig") as DQConfig;
        }

        public static BugsBoxApplication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BugsBoxApplication();
                }
                return instance;
            }
        }

        public string FirstChecker { get; private set; }
        public string SecondChecker { get; private set; }
        public string InventoryKeeper { get; private set; }

        public DQConfig Config { get; private set; }

    }
}
