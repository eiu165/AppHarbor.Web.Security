using System;
using System.Linq;
using Auth.Enitity;
using System.Collections.Generic;

namespace Auth.Data.PersistenceSupport
{
	public interface IUserRepository
	{
        User Get(Guid id) ;
        IEnumerable<User> GetAll ();
        void SaveOrUpdate (User entity);
	}
}
