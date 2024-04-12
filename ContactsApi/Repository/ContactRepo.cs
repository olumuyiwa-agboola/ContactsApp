using System.Data;
using ContactsApi.Models;
using ContactsApi.Exceptions;
using Microsoft.Data.SqlClient;

namespace ContactsApi.Repository;

public class ContactRepo
{
    #region GetAllContacts()
    public static List<Contact> GetAllContacts()
    {
        List<Contact> contacts = [];
        string connectionString = @"Data Source=DESKTOP-0CV7K6\SQLEXPRESS;Integrated Security=True;Database=ContactsApp;Trusted_Connection=true;encrypt=false;";
        using(SqlConnection connection = new(connectionString))
        {
            try
            {
                connection.Open();

                string getAllContactsQuery = "SELECT * FROM Contacts";
                using (SqlCommand command = new(getAllContactsQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contacts.Add(new Contact
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The following exception was caught:\nName - {ex.GetType().Name}\nMessage - \"{ex.Message}\"");
                throw;
            }
        }

        return contacts;
    }
    #endregion

    #region GetContactById()
    public static Contact GetContactById(int id)
    {
        Contact contact = new();
        string connectionString = @"Data Source=DESKTOP-0CV7K6R\SQLEXPRESS;Integrated Security=True;Database=ContactsApp;Trusted_Connection=true;encrypt=false;";
        using (SqlConnection connection = new(connectionString))
        {
            try
            {
                connection.Open();
                string getContactByIdQuery = $"SELECT * FROM Contacts WHERE Id = {id}";
                using (SqlCommand command = new(getContactByIdQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            contact = new Contact
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString()
                            };
                        }
                        else
                        {
                            throw new NotFoundException(message: $"No record was found for contact with Id: {id}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The following exception was caught:\nName - {ex.GetType().Name}\nMessage - \"{ex.Message}\"");
                throw;
            }
        }

        return contact;
    }
    #endregion

    #region AddContact()
    public static AddContactResponse AddContact(AddContactRequest request)
    {
        string? firstName = request.FirstName;
        string? lastName = request.LastName;
        string? phoneNumber = request.PhoneNumber;

        AddContactResponse response = new();
        Contact newContact = new();

        string connectionString = @"Data Source=DESKTOP-0CV7K6R\SQLEXPRESS;Integrated Security=True;Database=ContactsApp;Trusted_Connection=true;encrypt=false;";
        string addContactQuery = $"INSERT INTO Contacts (FirstName, LastName, PhoneNumber) OUTPUT inserted.* VALUES ('{firstName}', '{lastName}', '{phoneNumber}')";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new(addContactQuery, connection))
            {
                command.CommandType = CommandType.Text;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newContact.Id = Convert.ToInt32(reader["ID"]);
                            newContact.FirstName = reader["FirstName"].ToString();
                            newContact.LastName = reader["LastName"].ToString();
                            newContact.PhoneNumber = reader["PhoneNumber"].ToString();
                        }

                        response.ResponseCode = 201;
                        response.ResponseMessage = "Contact added successfully!";
                        response.NewContact = newContact;
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.ResponseCode = 500;
                    response.ResponseMessage = "An error occured";
                    Console.WriteLine($"The following exception was caught:\nName - {ex.GetType().Name}\nMessage - \"{ex.Message}\"");
                    throw;
                }
            }
        }
    }
    #endregion

    #region DeleteContact()
    public static DeleteContactResponse DeleteContact(int id)
    {
        DeleteContactResponse response = new();
        Contact deletedContact = GetContactById(id);

        string connectionString = @"Data Source=DESKTOP-0CV7K6R\SQLEXPRESS;Integrated Security=True;Database=ContactsApp;Trusted_Connection=true;encrypt=false;";
        string deleteContactQuery = $"DELETE FROM Contacts WHERE Id = {id}";

        using (SqlConnection connection = new(connectionString))
        {
            using (SqlCommand command = new(deleteContactQuery, connection))
            {
                command.CommandType = CommandType.Text;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    response.ResponseCode = 201;
                    response.ResponseMessage = "Contact deleted successfully!";
                    response.DeletedContact = deletedContact;

                    return response;
                }
                catch (Exception ex)
                {
                    response.ResponseCode = 500;
                    response.ResponseMessage = "An error occured";
                    Console.WriteLine($"The following exception was caught:\nName - {ex.GetType().Name}\nMessage - \"{ex.Message}\"");
                    return response;
                }
            }
        }
    }
    #endregion

    #region UpdateContact()
    public static UpdateContactResponse UpdateContact(int id, UpdateContactRequest request)
    {
        string? firstName = request.FirstName;
        string? lastName = request.LastName;
        string? phoneNumber = request.PhoneNumber;

        UpdateContactResponse response = new();

        string connectionString = @"Data Source=DESKTOP-0CV7K6R\SQLEXPRESS;Integrated Security=True;Database=ContactsApp;Trusted_Connection=true;encrypt=false;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string updateContactQuery = $"UPDATE Contacts SET FirstName='{firstName}', LastName='{lastName}', PhoneNumber='{phoneNumber}' WHERE Id={id}";
            using (SqlCommand command = new(updateContactQuery, connection))
            {
                command.CommandType = CommandType.Text;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    response.ResponseCode = 201;
                    response.ResponseMessage = "Contact updated successfully!";
                    response.UpdatedContact = GetContactById(id);

                    return response;
                }
                catch (Exception ex)
                {
                    response.ResponseCode = 500;
                    response.ResponseMessage = "An error occured";
                    Console.WriteLine($"The following exception was caught:\nName - {ex.GetType().Name}\nMessage - \"{ex.Message}\"");
                    throw;
                }
            }
        }
    }
    #endregion
}
