using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public class WebClientCrudService<TEntity> where TEntity:IBaseDto
    {
        private string serviceName;

        public WebClientCrudService(string ServiceName)
        {
            serviceName = ServiceName;
        }
        public List<TEntity> GetEntities()
        {
            string url = $"{FormsSettings.HostUrl}/{serviceName}/Entities";

            var req = WebRequest.Create(url);
            req.Method = "GET";
            var resp = (HttpWebResponse)req.GetResponse();
            var text = "";
            using (var stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<TEntity>>(text);
        }

        public string DeleteEntity(string id)
        {
            string url = $"{FormsSettings.HostUrl}/{serviceName}/Entities/{id}";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "DELETE";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            return resp.StatusCode.ToString();
        }

        public string CreateEntity(TEntity subjectDto)
        {
            subjectDto.Id = Guid.NewGuid();
            string url = $"{FormsSettings.HostUrl}/{serviceName}/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";

            var data = JsonConvert.SerializeObject(subjectDto);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);

            req.ContentType = "application/json";
            req.ContentLength = byteArray.Length;

            using (Stream dataStream = req.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            var text = "";
            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
            return text;
        }

        public string UpdateEntity(TEntity subjectDto)
        {
            string url = $"{FormsSettings.HostUrl}/{serviceName}/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "PUT";

            var data = JsonConvert.SerializeObject(subjectDto);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            req.ContentType = "application/json";
            req.ContentLength = byteArray.Length;

            using (Stream dataStream = req.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            var text = "";
            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
            return text;
        }
    }
}