using Auth.Data.PersistenceSupport;
using Auth.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Business
{
    public class AccountService : IAccountService
    {
        private IUserRepository _repository;
        public AccountService(IUserRepository  repository)
        {
            _repository = repository;
        }

        public User Get (Guid id) 
        {
            return _repository.Get(id);
        }

        public IEnumerable<User> GetAll()  
        {
            return _repository.GetAll( );
        }

        public void SaveOrUpdate(User entity)  
        {
            _repository.SaveOrUpdate(entity);
        }
    }
}
