using Moq;
using System;
using System.Collections.Generic;
using TestApp.Library.Dao.Interfaces;
using TestApp.Library.DataBase;
using TestApp.Library.Services;
using TestApp.Library.Services.Interfaces;
using Xunit;

namespace TestApp.Library.xUnitTests.Services
{
    public class FabricServiceTests : IDisposable
    {
        private Mock<IFabricDao> _fabricDaoMock;

        private IFabricService _fabricService;

        public FabricServiceTests()
        {
            _fabricDaoMock = new Mock<IFabricDao>();

            _fabricService = new FabricService(_fabricDaoMock.Object);
        }

        [Fact]
        public void GenerateIdentifier_WhenPreviousIdisOne_ReturnNewGeneratedId()
        {
            var prevId = 1;

            var listOfTestIdentifiers = GenerateListIdentifiers(prevId + 1);

            _fabricDaoMock.Setup(x => x.GetMaxIdForPair(It.IsAny<int>(), It.IsAny<int>())).Returns(prevId);
            _fabricDaoMock.Setup(x => x.AddIdentifier(It.IsAny<Identifier>())).Returns<Identifier>(x => { return GenerateIdentifier(x.IdentifierNumber); });
            _fabricDaoMock.Setup(x => x.GetIdentifier(It.IsAny<int>())).Returns(listOfTestIdentifiers[0]);

            var testResult = _fabricService.GenerateIdentifier(1, 1);

            Assert.NotNull(testResult);
            Assert.Equal($"CATEGORY-FABRIC-{++prevId}", testResult);
        }

        private List<Identifier> GenerateListIdentifiers(int newNumber)
        {
            return new List<Identifier>
            {
                GenerateIdentifier(newNumber)
            };
        }

        private Identifier GenerateIdentifier(int newNumber)
        {
            return new Identifier
            {
                IdentifierId = 1,
                CategoryId = 1,
                FabricId = 1,
                CreateDateTime = DateTime.Now,
                IdentifierNumber = newNumber,
                Fabric = new Fabric
                {
                    FabricId = 1,
                    FabricCode = "FABRIC"
                },
                Category = new Category
                {
                    CategoryId = 1,
                    CategoryCode = "CATEGORY"
                }
            };
        }

        public void Dispose()
        {
        }
    }
}
