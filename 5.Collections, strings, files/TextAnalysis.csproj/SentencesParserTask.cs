using System.Collections.Generic;
using System.Text;

namespace TextAnalysis {
    static class SentencesParserTask {
        public static List<List<string>> ParseSentences(string text) {

            var sentencesList = new List<List<string>>();
            var builder = new StringBuilder();
            List<string> list = null;
            for(int i = 0; i < text.Length; i++) {
                if(char.IsLetter(text[i]) || text[i] == '\'') {
                    builder.Append(char.ToLower(text[i]));
                } else {
                    if(builder.Length != 0) {
                        if(list == null)
                            list = new List<string>();
                        list.Add(builder.ToString());
                        builder.Clear();
                    }
                    if((text[i] == '?' || text[i] == '.' || text[i] == '!' || text[i] == ';'
                        || text[i] == '(' || text[i] == ')' || text[i] == ':') && list != null) {
                        sentencesList.Add(new List<string>(list));
                        list = null;
                    }
                }
            }
            if(builder.Length != 0) {
                if(list == null)
                    list = new List<string>();
                list.Add(builder.ToString());
            }
            if(list != null) {
                sentencesList.Add(list);
            }

            return sentencesList;
        }
    }
}