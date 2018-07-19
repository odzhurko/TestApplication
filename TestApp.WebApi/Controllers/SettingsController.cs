using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Library.Services.Interfaces;
using TestApp.WebApi.Models;

namespace TestApp.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Settings")]
    public class SettingsController : Controller
    {
        private readonly IFabricService _fabricService;


        public SettingsController(IFabricService fabricService)
        {
            _fabricService = fabricService;
        }

        [HttpGet("FillDefaultData")]
        public StatusCodeResult FillDefaultData()
        {
            _fabricService.FillDefaultData();
            return Ok();
        }

        [HttpGet("Fabric")]
        public ResponseModel GetFabrics()
        {
            return new ResponseModel
            {
                Data = _fabricService.RetrieveFabrics()
            };
        }

        [HttpPost("Fabric")]
        public ResponseModel AddFabric([FromBody]FabricRequestModel fabricRequestModel)
        {
            _fabricService.AddFabric(fabricRequestModel.FabricCode, fabricRequestModel.FabricName);

            return new ResponseModel
            {
                Data = _fabricService.RetrieveFabrics()
            };
        }

        [HttpGet("Category")]
        public ResponseModel GetCategory()
        {
            return new ResponseModel
            {
                Data = _fabricService.RetrieveCategories()
            };
        }

        [HttpPost("Category")]
        public ResponseModel AddCategory([FromBody]CategoryRequestModel CategoryRequestModel)
        {
            _fabricService.AddCategory(CategoryRequestModel.CategoryCode, CategoryRequestModel.CategoryName);

            return new ResponseModel
            {
                Data = _fabricService.RetrieveCategories()
            };
        }
    }
}