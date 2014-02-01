using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCombineTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ssts: " + BuildSstsFromParts("section", "subsection", "topic", "subtopic"));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("section", "subsection", "topic", ""));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("section", "subsection", "", ""));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("section", "", "", ""));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("section", "", "topic", "subtopic"));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("section", "", "", "subtopic"));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("section", "subsection", "", "subtopic"));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("", "subsection", "topic", "subtopic"));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("", "", "topic", "subtopic"));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("", "", "", "subtopic"));
            Console.WriteLine("Ssts: " + BuildSstsFromParts("", "", "", ""));

            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("section", "subsection", "topic", "subtopic"));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("section", "subsection", "topic", ""));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("section", "subsection", "", ""));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("section", "", "", ""));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("section", "", "topic", "subtopic"));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("section", "", "", "subtopic"));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("section", "subsection", "", "subtopic"));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("", "subsection", "topic", "subtopic"));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("", "", "topic", "subtopic"));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("", "", "", "subtopic"));
            Console.WriteLine("Ssts: " + ConvertSstsToPartialPageUrl("", "", "", ""));

            Console.WriteLine("done!");
            Console.ReadKey();
        }

        /// <summary>
        /// Builds an SSTS string form componenet parts.  
        /// Builds an SSTS string using only specified componenets, in SSTS order.
        /// </summary>
        /// <param name="section">the section</param>
        /// <param name="subsection">the subsection</param>
        /// <param name="topic">the topic</param>
        /// <param name="subtopic">the subtopic</param>
        /// <returns>The SSTS string composed of componenet parts</returns>
        public static string BuildSstsFromParts(string section, string subsection, string topic, string subtopic)
        {
            string[] sstsParts = new[] {section, subsection, topic, subtopic};
            return string.Join("/", sstsParts.TakeWhile(part => !string.IsNullOrWhiteSpace(part)));
        }


        private static string ConvertSstsToPartialPageUrl(string section, string subsection, string topic, string subtopic)
        {
            var ssts = section;
            ssts = ConcatenateSstsToPartialPageUrl(ssts, subsection);
            ssts = ConcatenateSstsToPartialPageUrl(ssts, topic);
            return ConcatenateSstsToPartialPageUrl(ssts, subtopic);
        }

        private static string ConcatenateSstsToPartialPageUrl(string path, string ssts)
        {
            if (!String.IsNullOrWhiteSpace(ssts))
            {
                return path + "/" + ssts;
            }
            return path;
        }

    }
}
