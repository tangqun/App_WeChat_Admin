using IDAL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using MySql.Data.MySqlClient;
using Helper_9H;
using System.Data;

namespace DAL_9H
{
    public class UserInfoDAL : IUserInfoDAL
    {
        public List<UserInfoModel> GetList()
        {
            string sql = "SELECT * FROM `user_info` ORDER BY create_time DESC;";
            DataTable dt = MySqlHelper.ExecuteDataset(ConfigHelper.ConnStr, sql).Tables[0];
            return EntityListToModelList(dt);
        }

        public int GetCount()
        {
            string sql = "SELECT COUNT(1) FROM `user_info`;";
            return MySqlHelper.ExecuteScalar(ConfigHelper.ConnStr, sql).ToInt();
        }

        public List<UserInfoModel> GetPageList(int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = GetCount();

            string sql =
                        @"SELECT * FROM `user_info` 
                        ORDER BY create_time DESC 
                        LIMIT @Offset, @Count;";
            MySqlParameter[] parameters = {
                new MySqlParameter("@Offset", (pageIndex - 1) * pageSize),
                new MySqlParameter("@Count", pageSize)
            };
            DataTable dt = MySqlHelper.ExecuteDataset(ConfigHelper.ConnStr, sql, parameters.ToArray()).Tables[0];
            return EntityListToModelList(dt);
        }

        private List<UserInfoModel> EntityListToModelList(DataTable dt)
        {
            List<UserInfoModel> modelList = new List<UserInfoModel>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    modelList.Add(EntityToModel(dr));
                }
            }
            return modelList;
        }

        private UserInfoModel EntityToModel(DataRow dr)
        {
            if (dr != null)
            {
                UserInfoModel model = new UserInfoModel();
                model.ID = dr["id"].ToInt();
                model.Mobile = dr["mobile"].ToString();
                model.Salt = dr["salt"].ToString();
                model.Password = dr["password"].ToString();
                model.RealName = dr["real_name"].ToString();
                model.UserStat = dr["user_stat"].ToInt();
                model.LoginErrorTimes = dr["login_error_times"].ToInt();
                model.CreateTime = dr["create_time"].ToDateTime();
                model.UpdateTime = dr["update_time"].ToDateTime();
                return model;
            }
            return null;
        }
    }
}
