using System.ComponentModel.DataAnnotations;

namespace Parcial3_AriasRoldanNatalia.DAL.Entities
{

    public class Entity
    {
        #region
        [Key]
        public virtual Guid Id { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime? CreatedDate { get; set; }
        #endregion
    }

}
