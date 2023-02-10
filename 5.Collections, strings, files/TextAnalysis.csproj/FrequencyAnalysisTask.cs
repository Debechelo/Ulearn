using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace TextAnalysis {
    static class FrequencyAnalysisTask {

        public static Dictionary<string, int> GetFrequent(List<List<string>> text) {
            var freg = new Dictionary<string, int>();
            for(int i = 0; i < text.Count; i++) {
                for(int j = 0; j < text[i].Count - 1; j++) {
                    if(j + 1 < text[i].Count) {
                        string key = text[i][j] + " " + text[i][j + 1];
                        if(freg.ContainsKey(key)) {
                            freg[key]++;
                        } else
                            freg.Add(key, 1);
                        if(j + 2 < text[i].Count) {
                            key += " " + text[i][j + 2];
                            if(freg.ContainsKey(key)) {
                                freg[key]++;
                            } else
                                freg.Add(key, 1);
                        }
                    }
                }
            }
            return freg;
        }

        private static void setDictionaryFreg(Dictionary<string, string> result, Dictionary<string, int> freg, 
            string key, string value , string fregKey) {
            if(result.ContainsKey(key)) {
                string unKnownKey = key + " " + result[key];
                if(freg[fregKey] < freg[unKnownKey])
                    result[key] = value;
                else if(freg[fregKey] == freg[unKnownKey] && string.CompareOrdinal(fregKey, unKnownKey) > 0) {
                    result[key] = value;
                }
            } else
                result.Add(key, value);
        }

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text) {
            var result = new Dictionary<string, string>();
            var freg = GetFrequent(text);

            foreach(var key in freg.Keys) {
                string[] keys = key.Split(' ');
                if(keys.Length == 2) {
                    setDictionaryFreg(result, freg, keys[0], keys[1], key);
                } else if(keys.Length == 3) {
                    string newKey = keys[0] + " " + keys[1];
                    setDictionaryFreg(result, freg, newKey, keys[2], key);
                }
            }
            return result;
        }
    }
}