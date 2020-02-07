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


//input Format

//The first line contains two space-separated integers, and, the numbers of words in the and the ..
//The second line contains  space-separated strings, each .
//The third line contains  space-separated strings, each .

//Constraints

//.
//Each word consists of English alphabetic letters(i.e., to and  to ).
//Output Format

//Print Yes if he can use the magazine to create an untraceable replica of his ransom note.Otherwise, print No.

//Sample Input 0

//6 4
//give me one grand today night
//give one grand today
//Sample Output 0

//Yes
//Sample Input 1

//6 5
//two times three is not four
//two times two is four
//Sample Output 1

//No
//Explanation 1

//'two' only occurs once in the magazine.

//Sample Input 2

//7 4
//ive got a lovely bunch of coconuts
//ive got some coconuts
//Sample Output 2

//No
//Explanation 2

//Harold's magazine is missing the word "some"

class Solution
{

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note)
    {        
        Dictionary<string, int> magazineWordsbycount = new Dictionary<string, int>();
        
        foreach(string word in magazine)
        {
            if (!magazineWordsbycount.ContainsKey(word))
            {
                magazineWordsbycount.Add(word, 1);

            }
            else
            {
                magazineWordsbycount[word]++;
            }

        }
        bool isSubSet = true;
        Dictionary<string, int> noteByCount = new Dictionary<string, int>();
        foreach(string word in note)
        {
            if (magazineWordsbycount.ContainsKey(word))
            {
                magazineWordsbycount[word]--;
                if(magazineWordsbycount[word] < 0)
                {
                    isSubSet = false;
                    break;
                }

            }
            else
            {
                isSubSet = false;
                break;
            }
        }
        if (isSubSet)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }

    }

    static void Main(string[] args)
    {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
