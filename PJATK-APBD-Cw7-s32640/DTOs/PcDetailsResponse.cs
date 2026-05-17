namespace PJATK_APBD_Cw7_sxxxxx.DTOs;

public record PcDetailsResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PcComponentResponse> PcComponents
);