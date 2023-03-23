using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonInformation.Data;
using PersonInformation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonInformation.Repostry
{
    public class UserInfoRepostry : IUserInfoRepostry
    {
        private readonly Dbcontext _dbcontext;

        public UserInfoRepostry(Dbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Addperson(PersonInfo personInfo)
        {

            var UserInformation = new Info()
            {
                FirstName = personInfo.FirstName,
                LastName = personInfo.LastName,
                CountryId = personInfo.CountryId,
                imgURL = personInfo.imgURL,
                Age = personInfo.Age,
                CityId =personInfo.CityId
            };

           
            await _dbcontext.Info.AddAsync(UserInformation);  //we added newbook to database with model book creted in folder data
          
            await _dbcontext.SaveChangesAsync();        //save changes in the database

            return UserInformation.id;

        }

        public async Task<List<PersonInfo>> Getinfopersons()
        {

           var obj = await _dbcontext.Info
                .Include(x => x.Country).ThenInclude(c=>c.Cities).Select(item => new PersonInfo
            {
                Age = item.Age,
                FirstName = item.FirstName,
                LastName = item.LastName,
                imgURL = item.imgURL,
                CountryId = item.CountryId,
                CityId =item.CityId,
                CountryName =item.Country.Name,
                CityName = item.Country.Cities.FirstOrDefault().Name

           }).ToListAsync();

            return obj;

        }
    }
}
