using System.ComponentModel.DataAnnotations;

namespace Parcial3_AriasRoldanNatalia.Models
{
    public class EstateServiceView
    {
        [Display(Name = "Placa")]
        public string VehiclePlateumber { get; set; }

        [Display(Name = "Servicio")]
        public string NameService { get; set; }

        [Display(Name = "Precio")]
        public decimal PriceService { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Fecha Salida")]
        public DateTime? DeliveryDate { get; set; }

    }
}
