using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Node<int> lst = CreateList();
            //Console.WriteLine(lst);
            //PrintList(lst);
            //Console.WriteLine("---------------------------------------------------------------------");
            //PrintList(Even_nums(lst));



            //string[] words = { "fish","blue","bear","play" };
            //Node<string> lst=BuildList(words);
            //Console.WriteLine(lst);

            Node<string> words=BuildList();
            
            
            string word=GetWord(words);

            ShowMissing(word);
            Char letter = GetLetter('k');
            int count = 0;
            Play("hello");
        }



         





















        public static Node<int> CreateList()
        {
            Node<int> first = new Node<int>(8);
            Node<int> last = first;
            for (int i = 0; i < 3; i++)
            {
                last.SetNext(new Node<int>(i));
                last = last.GetNext();

            }
            return first;
        }
        public static void PrintList(Node<int> lst)
        {
            while (lst != null)
            {
                Console.WriteLine(lst);
                lst = lst.GetNext();
            }
        }

        public static Node<int> ReverseList()
        {
            Node<int> lst = null;
            for (int i = 0; i < 3; i++)
            {
                lst = new Node<int>(i, lst);
            }
            return lst;
        }

        


        public static Node<int> Even_nums(Node<int> lst)
        {
            Node<int> first = null;
            Node<int> last = null;



            while (lst != null)
            {

                if (lst.GetValue() % 2 == 0)
                {
                    if (first == null)
                    {
                        first = new Node<int>(lst.GetValue());
                        last = first;
                    }
                    else
                    {

                        last.SetNext(new Node<int>(lst.GetValue()));
                        last = last.GetNext();
                    }

                }
                lst = lst.GetNext();
            }

            return first;



        }



        public static Node<string> BuildList()
        {
            Node<string> first = new Node<string>("fish");
            Node<string> last = first;
            for (int i = 0;i < 4; i++)
            {
                
                
                
                if (i == 1)
                {
                    last.SetNext(new Node<string>("play"));
                    last = last.GetNext();
                }
                if (i == 2)
                {
                    last.SetNext(new Node<string>("bear"));
                    last = last.GetNext();
                }
                if (i == 3)
                {
                    last.SetNext(new Node<string>("blue"));
                    last = last.GetNext();
                }
            }
            return first;
        }






        public static Node<string> BuildList(string[] arr)
        {
            Node<string> first = new Node<string>(arr[0]);
            Node<string> last = first;
            for (int i = 1; i < arr.Length; i++)
            {
                last.SetNext(new Node<string>(arr[i]));
                last = last.GetNext();
            }
            return first;
        }


        public static int NumofWords(Node<string> lst)
        {
            
            int count = 0;
            while (lst != null)
            {

                count++;
                lst = lst.GetNext();
            }
            return count;
        }



        public static Node<string> CreateListFromUser()
        {
            Node<string> first = null;
            Node<string> last = first;
            Console.Write("Please enter how many words do you want to add: ");
            int numofwords=int.Parse(Console.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                string word = Console.ReadLine();
                if (first == null)
                {
                    first.SetValue(word);
                }
                
                last.SetNext(new Node<string>(word));
                last = last.GetNext();

            }
            return first;
        }


        public static int RandomNum(Node<string> lst)
        {
            int Count = NumofWords(lst);
            Random random = new Random();
            int num = random.Next(1, Count+1);
            return num;       
        }




        public static string GetWord(Node<string> lst)
        {
            int count=RandomNum(lst);
            for (int i = 0; i<=count; i++)
            {
                lst = lst.GetNext();
            }
            return lst.GetValue();

        }

       


        public static void ShowMissing(string word)
        {
            
            int count=word.Length;
            Console.Write("Your Word ----> ");
            for(int i = 0; i < word.Length; i++)
            {
                Console.Write("_ ");
            }
        }


        public static int IsInWord(string word,char letter)
        {
            for (int i = 0; i < word.Length; i++) 
            {
              if (letter == word[i])
                {
                    return i;
                }
            }
            return -1;
        }




        public static char GetLetter(char letter)
        {
            return letter;
        }




        public static void ShowMissingAfter(string word)
        {

            int count = word.Length;
            Console.Write("Your Word ----> ");
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write("_ ");
            }
        }


        public static bool Is_InWord(string word, char[] chars,char letter)
        {
            bool flag=false;
            for (int i = 0; i < word.Length; i++) 
            {
                if (letter == word[i])
                {
                    chars[i] = letter;
                    flag = true;
                }
            }
            return flag;
            
        }

        public static void Play(string word)
        {
            int count = 0;
            char[] chars = new char[word.Length];
            Init(chars);
            while(count<=6)
            {
                char ch =char.Parse(Console.ReadLine());    
                bool IsRight=Is_InWord(word,chars, ch);
                if (IsRight)
                {
                    Console.WriteLine("You are right :) ");
                    
                }
                else 
                {
                    Console.WriteLine("Wrong");
                    count++;
                }
                PrintChar(chars);
                Draw_HangMan(count);

                

            }


        }
        public static void Init(char[] chars)
        {
            for(int i = 0;i < chars.Length; i++)
            {
                chars[i] = '_';
            }
        }


        public static void PrintChar(char[] chars)
        {
            for (int i = 0;i<chars.Length ; i++)
            {
                Console.Write(chars[i]);
            }
        }



        public static void Draw_HangMan(int count)
        {
            Console.Clear();

            if (count >= 1)
            {
                Console.WriteLine("  +---+");
            }
            if (count >= 2)
            {
                Console.WriteLine("  |   |");
            }
            else if (count >= 1)
            {
                Console.WriteLine("  |");
            }

            if (count >= 3)
            {
                Console.WriteLine("  |   O");
            }
            else if (count >= 1)
            {
                Console.WriteLine("  |");
            }

            if (count == 4)
            {
                Console.WriteLine("  |   |");
            }
            else if (count == 5)
            {
                Console.WriteLine("  |  /| ");
            }
            else if (count >= 6)
            {
                Console.WriteLine("  |  /|\\");
            }
            else if (count >= 1)
            {
                Console.WriteLine("  |");
            }

            if (count == 5)
            {
                Console.WriteLine("  |  /  ");
            }
            else if (count >= 6)
            {
                Console.WriteLine("  |  / \\");
            }
            else if (count >= 1)
            {
                Console.WriteLine("  |");
            }

            if (count >= 1)
            {
                Console.WriteLine("  |");
                Console.WriteLine("=========");
            }
        }

















    }

}

