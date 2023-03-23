using PersonInformation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonInformation.Repostry
{
    public interface IUserInfoRepostry
    {
        Task<int> Addperson(PersonInfo personInfo);
        Task<List<PersonInfo>> Getinfopersons();
    }
}