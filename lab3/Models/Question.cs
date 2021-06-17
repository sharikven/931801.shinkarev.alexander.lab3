using System;

namespace lab3.Models
{
    public class Question
    {
        public string question { set; get; }
        public int answer { set; get; }
        public int userAnswer { set; get; }

        public Question()
        {
            Random rnd = new();
            int a = rnd.Next(0, 10);
            int b = rnd.Next(1, 10);
            int opr = rnd.Next(0, 4);

            switch (opr)
            {
                case 0:
                    question = $"{a} + {b} = ";
                    answer = a + b;
                    break;
                case 1:
                    question = $"{a} - {b} =";
                    answer = a - b;
                    break;
                case 2:
                    question = $"{a} * {b} =";
                    answer = a * b;
                    break;
                case 3:
                    question = $"{a} / {b} =";
                    answer = a / b;
                    break;
                default: break;
            }
        }

        public bool isCorrect(int ans, int userans)
        {
           return (userans == ans) ? true : false;
        }
    }
}
