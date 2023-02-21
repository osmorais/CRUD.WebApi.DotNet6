using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.WebApi.DotNet6.Application.Services
{
    public class ResultService
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public ICollection<ErrorValidation> errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService()
            {
                isSuccess = false,
                message = message,
                errors = validationResult.Errors
                .Select(x => new ErrorValidation { field = x.PropertyName, message = x.ErrorMessage })
                .ToList()
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>()
            {
                isSuccess = false,
                message = message,
                errors = validationResult.Errors
                .Select(x => new ErrorValidation { field = x.PropertyName, message = x.ErrorMessage })
                .ToList()
            };
        }

        public static ResultService Fail(string message) => new ResultService { isSuccess = false, message = message };
        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { isSuccess = false, message = message };
        public static ResultService OK(string message) => new ResultService { isSuccess = true, message = message };
        public static ResultService<T> OK<T>(T data) => new ResultService<T> { isSuccess = true, Data = data };
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
