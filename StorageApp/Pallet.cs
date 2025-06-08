namespace StorageApp
{
    public class Pallet : StorageItem
    {
        public List<Box> Boxes { get; set; } = new();
        public override int Weight => Boxes.Sum(b => b.Weight) + 30;
        public DateOnly? ExpirationDate => Boxes.Count > 0 ? Boxes.Min(b => b.ExpirationDate): null;

        public override int GetVolume() =>
            base.GetVolume() + Boxes.Sum(b => b.GetVolume());
        
        public void AddBox(Box box)
        {
            if (box.Width > Width || box.Depth > Depth)
                throw new InvalidOperationException("Коробка слишком большая");
            Boxes.Add(box);
        }
    }
}
