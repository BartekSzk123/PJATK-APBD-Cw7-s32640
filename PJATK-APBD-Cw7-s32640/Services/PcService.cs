using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_sxxxxx.DTOs;
using PJATK_APBD_Cw7_sxxxxx.Infrastrucutre;

namespace PJATK_APBD_Cw7_sxxxxx.Services;

public class PcService(DatabaseContext databaseContext) : IPcService
{
    public async Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken token)
    {
        return await databaseContext.PCs.Select(pcr => new PcResponse(
            pcr.Id,
            pcr.Name,
            pcr.Weight,
            pcr.Warranty,
            pcr.CreatedAt,
            pcr.Stock
        )).ToListAsync(token);
    }
}