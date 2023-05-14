using Microsoft.AspNetCore.Mvc.Rendering;

namespace Parcial3_AriasRoldanNatalia.Helpers
{
    public interface IDropDownListHelper
    {

        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();
    }
}
