﻿using Authentication.BusinessLayer.Exceptions;
using Authentication.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Authentication.Api.Middlewares
{
    public class ExceptionsCathingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionsCathingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ExceptionBase ex)
            {
                if (ex.Result is not null)
                    await HandleCustomExceptionAsync(context, ex);
                else
                {
                    ErrorModel model = new ErrorModel()
                    {
                        Code = ex.Code,
                        Message = ex.Message
                    };
                    await HandleAsync(context, (int)ex.ExceptionStatusCode, model);
                }
            }
            catch (Exception ex)
            {

                ErrorModel model = new ErrorModel()
                {
                    Code = context.Response.StatusCode,
                    Message = ex.Message
                };

                await HandleAsync(context, context.Response.StatusCode, model);
            }
        }
        private async Task HandleCustomExceptionAsync(HttpContext context, ExceptionBase exceptionBase)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exceptionBase.ExceptionStatusCode;

            await exceptionBase.Result!.ExecuteResultAsync(new ActionContext
            {
                HttpContext = context
            });
        }
        private async Task HandleAsync(HttpContext context, int code, ErrorModel model)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            var result = JsonConvert.SerializeObject(model);

            await context.Response.WriteAsync(result);
        }
    }
}