# 🚗 Driving License Management System (DVLD)

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-3--Tier-blue?style=for-the-badge)

## 📌 About The Project
The **Driving License Management System (DVLD)** is an enterprise-level desktop solution built to manage the complete lifecycle of drivers and licenses. It demonstrates a deep understanding of software engineering principles, strictly layered architecture, and pure database logic.

## ⚙️ Tech Stack & Highlights
- **Architecture:** Strict **3-Tier Architecture** (Presentation, Business Logic, and Data Access Layers).
- **Communication:** Uses **Data Transfer Objects (DTOs)** for secure and efficient data passing between layers.
- **Database Logic:** Built using **ADO.NET** with pure SQL queries (No ORMs) for maximum performance and full control over data flow.
- **Logging:** Includes a dedicated **Logs** module for system activity tracking.

## ✨ Key Modules
- **License Management:** Full handling of Local and International licenses (Issuance, Renewal, Replacement).
- **Test Scheduling:** Relational system for Vision, Written, and Street tests.
- **Financial Module:** Automated calculation of fines and application fees for detaining and releasing licenses.
- **User Security:** Role-based access control and secure authentication.

## 📂 Project Structure
The repository is organized by logical layers:
- `DTOs/` - Data Transfer Objects.
- `DVLD/` - Presentation Layer (User Interface).
- `DVLD Business Layer/` - Core business rules and validations.
- `DVLD Data Access Layer/` - Database connectivity and ADO.NET logic.
- `Logs/` - System logging components.
- `Setup/` - Contains the logic and assets for the deployment package.

## 🚀 Installation & Deployment
The system features a **Professional Installer** that automates the entire setup process:
1. Go to the **[Releases](../../releases)** section on the right side of this repository.
2. Download the `setup.exe`.
3. Run the installer, which will:
   - Install the project binaries on your machine.
   - **Automatically install and configure the SQL Server database.**
   - **Handle the connection string linking** between the application and the local database.

---
**Author:** Ahmed Ramadan Abdel Rady  
[LinkedIn Profile](https://www.linkedin.com/in/ahm3d-ramadan/)