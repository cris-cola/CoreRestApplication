﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreRestApplication.Core.Data.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace CoreRestApplication.Core
{
    public class CustomerModelBinder : IModelBinder
    {
        private Dictionary<string, Func<CustomerDto>> _customers = new Dictionary<string, Func<CustomerDto>>();
        
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(CustomerDto)) { }

            string bodyAsText = await new StreamReader(bindingContext.HttpContext.Request.Body).ReadToEndAsync();
            RegisterAvailableCustomerTypes(bodyAsText);
            
            var customerType = JsonConvert.DeserializeObject<CustomerDto>(bodyAsText).CustomerType;
            var newCustomer = _customers[customerType].Invoke();
            
            bindingContext.Result = ModelBindingResult.Success(newCustomer);
        }

        #region Privates

        private void RegisterAvailableCustomerTypes(string bodyAsText)
        {
            _customers = new Dictionary<string, Func<CustomerDto>>
            {
                [nameof(MrBet)] = () => Deserialize<MrBet>(bodyAsText),
                [nameof(GreenHat)] = () => Deserialize<GreenHat>(bodyAsText)
            };
        }

        private static T Deserialize<T>(string bodyAsText)
        {
            return JsonConvert.DeserializeObject<T>(bodyAsText);
        }

        #endregion
    }
}