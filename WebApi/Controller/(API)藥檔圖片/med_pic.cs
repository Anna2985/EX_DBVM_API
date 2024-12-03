using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basic;
using HIS_DB_Lib;
using System.Collections.Concurrent;
using SQLUI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DB2VM_API.Controller._API_藥檔圖片
{
    [Route("api/[controller]")]
    [ApiController]
    public class med_pic : ControllerBase
    {
        static private string API_Server = "http://127.0.0.1:4433";
        static private MySqlSslMode SSLMode = MySqlSslMode.None;
        [HttpGet]
        public string get()
        {
            MyTimerBasic myTimerBasic = new MyTimerBasic();
            returnData returnData = new returnData();
            try
            {
                List<medPicClass> medPicClasses = new List<medPicClass>();
                for (int i = 1; i < DrugList().Count; i++)
                {
                    string 藥碼 = DrugList()[i][(int)enum_DrugList.藥碼].ToString();
                    string 藥名 = DrugList()[i][(int)enum_DrugList.藥名].ToString();
                    string 路徑 = DrugList()[i][(int)enum_DrugList.路徑].ToString();
                    Image image = Image.FromFile(路徑);
                    string base64 = image.ImageToBase64();
                    medPicClass medPicClass = new medPicClass
                    {
                        藥碼 = 藥碼,
                        藥名 = 藥名,
                        副檔名 = "jpg",
                        pic_base64 = base64,
                    };
                    medPicClasses.Add(medPicClass);

                }            
             
                for (int i = 0; i < medPicClasses.Count; i++)
                {
                    medPicClass.add(API_Server, medPicClasses[i]);
                }

                returnData.Code = 200;
                returnData.Result = $"新增<{medPicClasses.Count}>筆圖片";
                returnData.TimeTaken = $"{myTimerBasic}";
                return returnData.JsonSerializationt(true);
            }
            catch(Exception ex)
            {
                returnData.Code = -200;
                returnData.Result = ex.Message;
                return returnData.JsonSerializationt(true);
            }
        }
        public enum enum_DrugList
        {
            藥碼,
            藥名,
            路徑
        }
        public List<object[]> DrugList()
        {
            // 創建DataTable
            DataTable drugTable = new DataTable("drugTable ");

            // 定義欄位
            drugTable.Columns.Add("藥碼", typeof(string));
            drugTable.Columns.Add("藥名", typeof(string));
            drugTable.Columns.Add("路徑", typeof(string));

            // 插入資料
            drugTable.Rows.Add("OCRE", "CreStor 10mg", @"C:\Users\Administrator\Desktop\MedPic\Crestor.jpg");
            drugTable.Rows.Add("ONEX", "Nexium 40mg", @"C:\Users\Administrator\Desktop\MedPic\Nexium.jpg");
            drugTable.Rows.Add("ONOR2", "Norvasc 5mg", @"C:\Users\Administrator\Desktop\MedPic\Norvasc.jpg");
            drugTable.Rows.Add("OOLM2", "Olmetec 40mg", @"C:\Users\Administrator\Desktop\MedPic\Olmetec.jpg");
            drugTable.Rows.Add("OXIG", "*糖 Xigduo XR 10/1000mg", @"C:\Users\Administrator\Desktop\MedPic\Xigduo.jpg");
            drugTable.Rows.Add("ONES", "糖 NesiNA 25mg", @"C:\Users\Administrator\Desktop\MedPic\NesiNA.jpg");
            drugTable.Rows.Add("OQTE", "糖 Qtern 10mg/5mg", @"C:\Users\Administrator\Desktop\MedPic\Qtern.jpg");
            drugTable.Rows.Add("OFOR1", "糖 Forxiga 10mg", @"C:\Users\Administrator\Desktop\MedPic\forxiga.jpg");
            drugTable.Rows.Add("OCEL", "CeleBREX 200MG", @"C:\Users\Administrator\Desktop\MedPic\CeleBREX.jpg");
            drugTable.Rows.Add("ONEB", "Nebilet  5mg", @"C:\Users\Administrator\Desktop\MedPic\Nebilet.jpg");
            drugTable.Rows.Add("OBET1", "*Betmiga PR 50mg", @"C:\Users\Administrator\Desktop\MedPic\Betmiga.jpg");
            drugTable.Rows.Add("OTWY", "Twynsta 80mg/5mg (複方)", @"C:\Users\Administrator\Desktop\MedPic\Twynsta.jpg");
            drugTable.Rows.Add("OARC", "ARcoxia 60mg", @"C:\Users\Administrator\Desktop\MedPic\ARcoxia.jpg");
            drugTable.Rows.Add("ODIO5", "DiOvan 80mg", @"C:\Users\Administrator\Desktop\MedPic\diovan.jpg");
            drugTable.Rows.Add("OCAN1", "糖 Canaglu 100mg", @"C:\Users\Administrator\Desktop\MedPic\Canaglu.jpg");
            drugTable.Rows.Add("OPLA1", "Plavix 75mg", @"C:\Users\Administrator\Desktop\MedPic\Plavix.jpg");
            drugTable.Rows.Add("OSER9", "Seroquel 100MG", @"C:\Users\Administrator\Desktop\MedPic\seroquel.jpg");
            drugTable.Rows.Add("OCYM", "*Cymbalta 30mg", @"C:\Users\Administrator\Desktop\MedPic\cymbalta.jpg");
            drugTable.Rows.Add("OBLO1", "Candis 8mg", @"C:\Users\Administrator\Desktop\MedPic\candis.jpg");
            drugTable.Rows.Add("OCRE2", "Roty 5mg", @"C:\Users\Administrator\Desktop\MedPic\Roty.jpg");
            drugTable.Rows.Add("OSEV2", "Sevikar 40mg/5mg (複方)", @"C:\Users\Administrator\Desktop\MedPic\sevikar.jpg");
            drugTable.Rows.Add("OLIP8", "Lipitor 20mg", @"C:\Users\Administrator\Desktop\MedPic\Lipitor.jpg");

            return drugTable.DataTableToRowList();
        }
    }
}
