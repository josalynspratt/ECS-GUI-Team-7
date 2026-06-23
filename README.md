# Project Instructions

### Project Details

* Visual Studio Version: 2026 (18.7.0)
* Target Framework: .NET 10.0

### Compilation Instructions

1. Open the project folder in Visual Studio 2026.
2. Ensure the project path is short (e.g., C:\Project) to avoid MSB3577 build errors.
3. Select Build > Clean Solution.
4. Select Build > Build Solution.

### Database Setup

This project uses a local SQL Server database. The connection string has been updated to use the |DataDirectory| attribute to automatically locate the database files. Please ensure both ECSDatabase.mdf and ECSDatabase_log.ldf are included in the project folder.

### Running the Application

1. Right-click your project in Solution Explorer and select Set as Startup Project.
2. Press F5 to run the application.

### LOGIN/BADGE:
99999, B999 (ADMIN)
10020, B101 (Skill level: Standard)
10543, B102 (Skill level: Welding)
10895, B103 (Skill Level: Precision Calibration)
11247, B104 (Skill Level: Forklift)
11657, B105 (Skill level: Forklift)