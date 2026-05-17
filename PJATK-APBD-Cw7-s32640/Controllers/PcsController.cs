using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_sxxxxx.Services;

namespace PJATK_APBD_Cw7_sxxxxx.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController(IPcService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        return Ok(await service.GetAllAsync(token));
    }
}