using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace TableParser {
    [TestFixture]
    public class FieldParserTaskTests {
        public static void Test(string input, string[] expectedResult) {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for(int i = 0; i < expectedResult.Length; ++i) {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }

        [TestCase("text", new[] { "text" })] //Одно поле
        [TestCase("hello world", new[] { "hello", "world" })] //Больше одного поля Разделитель длиной в один пробел
        [TestCase("hello 'world'", new[] { "hello", "world" })] //Поле в кавычках после простого поля
        [TestCase("'hello' world", new[] { "hello", "world" })] //Простое поле после поля в кавычках
        [TestCase("hello\'world", new[] { "hello", "world" })] //Разделитель без пробелов
        [TestCase("hello     world", new[] { "hello", "world" })] //Разделитель длиной >1 пробела
        [TestCase("''", new[] { "" })] //Пустое поле    
        [TestCase("", new string[0])] //Нет полей
        [TestCase("hello ", new[] { "hello" })] //Пробелы в начале или в конце строки
        [TestCase("'hello", new[] { "hello" })] //Нет закрывающей кавычки
        [TestCase("' ", new[] { " " })] // Пробел в конце поля с незакрытой кавычкой
        [TestCase("' '", new[] { " " })] //Пробел внутри кавычек
        [TestCase("\"", new[] { "" })] //Одинарные кавычки внутри двойных
        [TestCase("\"\\\'\"", new[] { "\'" })] //Экранированный обратный слэш перед закрывающей кавычкой
        [TestCase("\"\\\\\"", new[] { "\\" })] //Экранированный обратный слэш внутри кавычек
        [TestCase("\'\\\'\'", new[] { "\'" })] //Экранированные одинарные кавычки внутри одинарных
        [TestCase("\"\\\"\"", new[] { "\"" })] //Экранированные двойные кавычки внутри двойных
        [TestCase("\'\\\"\'", new[] { "\"" })] // Двойные кавычки внутри одинарных

        public static void RunTests(string input, string[] expectedOutput) {
            Test(input, expectedOutput);
        }
    }

    public class FieldsParserTask {
        // При решении этой задаче постарайтесь избежать создания методов, длиннее 10 строк.
        // Подумайте как можно использовать ReadQuotedField и Token в этой задаче.
        public static List<Token> ParseLine(string line) {
            var tokens = new List<Token>();
            for(int i = 0; i < line.Length;) {
                Token token;
                if(line[i] == ' ') {
                    i++;
                    continue;
                }
                if(line[i] == '"' || line[i] == '\'') {
                    token = ReadQuotedField(line, i);
                    token = TrimSpace(token);
                } else
                    token = ReadField(line, i);

                tokens.Add(token);
                i += token.Length;
            }
            return tokens;
        }

        private static Token TrimSpace(Token token) {
            int i = 0;
            while(i < token.Value.Length && token.Value[i] == ' ') {
                i++;
            }
            if(i == token.Value.Length)
                return token;

            token.Value.Trim(' ');
            return token;
        }

        private static Token ReadField(string line, int startIndex) {
            var resultToken = new StringBuilder();
            var currentIndex = startIndex;

            while(currentIndex < line.Length) {
                if(line[currentIndex] == '\"' || line[currentIndex] == '\'' || line[currentIndex] == ' ')
                    break;
                resultToken.Append(line[currentIndex]);
                currentIndex++;
            }
            return new Token(resultToken.ToString(), startIndex, currentIndex - startIndex);
        }

        public static Token ReadQuotedField(string line, int startIndex) {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}