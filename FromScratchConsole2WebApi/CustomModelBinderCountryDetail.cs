using FromScratchConsole2WebApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace FromScratchConsole2WebApi
{
    public class CustomModelBinderCountryDetail : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //incoming data for model is id, so the modelname of model is id
            //ModelName is used as a key for looking up values in IvalueProvider during model binding
            var modelName = bindingContext.ModelName;


            // ValueProviderResult remarks: 
            //     can represent a single submitted value or multiple submitted values.
            //     Use ....ValueProviderResult.FirstValue to consume only a single value..
            //     Treat ...ValueProviderResult as an System.Collections.Generic.IEnumerable to consume all values
            // GetValue returns value object for provided key, if available
            var value = bindingContext.ValueProvider.GetValue(modelName);
            var result = value.FirstValue; //result is string
                                           //all the process up to here is only
                                           //to catch a clue/name which exists in the actual data and will correspond upcoming binding


            //string to int 
            if (!int.TryParse(result, out var value2bind)) 
            { return Task.CompletedTask; }
            //once we get value2bind, we can make database calls by this value2bind

            //since we dont have database, we hardcode data here
            //(we could initialize at the model as well)
            //to assign value2bind to data id
            var country2call = new Country()
            {
                Id = value2bind,
                Name = "Norge",
                Area = 372000,
                Population = 4900
            };

            //finally, real binding here, model to actual data
            bindingContext.Result = ModelBindingResult.Success(country2call);

            return Task.CompletedTask;
        }
    }
}
