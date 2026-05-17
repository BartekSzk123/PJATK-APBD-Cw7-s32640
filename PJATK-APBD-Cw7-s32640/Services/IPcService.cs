using PJATK_APBD_Cw7_sxxxxx.DTOs;

namespace PJATK_APBD_Cw7_sxxxxx.Services;

public interface IPcService
{
    Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken token);
    Task <PcDetailsResponse> GetByIdAsync(int id, CancellationToken token);
    Task <PcResponse> AddPcAsync(CreatePcRequest request, CancellationToken cancellationToken);
    Task UpdatePcAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken);
    Task DeletePcAsync(int id, CancellationToken token);
}