using StorageApp;

while (true)
{
    try
    {
        Console.WriteLine("Введите количество палет: ");
        var palletsCount = int.Parse(Console.ReadLine());
        var pallets = StorageGenerator.GeneratePallets(palletsCount);
        StoragePrinter.PrintGroupedPallets(pallets);
        StoragePrinter.PrintTopLongTermPallets(pallets);
        break;
    }

    catch (Exception ex)
    {
        Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте еще раз");
    }
}

