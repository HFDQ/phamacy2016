using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Application.Core.Repository;
using BugsBox.Common;
using BugsBox.Common.Config;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;
using BugsBox.Pharmacy.Config;
using System.Reflection;
using BugsBox.Common.Security;


namespace BugsBox.Pharmacy.Repository
{
    /// <summary>
    /// 默认数据库初始化器
    /// ef创建数据库时自动调用
    /// 主要功能是给某些表添加数据了。
    /// </summary>
    internal class DefaultDbInitializer : DropCreateDatabaseIfModelChanges<Db>
    {
        private static DateTime Now = DateTime.Now;
        private static Guid StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
        private ILogger Log = LoggerHelper.Instance;
        protected override void Seed(Db context)
        {
            try
            {
                Log.Information("BEGIN INIT DATABASE");
                base.Seed(context);
                //初始化功能与分类
                BuildModuleCatetoriesAndModules(context);//系统完成后必须完善 Add By Shen 2013.08.22 0829
                #region 字典数据 
                BuildDictionaryDosages(context);
                BuildDictionaryStorageTypes(context);
                BuildUnitTypes(context);
                BuildPaymentMethods(context);
                BuildPackagingMaterials(context);
                BuildPackagingUnits(context);
                BuildManufacturers(context);
                BuildDrugClinicalCategorys(context);
                BuildSpecialDrugCategories(context);
                BuildPurchaseManageCategorys(context);
                BuildBusinessTypes(context);
                BuildBusinessScopeCategorys(context);
                //BuildMedicalCategorys(context);
                BuildDictionaryUserDefinedTypes(context);
                BuildPaymentMethod(context);
                BuildMedicalCategoryDetails(context);
                #endregion
                BuildDictionarySpecifications(context); //只供测试使用
                BuildDrugApprovalNumbers(context);//只供测试使用 
                BuildVehicles(context);//只供测试使用
                BuildTaxRates(context);//只供测试使用 
                BuildStore(context);
                BuildUserLogs(context);
                BuildDepartments(context);
                BuildEmployees(context);
                BuildRoles(context);
                BuildUsers(context);
                BuildDrupDictionary(context);
                BuildWarehouses(context);
                BuildApprovalFlowType(context);

                BuildDrugInfo(context);
                //BuildInventoryRecord(context);
                BuildDistrict(context);
                //BuildPurchaseunit(context);


                BuildSupplyUnit(context);
                //BuildPurchaseOrder(context);
                //BuildDrugInventoryRecord(context);
                //BuildDrugMaintainRecord(context);

                AppConfig.Config.InitDateTime = Now;
                AppConfig.Config.AutoCreateAndInitDatabase = false;
                ConfigHelper<AppConfig>.SaveConfig();

            }
            catch (Exception ex)
            {
                ex = new Exception("初始化默认数据失败！", ex);
                Log.Error(ex);
            }

        }

        private void BuildMedicalCategoryDetails(Db context)
        {
            EnityImporter<MedicalCategory> importer = new EnityImporter<MedicalCategory>(new MedicalCategoryRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	生物
            //02	化学
            //03	中成药

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("01", "生物");
            dictionary.Add("02", "化学");
            dictionary.Add("03", "中成药");
            foreach (var keyValuePair in dictionary)
            {
                context.MedicalCategorys.Add(new MedicalCategory
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            //医疗分类详细
            List<MedicalCategoryDetail> details = new List<MedicalCategoryDetail>();

            details.Add(new MedicalCategoryDetail
            {
                Code = "-1",
                Name = "无",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });

            string pCode = string.Empty;
            pCode = "01";

            //01	01	空
            details.Add(new MedicalCategoryDetail
            {
                Code = "01",
                Name = "空",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //02	01	疫苗
            details.Add(new MedicalCategoryDetail
            {
                Code = "02",
                Name = "疫苗",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //03	01	血液制品
            details.Add(new MedicalCategoryDetail
            {
                Code = "03",
                Name = "血液制品",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //04	01	诊断药品
            details.Add(new MedicalCategoryDetail
            {
                Code = "04",
                Name = "诊断药品",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //05	01	蛋白同化制剂
            details.Add(new MedicalCategoryDetail
            {
                Code = "05",
                Name = "蛋白同化制剂",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //06	01	肽类激素
            details.Add(new MedicalCategoryDetail
            {
                Code = "06",
                Name = "肽类激素",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //07	01	其他
            details.Add(new MedicalCategoryDetail
            {
                Code = "07",
                Name = "其他",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            pCode = "02";
            details.Add(new MedicalCategoryDetail
            {
                Code = "01",
                Name = "空",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //08	02	抗生素类抗感染药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "08",
                Name = "抗生素类抗感染药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //09	02	非抗生素类抗感染药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "09",
                Name = "非抗生素类抗感染药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //10	02	抗寄生虫病药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "10",
                Name = "抗寄生虫病药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //11	02	解热镇痛药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "11",
                Name = "解热镇痛药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //12	02	麻醉用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "12",
                Name = "麻醉用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //13	02	维生素类与矿物质类药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "13",
                Name = "维生素类与矿物质类药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //14	02	营养治疗药物（酶类及其它生化药物）
            details.Add(new MedicalCategoryDetail
            {
                Code = "14",
                Name = "营养治疗药物（酶类及其它生化药物）",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //15	02	激素及调节内分泌功能类药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "15",
                Name = "激素及调节内分泌功能类药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //16	02	调节免疫功能药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "16",
                Name = "调节免疫功能药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //17	02	抗肿瘤药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "17",
                Name = "抗肿瘤药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //18	02	抗变态反应药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "18",
                Name = "抗变态反应药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //19	02	神经系统用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "19",
                Name = "神经系统用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //20	02	呼吸系统用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "20",
                Name = "呼吸系统用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //21	02	消化系统用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "21",
                Name = "消化系统用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //22	02	循环系统用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "22",
                Name = "循环系统用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //23	02	泌尿系统用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "23",
                Name = "泌尿系统用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //24	02	血液系统用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "24",
                Name = "血液系统用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //25	02	水、电解质及酸碱平衡调节药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "25",
                Name = "水、电解质及酸碱平衡调节药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //26	02	专科用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "26",
                Name = "专科用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //27	02	诊断用药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "27",
                Name = "诊断用药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //28	02	制剂辅料
            details.Add(new MedicalCategoryDetail
            {
                Code = "28",
                Name = "制剂辅料",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //29	02	保健品
            details.Add(new MedicalCategoryDetail
            {
                Code = "29",
                Name = "保健品",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //30	02	其它化学药物
            details.Add(new MedicalCategoryDetail
            {
                Code = "30",
                Name = "其它化学药物",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //31	02	原料药
            details.Add(new MedicalCategoryDetail
            {
                Code = "31",
                Name = "原料药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //32	02	蛋白同化制剂
            details.Add(new MedicalCategoryDetail
            {
                Code = "32",
                Name = "蛋白同化制剂",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //33	02	肽类激素
            details.Add(new MedicalCategoryDetail
            {
                Code = "33",
                Name = "肽类激素",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            pCode = "03";
            //34	03	祛痰药
            details.Add(new MedicalCategoryDetail
            {
                Code = "34",
                Name = "祛痰药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //35	03	解表药
            details.Add(new MedicalCategoryDetail
            {
                Code = "35",
                Name = "解表药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //36	03	和解药
            details.Add(new MedicalCategoryDetail
            {
                Code = "36",
                Name = "和解药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //37	03	温里药
            details.Add(new MedicalCategoryDetail
            {
                Code = "37",
                Name = "温里药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //38	03	补益药
            details.Add(new MedicalCategoryDetail
            {
                Code = "38",
                Name = "补益药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //39	03	开窍药
            details.Add(new MedicalCategoryDetail
            {
                Code = "39",
                Name = "开窍药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //40	03	理血药
            details.Add(new MedicalCategoryDetail
            {
                Code = "40",
                Name = "理血药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //41	03	消食药
            details.Add(new MedicalCategoryDetail
            {
                Code = "41",
                Name = "消食药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //42	03	驱虫药
            details.Add(new MedicalCategoryDetail
            {
                Code = "42",
                Name = "驱虫药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //43	03	疏风药
            details.Add(new MedicalCategoryDetail
            {
                Code = "43",
                Name = "疏风药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //44	03	清热药
            details.Add(new MedicalCategoryDetail
            {
                Code = "44",
                Name = "清热药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //45	03	治燥药
            details.Add(new MedicalCategoryDetail
            {
                Code = "45",
                Name = "治燥药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //46	03	五官用药
            details.Add(new MedicalCategoryDetail
            {
                Code = "46",
                Name = "五官用药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //47	03	其它
            details.Add(new MedicalCategoryDetail
            {
                Code = "47",
                Name = "其它",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //48	03	固涩药
            details.Add(new MedicalCategoryDetail
            {
                Code = "48",
                Name = "固涩药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //49	03	理气药
            details.Add(new MedicalCategoryDetail
            {
                Code = "49",
                Name = "理气药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //50	03	祛湿药
            details.Add(new MedicalCategoryDetail
            {
                Code = "50",
                Name = "祛湿药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //51	03	妇科用药
            details.Add(new MedicalCategoryDetail
            {
                Code = "51",
                Name = "妇科用药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //52	03	涌吐药
            details.Add(new MedicalCategoryDetail
            {
                Code = "52",
                Name = "涌吐药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //53	03	泻下药
            details.Add(new MedicalCategoryDetail
            {
                Code = "53",
                Name = "泻下药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //54	03	安神药
            details.Add(new MedicalCategoryDetail
            {
                Code = "54",
                Name = "安神药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //55	03	外用药
            details.Add(new MedicalCategoryDetail
            {
                Code = "55",
                Name = "外用药",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });
            //56	03	保健品
            details.Add(new MedicalCategoryDetail
            {
                Code = "56",
                Name = "保健品",
                MedicalCategoryId = context.MedicalCategorys.FirstOrDefault(c => c.Code == pCode).Id,
                Deleted = false,
                Enabled = true
            });




            foreach (var medicalCategoryDetail in details)
            {
                context.MedicalCategoryDetails.Add(medicalCategoryDetail);
            }
            context.Commit();
            importer.Backup();
        }

        private void BuildTaxRates(Db context)
        {
            for (int i = 1; i < 10; i++)
            {
                context.TaxRates.Add(new TaxRate
                {
                    Name = string.Format("9{0}%", i)
                   ,
                    Code = string.Format("9{0}%", i)
                   ,
                    Enabled = true
                });
            }
            context.Commit();
        }

        private void BuildVehicles(Db context)
        {
            for (int i = 0; i < 10; i++)
            {
                context.Vehicles.Add(new Vehicle
                {
                    Cubage = "1000"
                    ,
                    Driver = "司机" + (char)(i + 'A')
                    ,
                    Id = Guid.NewGuid()
                    ,
                    LicensePlate = "苏B." + i.ToString().PadLeft(5, '0')
                    ,
                    Other = "暂无"
                    ,
                    Rule = "ABCD"
                    ,
                    Status = true
                    ,
                    Type = "大小中车"
                });
            }
            context.Commit();
        }

        private void BuildDrugApprovalNumbers(Db context)
        {
            List<string> specifications = new List<string>();
            for (int i = 0; i < 26; i++)
            {
                specifications.Add(string.Format("国药准字号{0}", (char)(i + 'A')));
                //国食健字G
                specifications.Add(string.Format("国食健字{0}", (char)(i + 'A')));
                specifications.Add(string.Format("国药管械（进）{0}", (char)(i + 'A')));
            }
            foreach (var spec in specifications)
            {
                context.DrugApprovalNumbers.Add(new DrugApprovalNumber { Name = spec, Enabled = true });
            }
            context.Commit(); ;
        }

        private void BuildDictionaryUserDefinedTypes(Db context)
        {
            DictionaryUserDefinedType type = new DictionaryUserDefinedType();
            type.Code = "-1";
            type.Decription = "无";
            type.Enabled = true;
            type.Name = "无";
            type.Id = Guid.NewGuid();
            context.DictionaryUserDefinedTypes.Add(type);
            context.Commit();
        }
        private void BuildBusinessScopeCategorys(Db context)
        {
            EnityImporter<BusinessScopeCategory> importer = new EnityImporter<BusinessScopeCategory>(new BusinessScopeCategoryRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	药品
            //02	医疗器械
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("01", "药品");
            dictionary.Add("02", "医疗器械");
            foreach (var keyValuePair in dictionary)
            {
                context.BusinessScopeCategorys.Add(new BusinessScopeCategory
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            //经营范围
            List<BusinessScope> details = new List<BusinessScope>();
            //01	01	医疗用毒性药品
            //02	01	麻醉药品
            //03	01	一类精神药品
            //04	01	二类精神药品
            //05	01	放射性药品
            //06	01	中药材
            //07	01	中药饮片
            //08	01	中成药
            //09	01	化学原料药
            //10	01	化学药制剂
            //11	01	抗生素
            //12	01	生化药品
            //13	01	生物制品
            //14	01	生物制品（限诊断药品）
            //15	01	疫苗
            //16	01	生物制品（除疫苗）
            //17	01	生物制品（除血液药品）
            //18	01	蛋白同化制剂
            //19	01	肽类激素
            //20	01	体外诊断试剂
            //21	02	销字号
            //22	02	I类
            //23	02	II类
            //24	02	III类 
            //非药品
            //保健食品
            //化学药
            details.Add(new BusinessScope
            {
                Code = "-1",
                Name = "无",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "01",
                Name = "医疗用毒性药品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "02",
                Name = "麻醉药品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "03",
                Name = "一类精神药品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "04",
                Name = "二类精神药品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "05",
                Name = "放射性药品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "06",
                Name = "中药材",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "07",
                Name = "中药饮片",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "08",
                Name = "中成药",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "09",
                Name = "化学原料药",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "10",
                Name = "化学药制剂",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "11",
                Name = "抗生素",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "12",
                Name = "生化药品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "13",
                Name = "生物制品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "14",
                Name = "生物制品（限诊断药品）",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "15",
                Name = "疫苗",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "16",
                Name = "生物制品（除疫苗）",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "17",
                Name = "生物制品（除血液药品）",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "18",
                Name = "蛋白同化制剂",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "19",
                Name = "肽类激素",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "20",
                Name = "体外诊断试剂",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "21",
                Name = "销字号",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });

            details.Add(new BusinessScope
            {
                Code = "22",
                Name = "I类",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "23",
                Name = "II类",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "24",
                Name = "III类",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "25",
                Name = "保健食品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "26",
                Name = "非药品",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new BusinessScope
            {
                Code = "27",
                Name = "化学药",
                BusinessScopeCategoryId = context.BusinessScopeCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });

            foreach (var purchaseManageCategoryDetail in details)
            {
                context.BusinessScopes.Add(purchaseManageCategoryDetail);
            }
            context.Commit();
            importer.Backup();
        }

        /// <summary>
        /// 经营方式
        /// </summary>
        /// <param name="context"></param>
        private void BuildBusinessTypes(Db context)
        {
            EnityImporter<BusinessType> importer = new EnityImporter<BusinessType>(new BusinessTypeRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	批发
            //02	批发（非法人）
            //03	零售（经营处方药和非处方药）
            //04	零售（仅经营乙类非处方药）
            //05	零售（经营非处方药）
            //06	零售连锁（经营处方药和非处方药）
            //07	零售连锁（仅经营乙类非处方药）
            //08	零售连锁（经营非处方药）


            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("01", "批发");
            dictionary.Add("02", "批发（非法人）");
            dictionary.Add("03", "零售（经营处方药和非处方药）");
            dictionary.Add("04", "零售（仅经营乙类非处方药）");
            dictionary.Add("05", "零售（经营非处方药）");
            dictionary.Add("06", "零售连锁（经营处方药和非处方药）");
            dictionary.Add("07", "零售连锁（仅经营乙类非处方药）");
            dictionary.Add("08", "零售连锁（经营非处方药）");

            foreach (var keyValuePair in dictionary)
            {
                context.BusinessTypes.Add(new BusinessType
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();
        }

        private void BuildPurchaseManageCategorys(Db context)
        {
            EnityImporter<PurchaseManageCategory> importer = new EnityImporter<PurchaseManageCategory>(new PurchaseManageCategoryRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	处方药
            //02	非处方药



            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("01", "处方药");
            dictionary.Add("02", "非处方药");
            foreach (var keyValuePair in dictionary)
            {
                context.PurchaseManageCategorys.Add(new PurchaseManageCategory
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            //管理要求分类详细
            List<PurchaseManageCategoryDetail> details = new List<PurchaseManageCategoryDetail>();
            //code	type	name
            //01	01	处方药
            //02	02	甲类非处方药
            //03	02	乙类非处方药
            details.Add(new PurchaseManageCategoryDetail
            {
                Code = "-1",
                Name = "无",
                PurchaseManageCategoryId = context.PurchaseManageCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new PurchaseManageCategoryDetail
            {
                Code = "01",
                Name = "处方药",
                PurchaseManageCategoryId = context.PurchaseManageCategorys.FirstOrDefault(c => c.Code == "01").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new PurchaseManageCategoryDetail
            {
                Code = "02",
                Name = "甲类非处方药",
                PurchaseManageCategoryId = context.PurchaseManageCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });
            details.Add(new PurchaseManageCategoryDetail
            {
                Code = "03",
                Name = "乙类非处方药",
                PurchaseManageCategoryId = context.PurchaseManageCategorys.FirstOrDefault(c => c.Code == "02").Id,
                Deleted = false,
                Enabled = true
            });
            foreach (var purchaseManageCategoryDetail in details)
            {
                context.PurchaseManageCategoryDetails.Add(purchaseManageCategoryDetail);
            }
            context.Commit();
            importer.Backup();
        }

        private void BuildSpecialDrugCategories(Db context)
        {
            EnityImporter<SpecialDrugCategory> importer = new EnityImporter<SpecialDrugCategory>(new SpecialDrugCategoryRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	医疗用毒性药品
            //02	麻醉药品
            //03	一类精神药品
            //04	二类精神药品
            //05	放射性药品
            //06    毒性中药材


            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("-1", "无");
            dictionary.Add("01", "医疗用毒性药品");
            dictionary.Add("02", "麻醉药品");
            dictionary.Add("03", "一类精神药品");
            dictionary.Add("04", "二类精神药品");
            dictionary.Add("05", "放射性药品");
            dictionary.Add("06", "毒性中药材");
            foreach (var keyValuePair in dictionary)
            {
                context.SpecialDrugCategorys.Add(new SpecialDrugCategory
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();
        }

        /// <summary>
        /// 临床分类
        /// </summary>
        /// <param name="context"></param>
        private void BuildDrugClinicalCategorys(Db context)
        {
            EnityImporter<DrugClinicalCategory> importer = new EnityImporter<DrugClinicalCategory>(new DrugClinicalCategoryRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //00	空
            //01	内科
            //02	外科
            //03	妇产科
            //04	儿科
            //05	耳鼻喉科
            //06	眼科
            //07	口腔科
            //08	皮肤性病科
            //09	泌尿科
            //10	骨科
            //11	血液科
            //12	肿瘤科
            //13	医学影像科
            //14	病理科
            //15	检验科
            //16	超声诊断科
            //17	中医科
            //18	急诊科
            //99	其他

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("-1", "无");
            dictionary.Add("00", "空");
            dictionary.Add("01", "内科");
            dictionary.Add("02", "外科");
            dictionary.Add("03", "妇产科");
            dictionary.Add("04", "儿科");
            dictionary.Add("05", "耳鼻喉科");
            dictionary.Add("06", "眼科");
            dictionary.Add("07", "口腔科");
            dictionary.Add("08", "皮肤性病科");
            dictionary.Add("09", "泌尿科");
            dictionary.Add("10", "骨科");
            dictionary.Add("11", "血液科");
            dictionary.Add("12", "肿瘤科");
            dictionary.Add("13", "医学影像科");
            dictionary.Add("14", "病理科");
            dictionary.Add("15", "检验科");
            dictionary.Add("16", "超声诊断科");
            dictionary.Add("17", "中医科");
            dictionary.Add("18", "急诊科");
            dictionary.Add("99", "其他");


            foreach (var keyValuePair in dictionary)
            {
                context.DrugClinicalCategorys.Add(new DrugClinicalCategory
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();
        }

        /// <summary>
        /// 生产产商
        /// </summary>
        /// <param name="context"></param>
        private void BuildManufacturers(Db context)
        {
            EnityImporter<Manufacturer> importer = new EnityImporter<Manufacturer>(new ManufacturerRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
        }

        /// <summary>
        /// 包装单位
        /// </summary>
        /// <param name="context"></param>
        private void BuildPackagingUnits(Db context)
        {
            EnityImporter<PackagingUnit> importer = new EnityImporter<PackagingUnit>(new PackagingUnitRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	大包装
            //02	中包装
            //03	小包装 
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("01", "大包装");
            dictionary.Add("02", "中包装");
            dictionary.Add("03", "小包装");
            foreach (var keyValuePair in dictionary)
            {
                context.PackagingUnits.Add(new PackagingUnit
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();
        }

        /// <summary>
        /// 包装材质
        /// </summary>
        /// <param name="context"></param>
        private void BuildPackagingMaterials(Db context)
        {
            EnityImporter<PackagingMaterial> importer = new EnityImporter<PackagingMaterial>(new PackagingMaterialRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	空
            //02	西林瓶
            //03	安瓿瓶
            //04	塑料瓶
            //05	玻璃瓶
            //06	非PVC膜
            //07	PVC膜
            //08	聚丙烯膜
            //09	一针一水
            //10	配溶媒
            //11	笔芯
            //12	特充
            //13	预充
            //14	含冲洗器
            //15	配溶媒+输液器
            //16	自排液输液瓶
            //17	预灌封注射器
            //18	弹力微孔布
            //19	无纺布
            //20	弹力布
            //21	其他

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("-1", "无");
            dictionary.Add("01", "空");
            dictionary.Add("02", "西林瓶");
            dictionary.Add("03", "安瓿瓶");
            dictionary.Add("04", "塑料瓶");
            dictionary.Add("05", "玻璃瓶");
            dictionary.Add("06", "非PVC膜");
            dictionary.Add("07", "PVC膜");
            dictionary.Add("08", "聚丙烯膜");
            dictionary.Add("09", "一针一水");
            dictionary.Add("10", "配溶媒");
            dictionary.Add("11", "笔芯");
            dictionary.Add("12", "特充");
            dictionary.Add("13", "预充");
            dictionary.Add("14", "含冲洗器");
            dictionary.Add("15", "配溶媒+输液器");
            dictionary.Add("16", "自排液输液瓶");
            dictionary.Add("17", "预灌封注射器");
            dictionary.Add("18", "弹力微孔布");
            dictionary.Add("19", "无纺布");
            dictionary.Add("20", "弹力布");
            dictionary.Add("21", "其他");
            foreach (var keyValuePair in dictionary)
            {
                context.PackagingMaterials.Add(new PackagingMaterial
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();
        }

        /// <summary>
        /// 付款方式
        /// </summary>
        /// <param name="context"></param>
        private void BuildPaymentMethods(Db context)
        {
            EnityImporter<PaymentMethod> importer = new EnityImporter<PaymentMethod>(new PaymentMethodRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	现金
            //02	支票
            //03	转账
            //04	赊帐


            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("01", "现金");
            dictionary.Add("02", "支票");
            dictionary.Add("03", "转账");
            dictionary.Add("04", "赊帐");
            dictionary.Add("05", "在线支付");
            dictionary.Add("06", "银行汇款");
            foreach (var keyValuePair in dictionary)
            {
                context.PaymentMethods.Add(new PaymentMethod
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();
        }

        /// <summary>
        /// 企业类型
        /// </summary>
        /// <param name="context"></param>
        private void BuildUnitTypes(Db context)
        {
            EnityImporter<UnitType> importer = new EnityImporter<UnitType>(new UnitTypeRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //BC	00	经营企业	1
            //HP	10	医疗机构	1
            //MC	20	生产企业	1
            //OC	90	其他企业	1
            //AE	30	卫生防疫机构/疾病预防控制中心	1

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //dictionary.Add("00", "批发企业");
            //dictionary.Add("10", "零售连锁");
            //dictionary.Add("20", "零售");
            dictionary.Add("30", "医疗机构");
            dictionary.Add("40", "计划生育技术服务机构");
            dictionary.Add("50", "其他医疗机构");
            dictionary.Add("55", "经营企业");
            dictionary.Add("60", "生产企业");
            dictionary.Add("70", "卫生防疫机构/疾病预防控制中心");
            dictionary.Add("80", "学校科研机构");
            foreach (var keyValuePair in dictionary)
            {
                context.UnitTypes.Add(new UnitType
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();
        }

        private void BuildDictionarySpecifications(Db context)
        {
            List<string> specifications = new List<string>();
            specifications.Add("无");
            for (int i = 1; i < 50; i++)
            {
                specifications.Add(string.Format("0.0{0}g*36s", i));
                specifications.Add(string.Format("0.0{0}g*100s", i));
                specifications.Add(string.Format("0.{0}*10片", i));
                specifications.Add(string.Format("0.{0}*24片", i));
                specifications.Add(string.Format("0.1{0}g*6片*2板", i));
            }
            for (int i = 0; i < specifications.Count; i++)
            {
                context.DictionarySpecifications.Add(new DictionarySpecification { Name = specifications[i], Code = i.ToString().PadLeft(3, '0') });
            }
            context.Commit(); ;
        }

        private void BuildDictionaryStorageTypes(Db context)
        {
            EnityImporter<DictionaryStorageType> importer = new EnityImporter<DictionaryStorageType>(new DictionaryStorageTypeRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	阴凉,凉暗（密闭,遮光≤20℃）
            //02	常温（干燥0℃－30℃）
            //03	遮光
            //04	凉暗处保存
            //05	冷藏（2℃－10℃）
            //06	其它
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("-1", "无");
            dictionary.Add("01", "阴凉,凉暗（密闭,遮光≤20℃）");
            dictionary.Add("02", "常温（干燥0℃－30℃）");
            dictionary.Add("03", "遮光");
            dictionary.Add("04", "凉暗处保存");
            dictionary.Add("05", "冷藏（2℃－10℃）");
            dictionary.Add("06", "其它");
            foreach (var keyValuePair in dictionary)
            {
                context.DictionaryStorageTypes.Add(new DictionaryStorageType
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();

        }

        private void BuildDictionaryDosages(Db context)
        {
            EnityImporter<DictionaryDosage> importer = new EnityImporter<DictionaryDosage>(new DictionaryDosageRepository(context));
            if (importer.FileExists)
            {
                importer.Import();
                return;
            }
            //01	片剂
            //02	胶囊剂
            //03	口服液体剂
            //04	丸剂
            //05	颗粒剂
            //06	口服散剂
            //07	外用散剂
            //08	软膏剂
            //09	贴剂
            //10	外用液体剂
            //11	硬膏剂
            //12	凝胶剂
            //13	涂剂
            //14	栓剂
            //15	五官滴剂
            //16	吸入剂
            //17	注射液
            //18	粉针剂
            //19	原料药
            //20	内服膏剂
            //21	外用膏剂
            //22	糖浆剂
            //23	滴眼剂
            //24	喷雾剂
            //25	冻粉剂
            //26	洗剂
            //27	注射剂
            //28	合剂
            //29	酊剂
            //30	膜剂
            //99	其他
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("-1", "无");
            dictionary.Add("01", "片剂");
            dictionary.Add("02", "胶囊剂");
            dictionary.Add("03", "口服液体剂");
            dictionary.Add("04", "丸剂");
            dictionary.Add("05", "颗粒剂");
            dictionary.Add("06", "口服散剂");
            dictionary.Add("07", "外用散剂");
            dictionary.Add("08", "软膏剂");
            dictionary.Add("09", "贴剂");
            dictionary.Add("10", "外用液体剂");
            dictionary.Add("11", "硬膏剂");
            dictionary.Add("12", "凝胶剂");
            dictionary.Add("13", "涂剂");
            dictionary.Add("14", "栓剂");
            dictionary.Add("15", "五官滴剂");
            dictionary.Add("16", "吸入剂");
            dictionary.Add("17", "注射液");
            dictionary.Add("18", "粉针剂");
            dictionary.Add("19", "原料药");
            dictionary.Add("20", "内服膏剂");
            dictionary.Add("21", "外用膏剂");
            dictionary.Add("22", "糖浆剂");
            dictionary.Add("23", "滴眼剂");
            dictionary.Add("24", "喷雾剂");
            dictionary.Add("25", "冻粉剂");
            dictionary.Add("26", "洗剂");
            dictionary.Add("27", "注射剂");
            dictionary.Add("28", "合剂");
            dictionary.Add("29", "酊剂");
            dictionary.Add("30", "膜剂");
            dictionary.Add("99", "其他");
            foreach (var keyValuePair in dictionary)
            {
                context.DictionaryDosages.Add(new DictionaryDosage
                {
                    Code = keyValuePair.Key,
                    Name = keyValuePair.Value,
                    Deleted = false,
                    Enabled = true
                });
            }
            context.Commit();
            importer.Backup();

        }

        private void BuildEmployees(Db context)
        {
            var dbset = context.Set<Employee>();
            Employee employee = new Employee();//默认员工不允许删除
            employee.Id = PharmacyServiceConfig.Config.CurrentStore.Id;
            //To Do
            employee.Address = "Address";
            employee.BirthDay = Now.AddYears(-30);
            employee.CardDate = Now.AddYears(+5);
            employee.CardNo = "CardNo";
            employee.CreateTime = Now;
            employee.CreateUserId = sysAdminID;
            employee.DepartmentId = sysDepartmentID;
            employee.Duty = "系统管理员";
            employee.Education = "Education";
            employee.Email = "Email";
            employee.EmployStatus = EmployStatus.Serving;
            employee.Gender = "未知";
            employee.IdentityNo = "IdentityNo";
            employee.Name = "超级管理员";
            employee.Number = "Number";
            employee.Phone = "Phone";
            employee.Pinyin = "Pinyin";
            employee.Rank = "Rank";
            employee.Specility = "Specility";
            employee.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            employee.UpdateTime = Now;
            employee.UpdateUserId = sysAdminID;
            employee.WorkTime = Now;
            employee.Enabled = true;
            employee.OutDate = Now.AddYears(50);
            employee.Pro_work_exam = true;
            employee.Pro_work_exam_Date = Now;
            dbset.Add(employee);
        }

        /// <summary>
        /// 创建系统功能分类与功能
        /// 理论上不允许更改
        /// </summary>
        /// <param name="context"></param>
        private void BuildModuleCatetoriesAndModules(Db context)
        { //处理分类与模块定义
            Dictionary<CategoryWithIndex, List<DescriptionWithIndex>> moduleKeys =
                new Dictionary<CategoryWithIndex, List<DescriptionWithIndex>>();
            Type categoryWithIndexType = typeof(CategoryWithIndex);
            Type descriptionWithIndexType = typeof(DescriptionWithIndex);
            var moduleKeysFields = typeof(ModuleKeys)
                .GetFields()
                .Where(f => f.GetCustomAttributes(categoryWithIndexType, false).Length > 0
                && f.GetCustomAttributes(descriptionWithIndexType, false).Length > 0);

            //To Do 
            CategoryWithIndex categoryWithIndex;
            DescriptionWithIndex descriptionWithIndex;
            foreach (FieldInfo fieldInfo in moduleKeysFields)
            {
                categoryWithIndex = fieldInfo.GetCustomAttributes(categoryWithIndexType, false).FirstOrDefault() as CategoryWithIndex;
                descriptionWithIndex = fieldInfo.GetCustomAttributes(descriptionWithIndexType, false).FirstOrDefault() as DescriptionWithIndex;
                if (categoryWithIndex != null && descriptionWithIndex != null)
                {
                    if (!moduleKeys.ContainsKey(categoryWithIndex))
                    {
                        moduleKeys.Add(categoryWithIndex, new List<DescriptionWithIndex>());
                    }
                    moduleKeys[categoryWithIndex].Add(descriptionWithIndex);
                }
            }


            Guid storeId = PharmacyServiceConfig.Config.CurrentStore.Id;
            DbSet<ModuleCatetory> dbCatetory = context.Set<ModuleCatetory>();
            DbSet<BugsBox.Pharmacy.Models.Module> dbModule = context.Set<BugsBox.Pharmacy.Models.Module>();
            ModuleCatetory moduleCatetory = null;
            BugsBox.Pharmacy.Models.Module module = null;
            foreach (var moduleKey in moduleKeys)
            {
                moduleCatetory = new ModuleCatetory();
                moduleCatetory.Id = Guid.NewGuid();
                moduleCatetory.Name = moduleKey.Key.Category;
                moduleCatetory.Description = string.Format("[{0}]请不要删除", moduleCatetory.Name);
                moduleCatetory.StoreId = storeId;
                moduleCatetory.Index = moduleKey.Key.Index;
                dbCatetory.Add(moduleCatetory);
                foreach (DescriptionWithIndex dscriptionWithIndex in moduleKey.Value)
                {
                    module = new BugsBox.Pharmacy.Models.Module();
                    module.ModuleCatetoryId = moduleCatetory.Id;
                    module.Name = dscriptionWithIndex.Description;
                    module.Description = string.Format("[{0}]请不要删除", module.Name);
                    module.AuthKey = dscriptionWithIndex.Description;
                    module.Index = dscriptionWithIndex.Index;
                    module.StoreId = storeId;
                    dbModule.Add(module);
                }
            }
            context.Commit(); ;

        }



        private void BuildWarehouses(Db context)
        {
            DictionaryStorageType type = context.DictionaryStorageTypes.FirstOrDefault();

            DictionaryMeasurementUnit unit = context.DictionaryMeasurementUnits.FirstOrDefault();

            Warehouse house = new Warehouse();
            house.Code = "JCDefault";
            house.Name = "默认店面";
            house.MnemonicCode = "0001";
            house.Address = "ddddd";
            house.Phone = "88888888";
            house.Decription = "默认店面";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = PharmacyServiceConfig.Config.CurrentStore.Id;
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCYLCK00001";
            house.Name = "阴凉库";
            house.MnemonicCode = "YLCK";
            house.Address = "---";
            house.Phone = "88889999";
            house.Decription = "阴凉库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCCWCK00001";
            house.Name = "常温库";
            house.MnemonicCode = "CWCK00001";
            house.Address = "---";
            house.Phone = "88889999";
            house.Decription = "常温库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCLCCK00001";
            house.Name = "冷藏库";
            house.MnemonicCode = "LCCK00001";
            house.Address = "---";
            house.Phone = "88889999";
            house.Decription = "---冷藏库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCZYCK00001";
            house.Name = "中药库";
            house.MnemonicCode = "ZYCK00001";
            house.Address = "---";
            house.Phone = "88889999";
            house.Decription = "---中药库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCZYYPCK00001";
            house.Name = "中药饮片库";
            house.MnemonicCode = "ZYYPCK00001";
            house.Address = "---";
            house.Phone = "88889999";
            house.Decription = "---中药饮片库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCWXPCK00001";
            house.Name = "危险品库";
            house.MnemonicCode = "WXPCK00001";
            house.Address = "---";
            house.Phone = "88889999";
            house.Decription = "---危险品库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "DCLCK000001";
            house.Name = "待处理区";
            house.MnemonicCode = "dclq";
            house.Address = "---";
            house.Phone = "8999999";
            house.Decription = "---待处理仓库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "BHGCK000001";
            house.Name = "不合格区";
            house.MnemonicCode = "bhgq";
            house.Address = "---";
            house.Phone = "8999999";
            house.Decription = "不合格仓库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "SHQ000001";
            house.Name = "收货区";
            house.MnemonicCode = "shq";
            house.Address = "---";
            house.Phone = "852365452";
            house.Decription = "收货区";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "THQ000001";
            house.Name = "退货区";
            house.MnemonicCode = "shq";
            house.Address = "---";
            house.Phone = "852365452";
            house.Decription = "退货区";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "DYQ000001";
            house.Name = "待验区";
            house.MnemonicCode = "dyq";
            house.Address = "---";
            house.Phone = "852365452";
            house.Decription = "待验区";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCYLQX000001";
            house.Name = "医疗器械库";
            house.MnemonicCode = "YLQX";
            house.Address = "---";
            house.Phone = "99999999";
            house.Decription = "医疗器械库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCBJSPK000001";
            house.Name = "保健食品库";
            house.MnemonicCode = "BJSP";
            house.Address = "---";
            house.Phone = "99999999";
            house.Decription = "保健食品库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            house = new Warehouse();
            house.Code = "JCYLDX000001";
            house.Name = "医疗用毒性药材库";
            house.MnemonicCode = "YLDX";
            house.Address = "---";
            house.Phone = "99999999";
            house.Decription = "医疗用毒性药材库";
            house.CreateTime = DateTime.Now;
            house.UpdateTime = DateTime.Now;
            house.Id = Guid.NewGuid();
            house.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            context.Set<Warehouse>().Add(house);

            for (int i = 0; i < 10; i++)
            {
                WarehouseZone zone = new WarehouseZone();
                zone.Id = Guid.NewGuid();
                zone.Name = "货架" + i.ToString();
                zone.Code = "HJ" + i.ToString();
                zone.Decription = "HJ" + i.ToString();
                zone.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                zone.WarehouseId = house.Id;
                zone.WarehouseZoneType = WarehouseZoneType.Counter;
                zone.MnemonicCode = "0001";
                zone.CreateTime = DateTime.Now;
                zone.UpdateTime = DateTime.Now;
                zone.DictionaryStorageTypeId = type.Id;
                zone.DictionaryMeasurementUnitId = unit.Id;
                context.Set<WarehouseZone>().Add(zone);
            }
            context.Commit();
        }

        private void BuildUsers(Db context)
        {
            User user = new User
            {
                Account = "Administrator",
                CreateTime = Now,
                CreateUserId = sysAdminID,
                Pwd = EncodeHelper.Base64Encode("Administrator!@#$%"),
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = sysAdminID,
                EmployeeId = PharmacyServiceConfig.Config.CurrentStore.Id,
                Enabled = true
            };
            RoleWithUser roleWithUser = new RoleWithUser
            {
                CreateTime = Now,
                CreateUserId = user.Id,
                Id = user.Id,
                RoleId = sysRoleID,
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now,
                UpdateUserId = user.Id,
                UserId = user.Id,


            };
            context.Set<User>().Add(user);
            context.Set<RoleWithUser>().Add(roleWithUser);
            context.Commit();
        }

        private void BuildDrupDictionary(Db context)
        {
            string[] dw = { "无", "盒", "瓶", "包", "袋", "副", "个", "公升", "罐", "罐桶", "把", "克", "米", "片", "板", "千克", "台", "条", "桶", "张", "支", "只" };//计量单位
            string[] type = { "无", "化妆品", "日化用品", "生物制品", "食品", "消字号", "药品", "医疗器械", "中药", "其它" }; //药物分类
            string[] cldw = { "无", "片", "粒", "板", "袋", "支", "卷", "瓶" };//拆零单位
            for (int i = 0; i < dw.Length; i++)
            {
                context.Set<DictionaryMeasurementUnit>().Add(new DictionaryMeasurementUnit { Code = i.ToString().PadLeft(2, '0'), Id = Guid.NewGuid(), Name = dw[i], Enabled = true, Deleted = false });
            }
            context.Commit(); ;

            for (int i = 0; i < type.Length; i++)
            {
                context.Set<DrugCategory>().Add(new DrugCategory { Code = i.ToString().PadLeft(2, '0'), Id = Guid.NewGuid(), Name = type[i], Enabled = true, Deleted = false });
            }
            context.Commit();
            for (int i = 0; i < cldw.Length; i++)
            {
                context.Set<DictionaryPiecemealUnit>().Add(new DictionaryPiecemealUnit { Code = i.ToString().PadLeft(2, '0'), Id = Guid.NewGuid(), Name = cldw[i], Enabled = true, Deleted = false });
            }
            context.Commit();

        }
        private void BuildRoles(Db context)
        {
            DbSet<Role> dbset = context.Set<Role>();
            Role role = new Role
            {
                Id = sysRoleID
                    ,
                Code = "000000"
                    ,
                CreateTime = Now

                    ,
                CreateUserId = sysAdminID,
                Name = "SystemRole"
                    ,
                Description = "SystemRole请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);
            //给SYSTEMROLE加入所有权限
            var models = context.Modules.ToList();
            foreach (var module in models)
            {
                context.ModuleWithRoles.Add(new ModuleWithRole
                {
                    Id = Guid.NewGuid()
                    ,
                    CreateTime = Now
                    ,
                    CreateUserId = sysAdminID
                    ,
                    Deleted = false
                    ,
                    ModuleId = module.Id
                    ,
                    RoleId = role.Id
                    ,
                    StoreId = PharmacyServiceConfig.Config.CurrentStore.Id
                    ,
                    UpdateTime = Now
                    ,
                    UpdateUserId = sysAdminID
                    ,
                });

            }

            role = new Role
            {
                Id = adminRoleID
                ,
                Code = "000001"
                ,
                CreateTime = Now

                ,
                CreateUserId = sysAdminID,
                Name = "adminRole"
                ,
                Description = "adminRole请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            role = new Role
            {
                Id = operatorRoleID
                ,
                Code = "000002"
                ,
                CreateTime = Now

                ,
                CreateUserId = sysAdminID,
                Name = "OperRole"
                ,
                Description = "OperRole请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);
            Dictionary<Guid, string> roles = new Dictionary<Guid, string>();
            roles.Add(new Guid("1F39FAF3-F52F-4785-94F4-0127C8814E39"), "300001|采购员");
            roles.Add(new Guid("DC4B6839-A988-4DCD-B299-09E7CFB3D790"), "300002|采购审批员");
            roles.Add(new Guid("283A8335-8A44-409E-BC7A-022E4B0716F6"), "300003|验收员");
            roles.Add(new Guid("36ABB534-89F7-4967-A940-02B498FE1064"), "300004|保管员");
            foreach (var r in roles)
            {

                role = new Role
                {
                    Id = r.Key,
                    Code = r.Value.Split('|')[0],
                    CreateTime = Now,
                    CreateUserId = sysAdminID,
                    Name = r.Value.Split('|')[1],
                    Description = string.Format("{0}角色请不删除", r.Value.Split('|')[1]),
                    StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                    UpdateTime = Now,
                    UpdateUserId = sysAdminID
                };
                dbset.Add(role);
            }
            //12	业务员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300000"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "业务员"
                ,
                Description = "业务员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //13	收银员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300030"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "收银员"
                ,
                Description = "收银员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);
            //14	质量管理员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300001"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "质量管理员"
                ,
                Description = "质量管理员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //15	质量验收员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300002"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "质量验收员"
                ,
                Description = "质量管理员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //16	疫苗验收员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300010"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "疫苗验收员"
                ,
                Description = "疫苗验收员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //17	养护员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300040"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "养护员"
                ,
                Description = "养护员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //18	疫苗养护员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300050"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "疫苗养护员"
                ,
                Description = "疫苗养护员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //19	计量员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "400060"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "计量员"
                ,
                Description = "计量员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //20	保管员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "400010"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "保管员"
                ,
                Description = "保管员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //21	复核员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300008"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "复核员"
                ,
                Description = "复核员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);
            //22	驾驶员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "500010"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "驾驶员"
                ,
                Description = "驾驶员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //23	会计员 
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300025"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "会计员"
                ,
                Description = "会计员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //24	文员
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "300015"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "文员"
                ,
                Description = "文员请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //25	内勤
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "500020"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "内勤"
                ,
                Description = "内勤请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //26	质量管理部长
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "200010"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "质量管理部长"
                ,
                Description = "质量管理部长请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //27	储运部长
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "200020"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "储运部长"
                ,
                Description = "储运部长请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //28	财务部长
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "200030"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "财务部长"
                ,
                Description = "财务部长请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //29	行政部长
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "200040"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "行政部长"
                ,
                Description = "行政部长请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //30	业务部长
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "200050"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "业务部长"
                ,
                Description = "业务部长请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //31	质量副总经理
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "100020"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "质量副总经理"
                ,
                Description = "质量副总经理请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //32	业务副总经理
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "100030"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "业务副总经理"
                ,
                Description = "业务副总经理请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //33	总经理
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "100010"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "总经理"
                ,
                Description = "总经理请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            //33	总经理
            role = new Role
            {
                Id = Guid.NewGuid()
                ,
                Code = "3004"
                ,
                CreateTime = Now
                ,
                CreateUserId = sysAdminID,
                Name = "销售员"
                ,
                Description = "总经理请不删除",
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                UpdateTime = Now
            };
            dbset.Add(role);

            context.Commit();

        }

        private void BuildStore(Db context)
        {
            context.Set<Store>().Add(PharmacyServiceConfig.Config.CurrentStore);
        }

        /// <summary>
        /// 初始化UserLogs记录
        /// </summary>
        /// <param name="context"></param>
        protected void BuildUserLogs(Db context)
        {
            var nowTime = Now;
            context.Set<UserLog>().Add(new UserLog
            {


                CreateUserId = sysAdminID,
                UpdateUserId = sysAdminID,
                CreateTime = nowTime
                    ,
                UpdateTime = nowTime
                    ,
                Content = string.Format("系统自动创建数据库{0}", nowTime)
                  ,
                StoreId = PharmacyServiceConfig.Config.CurrentStore.Id
            });
            context.Commit();
        }

        protected void BuildDepartments(Db context)
        {
            DbSet<Department> dbset = context.Set<Department>();
            Department department = null;
            department = new Department();
            department.Id = sysDepartmentID;
            department.DepartmentId = Guid.Empty;
            department.Code = "QYGBM";
            department.Name = "药品经营企业名称";
            department.Decription = department.Name + department.Code;
            department.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
            department.Enabled = true;
            dbset.Add(department);
            Department subdepartment = null;
            for (int j = 0; j < 2; j++)
            {
                subdepartment = new Department();
                subdepartment.DepartmentId = department.Id;
                subdepartment.Code = "QYBM" + j.ToString();
                subdepartment.Name = "经营企业部门" + j.ToString();
                subdepartment.Decription = department.Name + department.Code;
                subdepartment.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                subdepartment.Enabled = true;
                dbset.Add(subdepartment);
                context.Commit();
            }
            context.Commit();
        }


        private Guid sysRoleID = Guid.NewGuid();
        private Guid adminRoleID = Guid.NewGuid();
        private Guid operatorRoleID = Guid.NewGuid();
        private Guid sysAdminID = Guid.NewGuid();
        private Guid sysDepartmentID = Guid.NewGuid();
        private void BuildApprovalFlowType(Db context)
        {
            ApprovalFlowType type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "供应商审批A流程",
                ApprovalTypeValue = 1,
                Decription = "供应商审批A流程",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            var node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "供应商审批A流程节点一",
                Name = "供应商审批A流程节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);
            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "供应商审批A流程节点二",
                Name = "供应商审批A流程节点二",
                Order = 2,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);

            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "供应商审批B流程",
                ApprovalTypeValue = 1,
                Decription = "供应商审批B流程",
                Deleted = false
            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "供应商审批B流程一",
                Name = "供应商审批B流程一",
                Order = 2,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);


            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "采购商审批A流程",
                ApprovalTypeValue = 2,
                Decription = "采购商审批A流程",
                Deleted = false
            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "采购商审批A流程一",
                Name = "采购商审批A流程一",
                Order = 2,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);

            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "采购商审批B流程",
                ApprovalTypeValue = 2,
                Decription = "采购商审批B流程",
                Deleted = false
            };
            context.Set<ApprovalFlowType>().Add(type);
            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "采购商审批B流程一",
                Name = "采购商审批B流程一",
                Order = 2,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);

            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "药品审批A流程",
                ApprovalTypeValue = 3,
                Decription = "药品审批A流程",
                Deleted = false
            };
            context.Set<ApprovalFlowType>().Add(type);


            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "药品审批A流程节点一",
                Name = "药品审批A流程节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);
            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "药品审批A流程节点二",
                Name = "药品审批A流程节点二",
                Order = 2,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);




            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "供应商审批A流程解锁",
                ApprovalTypeValue = 4,
                Decription = "供应商审批A流程",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "供应商审批A流程解锁",
                Name = "供应商审批A流程解锁节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);
            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "供应商审批A流程解锁节点二",
                Name = "供应商审批A流程解锁节点二",
                Order = 2,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);


            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "客户解锁审批",
                ApprovalTypeValue = 5,
                Decription = "客户解锁审批",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "客户解锁审批节点一",
                Name = "客户解锁审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);

            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "供货商解锁审批",
                ApprovalTypeValue = 6,
                Decription = "供货商解锁审批",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "供货商解锁审批节点一",
                Name = "供货商解锁审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);

            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "药品修改审批",
                ApprovalTypeValue = 7,
                Decription = "药品修改审批",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "药品修改审批节点一",
                Name = "药品修改审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);


            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "客户修改审批",
                ApprovalTypeValue = 8,
                Decription = "客户修改审批",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "客户修改审批节点一",
                Name = "客户修改审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);





            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "供货商修改审批",
                ApprovalTypeValue = 9,
                Decription = "供货商修改审批",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "供货商修改审批节点一",
                Name = "供货商修改审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);




            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "不合格药品审批",
                ApprovalTypeValue = 10,
                Decription = "不合格药品审批",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "不合格药品审批节点一",
                Name = "不合格药品审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);


            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "药品报损审批",
                ApprovalTypeValue = 11,
                Decription = "药品报损审批",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "药品报损审批节点一",
                Name = "药品报损审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);




            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "移库审批",
                ApprovalTypeValue = 12,
                Decription = "移库审批",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "移库审批节点一",
                Name = "移库审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);


            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "委托车辆",
                ApprovalTypeValue = 13,
                Decription = "委托车辆",
                Deleted = false

            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "委托车辆节点一",
                Name = "委托车辆节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);


            type = new ApprovalFlowType
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Name = "直调审批",
                ApprovalTypeValue = 14,
                Decription = "直调审批",
                Deleted = false
            };
            context.Set<ApprovalFlowType>().Add(type);

            node = new ApprovalFlowNode
            {
                CreateTime = Now,
                CreateUserId = sysAdminID,
                UpdateTime = Now,
                UpdateUserId = sysAdminID,
                Id = Guid.NewGuid(),
                Decription = "直调审批节点一",
                Name = "直调审批节点一",
                Order = 1,
                ApprovalFlowTypeId = type.Id,
                RoleId = sysRoleID
            };
            context.Set<ApprovalFlowNode>().Add(node);

            #region 报警设置

            List<WaringSet> waningSet = new List<WaringSet>()
            {
                new WaringSet()
                {
                     Code="001",
                      Name="供应商过期时间提醒",
                       SetValue="15"
                },
                new WaringSet()
                {
                     Code="002",
                      Name="采购商过期时间提醒",
                       SetValue="15"
                },
                new WaringSet()
                {
                     Code="003",
                      Name="药品过期时间提醒",
                       SetValue="30"
                }
            };
            waningSet.ForEach(p => context.Set<WaringSet>().Add(p));

            #endregion

            context.Commit(); ;
        }


        protected void BuildDrugInfo(Db context)
        {
            DbSet<DrugInfo> dbset = context.Set<DrugInfo>();
            List<BusinessScope> businessScopes = context.BusinessScopes.ToList();
            List<DrugCategory> drugCategories = context.DrugCategorys.ToList();
            List<DictionaryStorageType> dictionaryStorageTypes = context.DictionaryStorageTypes.ToList();
            List<DictionaryMeasurementUnit> dictionaryMeasurementUnits = context.DictionaryMeasurementUnits.ToList();
            List<DictionaryDosage> dictionaryDosages = context.DictionaryDosages.ToList();
            List<DictionarySpecification> dictionarySpecifications = context.DictionarySpecifications.ToList();
            List<SpecialDrugCategory> specialDrugCategorys = context.SpecialDrugCategorys.ToList();
            List<PackagingUnit> packagingUnits = context.PackagingUnits.ToList();
            List<DrugClinicalCategory> drugClinicalCategorys = context.DrugClinicalCategorys.ToList();
            List<PurchaseManageCategoryDetail> purchaseManageCategoryDetails = context.PurchaseManageCategoryDetails.ToList();
            List<MedicalCategoryDetail> medicalCategoryDetails = context.MedicalCategoryDetails.ToList();
            List<DictionaryPiecemealUnit> dictionaryPiecemealUnits = context.DictionaryPiecemealUnits.ToList();
            DrugInfo item = null;
            for (int j = 0; j < 64; j++)
            {
                item = new DrugInfo
                {
                    Id = Guid.NewGuid(),
                    Code = DateTime.Now.ToString("yyyyMMddhhmm") + j,
                    Description = "描述",
                    BarCode = "111111111111" + j,
                    StandardCode = "111111111111" + j.ToString().PadLeft(2, '0'),
                    ProductName = "药品名称" + j,
                    ProductGeneralName = "药品通用名" + j,
                    ProductOtherName = "药品其他名称" + j,
                    FactoryName = "厂家全称" + j,
                    FactoryNameAbbreviation = "厂家简称" + j,
                    PiecemealSpecification = "拆零规格" + j,
                    PiecemealNumber = j,
                    Price = j,
                    LicensePermissionNumber = "批准文号" + j,
                    CreateTime = DateTime.Now,
                    CreateUserId = PharmacyServiceConfig.Config.CurrentStore.Id,
                    BusinessScopeCode = businessScopes[j % businessScopes.Count].Name,
                    DrugCategoryCode = drugCategories[j % drugCategories.Count].Name,
                    DrugStorageTypeCode = dictionaryStorageTypes[j % dictionaryStorageTypes.Count].Name,
                    DictionaryMeasurementUnitCode = dictionaryMeasurementUnits[j % dictionaryMeasurementUnits.Count].Name,
                    DictionaryDosageCode = dictionaryDosages[j % dictionaryDosages.Count].Name,
                    DictionarySpecificationCode = dictionarySpecifications[j % dictionarySpecifications.Count].Name,
                    SpecialDrugCategoryCode = specialDrugCategorys[j % specialDrugCategorys.Count].Name,
                    PurchaseManageCategoryDetailCode = purchaseManageCategoryDetails[j % purchaseManageCategoryDetails.Count].Name,
                    MedicalCategoryDetailCode = medicalCategoryDetails[j % medicalCategoryDetails.Count].Name,
                    DictionaryPiecemealUnitCode = dictionaryPiecemealUnits[j % dictionaryPiecemealUnits.Count].Name,
                    Enabled = true,
                    IsLock = false,
                    ApprovalStatus = Models.ApprovalStatus.Approvaled,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = PharmacyServiceConfig.Config.CurrentStore.Id,
                    ApprovalDate = DateTime.Now,
                    GoodsType = GoodsType.DrugDomestic,
                    Package = packagingUnits[j % packagingUnits.Count].Name,
                    WholeSalePrice = j,
                    ValidRemark = "无",
                    ValidPeriod = 12,
                    TagPrice = 13,
                    SalePrice = j,
                    RetailPrice = j,
                    MinInventoryCount = 1,
                    MaxInventoryCount = 10000,
                    LowSalePrice = 1,
                    LockRemark = "无",
                    LimitedLowPrice = 1,
                    LimitedUpPrice = 1,
                    DictionaryUserDefinedTypeCode = "无",
                    DrugClinicalCategoryCode = drugClinicalCategorys[j % drugClinicalCategorys.Count].Name,
                    Origin = "",
                    PackageAmount = 10,
                    PermitLicenseCode = "PermitCode",
                    PermitOutDate = Now.AddYears(5),
                    PermitDate = Now.AddYears(-2)

                };
                if (item.BusinessScopeCode == "中药饮片" || item.BusinessScopeCode == "中药材")
                {
                    item.DictionaryDosageCode = "";
                    item.Origin = "合肥";
                }
                dbset.Add(item);
            }
            context.Commit();
        }


        protected void BuildInventoryRecord(Db context)
        {
            DbSet<InventoryRecord> dbset = context.Set<InventoryRecord>();
            InventoryRecord item = null;

            DrugInfoRepository d = new DrugInfoRepository(context);
            Guid DrugInfoId = d.Fetch(r => 1 == 1).First().Id;
            string DrugInfoCode = d.Fetch(r => 1 == 1).First().Code;
            for (int j = 0; j < 16; j++)
            {
                item = new InventoryRecord();
                item.Id = Guid.NewGuid();
                item.MaxInventoryCount = 1000000;
                item.MinInventoryCount = 0;
                item.CurrentInventoryCount = 100;
                item.SalesCount = 0;
                item.OnSalesOrderCount = 10;
                item.OnSalesOrderCount = 5000;
                item.RetailCount = 100;
                item.OnRetailCount = 100;

                item.DrugInfoId = DrugInfoId;
                item.DrugInfoCode = DrugInfoCode;

                dbset.Add(item);
                context.Commit();
            }
        }



        protected void BuildDistrict(Db context)
        {
            DbSet<District> dbset = context.Set<District>();
            District item = null;

            item = new District();
            item.Id = Guid.NewGuid();
            item.Name = "江苏";
            item.Decription = "江苏";
            item.Code = "0001";
            item.Enabled = true;
            item.StoreId = Guid.NewGuid();
            dbset.Add(item);

            item = new District();
            item.Id = Guid.NewGuid();
            item.Name = "上海";
            item.Decription = "上海";
            item.Code = "0002";
            item.Enabled = true;
            item.StoreId = Guid.NewGuid();

            dbset.Add(item);


            item = new District();
            item.Id = Guid.NewGuid();
            item.Name = "安徽";
            item.Decription = "安徽";
            item.Code = "0003";
            item.Enabled = true;
            item.StoreId = Guid.NewGuid();

            dbset.Add(item);

            context.Commit();

        }


        protected void BuildPurchaseunit(Db context)
        {
            DistrictRepository d = new DistrictRepository(context);
            Guid DistrictId = d.Fetch(r => 1 == 1).First().Id;

            UnitTypeRepository u = new UnitTypeRepository(context);
            Guid UnitTypeId = u.Fetch(r => 1 == 1).First().Id;

            DbSet<PurchaseUnit> dbset = context.Set<PurchaseUnit>();
            PurchaseUnit item = null;
            for (int j = 0; j < 16; j++)
            {
                item = new PurchaseUnit();
                item.Id = Guid.NewGuid();
                item.FlowID = Guid.NewGuid();
                item.DistrictId = DistrictId;

                item.Name = "单位名称" + j;
                item.Code = "10022" + j;
                item.Fax = "805215" + j;
                item.Email = "puchar" + j + "@sina.cn";
                item.WebAddress = "www.puchar" + j + ".cn";

                item.CreateTime = DateTime.Now;
                item.UpdateTime = DateTime.Now;

                item.OutDate = DateTime.Now.AddMonths(11);
                item.GSPLicenseOutDate = DateTime.Now.AddMonths(1);
                item.GMPLicenseOutDate = DateTime.Now.AddMonths(1);
                item.BusinessLicenseeOutDate = DateTime.Now.AddMonths(1);
                item.MedicineProductionLicenseOutDate = DateTime.Now.AddMonths(1);
                item.MedicineBusinessLicenseOutDate = DateTime.Now.AddMonths(1);
                item.InstrumentsProductionLicenseOutDate = DateTime.Now.AddMonths(1);
                item.InstrumentsBusinessLicenseOutDate = DateTime.Now.AddMonths(1);
                item.LastAnnualDte = DateTime.Now.AddMonths(-11);

                item.IsGSPLicenseOutDate = false;
                item.IsGMPLicenseOutDate = false;
                item.IsBusinessLicenseOutDate = false;
                item.IsMedicineProductionLicenseOutDate = false;
                item.IsMedicineBusinessLicenseOutDate = false;
                item.IsInstrumentsProductionLicenseOutDate = false;
                item.IsInstrumentsBusinessLicenseOutDate = false;

                item.IsOutDate = false;
                item.ApprovalStatus = ApprovalStatus.Approvaled;
                item.IsApproval = true;
                item.Enabled = true;
                item.Valid = true;

                item.UnitTypeId = UnitTypeId;

                dbset.Add(item);
                context.Commit();
            }
        }


        protected void BuildPaymentMethod(Db context)
        {
            PaymentMethodRepository d = new PaymentMethodRepository(context);
            Guid DistrictId = d.Fetch(r => 1 == 1).First().Id;

            DbSet<PaymentMethod> dbset = context.Set<PaymentMethod>();
            PaymentMethod item = null;
            context.Commit();

        }


        protected void BuildSupplyUnit(Db context)
        {
            UnitTypeRepository d = new UnitTypeRepository(context);
            Guid UnitTypeId = d.Fetch(r => 1 == 1).First().Id;


            DbSet<SupplyUnit> dbset = context.Set<SupplyUnit>();
            SupplyUnit item = null;
            for (int j = 0; j < 16; j++)
            {
                item = new SupplyUnit();
                item.Id = Guid.NewGuid();
                item.FlowID = Guid.NewGuid();

                item.Name = "供应商" + j;
                item.Code = "10022" + j;
                item.Fax = "805215" + j;
                item.Email = "puchar" + j + "@sina.cn";
                item.WebAddress = "www.puchar" + j + ".cn";

                item.CreateTime = DateTime.Now;
                item.UpdateTime = DateTime.Now;

                item.AttorneyAattorneyStartdate = DateTime.Now;
                item.QualityAgreemenStartdate = DateTime.Now;

                item.QualityAgreementOutdate = DateTime.Now.AddMonths(11);
                item.AttorneyAattorneyOutdate = DateTime.Now.AddMonths(11);
                item.OutDate = DateTime.Now.AddMonths(11);

                item.GSPLicenseOutDate = DateTime.Now.AddMonths(1);
                item.GMPLicenseOutDate = DateTime.Now.AddMonths(1);
                item.BusinessLicenseeOutDate = DateTime.Now.AddMonths(1);
                item.MedicineProductionLicenseOutDate = DateTime.Now.AddMonths(1);
                item.MedicineBusinessLicenseOutDate = DateTime.Now.AddMonths(1);
                item.InstrumentsProductionLicenseOutDate = DateTime.Now.AddMonths(1);
                item.InstrumentsBusinessLicenseOutDate = DateTime.Now.AddMonths(1);
                item.LastAnnualDte = DateTime.Now.AddMonths(-11);
                item.OrganizationCodeLicenseOutDate = DateTime.Now.AddYears(1);
                item.HealthLicenseOutDate = DateTime.Now.AddYears(1);
                item.LnstitutionLegalPersonLicenseOutDate = DateTime.Now.AddYears(1);
                item.TaxRegisterLicenseOutDate = DateTime.Now.AddYears(1);
                item.MmedicalInstitutionPermitOutDate = DateTime.Now.AddYears(1);
                item.FoodCirculateLicenseOutDate = DateTime.Now.AddYears(1);
                //处理out
                item.IsGSPLicenseOutDate = false;
                item.IsGMPLicenseOutDate = false;
                item.IsBusinessLicenseOutDate = false;
                item.IsMedicineProductionLicenseOutDate = false;
                item.IsMedicineBusinessLicenseOutDate = false;
                item.IsInstrumentsProductionLicenseOutDate = false;
                item.IsInstrumentsBusinessLicenseOutDate = false;
                item.IsLnstitutionLegalPersonLicenseOutDate = false;
                item.IsOrganizationCodeLicenseOutDate = false;
                item.IsHealthLicenseOutDate = false;
                item.IsMmedicalInstitutionPermitOutDate = false;
                item.IsTaxRegisterLicenseOutDate = false;
                item.IsFoodCirculateLicenseOutDate = false;
                item.UnitTypeId = UnitTypeId;
                item.Enabled = true;
                item.OutDate = DateTime.Now.AddYears(1);
                item.IsLock = false;
                item.ApprovalStatus = ApprovalStatus.Approvaled;
                dbset.Add(item);
                context.Commit();
            }
        }


        protected void BuildPurchaseOrder(Db context)
        {
            //SupplyUnitRepository d = new SupplyUnitRepository(context);
            //Guid SupplyUnitId = d.Fetch(r => 1 == 1).First().Id;


            //DbSet<PurchaseOrder> dbset = context.Set<PurchaseOrder>();
            //PurchaseOrder item = null;

            //item = new PurchaseOrder();
            //item.Id = Guid.NewGuid();
            //item.CreateTime = DateTime.Now;
            //item.UpdateTime = DateTime.Now;
            //item.StoreId = Guid.Empty;
            //item.DocumentNumber = "111";
            //item.Decription = "11133333";
            //item.EmployeeId = PharmacyServiceConfig.Config.CurrentStore.Id;
            //item.SupplyUnitId = SupplyUnitId;


            //dbset.Add(item);
            //context.Commit();

            //DbSet<PurchaseOrderDetail> dbset2 = context.Set<PurchaseOrderDetail>();
            //PurchaseOrderDetail Detailitem = null;

            //Detailitem = new PurchaseOrderDetail();
            //Detailitem.Id = Guid.NewGuid();
            //Detailitem.CreateTime = DateTime.Now;
            //Detailitem.UpdateTime = DateTime.Now;
            //Detailitem.StoreId = Guid.Empty;
            //Detailitem.PurchaseOrderId = item.Id;

            //dbset2.Add(Detailitem);
            //context.Commit();


            //Guid PurchaseDeliveryRecordId = Guid.NewGuid();

            //DbSet<PurchaseDeliveryRecord> dbset3 = context.Set<PurchaseDeliveryRecord>();
            //PurchaseDeliveryRecord DeliveryRecord = null;

            //DeliveryRecord = new PurchaseDeliveryRecord();
            //DeliveryRecord.Id = PurchaseDeliveryRecordId;
            //DeliveryRecord.ArrivalAmount = 100;
            //DeliveryRecord.ArrivalDateTime = DateTime.Now.AddDays(-1);
            //DeliveryRecord.DocumentNumber = "000122";
            //DeliveryRecord.QualifiedAmount = 100;
            //DeliveryRecord.CheckResult = 0;
            //DeliveryRecord.PurchaseOrderDetailId = Detailitem.Id;
            //DeliveryRecord.BatchNumber = "20130820";
            //dbset3.Add(DeliveryRecord);
            //context.Commit();
        }



        protected void BuildDrugInventoryRecord(Db context)
        {
            DbSet<DrugInventoryRecord> dbset = context.Set<DrugInventoryRecord>();
            DrugInventoryRecord item = null;

            DrugInfoRepository d = new DrugInfoRepository(context);
            Guid DrugInfoId = d.Fetch(r => 1 == 1).First().Id;
            List<DrugInfo> drugInfos = d.Queryable.ToList();

            //PurchaseDeliveryRecordRepository p = new PurchaseDeliveryRecordRepository(context);
            //Guid PurchaseDeliveryRecordId = p.Fetch(r => 1 == 1).First().Id;

            WarehouseZoneRepository w = new WarehouseZoneRepository(context);
            Guid WarehouseZoneId = w.Fetch(r => 1 == 1).First().Id;
            foreach (var drugInfo in drugInfos)
            {
                item = new DrugInventoryRecord();
                item.Id = Guid.NewGuid();
                item.BatchNumber = DateTime.Now.AddMonths(-9).ToString("yyyyMMddHHmm");
                item.PruductDate = DateTime.Now.AddMonths(-9);
                item.OutValidDate = DateTime.Now.AddMonths(8);
                item.InInventoryCount = 10000;
                item.SalesCount = 10;
                item.OnSalesOrderCount = 5000;
                item.CurrentInventoryCount = 4000;
                item.Decription = "描述即备注";
                item.StoreId = StoreId;//Add By Shen 2013.08.29
                item.DrugInfoId = drugInfo.Id;
                item.WarehouseZoneId = WarehouseZoneId;
                item.PurchaseInInventeryOrderDetailId = Guid.Parse("56bd1155-b95f-46fe-9f0e-1cbf6a24bfd2");
                //item.PurchaseDeliveryRecordId = PurchaseDeliveryRecordId; 
                dbset.Add(item);
            }
            context.Commit();

        }


        protected void BuildDrugMaintainRecord(Db context)
        {
            DbSet<DrugMaintainRecord> dbset = context.Set<DrugMaintainRecord>();
            DbSet<DrugMaintainRecordDetail> dbset2 = context.Set<DrugMaintainRecordDetail>();
            DrugMaintainRecord item = null;

            DrugMaintainRecordDetail detail = null;

            DrugInventoryRecordRepository d = new DrugInventoryRecordRepository(context);
            for (int j = 0; j < 3; j++)
            {
                item = new DrugMaintainRecord();
                item.Id = Guid.NewGuid();
                item.BillDocumentNo = "00000" + j;
                item.ExpirationDate = DateTime.Now;
                item.DrugMaintainTypeValue = 0;
                item.CompleteState = 0;
                item.CreateTime = DateTime.Now;
                item.UpdateTime = DateTime.Now;
                item.CreateUserId = Guid.NewGuid();
                item.UpdateUserId = Guid.NewGuid();
                item.Deleted = false;
                dbset.Add(item);


                for (int i = 0; i < 3 + j; i++)
                {
                    detail = new DrugMaintainRecordDetail();
                    detail.Id = Guid.NewGuid();
                    detail.BillDocumentNo = item.BillDocumentNo;

                    DrugInventoryRecord dir = d.Fetch(r => 1 == 1).OrderBy(r => r.Id).Take(i + 1).OrderByDescending(r => r.Id).FirstOrDefault();
                    detail.DrugInventoryRecordId = dir.Id;
                    detail.ProductName = dir.DrugInfo.ProductName;
                    detail.DictionarySpecificationCode = dir.DrugInfo.DictionarySpecificationCode;
                    detail.OutValidDate = DateTime.Now;
                    detail.CurrentInventoryCount = 500;
                    detail.MaintainCount = 200;
                    detail.Deleted = false;
                    detail.Price = i * 100;
                    detail.PruductDate = DateTime.Now;
                    detail.OutValidDate = DateTime.Now;

                    dbset2.Add(detail);
                }
            }

            context.Commit();

        }
    }
}
