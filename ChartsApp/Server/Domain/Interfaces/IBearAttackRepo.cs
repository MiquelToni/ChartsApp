namespace ChartsApp.Server.Domain.Interfaces
{
  public interface IBearAttackRepo {
    IEnumerable<Shared.BearAttack> GetBearAttack();
  }
}