﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using HIS_DB_Lib;
using Basic;
using Newtonsoft.Json;
using System.ComponentModel;


namespace DB2VM_API
{
    [EnumDescription("ex_order")]
    public enum enum_ex_order
    {
        [Description("GUID,VARCHAR,50,PRIMARY")]
        GUID,
        [Description("PRI_KEY,VARCHAR,200,INDEX")]
        PRI_KEY,
        [Description("藥局代碼,VARCHAR,15,NONE")]
        藥局代碼,
        [Description("藥袋條碼,VARCHAR,200,NONE")]
        藥袋條碼,
        [Description("藥袋類型,VARCHAR,15,NONE")]
        藥袋類型,
        [Description("藥品碼,VARCHAR,10,INDEX")]
        藥品碼,
        [Description("藥品名稱,VARCHAR,200,NONE")]
        藥品名稱,
        [Description("住院序號,VARCHAR,15,INDEX")]
        住院序號,
        [Description("領藥號,VARCHAR,15,INDEX")]
        領藥號,
        [Description("批序,VARCHAR,15,NONE")]
        批序,
        [Description("天數,VARCHAR,15,NONE")]
        天數,
        [Description("單次劑量,VARCHAR,10,NONE")]
        單次劑量,
        [Description("劑量單位,VARCHAR,10,NONE")]
        劑量單位,
        [Description("途徑,VARCHAR,10,NONE")]
        途徑,
        [Description("頻次,VARCHAR,10,NONE")]
        頻次,
        [Description("費用別,VARCHAR,10,NONE")]
        費用別,
        [Description("病房,VARCHAR,10,INDEX")]
        病房,
        [Description("床號,VARCHAR,10,NONE")]
        床號,
        [Description("病人姓名,VARCHAR,50,NONE")]
        病人姓名,
        [Description("病歷號,VARCHAR,20,INDEX")]
        病歷號,
        [Description("醫師代碼,VARCHAR,20,NONE")]
        醫師代碼,
        [Description("科別,VARCHAR,20,NONE")]
        科別,
        [Description("交易量,VARCHAR,15,NONE")]
        交易量,
        [Description("實際調劑量,VARCHAR,15,NONE")]
        實際調劑量,
        [Description("開方日期,DATETIME,20,INDEX")]
        開方日期,
        [Description("結方日期,DATETIME,20,NONE")]
        結方日期,
        [Description("展藥時間,DATETIME,20,NONE")]
        展藥時間,
        [Description("產出時間,DATETIME,20,INDEX")]
        產出時間,
        [Description("過帳時間,DATETIME,20,INDEX")]
        過帳時間,
        [Description("就醫時間,DATETIME,20,INDEX")]
        就醫時間,
        [Description("藥師姓名,VARCHAR,50,INDEX")]
        藥師姓名,
        [Description("藥師ID,VARCHAR,20,NONE")]
        藥師ID,
        [Description("核對姓名,VARCHAR,50,INDEX")]
        核對姓名,
        [Description("核對ID,VARCHAR,15,INDEX")]
        核對ID,
        [Description("領藥姓名,VARCHAR,50,INDEX")]
        領藥姓名,
        [Description("領藥ID,VARCHAR,20,NONE")]
        領藥ID,
        [Description("狀態,VARCHAR,15,NONE")]
        狀態,
        [Description("備註,VARCHAR,300,NONE")]
        備註,
    }
    public class exorderlistClass
    {
        [JsonPropertyName("GUID")]
        public string GUID { get; set; }
        [JsonPropertyName("PRI_KEY")]
        public string PRI_KEY { get; set; }
        [JsonPropertyName("PHARM_CODE")]
        public string 藥局代碼 { get; set; }
        [JsonPropertyName("MED_BAG_SN")]
        public string 藥袋條碼 { get; set; }
        [JsonPropertyName("BRYPE")]
        public string 藥袋類型 { get; set; }
        [JsonPropertyName("CODE")]
        public string 藥品碼 { get; set; }
        [JsonPropertyName("NAME")]
        public string 藥品名稱 { get; set; }
        [JsonPropertyName("MED_BAG_NUM")]
        public string 領藥號 { get; set; }
        [JsonPropertyName("HCASENO")]
        public string 住院序號 { get; set; }
        [JsonPropertyName("UDORDSEQ")]
        public string 就醫序號 { get; set; }
        [JsonPropertyName("HCASETYP")]
        public string 就醫類別 { get; set; }
        [JsonPropertyName("DOS")]
        public string 批序 { get; set; }
        /// <summary>
        /// 天數
        /// </summary>
        [JsonPropertyName("DAYS")]
        public string 天數 { get; set; }
        [JsonPropertyName("SD")]
        public string 單次劑量 { get; set; }
        [JsonPropertyName("DUNIT")]
        public string 劑量單位 { get; set; }
        [JsonPropertyName("RROUTE")]
        public string 途徑 { get; set; }
        [JsonPropertyName("FREQ")]
        public string 頻次 { get; set; }
        [JsonPropertyName("CTYPE")]
        public string 費用別 { get; set; }
        [JsonPropertyName("WARD")]
        public string 病房 { get; set; }
        [JsonPropertyName("BEDNO")]
        public string 床號 { get; set; }
        [JsonPropertyName("PATNAME")]
        public string 病人姓名 { get; set; }
        [JsonPropertyName("PATCODE")]
        public string 病歷號 { get; set; }
        [JsonPropertyName("TXN_QTY")]
        public string 交易量 { get; set; }
        /// <summary>
        /// 實際調劑量
        /// </summary>
        [JsonPropertyName("DISP_QTY")]
        public string 實際調劑量 { get; set; }
        [JsonPropertyName("DOCID")]
        public string 醫師代碼 { get; set; }
        [JsonPropertyName("SECTNO")]
        public string 科別 { get; set; }
        [JsonPropertyName("ORD_START")]
        public string 開方日期 { get; set; }
        [JsonPropertyName("ORD_END")]
        public string 結方日期 { get; set; }
        [JsonPropertyName("EXT_TIME")]
        public string 展藥時間 { get; set; }
        [JsonPropertyName("CT_TIME")]
        public string 產出時間 { get; set; }
        [JsonPropertyName("POST_TIME")]
        public string 過帳時間 { get; set; }
        [JsonPropertyName("VISITDT_TIME")]
        public string 就醫時間 { get; set; }
        [JsonPropertyName("PHARER_NAME")]
        public string 藥師姓名 { get; set; }
        [JsonPropertyName("PHARER_ID")]
        public string 藥師ID { get; set; }
        /// <summary>
        /// 核對姓名
        /// </summary>
        [JsonPropertyName("CHK_NAME")]
        public string 核對姓名 { get; set; }
        /// <summary>
        /// 核對ID
        /// </summary>
        [JsonPropertyName("CHK_ID")]
        public string 核對ID { get; set; }
        [JsonPropertyName("TAKER_NAME")]
        public string 領藥姓名 { get; set; }
        [JsonPropertyName("TAKER_ID")]
        public string 領藥ID { get; set; }
        [JsonPropertyName("STATE")]
        public string 狀態 { get; set; }
        [JsonPropertyName("NOTE")]
        public string 備註 { get; set; }



    }
   

}
