using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using es;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace api.command_handler.Services 
{
    public interface IEventStreamApi 
    {
        [Post("append")]
        Task<StatusCodeResult> Append(EventPayload evnt);

        [Get("query")]
        Task<IEnumerable<EventPayload>> Query(Guid id) ;
    }
}