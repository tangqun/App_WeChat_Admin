using Helper_9H;
using Model_9H;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuCreateReq req = new MenuCreateReq()
            {
                Button = new List<Button>()
                {
                    new Button()
                    {
                        Name = "现代纯K",
                        SubButton = new List<Button>()
                        {
                            new Button()
                            {
                                Type = "view",
                                Name = "门店中心",
                                Url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxab6d7123cc1125f5&redirect_uri=" + "http://wxab6d7123cc1125f5.wx.smartyancheng.com/entityshop/list" + "&response_type=code&scope=snsapi_base&state=&component_appid=" + "wx6230602b18fb87dc" + "#wechat_redirect"
                            }
                        }
                    }
                }
            };
            string requestBody = JsonConvert.SerializeObject(req);

            string accessToken = "ngLMBP9xwQ5M04AQBLX583-ryDHnn7o9fcB-d2Bqvsfxz20baXxFFoUwChX-3sX-23PNdc4CyuE2ktNTMCkykkscq4R-oww0kMFnT1GFWsPYUTNKQTo922Dp-T_Y0virCEWaAKDIKC";
            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + accessToken;

            string responseBody = HttpHelper.Post(url, requestBody);

            Console.WriteLine(responseBody);

            Console.ReadLine();
        }
    }
}
