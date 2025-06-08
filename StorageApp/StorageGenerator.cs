namespace StorageApp
{
    public static class StorageGenerator
    {
        public static readonly Random _random = new();

        public static List<Pallet> GeneratePallets(int count)
        {
            var pallets = new List<Pallet>();

            for(int i = 0; i < count; i++)
            {
                var pallet = new Pallet
                {
                    Width = _random.Next(80, 120),
                    Depth = _random.Next(80, 180),
                    Height = _random.Next(10, 18),
                    Boxes = GenerateBoxes(_random.Next(1,15))
                };

                pallets.Add(pallet);
            }

            return pallets;
        }

        public static List<Box> GenerateBoxes(int count)
        {
            var boxes = new List<Box>();
            for (int i = 0; i < count; i++)
            {
                var box = new Box
                {
                    Width = _random.Next(10, 20),
                    Depth = _random.Next(10, 20),
                    Height = _random.Next(10, 20),
                    Weight = _random.Next(1, 20),
                    ProductionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-_random.Next(0, 365)))
                };

                boxes.Add(box);
            }

            return boxes;
        }
    }
}
