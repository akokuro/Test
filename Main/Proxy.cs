using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Models;
using static Models.Obj;

namespace Main
{
    public class Proxy : Connection
    {
        private ObjService service;
        private List<Obj> list;
        public CareTaker history = new CareTaker();
        public Proxy(ObjService service)
        {
            this.service = service;
        }
        public void AddElement(Obj model)
        {
            if (list.FirstOrDefault(rec => rec.Name == model.Name) == null)
            {
                list.Add(model);
                service.AddElement(model);
            }
            else
            {
                throw new Exception("Уже есть");
            }

        }

        public void DelElement(string Name)
        {
            list.Remove(list.FirstOrDefault(rec => rec.Name == Name));
            service.DelElement(Name);
        }

        public Obj GetElement(string Name)
        {
            if (list.FirstOrDefault(rec => rec.Name == Name) != null)
            {
                return list.FirstOrDefault(rec => rec.Name == Name);
            }
            else
            {
                Obj temp = service.GetElement(Name);
                if (temp == null)
                {
                    throw new Exception("Нет такого элемента");
                }
                else
                {
                    list.Add(temp);
                    return temp;
                }
            }
        }

        public List<Obj> GetList()
        {
            return list;
        }

        public void UpdElement(Obj model)
        {
            Obj element = list.FirstOrDefault(rec => rec.Name == model.Name);
            if (element == null)
            {
                Obj temp = service.GetElement(model.Name);
                if (temp == null)
                {
                    throw new Exception("Такого элемента не существует");
                }
                else
                {
                    service.UpdElement(model);
                    list.Add(service.GetElement(model.Name));
                    history.Do(model.Save(), list.Count - 1);
                }
            }
            else
            {
                service.UpdElement(model);
                int i = list.IndexOf(list.FirstOrDefault(rec => rec.Name == model.Name));
                history.Do(model.Save(), i);
                list[i].Name = model.Name;
                list[i].Enum = model.Enum;
            }
        }
        public class CareTaker
        {
            private List<Memento>[] stack;

            public void Do(Memento m, int i)
            {
                stack[i].Add(m);
            }

            public Memento Undo(int i)
            {
                return stack[i].ElementAt(stack[i].Count - 1);
            }
        }
    }
}
