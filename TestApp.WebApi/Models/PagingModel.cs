using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.WebApi.Models
{

    public class PagingModel
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 5;
    }
}
