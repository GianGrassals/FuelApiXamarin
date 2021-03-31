using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace FuelApi.Models
{
    public interface IFuelsApi
    {

        [Get("/api/fuels")]
        Task<List<Fuels>> GetFuels();


    }
}
