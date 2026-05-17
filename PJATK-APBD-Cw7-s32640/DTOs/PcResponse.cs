namespace PJATK_APBD_Cw7_sxxxxx.DTOs;

public record PcResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);
