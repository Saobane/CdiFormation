using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public class RateRepositoryCsv : IRateRepository
    {
        private const String FilePath = @"C:\Users\sahobau.dasilva\source\Repos\CdiFormationRepo\PricerSolution\MyPricerLibrary\CSV\taux2.csv";

        public List<RateCurve> GetRatesCurve()
        {
            var durations = GetHeaderDurations();

            var list = new List<RateCurve>();
            String line;
            using (var reader = new StreamReader(FilePath))
            {
                reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    var rateCurve = new RateCurve();
                    var ratesHashTable = new Hashtable();
                    var lineList = SplitCsvLine(line);

                    rateCurve.RatesDate = DateTime.Parse(lineList[0]);

                    for (int i = 1; i < lineList.Count-1; i++)
                    {
                        double rateTmp= lineList[i].Trim() == "na" ? 0 : Convert.ToDouble( lineList[i].Trim().Replace(".", ","));


                        ratesHashTable.Add(durations[i-1], rateTmp);
                    }
                    rateCurve.Rates = ratesHashTable;
                    list.Add(rateCurve);
                }


            }

            return list;
        }


        public List<double> GetHeaderDurations()
        {
            List<double> durations = new List<double>();
            int i = 0;
            using (var reader = new StreamReader(FilePath))
            {
                var csvHeader = reader.ReadLine().Split(';').ToList();
               
                
                csvHeader.ForEach(x => {
                    if (i > 0 && i < csvHeader.Count - 1)
                    {
                        durations.Add(double.Parse(Regex.Match(x, @"\d+").Value));

                    }
                    i++;
                });

                

            }
            return durations;

        }

        private List<String> SplitCsvLine(String line)
        {

            return line.Split(';').ToList();
        }
    }
}
