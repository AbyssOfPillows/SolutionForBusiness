-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: KeeperBD
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Applications`
--

DROP TABLE IF EXISTS `Applications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Applications` (
  `Id` int NOT NULL,
  `DateOfVisit` varchar(50) DEFAULT NULL,
  `EmployeeId` int DEFAULT NULL,
  `GroupId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Purposes_FK` (`EmployeeId`),
  KEY `Purposes_FK_1` (`GroupId`),
  CONSTRAINT `Application_FK` FOREIGN KEY (`GroupId`) REFERENCES `Groups` (`Id`),
  CONSTRAINT `Application_FK_1` FOREIGN KEY (`EmployeeId`) REFERENCES `Employees` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Applications`
--

LOCK TABLES `Applications` WRITE;
/*!40000 ALTER TABLE `Applications` DISABLE KEYS */;
INSERT INTO `Applications` VALUES (1,'24.04.2023',1,3),(2,'24.04.2023',2,4),(3,'24.04.2023',3,5),(4,'25.04.2023',1,6),(5,'25.04.2023',2,7),(6,'25.04.2023',3,8),(7,'26.04.2023',1,9),(8,'26.04.2023',2,10),(9,'26.04.2023',3,11),(10,'27.04.2023',1,12),(11,'27.04.2023',2,13),(12,'27.04.2023',3,14),(13,'28.04.2023',1,15),(14,'28.04.2023',2,16),(15,'28.04.2023',3,17),(16,'24.04.2023',1,1),(17,'24.04.2023',1,2);
/*!40000 ALTER TABLE `Applications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Departments`
--

DROP TABLE IF EXISTS `Departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Departments` (
  `Id` int NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Departments`
--

LOCK TABLES `Departments` WRITE;
/*!40000 ALTER TABLE `Departments` DISABLE KEYS */;
INSERT INTO `Departments` VALUES (1,'Производство'),(2,'Сбыт'),(3,'Администрация'),(4,'Служба безопасности'),(5,'Планирование'),(6,'Общий отдел'),(7,'Охрана');
/*!40000 ALTER TABLE `Departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Employees`
--

DROP TABLE IF EXISTS `Employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Employees` (
  `Id` int NOT NULL,
  `Surname` varchar(50) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Patronymic` varchar(50) DEFAULT NULL,
  `DepartmentId` int DEFAULT NULL,
  `Code` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Employes_FK` (`DepartmentId`),
  CONSTRAINT `Employes_FK` FOREIGN KEY (`DepartmentId`) REFERENCES `Departments` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employees`
--

LOCK TABLES `Employees` WRITE;
/*!40000 ALTER TABLE `Employees` DISABLE KEYS */;
INSERT INTO `Employees` VALUES (1,'Фомичева','Авдотья','Трофимовна',1,9367788),(2,'Гаврилова','Римма','Ефимовна',2,9788737),(3,'Носкова','Наталия','Прохоровна',3,9736379),(4,'Архипов','Тимофей','Васильевич',4,9362832),(5,'Орехова','Вероника','Артемовна',5,9737848),(6,'Савельев','Павел','Степанович',6,9768239),(7,'Чернов','Всеволод','Наумович',7,9404040),(8,'Марков','Юрий','Романович',7,9404041);
/*!40000 ALTER TABLE `Employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Groups`
--

DROP TABLE IF EXISTS `Groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Groups` (
  `Id` int NOT NULL,
  `Group` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Groups`
--

LOCK TABLES `Groups` WRITE;
/*!40000 ALTER TABLE `Groups` DISABLE KEYS */;
INSERT INTO `Groups` VALUES (1,'ГР_1'),(2,'ГР_2'),(3,'ИП_1'),(4,'ИП_2'),(5,'ИП_3'),(6,'ИП_4'),(7,'ИП_5'),(8,'ИП_6'),(9,'ИП_7'),(10,'ИП_8'),(11,'ИП_9'),(12,'ИП_10'),(13,'ИП_11'),(14,'ИП_12'),(15,'ИП_13'),(16,'ИП_14'),(17,'ИП_15');
/*!40000 ALTER TABLE `Groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `GroupsVisitors`
--

DROP TABLE IF EXISTS `GroupsVisitors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `GroupsVisitors` (
  `GroupId` int NOT NULL,
  `VisitorId` int NOT NULL,
  KEY `GroupsVisitors_FK` (`VisitorId`),
  KEY `GroupsVisitors_FK_1` (`GroupId`),
  CONSTRAINT `GroupsVisitors_FK` FOREIGN KEY (`VisitorId`) REFERENCES `Visitors` (`Id`),
  CONSTRAINT `GroupsVisitors_FK_1` FOREIGN KEY (`GroupId`) REFERENCES `Groups` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `GroupsVisitors`
--

LOCK TABLES `GroupsVisitors` WRITE;
/*!40000 ALTER TABLE `GroupsVisitors` DISABLE KEYS */;
INSERT INTO `GroupsVisitors` VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(2,8),(2,9),(2,10),(2,11),(2,12),(2,13),(2,14),(2,15),(3,16),(4,17),(5,18),(6,19),(7,20),(8,21),(9,22),(10,23),(11,24),(12,25),(13,26),(14,27),(15,28),(16,29),(17,30);
/*!40000 ALTER TABLE `GroupsVisitors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Visitors`
--

DROP TABLE IF EXISTS `Visitors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Visitors` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Surname` varchar(50) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Patronymic` varchar(50) DEFAULT NULL,
  `NumberPhone` varchar(50) DEFAULT NULL,
  `E-mail` varchar(50) DEFAULT NULL,
  `DateOfBirth` varchar(50) DEFAULT NULL,
  `DataOfPasport` varchar(50) DEFAULT NULL,
  `Login` varchar(50) DEFAULT NULL,
  `Password` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Visitors`
--

LOCK TABLES `Visitors` WRITE;
/*!40000 ALTER TABLE `Visitors` DISABLE KEYS */;
INSERT INTO `Visitors` VALUES (1,'Самойлова','Таисия','Гермоновна','+7 (891) 555-81-44','Taisiya177@lenta.ru','14 ноября 1979 года','5 193 897 719','Taisiya177','R94YGT3XFjgD'),(2,'Ситникова','Аделаида','Гермоновна','+7 (793) 736-70-31','Adelaida20@hotmail.com','21 января 1979 года','7 561 148 016','Adelaida20','LCY*{L*fEGYB'),(3,'Исаев','Лев','Юлианович','+7 (675) 593-89-30','Lev131@rambler.ru','5 августа 1994 года','1 860 680 004','Lev131','~?oj2Lh@S7*T'),(4,'Никифоров','Даниил','Степанович','+7 (384) 358-77-82','Daniil198@bk.ru','13 декабря 1970 года','4 557 999 958','lzaihtvkdn','L2W#uo7z{EsO'),(5,'Титова','Людмила','Якововна','+7 (221) 729-16-84','Lyudmila123@hotmail.com','21 августа 1976 года','7 715 639 425','Lyudmila123','@8mk9M?NBAGj'),(6,'Абрамова','Таисия','Дмитриевна','+7 (528) 312-18-20','Taisiya176@hotmail.com','20 ноября 1982 года','7 310 893 510','Taisiya176','~rIWfsnXA~7C'),(7,'Кузьмина','Вера','Максимовна','+7 (598) 583-53-45','Vera195@list.ru','10 декабря 1989 года','3 537 982 933','Vera195','B|5v$2r$7luL'),(8,'Мартынов','Яков','Ростиславович','+7 (546) 159-67-33','YAkov196@rambler.ru','5 декабря 1976 года','1 793 986 063','YAkov196','$6s5bggKP7aw'),(9,'Евсеева','Нина','Павловна','+7 (833) 521-31-50','Nina145@msn.com','26 сентября 1994 года','9 323 745 717','Nina145','Uxy6RtBXIcpT'),(10,'Голубев','Леонтий','Вячеславович','+7 (160) 527-57-41','Leontij161@mail.ru','3 октября 1990 года','1 059 822 077','Leontij161','KkMY8yKw@oCa'),(11,'Карпова','Серафима','Михаиловна','+7 (459) 930-91-70','Serafima169@yahoo.com','19 ноября 1989 года','7 034 858 987','Serafima169','gNe3I9}8J3Z@'),(12,'Орехов','Сергей','Емельянович','+7 (669) 603-29-87','Sergej35@inbox.ru','11 февраля 1972 года','3 844 223 682','Sergej35','$39vc%ljqN%r'),(13,'Исаев','Георгий','Павлович','+7 (678) 516-36-86','Georgij121@inbox.ru','11 августа 1987 года','4 076 629 809','Georgij121','bbx5H}f*BC?w'),(14,'Богданов','Елизар','Артемович','+7 (165) 768-30-97','Elizar30@yandex.ru','2 февраля 1978 года','573 198 559','Elizar30','wJs1~r3RS~dr'),(15,'Тихонова','Лана','Семеновна','+7 (478) 467-75-15','Lana117@outlook.com','24 июля 1990 года','8 761 609 740','Lana117','mFoG$jcS3c4~'),(16,'Степанова','Радинка','Власовна','+7 (613) 272-60-62','Radinka100@yandex.ru','18 октября 1986 года','208 530 509','Vlas86','b3uWS6#Thuvq'),(17,'Шилов','Прохор','Герасимович','+7 (615) 594-77-66','Prohor156@list.ru','9 октября 1977 года','3 036 796 488','Prohor156','zDdom}SIhWs?'),(18,'Кононов','Юрин','Романович','+7 (784) 673-51-91','YUrin155@gmail.com','8 октября 1971 года','2 747 790 512','YUrin155','u@m*~ACBCqNQ'),(19,'Елисеева','Альбина','Николаевна','+7 (654) 864-77-46','Aljbina33@lenta.ru','15 февраля 1983 года','5 241 213 304','Aljbina33','Bu?BHCtwDFin'),(20,'Шарова','Клавдия','Макаровна','+7 (822) 525-82-40','Klavdiya113@live.com','22 июля 1980 года','8 143 593 309','Klavdiya113','FjC#hNIJori}'),(21,'Сидорова','Тамара','Григорьевна','+7 (334) 692-79-77','Tamara179@live.com','22 ноября 1995 года','8 143 905 520','Tamara179','TJxVqMXrbesI'),(22,'Петухов','Тарас','Фадеевич','+7 (376) 220-62-51','Taras24@rambler.ru','5 января 1991 года','1 609 171 096','Taras24','07m5yspn3K~K'),(23,'Родионов','Аркадий','Власович','+7 (491) 696-17-11','Arkadij123@inbox.ru','11 августа 1993 года','3 841 642 594','Arkadij123','vk2N7lxX}ck%'),(24,'Горшкова','Глафира','Валентиновна','+7 (553) 343-38-82','Glafira73@outlook.com','25 мая 1978 года','9 170 402 601','Glafira73','Zz8POQlP}M4~'),(25,'Кириллова','Гавриила','Яковна','+7 (648) 700-43-34','Gavriila68@msn.com','26 апреля 1992 года','9 438 379 667','Gavriila68','x4K5WthEe8ua'),(26,'Овчинников','Кузьма','Ефимович','+7 (562) 866-15-27','Kuzjma124@yandex.ru','2 августа 1993 года','766 647 226','Kuzjma124','OsByQJ}vYznW'),(27,'Беляков','Роман','Викторович','+7 (595) 196-56-28','Roman89@gmail.com','7 июня 1991 года','2 411 478 305','Roman89','Xd?xP$2yICcG'),(28,'Лыткин','Алексей','Максимович','+7 (994) 353-29-52','Aleksej43@gmail.com','7 марта 1996 года','2 383 259 825','Aleksej43','~c%PlTY0?qgl'),(29,'Шубина','Надежда','Викторовна','+7 (736) 488-66-95','Nadezhda137@outlook.com','24 сентября 1981 года','8 844 708 476','Nadezhda137','QQ~0q~rXHb?p'),(30,'Зиновьева','Бронислава','Викторовна','+7 (778) 565-12-18','Bronislava56@yahoo.com','19 марта 1981 года','6 736 319 423','Bronislava56','LO}xyC~1S4l6');
/*!40000 ALTER TABLE `Visitors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'KeeperBD'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-13  8:44:05
