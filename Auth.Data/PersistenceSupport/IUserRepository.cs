using System;
using System.Linq;
using Auth.Enitity;
using System.Collections.Generic;

namespace Auth.Data.PersistenceSupport
{
	public interface IUserRepository
    { 
        User GetByUsername(string username);
        IEnumerable<User> GetAll ();
        void Insert (User entity);
	}
}
