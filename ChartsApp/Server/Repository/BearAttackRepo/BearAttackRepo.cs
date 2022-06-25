using ChartsApp.Server.Domain.Interfaces;
using ChartsApp.Shared;

namespace ChartsApp.Server.Repository.BearAttackRepo
{
  public class BearAttackRepo : IBearAttackRepo {
    public IEnumerable<Shared.BearAttack> GetBearAttack() {
      var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser("./data/bear_attacks.csv")
        {
            TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
        };
        parser.SetDelimiters(new string[] { "," });

        List<BearAttack> bearAttacks = new();
        int rowCount;
        parser.ReadFields(); // skip headers row
        while (!parser.EndOfData)
        {
            rowCount = 0;
            string[]? row = parser.ReadFields();
            if (row == null) continue;

            bearAttacks.Add(
                new BearAttack
                {
                    Date = DateTime.TryParse(row[rowCount++], out DateTime parsedDate) ? parsedDate : null,
                    Location = row[rowCount++],
                    Details = row[rowCount++],
                    Bear = Enum.TryParse(row[rowCount++], true, out BearType parsedBear) ? parsedBear : BearType.Unknown,
                    Latitude = float.TryParse(row[rowCount++], out float parsedLatitude) ? parsedLatitude : null,
                    Longitude = float.TryParse(row[rowCount++], out float parsedLongitude) ? parsedLongitude : null,
                    Name = row[rowCount++],
                    Age = int.TryParse(row[rowCount++], out int parsedAge) ? parsedAge : 0,
                    Gender = Enum.TryParse(row[rowCount++], true, out GenderType parsedGender) ? parsedGender : GenderType.Unknown,
                });
        }

        return bearAttacks;
    }
  }
}