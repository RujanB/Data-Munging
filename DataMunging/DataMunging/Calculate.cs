using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMunging
{
    public class Calculate
    {
        public void CalculateWeatherSpread()
        {
            var data = new DataReader().GetData(@"D:\Giridhar\Personal\Interview test\Rujan\weather.dat");

            foreach (DataRow item in data.Rows)
            {
                if (!string.IsNullOrEmpty(item["Dy"].ToString()) && int.TryParse(item["Dy"].ToString(), out int day) && int.TryParse(item["MxT"].ToString(), out int mxt) && int.TryParse(item["MnT"].ToString(), out int mnt))
                    Console.WriteLine($" {item["Dy"].ToString()} - {Convert.ToInt32(item["MxT"]) - Convert.ToInt32(item["MnT"])}");
            }

        }

        public void CalculateSoccerLeagueSmallestDiff()
        {
            var data = new DataReader().GetData(@"D:\Giridhar\Personal\Interview test\Rujan\football.dat");
            List<SoccerModel> soccerModels = new List<SoccerModel>();
            foreach (DataRow item in data.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(item["P"])) && item["A"] != DBNull.Value)
                    soccerModels.Add(new SoccerModel()
                    {
                        Name = Convert.ToString(item["P"]),
                        F = Convert.ToInt32(item["A"]),
                        A = Convert.ToInt32(item["Column8"]),
                        Difference = Convert.ToInt32(item["A"]) - Convert.ToInt32(item["Column8"])

                    });
            }

            var finalValue = soccerModels.OrderBy(x => x.Difference).Where(x => x.F > 0 && x.A > 0 && x.Difference > 0).First();

            Console.WriteLine($" Team : {finalValue.Name}  F : {finalValue.F}  A : {finalValue.A}   Diff : {finalValue.Difference}");
        }
    }

    class SoccerModel
    {
        public string? Name { get; set; }
        public int F { get; set; }
        public int A { get; set; }
        public int Difference { get; set; }
    }
}
