using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public class dgvColumn
    {
        string _colID;
        string _colCaption;
        bool _visible;
        DataGridViewContentAlignment _Align;

        public string colID { get { return _colID; } set { _colID = value; } }
        public string colCaption { get { return _colCaption; } set { _colCaption = value; } }
        public bool visible { get { return _visible; } set { _visible = value; } }
        public DataGridViewContentAlignment Align { get { return _Align; } set { _Align = value; } }

        public dgvColumn(string colID, string colCaption, DataGridViewContentAlignment Align = DataGridViewContentAlignment.MiddleCenter, bool visible = true)
        {
            this.colID = colID;
            this.colCaption = colCaption;
            this.Align = Align;
            this.visible = visible;
        }
    }
}
