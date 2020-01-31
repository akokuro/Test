using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChoiceEnum
{
    public partial class UserControl1: UserControl
    {
        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        private event EventHandler _listBoxSelectedElement;

        /// <summary>
        /// Порядковый номер выбранного Менеджера
        /// </summary>
        [Category("Спецификация"), Description("Порядковый номер выбранного элемента ФИО Менеджера")]
        public int SelectedIndex
        {
            get { return listBoxEnum.SelectedIndex; }
            set { listBoxEnum.SelectedIndex = value; }
        }

        /// <summary>
        /// Текст выбранной записи
        /// </summary>
        [Category("Спецификация"), Description("Текст выбранной записи ФИО менеджера")]
        public string SelectedText
        {
            get { return listBoxEnum.SelectedItem.ToString(); }
        }
        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        [Category("Спецификация"), Description("Событие выбора элемента из списка ФИО менеджера")]
        public event EventHandler ListBoxSelectedElementChange
        {
            add { _listBoxSelectedElement += value; }
            remove { _listBoxSelectedElement -= value; }
        }

        public UserControl1()
        {
            InitializeComponent();
            listBoxEnum.SelectedIndexChanged += (send, ev) => { _listBoxSelectedElement?.Invoke(send, ev); };
        }

        /// <summary>
        /// Заполнение списка ФИО менеджеров значениями из справочника
        /// </summary>
        /// <param name="type">тип-справочник</param>
        public void LoadEnumeration(Type type)
        {
            foreach (var elem in Enum.GetValues(type))
            {
                listBoxEnum.Items.Add(elem.ToString());
            }
            listBoxEnum.SelectedIndex = 0;
        }
    }
}
