using System.Linq;
using AutoMapper;
using DatingApp.API.Database.Entities;
using DatingApp.DatingApp.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Database.Repositories
{
    public class UserLikeRepository : IUserLikeRepository
    {
        public DataContext _context { get; set; }
        public UserLikeRepository(DataContext context)
        {
            this._context = context;

        }
        
        public bool LikeUser(string sourceUsername, string likedUsername)
        {
            var sourceUser = _context.Users.Include(x => x.SourceUsers).FirstOrDefault(u => u.UserName == sourceUsername);
            if(sourceUser == null) return false;
            var likedUser = _context.Users.FirstOrDefault(u => u.UserName == likedUsername);

            if(likedUser == null)     return false;
            if(sourceUser.SourceUsers.Any(u => u.LikedUserId == likedUser.Id)) return false;
            _context.UserLikes.Add(new UserLike{SourceUserId = sourceUser.Id, LikedUserId = likedUser.Id});

            return _context.SaveChanges() > 0;
        }
    }
}