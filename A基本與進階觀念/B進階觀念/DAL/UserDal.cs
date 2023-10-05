using B進階觀念.Dapper範例.DBConnction;
using B進階觀念.Dapper範例.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.DAL
{
    public  class UserDal
    {
         DapperHelper _db = new DapperHelper();

        public User GetUserByLogin(string userno, string password) 
        {
            string sql = @"SELECT  * FROM  [dbo].[User] 
                                    WHERE UserNo =@userno
                                    ";
           var user = _db.QueryFirst<User>(sql, new { userno, password });

            return user;
        }

        public User GetUsersByUserno(string userno)
        {
            string sql = @"SELECT  * FROM  [dbo].[User] 
                                    WHERE UserNo =@userno
                                    ";
            var user = _db.Query<User>(sql, new { userno });


            return user.ToList().FirstOrDefault();
        }

    }
}
