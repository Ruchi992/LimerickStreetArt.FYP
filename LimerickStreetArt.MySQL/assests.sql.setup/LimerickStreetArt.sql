-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema LimerickStreetArt
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema LimerickStreetArt
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `LimerickStreetArt` DEFAULT CHARACTER SET utf8 ;
USE `LimerickStreetArt` ;

-- -----------------------------------------------------
-- Table `LimerickStreetArt`.`UserAccount`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `LimerickStreetArt`.`UserAccount` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL,
  `Active` TINYINT NOT NULL,
  `UserAccountcol` TINYINT NOT NULL,
  `DateOfBirth` DATE NOT NULL,
  `AccessLevel` INT NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Username_UNIQUE` (`Username` ASC) VISIBLE,
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `LimerickStreetArt`.`StreetArt`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `LimerickStreetArt`.`StreetArt` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `GpsLatitude` FLOAT(10,8) NOT NULL,
  `GpsLongitude` FLOAT(10,8) NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Street` VARCHAR(45) NULL,
  `Timestamp` DATETIME NOT NULL,
  `Image` MEDIUMBLOB NOT NULL,
  `UserAccountId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_StreetArt_UserAccount_idx` (`UserAccountId` ASC) VISIBLE,
  CONSTRAINT `fk_StreetArt_UserAccount`
    FOREIGN KEY (`UserAccountId`)
    REFERENCES `LimerickStreetArt`.`UserAccount` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
