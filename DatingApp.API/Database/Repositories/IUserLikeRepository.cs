using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Database.Repositories
{
    public interface IUserLikeRepository
    {
        bool LikeUser(string sourceUsername, string likedUsername);
    }
}