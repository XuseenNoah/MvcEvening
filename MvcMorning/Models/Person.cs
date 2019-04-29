using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcMorning.Models
{
    public class Person
    {

        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Db"].ConnectionString;

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Addres { get; set; }
        [Required]
        public string Phone { get; set; }


        public static List<Person> GetListPerson()
        {
            return new List<Person> {
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
                new Person{Id=1,Name="Ahmed",Addres="Goljano"},
            };
        }

        internal static void CreatePerson(Person person)
        {
            using (var conn = new SqlConnection(connectionString))
                using(var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Persons VALUES (@Name,@Addres,@Phone,getdate())";
                cmd.Parameters.AddWithValue("@Name", person.Name);
                cmd.Parameters.AddWithValue("@Addres", person.Addres);
                cmd.Parameters.AddWithValue("@Phone", person.Phone);
                conn.Open();
                cmd.ExecuteNonQuery();

            }

        }
    }
}