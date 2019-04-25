//using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SearchService.Infrastructure
{
    public class PropertySelector<T> where T: class
    {
        public PropertySelector(params Expression<Func<T, object>>[] expressions) =>
            SelectedProperties = NameReaderExtensions.GetMemberNames(expressions).Select(LowerCaseFirstLetter).ToList();    
        

        private string LowerCaseFirstLetter(string input) => 
            input.Substring(0, 1).ToLower() + (input.Length > 1 ? input.Substring(1) : "");

        public IList<string> SelectedProperties { get; }
    }
}
