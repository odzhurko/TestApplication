using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Library.Dao.Interfaces;
using TestApp.Library.DataBase;

namespace TestApp.Library.Dao
{
    public class FabricDao : IFabricDao
    {
        private readonly FabricContext _fabricContext;

        public FabricDao(FabricContext fabricContext)
        {
            _fabricContext = fabricContext;
        }

        public Category AddCategory(Category category)
        {
            var existedCategory = _fabricContext.Categories
                .SingleOrDefault(x => x.CategoryCode == category.CategoryCode);

            if(existedCategory != null)
            {
                return existedCategory;
            }

            _fabricContext.Categories.Add(category);
            _fabricContext.SaveChanges();

            return category;
        }

        public Fabric AddFabric(Fabric fabric)
        {
            var existedFabric = _fabricContext.Fabrics
                .SingleOrDefault(x => x.FabricCode== fabric.FabricCode);

            if (existedFabric != null)
            {
                return existedFabric;
            }

            _fabricContext.Fabrics.Add(fabric);
            _fabricContext.SaveChanges();

            return fabric;
        }

        public void AddFabrics(List<Fabric> fabrics)
        {
            foreach (var fabric in fabrics)
            {
                _fabricContext.Fabrics.Add(fabric);
            }            
            _fabricContext.SaveChanges();
        }

        public void AddCategories(List<Category> categories)
        {
            foreach (var category in categories)
            {
                _fabricContext.Categories.Add(category);
            }
            _fabricContext.SaveChanges();
        }

        public Identifier AddIdentifier(Identifier identifier)
        {
            _fabricContext.Identifiers.Add(identifier);
            _fabricContext.SaveChanges();

            return identifier;
        }

        public Identifier GetIdentifier(int id)
        {
            return _fabricContext.Identifiers
                .Include(x => x.Fabric)
                .Include(x => x.Category)
                .FirstOrDefault(x =>x.IdentifierId == id );
        }

        public void AddIdentifier(int fabricId, int categoryId)
        {
            _fabricContext.Database.ExecuteSqlCommand(@"
               DECLARE @MaxId int;
                select @MaxId = isnull(MAX(IdentifierNumber) ,1) from Identifiers where FabricId = @p0 AND CategoryId = @p1;

                insert into Identifiers (FabricId, CategoryId, CreateDateTime,IdentifierNumber)
                values (@p0, @p1, GETDATE(), @MaxId)
                ", fabricId, categoryId);
        }

        public List<Category> GetCategories()
        {
            return _fabricContext.Categories.ToList();
        }

        public List<Fabric> GetFabrics()
        {
            return _fabricContext.Fabrics.ToList();
        }

        public List<Identifier> GetIdentifiers(int pageNumber, int pageSize)
        {
            return _fabricContext.Identifiers
                .Include(x => x.Category)
                .Include(x => x.Fabric)
                .Skip(pageNumber*pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetMaxIdForPair(int fabricId, int categoryId)
        {
            if (!_fabricContext.Identifiers.Any(x => x.FabricId == fabricId && x.CategoryId == categoryId))
            {
                return 0;
            }

            var maxId = _fabricContext.Identifiers
                .Where(x => x.CategoryId == categoryId &&
                x.FabricId == fabricId)
                .Max(x => x.IdentifierNumber);

            return maxId;
        }

        public void FillDefaultData()
        {
            _fabricContext.Database.ExecuteSqlCommand(@"
                    EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'; 
                    EXEC sp_MSForEachTable 'DELETE FROM ?';
                    EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL';

                    DBCC CHECKIDENT ('Fabrics', RESEED, 0);
                    DBCC CHECKIDENT ('Categories', RESEED, 0);
            ");

            _fabricContext.Fabrics.Add(new Fabric { FabricCode = "CH", FabricName = "Test Fabric 1" });
            _fabricContext.Fabrics.Add(new Fabric { FabricCode = "CD", FabricName = "Test Fabric 2" });
            _fabricContext.Fabrics.Add(new Fabric { FabricCode = "CF", FabricName = "Test Fabric 3" });
            _fabricContext.Fabrics.Add(new Fabric { FabricCode = "CG", FabricName = "Test Fabric 4" });

            _fabricContext.Categories.Add(new Category { CategoryCode = "VEH", CategoryName = "Test Category 1" });
            _fabricContext.Categories.Add(new Category { CategoryCode = "VER", CategoryName = "Test Category 2" });
            _fabricContext.Categories.Add(new Category { CategoryCode = "RTG", CategoryName = "Test Category 3" });
            _fabricContext.Categories.Add(new Category { CategoryCode = "WSD", CategoryName = "Test Category 4" });
            _fabricContext.SaveChanges();

            _fabricContext.Identifiers.Add(new Identifier { CategoryId = 1, FabricId = 1 , CreateDateTime = DateTime.Now, IdentifierNumber = 1 });
            _fabricContext.Identifiers.Add(new Identifier { CategoryId = 1, FabricId = 1 , CreateDateTime = DateTime.Now, IdentifierNumber = 2 });
            _fabricContext.Identifiers.Add(new Identifier { CategoryId = 1, FabricId = 1 , CreateDateTime = DateTime.Now, IdentifierNumber = 3 });
            _fabricContext.Identifiers.Add(new Identifier { CategoryId = 1, FabricId = 2, CreateDateTime = DateTime.Now, IdentifierNumber = 1 });

            _fabricContext.SaveChanges();
        }
    }
}
