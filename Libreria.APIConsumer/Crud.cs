namespace Libreria.APIConsumer
{
    public class Crud<T>
    {

        public static T[] Select(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = api.DownloadString(url);
            var datos = Newtonsoft.Json.JsonConvert.DeserializeObject<T[]>(json);
            return datos;
        }

        public static T Select_One(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = api.DownloadString(url);
            var datos = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            return datos;
        }

        public static T Insert(string url, T data)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            json = api.UploadString(url, "POST", json);
            var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            return resultado;
        }

        public static void Update(string url, T data)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            api.UploadString(url, "PUT", json);
        }

        public static void Delete(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            api.UploadString(url, "DELETE", "");
        }
    }
}