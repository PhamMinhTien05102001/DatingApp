using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.API.DTOs;
using DatingApp.DatingApp.API.Database.Entities;

namespace DatingApp.API.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        public DataContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public UserRepository(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;

        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public User GetUsersById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUsersByUsername(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void CreateUser(User user)
        {
            if (GetUsersByUsername(user.UserName) != null) return;
            _context.Users.Add(user);
        }

        public IEnumerable<MemberDto> GetMembers()
        {
            return _context.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider);
        }

        public MemberDto GetMembersByUsername(string userName)
        {
            return _context.Users.Where(u => u.UserName == userName)
                                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                                .FirstOrDefault();
        }
    }
}