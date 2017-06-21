using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public enum CodeEnum
    {
        系统异常 = -1,
        成功 = 0,
        失败 = 1,

        密码错误 = 800001,
        账号不存在 = 800002,

        // 上传图片
        文件集合为空 = 801001,
        文件大小超限 = 801002,
    }
}
