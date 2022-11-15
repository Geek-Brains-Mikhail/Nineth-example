using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._11._22
{
    internal class Program
    {  
        static bool Check(string[] fullName)
        {
            if (fullName.Length != 0)
                return true;
            else return false;
        }
        static void AddDossier(ref string[] fullName,ref string[] post,ref int[] salary,string tmpFullName,string tmpPost,int tmpSalary)
        {
            Array.Resize(ref fullName, fullName.Length+1);
            Array.Resize(ref post, post.Length+1);
            Array.Resize(ref salary, salary.Length+1);
            fullName[fullName.Length-1] = tmpFullName;
            post[fullName.Length-1] = tmpPost;
            salary[fullName.Length-1] = tmpSalary;
        }
        static void PrintDossier(string[] fullName, string[] post, int[] salary)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
            }
            Console.WriteLine();
        }
        static void DeleteDossier(ref string[] fullName,ref string[] post,ref int[] salary,int index)
        {
            string[] tmpFullName = new string[fullName.Length - 1];
            string[] tmpPost = new string[post.Length - 1];
            int[] tmpSalary = new int[salary.Length -1];

            for (int i = 0,g =0; i < fullName.Length; i++)
            {
                if(i!=index)
                {
                    tmpFullName[g] = fullName[i];
                    tmpPost[g] = post[i];
                    tmpSalary[g] = salary[i];
                    continue;
                }
                if (index!=0) g--;
            }
            Array.Resize(ref fullName, fullName.Length-1);
            Array.Resize(ref post, post.Length-1);
            Array.Resize(ref salary, salary.Length - 1);

            for (int i = 0; i < fullName.Length; i++)
            {
                fullName[i] = tmpFullName[i];
                post[i] = tmpPost[i];
                salary[i] = tmpSalary[i];
            }
        }
        static int SeacrhDossier(string surName, string[] fullName)
        {
       
            for (int i = 0; i < fullName.Length; i++)
            {
                string[] tmp = fullName[i].Split(' ');
                if (tmp[0].ToLower() ==surName.ToLower())
                {
                    return i + 1;
                }
            }
            return -1;
        }
        static void SearchCertainSalary(string[] fullName, string[] post, int[] salary, string parameter)
        {
            char sign = parameter[0];
            int sum = Convert.ToInt32(parameter.Substring(1, parameter.Length - 1));
            if (sign == '>')
            {
                for (int i = 0; i < salary.Length; i++)
                {
                    if (salary[i] > sum)
                        Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
                }
            }
            else
            {
                for (int i = 0; i < salary.Length; i++)
                {
                    if (salary[i] < sum)
                        Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
                }
            }
        }
        static void SearchCertainPost(string[] fullName, string[] post, int[] salary, string postName)
        {
            for (int i = 0; i < post.Length; i++)
            {
                if (post[i].ToLower()==postName.ToLower())
                    Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
            }
        }

        static void Main(string[] args)
        {
            //9. Программа для ведения досье работников. Есть 3 массива: фио, должность и зарплата.
            //В программе должна быть возможность добавить досье, вывести все досье в формате фио-должность-зп
            //(Иванов Иван Иванович – кассир – 25 000), удалить досье по номеру (номера начинаются с 1),
            //поиск досье по фамилии. Дополнительно: вывод всех досье с зп меньше или больше указанной,
            //вывод всех досье с указанной должностью. Можно придумать еще свои команды.

            string[] fullName = { };
            string[] post = { };
            int[] salary = { };
            bool isWork = true;
            Console.WriteLine("Добро пожаловать в программу для ведения досье работникв");
            while (isWork)
            {
                Console.Write("Add - добавить досье\n" +
                    "Print - вывести все досье\n" +
                    "Delete - удалить досье по номеру(начиная с 1)\n" +
                    "Search - поиск досье по фамилии\n" +
                    "Exit - выйти\n" +
                    "SearchCertainSalary - поиск по зарплате с ограничениями\n" +
                    "SearchCertainPost поиск по  должности\n" +
                    "Напишите команду: ");
                string solution = Console.ReadLine();
                Console.WriteLine();

                switch (solution.ToLower())
                {
                    case "add":
                        Console.Write("Введите ФИО работника: ");
                        string tmpFullName = Console.ReadLine();
                        Console.Write("Введите должность сотрудника: ");
                        string tmpPost = Console.ReadLine();
                        Console.Write("Введите зарплату сотрудника: "); 
                        int tmpSalary = Convert.ToInt32(Console.ReadLine());
                        AddDossier(ref fullName,ref post,ref salary,tmpFullName,tmpPost,tmpSalary);
                        Console.WriteLine("Досье добавлено!\n");
                        break;
                    case "print":
                        if(Check(fullName))
                            PrintDossier(fullName,post,salary);
                        break;
                    case "delete":
                        if(Check(fullName))
                        {
                            Console.Write("Введите номер досье,которе хотите удалить: ");
                            int indexDelete = Convert.ToInt32(Console.ReadLine());
                            if(indexDelete<=fullName.Length && indexDelete>0)
                            {
                                DeleteDossier(ref fullName, ref post, ref salary, indexDelete - 1);
                                Console.WriteLine("Удаление прошло успешно!\n");
                            }
                            else Console.WriteLine("Заданный номер вышел за границыы списка досье");
                            
                            break;
                        }
                        Console.WriteLine("Не ");
                        break;
                    case "search":
                        Console.Write("Введите фамилию работника: ");
                        string surName = Console.ReadLine();
                        int indexDossier = SeacrhDossier(surName, fullName);
                        if (indexDossier != -1)
                        {
                            Console.WriteLine("Ваше досье: ");
                            PrintDossier(fullName, post, salary);
                        }
                        else
                            Console.WriteLine("Человек с такой фамилией не найден\n");
                        break;
                    case "exit":
                        isWork = false;
                        break;
                    case "SearchCertainSalary":
                        Console.Write("Введите сумма с ограничением(>100000): \n");
                        string certain = Console.ReadLine();
                        SearchCertainSalary(fullName, post, salary, certain);
                        break;
                    case "searchcertainpost":
                        Console.Write("Введите должность работника: ");
                        string postName = Console.ReadLine();
                        SearchCertainPost(fullName, post, salary, postName);
                        break;
                    default:
                        break;
                }
            }


        }
    }
}
