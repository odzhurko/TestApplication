using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp.Library.Dao.Interfaces;
using TestApp.Library.DataBase;
using TestApp.Library.Services.Interfaces;
using TestApp.Library.ViewModels;

namespace TestApp.Library.Services
{
    public class MigrationService : IMigrationService
    {

        private readonly IFabricDao _fabricDao;
        private readonly IFabricService _fabricService;

        public MigrationService(IFabricDao fabricDao, IFabricService fabricService)
        {
            _fabricDao = fabricDao;
            _fabricService = fabricService;
        }

        public List<GenIdentifierModel> GenerateIdentifiers(List<GenIdentifierModel> genIdentifierModels)
        {
            foreach (var item in genIdentifierModels.Where(x => string.IsNullOrEmpty(x.GeneratedIdentifier)))
            {
                item.GeneratedIdentifier = _fabricService.GenerateIdentifier(item.FabricId, item.CategoryId);
            }

            return genIdentifierModels;
        }

        public void InsertCategories(List<Category> categories)
        {
            var existed = _fabricDao.GetCategories();

            var uniqueCategories = categories
                .Where(x => !existed.Any(y => y.CategoryCode == x.CategoryCode))
                .ToList();

            _fabricDao.AddCategories(uniqueCategories);
        }

        public void InsertFabrics(List<Fabric> fabrics)
        {
            var existed = _fabricDao.GetFabrics();

            var uniqueFabrics = fabrics
                .Where(x => !existed.Any(y => y.FabricCode == x.FabricCode))
                .ToList();

            _fabricDao.AddFabrics(uniqueFabrics);
        }
    }
}
