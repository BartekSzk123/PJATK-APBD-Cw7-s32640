using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_sxxxxx.Exceptions;
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
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetByIdAsync([FromRoute]int id, CancellationToken token)
    {
        try
        {
            return Ok(await service.GetByIdAsync(id, token));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
}