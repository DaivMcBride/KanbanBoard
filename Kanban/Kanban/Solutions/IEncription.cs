using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Models;

namespace Kanban.Solutions
{
    public interface IEncription
    {
        EncriptionFile GetEncriptedFile(EncriptionKey Key);
        void SaveDataSet(EncriptionFile Efile);
        void EncriptedFile(EncriptionFile Efile);
        void DeEncriptedFile(EncriptionFile Efile);
        char Cipher(char Charcter, List<char> Key, int Shift);

    }
}

