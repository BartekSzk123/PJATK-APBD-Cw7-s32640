using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw7_sxxxxx.DTOs;

public record CreatePcRequest(
    [MaxLength(50), MinLength(1)]string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);
