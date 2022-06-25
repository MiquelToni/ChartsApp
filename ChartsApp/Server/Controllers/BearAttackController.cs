using ChartsApp.Server.Domain.Interfaces;
using ChartsApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ChartsApp.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BearAttackController
  {
    private readonly ILogger<BearAttackController> _logger;
    private readonly IBearAttackRepo _bearAttackRepo;

    public BearAttackController(ILogger<BearAttackController> logger, IBearAttackRepo bearAttackRepo)
    {
      _logger = logger;
      _bearAttackRepo = bearAttackRepo;
    }

    [HttpGet]
    public IEnumerable<BearAttack> Get()
    {
      return _bearAttackRepo.GetBearAttack();
    }

    [HttpGet]
    [Route("GetAttacksPerBearType")]
    public IEnumerable<AttacksPerBearType> GetAttacksPerBearType()
    {
      var bearAttacks = _bearAttackRepo.GetBearAttack();

      var black = new AttacksPerBearType()
      {
        Bear = BearType.Black,
        Cases = bearAttacks.Where(x => x.Bear == BearType.Black).Count()
      };

      var brown = new AttacksPerBearType()
      {
        Bear = BearType.Brown,
        Cases = bearAttacks.Where(x => x.Bear == BearType.Brown).Count()
      };

      var polar = new AttacksPerBearType()
      {
        Bear = BearType.Polar,
        Cases = bearAttacks.Where(x => x.Bear == BearType.Polar).Count()
      };

      return new List<AttacksPerBearType> { brown, black, polar };
    }
  }
}
