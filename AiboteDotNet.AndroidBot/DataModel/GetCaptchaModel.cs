using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.DataModel
{
    public class GetCaptchaModel
    {

        public int err_no { get; set; }
        public string err_str { get; set; }
        public string pic_id { get; set; }
        public string pic_str { get; set; }
        public string md5 { get; set; }


    }
}
