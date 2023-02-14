using BlogZamin.EndPoint.BlazorShared.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogZamin.EndPoint.BlazorShared.Services
{
    public class ServiceBase
    {
        protected static async Task<ApiResult> FailedResult(ApiException ex)
        {
            var errors = await ex.GetContentAsAsync<string[]>();
            return ApiResult.Failed(errors.First());
        }

        protected static async Task<ApiResult<TData>> FailedResult<TData>(ApiException ex)
        {
            var errors = await ex.GetContentAsAsync<string[]>();
            return ApiResult.Failed<TData>(errors.First());
        }
    }
}
