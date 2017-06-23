using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL_9H
{
    public interface ICardBLL
    {
        string Create(string authorizerAppID, MemberCardModel model);

        MemberCardModel GetModel(string authorizerAppID, string cardID);

        string Update(string authorizerAppID, MemberCardModel model);

        List<MemberCardModel> GetList(string authorizerAppID);
    }
}
