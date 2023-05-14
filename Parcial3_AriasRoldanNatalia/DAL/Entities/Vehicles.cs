using System.ComponentModel.DataAnnotations;

namespace Parcial3_AriasRoldanNatalia.DAL.Entities
{
    public class Vehicles :Entity
    {
        [Display(Name = "Propietario")]
        public User Owner { get; set; }

        [Display(Name = "Placa")]
        public string NumberPlate { get; set; }

        [Display (Name = "Servicio")]
        public Services? Services { get; set; } 

    }
}
