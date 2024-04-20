CREATE DATABASE user_patient_info;
USE user_patient_info;
CREATE TABLE `patients` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(20) NOT NULL,
  `Lastname` varchar(20) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Phone` varchar(10) NOT NULL,
  `Diagnosis` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `users` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(20) NOT NULL,
  `Lastname` varchar(20) NOT NULL,
  `Email` varchar(60) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Sex` char(1) NOT NULL,
  `Login` varchar(12) NOT NULL,
  `Password` varchar(25) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

