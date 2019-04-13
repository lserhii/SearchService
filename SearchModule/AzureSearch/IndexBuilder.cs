using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using SearchModule.AzureSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchModule.Infrastructure
{
    public class IndexBuilder
    {
        private ISearchServiceProvider _clientProvider;
        public IndexBuilder(ISearchServiceProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        public void UploadToIndex<T>(string indexName, IEnumerable<T> data) where T : class
        {
            try
            {
                var batch = UploadIndexBatch(data);
                _clientProvider.CreateSearchServiceClient()
                    .Indexes.GetClient(indexName)
                    .Documents.Index(batch);
            }
            catch (IndexBatchException e)
            {
                // Sometimes when your Search service is under load, indexing will fail for some of the documents in
                // the batch. Depending on your application, you can take compensating actions like delaying and
                // retrying. For this simple demo, we just log the failed document keys and continue.
            }
        }

        private IndexBatch<T> UploadIndexBatch<T>(IEnumerable<T> data) where T: class
        {
            var indexAtions = new List<IndexAction<T>>();
            foreach(var item in data)
            {
                indexAtions.Add(IndexAction.Upload(item)); 
            }

            return IndexBatch.New(indexAtions);   
        }


        //var actions =
        //        new IndexAction<BusinessUnit>[]
        //        {
        //            IndexAction.Upload(
        //                new BusinessUnit()
        //                {
        //                   BusinessUnitId = "1",
        //                    IsOnboardingLevel = true,
        //                    BusinessUnitCode = "ASEE88",
        //                    BusinessUnitName = "Global Root Bu",
        //                    BusinessUnitParents = new [] { "Global Root Bu" },
        //                    Users = new []{"Leo Lobster", "Sara Ams", "Brad Pitt", "Bobby Boo"}

        //                }),
        //            IndexAction.Upload(
        //                new BusinessUnit()
        //                {
        //                    BusinessUnitId = "2",
        //                    IsOnboardingLevel = true,
        //                    BusinessUnitCode = "ASRE98",
        //                    BusinessUnitName = "Managed",
        //                    BusinessUnitParents = new [] { "Global Root Bu", "Managed" },
        //                    Users = new []{"Jacky Chan", "Lara Craft", "Barry", "Daphne Cortes"}
        //                }),
        //        };
    }
}
