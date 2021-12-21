using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Diagnostics;
using System.Text;

namespace Chat_Web_App
{

    public class reqObject
    {
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
    
    public class resObject
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

    public partial class registration : System.Web.UI.Page
    {
        private string URL = "http://localhost:5000/api/v1/auth/register/";

        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Registration Page Loaded !");
        }

        protected void regbutton_click(object sender,EventArgs e)
        {
            Console.WriteLine("Reg button clicked !");
            Debug.WriteLine("Reg button clicked !");

            reqObject obj = new reqObject();
            obj.fullname = this.fname.Text;
            obj.username = this.uname.Text;
            obj.password = this.pwd.Text;

            string json = JsonConvert.SerializeObject(obj);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL, httpContent).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

            if (response.IsSuccessStatusCode)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sign Up Complete!')", true);
                // Parse the response body.
                resObject dataObjects = new resObject();
                dataObjects = response.Content.ReadAsAsync<resObject>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                //foreach (var d in dataObjects)
                {
                    Debug.WriteLine("Success Msg: ", dataObjects.message);
                }
                Server.Transfer("~/login.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sign Up Failed!')", true);
                Debug.WriteLine("Fail Msg: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

        }
    }
}