using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_sxxxxx.DTOs;
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
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute]int id, CancellationToken token)
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

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = await service.AddPcAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = pc.Id }, pc);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePcRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdatePcAsync(id,request, cancellationToken);
            return NoContent();
        }catch(NotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
    
}