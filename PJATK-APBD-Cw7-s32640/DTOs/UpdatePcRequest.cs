namespace PJATK_APBD_Cw7_sxxxxx.DTOs;

public record UpdatePcRequest(
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);
