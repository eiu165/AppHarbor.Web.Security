using System;
using System.Collections.Generic;
using System.Linq;
using Auth.Enitity;
using Auth.Data.PersistenceSupport;

namespace Auth.Data.PersistenceSupport
{
	public class InMemoryUserRepository : IUserRepository
	{
		private static IDictionary<Type, IDictionary<Guid, object>> _dictionaries =
			new Dictionary<Type, IDictionary<Guid, object>>();

        public User Get (Guid id) 
		{
			IDictionary<Guid, object> dictionary;
            if (_dictionaries.TryGetValue(typeof(User), out dictionary))
			{
                return (User)dictionary[id];
			}
            return default(User);
		}

        public void Insert (User entity)  
		{
            var type = typeof(User);
			IDictionary<Guid, object> dictionary;
			if (!_dictionaries.TryGetValue(type, out dictionary))
			{
				dictionary = new Dictionary<Guid, object>();
				_dictionaries.Add(type, dictionary);
			} 
			dictionary[entity.Id] = entity;
		}

        public IEnumerable<User> GetAll()  
		{
            var type = typeof(User);
			if (_dictionaries.ContainsKey(type))
			{
                return _dictionaries[type].Values.OfType<User>().AsQueryable();
			}
            return Enumerable.Empty<User>().AsQueryable();
		}

        public User Get<User>(Guid id)
        {
            throw new NotImplementedException();
        }



        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
