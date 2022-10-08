using BluePrint.CrossCuttingConcern.Authorization.Extensions;
using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
using BluePrint.CrossCuttingConcern.Utilities.Messages;
using BluePrint.DependencyInjection.Container.Providers;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace BluePrint.CrossCuttingConcern.Authorization.Aspects
{
    public class AuthorizationAspect : MethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationAspect(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceLocator.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(AspectMessages.AuthorizationDenied);
        }
    }
}
