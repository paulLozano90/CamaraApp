using System;
using System.Threading.Tasks;
using ContactosModel.Model;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace CamaraApp
{
    public class UploadFile
    {
        string url = "http://apisocialnetdani.azurewebsites.net/api/Camara";

        public async Task<String> SubirFoto(byte[] file)
        {
            var client = new RestClient(url);

            var request = new RestRequest();
            request.Method = Method.POST;

            var d = new FotosModel() {Data = Convert.ToBase64String(file), idFoto = 2};
            request.AddJsonBody(d);

            var r = await client.Execute<string>(request);
            return r.Data;
        }
    }
}