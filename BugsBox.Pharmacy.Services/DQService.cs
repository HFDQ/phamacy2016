using BugsBox.Application.Core;
using BugsBox.Pharmacy.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Services
{
    public class DQService : IDQService
    {
        public object Excute(Command cmd)
        {
            return cmd.Execute();
        }

        public bool Ping()
        {
            return true;
        }
    }
}
