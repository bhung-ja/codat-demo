using Codat.Public.Client;
using CodatDemo.Models;
using RestSharp;
using System.Threading.Tasks;

namespace CodatDemo.Services
{
    public interface ICodatService
    {
        Task<IRestResponse> CreateInvoiceAsync(InvoiceModel invoice);
        Task<Company> CreateCompanyAsync(AddCompanyModel company);
        Task<PagedResponseModelOfCompany> GetCompanies();
    }
}