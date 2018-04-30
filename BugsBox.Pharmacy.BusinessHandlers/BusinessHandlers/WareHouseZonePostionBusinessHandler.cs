using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Config;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    public partial class WarehouseZonePositionBusinessHandler
    {
        object locker = new object();

        /// <summary>
        /// 新增库位
        /// </summary>
        /// <param name="ListWareHouseZonePositions"></param>
        /// <returns></returns>
        public bool AddWareHouseZonePositions(IEnumerable<WarehouseZonePosition> ListWareHouseZonePositions)
        {
            lock (locker)
            {
                try
                {
                    foreach (var r in ListWareHouseZonePositions)
                    {
                        r.CreateTime = DateTime.Now;
                        r.UpdateTime = DateTime.Now;
                        RepositoryProvider.Db.WarehouseZonePositions.Add(r);
                    }
                    this.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// 保存库位信息
        /// </summary>
        /// <param name="ListWareHouseZonePositions"></param>
        /// <returns></returns>
        public bool SaveWareHouseZonePosition(IEnumerable<WarehouseZonePosition> ListWareHouseZonePositions)
        {
            lock (locker)
            {
                try
                {
                    foreach (var r in ListWareHouseZonePositions)
                    {
                        r.UpdateTime = DateTime.Now;
                        BusinessHandlerFactory.WarehouseZonePositionBusinessHandler.Save(r);
                    }
                    this.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// 删除库位信息
        /// </summary>
        /// <param name="ListWareHouseZonePositions"></param>
        /// <returns></returns>
        public bool DeleteWareHouseZonePostion(System.Collections.Generic.IEnumerable<Guid> Ids)
        {
            lock (locker)
            {
                try
                {

                    foreach (var r in Ids)
                    {
                        var d = RepositoryProvider.Db.WarehouseZonePositions.FirstOrDefault(u => u.Id == r);
                        d.UpdateTime = DateTime.Now;
                        d.Deleted = true;
                        BusinessHandlerFactory.WarehouseZonePositionBusinessHandler.Save(d);
                    }
                    this.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// 综合查询方法
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<Business.Models.WareHouseZonePositionModel> GetWareHouseZonePositionById(Business.Models.WareHouseZonePositionQueryModel q)
        {
            var all = RepositoryProvider.Db.WarehouseZonePositions.Where(r => !r.Deleted);
            if (q.Id != Guid.Empty)
            {
                all = all.Where(r => r.Id == q.Id);
            }

            if (!string.IsNullOrEmpty(q.Keyword))
            {
                all = all.Where(r => r.Name.Contains(q.Keyword) || r.Memo.Contains(q.Keyword));
            }

            var wz = RepositoryProvider.Db.WarehouseZones.Where(r => r.Deleted == false);
            if (q.WareHouseZoneId != Guid.Empty)
            {
                wz = wz.Where(r => r.Id == q.WareHouseZoneId);
            }
            if (!string.IsNullOrEmpty(q.whzKeyword))
            {
                wz = wz.Where(r => r.Name.Contains(q.whzKeyword));
            }

            var w = RepositoryProvider.Db.Warehouses.Where(r => !r.Deleted);
            if (q.WareHouseId != Guid.Empty)
            {
                w = w.Where(r => r.Id == q.WareHouseId);
            }
            if (!string.IsNullOrEmpty(q.whKeyword))
            {
                w = w.Where(r => r.Name.Contains(q.whKeyword));
            }

            var re = from i in all
                     join j in wz
                     on i.WareHouseZoneId equals j.Id
                     join k in w on j.WarehouseId
                     equals k.Id
                     select new WareHouseZonePositionModel
                     {
                         Capacity = i.Capacity,
                         Id = i.Id,
                         Memo = i.Memo,
                         Name = i.Name,
                         PIndex = i.PIndex,
                         RowCol = i.RowCol,
                         WareHouseName = k.Name,
                         WareHouseId = k.Id,
                         WareHouseZoneId = j.Id,
                         WareHouseZoneName = j.Name,
                         WareHouseZonePIndex = j.PIndex
                     };
            return re.OrderBy(r => r.WareHouseName).ThenBy(r => r.WareHouseZoneName).ThenBy(r => r.PIndex);
        }

        public Models.WarehouseZonePosition GetWarehouseZonePositionById(Guid Id)
        {
            var re = RepositoryProvider.Db.WarehouseZonePositions.Where(r => !r.Deleted && r.Id == Id).FirstOrDefault();
            return re;
        }
    }


}
