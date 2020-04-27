using homeCinema.Data.EF;
using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace homeCinema.WebApp.Infrastructures.Core
{
    public class ApiControllerBase : ApiController
    {
        protected readonly IRepository<Error> _errorRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ApiControllerBase(IRepository<Error> errorRepository,
            IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response;
            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                };

                _errorRepository.Add(_error);
                _unitOfWork.Commit();
            }
            catch { }
        }
    }
}
