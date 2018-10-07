using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HowdyService.Models;
using HowdyService.Dal.Contexts;
using AutoMapper;
using HowdyService.Dal.Entities;
using Microsoft.AspNetCore.Http;

namespace HowdyService.Controllers
{
    public class HomeController : Controller
    {
        private const string scoreKey = "score";
        private const string counterKey = "counter";
        private const int nrOfQuestions = 4;

        private readonly HowdyDbContext _dbcontext;

        public HomeController(HowdyDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IActionResult Index()
        {
            InitSession();
            var question = _dbcontext.Questions.FirstOrDefault();
            var questionView = Mapper.Map<QuestionAnwserView>(question);

            return View(questionView);
        }

        public IActionResult NextQuestion(int value)
        {
            AddScore(value);
            int counter = GetCounter();

            if (counter > _dbcontext.Questions.LastOrDefault().Id)
            {
                return RedirectToAction("Result");
            }
            var question = _dbcontext.Questions.FirstOrDefault(q => q.Id == counter);
            var questionView = Mapper.Map<QuestionAnwserView>(question);

            return View("Index", questionView);
        }

        public IActionResult Result()
        {
            var gifId = GetScore() / nrOfQuestions;
            var gif = _dbcontext.Gifs.FirstOrDefault(g => g.Id == gifId);

            var gifView = Mapper.Map<GifView>(gif);

            return View(gifView);
        }

        private void InitSession()
        {
            HttpContext.Session.SetInt32(scoreKey, 0);
            HttpContext.Session.SetInt32(counterKey, 1);
        }

        private void AddScore(int value)
        {
            int? score = HttpContext.Session.GetInt32(scoreKey);
            if (score == null)
            {
                throw new NullReferenceException($"score can't be null, check if you accepted cookies.");
            }

            HttpContext.Session.SetInt32(scoreKey, score.Value + value);
        }

        private int GetScore()
        {
            int? score = HttpContext.Session.GetInt32(scoreKey);
            if (score == null)
            {
                throw new NullReferenceException($"score can't be null, check if you accepted cookies.");
            }
            return score.Value;
        }

        private int GetCounter()
        {
            int? counter = HttpContext.Session.GetInt32(counterKey);
            if (counter == null)
            {
                throw new NullReferenceException($"counter can't be null, check if you accepted cookies.");
            }

            counter = counter.Value + 1;
            HttpContext.Session.SetInt32(counterKey, counter.Value);

            return counter.Value;
        }
    }
}
