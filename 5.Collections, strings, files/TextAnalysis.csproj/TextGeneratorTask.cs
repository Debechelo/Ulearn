using System.Collections.Generic;
using System.Text;

namespace TextAnalysis {
    static class TextGeneratorTask {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount) {

            string twoWords, secondWord;
            string[] words = phraseBeginning.Split(' ');
            if(words.Length >= 2) {
                twoWords = words[words.Length - 2] + " " + words[words.Length - 1];
                secondWord = words[words.Length - 1];
            } else {
                twoWords = words[0];
                secondWord = words[0];
            }

            var builder = new StringBuilder(phraseBeginning);

            for(int i = 0; i < wordsCount; i++) {
                string nextWord;
                if(nextWords.ContainsKey(twoWords)) {
                    nextWord = " " + nextWords[twoWords];
                }else if(nextWords.ContainsKey(secondWord)){
                    nextWord = " " + nextWords[secondWord];
                } else return builder.ToString();
                builder.Append(nextWord);
                twoWords = secondWord + nextWord;
                secondWord = nextWord.Remove(0,1);
            }
            return builder.ToString();
        }
    }
}