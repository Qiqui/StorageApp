using StorageApp;

namespace StorageAppTests
{
    public class PalletTests
    {
        public void Weight_WithBoxes_ShouldSumBoxesWeightPlus30()
        {
            var pallet = new Pallet();
            var firstBox = new Box { Weight = 10 };
            var secondBox = new Box { Weight = 20 };
            pallet.AddBox(firstBox);
            pallet.AddBox(secondBox);

            var result = pallet.Weight;

            Assert.Equal(60, result);
        }

        [Fact]
        public void ExpirationDate_WithBoxes_ShouldReturnMinExpirationDate()
        {
            var pallet = new Pallet();
            var firstBox = new Box { ProductionDate = new DateOnly(2025, 01, 01) };
            var secondBox = new Box { ProductionDate = new DateOnly(2025, 02, 01) };
            pallet.AddBox(firstBox);
            pallet.AddBox(secondBox);

            var result = pallet.ExpirationDate;

            Assert.Equal(new DateOnly(2025, 04, 11), result);
        }

        [Fact]
        public void AddBox_WhenBoxIsWider_ShouldThrow()
        {
            var pallet = new Pallet
            {
                Width = 10,
            };

            var widerBox = new Box
            {
                Width = 100,
            };

            Assert.Throws<InvalidOperationException>(() => pallet.AddBox(widerBox));
        }

        [Fact]
        public void AddBox_WhenBoxIsDeeper_ShouldThrow()
        {
            var pallet = new Pallet
            {
                Depth = 10,
            };

            var deeperBox = new Box
            {
                Depth = 100,
            };

            Assert.Throws<InvalidOperationException>(() => pallet.AddBox(deeperBox));
        }

        [Fact]
        public void AddBox_WhenBoxHasSameSize_ShouldNotThrow()
        {
            var pallet = new Pallet
            {
                Depth = 10,
            };

            var box = new Box
            {
                Depth = 10,
            };

            var exception = Record.Exception(() => pallet.AddBox(box));
            Assert.Null(exception);
        }
    }
}
