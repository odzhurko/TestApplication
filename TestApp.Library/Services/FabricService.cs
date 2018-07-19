using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Library.Dao.Interfaces;
using TestApp.Library.DataBase;
using TestApp.Library.Services.Interfaces;
using TestApp.Library.ViewModels;

namespace TestApp.Library.Services
{
    public class FabricService : IFabricService
    {
        private readonly IFabricDao _fabricDao;

        public FabricService(IFabricDao fabricDao)
        {
            _fabricDao = fabricDao;
        }

        public void AddCategory(string categoryCode, string categoryName)
        {
            _fabricDao.AddCategory(new Category
            {
                CategoryCode = categoryCode,
                CategoryName = categoryName
            });            
        }

        public void AddFabric(string fabricCode, string fabricName)
        {
            _fabricDao.AddFabric(new Fabric
            {
                FabricCode = fabricCode,
                FabricName = fabricName
            });
        }

        public void FillDefaultData()
        {
            _fabricDao.FillDefaultData();
        }

        public string GenerateIdentifier(int fabricId, int categoryId)
        {
            var maxIdForPair = _fabricDao.GetMaxIdForPair(fabricId, categoryId);

            var newEntry = _fabricDao.AddIdentifier(new Identifier
            {
                CategoryId = categoryId,
                FabricId = fabricId,
                IdentifierNumber = ++maxIdForPair,
                CreateDateTime = DateTime.Now
            });

            var result = _fabricDao.GetIdentifier(newEntry.IdentifierId);

            return $"{result.Category.CategoryCode}-{result.Fabric.FabricCode}-{result.IdentifierNumber}";
        }

        public IEnumerable<Category> RetrieveCategories()
        {
            return _fabricDao.GetCategories();
        }

        public IEnumerable<Fabric> RetrieveFabrics()
        {
            return _fabricDao.GetFabrics();
        }

        public IEnumerable<IdentifierModel> RetrieveIdentifiers(int pageNumber, int pageSize)
        {
            var identifiers = _fabricDao.GetIdentifiers(pageNumber, pageSize);

            return identifiers.Select(x => new IdentifierModel
            {
                IdentifierId = x.IdentifierId,
                CreationDateTime = x.CreateDateTime,
                IdentifierCode = $"{x.Category.CategoryCode}-{x.Fabric.FabricCode}-{x.IdentifierNumber}"
            });
        }
    }
}