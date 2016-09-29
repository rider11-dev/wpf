using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2.Pages.TransferState
{
    public class User
    {
        private string _name;
        private string _pwd;
        private List<string> _favColors;

        public User() { }

        public User(string name, string pwd)
        {
            this._name = name;
            this._pwd = pwd;
            this._favColors = new List<string>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        public List<string> FavColors
        {
            get { return _favColors; }
            set { _favColors = value; }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
