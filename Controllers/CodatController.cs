using Codat.Public.Client;
using CodatDemo.Models;
using CodatDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodatDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodatController : ControllerBase
    {
        private readonly ICodatService _codatClient;

        public CodatController(ICodatService codatClient)
        {
            this._codatClient = codatClient;
        }

        [HttpPost]
        [Route("invoices")]
        public async Task<IActionResult> InvoicesAsync([FromBody] InvoiceModel invoice)
        {
            var response = await _codatClient.CreateInvoiceAsync(invoice);
            return Ok(response);
        }

        [HttpPost]
        [Route("companies")]
        public async Task<IActionResult> Companies([FromBody] AddCompanyModel model)
        {
            var response = await _codatClient.CreateCompanyAsync(model);
            return Ok(response);
        }

        [HttpGet]
        [Route("companies")]
        public async Task<IActionResult> Companies()
        {
            var response = await _codatClient.GetCompanies();
            return Ok(response);
        }
    }
}
