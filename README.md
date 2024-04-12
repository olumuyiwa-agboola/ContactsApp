This repository contains my first 'real' attempt at building an API with ASP.NET Core. The ContactsApi project implements the following API:

| API | Description | Request body | Response body |
|-----|-------------|--------------|---------------|
|GET /api/contacts | Retrieve all contacts from the database | None | Array of contact objects |
|GET /api/contacts/{id} | Get a contact by its ID | None | Single contact object |
|POST /api/contacts | Add a contact to the database | Single contact object | Operation response object |
|PUT /api/contacts/{id} | Update the details of the contact whose ID is given | Single contact object | Operation response object |
|Delete /api/contacts/{id} | Delete a contact from the database | None | Operation response object |
