using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface Connection
    {
        List<Obj> GetList();
        Obj GetElement(String Name);
        void AddElement(Obj model);
        void UpdElement(Obj model);
        void DelElement(String Name);
    }
}
