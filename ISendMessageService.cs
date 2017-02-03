using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EastFive.Api.Services
{
    public interface ISendMessageService
    {
        Task<TResult> SendEmailMessageAsync<TResult>(
            string toAddress, string toName,
            string fromAddress, string fromName,
            string templateName,
            IDictionary<string, string> substitutionsSingle,
            IDictionary<string, string[]> substitutionsMultiple,
            Func<string, TResult> onSuccess,
            Func<TResult> onServiceUnavailable,
            Func<string, TResult> onFailed);
    }
}