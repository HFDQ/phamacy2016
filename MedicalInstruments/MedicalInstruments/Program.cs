
using MedicalInstruments.Infrastructure;
using MedicalInstruments.Infrastructure.Log;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstruments.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider.Instance.Start();
        }
    }
}
