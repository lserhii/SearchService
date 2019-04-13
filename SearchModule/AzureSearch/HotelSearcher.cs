//using System;
//using System.Collections.Generic;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using SearchModule.AzureSearch;
//using Microsoft.Spatial;
//using Newtonsoft.Json;

namespace SearchService.Infrastructure
{
    public class HotelSearcher
    {
        private ISearchServiceProvider _clientProvider;
        public object[] Search()
        {
            return null;
        }

        //SearchParameters parameters;
        //DocumentSearchResult<BusinessUnit> results;
        //var indexClient = searchClient.Indexes.GetClient(BusinessUnitIndexName);




        //parameters =
        //        new SearchParameters()
        //{
        //    Select = new[] { "businessUnitName", "businessUnitId" },
        //            QueryType = QueryType.Full,
        //            SearchFields = new List<string>() { "businessUnitParents" }
        //        };

        //results = indexClient.Documents.Search<BusinessUnit>("Mapaned~", parameters);

        //    WriteDocuments(results);
    }
}

/*
using System;
using System.Collections.Generic;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace AzureSearchApp
{
    class Program
    {
        private const string BusinessUnitIndexName = "business-units";
        private static void DeleteBUIndexIfExists(SearchServiceClient serviceClient)
        {
            if (serviceClient.Indexes.Exists(BusinessUnitIndexName))
            {
                serviceClient.Indexes.Delete(BusinessUnitIndexName);
            }
        }
        static void Main(string[] args)
        {
            var searchClient = CreateSearchServiceClient();

            //DeleteBUIndexIfExists(searchClient);

            //var buIndexDefinition = new Index()
            //{
            //    Name = BusinessUnitIndexName,
            //    Fields = FieldBuilder.BuildForType<BusinessUnit>()
            //};

            //searchClient.Indexes.Create(buIndexDefinition);

            //try
            //{
            //    var batch = CreateIndexBatch();
            //    searchClient.Indexes.GetClient(BusinessUnitIndexName).Documents.Index(batch);
            //}
            //catch (IndexBatchException e)
            //{
            //    // Sometimes when your Search service is under load, indexing will fail for some of the documents in
            //    // the batch. Depending on your application, you can take compensating actions like delaying and
            //    // retrying. For this simple demo, we just log the failed document keys and continue.
               
            //}

            SearchParameters parameters;
            DocumentSearchResult<BusinessUnit> results;
            var indexClient = searchClient.Indexes.GetClient(BusinessUnitIndexName);




            parameters =
                new SearchParameters()
                {
                    Select = new[] { "businessUnitName", "businessUnitId" },
                    QueryType = QueryType.Full,
                    SearchFields = new List<string>() { "businessUnitParents" }
                };

            results = indexClient.Documents.Search<BusinessUnit>("Mapaned~", parameters);

            WriteDocuments(results);



            parameters =
                new SearchParameters()
                {
                    Select = new[] { "businessUnitName", "businessUnitId" },
                    QueryType = QueryType.Full,
                    SearchFields = new List<string>() { "users" }
                };

            results = indexClient.Documents.Search<BusinessUnit>("Sara Cms~", parameters);

            WriteDocuments(results);
        }

        private static void WriteDocuments(DocumentSearchResult<BusinessUnit> searchResults)
        {
            foreach (SearchResult<BusinessUnit> result in searchResults.Results)
            {
                Console.WriteLine(result.Document.BusinessUnitName, result.Document.BusinessUnitId);
            }

            Console.WriteLine("--------------------------------------------------------");
        }

       

        [SerializePropertyNamesAsCamelCase]
        public class BusinessUnit
        {
            [System.ComponentModel.DataAnnotations.Key]
            [IsFilterable]
            public string BusinessUnitId { get; set; }

            [IsFilterable]
            public string BusinessUnitCode { get; set; }

            [IsSearchable]
            public string BusinessUnitName { get; set; }

            [IsFilterable]
            public bool IsOnboardingLevel { get; set; }

            [IsSearchable, IsFilterable] //can not be IsSortable -- 
            public string[] BusinessUnitParents { get; set; }

            [IsSearchable, IsFilterable]
            public string[] Users { get; set; } //can not be IsSortable -- 
        }

        //[SerializePropertyNamesAsCamelCase]
        //public partial class Hotel
        //{
        //    [System.ComponentModel.DataAnnotations.Key]
        //    [IsFilterable]
        //    public string HotelId { get; set; }

        //    [IsFilterable, IsSortable, IsFacetable]
        //    public double? BaseRate { get; set; }

        //    [IsSearchable]
        //    public string Description { get; set; }

        //    [IsSearchable]
        //    [Analyzer(AnalyzerName.AsString.FrLucene)]
        //    [JsonProperty("description_fr")]
        //    public string DescriptionFr { get; set; }

        //    [IsSearchable, IsFilterable, IsSortable]
        //    public string HotelName { get; set; }

        //    [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        //    public string Category { get; set; }

        //    [IsSearchable, IsFilterable, IsFacetable]
        //    public string[] Tags { get; set; }

        //    [IsFilterable, IsFacetable]
        //    public bool? ParkingIncluded { get; set; }

        //    [IsFilterable, IsFacetable]
        //    public bool? SmokingAllowed { get; set; }

        //    [IsFilterable, IsSortable, IsFacetable]
        //    public DateTimeOffset? LastRenovationDate { get; set; }

        //    [IsFilterable, IsSortable, IsFacetable]
        //    public int? Rating { get; set; }

        //    [IsFilterable, IsSortable]
        //    public GeographyPoint Location { get; set; }
        //}
    }
}
 */
