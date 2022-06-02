namespace ChartsApp.Shared
{
    public class BearAttack
    {
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public string? Details { get; set; }
        public BearType Bear { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
    }
}
