using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basic;
using HIS_DB_Lib;
using MySql.Data.MySqlClient;
using SQLUI;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DB2VM_API.Controller._API_處方取得
{
    [Route("api/[controller]")]
    [ApiController]
    public class BBAR : ControllerBase
    {
        static public string API_Server = "http://127.0.0.1:4433";
        static public string Server = "127.0.0.1";
        static public string DB = "dbvm";
        static public string UserName = "user";
        static public string Password = "66437068";
        static public uint Port = 3306;
        static private MySqlSslMode SSLMode = MySqlSslMode.None;
        [HttpGet]
        public string get_order(string? BarCode)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData returnData = new returnData();
            returnData.Method = "api/bbar?barcode=";
            try
            {
                if (BarCode.StringIsEmpty())
                {
                    returnData.Code = -200;
                    returnData.Result = "Barcode空白";
                    return returnData.JsonSerializationt(true);
                }
                SQLControl sQLControl_med_carInfo = new SQLControl(Server, DB, "ex_order", UserName, Password, Port, SSLMode);
                List<object[]> list_pha_order = sQLControl_med_carInfo.GetRowsByDefult(null, (int)enum_ex_order.藥袋條碼, BarCode);
                List<exorderlistClass> exorderlistClasses = list_pha_order.SQLToClass<exorderlistClass, enum_ex_order>();
                List<object[]> string_pha_order = new List<object[]>();

                List<OrderClass> orderClasses = new List<OrderClass>();
           
                foreach (exorderlistClass exorderlistClass in exorderlistClasses)
                {                                               
                    OrderClass orderClass = new OrderClass
                    {
                        PRI_KEY = BarCode,
                        藥袋條碼 = BarCode,
                        開方日期 = exorderlistClass.開方日期,
                        病歷號 = exorderlistClass.病歷號,
                        領藥號 = exorderlistClass.領藥號,
                        病人姓名 = exorderlistClass.病人姓名,
                        藥品碼 = exorderlistClass.藥品碼,
                        藥品名稱 = exorderlistClass.藥品名稱,
                        單次劑量 = exorderlistClass.單次劑量,
                        頻次 = exorderlistClass.頻次,
                        途徑 = exorderlistClass.途徑,
                        交易量 = (exorderlistClass.交易量.StringToInt32()*-1).ToString(),
                        批序 = exorderlistClass.批序,
                        藥袋類型 = exorderlistClass.藥袋類型,
                        病房 = exorderlistClass.病房,
                        床號 = exorderlistClass.床號,
                        狀態 = "未過帳"
                    };
                    orderClasses.Add(orderClass);
                }
                //List<OrderClass> update_OrderClass = OrderClass.update_order_list(API_Server, orderClasses);
                returnData.Data = orderClasses;
                returnData.Code = 200;
                returnData.Result = $"取得醫令資料{orderClasses.Count}筆資料";
                return returnData.JsonSerializationt(true);
            }
            catch(Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception:{ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        [HttpPost("init_ex_order")]
        public string init_ex_order([FromBody] returnData returnData)
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData.Method = "bbar/init_ex_order";
            try
            {
                List<ServerSettingClass> serverSettingClasses = ServerSettingClassMethod.WebApiGet($"http://127.0.0.1:4433/api/ServerSetting");
                serverSettingClasses = serverSettingClasses.MyFind("Main", "網頁", "VM端");
                if (serverSettingClasses.Count == 0)
                {
                    returnData.Code = -200;
                    returnData.Result = $"找無Server資料!";
                    return returnData.JsonSerializationt();
                }
                return CheckCreatTable(serverSettingClasses[0], new enum_ex_order());
            }
            catch (Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = $"Exception : {ex.Message}";
                return returnData.JsonSerializationt(true);
            }
        }
        private string CheckCreatTable(ServerSettingClass serverSettingClass, Enum enumInstance)
        {
            string Server = serverSettingClass.Server;
            string DB = serverSettingClass.DBName;
            string UserName = serverSettingClass.User;
            string Password = serverSettingClass.Password;
            uint Port = (uint)serverSettingClass.Port.StringToInt32();

            Table table = MethodClass.CheckCreatTable(serverSettingClass, enumInstance);
            return table.JsonSerializationt(true);
        }




    }

}
