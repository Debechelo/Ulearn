using NUnit.Framework;
using System.Text;

namespace TableParser {
    [TestFixture]
    public class QuotedFieldTaskTests {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase(@"'a\' b\'", 0, "a' b'", 8)]
        [TestCase(@"'a\' b'xx", 0, "a' b", 7)]
        [TestCase(@"'\'\''xx", 0, "''", 6)]
        [TestCase("'a\"\"'", 0, "a\"\"", 5)]
        [TestCase("\"abc\"", 0, "abc", 5)]
        [TestCase("sx\"a'\"", 2, "a'", 4)]
        [TestCase("'a\"\"'", 0, "a\"\"", 5)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength) {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    class QuotedFieldTask {
        public static Token ReadQuotedField(string line, int startIndex) {
            var resultToken = new StringBuilder();
            var currentIndex = startIndex;
            char startChar = line[currentIndex];
            bool flag = false;
            if(startChar == '\'' || startChar == '"') {
                currentIndex++;
                flag = true;
            }

            while(currentIndex < line.Length) {
                currentIndex++;
                if(line[currentIndex - 1] == '\\' && currentIndex < line.Length
                    && line[currentIndex] == '\'') {
                    resultToken.Append(line[currentIndex]);
                    currentIndex++;
                    continue;
                }
                if(flag && line[currentIndex - 1] == startChar)
                    break;
                resultToken.Append(line[currentIndex - 1]);
            }
            return new Token(resultToken.ToString().Trim(' '), startIndex, currentIndex - startIndex);
        }
    }
}
