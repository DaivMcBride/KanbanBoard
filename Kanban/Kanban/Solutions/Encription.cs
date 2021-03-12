using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Models;
using System.IO;

namespace Kanban.Solutions
{
    public class Encription : IEncription
    {

        public EncriptionFile GetEncriptedFile(EncriptionKey Key)
        {
            var Efile = new EncriptionFile(Key);
            if (File.Exists(Key.Loads))
            {
                Efile.Description = File.ReadAllText(Key.Loads);
            }
            else
            {
                File.WriteAllText(Efile.Loads, Efile.Description);
            }
            return Efile;
        }
        public void SaveDataSet(EncriptionFile Efile)
        {


            File.WriteAllText(Efile.Loads, Efile.Description);
        }
        public char Cipher(char Charcter, List<char> Key, int Shift)
        {
            var index = Key.IndexOf(Charcter);
            var value = Charcter;
            if (index >= 0)
            {
                index += Shift;
                if (index > Key.Count() - 1)
                {
                    index = index - (Key.Count() );
                }
                else if (index < 0)
                {
                    index = index + (Key.Count() );
                }
                value = Key[index];
            }
            return value;


        }
        public void EncriptedFile(EncriptionFile Efile)
        {
            var encripted = "";
            var description = Efile.Description.ToCharArray();
            for (var x = 0; x < description.Length; x++)
            {
                encripted += Cipher(description[x], Efile.CipherKey, Efile.Shift);
            }
            Efile.Description = encripted;
        }
        public void DeEncriptedFile(EncriptionFile Efile)
        {

            var dencripted = "";
            var description = Efile.Description.ToCharArray();
            for (var x = 0; x < description.Length; x++)
            {
                dencripted += Cipher(description[x], Efile.CipherKey, Efile.Shift*-1);
            }
            Efile.Description = dencripted;
        }
    }
}

