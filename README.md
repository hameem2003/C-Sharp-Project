# Mobile Retail Shop

The **Mobile Retail Shop** is a comprehensive application designed to manage a mobile retail business. It features a robust system that supports different user roles, including Admin, Shop Owner, and Customer. The application streamlines the management of shops, products, and customer purchases, providing an efficient and user-friendly experience.

## User Roles

### 1. Admin
- **Full Access:** Admins have complete control over the system.
- **Manage Users:** Admins can add new Admins, Shop Owners, and Customers.
- **Manage Shops:** Admins can create and manage shops, as well as assign Shop Owners to multiple shops.
- **Manage Products:** Admins have access to all products across all shops.
- **View Reports:** Admins can generate and view reports on sales, inventory, and user activity.

### 2. Shop Owner
- **Shop Management:** Shop Owners can manage their shops, including adding, editing, and removing products.
- **Multiple Shops:** A Shop Owner can be assigned to multiple shops and manage them independently.
- **Inventory Control:** Shop Owners can monitor and update the inventory for each shop.

### 3. Customer
- **Browse Products:** Customers can browse products available in the shops.
- **Shopping Cart:** Customers can add multiple products to their cart for a single purchase.
- **Checkout:** Customers can pay for their purchases using a card.
- **Order History:** Customers can view their past orders and track current orders.

## Features

- **Role-Based Access Control:** The system provides different levels of access depending on the user role.
- **Multi-Shop Management:** Shop Owners can manage multiple shops, each with its own set of products and inventory.
- **Cart Functionality:** Customers can add multiple products to their cart, providing a convenient shopping experience.
- **Secure Payment:** Customers can securely pay for their purchases using a card.
- **User Management:** Admins can easily manage user roles, add new users, and assign permissions.

## Technologies Used

- **C#**
- **.NET Framework**
- **SQL Database**
- **Guna.UI2.WinForms** (for UI components)

## Getting Started

### Prerequisites
- Visual Studio with .NET Framework support
- SQL Server for database management

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/hameem2003/C-Sharp-Project.git
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Set up the SQL Database:
   - Create a new database in SQL Server.
   - Update the connection string in the application to point to your database.
5. Build and run the application.


## Usage
- **Admin:** Log in with Admin credentials to manage users, shops, and products.
- **Shop Owner:** Log in with Shop Owner credentials to manage your assigned shops.
- **Customer:** Create a customer account, browse products, add items to your cart, and proceed to checkout.
## SQL Schema

-- Product Information Table
```sql
CREATE TABLE [dbo].[Product Information] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [Picture]        IMAGE           NULL,
    [Company Name]   VARCHAR (100)   NOT NULL,
    [Model]          VARCHAR (100)   NOT NULL,
    [SIM]            INT             NOT NULL,
    [RAM]            VARCHAR (6)     NOT NULL,
    [ROM]            VARCHAR (6)     NOT NULL,
    [Color]          VARCHAR (100)   NOT NULL,
    [Price]          INT             NOT NULL,
    [Discount]       INT             NOT NULL,
    [Total Review]   DECIMAL (18, 5) NULL,
    [Total Reviewer] INT             NULL,
    [Shop ID]        INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([Shop ID]) REFERENCES [dbo].[Shop Information] ([ID])
);
```

-- Shop Accounts Table
```sql
CREATE TABLE [dbo].[Shop Accounts] (
    [Shop ID]         INT             NOT NULL,
    [Current Balance] DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [Total Withdraw]  DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Shop ID] ASC),
    FOREIGN KEY ([Shop ID]) REFERENCES [dbo].[Shop Information] ([ID])
);
```
-- Transaction Table
```sql
CREATE TABLE [dbo].[Transaction] (
    [ID]               INT      IDENTITY (1, 1) NOT NULL,
    [User ID]          INT      NOT NULL,
    [Transaction Date] DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([User ID]) REFERENCES [dbo].[User Information] ([ID])
);
```
-- Transaction Details Table
```sql
CREATE TABLE [dbo].[Transaction Details] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [Transaction ID] INT             NOT NULL,
    [Shop ID]        INT             NOT NULL,
    [Product ID]     INT             NOT NULL,
    [Quantity]       INT             NOT NULL,
    [Total Price]    DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([Transaction ID]) REFERENCES [dbo].[Transaction] ([ID]),
    FOREIGN KEY ([Shop ID]) REFERENCES [dbo].[Shop Information] ([ID]),
    FOREIGN KEY ([Product ID]) REFERENCES [dbo].[Product Information] ([ID])
);
```
-- User Information Table
```sql
CREATE TABLE [dbo].[User Information] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Email]        VARCHAR (100) NOT NULL,
    [Phone Number] VARCHAR (15)  NOT NULL,
    [City]         VARCHAR (50)  NOT NULL,
    [Password]     VARCHAR (100) NOT NULL,
    [User Type]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
```

## Roadmap      Database connectionString process




## Contributing
- [**Mustafa Alam Hameem**](https://github.com/hameem2003)
- [**Sadikuzzaman Rakib**](https://github.com/Sadikuzzamanrakib)
  
Contributions are welcome! Please submit a pull request or open an issue to discuss changes.

## License
This project is licensed under the [MIT License](https://github.com/hameem2003/C-Sharp-Project?tab=MIT-1-ov-file).
