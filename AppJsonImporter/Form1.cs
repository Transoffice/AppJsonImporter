using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Bytescout.PDFExtractor;
using System.Windows.Forms;
using System.Xml;

namespace AppJsonImporter
{
    public partial class MainForm : Form
    {
        RoutesVerwaltung rts = new RoutesVerwaltung();
        public MainForm()
        {
            InitializeComponent();
            this.RoutesBoxList.MouseDoubleClick += new MouseEventHandler(RoutesBoxList_MouseDoubleClick);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Add ad = new Add(rts);
            ad.ShowDialog();
            if (rts != null)
            {
                RoutesBoxList.Items.Clear();
                rts = ad.getRTS();
                for (int i = 0; i < rts.getRoute().Count; i++)
                    RoutesBoxList.Items.Add(ad.getRTS().getRoutebyId(i).getCateg());
            }
            else
            {
                RoutesBoxList.Items.Clear();
                rts = ad.getRTS();
                for (int i = 0; i < ad.getRTS().getRoute().Count; i++)
                    RoutesBoxList.Items.Add(ad.getRTS().getRoutebyId(i).getCateg());
            }


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
                //readJson(fileToOpen);
                //readPdf(fileToOpen);
                //PdfExtract(fileToOpen);
                readXml(fileToOpen);
            }
        }

        private void PdfExtract(string fileToOpen)
        {
            // Create Bytescout.PDFExtractor.XMLExtractor instance
            XMLExtractor extractor = new XMLExtractor();
            extractor.RegistrationName = "demo";
            extractor.RegistrationKey = "demo";

            // Load sample PDF document
            extractor.LoadDocumentFromFile(fileToOpen);

            extractor.SaveXMLToFile("output.XML");

            RoutesBoxList.Items.Add("Data has been extracted to 'output.XML' file.");
            RoutesBoxList.Items.Add("Press any key to continue and open XML in default XML viewer)...");

            Process.Start("output.XML");
        }

        private void saveJson()
        {
            using (FileStream fs = File.Open(@"D:\App\VertrigoServ\www\dialog\RTSBapp\data\asd.json", FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, rts);
            }
        }

        private void readPdf(string fileToOpen)
        {
            try
            {

            PdfReader reader = new PdfReader(fileToOpen);
            // total number of pages
            int n = reader.NumberOfPages;
            // size of the first page
            Rectangle psize = reader.GetPageSize(1);
            float width = psize.Width;
            float height = psize.Height;
                string asd = "Size of page 1 of {0} => {1} × {2}"+ n+ width+ height;
             RoutesBoxList.Items.Add(asd);
            // file properties
            Dictionary<string, string> infodict = reader.Info;

            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string currentText = PdfTextExtractor.GetTextFromPage(reader, page, strategy);

                currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                                RoutesBoxList.Items.Add(currentText);
                                TestBox.Text = currentText;
            }
            foreach (KeyValuePair<string, string> kvp in infodict)
                RoutesBoxList.Items.Add(kvp.Key + " => " + kvp.Value);
            }
            catch (Exception e)
            {
                RoutesBoxList.Items.Add("Cannot deserialize PDF " + fileToOpen);
            }
        }


        private void readJson(string fileToOpen)
        {
            try
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();


                byte[] byteArray = System.IO.File.ReadAllBytes(fileToOpen);

                string jsonResponse = System.Text.Encoding.UTF8.GetString(byteArray);
                RoutesVerwaltung singlePerson = jsonSerializer.Deserialize<RoutesVerwaltung>(jsonResponse);
                rts = singlePerson;

                var jss = new JavaScriptSerializer();
                var dict = jss.Deserialize<Dictionary<string, dynamic>>(jsonResponse);
                                ProgressBarStatus();
                var json = jss.Serialize(dict);
                //RoutesBoxList.Items.Add(singlePerson.getRoute().Count);
                //RoutesBoxList.Items.Add(json);
                //RoutesBoxList.Items.Add(singlePerson.children);
                //singlePerson.getRoutebyId(1).getCateg();
                RoutesBoxList.Items.Clear();
                for (int i = 0; i < rts.getRoute().Count; i++)
                {
                    RoutesBoxList.Items.Add(rts.getRoutebyId(i).getCateg());
                }


                //RoutesBoxList.Items.Add(jsonResponse);
                //RoutesBoxList.Items.Add(singlePerson.getCateg());

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

        string NL = Environment.NewLine;
        private void readXml(string path)
        {
            string tix = TestBox.Text;
            XmlTextReader reader = new XmlTextReader(path);


            
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        //TestBox.Text = TestBox.Text + NL + "<" + reader.Name;
                       // TestBox.Text = TestBox.Text + ">";
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        TestBox.Text = TestBox.Text + NL + reader.Value;
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        //TestBox.Text = TestBox.Text + NL + "</" + reader.Name;
                        //TestBox.Text = TestBox.Text + ">";
                        break;
                }
            }
        }

        private void RoutesBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void RoutesBoxList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.RoutesBoxList.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                if (RoutesBoxList.SelectedItem != null)
                {
                    try
                    {
                        int a = RoutesBoxList.SelectedIndex;
                        Route r = rts.getRoutebyId(a);
                        Edit edit = new Edit(rts, a, r.getLevel(), r.getExpand(), r.getLeaf(), r.getCateg(), r.getId(), r.getParentId(), r.getFtWeight(), r.getFtWeight2(), r.getFtWeight3(), r.getFtWeight4(), r.getFtWeight5(), r.getFtWeight6(), r.getFtWeight7(), r.getMap(), r.getDetails());

                        edit.ShowDialog();
                    }
                    catch (Exception b)
                    {
                        MessageBox.Show(b.ToString());
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int a = RoutesBoxList.SelectedIndex;
                rts.deleteById(a);

                RoutesBoxList.Items.Clear();
                for (int i = 0; i < rts.getRoute().Count; i++)
                    RoutesBoxList.Items.Add(rts.getRoutebyId(i).getCateg());
            }
            catch (Exception x)
            {
                MessageBox.Show("Nothing Selected", "Error");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RoutesBoxList.SelectedItem != null)
            {
                try
                {
                    int a = RoutesBoxList.SelectedIndex;
                    Route r = rts.getRoutebyId(a);
                    Edit edit = new Edit(rts, a, r.getLevel(), r.getExpand(), r.getLeaf(), r.getCateg(), r.getId(), r.getParentId(), r.getFtWeight(), r.getFtWeight2(), r.getFtWeight3(), r.getFtWeight4(), r.getFtWeight5(), r.getFtWeight6(), r.getFtWeight7(), r.getMap(), r.getDetails());

                    edit.ShowDialog();
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.ToString());
                }
            }
            else
            {
                MessageBox.Show("Nothing Selected", "Error");
            }
        }

        public void ProgressBarStatus()
        {
            LoadBar.Refresh();
            LoadBarText.Refresh();



            for (int i = 0; i < 101; i++)
            {
                LoadBar.Value = i;
                // Demo purposes only

                if (i < 30)
                {
                    LoadBarText.Text = "Read File";
                    LoadBarText.Refresh();
                }

                if (i < 70 && i > 31)
                {
                    LoadBarText.Text = "Convert File";
                    LoadBarText.Refresh();
                }

                if (i < 90 && i > 71)
                {
                    LoadBarText.Text = "Import File";
                    LoadBarText.Refresh();
                }

                if (i >= 99)
                {
                    LoadBarText.Text = "Complete";
                    LoadBarText.Refresh();
                }
                System.Threading.Thread.Sleep(10);

                // Set the custom text at different intervals for demo purposes

            }
        }
    }
}
