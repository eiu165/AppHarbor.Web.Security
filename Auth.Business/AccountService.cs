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
        private IRepository _repository;
        public AccountService(IRepository  repository)
        {
            _repository = repository;
        }

        public T Get<T>(Guid id) where T : Entity
        {
            return _repository.Get<T>(id);
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            return _repository.GetAll<T>( );
        }

        public void SaveOrUpdate<T>(T entity) where T : Entity
        {
            _repository.SaveOrUpdate<T>(entity);
        }
    }
}
