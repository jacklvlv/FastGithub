﻿using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

namespace FastGithub.PacketIntercept
{
    /// <summary>
    /// tcp拦截后台服务
    /// </summary>
    [SupportedOSPlatform("windows")]
    sealed class TcpInterceptHostedService : BackgroundService
    {
        private readonly IEnumerable<ITcpInterceptor> tcpInterceptors;

        /// <summary>
        /// tcp拦截后台服务
        /// </summary> 
        /// <param name="tcpInterceptors"></param> 
        public TcpInterceptHostedService(IEnumerable<ITcpInterceptor> tcpInterceptors)
        {
            this.tcpInterceptors = tcpInterceptors;
        }

        /// <summary>
        /// https后台
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var tasks = this.tcpInterceptors.Select(item => this.InterceptAsync(item, stoppingToken));
            return Task.WhenAll(tasks);
        }

        /// <summary>
        /// 拦截
        /// </summary>
        /// <param name="interceptor"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task InterceptAsync(ITcpInterceptor interceptor, CancellationToken cancellationToken)
        {
            await Task.Yield();
            interceptor.Intercept(cancellationToken);
        }
    }
}
