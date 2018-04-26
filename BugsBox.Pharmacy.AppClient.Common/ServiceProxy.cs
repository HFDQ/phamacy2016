
using BugsBox.Application.Core;
using BugsBox.Pharmacy.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BugsBox.Pharmacy.AppClient.Common
{
    public class ServiceProxy
    {
        private ChannelFactory<IDQService> _channelFactory;

        public ServiceProxy()
        {
            _channelFactory = new ChannelFactory<IDQService>("DQService");
        }

        public object Excute(Command cmd)
        {
            var server = _channelFactory.CreateChannel();

            return server.Excute(cmd);
        }

        public ChannelFactory<IDQService> ChannelFactory
        {
            get
            {
                return _channelFactory;
            }
        }
    }
}
