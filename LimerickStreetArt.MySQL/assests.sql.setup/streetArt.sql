-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 28, 2020 at 10:50 AM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `limerickstreetart`
--
CREATE DATABASE IF NOT EXISTS `limerickstreetart` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `limerickstreetart`;

DELIMITER $$
--
-- Procedures
--
DROP PROCEDURE IF EXISTS `CreateStreetArt`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateStreetArt` (IN `GpsLatitude` FLOAT(10,8), IN `GpsLongitude` FLOAT(10,8), IN `Title` VARCHAR(45), IN `Street` VARCHAR(45), IN `Timestamp` DATETIME, IN `Image` VARCHAR(45), IN `UserAccountId` INT(11), OUT `id_` INT)  BEGIN
INSERT INTO `limerickstreetart`.`streetart`
(
`GpsLatitude`,`GpsLongitude`,`Title`,`Street`,`Timestamp`,`Image`,`UserAccountId`)
VALUES
(
GpsLatitude,GpsLongitude, Title, Street, Timestamp, Image, UserAccountId);
set id_ = LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `CreateUserAccount`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateUserAccount` (IN `Username` VARCHAR(45), IN `Email` VARCHAR(45), IN `Password` VARCHAR(45), IN `Active` TINYINT, IN `DateOfBirth` DATE, IN `AccessLevel` INT(11), OUT `id_` INT)  BEGIN
INSERT INTO `limerickstreetart`.`useraccount`
(`Username`, `Email`, `Password`,`Active`,`DateOfBirth`,`AccessLevel`)
VALUES
(Username, Email, Password, Active, DateOfBirth, AccessLevel);
set id_ = LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `DeleteStreetArt`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteStreetArt` (IN `id` INT)  BEGIN
delete from streetart
where streetart.Id = id;
END$$

DROP PROCEDURE IF EXISTS `DeleteUserAccount`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUserAccount` (IN `Id_` INT)  BEGIN
DELETE FROM useraccount WHERE `Id` = Id_;
END$$

DROP PROCEDURE IF EXISTS `GetActiveUserAccounts`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetActiveUserAccounts` ()  BEGIN
select * from `useraccount` 
where  `active`  =1;
END$$

DROP PROCEDURE IF EXISTS `GetStreetArtById`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetStreetArtById` (IN `_id` INT)  BEGIN
SELECT * FROM streetart
where `ID`= _id;
END$$

DROP PROCEDURE IF EXISTS `GetStreetArtList`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetStreetArtList` ()  BEGIN
select * from limerickstreetart.streetart;
END$$

DROP PROCEDURE IF EXISTS `GetUserAccountByCredentials`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserAccountByCredentials` (IN `Username` VARCHAR(45), IN `Password` VARCHAR(45))  BEGIN
select * from `useraccount` U
where U.`Username` = username And U.`Password` = password;
END$$

DROP PROCEDURE IF EXISTS `GetUserAccountById`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserAccountById` (IN `Id_` INT)  BEGIN
select * from `useraccount`
where  `Id` = Id_;
END$$

DROP PROCEDURE IF EXISTS `GetUserAccounts`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserAccounts` ()  BEGIN
SELECT * FROM limerickstreetart.useraccount;
END$$

DROP PROCEDURE IF EXISTS `UpdateStreetArt`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStreetArt` (IN `GpsLatitude` FLOAT(10,8), IN `GpsLongitude` FLOAT(10,8), IN `Title` VARCHAR(45), IN `Street` VARCHAR(45), IN `Timestamp` DATETIME, IN `Image` VARCHAR(45), IN `UserAccountId` INT, IN `Id_` INT)  BEGIN
UPDATE `limerickstreetart`.`streetart`
SET
`GpsLatitude` =  GpsLatitude,
`GpsLongitude` = GpsLongitude,
`Title` = Title,
`Street` = Street,
`Timestamp` = Timestamp,
`Image` = Image,
`UserAccountId` =UserAccountId
 WHERE `Id` = Id_;
END$$

DROP PROCEDURE IF EXISTS `UpdateUserAccount`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUserAccount` (IN `Username` VARCHAR(45), IN `Email` VARCHAR(45), IN `Password` VARCHAR(45), IN `Active` TINYINT, IN `DateOfBirth` DATE, IN `AccessLevel` INT, IN `Id_` INT)  BEGIN
UPDATE `limerickstreetart`.`useraccount`
SET
`Username` = Username,
`Email` = Email,
`Password` = Password,
`Active` = Active,
`DateOfBirth` = DateOfBirth,
`AccessLevel` = AccessLevel

WHERE `Id` = Id_;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `streetart`
--

DROP TABLE IF EXISTS `streetart`;
CREATE TABLE `streetart` (
  `Id` int(11) NOT NULL,
  `GpsLatitude` float(10,8) NOT NULL DEFAULT 52.66378784,
  `GpsLongitude` float(10,8) NOT NULL DEFAULT -8.62675190,
  `Title` varchar(45) NOT NULL,
  `Street` varchar(45) NOT NULL,
  `Timestamp` datetime NOT NULL DEFAULT current_timestamp(),
  `Image` varchar(255) NOT NULL,
  `UserAccountId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `streetart`
--

INSERT INTO `streetart` (`Id`, `GpsLatitude`, `GpsLongitude`, `Title`, `Street`, `Timestamp`, `Image`, `UserAccountId`) VALUES
(1, 30.22340012, -97.76969910, '1', '1', '0001-01-01 00:00:00', '1.jpg', 1),
(17, 52.66625214, -8.62502670, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:32:25', 'Image', 2),
(18, 52.66128922, -8.62926865, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:35:47', 'Image', 2);

-- --------------------------------------------------------

--
-- Table structure for table `useraccount`
--

DROP TABLE IF EXISTS `useraccount`;
CREATE TABLE `useraccount` (
  `Id` int(11) NOT NULL,
  `Username` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `Active` tinyint(4) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `AccessLevel` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `useraccount`
--

INSERT INTO `useraccount` (`Id`, `Username`, `Email`, `Password`, `Active`, `DateOfBirth`, `AccessLevel`) VALUES
(1, 'Admin', 'Admin@streetart.ie', 'letmein', 1, '2000-01-01', 1),
(2, 'Test', 'test@test.ie', 'letmein', 1, '1996-09-28', 2),
(26, 'locked', 'locked@noreply.com', 'password', 0, '0000-00-00', 2),
(36, 'kjgkjgkjq', 'f@l.vom', 'letmein', 0, '2020-05-21', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `streetart`
--
ALTER TABLE `streetart`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk_StreetArt_UserAccount_idx` (`UserAccountId`);

--
-- Indexes for table `useraccount`
--
ALTER TABLE `useraccount`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Username_UNIQUE` (`Username`),
  ADD UNIQUE KEY `Email_UNIQUE` (`Email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `streetart`
--
ALTER TABLE `streetart`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `useraccount`
--
ALTER TABLE `useraccount`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `streetart`
--
ALTER TABLE `streetart`
  ADD CONSTRAINT `fk_StreetArt_UserAccount` FOREIGN KEY (`UserAccountId`) REFERENCES `useraccount` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
