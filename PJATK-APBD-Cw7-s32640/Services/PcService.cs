using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_sxxxxx.DTOs;
using PJATK_APBD_Cw7_sxxxxx.Exceptions;
using PJATK_APBD_Cw7_sxxxxx.Infrastrucutre;
using PJATK_APBD_Cw7_sxxxxx.Models;

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

    public async Task<PcResponse> AddPcAsync(CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        databaseContext.Add(pc);
        await databaseContext.SaveChangesAsync(cancellationToken);
        return new PcResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock);
    }

    public async Task UpdatePcAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken)
    {
        int affectedRows = await databaseContext.PCs.Where(pc => pc.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(pc => pc.Name, request.Name)
                .SetProperty(pc => pc.Weight, request.Weight)
                .SetProperty(pc => pc.Warranty, request.Warranty)
                .SetProperty(pc => pc.CreatedAt, request.CreatedAt)
                .SetProperty(pc => pc.Stock, request.Stock),
                cancellationToken);

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }

    public async Task DeletePcAsync(int id, CancellationToken token)
    {
        int affectedRows = await databaseContext.PCs
            .Where(pc => pc.Id == id )
            .ExecuteDeleteAsync(token);
        
        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }
}