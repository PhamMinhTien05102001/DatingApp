using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
    public class ProfileDto
    {
        public DateTime DateOfBirth { get; set;}

        [StringLength(32)]
        public string KnownAs { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [StringLength(256)]
        public string Introduction { get; set; }

        [StringLength(32)]
        public string City { get; set;}

        [StringLength(512)]
        public string Avatar { get; set;}

    }
}