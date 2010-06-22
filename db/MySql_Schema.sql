-- ----------------------------------------------------------------------
-- MySQL Migration Toolkit
-- SQL Create Script
-- ----------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

CREATE DATABASE IF NOT EXISTS `simsto`
  CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `simsto`;
-- -------------------------------------
-- Tables

DROP TABLE IF EXISTS `simsto`.`Image`;
CREATE TABLE `simsto`.`Image` (
  `ImageId` INT(10) NOT NULL AUTO_INCREMENT,
  `ImagePath` VARCHAR(512) NOT NULL,
  `Height` INT(10) NOT NULL,
  `Width` INT(10) NOT NULL,
  `Size` INT(10) NOT NULL,
  `Created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ImageId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `simsto`.`ProductImage`;
CREATE TABLE `simsto`.`ProductImage` (
  `ProductId` INT(10) NOT NULL,
  `ImageId` INT(10) NOT NULL,
  `IsPrimary` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`ProductId`, `ImageId`),
  CONSTRAINT `FK_ProductImage_Image` FOREIGN KEY `FK_ProductImage_Image` (`ImageId`)
    REFERENCES `simsto`.`Image` (`ImageId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProductImage_Product` FOREIGN KEY `FK_ProductImage_Product` (`ProductId`)
    REFERENCES `simsto`.`Product` (`ProductId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;


DROP TABLE IF EXISTS `simsto`.`ProductAttribute`;
CREATE TABLE `simsto`.`ProductAttribute` (
  `ProductAttributeId` INT(10) NOT NULL AUTO_INCREMENT,
  `ProductId` INT(10) NOT NULL,
  `Name` VARCHAR(1024) NOT NULL,
  `Value` VARCHAR(20000) NOT NULL,
  `IsGroup` TINYINT NOT NULL DEFAULT 0,
  `Created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductAttributeId`),
  CONSTRAINT `FK_ProductAttribute_Product` FOREIGN KEY `FK_ProductAttribute_Product` (`ProductId`)
    REFERENCES `simsto`.`Product` (`ProductId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;


DROP TABLE IF EXISTS `simsto`.`Site`;
CREATE TABLE `simsto`.`Site` (
  `SiteId` INT(10) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(512) NOT NULL,
  `SellerId` INT(10) NOT NULL,
  `Created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SiteId`),
  CONSTRAINT `FK_Site_Seller` FOREIGN KEY `FK_Site_Seller` (`SellerId`)
    REFERENCES `simsto`.`Seller` (`SellerId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `simsto`.`Seller`;
CREATE TABLE `simsto`.`Seller` (
  `SellerId` INT(10) NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(512) NOT NULL,
  `EbayUser` VARCHAR(50) NOT NULL,
  `Created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SellerId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `simsto`.`ProductStatus`;
CREATE TABLE `simsto`.`ProductStatus` (
  `ProductStatusId` INT(10) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `Created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductStatusId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `simsto`.`Product`;
CREATE TABLE `simsto`.`Product` (
  `ProductId` INT(10) NOT NULL AUTO_INCREMENT,
  `SiteId` INT(10) NOT NULL,
  `ProductStatusId` INT(10) NOT NULL,
  `Title` VARCHAR(512) NOT NULL,
  `Created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductId`),
  CONSTRAINT `FK_Product_Site` FOREIGN KEY `FK_Product_Site` (`SiteId`)
    REFERENCES `simsto`.`Site` (`SiteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Product_ProductStatus` FOREIGN KEY `FK_Product_ProductStatus` (`ProductStatusId`)
    REFERENCES `simsto`.`ProductStatus` (`ProductStatusId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `simsto`.`Html`;
CREATE TABLE `simsto`.`Html` (
  `HtmlId` INT(10) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(512) NOT NULL,
  `Html` VARCHAR(20000) NOT NULL,
  `Created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`HtmlId`)
)
ENGINE = INNODB;


DROP TABLE IF EXISTS `simsto`.`ProductDescription`;
CREATE TABLE `simsto`.`ProductDescription` (
  `ProductId` INT(10) NOT NULL,
  `HtmlId` INT(10) NOT NULL,
  PRIMARY KEY (`ProductId`, `HtmlId`),
  CONSTRAINT `FK_ProductDescription_Product` FOREIGN KEY `FK_ProductDescription_Product` (`ProductId`)
    REFERENCES `simsto`.`Product` (`ProductId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProductDescription_Html` FOREIGN KEY `FK_ProductDescription_Html` (`HtmlId`)
    REFERENCES `simsto`.`Html` (`HtmlId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `simsto`.`ProductListing`;
CREATE TABLE `simsto`.`ProductListing` (
  `ProductId` INT(10) NOT NULL,
  `HtmlId` INT(10) NOT NULL,
  PRIMARY KEY (`ProductId`, `HtmlId`),
  CONSTRAINT `FK_ProductListing_Product` FOREIGN KEY `FK_ProductListing_Product` (`ProductId`)
    REFERENCES `simsto`.`Product` (`ProductId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProductListing_Html` FOREIGN KEY `FK_ProductListing_Html` (`HtmlId`)
    REFERENCES `simsto`.`Html` (`HtmlId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `simsto`.`Page`;
CREATE TABLE `simsto`.`Page` (
  `PageId` INT(10) NOT NULL AUTO_INCREMENT,
  `SiteId` INT(10) NOT NULL,
  `Name` VARCHAR(512) NOT NULL,
  `Title` VARCHAR(1024) NOT NULL,
  `HtmlId` INT(10) NOT NULL,
  `Created` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PageId`),
  CONSTRAINT `FK_Page_Site` FOREIGN KEY `FK_Page_Site` (`SiteId`)
    REFERENCES `simsto`.`Site` (`SiteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Page_Html` FOREIGN KEY `FK_Page_Html` (`HtmlId`)
    REFERENCES `simsto`.`Html` (`HtmlId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;



SET FOREIGN_KEY_CHECKS = 1;

-- ----------------------------------------------------------------------
-- EOF

