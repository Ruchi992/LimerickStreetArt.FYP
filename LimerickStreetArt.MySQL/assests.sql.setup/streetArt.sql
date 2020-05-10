-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 09, 2020 at 01:53 AM
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
DROP DATABASE IF EXISTS `limerickstreetart`;
CREATE DATABASE IF NOT EXISTS `limerickstreetart` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `limerickstreetart`;

-- --------------------------------------------------------

--
-- Table structure for table `streetart`
--

DROP TABLE IF EXISTS `streetart`;
CREATE TABLE `streetart` (
  `Id` int(11) NOT NULL,
  `GpsLatitude` float(10,8) NOT NULL,
  `GpsLongitude` float(10,8) NOT NULL,
  `Title` varchar(45) NOT NULL,
  `Street` varchar(45) NOT NULL,
  `Timestamp` datetime NOT NULL,
  `Image` mediumblob NOT NULL,
  `UserAccountId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `streetart`
--

INSERT INTO `streetart` (`Id`, `GpsLatitude`, `GpsLongitude`, `Title`, `Street`, `Timestamp`, `Image`, `UserAccountId`) VALUES
(1, 30.22340012, -97.76969910, '1', '1', '0000-00-00 00:00:00', '', 1),
(3, 100.00000000, 100.00000000, 'Jim version', '', '0001-01-01 00:00:00', 0x496d616765, 2),
(4, 100.00000000, 100.00000000, 'Jim version', '', '0001-01-01 00:00:00', 0x496d616765, 2),
(5, 100.00000000, 100.00000000, 'Jim version', '', '2020-04-21 20:51:01', 0x496d616765, 2),
(6, 100.00000000, 100.00000000, 'Jim version', '', '2020-04-21 20:52:31', 0x496d616765, 2),
(7, 100.00000000, 100.00000000, 'Jim version', '', '2020-04-21 20:53:44', 0x496d616765, 2),
(8, 100.00000000, 100.00000000, 'Jim version', '', '2020-04-21 20:54:44', 0x496d616765, 2),
(9, 100.00000000, 100.00000000, 'Jim version', '', '2020-04-21 21:02:57', 0x496d616765, 2),
(10, 100.00000000, 100.00000000, 'Jim version', 'Evergreen Terrrace', '2020-04-21 21:21:22', 0x496d616765, 2),
(11, 100.00000000, 100.00000000, 'Jim version', 'Evergreen Terrrace', '2020-04-22 14:59:09', 0x496d616765, 2),
(12, 100.00000000, 100.00000000, 'Jim version', 'Evergreen Terrrace', '2020-05-04 22:28:56', 0x496d616765, 2),
(13, 1.00000000, 1.00000000, '1', '1', '0000-00-00 00:00:00', 0x31, 1),
(14, 100.00000000, 100.00000000, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:30:13', 0x496d616765, 2),
(15, 23.08769035, 23.00000000, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:44:35', 0x496d616765, 2),
(16, 100.00000000, 100.00000000, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:32:25', 0x496d616765, 2),
(17, 100.00000000, 100.00000000, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:32:25', 0x496d616765, 2),
(18, 23.08769035, 23.00000000, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:35:47', 0x496d616765, 2);

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
(2, 'Test', 'test@test.ie', 'letmein', 1, '2000-01-01', 2),
(26, 'locked', 'locked@noreply.com', 'password', 0, '0000-00-00', 2);

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `useraccount`
--
ALTER TABLE `useraccount`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

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