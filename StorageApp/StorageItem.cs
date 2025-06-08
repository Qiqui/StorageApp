namespace StorageApp
{
    public abstract class StorageItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public int Width  { get; set; }
        public int Height  { get; set; }
        public int Depth  { get; set; }
        public virtual int Weight  { get; set; }

        public virtual int  GetVolume()
        {
            return Width * Height * Depth;
        }
    }
}
