﻿using System.Diagnostics;
using System.Threading.Tasks;
using EniymCacheInterceptor.Demo.Web.Models;
using EniymCacheInterceptor.Demo.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EniymCacheInterceptor.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;

        public HomeController(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<IActionResult> Index()
        {
            var person = await _testService.GetUser(11111);
            return View(person);
        }

        public async Task<IActionResult> Privacy()
        {
            var testStr = await _testService.GetUserName(11);
            return Ok(testStr);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}