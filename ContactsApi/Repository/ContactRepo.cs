using System.ComponentModel.Design;
using System.Data;
using ContactsApi.Models;
using Microsoft.Data.SqlClient;

namespace ContactsApi.Repository;

public class ContactRepo
{
    public static List<ContactDTO> GetAllContacts()
    {
        List<ContactDTO> contacts = new List<ContactDTO>();
        string connectionString = @"Data Source=DESKTOP-0CV7K6R\SQLEXPRESS;Integrated Security=True;Database=ContactsApp;Trusted_Connection=true;encrypt=false;";
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string getAllContactsQuery = "SELECT * FROM Contacts";
            using(SqlCommand command = new SqlCommand(getAllContactsQuery, connection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contacts.Add(new ContactDTO{
                            Id = Convert.ToInt32(reader["ID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                        });
                    }
                }
            }
        }

        return contacts;
    }
}
