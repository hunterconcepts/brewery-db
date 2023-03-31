using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HunterConcepts.BreweryDb.Models;

namespace HunterConcepts.BreweryDb.Api
{
    public class BreweryDbService
    {
        public string ApiKey { get; private set; }

        public BreweryDbService(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("apiKey");

            ApiKey = apiKey;
        }

        public BreweryDbService()
            : this(ConfigurationManager.AppSettings["BreweryDb:ApiKey"]) { }

        string GetPlural<TModel>()
            where TModel : Model
        {            
            return typeof(TModel).GetAttributeValue((PluralAttribute pa) => pa.Plural).ToLower();
        }

        string EndPoint<TModel>(string id = null)
            where TModel : Model
        {
            if (string.IsNullOrEmpty(id))
                return GetPlural<TModel>();

            return string.Format("{0}/{1}", typeof(TModel).Name.ToLower(), id);
        }

        string EndPoint<TPrimary, TDependent>(string id)
            where TPrimary : PrimaryModel
            where TDependent : DependentModel
        {
            return string.Format("{0}/{1}", EndPoint<TPrimary>(id), EndPoint<TDependent>());
        }

        /// <summary>
        /// /primary
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Result<TModel> Get<TModel>(string id, object parameters = null)
            where TModel : Model, new()
        {
            var response = new Request(ApiKey, EndPoint<TModel>(id), HttpMethod.Get, ToParameters(parameters)).Send();
            return response.ToResult<TModel>();
        }

        /// <summary>
        /// /model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public PagedResult<TModel> GetAll<TModel>(object parameters = null)
            where TModel : Model, new()
        {
            Request request = new Request(ApiKey, EndPoint<TModel>(), HttpMethod.Get, ToParameters(parameters));
            var response = request.Send();
            return response.ToPagedResult<TModel>();
        }

        /// <summary>
        /// /primary/{id}/dependent
        /// </summary>
        /// <typeparam name="TPrimary"></typeparam>
        /// <typeparam name="TDependent"></typeparam>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ListResult<TDependent> GetAll<TPrimary, TDependent>(string id, object parameters = null)
            where TPrimary : PrimaryModel, new()
            where TDependent : DependentModel, new()
        {
            Request request = new Request(ApiKey, EndPoint<TPrimary, TDependent>(id), HttpMethod.Get, ToParameters(parameters));
            var response = request.Send();
            return response.ToListResult<TDependent>();
        }

        /// <summary>
        /// /primaries
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Result<TModel> Post<TModel>(object parameters = null)
            where TModel : PrimaryModel, new()
        {
            var response = new Request(ApiKey, EndPoint<TModel>(), HttpMethod.Post, ToParameters(parameters)).Send();
            return response.ToResult<TModel>();
        }

        /// <summary>
        /// /primary/{id}/dependents
        /// </summary>
        /// <typeparam name="TPrimary"></typeparam>
        /// <typeparam name="TDependent"></typeparam>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Result<TDependent> Post<TPrimary, TDependent>(string id, object parameters = null)
            where TPrimary : PrimaryModel, new()
            where TDependent : DependentModel, new()
        {
            Request request = new Request(ApiKey, EndPoint<TPrimary, TDependent>(id), HttpMethod.Post, ToParameters(parameters));
            var response = request.Send();
            return response.ToResult<TDependent>();
        }

        public Result<TModel> Put<TModel>(string id, object parameters = null)
            where TModel : DependentModel, new()
        {
            Request request = new Request(ApiKey, EndPoint<TModel>(id), HttpMethod.Put, ToParameters(parameters));
            var response = request.Send();
            return response.ToResult<TModel>();
        }

        public Result<TModel> Delete<TModel>(string id)
            where TModel : PrimaryModel, new()
        {
            Request request = new Request(ApiKey, EndPoint<TModel>(id), HttpMethod.Delete);
            var response = request.Send();
            return response.ToResult<TModel>();
        }        

        public PagedResult<TModel> Search<TModel>(object parameters = null)
            where TModel : PrimaryModel, new()
        {
            Request request = new Request(ApiKey, "search", HttpMethod.Get, ToParameters(parameters));
            var response = request.Send();
            return response.ToPagedResult<TModel>();
        }

        public static string ToParameters(object parameters)
        {
            if (parameters == null)
                return string.Empty;

            var type = parameters.GetType();
            var props = type.GetProperties();
            var pairs = props.Select(x => string.Format("{0}={1}", x.Name, x.GetValue(parameters, null))).ToArray();
            return string.Join("&", pairs);
        }
    }
}
