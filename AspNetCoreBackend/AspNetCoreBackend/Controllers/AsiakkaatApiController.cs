using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBackend.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBackend.Controllers
{
   // [Route("api/[controller]")]
    [Route("api/asiakkaat")]
    [ApiController]
    public class AsiakkaatApiController : ControllerBase
    {
      //  [Route("listaus")] // ei case sensitiivinen
        [HttpGet]   // hyväksytään vain GET
        [Route("")] // => <web-osoite>/api/asiakkaat
        public List<Customers> Listaus()
        {
            NorthwindContext context = new NorthwindContext();
            List<Customers> allCustomers = context.Customers.ToList();

            return allCustomers;
        }

        // aaltosuluisa olevasta asiakasId:stä tulee parametri
        [HttpGet]
        [Route("{asiakasId}")] // => <web-osoite>/api/asiakkaat/{asiakasId}
        public Customers Yksittäinen(string asiakasId)
        {
            NorthwindContext context = new NorthwindContext();
            Customers asiakas = context.Customers.Find(asiakasId);

            //LINQ
            //Customers asiakas2 = (from c in context.Customers
            //                      where c.CustomerId == asiakasId
            //                      select c).FirstOrDefault();

            return asiakas;
        }

        [HttpPost]
        [Route("")] // => <web-osoite>/api/asiakkaat
        public bool Luonti([FromBody] Customers uusi)
        {
            NorthwindContext context = new NorthwindContext();
            context.Customers.Add(uusi);
            context.SaveChanges();  // muutokset tallennetaan

            return true;
        }

        [HttpPut]
        [Route("{asiakasId}")]
        public Customers Muokkaus(string asiakasId, [FromBody] Customers muutokset)
        {
            NorthwindContext context = new NorthwindContext();
            Customers asiakas = context.Customers.Find(asiakasId);

            //löytyykö asiakas annetulla id:llä?
            if(asiakas == null)
            {
                return null;
            }

            //muokkaus
            asiakas.CompanyName = muutokset.CompanyName;
            asiakas.ContactName = muutokset.ContactName;
            asiakas.ContactTitle = muutokset.ContactTitle;
            asiakas.City = muutokset.City;
            asiakas.Country = muutokset.Country;
            asiakas.Phone = muutokset.Phone;
            asiakas.Fax = muutokset.Fax;
            asiakas.Address = muutokset.Address;
            asiakas.Region = muutokset.Region;
            asiakas.PostalCode = muutokset.PostalCode;

            context.SaveChanges();
            return asiakas;
        }

        [HttpDelete]
        [Route("{asiakasId}")]
        public bool Poisto(string asiakasId)
        {
            NorthwindContext context = new NorthwindContext();
            Customers asiakas = context.Customers.Find(asiakasId);

            if(asiakas == null)
            {
                return false;
            }

            context.Customers.Remove(asiakas);
            context.SaveChanges();

            return true;
        }
    }
}