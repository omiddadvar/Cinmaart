using Cinamaart.WebAPI.Abstractions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Country])]
        public async Task<IActionResult> GetCountries()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Country])]
        public async Task<IActionResult> GetCountryById(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddCountry()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditCountry()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveCountry()
        {
            throw new NotImplementedException();
        }
    }
}
