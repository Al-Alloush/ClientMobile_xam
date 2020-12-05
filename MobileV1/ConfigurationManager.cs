using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace MobileV1
{
    /*
     This is going to be a simple Singleton Manager that will allow you to easily access
     your App Settings anywhere in the shared code of your project.
     https://www.andrewhoefling.com/Blog/Post/xamarin-app-configuration-control-your-app-settings */
    class Configuration
    {
        // stores the instance of the singleton
        private static Configuration _instance;

        // variable to store appsettings in memory for quick and easy access
        private JObject _value; 
        private JObject _value2; 

        // constants needed to locate and access the App Settings file
        // after add json file in properites change Build Action to embedded resource, with out it will not find this file
        private const string FileNameRelease = "appsettings.json";
        private const string FileNameDebug = "appsettings.development.json";
        //#if DEBUG
        //        private const string FileName = "appsettings.development.json";
        //#else
        //        private const string FileName = "appsettings.json";
        //#endif

        // Creates the instance of the singleton
        private Configuration()
        {
            try
            {
                var assembly = typeof(Configuration).GetTypeInfo().Assembly;

                /*
                Reading two appsettings Json Files and merging them using LINQ to JSON objects.
                source: https://www.newtonsoft.com/json/help/html/MergeJson.htm

                If the key is present in both files, the key is overwritten in the appsettings.development.json file  */

                // read appsttings.development.json file, assembly.GetName().Name to get the Project Name
                Stream streamDebug = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{FileNameDebug}");
                using (var readerDebug = new StreamReader(streamDebug))
                {
                    var jsonDebug = readerDebug.ReadToEnd();
                    _value = JObject.Parse(jsonDebug);
                }
                // read appsttings.json file
                Stream streamRelease = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{FileNameRelease}");
                using (var readerRelease = new StreamReader(streamRelease))
                {
                    var jsonRelease = readerRelease.ReadToEnd();
                    _value2 = JObject.Parse(jsonRelease);
                }
                // Merge 2 files and overwritten in the appsettings.development.json file
                _value.Merge(_value2, new JsonMergeSettings
                {
                    // union array values together to avoid duplicates
                    MergeArrayHandling = MergeArrayHandling.Union
                });

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to load secrets file, Message:" + ex.Message);
            }
        }
        // Accesses the instance or creates a new instance
        public static Configuration Settings
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }
                return _instance;
            }
        }
        // Used to retrieved setting values
        public string this[string name]
        {
            get
            {
                try
                {
                    var path = name.Split(':');
                    JToken node = _value[path[0]];
                    for (int index = 1; index < path.Length; index++)
                    {
                        node = node[path[index]];
                    }
                    return node.ToString();
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Unable to retrieve secret '{name}'");
                    return string.Empty;
                }
            }
        }
    }
}
