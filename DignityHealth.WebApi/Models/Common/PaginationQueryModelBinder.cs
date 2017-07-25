using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace DignityHealth.WebApi.Models.Common
{
    /// <summary>
    /// Pagination Query Model Binder
    /// </summary>
    public class PaginationQueryModelBinder : SearchQueryModelBinder, IModelBinder
    {
        #region Public Methods

        /// <summary>
        /// Builds the PaginationQueryModel.
        /// </summary>
        /// <param name="actionContext">HttpActionContext Object</param>
        /// <param name="bindingContext">ModelBindingContext Object</param>
        /// <returns>Boolean</returns>
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            ErrorBuilder = new StringBuilder();

            if (bindingContext.ModelType != typeof(PaginationQueryModel))
                return false;

            var model = (PaginationQueryModel)bindingContext.Model ?? new PaginationQueryModel();
            var hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);
            var searchPrefix = (hasPrefix) ? string.Format("{0}.", bindingContext.ModelName) : string.Empty;

            //Offset           
            model.Offset = SetOffset(GetValue(bindingContext, searchPrefix, DWResources.DWRes.Offset));

            //Limit       
            model.Limit = SetLimit(GetValue(bindingContext, searchPrefix, DWResources.DWRes.Limit));

            if (ErrorBuilder.Length > 0)
            {
                bindingContext.ModelState.AddModelError(string.Format(".{0}", ErrorBuilder).TrimEnd(','), string.Empty);
                return false;
            }

            bindingContext.Model = model;
            return true;
        }

        #endregion
    }
}