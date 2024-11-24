using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MultiLanguage.Library;
using MultiLanguage.Library.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiLanguage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok(UIMessages.WelcomeMessage(name));
        }

        [HttpPost]
        public IActionResult Get(CreateTestDto dto)
        {
            return Ok(UIMessages.WelcomeMessage(dto.Name));
        }
    }
}

