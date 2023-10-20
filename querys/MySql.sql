CREATE DATABASE `db_operation`;

USE `db_operation`;

CREATE TABLE `payment` (
  `id_operation` int NOT NULL AUTO_INCREMENT,
  `id_invoice` int NOT NULL,
  `amount` decimal(18,2) NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id_operation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;