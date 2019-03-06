﻿using System;
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
        [Route("listaus")] // ei case sensitiivinen
        public List<Customers> Listaus()
        {
            NorthwindContext context = new NorthwindContext();
            List<Customers> allCustomers = context.Customers.ToList();

            return allCustomers;
        }

        [Route("yksittäinen/{asiakasId}")] // ei case sensitiivinen
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
    }
}