using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Plugins
{
    public class DatabasePluginManager
    {
        public string PluginDirectory { get; set; }
        public List<DatabasePlugin> DatabasePlugins { get; set; } = new();

        public DatabasePluginManager(string pluginDirectory)
        {
            this.PluginDirectory = pluginDirectory;
        }

        public bool LoadDatabasePlugins()
        {
            string path = System.IO.Path.GetFullPath(PluginDirectory);
            if (!System.IO.Directory.Exists(path))
                return false;
            //string[] pluginFilenames = System.IO.Directory.GetFiles(path, "*.dll");
            string[] pluginDirectories = System.IO.Directory.GetDirectories(path);
            var pluginFilenames = pluginDirectories.SelectMany(d => System.IO.Directory.GetFiles(d, "*.dll")).ToArray();
            
            foreach(var pluginFilename in pluginFilenames)
            {
                //var filename = System.IO.Path.GetFileName(pluginFilename);
                var assembly = LoadDatabasePluginAssembly(pluginFilename);
                var databasePlugins = LoadDatabasePluginsFromAssembly(assembly);
                DatabasePlugins.AddRange(databasePlugins);
            }
            return true;
        }

        private Assembly LoadDatabasePluginAssembly(string pluginLocation)
        {
            Console.WriteLine($"Loading commands from: {pluginLocation}");
            var loadFilename = Path.GetFileNameWithoutExtension(pluginLocation);
            var assemblyName = new AssemblyName(loadFilename);

            var loadContext = new PluginLoadContext(pluginLocation);
            var result = loadContext.LoadFromAssemblyName(assemblyName);
            return result;
        }

        private IEnumerable<DatabasePlugin> LoadDatabasePluginsFromAssembly(Assembly assembly)
        {
            string assemblyName = assembly.GetName().Name ?? string.Empty;
            int count = 0;
            var toType = typeof(DatabasePlugin);
            var types = assembly.GetTypes().ToArray();
            foreach (Type type in types)
            {
                string typeName = type.Name;
                if (toType.IsAssignableFrom(type))
                {
                    var plugin = Activator.CreateInstance(type) as DatabasePlugin;
                    if (plugin != null)
                    {
                        count++;
                        yield return plugin;
                    }
                }
            }

            if (count == 0)
            {
                string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
                System.Console.WriteLine(
                    $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                    $"Available types: {availableTypes}\n\n");
            }
        }


        public static MethodInfo? GetImplicitCast(Type type, Type destinationType)
        {

            if (type == destinationType)
                return null; // doesn't convert, it already is!
            var publicStaticMethods = (from method in type.GetMethods(BindingFlags.Static |
                                                   BindingFlags.Public)
                           //where //(method.Name == "op_Implicit" || method.Name == "op_Explicit") &&
                           //      method.ReturnType == destinationType
                           select method
                    ).ToArray();
            var returnPluginMethods = (from method in publicStaticMethods
                                       where
                                       method.ReturnType == destinationType
                                       select method).ToArray();
            var implicitOrExplicitMethods = (from method in returnPluginMethods
                                             where
                                             method.Name == "op_Implicit" || method.Name == "op_Explicit"
                                             select method).ToArray();

            var results = implicitOrExplicitMethods;

            return results.FirstOrDefault();
        }

    }
}
