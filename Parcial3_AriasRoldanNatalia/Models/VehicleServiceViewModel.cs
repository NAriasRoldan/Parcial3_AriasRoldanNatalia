using Microsoft.AspNetCore.Mvc.Rendering;
using Parcial3_AriasRoldanNatalia.DAL.Entities;
using Parcial3_AriasRoldanNatalia.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Parcial3_AriasRoldanNatalia.Models
{
    public class VehicleServiceViewModel : Vehicles
    {
        [Display(Name = "Servicio")]
        [NonEmptyGuid(ErrorMessage = "Debes de seleccionar un Servicio.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid ServiceId { get; set; }
        public IEnumerable<SelectListItem> listServices { get; set; }
    }
}
