using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreRestApplication.Core.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace CoreRestApplication.Core
{ 
    public class CustomerModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(CustomerDto))
            {
                return null;
            }

            var subclasses = new[] { typeof(MrGreen), typeof(RedBet) };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new CustomerModelBinder(binders);
        }
    }

    public class CustomerModelBinder : IModelBinder
    {
        private Dictionary<Type, (ModelMetadata, IModelBinder)> bindersDictionary;
        private Dictionary<string, Func<CustomerDto>> Customers;

        public CustomerModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders)
        {
            bindersDictionary = binders;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(CustomerDto)) { }

            string bodyAsText = await new StreamReader(bindingContext.HttpContext.Request.Body).ReadToEndAsync();
            RegisterAvailableCustomerTypes(bodyAsText);
            
            string customerType = JsonConvert.DeserializeObject<CustomerDto>(bodyAsText).CustomerType;

            var newCustomer = Customers[customerType].Invoke();
            
            bindingContext.Result = ModelBindingResult.Success(newCustomer);
        }

        private void RegisterAvailableCustomerTypes(string bodyAsText)
        {
            Customers = new Dictionary<string, Func<CustomerDto>>
            {
                [nameof(RedBet)] = () => JsonConvert.DeserializeObject<RedBet>(bodyAsText),
                [nameof(MrGreen)] = () => JsonConvert.DeserializeObject<MrGreen>(bodyAsText)
            };
        }
    }
}
