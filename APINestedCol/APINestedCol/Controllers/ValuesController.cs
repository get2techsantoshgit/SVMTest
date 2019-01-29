using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APINestedCol.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace APINestedCol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            //List<Customer> obj = new List<Customer>()
            //{
            //    new Customer {id =1, address="adad-1",membership="asdad",name="sadad",phone="234234"},
            //    new Customer {id =1, address="adad-11",membership="asdad",name="sadad",phone="234234"},
            //    new Customer {id =2, address="adad-2",membership="asdad",name="sadad",phone="234234"},
            //    new Customer {id =3, address="adad -3",membership="asdad",name="sadad",phone="234234"}
            //};
            //return Ok(obj);
            SqlConnection con = new SqlConnection(@"Data source=SANTOSHOFFICIAL;Initial Catalog = EmployeeDB;Integrated Security = True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            List<Shop> Shop1 = con.Query<Shop>("Select * from shop").ToList();
            List<Account> Account1 = con.Query<Account>("Select * from Account").ToList();

            foreach (var sh in Shop1)
            {
                foreach (var acc in Account1)
                {
                    if (sh.id == acc.id)
                    {
                        sh.accounts.Add(acc);
                    }
                }

            }

            return Ok(Shop1);

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
