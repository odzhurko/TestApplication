using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Library.Services.Interfaces;
using TestApp.WebApi.Models;
using TestApp.WebApi.Validators.Interfaces;

namespace TestApp.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Identifier")]
    public class IdentifierController : Controller
    {
        private readonly IFabricService _fabricService;
        private readonly IPagingValidator _pagingValidator;


        public IdentifierController(IFabricService fabricService, IPagingValidator pagingValidator)
        {
            _fabricService = fabricService;
            _pagingValidator = pagingValidator;
        }

        [HttpGet]
        public ResponseModel GetIdentifiers([FromQuery]PagingModel pagingModel)
        {
            _pagingValidator.Validate(pagingModel);

            return new PagingResponseModel
            {
                Data = _fabricService.RetrieveIdentifiers(pagingModel.PageNumber, pagingModel.PageSize),
                PageNumber = pagingModel.PageNumber,
                PageSize = pagingModel.PageSize
            };
        }

        [HttpPost]
        public ResponseModel GenerateIdentifier([FromBody]IdentifierRequestModel identifierRequestModel)
        {
            return new ResponseModel
            {
                Data = _fabricService.GenerateIdentifier(identifierRequestModel.FabricId, identifierRequestModel.CategoryId)
            };
        }
    }
}
