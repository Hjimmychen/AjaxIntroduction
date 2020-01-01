using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace AjaxIntroduction2
{
    /// <summary>
    ///AjaxService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class AjaxService : System.Web.Services.WebService
    {
        #region Demo1
        [WebMethod]
        public void IsNameDuplicate(string name)
        {
            bool check = name == "Jimmy_Chen";

            //物件轉成JSON
            Context.Response.Write(new JavaScriptSerializer().Serialize(check));
        }
        #endregion

        #region Demo2
        private static List<User> userList = new List<User> {
                new User { ID = 1, Name = "小明", Mobile = "111" },
                new User { ID = 2, Name = "小華", Mobile = "222" },
                new User { ID = 3, Name = "小陳", Mobile = "333" }
            };

        [WebMethod]
        public void GetUser()
        {
            Context.Response.Write(new JavaScriptSerializer().Serialize(userList));
        }

        [WebMethod]
        public void GetUserByID(int id)
        {
            User user = userList.Where(m => m.ID == id).FirstOrDefault();

            Context.Response.Write(new JavaScriptSerializer().Serialize(user));
        }

        [WebMethod]
        public void UpdateUser(int id, string name, string mobile)
        {
            User user = userList.Where(m => m.ID == id).FirstOrDefault();
            user.Name = name;
            user.Mobile = mobile;

            Context.Response.Write(new JavaScriptSerializer().Serialize(true));
        }

        [WebMethod]
        public void DelUserByID(int id)
        {
            User user = userList.Where(m => m.ID == id).FirstOrDefault();
            userList.Remove(user);

            Context.Response.Write(new JavaScriptSerializer().Serialize(true));
        }
        #endregion

        #region Demo3
        [WebMethod]
        public void ValidMonthInput(int month, string inputted)
        {
            InputHelper helper = new InputHelper(inputted);
            string msg = helper.isMonthValid(month);
            bool success = String.IsNullOrEmpty(msg);

            Context.Response.Write(new JavaScriptSerializer().Serialize(new { success = success, msg = msg }));
        }
        #endregion

        #region Demo4
        [WebMethod]
        public void GetPieChartData()
        {
            List<PieData> data = new List<PieData>{
                new PieData { Task = "Work", HoursPerDay = 11},
                new PieData { Task = "Eat", HoursPerDay = 2},
                new PieData { Task = "Commute", HoursPerDay = 2},
                new PieData { Task = "Watch TV", HoursPerDay = 2 },
                new PieData { Task = "Sleep", HoursPerDay = 7},
            };

            Context.Response.Write(new JavaScriptSerializer().Serialize(data));
        }

        #endregion
    }
}
