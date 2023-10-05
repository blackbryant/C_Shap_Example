using B進階觀念.Dapper範例.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B進階觀念.Dapper範例
{
    public class DapperEx01
    {

        /// <summary>
        /// 查詢firstName
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public List<Person> GetListByFirstName(string firstName) 
        {
            List<Person>   list = new List<Person>();
            using (DbConnection db = new SqlConnection(DbHelper.GetConnectionString())) 
            {
                string sql = "SELECT * FROM [dbo].[PERSON] where LastName like @firstName";
                IEnumerable<Person> ie = db.Query<Person>(sql, new { firstName = "%"+firstName+ "%" });
                list = ie.ToList();
            }
            return list ;
        }


        /// <summary>
        /// 新增Person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int Insert(Person person)
        {
            int result = 0; 
            using (DbConnection db = new SqlConnection(DbHelper.GetConnectionString()))
            {
                string sql = @"INSERT INTO [dbo].[PERSON]([FirstName] ,[LastName] ,[EmailAddress] ,[CreateDate] ,[IpAddress])
                                        VALUES( @FirstName, @LastName, @EmailAddress, @CreateDate, @IpAddress)

                                    ";
               result =  db.Execute(sql, person);

            }
            return result;
        }


        /// <summary>
        /// 更新Person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int Update(Person person)
        {
            int result = 0;
            using (DbConnection db = new SqlConnection(DbHelper.GetConnectionString()))
            {
                string sql = @"UPDATE  [dbo].[PERSON] 
                                        SET  [FirstName]       =@FirstName
                                                 ,[LastName]       =  @LastName
                                                ,[EmailAddress] = @EmailAddress
                                                ,[CreateDate]      = @CreateDate
                                                ,[IpAddress]       =  @IpAddress
                                        WHERE  [Id] = @Id
                                    ";
                result = db.Execute(sql, person);

            }
            return result;
        }



        /// <summary>
        /// 更新Person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            int result = 0;
            using (DbConnection db = new SqlConnection(DbHelper.GetConnectionString()))
            {
                string sql = @"DELETE FROM [dbo].[PERSON]
                                        WHERE  [Id] = @Id
                                    ";
                result = db.Execute(sql, new { Id= id});

            }
            return result;
        }


        public static void Main(string[] args)
        {
            //查詢
            Console.WriteLine("============查詢===============");
            DapperEx01 ex01 = new DapperEx01();
            List<Person> list = ex01.GetListByFirstName("ski");
            foreach (Person person in list)
            {
                Console.WriteLine(person.FirstName);
            }

            //新增
            Console.WriteLine("============新增===============");
            Person person1 = new Person()
            {
                FirstName = "Test",
                LastName = "Lin",
                IpAddress = "127.0.0.1",
                CreateDate = DateTime.Now,
                EmailAddress = "Test@aaa.bb.cc"

            };
           
           int insert_count =   ex01.Insert(person1);
            if (insert_count > 0)
            {
                Console.WriteLine("新增成功");
            }
            else 
            {
                Console.WriteLine("新增失敗");
            }


            //更新
            Console.WriteLine("============更新===============");
            person1.Id = 1001;
            person1.EmailAddress = "LL@asdf.com.tw"; 
            ex01.Update(person1);
            //刪除
            Console.WriteLine("============刪除===============");
            ex01.Delete(1001);
        }



    }
}
