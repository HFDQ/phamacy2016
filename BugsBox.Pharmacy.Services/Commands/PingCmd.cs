using BugsBox.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BugsBox.Pharmacy.Services
{
    [DataContract(Namespace = "http://www.dqinfo.net/2017/dqinfo")]
    public class PingCmd : Command
    {
        [DataMember]

        public string IP { get; set; }
        public override object Execute()
        {
            //return new Item { Name = "a" };
            return "1";
            //return new Book { Items = new List<Item> { new Item { Name = "s" } } };
            //return new Bookshelf {  Books= new List<Book> { new Book { Items = new List<Item> { new Item { Name = "s" } } } } };
            //return new Item[] { new Item { Name = "d" } };

            //return new List<Book> { new Book { Items = new List<Item> { new Item { Name = "s" } } } };
        }
    }
}
