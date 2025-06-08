using StorageApp;

Console.WriteLine("Введите количество палет: ");
var palletsCount = int.Parse(Console.ReadLine());
var pallets = StorageGenerator.GeneratePallets(palletsCount);

StoragePrinter.PrintGroupedPallets(pallets);
StoragePrinter.PrintTopLongTermPallets(pallets);