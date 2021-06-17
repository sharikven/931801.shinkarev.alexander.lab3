using lab3.Models;
using Microsoft.AspNetCore.Mvc;
using lab3.Util;

namespace lab3.Controllers
{
    public class QuizController : Controller
    {
        private void CreateQlContext()
        {
            var qList = new QuestionList();
            HttpContext.Session.SetObjectAsJson("ql", qList);
        }
        private QuestionList GetQl()
        {
            return HttpContext.Session.GetObjectFromJson<QuestionList>("ql");
        }
        private void SaveQl(QuestionList qList)
        {
            HttpContext.Session.SetObjectAsJson("ql", qList);
        }
        private void SaveQuestion(Question question)
        {
            HttpContext.Session.SetObjectAsJson("quest", question);
        }
        private Question GetQuestion()
        {
            return HttpContext.Session.GetObjectFromJson<Question>("quest");
        }

        public IActionResult StartQuiz()
        {
            CreateQlContext();

            return RedirectToAction("Quiz");
        }

        [HttpGet]
        public IActionResult Quiz()
        {
            var question = new Question();

            SaveQuestion(question);

            ViewBag.q = question;

            return View();
        }

        [HttpPost]
        public IActionResult Quiz(int userAnswer, string action)
        {
            var qList = GetQl();
            Question question = GetQuestion();

            question.userAnswer = userAnswer;

            if (question.isCorrect(question.answer, userAnswer)) qList.rightAnswers++;

            qList.questionCount++;
            qList.add(question);

            SaveQl(qList);

            if (action == "Next")
            {
                return RedirectToAction("Quiz");
            }
            else
            {
                return RedirectToAction("QuizResult");
            }
        }       
        
        public ViewResult QuizResult()
        {
            var qList = GetQl();
            ViewBag.qList = qList;

            return View();
        }
    }
}
