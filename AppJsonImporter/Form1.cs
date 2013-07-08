using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace AppJsonImporter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Add ad = new Add();
            ad.ShowDialog();
        }
        private string FilePathJson;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            var FD = fDialog;
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = FD.FileName;

                System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);
                fDialog.ShowHelp = true;
                fDialog.Filter = "JSON Files|*.json";
                fDialog.Title = "Open XML/UML File";
                //OR

                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                //etc
                FilePathSt.Text = fileToOpen;
                FilePathJson = fileToOpen;
                readJson(fileToOpen);
            }
        }
        private void readJson(string fileToOpen)
        {
            try
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();


                byte[] byteArray = System.IO.File.ReadAllBytes(fileToOpen);

                string jsonResponse = System.Text.Encoding.UTF8.GetString(byteArray);
                Route singlePerson = jsonSerializer.Deserialize<Route>(jsonResponse);

                RoutesBoxList.Items.Add(jsonResponse);
                RoutesBoxList.Items.Add(singlePerson.getCateg());

            }
            catch (Exception e)
            {
                RoutesBoxList.Items.Add("Cannot deserialize json " + fileToOpen);
            }
            /*var json = System.IO.File.ReadAllText(@"D:\App\VertrigoServ\www\dialog\RTSBapp\data\TransportTable.json");

            var objects = JArray.Parse(json); // parse as array  
            foreach (JObject root in objects)
            {
                foreach (KeyValuePair<String, JToken> app in root)
                {
                    //var appName = app.Key;
                    var LEVEL = (String)app.Value["LEVEL"];
                    //var value = (String)app.Value["Value"];

                    //Console.WriteLine(appName);
                    //Console.WriteLine(description);
                    //Console.WriteLine(value);
                    //Console.WriteLine("\n");
                    RoutesBoxList.Items.Add(LEVEL);
                }
            }*/
           /* var json = System.IO.File.ReadAllText(@"D:\App\VertrigoServ\www\dialog\RTSBapp\data\TransportTable.json");
            WebClient c = new WebClient();
            var data = c.DownloadString("http://127.0.0.1:25065/dialog/RTSBapp/data/TransportTable.json");
            //Console.WriteLine(data);
            JObject o = JObject.Parse(data);
            RoutesBoxList.Items.Add("Name: " + o["CATEG"]);*/
        }

        private void RoutesBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
