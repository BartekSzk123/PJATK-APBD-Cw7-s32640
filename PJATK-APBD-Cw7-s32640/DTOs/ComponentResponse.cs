namespace PJATK_APBD_Cw7_sxxxxx.DTOs;

public record ComponentResponse(
    string Code,
    string Name,
    string Description,
    ComponentManufacturerResponse Manufacturer,
    ComponentTypeResponse Type
);
