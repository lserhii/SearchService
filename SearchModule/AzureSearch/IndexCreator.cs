using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace SearchModule.AzureSearch
{
    public interface IIndexCreator<T>
    {
        void CreateIndex<T>(string indexName, IndexConfig settings);
    }

    public class IndexConfig
    {

    }

    public class IndexCreator
    {
        private ISearchServiceProvider _provider;
        public IndexCreator(ISearchServiceProvider provider)
        {
            _provider = provider;
        }

        public void CreateIndex<T>(string indexName, IndexConfig settings)
        {
            var client = _provider.CreateSearchServiceClient();

            var buIndexDefinition = new Index()
            {
                Name = indexName,
                Fields = FieldBuilder.BuildForType<T>()  
            };

            DeleteBUIndexIfExists(client, indexName);

            client.Indexes.Create(buIndexDefinition);
        }

        private static void DeleteBUIndexIfExists(SearchServiceClient serviceClient, string indexName)
        {
            if (serviceClient.Indexes.Exists(indexName))
            {
                serviceClient.Indexes.Delete(indexName);
            }
        }
    }
}

//private const string BusinessUnitIndexName = "business-units";
//private static void DeleteBUIndexIfExists(SearchServiceClient serviceClient)
//{
//    if (serviceClient.Indexes.Exists(BusinessUnitIndexName))
//    {
//        serviceClient.Indexes.Delete(BusinessUnitIndexName);
//    }
//}
//static void Main(string[] args)
//{
//    var searchClient = CreateSearchServiceClient();

            //DeleteBUIndexIfExists(searchClient);

//var buIndexDefinition = new Index()
//{
//    Name = BusinessUnitIndexName,
//    Fields = FieldBuilder.BuildForType<BusinessUnit>()
//};

//searchClient.Indexes.Create(buIndexDefinition);
