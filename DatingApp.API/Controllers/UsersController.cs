using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Database.Repositories;
using DatingApp.API.DTOs;
using DatingApp.API.Extensions;
using DatingApp.DatingApp.API.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public IUserRepository _userRepository { get; set; }
        public IUserLikeRepository _userLikeRepository { get; set; }
        public UsersController(IUserRepository userRepository, IUserLikeRepository userLikeRepository)
        {
            this._userLikeRepository = userLikeRepository;
            this._userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MemberDto>> Get()
        {
            // var users = _userRepository.GetUsers();
            // return Ok(_mapper.Map<IEnumerable<MemberDto>>(users));

            return Ok(_userRepository.GetMembers());
        }

        [HttpGet("{username}")]
        public ActionResult<MemberDto> Get(string username)
        {
            var member = _userRepository.GetMembersByUsername(username);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPut]
        public ActionResult<MemberDto> Put(ProfileDto profileDto)
        {
            var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }

            _userRepository.UpdateProfile(username, profileDto);
            if (_userRepository.SaveChanges()) return NoContent();
            return NotFound();
        }

        [HttpPost("{likeUsername}")]
        public ActionResult Like(string likeUsername){
            var sourceUsername = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(_userLikeRepository.LikeUser(sourceUsername, likeUsername)) return NoContent();
            return BadRequest();
        }
    }
}