using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvc.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public String City { get; set; }


        static public List<Person> People = new List<Person>
        {
            new Person
            {
                Name = "Fredrik Ason",
                PhoneNumber = "0707775552",
                City = "London",
            },

               new Person
            {
                Name = "Anna Brodde",
                PhoneNumber = "0735889741",
                City = "Moskva",
            },

                new Person
            {
                Name = "Nu Tan Tu",
                PhoneNumber = "0709876552",
                City = "Beijing",
            },

                new Person
            {
                Name = "Ben Dover",
                PhoneNumber = "0798654231",
                City = "New York",
            },

                new Person
            {
                Name = "Dimitrij Soroka",
                PhoneNumber = "0765867714",
                City = "Ekaterinburg",
            },

                new Person
            {
                Name = "Lada Ås",
                PhoneNumber = "0776656651",
                City = "Bredaryd",
            },

        };
    }
}