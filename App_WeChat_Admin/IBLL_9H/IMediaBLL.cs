using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IBLL_9H
{
    public interface IMediaBLL
    {
        string UploadImg(string authorizerAppID, HttpFileCollectionBase files);
    }
}
