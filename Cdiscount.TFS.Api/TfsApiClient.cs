using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Cdiscount.TFS.Api.Business.Build;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.InteropServices;
using Cdiscount.TFS.Api.Business.Test;
using Cdiscount.TFS.Api.Business.VersionControl;
using Cdiscount.TFS.Api.Business.Wit;
using Cdiscount.TFS.Api.Business.GetComments;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Cdiscount.TFS.Api
{
    public class TfsApiClient
    {
        #region attributes

        private string _baseAddress;
        private Builds _builds;
        private Test _TestResults;
        private Versioncontrol _VersionControl;
        private Wit _wit;
        private GetComments _getComments;

        #endregion attributes

        private void AffectURI(Uri baseAddress)
        {
            _baseAddress = baseAddress.AbsoluteUri;
            _builds = BaseObjectApi<Builds>.CreateObject(this);
            _TestResults = BaseObjectApi<Test>.CreateObject(this);
            _VersionControl = BaseObjectApi<Versioncontrol>.CreateObject(this);
            _wit = BaseObjectApi<Wit>.CreateObject(this);
            _getComments = BaseObjectApi<GetComments>.CreateObject(this);

        }

        #region Constructors
        public TfsApiClient(IConfigurationRoot configuration)
        {
            AffectURI(new Uri(configuration["TfsApiUri"]));
        }

        public TfsApiClient(Uri baseAddress)
        {
            AffectURI(baseAddress);
        }

        #endregion Constructors




        #region Properties

        public string BaseAddress
        {
            get { return _baseAddress; }
        }

        public Wit Wit 
        {
            get { return _wit; }
        }

        public GetComments Comments
        {
            get { return _getComments; }
        }

        public Test Test
        {
            get { return _TestResults; }
        }
        public Versioncontrol VersionControl
        {
            get { return _VersionControl; }
        }

        public Builds Builds
        {
            get { return _builds; }
        }


        #endregion Properties



        #region Methods

        public static T QueryObject<T>(string queryUrl, IConfigurationRoot configuration)
        {
            try
            {
                using (HttpClient client = GetWebClient(configuration, 30))
                {
                    string json = null;
                    CallWebApi(() => json = client.GetStringAsync(queryUrl).Result);
                    T obj = JsonConvert.DeserializeObject<T>(json);
                    return obj;
                }
            }
            catch(Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
                return default(T);
            }

        }

        //public static T QueryObject<T>(string queryUrl, IConfigurationRoot configuration, HttpClient client)
        //{
        //    try
        //    {
        //        using (client)
        //        {
        //            string json = null;
        //            CallWebApi(() => json = client.GetStringAsync(queryUrl).Result);
        //            T obj = JsonConvert.DeserializeObject<T>(json);
        //            return obj;
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
        //        return default(T);
        //    }

        //}

        static int compt = 0;


        public static List<T> QueryList<T>(string queryUrl, IConfigurationRoot configuration)
        {
            using (HttpClient client = GetWebClient(configuration,30))
            {
                string json = null;
                CallWebApi(
                    () =>
                    {
                        try
                        {
                            json = client.GetStringAsync(queryUrl).Result;
                        }
                        catch (TaskCanceledException ex)
                        {
                            compt++;
                            Debug.WriteLine(string.Format("TaskCanceledException : {0}", compt));                            
                        }
                    }
                    );
                var list = JsonConvert.DeserializeObject<List<T>>(json ?? "[]");
                return list;
            }
        }


        private static string CallWebApi(Action a, bool rethrow = true)
        {
            string result = null;
            try
            {
                a();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                    result = reader.ReadToEnd();
                    if (rethrow)
                    {
                        throw new WebException(string.Format("Sonar API error: {0}", result), ex);
                    }
                }
                else
                {
                    throw;
                }
            }
            return result;
        }

        public static HttpClient GetWebClient(IConfigurationRoot configuration, int timeOut)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0,0,timeOut);
           
            string token = configuration["TfsApiToken"];
            if (string.IsNullOrEmpty(token))
            {
                string login = configuration["SonarApiLogin"];
                string password = configuration["SonarApiPassword"];

                if (String.IsNullOrEmpty(login))
                {
                    throw new ArgumentNullException("SonarApiLogin not found in app.config !");
                }
                if (String.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException("SonarApiPassword not found in app.config !");
                }
                var bytes = Encoding.UTF8.GetBytes(login + ":" + password);
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(bytes));
            }
            else
            {
                var bytes = Encoding.UTF8.GetBytes(token + ":");
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(bytes));

            }

            return client;
        }




        #endregion Methods



    }
}
