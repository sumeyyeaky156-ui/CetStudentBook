## Assignment: Books CRUD

### What I implemented
- Added **Book** model with validations (Data Annotations)
- Added **DbSet<Book> Books** to `ApplicationDbContext`
- Created EF Core migrations and database schema for **Books** table
- Implemented Books CRUD pages manually (no scaffolding):
    - **List**: `/Books`
    - **Create**: `/Books/Create`
    - **Edit/Update**: `/Books/Edit/{id}`
    - **Delete (confirmation + delete)**: `/Books/Delete/{id}`
- Added **Books** link to the main navigation menu (`_Layout.cshtml`)

### How to run locally
```bash
dotnet restore
dotnet run