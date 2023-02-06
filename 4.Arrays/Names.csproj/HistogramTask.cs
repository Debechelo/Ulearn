using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            string[] days = new string[31];
            double[] freq = new double[31];
            for(int i = 1; i <= 31; i++) {
                days[i - 1] = i.ToString();   
            }
            foreach(var person in names) {
                if(person.Name == name) {
                    freq[person.BirthDate.Day - 1]++;
                }
            }
            freq[0] = 0;

            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                days,
                freq);
        }
    }
}