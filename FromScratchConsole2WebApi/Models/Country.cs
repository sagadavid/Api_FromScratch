using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Models
{
    //bind model to binder
    [ModelBinder(typeof(CustomModelBinderCountryDetail))]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Population { get; set; }

        public int Area { get; set; }
    }
}
