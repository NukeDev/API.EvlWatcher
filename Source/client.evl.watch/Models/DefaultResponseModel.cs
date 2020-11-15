using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.evl.watch.Models
{
    public class DefaultResponseModel<T>
    {
        public string ResponseID { get; set; }
        public int ResponseStatusCode { get; set; }
        public DateTimeOffset ResponseDateTime { get; set; }
        public string RequestMethod { get; set; }
        public string IPAddress { get; set; }
        public T Data { get; set; }

    }
}
