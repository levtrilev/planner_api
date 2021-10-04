using System.Text.Json.Serialization;
using System;

namespace PlannerAPI2.Models
{
    
    public class User : BaseEntity
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    public User(string name)
    //    {
    //        Name = name;
    //    }

    //    public string Role { get; set; }
    //    public DateTime RegisterDate { get; set; }
    //    public bool Active { get; set; }
    //}

