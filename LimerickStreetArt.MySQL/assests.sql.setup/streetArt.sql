-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 11, 2020 at 12:17 AM
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
  `Image` mediumblob NOT NULL,
  `UserAccountId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `streetart`
--

INSERT INTO `streetart` (`Id`, `GpsLatitude`, `GpsLongitude`, `Title`, `Street`, `Timestamp`, `Image`, `UserAccountId`) VALUES
(1, 30.22340012, -97.76969910, '1', '1', '0000-00-00 00:00:00', '', 1),
(15, 23.08769035, 23.00000000, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:44:35', 0x496d616765, 2),
(16, 52.66179657, -8.62880230, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:32:25', 0x496d616765, 2),
(17, 52.66193390, -8.63142014, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:32:25', 0x496d616765, 2),
(18, 23.08769035, 23.00000000, 'Jim version', 'Evergreen Terrrace', '2020-05-09 00:35:47', 0x496d616765, 2);

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
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `streetart`
--
ALTER TABLE `streetart`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

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
