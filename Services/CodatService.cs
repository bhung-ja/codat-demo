using Codat.Public.Client;
using CodatDemo.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodatDemo.Services
{
    public class CodatService : ICodatService
    {
        private readonly CodatClient _codatClient;

        public CodatService(IHttpClientFactory httpClientFactory)
        {
            _codatClient = new CodatClient(new CodatClientSettings("SV5XlNbCQODqdmOvd9ycen1uB0zSOR6Y8lQlQBYg", CodatEnvironment.Production), httpClientFactory.CreateClient());
        }

        public async Task<IRestResponse> CreateInvoiceAsync(InvoiceModel model)
        {
            var companyId = Guid.Parse("c42ad7b7-9050-4a6e-9942-00953028de5f");
            var connectionId = Guid.Parse("459e8479-7674-419c-8b64-1713cbd3a6f5");

            var invoiceUrl = $"https://api.codat.io/companies/{companyId}/connections/{connectionId}/push/invoices";
            var client = new RestClient(invoiceUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic U1Y1WGxOYkNRT0RxZG1PdmQ5eWNlbjF1QjB6U09SNlk4bFFsUUJZZw==");

            var invoice = new Invoice
            {
                Id = model.Id,
                DueDate = model.DueDate,
                Currency = model.Currency,
                CustomerRef = new CustomerRef { Id = model.CustomerRefId },
                Status = InvoiceStatus.Submitted,
                LineItems = new List<InvoiceLineItem>()
                {
                    new InvoiceLineItem
                    {
                        UnitAmount = model.UnitAmount,
                        Quantity = model.Quantity,
                        TotalAmount = model.UnitAmount*model.Quantity,
                        Description = model.Description,
                        TaxRateRef = new TaxRateRef { Id = "NON" }
                    }
                }
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(invoice), ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<Company> CreateCompanyAsync(AddCompanyModel company)
        {
            var data = await _codatClient.Companies.AddAsync(company);
            return data;
        }

        public async Task<PagedResponseModelOfCompany> GetCompanies()
        {
            var data = await _codatClient.Companies.ListPagedAsync(1, 100, "", "");
            return data;
        }
    }
}
