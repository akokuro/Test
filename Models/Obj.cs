using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Obj
    {
        public String Name;
        public String Enum;
        public Obj(String Name, String Enum)
        {
            this.Name = Name;
            this.Enum = Enum;
        }
        public override string ToString()
        {
            return "" + Name + " " + Enum;
        }
        public Memento Save()
        {
            return new Memento(this.Name, this.Enum);
        }
        public void Restore(Memento m)
        {
            this.Name = m.getState()[0];
            this.Enum = m.getState()[1];
        }
        public class Memento
        {
            private String Name;
            private String Enum;

            public Memento(String Name, String Enum)
            {
                this.Name = Name;
                this.Enum = Enum;
            }

            public String[] getState()
            {
                return new String[] { this.Name, this.Enum };
            }
        }
    }
}
