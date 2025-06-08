using StorageApp;

namespace StorageAppTests
{
    public class BoxTests
    {
        [Fact]
        public void ExpirationDate_WithProductionDate_ShouldBeProductionDatePlus100Days()
        {
            var productionDate = new DateOnly(2023, 01, 01);
            var box = new Box { ProductionDate = productionDate };

            var result = box.ExpirationDate;

            Assert.Equal(productionDate.AddDays(100), result);
        }

        [Fact]
        public void ExpirationDate_WithoutProductionDate_ShouldThrow()
        {
            var box = new Box { ProductionDate = null };

            Assert.Throws<InvalidOperationException>(() => box.ExpirationDate);
        }
    }
}
  