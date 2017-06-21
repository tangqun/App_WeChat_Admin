using IDAL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using System.Data;
using Helper_9H;
using MySql.Data.MySqlClient;

namespace DAL_9H
{
    public class AdminInfoDAL : IAdminInfoDAL
    {
        public AdminInfoModel GetModel(string mobile)
        {
            string sql = "SELECT * FROM `admin_info` WHERE mobile = @mobile;";
            DataRow dr = MySqlHelper.ExecuteDataRow(ConfigHelper.ConnStr, sql, new MySqlParameter("@mobile", mobile));
            return EntityToModel(dr);
        }

        private AdminInfoModel EntityToModel(DataRow dr)
        {
            if (dr != null)
            {
                AdminInfoModel model = new AdminInfoModel();
                model.ID = dr["id"].ToInt();
                model.BusinessID = dr["business_id"].ToString();
                model.Mobile = dr["mobile"].ToString();
                model.Salt = dr["salt"].ToString();
                model.Password = dr["password"].ToString();
                model.RealName = dr["real_name"].ToString();
                model.UserStat = dr["user_stat"].ToInt();
                model.LoginErrorTimes = dr["login_error_times"].ToInt();
                model.Token = dr["token"].ToString();
                model.CreateTime = dr["create_time"].ToDateTime();
                model.UpdateTime = dr["update_time"].ToDateTime();
                return model;
            }
            return null;
        }
    }
}
