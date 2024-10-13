-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 01, 2024 at 09:32 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `event_management`
--

-- --------------------------------------------------------

--
-- Table structure for table `bookings`
--

CREATE TABLE `bookings` (
  `BookingId` int(11) NOT NULL,
  `TicketId` int(11) DEFAULT NULL,
  `MemberEmail` varchar(255) DEFAULT NULL,
  `TicketName` varchar(255) DEFAULT NULL,
  `BookingDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bookings`
--

INSERT INTO `bookings` (`BookingId`, `TicketId`, `MemberEmail`, `TicketName`, `BookingDate`) VALUES
(14, 14, 'tharushi@gmail.com', 'Summer Beach Bash', '2024-07-01 21:18:39'),
(15, 15, 'tharushi@gmail.com', 'Masquerda Ball VIP', '2024-07-01 21:18:48'),
(16, 15, 'tharushi@gmail.com', 'Masquerda Ball VIP', '2024-07-01 21:19:09'),
(17, 15, 'tharushi@gmail.com', 'Masquerda Ball VIP', '2024-07-01 21:27:07'),
(18, 16, 'tharushi@gmail.com', 'Retro Disco Night', '2024-07-01 21:28:15');

-- --------------------------------------------------------

--
-- Table structure for table `events`
--

CREATE TABLE `events` (
  `EventID` int(11) NOT NULL,
  `PartnerID` int(11) NOT NULL,
  `EventName` varchar(100) NOT NULL,
  `EventDescription` text DEFAULT NULL,
  `EventDate` varchar(20) DEFAULT NULL,
  `EventTime` varchar(20) NOT NULL,
  `Location` varchar(255) NOT NULL,
  `link` varchar(3000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `events`
--

INSERT INTO `events` (`EventID`, `PartnerID`, `EventName`, `EventDescription`, `EventDate`, `EventTime`, `Location`, `link`) VALUES
(17, 14, 'Summer Bash', 'Join us for a sunny day of beach fun with games, music, and BBQ. Bring your swimsuits and sunscreen!', 'Aug 5th', '3 PM', 'Galle', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVKJ6RRI5XhXlt6kcytZYzJd52eg84Y8dzZA&s'),
(18, 14, 'Masquerade Ball', 'Dress in your finest and wear a mask for an evening of mystery, dancing, and live entertainment.', 'Feb 13th', '6 PM', 'Dambulla', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT5x2yy4rTPrrApZ_dCGVUhDybZrMdUMreACQ&s'),
(19, 15, 'Retro Disco Night', 'Flashback to the 70s with groovy tunes, a dazzling dance floor, and funky costumes.', 'Jan 7th', '9 PM', 'Ella', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJjY_MugfRVzFBb4IRkcDdmPfA1mJ_o6-_Qg&s'),
(21, 16, 'Halloween Spooktacular', 'Experience a night of fright with haunted houses, costume contests, and spooky decorations.', 'Nov 11', '12 AM', 'Borella Cemenery', 'https://d1csarkz8obe9u.cloudfront.net/posterpreviews/halloween-party-poster-template-57f6478f50fae4a682646f88f809defd_screen.jpg?ts=1700639182');

-- --------------------------------------------------------

--
-- Table structure for table `members`
--

CREATE TABLE `members` (
  `MemberId` int(11) NOT NULL,
  `MemberName` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `members`
--

INSERT INTO `members` (`MemberId`, `MemberName`, `Email`, `Password`) VALUES
(6, 'Tharushi', 'tharushi@gmail.com', 'tharushi'),
(7, 'premasiri', 'premasiri@gmail.com', 'premasiri');

-- --------------------------------------------------------

--
-- Table structure for table `partners`
--

CREATE TABLE `partners` (
  `PartnerID` int(11) NOT NULL,
  `PartnerName` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `partners`
--

INSERT INTO `partners` (`PartnerID`, `PartnerName`, `Email`, `Password`) VALUES
(13, 'Admin', 'admin@gmail.com', 'admin'),
(14, 'tharushi', 'tharushi@gmail.com', 'tharushi'),
(15, 'dil', 'dil@gmail.com', 'dil'),
(16, 'imalka', 'imalka@gmail.com', 'imalka'),
(17, 'Dilshaani', 'tharushi2@gmail.com', 'tharushi'),
(18, 'Dilshaani', 'tharushi2@gmail.com', 'tharushi');

-- --------------------------------------------------------

--
-- Table structure for table `tickets`
--

CREATE TABLE `tickets` (
  `TicketID` int(11) NOT NULL,
  `EventID` int(11) NOT NULL,
  `TicketName` varchar(100) NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `CommissionRate` decimal(5,2) DEFAULT NULL,
  `Sold` int(9) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tickets`
--

INSERT INTO `tickets` (`TicketID`, `EventID`, `TicketName`, `Price`, `Quantity`, `CommissionRate`, `Sold`) VALUES
(14, 17, 'Summer Bash', 70.00, 199, 0.20, 1),
(15, 18, 'Masquerda Ball VIP', 100.00, 22, 0.15, 3),
(16, 19, 'Retro Disco Night', 25.00, 249, 0.20, 1),
(18, 21, 'Halloween Spooktacular', 99.00, 444, 0.10, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`BookingId`),
  ADD KEY `TicketId` (`TicketId`);

--
-- Indexes for table `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`EventID`),
  ADD KEY `PartnerID` (`PartnerID`);

--
-- Indexes for table `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`MemberId`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexes for table `partners`
--
ALTER TABLE `partners`
  ADD PRIMARY KEY (`PartnerID`);

--
-- Indexes for table `tickets`
--
ALTER TABLE `tickets`
  ADD PRIMARY KEY (`TicketID`),
  ADD KEY `EventID` (`EventID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bookings`
--
ALTER TABLE `bookings`
  MODIFY `BookingId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `events`
  MODIFY `EventID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `members`
--
ALTER TABLE `members`
  MODIFY `MemberId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `partners`
--
ALTER TABLE `partners`
  MODIFY `PartnerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `tickets`
--
ALTER TABLE `tickets`
  MODIFY `TicketID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bookings`
--
ALTER TABLE `bookings`
  ADD CONSTRAINT `bookings_ibfk_1` FOREIGN KEY (`TicketId`) REFERENCES `tickets` (`TicketID`);

--
-- Constraints for table `events`
--
ALTER TABLE `events`
  ADD CONSTRAINT `events_ibfk_1` FOREIGN KEY (`PartnerID`) REFERENCES `partners` (`PartnerID`);

--
-- Constraints for table `tickets`
--
ALTER TABLE `tickets`
  ADD CONSTRAINT `tickets_ibfk_1` FOREIGN KEY (`EventID`) REFERENCES `events` (`EventID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
