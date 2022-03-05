using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.DTOs;
using DatingApp.DatingApp.API.Database.Entities;

namespace DatingApp.API.Database.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<MemberDto> GetMembers();
        User GetUsersByUsername(string userName);
        User GetUsersById(int id);
        MemberDto GetMembersByUsername(string userName);
        bool SaveChanges();
        void CreateUser(User user); 
        
    }
}