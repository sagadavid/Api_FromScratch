using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace FromScratchConsole2WebApi
{
    public class CustomModelBinderCountries : IModelBinder
    {
        //binding source : custom
        //field name: countries
        //modelmetadata:parameter, countries/type,string
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //my data input is a query and take it by bindingcontext
            //notice that httpcontext is iCollection
            var data = bindingContext.HttpContext.Request.Query;

            //bool, check if you get my countries query and outable as country
            //trygetvalue needs key and it will be named as countries
            //and countries is an icollection
            
            var result = data.TryGetValue("countries", out var country);
            
            //if check above is true,
            //then convert to string arrays by using split which returns,
            //delimited substrings in an array
            if (result)
            {
            var array = country.ToString().Split('|');

                bindingContext.Result=ModelBindingResult.Success(array);
            }

            return Task.CompletedTask;
            

        }
    }
}
