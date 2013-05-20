using Auth.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Business
{ 
    public interface IAccountService
    { 
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
        void SaveOrUpdate (User entity)  ; 
    } 
}
