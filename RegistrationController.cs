using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Userdetailsapp.Models;

namespace Userdetailsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Registration")]
        public string Registration(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Userdetails").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO registration(UserName,Password,Email,IsActive) values('"+registration.UserName+ "','" + registration.Password + "','" + registration.Email + "','" + registration.IsActive + "' )", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i > 0)
            {
                return "Data inserted";
            }
            else
            {
                return "Error";
            }
        }
    }
}
