﻿using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Hid.CheckPoint.Shared;
using Hid.Identity.Business;
using Hid.Identity.Client.Services;
using Hid.Identity.Common;
using Hid.Identity.Common.Consts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hid.Identity.Client;

public static class DependencyInjection
{
    private const string DefaultSection = "JwtOptions";

    public static IServiceCollection AddImbeddedIdentityClient(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName = DefaultSection)
    {
        services.Configure<JwtOptions>(options =>
        {
            configuration.GetSection(sectionName).Bind(options);
        });
        
        services
            .AddScoped<IIdentityService, IdentityService>()
            .AddIdentityBusiness(configuration);

        return services;
    }

    public static IServiceCollection AddHidAuthorization(
        this IServiceCollection services)
    {
        return services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = AuthorizationSchemes.General;
                options.DefaultAuthenticateScheme = AuthorizationSchemes.General;
                options.DefaultChallengeScheme = AuthorizationSchemes.General;
            })
            .AddJwtBearer(AuthorizationSchemes.General, DefaultTokenConfigureAction).Services
            .AddAuthorization(config =>
            {
                config.AddPolicy(AuthorizationSchemes.General,
                    builder =>
                    {
                        builder.AuthenticationSchemes = new List<string> { AuthorizationSchemes.General };
                        builder.AddRequirements(new TokenRequirement());
                    });
            })
            .AddScoped<IAuthorizationHandler, TokenRequirementHandler>();
    }
    
    private static void DefaultTokenConfigureAction(JwtBearerOptions cfg)
    {
        cfg.RequireHttpsMetadata = false;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = false,
            RequireSignedTokens = true,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.FromSeconds(5),
            SignatureValidator = (token, _) =>
                new JwtSecurityToken(token)
        };
        
        cfg.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                if (!string.IsNullOrWhiteSpace(context.Token) || context.HttpContext.User.Identities.Any())
                    return Task.CompletedTask;

                var token = context.Request.Query["access_token"].ToString().Split(' ');
                context.Token = token.Length <= 1 ? token[0] : token[1];
                return Task.CompletedTask; 
            },
            OnAuthenticationFailed = async context =>
            {
                context.Response.StatusCode = 401;
                context.Response.Headers["Content-Type"] = "application/json";
                await context.Response.Body.WriteAsync(
                    JsonSerializer.SerializeToUtf8Bytes(Result.UnAuthorized("Not authorized")));
            },
            OnForbidden = async context =>
            {
                await context.Response.Body.WriteAsync(
                    JsonSerializer.SerializeToUtf8Bytes(
                        Result.Forbidden("No access to this resource")));
            },
            OnChallenge = context =>
            {
                context.HandleResponse();
                return Task.CompletedTask;
            }
        };
    }
    
    public static IServiceCollection AddCurrentUserService(this IServiceCollection services)
    {
        return services.AddScoped<ICurrentUserService, CurrentUserService>();
    }
}
