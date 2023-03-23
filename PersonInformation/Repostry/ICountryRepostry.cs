using PersonInformation.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonInformation.Repostry
{
    public interface ICountryRepostry
    {
        Task<List<Country>> GetCountries();

        Task<List<City>> GetCities();
    }
}