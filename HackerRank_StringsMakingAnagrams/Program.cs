using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the makeAnagram function below.
    static int makeAnagram(string a, string b)
    {
        List<char> aLst = a.ToList();
        List<char> bLst = b.ToList();

        int minNumberOfDeletions = 0;

        bool isEmptyList = false;

        aLst.Sort();
        bLst.Sort();

        while (!isEmptyList)
        {
            int aCountOfLetters = 0;
            int bCountOfLetters = 0;
            char aLstLetter = aLst.Count > 0 ? aLst[0] : '/';
            char bLstLetter = bLst.Count > 0 ? bLst[0] : '/';

            // For List a
            if (aLst.Count > 0)
            {
                aCountOfLetters = aLst.Where(x => x == aLstLetter).Count();
                bCountOfLetters = bLst.Where(y => y == aLstLetter).Count();

                if (aCountOfLetters - bCountOfLetters >= 0)
                    minNumberOfDeletions += (aCountOfLetters - bCountOfLetters);
                else
                    minNumberOfDeletions += (bCountOfLetters - aCountOfLetters);

                aLst.RemoveAll(x => x == aLstLetter);
                bLst.RemoveAll(x => x == aLstLetter);
            }


            // For List b
            if (bLst.Count > 0 && bLstLetter != aLstLetter)
            {
                aCountOfLetters = aLst.Where(x => x == bLstLetter).Count();
                bCountOfLetters = bLst.Where(y => y == bLstLetter).Count();

                if (aCountOfLetters - bCountOfLetters >= 0)
                    minNumberOfDeletions += (aCountOfLetters - bCountOfLetters);
                else
                    minNumberOfDeletions += (bCountOfLetters - aCountOfLetters);

                aLst.RemoveAll(x => x == bLstLetter);
                bLst.RemoveAll(x => x == bLstLetter);
            }


            if (aLst.Count <= 0 && bLst.Count <= 0)
                isEmptyList = true;
        }

        return minNumberOfDeletions;

    }

    static void Main(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = makeAnagram(a, b);

        Console.WriteLine(res);
        Console.ReadKey();

        //textWriter.Flush();
        //textWriter.Close();
    }
}
