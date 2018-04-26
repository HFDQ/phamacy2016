using MedicalInstruments.Infrastructure;
using MedicalInstruments.Infrastructure.Entity;
using MedicalInstruments.Infrastructure.Repository;
using MedicalInstruments.Infrastructure.Security;
using MedicalInstruments.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedicalInstruments.Controller
{
    public class DeviceController : ApiController
    {
        IDbContext db = new DB();

        [HttpGet]
        public string Test()
        {
            return "hi i'm from server";
        }


        /// <summary>
        /// 软件启动时调用，并记录启动历史
        /// </summary>
        /// <param name="launchInfo"></param>
        [HttpPost]
        public void Launch(LaunchInfo launchInfo)
        {
            var device = db.Set<Device>().FirstOrDefault(o => o.CPUSerialNumber == launchInfo.CPUSerialNumber);
            if (device == null)
            {
                device = new Device
                {
                    ComputerName = launchInfo.ComputerName,
                    CPUSerialNumber = launchInfo.CPUSerialNumber,
                    MACAddress = launchInfo.MACAddress,
                    ExpirationDate = DateTime.Now.AddDays(30).Date,
                    Name = launchInfo.Name,
                    CreateOn = DateTime.Now,
                    ProductKey = launchInfo.ProductKey,
                    SystemType = launchInfo.SystemType,
                    UpdateOn = DateTime.Now
                };
                db.Set<Device>().Add(device);
            }
            else
            {
                device.Name = launchInfo.Name;
                device.UpdateOn = DateTime.Now;
            }

            var launchHis = new LaunchHis { DevieID = device.ID, StartOn = DateTime.Now };
            db.Set<LaunchHis>().Add(launchHis);
            db.SaveChanges();

        }

        /// <summary>
        /// 验证客户端Product Key的有效性，有效则返回过期时间，否则不返回
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public VerifyKeyReponse VerifyProductKey(VerifyKeyRequest request)
        {
            var device = db.Set<Device>().FirstOrDefault(o => o.CPUSerialNumber == request.CPUSerialNumber && o.ProductKey == request.ProductKey);
            var responseInfo = new VerifyKeyReponse();
            if (device != null)
            {
                responseInfo.ExpirationDate = device.ExpirationDate;
            }

            return responseInfo;
        }
    }
}
