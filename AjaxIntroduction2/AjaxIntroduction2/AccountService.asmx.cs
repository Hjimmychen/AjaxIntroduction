﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace AjaxIntroduction2
{
    /// <summary>
    ///AccountService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class AccountService : System.Web.Services.WebService
    {
        [WebMethod]
        public void IsNameDuplicate(string name)
        {
            bool check = name == "Jimmy_Chen";

            //物件轉成JSON
            Context.Response.Write(new JavaScriptSerializer().Serialize(check));  
        }
    }
}
