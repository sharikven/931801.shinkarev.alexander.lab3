using System.Collections.Generic;

namespace lab3.Models
{
    public class QuestionList
    {
        public List<Question> ql { get; } = new List<Question>();
        public int rightAnswers { set; get; } = 0;
        public int questionCount { set; get; } = 0;
        public void add(Question q)
        {
            ql.Add(q);
        }

        public List<Question> list()
        {
            return ql;
        }
    }
}
