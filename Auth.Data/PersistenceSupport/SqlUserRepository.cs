using Auth.Enitity;
using Massive;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq; 
using System.Text;
using System.Dynamic;

namespace Auth.Data.PersistenceSupport
{

    public class SqlUserRepository : IUserRepository
    {
        private readonly DynamicModel _membershipTable;
         
        public SqlUserRepository (string connectionString)
        {
            this._membershipTable = new DynamicModel(connectionString, "[dbo].[Membership]", "Id");
        } 

        public User Get(Guid id)
        { 
            string sqlQuery = "SELECT top (1)  * FROM Membership where Id = @0";
            IEnumerable<dynamic> data = this._membershipTable.Query(sqlQuery, id);
            return data.Select(x => new User
            {
                Id = x.Id,
                Username = x.Name,
                Password = x.Password
            }).FirstOrDefault<User>(); 
        }

        public User GetByUsername(string username)
        {
            string sqlQuery = "SELECT top (1) * FROM Membership where Name = @0";
            IEnumerable<dynamic> data = this._membershipTable.Query(sqlQuery, username);
            return data.Select(x => new User
            {
                Id = x.Id,
                Username = x.Name,
                Password = x.Password
            }).FirstOrDefault<User>(); 
        }


        public IEnumerable<User> GetAll()
        {
            string sqlQuery = "SELECT top  * FROM Membership ";
            IEnumerable<dynamic> data = this._membershipTable.Query(sqlQuery );
            return data.Select(x => new User
            {
                Id = x.Id,
                Username = x.Name,
                Password = x.Password
            });
        }

        public void Insert(User entity)
        {
            dynamic newUser = new ExpandoObject();

            newUser.Name = entity.Username;
            newUser.Password = entity.Password;
            newUser.PasswordSalt = "";
            this._membershipTable.Insert(newUser);

        }
        public void Update(User entity)
        {
            dynamic updatedUser = new ExpandoObject(); 
            updatedUser.Name = entity.Username;
            updatedUser.Password = entity.Password;

            this._membershipTable.Update(updatedUser, entity.Id);

        }


    }

}
