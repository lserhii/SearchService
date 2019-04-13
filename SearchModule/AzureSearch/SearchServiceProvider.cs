using Microsoft.Azure.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchModule.AzureSearch
{
    public interface ISearchServiceProvider
    {
        SearchServiceClient CreateSearchServiceClient();
    }

    public class SearchServiceProvider : ISearchServiceProvider
    {
        public SearchServiceProvider()
        {

        }

        public SearchServiceClient CreateSearchServiceClient()
        {
            string searchServiceName = "";//configuration["SearchServiceName"];
            string adminApiKey = "";//configuration["SearchServiceAdminApiKey"];

            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
            return serviceClient;
        }
    }
}
