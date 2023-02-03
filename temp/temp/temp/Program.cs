
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace temp
{
    class temp
    {
        public static void Main(string[] args)
        {
            temp t = new temp();
            Console.Write(t.F("flying"));
        }

        public bool D(string text)
        {
            return text == "yes";
        }

        public Char E(string text)
        {
            return text[text.Length - 1];
        }
        
        public string F(string text)
        {
            if (text.Length > 1)
            {
                Char[] chars = text.ToCharArray();
                return chars[chars.Length - 1].ToString() + chars[0].ToString();
            }
            else
            {
                return text;
            }
        }

        public Char G(string txt, int i)
        {
            Char[] chars = txt.ToCharArray();
            
            
            return chars[i];
        }

        public string H(string txt, string txt2)
        {
            return txt + txt2;
        }

        public bool I(string txt, Char c)
        {
            return c == txt[0];
        }
         
        public int[] K(int[] arr, int[] arr2)
        {
            int[] arr3;
            if(arr.Length == 4 && arr2.Length == 4)
            {
                int[] output = new int[8]; // it's given that the output should be 8 since it's 2 arrays of the length 4 put together 
                for (int i = 0; i < 4; i++) // we know the length is 4 so we can interate through that
                {
                    output[i] = arr[i]; // places arr[i] in the place of i
                    output[i + 4] = arr2[i]; // places aee2[i] in the place of i + 4 so it doesn't override.
                }
                arr3 = output;
            }
            else
            {
                int[] output = { };
                arr3 = output;
            }
            return arr3 ;
        }

        public int[] L(int i)
        {
            int[] arr = new int[i]; // creates empty array of the number given
            return arr;
        }

        public int numberOfLetters(string s, char b)
        {
            char[] chars = s.ToCharArray(); // makes the string into a char array
            int count = 0; // a countr for the amount of times a char is in the string
            int check = 0;
            do
            {
                if (chars[check] == b)
                {
                    count++;
                    check++;
                }
                else 
                {
                    check++;
                }
                
            }
            while (check < chars.Length);

            return count;
        }
        
        public int sumOfAllNumbers(int[] numbers)
        {
            return numbers.Sum();
        }

        public string theLongestWord(string[] list)
        {
            string output = "";
            int longest = 0;
            foreach(string s in list)
            {
                if (s.Length > longest)
                {
                    output = s;
                    longest = s.Length;
                    
                }
            }
        }


    }
}
