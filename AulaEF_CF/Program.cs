using AulaEF_CF.Context;
using AulaEF_CF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaEF_CF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new PersonContext())
            {
                //Insert
                context.Persons.Add(new Models.Person()
                { Name = "Weslen", Phone = "16-99300 7575" });
                context.SaveChanges();

                //Select all
                var persons = new PersonContext().Persons.ToList();
                foreach(var person in persons)
                {
                    Console.WriteLine(person.ToString());
                }
                
                //Select específico
                string n = Console.ReadLine();  
                Person find = new PersonContext().Persons.FirstOrDefault(c => c.Name == n);
                if (find != null) Console.WriteLine(find.ToString());

                //Remove
                context.Entry(find).State = EntityState.Deleted;
                context.Persons.Remove(find);
                context.SaveChanges();

                Console.ReadKey();
            }
        }
    }
}
