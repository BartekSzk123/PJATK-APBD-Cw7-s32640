using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_sxxxxx.Models;

[Table("PCsComponents")]
public class PCsComponent
{   
    
    public int PcId { get; set; }
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;
    
    public int Amount { get; set; }

    [ForeignKey(nameof(PcId))] 
    public PC Pc { get; set; } = null!;

    [ForeignKey(nameof(ComponentCode))] 
    public Component Component { get; set; } = null!;

}