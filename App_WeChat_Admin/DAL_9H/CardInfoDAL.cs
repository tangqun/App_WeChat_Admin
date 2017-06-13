using Helper_9H;
using IDAL_9H;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_9H
{
    public class CardInfoDAL : ICardInfoDAL
    {
        public int Insert(string authorizerAppID, string cardID, DateTime createTime)
        {
            string sql =
                        @"INSERT INTO `card_info`
                                    (
                                     `authorizer_appid`,
                                     `card_id`,
                                     `card_stat`,
                                     `create_time`,
                                     `update_time`)
                        VALUES (@authorizer_appid,
                                @card_id,
                                '',
                                @create_time,
                                @update_time);
                        SELECT @@IDENTITY;";
            MySqlParameter[] parameters = {
                new MySqlParameter("@authorizer_appid", authorizerAppID),
                new MySqlParameter("@card_id", cardID),
                new MySqlParameter("@create_time", createTime),
                new MySqlParameter("@update_time", createTime)
            };
            return MySqlHelper.ExecuteScalar(ConfigHelper.ConnStr, sql, parameters).ToInt();
        }
    }
}
