using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Library.DataBase
{
    public class FabricContextFactory : IDesignTimeDbContextFactory<FabricContext>
    {
        public FabricContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FabricContext>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=TestApp.DataBase;Trusted_Connection=True;ConnectRetryCount=0";
            optionsBuilder.UseSqlServer(connection);

            return new FabricContext(optionsBuilder.Options);
        }
    }
}
