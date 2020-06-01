using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FAMS
{
    public class ComboItem
    {
        public int? Key; public string Value;
        public ComboItem(int? key, string value)
        {
            if (key.HasValue)
            {
                Key = key; Value = value;
            }
            else GF.Error("Key of ComboItem[" + value + "] is invalid");
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Value;
        }
    }
}
