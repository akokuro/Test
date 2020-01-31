using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ObjService : Connection
    {
        private DBContext context;
        public ObjService(DBContext context)
        {
            this.context = context;
        }
        public List<Obj> GetList()
        {
            List<Obj> result = context.Objs.Select(rec => new Obj(rec.Name, rec.Enum)).ToList();
            return result;
        }
        public Obj GetElement(String Name)
        {
            Obj element = context.Objs.FirstOrDefault(rec => rec.Name == Name);
            if (element != null)
            {
                return element;
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(Obj model)
        {
            Obj element = context.Objs.FirstOrDefault(rec => rec.Name ==
           model.Name);
            if (element != null)
            {
                throw new Exception("Уже есть");
            }
            context.Objs.Add(new Obj(model.Name, model.Enum));
            context.SaveChanges();
        }
        public void UpdElement(Obj model)
        {
            Obj element = context.Objs.FirstOrDefault(rec => rec.Name == model.Name && rec.Enum == model.Enum);
            if (element != null)
            {
                throw new Exception("Уже есть");
            }
            element = context.Objs.FirstOrDefault(rec => rec.Name == model.Name);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Name = model.Name;
            element.Enum = model.Enum;
            context.SaveChanges();
        }
        public void DelElement(String Name)
        {
            Obj element = context.Objs.FirstOrDefault(rec => rec.Name == Name);
            if (element != null)
            {
                context.Objs.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
