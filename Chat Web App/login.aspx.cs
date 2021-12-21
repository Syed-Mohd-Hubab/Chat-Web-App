using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chat_Web_App
{
    public class tokenClass
    {
        public string token { get; set; }
    }

    public class reqObject2
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class resObject2
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string token{ get; set;}
    }

    public partial class login : System.Web.UI.Page
    {
        string token;

        private string URL = "http://localhost:5000/api/v1/auth/login/";
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Log in Page Loaded !");
        }

        protected void logbutton_click(object sender, EventArgs e)
        {
            Debug.WriteLine("Login button clicked !");

            reqObject2 obj = new reqObject2();
            obj.username = this.uname2.Text;
            obj.password = this.pwd2.Text;

            string json = JsonConvert.SerializeObject(obj);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            // +"?username=" + obj.username + "?password=" + obj.password
            HttpResponseMessage response = client.PostAsync(URL, httpContent).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            c
            if (response.IsSuccessStatusCode)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Log In Complete!')", true);
                // Parse the response body.
                resObject2 dataObjects = new resObject2();
                dataObjects = response.Content.ReadAsAsync<resObject2>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                //foreach (var d in dataObjects)
                token = dataObjects.token;
                Debug.WriteLine("Success Msg: ", dataObjects.message);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Log In Failed!')", true);
                Debug.WriteLine("Fail Msg: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

        }
    }
}