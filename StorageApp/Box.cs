namespace StorageApp
{
    public class Box : StorageItem
    {
        public DateOnly? ProductionDate { get; set; }
        private DateOnly _expirationDate;
        public DateOnly ExpirationDate
        {
            get => ProductionDate?.AddDays(100) ?? throw new InvalidOperationException("Дата не указана");
            set => _expirationDate = value;
        }
    }
}
