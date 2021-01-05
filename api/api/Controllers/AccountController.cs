using api.Data;
using api.DTO;
using api.Models;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenService _tokenService;

        //private readonly ITokenService _tokenService;

        public AccountController(ApplicationDbContext db,ITokenService tokenService)
        {
            _tokenService = tokenService;
            _db = db;
            //this.tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto userDto)
        {
            using var hmac = new HMACSHA512();
            var user = new User()
            {
                userName = userDto.userName,
                firstName = userDto.firstName,
                lastName = userDto.lastName,
                eMail = userDto.eMail,
                city = userDto.city,
                State = userDto.state,
                hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.password)),
                hashSalt = hmac.Key
            };
            await _db.users.AddAsync(user);
            _db.SaveChanges();
            return  user;
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginDtoResult>> Login(LoginDto loginDto)
        {
            User user = await _db.users.SingleOrDefaultAsync(x => x.userName == loginDto.userName);
            if (user == null) return Unauthorized("Invalid username");
            using var hmac = new HMACSHA512(user.hashSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));
            int l = computedHash.Length;
            for(int i = 0; i < l; i++)
            {
                if (computedHash[i] != user.hashedPassword[i])
                    return Unauthorized("Invalid Password");
            }
            return new LoginDtoResult
            {
                userName = loginDto.userName,
                token = _tokenService.CreateJWTToken(user)
            };
        }
    }
}
