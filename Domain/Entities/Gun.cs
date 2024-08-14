namespace Domain.Entities
{
    public class Gun
    {
        public int Id { get;set; }
        public string? ModelName { get ; set; }
        public int MagazineSize { get; set; }
        public int Clip { get; set; }
        public bool SquibLoaded { get; set; }
    }
}
