using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace SPO_555
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            while(true)
            {
                //Задали массив словов
                #region
                string[] words = new string[200];
                Char[] wChars = new Char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                Random rand = new Random();
                for(int k = 0; k<words.Count(); k++)
                {
                    string w = "";
                    for(int i = 0; i < rand.Next(3, 6); i++)
                    {
                        w += wChars[rand.Next(0, 25)];
                    }
                    words[k] = w;
                }
                #endregion
                string[] mas = new string[200];
                for (int i = 0; i < mas.Length;i++ )
                {
                    mas[i] = "";
                }

                for (int i = 0; i < words.Length; i++)
                {
                    Console.WriteLine(i + ": " + words[i]);
                }

                Console.WriteLine("Введите индекс для поиска через пробел:");
                string find = Console.ReadLine();
                int solt = 20;
                int hash = 0;
                //простой список
                #region
                for(int i = 0; i < words.Length; i++)
                {
                    string s = words[i];
                    hash = 100;
                    for (int j = 0; j < s.Length; j++)
                    {
                        hash += (int)s.ElementAt(j);
                    }
                    //Hash + solt
                    hash = (hash / 10)+solt;

                    mas[hash] += s + " ";
                }
                #endregion
                //поиск элемента
                DateTime d1 = DateTime.Now;
                string ms = DateTime.Now.ToString("ffff");
                int a1 = int.Parse(ms);
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] != "")
                    {
                        mas[i] = mas[i].Trim();
                        string[] e = mas[i].Split(' ');
                        for (int j = 0; j < e.Length; j++)
                        {
                            if (e[j] == find)
                            {
                                Console.WriteLine("--> Элемент " + find + " найден");
                            }
                        }
                    }
                }
                d1 = DateTime.Now;
                ms = DateTime.Now.ToString("ffff");
                int a2 = int.Parse(ms);
                Random r = new Random();
                Console.WriteLine("Затрачено времени: " + (a2-a1).ToString() + "мс");
                Console.WriteLine("Просто спиок:");
                //вывод простого списка
                for (int i = 0; i < mas.Length;i++)
                {
                    if(mas[i] != "")
                    {
                        Console.WriteLine(i + ": " + mas[i]);
                    }
                }
                Console.WriteLine();



                d1 = DateTime.Now;
                ms = DateTime.Now.ToString("fff");
                a1 = int.Parse(ms);      
                Console.WriteLine("Упорядоченный спискок");
                for (int i = 0; i < mas.Length;i++)
                {
                    if(mas[i]!="")
                    {
                        mas[i] = mas[i].Trim();
                        string[] e = mas[i].Split(' ');
                        Array.Sort(e);                          
                        for(int j = 0; j < e.Length; j++)
                        {
                            Console.Write(i + ": "+ e[j] + "; ");
                            if (e[j] == find)
                            {
                                Console.WriteLine("--> Элемент найден!");
                                d1 = DateTime.Now;
                                ms = DateTime.Now.ToString("fff");
                                a2 = int.Parse(ms);
                                Console.WriteLine("Затрачено времени: " + (a2 - a1).ToString() + "мс");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("---------------");
            }
        }
    }
}