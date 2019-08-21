using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace auth
{
    public class AuthAttribute : AuthorizeAttribute, IFilterMetadata
    {
        public AuthAttribute() { }

        public AuthAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; private set; }
    }
}
