using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Library.DataBase;
using TestApp.Library.ViewModels;

namespace TestApp.Library.Services.Interfaces
{
    public interface IFabricService
    {
        IEnumerable<IdentifierModel> RetrieveIdentifiers(int pageNumber, int pageSize);

        string GenerateIdentifier(int fabricId, int categoryId);

        void AddFabric(string fabricCode, string fabricName);

        void AddCategory(string categoryCode, string categoryName);

        IEnumerable<Fabric> RetrieveFabrics();

        IEnumerable<Category> RetrieveCategories();

        void FillDefaultData();
    }
}
