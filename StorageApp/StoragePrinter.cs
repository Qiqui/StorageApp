namespace StorageApp
{
    public static class StoragePrinter
    {
        public static void PrintGroupedPallets(List<Pallet> pallets)
        {
            var groupedPallets = pallets
                .Where(p => p.ExpirationDate != null)
                .GroupBy(p => p.ExpirationDate)
                .OrderBy(g => g.Key);

            foreach(var group in groupedPallets)
            {
                Console.WriteLine($"\nПаллеты со сроком годности до {group.Key}:\n");
                foreach(var pallet in group.OrderBy(p => p.Weight))
                {
                    Console.WriteLine($"Палета с Id {pallet.Id}: \n\tВес: {pallet.Weight} кг; \n\tОбъем: {pallet.GetVolume()} см3");
                }
            }
        }

        public static void PrintTopLongTermPallets(List<Pallet> pallets)
        {
            var topPallets = pallets
                .OrderByDescending(p => p.Boxes.Max(b => b.ExpirationDate))
                .Take(3)
                .OrderBy(p => p.GetVolume());

            Console.WriteLine("\nТоп 3 палеты с наибольшим сроком годности:\n");

            foreach(var pallet in topPallets)
            {
                Console.WriteLine($"\nПалета {pallet.Id}: \n\tВес: {pallet.Weight} кг; \n\tОбъем: {pallet.GetVolume()} см3; \n\tСрок годности {pallet.ExpirationDate}");
            }
        }
    }
}
