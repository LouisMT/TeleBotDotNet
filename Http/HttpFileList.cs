using System;
using System.Collections.Generic;

namespace TeleBotDotNet.Http
{
    internal class HttpFileList : List<HttpFile>
    {
        internal void Add(string key, string extension, byte[] file, string contentType)
        {
            Add(new HttpFile
            {
                Key = key,
                File = file,
                FileName = $"{Guid.NewGuid()}.{extension}",
                ContentType = contentType
            });
        }
    }
}