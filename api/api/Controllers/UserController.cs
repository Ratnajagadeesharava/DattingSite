using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<User> GetUsers()
        {
            return this._db.users.ToList();
        }
       [HttpGet]
       public User GetUser(int Id)
        {
            return this._db.users.Find(Id);
        }
    }
}
