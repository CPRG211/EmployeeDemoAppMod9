-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.11.5-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for cprg211mod9demo
CREATE DATABASE IF NOT EXISTS `cprg211mod9demo` /*!40100 DEFAULT CHARACTER SET armscii8 COLLATE armscii8_bin */;
USE `cprg211mod9demo`;

-- Dumping structure for table cprg211mod9demo.employees
CREATE TABLE IF NOT EXISTS `employees` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `active` tinyint(4) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1011 DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Dumping data for table cprg211mod9demo.employees: ~10 rows (approximately)
DELETE FROM `employees`;
INSERT INTO `employees` (`id`, `name`, `active`) VALUES
	(1001, 'Mickey Mouse', 1),
	(1002, 'Donald Duck', 1),
	(1003, 'Goofy', 0),
	(1004, 'Pluto', 1),
	(1005, 'Cinderella', 0),
	(1006, 'Aladdin', 1),
	(1007, 'Snow White', 1),
	(1008, 'Belle', 1),
	(1009, 'Sleeping Beauty', 0),
	(1010, 'Peter Pan', 1);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
