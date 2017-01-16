using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    public class SQLcondition
    {
        private String parameter;
        private String value;
        private List<String> listValue;
        public String Parameter
        {
            get { return this.parameter; }
            set { this.parameter = value; }
        }
        public String Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public SQLcondition(String _parameter, String _value)
        {
            this.Parameter = _parameter;
            this.Value = _value;
            this.listValue = null;
        }
        public SQLcondition(String _parameter, List<String> _listValue)
        {
            this.Parameter = _parameter;
            this.Value = null;
            this.listValue = _listValue;
        }
        public override String ToString()
        {
            String retour;
            if (this.Value == null)
            {
                retour = this.Parameter + " IN (";
                foreach(String val in this.listValue)
                {
                    retour += "val,";
                }
                retour.Remove(retour.Length - 1);
                retour += ")";
            }
            else
            {
                retour = this.Parameter + " = " + this.Value;
            }
            return retour;
        }
    }
}
