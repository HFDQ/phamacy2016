using MedicalInstruments.Infrastructure.Log;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstruments
{
    public class ServiceProvider
    {
        public static ServiceProvider Instance = new ServiceProvider();

        private ServiceProvider()
        {

        }

        IDisposable service;
        public void Start()
        {
            string serverUri = System.Configuration.ConfigurationManager.AppSettings["serveruri"];
            try
            {
                Logger.Info("Server Starting:" + serverUri);
                service = WebApp.Start(serverUri);
                Logger.Info("Server Started :" + serverUri);
                Console.ReadKey();
            }
            catch (TargetInvocationException)
            {
                Logger.Error("A server is already running at " + serverUri);
                return;
            }
            catch (Exception ex)
            {
                Logger.Error("Error Happen When Server Starting" + ex.Message);

                Logger.Error("Exception Info:" + ex.ToString());
            }
        }

        public void Stop()
        {
            service.Dispose();
        }

    }
}
