using System;
using System.IO;
using System.Text;

namespace QuizFileParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ouverture du fichier contenant les questions...");
            StreamReader sr = new StreamReader("C:\\Temp\\questionScrum.txt");
            string allText = sr.ReadToEnd();
            Span<string> questionsSpan = allText.Split("\r\n--\r\n").AsSpan();
            Span<string> currentQuestion;
            StreamWriter streamWriter = new StreamWriter("C:\\Temp\\questionOutput.txt");
            for (int i = 0; i < questionsSpan.Length; i++)
            {
                currentQuestion = questionsSpan[i].Split("\r\n").AsSpan();
                streamWriter.WriteLine(
                    $"Question q{i} = new Question(\"{currentQuestion[0].Substring(4)}\"," +
                    $"\"{currentQuestion[1]}\"," +
                    $"{(currentQuestion.Length >= 3 ? string.Concat("\"", currentQuestion[2].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 4 ? string.Concat("\"", currentQuestion[3].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 5 ? string.Concat("\"", currentQuestion[4].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 6 ? string.Concat("\"", currentQuestion[5].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 7 ? string.Concat("\"", currentQuestion[6].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 8 ? string.Concat("\"", currentQuestion[7].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 9 ? string.Concat("\"", currentQuestion[8].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 10 ? string.Concat("\"", currentQuestion[9].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 11 ? string.Concat("\"", currentQuestion[10].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion.Length >= 12 ? string.Concat("\"", currentQuestion[11].AsSpan(3), "\"") : "null")}," +
                    $"{(currentQuestion[0].Contains("(Choose") ? "Question.QuestionType.MultipleChoice" : "Question.QuestionType.SingleChoice")});");
                streamWriter.WriteLine($"addQuestion(q{i});");
            }
            streamWriter.Close();
            
        }
    }
}