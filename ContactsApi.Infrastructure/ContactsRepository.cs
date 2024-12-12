using Dapper;
using Microsoft.Data.Sqlite;
using ContactsApi.Core.Models;
using ContactsApi.Core.Abstractions;
using System.Data;

namespace ContactsApi.Infrastructure
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly SqliteConnection _connection = new($"Data Source={AppContext.BaseDirectory}\\Contacts.db");

        public async Task<Contact?> GetContact(string contactId)
        {
            DynamicParameters parameters = new();
            parameters.Add("Id", contactId);

            string query = "SELECT * FROM Contacts WHERE Id = @Id";

            using SqliteConnection connection = _connection;

            Contact? contact =  (await connection.QueryAsync<Contact>(query, parameters)).FirstOrDefault();

            return contact;
        }

        public async Task<int> SaveContact(Contact contact)
        {
            DynamicParameters parameters = new();

            parameters.Add("PhoneNumber", contact.PhoneNumber);
            parameters.Add("FirstName", contact.FirstName);
            parameters.Add("LastName", contact.LastName);
            parameters.Add("Email", contact.Email);
            parameters.Add("Id", contact.Id);

            string query = "INSERT INTO Contacts (Id, FirstName, LastName, Email, PhoneNumber) VALUES (@Id, @FirstName, @LastName, @Email, @PhoneNumber)";

            using SqliteConnection connection = _connection;

            return await connection.ExecuteAsync(query, parameters);
        }
    }
}
