//using System;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using SearchModule.AzureSearch;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SearchService.Infrastructure
{
    public class HotelSearcher
    {
        const string BusinessUnitIndexName = "HotelIndex";
        private ISearchServiceProvider _clientProvider;
        public IEnumerable<Hotel> Search(string searchTerm)
        {
            var srv = _clientProvider.CreateSearchServiceClient();
            var searchApi = srv.Indexes.GetClient(BusinessUnitIndexName);

            var selector = new PropertySelector<Hotel>(
                x => x.HotelName,
                x => x.Tags,
                x => x.Location);

            var searchFields = new PropertySelector<Hotel>(x => x.HotelName);

            var parameters = new SearchParameters
            {
                Select = selector.SelectedProperties,
                QueryType = QueryType.Full,
                SearchFields = searchFields.SelectedProperties
            };

            var results = searchApi.Documents.Search<Hotel>($"{searchTerm}~", parameters);

            return results.Results.Select(r => r.Document);
        }
    }
}
