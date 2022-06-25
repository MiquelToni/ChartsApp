namespace ChartsApp.Shared
{
  public class AttacksPerBearType
  {
    public BearType Bear { get; set; }
    public String BearName { get { return Bear.ToString(); } }
    public int Cases { get; set; }
  }
}