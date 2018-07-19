using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.WebApi.Validators.Interfaces
{
    public interface IBaseValidator<T> where T : class
    {
        void Validate(T model);
    }
}
