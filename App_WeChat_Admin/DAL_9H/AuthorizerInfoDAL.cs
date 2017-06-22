using Helper_9H;
using IDAL_9H;
using Model_9H;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_9H
{
    public class AuthorizerInfoDAL : IAuthorizerInfoDAL
    {
        public List<AuthorizerInfoModel> GetList(int userID)
        {
            string sql =
                        @"SELECT
                            `id`,
                            `user_id`,
                            `authorizer_appid`,
                            `nick_name`,
                            `head_img`,
                            `service_type_info`,
                            `verify_type_info`,
                            `user_name`,
                            `alias`,
                            `qrcode_url`,
                            `open_pay`,
                            `open_shake`,
                            `open_scan`,
                            `open_card`,
                            `open_store`,
                            `idc`,
                            `principal_name`,
                            `create_time`,
                            `update_time`
                        FROM `authorizer_info`
                        WHERE `user_id` = @user_id";
            DataTable dt = MySqlHelper.ExecuteDataset(ConfigHelper.ConnStr, sql, new MySqlParameter("@user_id", userID)).Tables[0];
            return EntityListToModelList(dt);
        }

        public AuthorizerInfoModel GetModel(string authorizerAppID)
        {
            string sql =
                        @"SELECT
                            `id`,
                            `user_id`,
                            `authorizer_appid`,
                            `nick_name`,
                            `head_img`,
                            `service_type_info`,
                            `verify_type_info`,
                            `user_name`,
                            `alias`,
                            `qrcode_url`,
                            `open_pay`,
                            `open_shake`,
                            `open_scan`,
                            `open_card`,
                            `open_store`,
                            `idc`,
                            `principal_name`,
                            `create_time`,
                            `update_time`
                        FROM `authorizer_info`
                        WHERE `authorizer_appid` = @authorizer_appid;";
            DataRow dr = MySqlHelper.ExecuteDataRow(ConfigHelper.ConnStr, sql, new MySqlParameter("@authorizer_appid", authorizerAppID));
            return EntityToModel(dr);
        }

        private List<AuthorizerInfoModel> EntityListToModelList(DataTable dt)
        {
            List<AuthorizerInfoModel> modelList = new List<AuthorizerInfoModel>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    modelList.Add(EntityToModel(dr));
                }
            }
            return modelList;
        }

        private AuthorizerInfoModel EntityToModel(DataRow dr)
        {
            if (dr != null)
            {
                AuthorizerInfoModel model = new AuthorizerInfoModel();
                model.ID = dr["id"].ToInt();
                model.UserID = dr["user_id"].ToInt();
                model.AuthorizerAppID = dr["authorizer_appid"].ToString();
                model.NickName = dr["nick_name"].ToString();
                model.HeadImg = dr["head_img"].ToString();
                model.ServiceTypeInfo = dr["service_type_info"].ToInt();
                model.VerifyTypeInfo = dr["verify_type_info"].ToInt();
                model.UserName = dr["user_name"].ToString();
                model.Alias = dr["alias"].ToString();
                model.QrcodeUrl = dr["qrcode_url"].ToString();
                model.OpenPay = dr["open_pay"].ToInt();
                model.OpenShake = dr["open_shake"].ToInt();
                model.OpenScan = dr["open_scan"].ToInt();
                model.OpenCard = dr["open_card"].ToInt();
                model.OpenStore = dr["open_store"].ToInt();
                model.IDC = dr["idc"].ToInt();
                model.PrincipalName = dr["principal_name"].ToString();
                model.CreateTime = dr["create_time"].ToDateTime();
                model.UpdateTime = dr["update_time"].ToDateTime();
                return model;
            }
            return null;
        }
    }
}
