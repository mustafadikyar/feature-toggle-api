using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace FeatureToggle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        public FeaturesController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [HttpGet("new-feature")]
        public async Task<IActionResult> GetNewFeature()
        {
            if (await _featureManager.IsEnabledAsync("NewFeature"))
            {
                return Ok("New feature is enabled!");
            }
            return NotFound("New feature is not enabled.");
        }

        [HttpGet("beta-feature")]
        public async Task<IActionResult> GetBetaFeature()
        {
            if (await _featureManager.IsEnabledAsync("BetaFeature"))
            {
                return Ok("Beta feature is enabled!");
            }
            return NotFound("Beta feature is not enabled.");
        }
    }
}
