using Auth.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Business
{ 
    public interface IAccountService
    { 
        User Get(Guid id)  ;
        IEnumerable<User> GetAll();
        void SaveOrUpdate (User entity)  ; 
    } 
}
