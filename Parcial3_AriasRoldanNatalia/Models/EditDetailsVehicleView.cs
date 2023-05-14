using Parcial3_AriasRoldanNatalia.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Parcial3_AriasRoldanNatalia.Models
{
    public class EditDetailsVehicleView : Entity
    {
        public DateTime? DeliveryDate { get; set; }

        public Guid VehiclesId { get; set; }
    }
}
