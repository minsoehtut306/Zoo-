# Zoo Management Application (C# WinForms)

## Overview
A Windows Forms application for managing a zoo database. It supports **Oracle** (relational) and **MongoDB** (document) backends, with forms to add/update animals, enclosures, staff, vets, species, and zones.

---

## Project Structure
```
Zoo-/
├─ app/ZooApp/
│  ├─ ZooApp.sln                 # Visual Studio solution
│  ├─ ZooApp.csproj              # Project file (.NET Framework 4.7.2, WinForms)
│  ├─ *.cs / *.Designer.cs / *.resx  # Forms and resources (AddAnimalForm, AddStaffForm, etc.)
│  ├─ DatabaseHelper.cs          # Oracle DB helper (set connection string here)
│  ├─ MongoDBHelper.cs           # MongoDB helper (configure client/database)
│  └─ App.config                 # Binding redirects & Oracle provider registration
├─ mongo/                        # JSON data to mirror the relational schema in MongoDB
│  └─ *.json / README.md
├─ *.sql                         # Oracle SQL scripts (schema, indexes, sample data)
│  ├─ zoo.sql
│  ├─ small.sql
│  ├─ milestone2tables.sql
│  ├─ Index.sql
│  └─ Query Scripts.sql
└─ README.md (this file)
```

---

## Tech Stack
- **C# / .NET Framework 4.7.2** (Windows Forms)
- **Oracle Managed Data Access** (`Oracle.ManagedDataAccess` via NuGet)
- **MongoDB.Driver** (optional NoSQL backend)
- Visual Studio 2019/2022

---

## Getting Started

### 1) Oracle Setup (Relational)
1. Create an Oracle user/schema.
2. Run the SQL scripts in order (typical):
   - `zoo.sql` (schema & seed) → `Index.sql` (indexes) → `small.sql` (optional sample)  
     *(consult `Query Scripts.sql` for example queries)*
3. Open `app/ZooApp/DatabaseHelper.cs` and set your Oracle connection string:
   ```csharp
   // DatabaseHelper.cs
   public static string connectionString =
       "User Id=YOUR_USER;Password=YOUR_PASS;Data Source=HOST:PORT/SERVICE;";
   ```
4. Build and run the solution.

### 2) MongoDB Setup (Document)
1. Start MongoDB server locally or use a hosted cluster.
2. In `mongo/README.md`, follow the mapping and import the JSON files as individual collections.
3. In `MongoDBHelper.cs`, initialise the client and database (add your connection URI and DB name).
4. Build and run the solution. Switch the code paths to use MongoDB where required.

> **Note:** The app is configured by default to use Oracle. MongoDB paths are provided for alternative/extra functionality—adjust your forms/services accordingly.

## Build & Run (Visual Studio)
1. Open `app/ZooApp/ZooApp.sln` in Visual Studio.
2. Restore NuGet packages if prompted (MongoDB.Driver, Oracle.ManagedDataAccess).
3. Set **ZooApp** as startup project.
4. Press **F5** to run.

---

## Team Members 

- Min Soe Htut
- Joel 
- Dolf

---


## Notes
- App.config already registers the Oracle provider; you still need a valid Oracle connection string.
- Many forms are provided (e.g., **AddAnimalForm**, **AddEnclosureForm**, **AddStaffForm**, **VetForm**, **SelectSpeciesGroupForm**, etc.).
- `.resx` files hold UI resources; avoid moving them without updating the `.csproj`.
- The repo contains a `.git/` directory from the original project; you may remove it before publishing your own repository.

This project was completed as part of the Bachelor of Computer Science degree at the University of Waikato.  
It is published here solely for educational and portfolio purposes, to showcase my skills in software development.  

All code presented is me and my team meamber own work. Course-specific materials such as assignment descriptions or test data are not included to respect university policies.  

