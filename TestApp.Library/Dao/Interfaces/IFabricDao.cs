using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Library.DataBase;

namespace TestApp.Library.Dao.Interfaces
{
    public interface IFabricDao
    {
        void FillDefaultData();

        Category AddCategory(Category category);

        Fabric AddFabric(Fabric fabric);

        Identifier AddIdentifier(Identifier identifier);

        Identifier GetIdentifier(int id);

        int GetMaxIdForPair(int fabricId, int categoryId);

        void AddIdentifier(int fabricId, int categoryId);

        List<Category> GetCategories();

        List<Fabric> GetFabrics();

        List<Identifier> GetIdentifiers(int pageNumber, int pageSize);

        void AddFabrics(List<Fabric> fabrics);

        void AddCategories(List<Category> categories);
    }
}
