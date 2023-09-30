using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();


        foreach (var lang in languages)
        {
            // Console.WriteLine(lang.Prettify());
        }

        var basicInfos = languages.Select(x => $"{x.Year}, {x.Name}, {x.ChiefDeveloper}");

        var cSharpLangs = languages.Where(x => x.Name == "C#");

        var microSoft = languages.Where(x => x.ChiefDeveloper.Contains("Microsoft"));

        var lispLangs = languages.Where(x => x.Predecessors.Contains("Lisp"));

        var scriptLangs = languages.Where(x => x.Name.Contains("Script"))
        .Select(x => x.Name);

      

       var nearMillLang = languages.Where(x => x.Year >= 1995 && x.Year <= 2005)
       .Select(x => $"{x.Name} was invented in {x.Year}");

    //    foreach (var lang in nearMillLang)
    //    {
    //     Console.WriteLine(lang);
    //    }



    //    PrettyPrintAll(lispLangs);
       PrintAll(nearMillLang);
        

    }

    public static void PrettyPrintAll(IEnumerable<Language> langs)
    {
        foreach (Language lang in langs)
        {
            Console.WriteLine(lang.Prettify());
        }
    }

    public static void PrintAll(IEnumerable<Object> sequence)
    {
        foreach(Object obj in sequence)
        {
            Console.WriteLine(obj);
        }
    }


  }
}