using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Library.Dao.Interfaces;
using TestApp.WebApi.Models;
using TestApp.WebApi.Validators.Interfaces;

namespace TestApp.WebApi.Validators
{
    public class PagingValidator : IPagingValidator
    {
        public void Validate(PagingModel model)
        {
            if(model.PageNumber < 0)
            {
                throw new Exception($"PageNumber '{model.PageNumber}' must be greater or equal 0");
            }            
        }
    }
}
