using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_sxxxxx.DTOs;
using PJATK_APBD_Cw7_sxxxxx.Exceptions;
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

    public async Task<PcDetailsResponse> GetByIdAsync(int id, CancellationToken token)
    {
        return await databaseContext.PCs
            .Where(pc => pc.Id == id)
            .Select(pcr => new PcDetailsResponse(
                pcr.Id,
                pcr.Name,
                pcr.Weight,
                pcr.Warranty,
                pcr.CreatedAt,
                pcr.Stock,
                
                pcr.PCsComponents.Select(pcs => new PcComponentResponse(
                    pcs.Amount,
                    
                    new ComponentResponse(
                        pcs.Component.Code,
                        pcs.Component.Name,
                        pcs.Component.Description,
                        
                        new ComponentManufacturerResponse(
                            pcs.Component.ComponentManufacturer.Id,
                            pcs.Component.ComponentManufacturer.Abbreviation,
                            pcs.Component.ComponentManufacturer.FullName,
                            pcs.Component.ComponentManufacturer.foundationDate
                            ),
                        
                        new ComponentTypeResponse(
                            pcs.Component.ComponentType.Id,
                            pcs.Component.ComponentType.Abbreviation,
                            pcs.Component.ComponentType.Name)
                        )
                    
                    )).ToList()
                )).FirstOrDefaultAsync(token) 
                ?? throw new NotFoundException($"PC with id {id} not found");
    }
}