using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string eMail { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public byte[]  hashedPassword { get; set; }
        public byte[] hashSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public int GetAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            return age;
        }
    }
}
