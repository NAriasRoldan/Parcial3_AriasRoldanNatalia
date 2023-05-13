using System.ComponentModel.DataAnnotations;

namespace Parcial3_AriasRoldanNatalia.DAL.Entities
{
    public class VehicleDetails : Entity
    {
        [Display(Name = "Fecha de Entrega")]
        public DateTime? DeliveryDate { get; set; }

        [Display (Name = "Vehiculo")]
        public Vehicles Vehicles { get; set; }
    }
}
