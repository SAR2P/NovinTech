using Dapper;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _config;
        private readonly IConfiguration _connectionString;

        public UserRepository(DataContext config)
        {
            _config = config;
            
        }



        public async Task<IEnumerable<User>> GetUserAsync()
        {
            using (var connection = _config.createConnection())
            {
                string Query = "select * from user";
                var users = await connection.QueryAsync<User>(Query);
                return users;
            }
        }



        public async Task<User> GetUserByIdAsync(int id)
        {
            using (var connection = _config.createConnection())
            {
                string Query = "select Id,FullName,Address from user where Id =@id";
                var users = await connection.QueryFirstOrDefaultAsync<User>(Query, new {id});
                return users;
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            using (var connection = _config.createConnection())
            {
                string Query = @"insert into  user(FullName,Address) values(@FullName,@Address);";
                int CreateduserId = await connection.ExecuteScalarAsync<int>(Query, new { user.FullName, user.Address });
                user.Id = CreateduserId;
                return user;
            }
        }


        public async Task UpdateUserAsync(User user)
        {
            using (var connection = _config.createConnection())
            {
                string Query = @"update user set FullName= @FullName, Address=@Address where Id=@Id";
                 await connection.ExecuteAsync(Query,user);
              
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            using (var connection = _config.createConnection())
            {
                string Query = @"delete from user where Id=@id";
                await connection.ExecuteAsync(Query, new { id });

            }
        }
    }
}
