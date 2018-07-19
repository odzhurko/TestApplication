using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.WebApi.Models
{
    public class PagingResponseModel : ResponseModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
