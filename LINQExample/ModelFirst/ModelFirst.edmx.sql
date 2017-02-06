
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/06/2017 17:44:35
-- Generated from EDMX file: D:\Deepa\Training\GitHub\DotNet\LINQExample\ModelFirst\ModelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [order];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_ClientOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientClientAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientAddresses] DROP CONSTRAINT [FK_ClientClientAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductOrderDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK_ProductOrderDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOrderDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK_OrderOrderDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientAddressOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_ClientAddressOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[ClientAddresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientAddresses];
GO
IF OBJECT_ID(N'[dbo].[OrderDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [clientID] int IDENTITY(1,1) NOT NULL,
    [clientName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [productID] int IDENTITY(1,1) NOT NULL,
    [productName] nvarchar(50)  NOT NULL,
    [qty] int  NOT NULL,
    [price] float  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [orderID] int IDENTITY(1,1) NOT NULL,
    [clientID] int  NOT NULL,
    [addresssID] int  NOT NULL,
    [orderDate] datetime  NOT NULL,
    [orderAmount] float  NOT NULL,
    [expDeliveryDate] datetime  NULL,
    [actDeliveryDate] datetime  NULL,
    [countOfItems] int  NOT NULL
);
GO

-- Creating table 'ClientAddresses'
CREATE TABLE [dbo].[ClientAddresses] (
    [addresssID] int IDENTITY(1,1) NOT NULL,
    [clientID] int  NOT NULL,
    [addressType] int  NOT NULL,
    [Line1] nvarchar(50)  NOT NULL,
    [Line2] nvarchar(50)  NULL,
    [City] nvarchar(20)  NOT NULL,
    [State] nvarchar(30)  NOT NULL,
    [ZipCode] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [orderID] int  NOT NULL,
    [ItemID] int IDENTITY(1,1) NOT NULL,
    [productID] int  NOT NULL,
    [purchasedQty] int  NOT NULL,
    [purchasePrice] nvarchar(max)  NOT NULL,
    [purchaseAmount] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [clientID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([clientID] ASC);
GO

-- Creating primary key on [productID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([productID] ASC);
GO

-- Creating primary key on [orderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([orderID] ASC);
GO

-- Creating primary key on [addresssID] in table 'ClientAddresses'
ALTER TABLE [dbo].[ClientAddresses]
ADD CONSTRAINT [PK_ClientAddresses]
    PRIMARY KEY CLUSTERED ([addresssID] ASC);
GO

-- Creating primary key on [orderID], [ItemID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([orderID], [ItemID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [clientID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_ClientOrder]
    FOREIGN KEY ([clientID])
    REFERENCES [dbo].[Clients]
        ([clientID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientOrder'
CREATE INDEX [IX_FK_ClientOrder]
ON [dbo].[Orders]
    ([clientID]);
GO

-- Creating foreign key on [clientID] in table 'ClientAddresses'
ALTER TABLE [dbo].[ClientAddresses]
ADD CONSTRAINT [FK_ClientClientAddress]
    FOREIGN KEY ([clientID])
    REFERENCES [dbo].[Clients]
        ([clientID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientClientAddress'
CREATE INDEX [IX_FK_ClientClientAddress]
ON [dbo].[ClientAddresses]
    ([clientID]);
GO

-- Creating foreign key on [productID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_ProductOrderDetails]
    FOREIGN KEY ([productID])
    REFERENCES [dbo].[Products]
        ([productID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductOrderDetails'
CREATE INDEX [IX_FK_ProductOrderDetails]
ON [dbo].[OrderDetails]
    ([productID]);
GO

-- Creating foreign key on [orderID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_OrderOrderDetails]
    FOREIGN KEY ([orderID])
    REFERENCES [dbo].[Orders]
        ([orderID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [addresssID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_ClientAddressOrder]
    FOREIGN KEY ([addresssID])
    REFERENCES [dbo].[ClientAddresses]
        ([addresssID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientAddressOrder'
CREATE INDEX [IX_FK_ClientAddressOrder]
ON [dbo].[Orders]
    ([addresssID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------