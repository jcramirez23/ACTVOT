

namespace ACTVOT.common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;



    public class ChangePasswordRequest
    {
        
        public string OldPassword { get; set; }

        
        public string NewPassword { get; set; }

        
        public string Email { get; set; }
    }

}
