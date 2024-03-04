-- Создание таблицы PickPoints
CREATE TABLE PickPoints (
    PickupPointId INT IDENTITY(1,1) PRIMARY KEY,
    PickupPointAddress NVARCHAR(100) NOT NULL,
    PickupPointDescription NVARCHAR(100) NOT NULL,
    PickupPointRating INT NOT NULL
);

-- Создание таблицы Roles
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);

-- Создание таблицы Sellers
CREATE TABLE Sellers (
    SellerId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    SellerPassport NVARCHAR(10) NOT NULL,
    SellerINN NVARCHAR(12) NOT NULL,
    SellerPhone NVARCHAR(10) NOT NULL
);

-- Создание таблицы Status
CREATE TABLE Status (
    StatusId INT IDENTITY(1,1) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);

-- Создание таблицы Employees
CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    EmployeePassport NVARCHAR(10) NOT NULL,
    EmployeePhone NVARCHAR(10) NOT NULL,
    EmployeeSalary INT NOT NULL,
    PickupPointId INT NOT NULL,
    FOREIGN KEY (PickupPointId) REFERENCES PickPoints(PickupPointId)
);

-- Создание таблицы Users
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    UserSurname NVARCHAR(50) NOT NULL,
    UserEmail NVARCHAR(50) NOT NULL,
    UserPassword NVARCHAR(50) NOT NULL,
    RoleId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);

-- Создание таблицы Shops
CREATE TABLE Shops (
    ShopId INT IDENTITY(1,1) PRIMARY KEY,
    ShopName NVARCHAR(50) NOT NULL,
    ShopDescription NVARCHAR(100) NOT NULL,
    ShopRating INT NOT NULL,
    SellerId INT NOT NULL,
    FOREIGN KEY (SellerId) REFERENCES Sellers(SellerId)
);

-- Создание таблицы Carts
CREATE TABLE Carts (
    CartId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Создание таблицы Orders
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    OrderPrice INT NOT NULL,
    PickupPointId INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    OrderExpDate DATETIME NOT NULL,
    UserId INT NOT NULL,
    StatusId INT NOT NULL,
    FOREIGN KEY (PickupPointId) REFERENCES PickPoints(PickupPointId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (StatusId) REFERENCES Status(StatusId)
);

-- Создание таблицы Products
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(50) NOT NULL,
    ProductDescription NVARCHAR(100) NOT NULL,
    ProductPrice INT NOT NULL,
    ProductRating INT NOT NULL,
    ProductQuantity INT NOT NULL,
    ShopId INT NOT NULL,
    FOREIGN KEY (ShopId) REFERENCES Shops(ShopId)
);

-- Создание таблицы Issuances
CREATE TABLE Issuances (
    IssuanceId INT IDENTITY(1,1) PRIMARY KEY,
    IssuanceDate DATETIME NOT NULL,
    IssuanceRating INT NOT NULL,
    OrderId INT NOT NULL,
    EmployeeId INT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- Создание таблицы CartItems
CREATE TABLE CartItems (
    CartItemId INT IDENTITY(1,1) PRIMARY KEY,
    CartItemQuantity INT NOT NULL,
    CartId INT NOT NULL,
    ProductId INT NOT NULL,
    FOREIGN KEY (CartId) REFERENCES Carts(CartId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- Создание таблицы OrderItems
CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderItemQuantity INT NOT NULL,
    OrderItemRating INT NOT NULL,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
