using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Form1 : Form
    {
        List<Obj> objs;
        Proxy proxy;
        public Form1()
        {
            InitializeComponent();
            objs = new List<Obj>();
            userControl.LoadEnumeration(typeof(Enum));
            listBox.Items.Add("Название                         Жанр");
            PluginLoader loader = new PluginLoader();
            loader.LoadPlugins("C:\\Users\\Kurai\\source\\repos\\Main\\DataBase\\bin\\Debug");
            proxy = new Proxy(loader.Plugins[0].RunPlugin());
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Obj temp = new Obj(textBoxName.Text, userControl.SelectedText);
            objs.Add(temp);
            listBox.Items.Add(temp.ToString());
            textBoxName.Text = "";
            proxy.AddElement(temp);
        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            createReport.createReport("D:\\test.pdf", "Otchet", new String[] { "Name", "Enum" }, objs);
        }
    }
    public enum Enum
    {
        Yaoi,
        Senen_ai,
        Sedze,
        OYASH
    }
}
