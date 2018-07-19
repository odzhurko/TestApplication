using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Library.DataBase;
using TestApp.Library.ViewModels;

namespace TestApp.Library.Services.Interfaces
{
    public interface IMigrationService
    {
        void InsertCategories(List<Category> categories);

        void InsertFabrics(List<Fabric> fabrics);

        List<GenIdentifierModel> GenerateIdentifiers(List<GenIdentifierModel> genIdentifierModels);
    }
}
