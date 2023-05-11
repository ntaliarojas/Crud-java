using System.Data.SqlClient;

namespace CRUD3.Pages
{
    internal class Datatable
    {
        private SqlCommand cmd;

        public Datatable(SqlCommand cmd)
        {
            this.cmd = cmd;
        }
    }
}