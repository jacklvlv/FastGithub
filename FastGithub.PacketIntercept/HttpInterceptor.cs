﻿using FastGithub.Configuration;
using Microsoft.Extensions.Logging;
using System.Runtime.Versioning;

namespace FastGithub.PacketIntercept
{
    /// <summary>
    /// http拦截器
    /// </summary>   
    [SupportedOSPlatform("windows")]
    sealed class HttpInterceptor : TcpInterceptor
    {
        /// <summary>
        /// http拦截器
        /// </summary>
        /// <param name="logger"></param>
        public HttpInterceptor(ILogger<HttpInterceptor> logger)
            : base(80, ReverseProxyPort.Http, logger)
        {
        }
    }
}
