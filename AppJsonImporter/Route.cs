using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJsonImporter
{
    class Route
    {
        private int _LEVEL;
        private bool _expanded = false;
        private bool _leaf = false;
        private string _CATEG;
        private int _ID;
        private int _PARENT_ID;
        private double _FtWEIGHT;
        private double _FtWEIGHT2;
        private double _FtWEIGHT3;
        private double _FtWEIGHT4;
        private double _FtWEIGHT5;
        private double _FtWEIGHT6;
        private double _FtWEIGHT7;
        private string _MAP;
        private string _DETAILS;

        public int LEVEL
        {
            get { return this._LEVEL; }
            set { this._LEVEL = value; }
        }
        public bool expanded
        {
            get { return this._expanded; }
            set { this._expanded = value; }
        }
        public bool leaf
        {
            get { return this._leaf; }
            set { this._leaf = value; }
        }
        public string CATEG
        {
            get { return this._CATEG; }
            set { this._CATEG = value; }
        }
        public int ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }
        public int PARENT_ID
        {
            get { return this._PARENT_ID; }
            set { this._PARENT_ID = value; }
        }
        public double FtWEIGHT
        {
            get { return this._FtWEIGHT; }
            set { this._FtWEIGHT = value; }
        }
        public double FtWEIGHT2
        {
            get { return this._FtWEIGHT2; }
            set { this._FtWEIGHT2 = value; }
        }
        public double FtWEIGHT3
        {
            get { return this._FtWEIGHT3; }
            set { this._FtWEIGHT3 = value; }
        }
        public double FtWEIGHT4
        {
            get { return this._FtWEIGHT4; }
            set { this._FtWEIGHT4 = value; }
        }
        public double FtWEIGHT5
        {
            get { return this._FtWEIGHT5; }
            set { this._FtWEIGHT5 = value; }
        }
        public double FtWEIGHT6
        {
            get { return this._FtWEIGHT6; }
            set { this._FtWEIGHT6 = value; }
        }
        public double FtWEIGHT7
        {
            get { return this._FtWEIGHT7; }
            set { this._FtWEIGHT7 = value; }
        }
        public string MAP
        {
            get { return this._MAP; }
            set { this._MAP = value; }
        }
        public string DETAILS
        {
            get { return this._DETAILS; }
            set { this._DETAILS = value; }
        }

        private void setRoute(int val1, bool val2, bool val3, string val4, int val5, int val6, double val7, double val8, double val9, double val10, double val11, double val12, double val13)
        {
            _LEVEL = val1;
            _expanded = val2;
            _leaf = val3;
            _CATEG = val4;
            _ID = val5;
            _PARENT_ID = val6;
            _FtWEIGHT = val7;
            _FtWEIGHT2 = val8;
            _FtWEIGHT3 = val9;
            _FtWEIGHT4 = val10;
            _FtWEIGHT5 = val11;
            _FtWEIGHT6 = val12;
            _FtWEIGHT7 = val13;
        }

        public int getLevel()
        {
            return _LEVEL;
        }
        public void setLevel(int val)
        {
            _LEVEL = val;
        }
        public bool getExpand()
        {
            return _expanded;
        }
        public void setExpand(bool val)
        {
            _expanded = val;
        }
        public bool getLeaf()
        {
            return _leaf;
        }
        public void setLeaf(bool val)
        {
            _leaf = val;
        }
        public string getCateg()
        {
            return _CATEG;
        }
        public void setCateg(string val)
        {
            _CATEG = val;
        }
        public int getId()
        {
            return _ID;
        }
        public void setId(int val)
        {
            _ID = val;
        }
        public int getParentId()
        {
            return _PARENT_ID;
        }
        public void setParentId(int val)
        {
            _PARENT_ID = val;
        }
        public double getFtWeight()
        {
            return _FtWEIGHT;
        }
        public void setFtWeight(double val)
        {
            _FtWEIGHT = val;
        }
        public double getFtWeight2()
        {
            return _FtWEIGHT2;
        }
        public void setFtWeight2(double val)
        {
            _FtWEIGHT2 = val;
        }
        public double getFtWeight3()
        {
            return _FtWEIGHT3;
        }
        public void setFtWeight3(double val)
        {
            _FtWEIGHT3 = val;
        }
        public double getFtWeight4()
        {
            return _FtWEIGHT4;
        }
        public void setFtWeight4(double val)
        {
            _FtWEIGHT4 = val;
        }
        public double getFtWeight5()
        {
            return _FtWEIGHT5;
        }
        public void setFtWeight5(double val)
        {
            _FtWEIGHT5 = val;
        }
        public double getFtWeight6()
        {
            return _FtWEIGHT6;
        }
        public void setFtWeight6(double val)
        {
            _FtWEIGHT6 = val;
        }
        public double getFtWeight7()
        {
            return _FtWEIGHT7;
        }
        public void setFtWeight7(double val)
        {
            _FtWEIGHT7 = val;
        }
        public string getMap()
        {
            return MAP;
        }
        public void setMap(string val)
        {
            MAP = val;
        }
        public string getDetails()
        {
            return DETAILS;
        }
        public void setDetails(string val)
        {
            DETAILS = val;
        }
    }
}
