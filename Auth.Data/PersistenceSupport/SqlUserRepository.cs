using Auth.Enitity;
using Massive;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq; 
using System.Text;

namespace Auth.Data.PersistenceSupport
{
    /*
    public class SqlUserRepository : IUserRepository
    {
        private readonly DynamicModel _membershipTable;

        public SqlUserRepository (string connectionString)
        {
            this._membershipTable = new DynamicModel(connectionString, "[dbo].[Membership]", "Id");
        }


        public T Get<T>(Guid id) where T : Entity
        {
            throw new NotImplementedException();
            string sqlQuery = "SELECT top 1 * FROM Membership where Id = @0";
            IEnumerable<dynamic> data = this._membershipTable.Query(sqlQuery, id);
            return data.Select(x => new User
                    {
                        Id = x.Id,
                        Username = x.Name,
                        Password = x.Password
                    }).FirstOrDefault<T>(); 
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
    */
}
