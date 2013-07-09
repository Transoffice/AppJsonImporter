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
    public partial class Add : Form
    {
        public RoutesVerwaltung rts = new RoutesVerwaltung();

        public RoutesVerwaltung getRTS()
        {
            return rts;
        }
        public Add()
        {
            InitializeComponent();
        }

        public Add(RoutesVerwaltung farm)
        {
            InitializeComponent();
            rts = farm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Route rute = new Route();
            rute.setRoute(Convert.ToInt32(LevelBox.Text), expandedBox.ThreeState, leafBox.ThreeState, CategBox.Text, Convert.ToInt32(IdBox.Text), Convert.ToInt32(ParentIdBox.Text), Convert.ToDouble(FtWeightBox.Text), Convert.ToDouble(FtWeight2Box.Text), Convert.ToDouble(FtWeight3Box.Text), Convert.ToDouble(FtWeight4Box.Text), Convert.ToDouble(FtWeight5Box.Text), Convert.ToDouble(FtWeight6Box.Text), Convert.ToDouble(FtWeight7Box.Text), MapBox.Text, DetailsBox.Text);
            rts.setRoute(rute);

            this.Hide();
        }
    }
}
