using System;
using System.Linq;
using Auth.Enitity;
using System.Collections.Generic;

namespace Auth.Data.PersistenceSupport
{
	public interface IUserRepository
    {
        User Get(Guid id);
        User GetByUsername(string username);
        IEnumerable<User> GetAll ();
        void Insert (User entity);
	}
}
