using Microsoft.EntityFrameworkCore;
using PersonInformation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonInformation.Repostry
{
    public class CountryRepostry: ICountryRepostry
    {
        private readonly Dbcontext _dbcontext;

        public CountryRepostry(Dbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task <List<Country>> GetCountries()
        {
           return await _dbcontext.Country.Select(x => new Country()
           {
               Id = x.Id,
               Name = x.Name
           }).ToListAsync();
        }

        public async Task<List<City>> GetCities()
        {
           return await _dbcontext.City.Select(x => new City() {  Id = x.Id , Name = x.Name , CountryId = x.CountryId}).ToListAsync();
        }

    }

    }

   

