using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationStreamRead {


  class Program {
    static void Main(string[] args) {

      Console.WriteLine("Entre com um texto");
      var input = Console.ReadLine();

      IStream iStrm = new MyStream(Encoding.UTF8.GetBytes(input));
      var output = firstChar(iStrm);
      if(output == Convert.ToChar(" "))
        Console.WriteLine($"Não foi localizado vogal que não se repete após a primeira Consoante.");
      else
        Console.WriteLine($"Foi localizado vogal '{output}' que se repete após a primeira Consoante." );

      Console.ReadKey();

    }

    public static char firstChar(IStream input) {

      var word = "";
      var final = ' ';
      var ini = -1;


      while (input.hasNext()) {
        var ret = input.getNext();
        word += ret;
      }

      for (int i = 0; i < word.Length; i++) {
        if (!"aeiou".Contains(word[i])) {
          ini = i;
          break;
        }
      }

      if (ini >= 0)
        for (int i = ini; i < word.Length; i++) {
          int count = 0;
          var r = word[i];

          for (int i2 = 0; i2 < word.Length; i2++) {

            var r2 = word[i2];

            if (word[i] == word[i2] && "aeiou".Contains(word[i2])) {
              

              int o = 0;

              for (int i3 = 0; i3 < word.Length; i3++) {
                if (word[i3] == word[i2])
                  o++;
              }


              if (o <= 1) {
                final = word[i];
                count++;
              }
            }

            if (count > 1)
              final = ' ';
          }
        }

      return final;
    }
  }
}

