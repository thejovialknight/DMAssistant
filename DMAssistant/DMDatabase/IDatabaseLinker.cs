using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMDatabase
{
    interface IDatabaseLinker
    {
        string LinkString(string key, string value);
        List<string> LinkStringList(string key, List<string> value);
        bool LinkBool(string key, bool value);
        List<bool> LinkBoolList(string key, List<bool> value);
        int LinkInt(string key, int value);
        List<int> LinkIntList(string key, List<int> value);
        double LinkDouble(string key, double value);
        List<double> LinkDoubleList(string key, List<double> value);
        float LinkFloat(string key, float value);
        List<float> LinkFloatList(string key, List<float> value);
        T LinkObject<T>(string key, T value) where T : IDatabaseLinkable, new(); // generics to pass as type rather than instance? maybe?
        List<T> LinkObjectList<T>(string key, List<T> value) where T : IDatabaseLinkable, new(); // generics to pass as type rather than instance? maybe?
    }
}
