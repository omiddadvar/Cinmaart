using Cinamaart.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cinamaart.WebAPI.Abstractions
{
    public class CinamaartBaseController(IOutputCacheStore? cacheStore = null) : ControllerBase
    {
        protected async Task<IActionResult> runAfterCommandOperationWithCacheReset(
            IBaseResult result,
            string? cacheTag = null
            )
        {
            if (result.IsSuccess)
            {
                if (cacheStore is not null &&
                        !string.IsNullOrEmpty(cacheTag))
                    await cacheStore.EvictByTagAsync(cacheTag, CancellationToken.None);
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}
