using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJsonImporter
{
    class Person
    {
        private string _FirstName;
        private string _LastName;
        private string _MiddleName;

        public string FirstName
        {
            get { return this._FirstName; }
            set { this._FirstName = value; }
        }

        public string LastName
        {
            get { return this._LastName; }
            set { this._LastName = value; }
        }

        public string MiddleName
        {
            get { return this._MiddleName; }
            set { this._MiddleName = value; }
        }
        public string getfirst()
        {
            return _FirstName;
        }
    }
}
