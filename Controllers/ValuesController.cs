using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bhanuapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            MySqlConnection connection = new MySqlConnection
            {
                ConnectionString = "server=localhost;user id=root;password=root;persistsecurityinfo=True;port=3306;database=sakila;SSL Mode=None"
            };
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM sakila.category;", connection);
 
            using (MySqlDataReader reader =  command.ExecuteReader())
            {
                System.Console.WriteLine("Category Id\t\tName\t\tLast Update");
                while (reader.Read())
                {
                string row = $"{reader["category_id"]}\t\t{reader["name"]}\t\t{reader["last_update"]}";
                System.Console.WriteLine(row);
                }
            }
 
            connection.Close();
 
            System.Console.ReadKey();
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            MySqlConnection connection = new MySqlConnection
            {
                ConnectionString = "server=localhost;user id=root;password=root;persistsecurityinfo=True;port=3306;database=sakila"
            };
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM sakila.category;", connection);
 
            using (MySqlDataReader reader =  command.ExecuteReader())
            {
                System.Console.WriteLine("Category Id\t\tName\t\tLast Update");
                while (reader.Read())
                {
                string row = $"{reader["category_id"]}\t\t{reader["name"]}\t\t{reader["last_update"]}";
                System.Console.WriteLine(row);
                }
            }
 
            connection.Close();
 
            System.Console.ReadKey(); 
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
