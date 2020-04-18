SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

DROP DATABASE IF EXISTS `limerickstreetart`;
CREATE DATABASE IF NOT EXISTS `limerickstreetart` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `limerickstreetart`;

CREATE TABLE `streetart` (
  `Id` int(11) NOT NULL,
  `GpsLatitude` float(10,8) NOT NULL,
  `GpsLongitude` float(10,8) NOT NULL,
  `Title` varchar(45) NOT NULL,
  `Street` varchar(45) DEFAULT NULL,
  `Timestamp` datetime NOT NULL,
  `Image` mediumblob NOT NULL,
  `UserAccountId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `useraccount` (
  `Id` int(11) NOT NULL,
  `Username` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `Active` tinyint(4) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `AccessLevel` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `useraccount` (`Id`, `Username`, `Email`, `Password`, `Active`, `DateOfBirth`, `AccessLevel`) VALUES
(1, 'Admin', 'Admin@streetart.ie', 'letmein', 1, '2000-01-01', 1),
(2, 'Test', 'test@test.ie', 'letmein', 1, '2000-01-01', 2);


ALTER TABLE `streetart`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk_StreetArt_UserAccount_idx` (`UserAccountId`);

ALTER TABLE `useraccount`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Username_UNIQUE` (`Username`),
  ADD UNIQUE KEY `Email_UNIQUE` (`Email`);


ALTER TABLE `streetart`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `useraccount`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;


ALTER TABLE `streetart`
  ADD CONSTRAINT `fk_StreetArt_UserAccount` FOREIGN KEY (`UserAccountId`) REFERENCES `useraccount` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
