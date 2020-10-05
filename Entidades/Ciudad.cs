using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace David_P1_AP1.Entidades{
    public class Ciudad{
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
    }
}