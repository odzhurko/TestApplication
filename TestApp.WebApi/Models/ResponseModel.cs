using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.WebApi.Models
{
    public class ResponseModel
    {
        public Exception Error { get; set; }
        public object Data { get; set; }
    }
}
