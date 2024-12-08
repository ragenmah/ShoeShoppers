CREATE DATABASE SimonNeckieDB

USE SimonNeckieDB;



CREATE TABLE Categories
(
	CategoryId INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(100) NOT NULL,
	CategoryImageUrl VARCHAR(MAX)  NOT NULL,
	IsActive BIT DEFAULT 1    NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE()
);


CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,    -- Unique identifier for each product
    ProductName NVARCHAR(100) NOT NULL,               -- Name of the product
    ProductDescription NVARCHAR(MAX),                 -- Detailed description of the product
    Price DECIMAL(18, 2) NOT NULL,             -- Original price of the product
    DiscountPercentage DECIMAL(5, 2) DEFAULT 0,-- Discount percentage (e.g., 10 for 10%)
    DiscountedPrice AS (Price - (Price * DiscountPercentage / 100)), -- Calculated field for the discounted price
    StockQuantity INT NOT NULL DEFAULT 0,      -- Number of shoes in stock
    Size NVARCHAR(30) NOT NULL,                -- Sizes available (e.g., 7, 8, 9)
    Color NVARCHAR(50) NOT NULL,               -- Color of the shoeStockQuantity INT NOT NULL DEFAULT 0,      -- Number of items in stock
    CategoryId INT NOT NULL,              -- Category of the product (e.g., Men's Shoes, Casual Shoes)
    ImageUrl NVARCHAR(255),                    -- Path to the product image as MainImageUrl
    CreatedAt DATETIME DEFAULT GETDATE(),      -- Timestamp when the product was added
    UpdatedAt DATETIME DEFAULT GETDATE(),      -- Timestamp when the product was last updated
    IsActive BIT DEFAULT 1                     -- Status of the product (1 for active, 0 for inactive)
	
    -- Define Foreign Key Constraint
	CONSTRAINT FK_Category FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE CASCADE
);

CREATE TABLE ProductImages
( 
	ImageId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    ImageUrl VARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    -- Define Foreign Key Constraint
    CONSTRAINT FK_Product FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE
);


CREATE TABLE Roles
(
	RoleId INT PRIMARY KEY IDENTITY(1,1), -- Unique identifier for each role
    RoleName  VARCHAR(50) NOT NULL,       -- Name of the role (e.g., Admin, User)
    CreatedAt DATETIME DEFAULT GETDATE(), -- Timestamp when the role was created
    UpdatedAt DATETIME DEFAULT GETDATE()  -- Timestamp for the last update

);

INSERT INTO Roles (RoleName)
    VALUES('Admin'),('Member');


CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,       -- Member's first name
    LastName VARCHAR(50) NOT NULL,        -- Member's last name
    Email VARCHAR(100) NOT NULL UNIQUE,   -- Member's email (must be unique)
    Password VARCHAR(255) NOT NULL,   -- Hashed password for security
    RoleId INT FOREIGN KEY  REFERENCES Roles(RoleId) ON DELETE CASCADE NOT NULL, 
	MobileNumber VARCHAR(15),              -- Optional phone number
    DateOfBirth DATE,                      -- Optional date of birth
    Address VARCHAR(255),                 -- Optional address
	City VARCHAR(50),                     -- Optional city
    PostalCode VARCHAR(10),               -- Optional postal code
    Country VARCHAR(50),                  -- Optional country
    AccountImage VARCHAR(255),            -- Path to the profile image (optional)
    CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE()
);

INSERT INTO Users (FirstName, LastName, Email, Password, RoleId)
        VALUES ('Admin', 'USER','admin@admin.com', 'admin', 1)

CREATE TABLE ProductReviews
(
	ReviewId INT IDENTITY(1,1) PRIMARY KEY,
	Rating INT NOT NULL,
	Comment VARCHAR(MAX) NULL,
	ProductId INT FOREIGN KEY  REFERENCES Products(ProductId) ON DELETE CASCADE NOT NULL, 
	UserId INT FOREIGN KEY  REFERENCES Users(UserId) ON DELETE CASCADE NOT NULL, 
	CreatedAt DATETIME DEFAULT GETDATE(),
	IsReplied BIT DEFAULT 0,  -- 0 = not replied, 1 = replied
    RepliedAt DATETIME NULL,  -- When the review was replied to
    RepliedBy NVARCHAR(100) NULL,  -- Who replied to the review (admin/agent)
	ResponseContent VARCHAR(MAX) NULL          -- Optional field for the response content (reply from admin)

);


CREATE TABLE WishList
(
	WishlistId INT IDENTITY(1,1) PRIMARY KEY,
	ProductId INT FOREIGN KEY  REFERENCES Products(ProductId) ON DELETE CASCADE NOT NULL, 
	UserId INT FOREIGN KEY  REFERENCES Users(UserId) ON DELETE CASCADE NOT NULL, 
	CreatedAt DATETIME DEFAULT GETDATE(),
);

CREATE TABLE Cart
(
	CartId INT IDENTITY(1,1) PRIMARY KEY,
	ProductId INT FOREIGN KEY  REFERENCES Products(ProductId) ON DELETE CASCADE NOT NULL, 
	Quantity INT NULL,
	UserId INT FOREIGN KEY  REFERENCES Users(UserId) ON DELETE CASCADE NOT NULL, 
	CreatedAt DATETIME DEFAULT GETDATE(),
);


CREATE TABLE ContactUs
(
	ContactUsId INT IDENTITY(1,1) PRIMARY KEY,
	FullName VARCHAR(50) NOT NULL, 
	Email VARCHAR(100) NOT NULL UNIQUE,
	PhoneNumber NVARCHAR(15),
	Message VARCHAR(MAX),
	CreatedAt DATETIME DEFAULT GETDATE(),
	IsReplied BIT DEFAULT 0,  -- 0 = not replied, 1 = replied
    RepliedAt DATETIME NULL,  -- When the review was replied to
    RepliedBy NVARCHAR(100) NULL  -- Who replied to the review (admin/agent)
);


CREATE TABLE Payment
(
	PaymentId INT IDENTITY(1,1) PRIMARY KEY,
	OwnerName VARCHAR(50) NOT NULL, 
	CardNo VARCHAR(50) NULL,
	ExpiryDate VARCHAR(50) NULL,
	CvvNo INT NULL,
	BillingAddress VARCHAR(MAX) NULL,
	PaymentMethod VARCHAR(50) NULL -- E.g., 'Credit Card', 'PayPal', etc.
);

CREATE TABLE Orders
(
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    OrderNumber VARCHAR(50) NOT NULL,            -- Unique order number
    UserId INT NOT NULL,                          -- Reference to the user placing the order
    Status VARCHAR(50) NOT NULL,                  -- E.g., 'Pending', 'Shipped', 'Completed', etc.
    PaymentId INT NOT NULL,                       -- Reference to the payment for this order
    OrderDate DATETIME NOT NULL,                  -- Date and time of order
    IsCancelled BIT NOT NULL DEFAULT 0,           -- Indicates if the order is cancelled
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE,  -- Linking to Users table
    FOREIGN KEY (PaymentId) REFERENCES Payment(PaymentId) ON DELETE CASCADE   -- Linking to Payment table
);

CREATE TABLE OrderItems
(
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,                        -- Reference to the order
    ProductId INT NOT NULL,                      -- Reference to the product
    Quantity INT NOT NULL,                       -- Quantity of the product ordered
    UnitPrice DECIMAL(18,2) NOT NULL,            -- Price per unit at the time of order
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,   -- Linking to Orders table
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE  -- Linking to Products table
);

CREATE TABLE CustomerEnquiries
(
    EnquiryId INT IDENTITY(1,1) PRIMARY KEY,    -- Unique ID for each enquiry
    CustomerName VARCHAR(100) NOT NULL,           -- Name of the customer
    CustomerEmail VARCHAR(100) NOT NULL,          -- Email of the customer
    PhoneNumber NVARCHAR(15) NULL,                -- Optional phone number
    MessageType VARCHAR(50) NOT NULL,             -- Type of message (e.g., 'Enquiry', 'Feedback', 'Comment')
    MessageContent VARCHAR(MAX) NOT NULL,         -- Content of the enquiry/feedback/comment
    Status VARCHAR(50) DEFAULT 'Pending',         -- Current status of the enquiry (e.g., Pending, Responded, Closed)
    CreatedAt DATETIME DEFAULT GETDATE(),         -- Timestamp when the message was created
    RepliedAt DATETIME NULL,                      -- Timestamp when the reply was sent (if any)
    RepliedBy NVARCHAR(100) NULL,                 -- Optional: Who replied (admin/agent)
    ResponseContent VARCHAR(MAX) NULL             -- Optional: Content of the admin's response to the enquiry
);