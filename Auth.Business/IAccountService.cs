using Auth.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Business
{


    public interface IAccountService
    { 

        T Get<T>(Guid id) where T : Entity;
        IQueryable<T> GetAll<T>() where T : Entity;
        void SaveOrUpdate<T>(T entity) where T : Entity;

    }


}
