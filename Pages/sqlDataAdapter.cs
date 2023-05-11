using System;

namespace CRUD3.Pages
{
    internal class sqlDataAdapter
    {
        private string v;
        private object con;

        public sqlDataAdapter(string v, object con)
        {
            this.v = v;
            this.con = con;
        }

        public object SelectCommand { get; internal set; }

        internal void Fill()
        {
            throw new NotImplementedException();
        }
    }
}