using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreRestApplication.Core.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace CoreRestApplication.Core
{

    public class ModelBinderProvider : IModelBinderProvider
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

            return new ModelBinder(binders);
        }
    }

    public class ModelBinder : IModelBinder
    {
        private Dictionary<string, Func<CustomerDto>> Customers;
        private Dictionary<Type, (ModelMetadata, IModelBinder)> _binders;

        public ModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders)
        {
            this._binders = binders;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(CustomerDto)) { }

            string bodyAsText = await new StreamReader(bindingContext.HttpContext.Request.Body).ReadToEndAsync(); 
            var customerType = JsonConvert.DeserializeObject<CustomerDto>(bodyAsText).CustomerType;
            
            var actualType = TypeFrom(customerType);
            if (actualType == null)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            var (modelMetadata, modelBinder) = _binders[actualType];
            var newBindingContext = DefaultModelBindingContext.CreateBindingContext(
                bindingContext.ActionContext,
                bindingContext.ValueProvider,
                modelMetadata,
                bindingInfo: null,
                bindingContext.ModelName);
            
            await modelBinder.BindModelAsync(newBindingContext); //check
            
            bindingContext.Result = newBindingContext.Result;
        }


        #region Privates
        
        private static Type? TypeFrom(string name)
        {
            return name switch
            {
                nameof(RedBet) => typeof(RedBet),
                nameof(MrGreen) => typeof(MrGreen),
                _ => null
            };
        }

        #endregion
    }

}
