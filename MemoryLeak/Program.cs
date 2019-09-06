using Castle.Components.DictionaryAdapter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeak
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var factory = new DictionaryAdapterFactory(); //if you uncomment this line everything is fine, no leaks
            for (int i = 0; i < 1000000; i++)
            {
                var factory = new DictionaryAdapterFactory(); //if you uncomment this line program is reserving more and more memory without releasing it, even though objects are not used anymore
                var tmp = factory.GetAdapter<IYolo>(new Hashtable());
            }
            Console.ReadKey();
        }

        public interface IYolo
        {
            int Abc { get; set; }
            string swag { get; set; }
        }
    }
}
