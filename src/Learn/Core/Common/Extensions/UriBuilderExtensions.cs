using System;
using System.IO;

namespace Learn.Core.Common.Extensions
{
    internal static class UriBuilderExtensions
    {
        internal static void AppendToPath(this UriBuilder builder, string pathToAdd)
        {
            var completePath = Path.Combine(builder.Path, pathToAdd);
            builder.Path = completePath;
        } 
    }
}
