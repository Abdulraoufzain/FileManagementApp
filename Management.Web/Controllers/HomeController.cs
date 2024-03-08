using Management.Domain.Models;
using Management.InfraStructure.Repository;
using Management.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;

namespace Management.Web.Controllers
{
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            private readonly IRepository<FileUploads> FileUploadsRepository;

            public HomeController(ILogger<HomeController> logger, IRepository<FileUploads> FileUploadsRepository)
            {
                _logger = logger;
                this.FileUploadsRepository = FileUploadsRepository;
            }

            public IActionResult Index()
            {
                return View();
            }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> loginAsync(UserModel createLogin)
        {

            if(createLogin.UserName is  null)
            {
                return BadRequest();
             }
            if(createLogin.UserName == "Abonidal") {
                var claims = new List<Claim>
                    {
                        new Claim (ClaimTypes.NameIdentifier, createLogin.UserName),
                        new Claim (ClaimTypes.Role, "User"),
                    };
                var claimIdintity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdintity));
                return RedirectToAction("UploadFile", "FileUploads");
            }

            return View("login");
        }

        public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            //[Route("details/{FileUploadsId:int}/{slug:SlugTransformer}")]
            //public IActionResult FileUploadsDetails(Guid FileUploadsId, [RegularExpression("^[a-zA-Z0-9- ]+$")] string? slug)
            //{
            //    if (!ModelState.IsValid)
            //        return BadRequest();
            //    var FileUploads = FileUploadsRepository.Get(FileUploadsId);
            //    return View(FileUploads);
            //}
        }
}

