using System;
using System.Xml.Linq;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            string[] days = new string[30];
            string[] months = new string[12];
            double[,] freq = new double[30, 12];
            for(int i = 2; i <= 31; i++) {
                days[i - 2] = i.ToString();
            }

            for(int i = 1; i <= 12; i++) {
                days[i - 1] = i.ToString();
            }

            foreach(var person in names) {
                if(person.BirthDate.Day != 1) {
                    freq[person.BirthDate.Day - 2, person.BirthDate.Month - 1]++;
                }
            }

            return new HeatmapData(
                "Пример карты интенсивностей",
                freq,
                days,
                months);
        }
    }
}