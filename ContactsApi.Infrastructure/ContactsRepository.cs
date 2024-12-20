﻿using Dapper;
using Microsoft.Data.Sqlite;
using ContactsApi.Core.Models;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Infrastructure
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly SqliteConnection _connection = new($"Data Source={AppContext.BaseDirectory}\\Contacts.db");

        public async Task<int> DeleteContact(string contactId)
        {
            DynamicParameters parameters = new();

            parameters.Add("Id", contactId);

            string query = "DELETE FROM Contacts WHERE Id = @Id";

            using SqliteConnection connection = _connection;

            return await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            string query = "SELECT * FROM Contacts";

            using SqliteConnection connection = _connection;

            List<Contact>? contacts = (await connection.QueryAsync<Contact>(query)).ToList();

            return contacts;
        }

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

        public async Task<int> UpdateContact(Contact contact)
        {
            DynamicParameters parameters = new();

            parameters.Add("PhoneNumber", contact.PhoneNumber);
            parameters.Add("FirstName", contact.FirstName);
            parameters.Add("LastName", contact.LastName);
            parameters.Add("Email", contact.Email);
            parameters.Add("Id", contact.Id);

            string query = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";

            using SqliteConnection connection = _connection;

            return await connection.ExecuteAsync(query, parameters);
        }
    }
}
