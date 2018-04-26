using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstruments.Infrastructure.Entity
{
    public class LaunchHis : BaseEntity
    {

        /// <summary>
        /// 设备ID
        /// </summary>
        public int DevieID { get; set; }
        /// <summary>
        /// 启动时间
        /// </summary>

        public DateTime StartOn { get; set; }


        [ForeignKey("DevieID")]
        public virtual Device Device { get; set; }
    }
}
