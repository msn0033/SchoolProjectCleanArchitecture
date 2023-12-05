using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CultureController : ControllerBase
    {
        [HttpGet("culture/setlang")]
        public IActionResult SetLang(string culture ,string url)
        { 
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires=DateTimeOffset.Now.AddDays(2)});
            return Ok(url);
        }
    }
}
