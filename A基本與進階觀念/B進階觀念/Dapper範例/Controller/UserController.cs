using B進階觀念.AutoMapper範例;
using B進階觀念.DAL;
using B進階觀念.Dapper範例.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;                                              
using System.Threading.Tasks;
using System.Xml.Linq;

namespace B進階觀念.Dapper範例.Controller
{

    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserDal userDal;

        public UserController() 
        {
            this.userDal = new UserDal();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Get() {
            return "AAAAAAAAAAAAAA"; 
        }



        [HttpGet("{userno}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<User> GetByUserno(string userno)
        {
            User user = null;

            System.Console.WriteLine("AAAAAAAAAAA   ");
            try
            {
                user =  userDal.GetUsersByUserno(userno); 
                if(user == null) 
                {
                    return NotFound();
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
            System.Console.WriteLine(user.UserName); 
            return user;
        }

    }
}
