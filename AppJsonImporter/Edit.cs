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

namespace AppJsonImporter
{
    public partial class Edit : Form
    {
        RoutesVerwaltung rts = new RoutesVerwaltung();
        private int inda;
        public Edit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Route rute = new Route();
            rute.setRoute(Convert.ToInt32(LevelBox.Text), expandedBox.ThreeState, leafBox.ThreeState, CategBox.Text, Convert.ToInt32(IdBox.Text), Convert.ToInt32(ParentIdBox.Text), Convert.ToDouble(FtWeightBox.Text), Convert.ToDouble(FtWeight2Box.Text), Convert.ToDouble(FtWeight3Box.Text), Convert.ToDouble(FtWeight4Box.Text), Convert.ToDouble(FtWeight5Box.Text), Convert.ToDouble(FtWeight6Box.Text), Convert.ToDouble(FtWeight7Box.Text), MapBox.Text, DetailsBox.Text);
            rts.insertIntoRoute(inda, rute);
            saveJson();
        }
        public Edit(RoutesVerwaltung farm,int vil, int val1, bool val2, bool val3, string val4, int val5, int val6, double val7, double val8, double val9, double val10, double val11, double val12, double val13, string val14, string val15)
        {
            InitializeComponent();
            rts = farm;
            inda = vil;
            LevelBox.Text = val1.ToString();
            expandedBox.ThreeState = val2;
            leafBox.ThreeState = val3;
            CategBox.Text = val4;
            IdBox.Text = val5.ToString();
            ParentIdBox.Text = val6.ToString();
            FtWeightBox.Text = val7.ToString();
            FtWeight2Box.Text = val8.ToString();
            FtWeight3Box.Text = val9.ToString();
            FtWeight4Box.Text = val10.ToString();
            FtWeight5Box.Text = val11.ToString();
            FtWeight6Box.Text = val12.ToString();
            FtWeight7Box.Text = val13.ToString();
            MapBox.Text = val14;
            DetailsBox.Text = val15;
        }

        public void setLevel(int val)
        {
            LevelBox.Text = val.ToString();
        }

        private void saveJson()
        {
            using (FileStream fs = File.Open(@"D:\App\VertrigoServ\www\dialog\RTSBapp\data\asd.json", FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, rts);
            }
        }
    }
}
