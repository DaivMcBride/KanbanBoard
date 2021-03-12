using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class EncriptionKey
    {
        public int Shift { get; set; }
        public string Loads { get; set; }
    }
    public class EncriptionFile : EncriptionKey
    {
        public string Description { get; set; }
        public List<char> CipherKey { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890,./<>?!@#$%^&*()-=_+[]{};:".ToCharArray().ToList();
        public EncriptionFile()
        {

        }
        public EncriptionFile(EncriptionKey Key)
        {
            Shift = Key.Shift;
            Loads = Key.Loads;
            Description = "";
        }
    }
}
