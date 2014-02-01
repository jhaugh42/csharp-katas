using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlayground
{
    class Program
    {
private static void Main(string[] args)
{

    List<int> allTheThings = new List<int> { 2, 4, 234, 523, 23, 124, 35 };
            
    Dictionary<int, string> subSetOfThings = new Dictionary<int, string>
        {
            {1,"AssetGroup for id 1"}, {2,"AssetGroup for id 2"}, {3,"AssetGroup for id 3"}, 
            {4,"AssetGroup for id 4"}, {234, "AssetGroup for id 234"}, {35, "AssetGroup for id 35"}
        };

    allTheThings.RemoveAll(c => !subSetOfThings.ContainsKey(c));

    Console.WriteLine("The things we are left with = {0}", string.Join(" ", allTheThings));
    Console.ReadLine();
}

    }
}
