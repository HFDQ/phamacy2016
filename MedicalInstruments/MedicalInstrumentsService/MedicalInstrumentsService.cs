using MedicalInstruments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstrumentsService
{
    public partial class MedicalInstrumentsService : ServiceBase
    {
        public MedicalInstrumentsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceProvider.Instance.Start();
        }

        protected override void OnStop()
        {
            ServiceProvider.Instance.Stop();
        }
    }
}
