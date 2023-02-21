

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle {
    public class Indexer: IIndexer {
        //private Dictionary<int, Dictionary<string, HashSet<int>>> dictWordsAndIndex;
        Dictionary<string, HashSet<int>> wordWithIdDoc;
        Dictionary<int, Dictionary<string, HashSet<int>>> idWordText;

        public Indexer() {
            wordWithIdDoc = new Dictionary<string, HashSet<int>>();
            idWordText = new Dictionary<int, Dictionary<string, HashSet<int>>>();
        }

        private void SetInWordIdInText(Dictionary<string, HashSet<int>> keyValuePairs,
                        string word, int idWord) {
            if(keyValuePairs.ContainsKey(word))
                keyValuePairs[word].Add(idWord);
            else
                keyValuePairs.Add(word, new HashSet<int>() { idWord });
        }

        private void SetWordIdDoc(string word, int idDoc) {
            if(wordWithIdDoc.ContainsKey(word))
                wordWithIdDoc[word].Add(idDoc);
            else
                wordWithIdDoc.Add(word, new HashSet<int>() { idDoc });
        }

        public void Add(int id, string documentText) {
            var splits = new HashSet<char>()
                            { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };
            var builder = new StringBuilder();
            var keyValuePairs = new Dictionary<string, HashSet<int>>();
            for(int i = 0; i < documentText.Length; i++) {
                if(splits.Contains(documentText[i])) {
                    if(builder.Length != 0) {
                        var str = builder.ToString();
                        SetInWordIdInText(keyValuePairs, str, i - str.Length);
                        SetWordIdDoc(str, id);
                        builder.Clear();
                    }
                } else
                    builder.Append(documentText[i]);
            }
            if(builder.Length != 0) {
                var str = builder.ToString();
                SetInWordIdInText(keyValuePairs, str, documentText.Length - builder.Length);
                SetWordIdDoc(str, id);
            }
            idWordText.Add(id, keyValuePairs);
        }

        public List<int> GetIds(string word) {
            if(wordWithIdDoc.ContainsKey(word))
                return wordWithIdDoc[word].ToList();
            return new List<int>();
        }

        public List<int> GetPositions(int id, string word) {
            if(idWordText.ContainsKey(id) && idWordText[id].ContainsKey(word))
                return idWordText[id][word].ToList();
            return new List<int>();
        }

        public void Remove(int id) {
            if(idWordText.ContainsKey(id)) {
                idWordText.Remove(id);

                foreach(var item in wordWithIdDoc.ToList())
                    if(item.Value.Contains(id)) {
                        if(item.Value.Count == 1)
                            wordWithIdDoc.Remove(item.Key);
                        else
                            item.Value.Remove(id);
                    }
            }
        }
    }
}

