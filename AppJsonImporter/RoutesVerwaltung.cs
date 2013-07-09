using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJsonImporter
{
    public class RoutesVerwaltung
    {
        private List<Route> Routes = new List<Route>();

        public List<Route> children
        {
            get { return this.Routes; }
            set { this.Routes = value; }
        }


        public List<Route> getRoute()
        {
            return Routes;
        }
        public void setRoute(Route val)
        {
            Routes.Add(val);
        }
        public Route getRoutebyId(int index)
        {
            return Routes[index];
        }

        public void insertIntoRoute(int index, Route val)
        {
            Routes[index] = val;
        }
        public void deleteById(int index)
        {
            Routes.RemoveAt(index);
        }
    }
}
