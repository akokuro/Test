using DataBase;
using System;
using System.Collections.Generic;
using System.IO;

namespace Main
{
    public class PluginLoader
    {
        public List<IPlugin> Plugins = new List<IPlugin>();

        public void LoadPlugins(string dir)
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir);
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (string file in files)
            {
                IsPlugin(file);
            }
        }

        private IPlugin IsPlugin(string file_url)
        {

            byte[] b = System.IO.File.ReadAllBytes(file_url);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(b);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetInterface("IPlugin") != null)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    if (plugin != null)
                        Plugins.Add(plugin);
                }
            }
            return null;
        }
    }
}
