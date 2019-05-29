using System;
using System.Collections.Generic;
using System.Text;

namespace Vote.Common.Models
{
   

    public class NewUserRequest
    {
        
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

      
        public string Email { get; set; }

        
        public string Ocupattion { get; set; }

      
        public string Stratum { get; set; }

      
        public string Gender { get; set; }

       
        public DateTime Birthdate { get; set; }

       
        public string Phone { get; set; }

       
        public string Password { get; set; }

       
        public int CityId { get; set; }
    }

}
