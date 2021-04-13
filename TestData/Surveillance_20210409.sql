/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MariaDB
 Source Server Version : 100418
 Source Host           : localhost:3306
 Source Schema         : surveillance

 Target Server Type    : MariaDB
 Target Server Version : 100418
 File Encoding         : 65001

 Date: 09/04/2021 16:42:23
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for Card
-- ----------------------------
DROP TABLE IF EXISTS `Card`;
CREATE TABLE `Card`  (
  `Seq` int(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `ID` int(16) UNSIGNED NOT NULL DEFAULT 0,
  `Note` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `IsWork` int(1) UNSIGNED NOT NULL DEFAULT 0,
  `ActionTime` datetime(0) NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Seq`, `ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Card
-- ----------------------------
INSERT INTO `Card` VALUES (1, 9001, '公用', 1, '2021-02-28 12:00:00');
INSERT INTO `Card` VALUES (2, 9002, '公用', 1, '2021-03-15 10:00:00');
INSERT INTO `Card` VALUES (3, 9003, '公用', 0, '2021-03-26 11:28:50');

-- ----------------------------
-- Table structure for CardAuthority
-- ----------------------------
DROP TABLE IF EXISTS `CardAuthority`;
CREATE TABLE `CardAuthority`  (
  `Seq` int(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `DoorID` int(16) UNSIGNED NOT NULL DEFAULT 0,
  `CardID` int(16) UNSIGNED NOT NULL DEFAULT 0,
  PRIMARY KEY (`Seq`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of CardAuthority
-- ----------------------------
INSERT INTO `CardAuthority` VALUES (1, 6001, 9001);
INSERT INTO `CardAuthority` VALUES (2, 6002, 9002);
INSERT INTO `CardAuthority` VALUES (3, 6003, 9001);

-- ----------------------------
-- Table structure for CardBatch
-- ----------------------------
DROP TABLE IF EXISTS `CardBatch`;
CREATE TABLE `CardBatch`  (
  `Seq` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `CardID` int(16) UNSIGNED NOT NULL DEFAULT 0,
  `HolderID` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `HolderName` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `StartTime` datetime(0) NOT NULL DEFAULT current_timestamp(),
  `EndTime` datetime(0) NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Seq`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of CardBatch
-- ----------------------------
INSERT INTO `CardBatch` VALUES (1, 9001, 'H001', '小明', '2021-03-01 00:00:00', '2021-03-31 23:59:59');
INSERT INTO `CardBatch` VALUES (2, 9002, 'H002', '小花', '2021-03-01 00:00:00', '2021-03-31 23:59:59');
INSERT INTO `CardBatch` VALUES (3, 9001, 'H003', '小王', '2021-04-01 00:00:00', '2021-04-30 23:59:59');
INSERT INTO `CardBatch` VALUES (4, 9002, 'H004', '小陳', '2021-04-01 00:00:00', '2021-04-30 23:59:59');

-- ----------------------------
-- Table structure for Door
-- ----------------------------
DROP TABLE IF EXISTS `Door`;
CREATE TABLE `Door`  (
  `Seq` int(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `ID` int(16) UNSIGNED NOT NULL DEFAULT 0,
  `Floor` int(2) UNSIGNED NOT NULL DEFAULT 0,
  `Name` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Note` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Status` int(2) UNSIGNED NOT NULL DEFAULT 0,
  `Battery` int(3) UNSIGNED NOT NULL DEFAULT 0,
  `IsRemote` int(1) UNSIGNED NOT NULL DEFAULT 0,
  `ActionTime` datetime(0) NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Seq`, `ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Door
-- ----------------------------
INSERT INTO `Door` VALUES (1, 6001, 1, '大門', NULL, 0, 100, 1, '2021-03-26 10:35:11');
INSERT INTO `Door` VALUES (2, 6002, 2, '電梯', NULL, 0, 80, 1, '2021-03-26 10:35:33');
INSERT INTO `Door` VALUES (3, 6003, 3, '房間A', NULL, 0, 75, 0, '2021-04-09 10:44:01');
INSERT INTO `Door` VALUES (4, 6004, 3, '房間B', NULL, 0, 70, 0, '2021-04-09 10:44:11');
INSERT INTO `Door` VALUES (5, 6005, 3, '房間C', NULL, 0, 72, 0, '2021-04-09 10:44:31');
INSERT INTO `Door` VALUES (6, 6006, 3, '房間D', NULL, 0, 76, 0, '2021-04-09 10:44:41');

-- ----------------------------
-- Table structure for EventLog
-- ----------------------------
DROP TABLE IF EXISTS `EventLog`;
CREATE TABLE `EventLog`  (
  `Seq` int(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `Time` datetime(0) NOT NULL DEFAULT current_timestamp(),
  `DoorID` int(16) UNSIGNED NOT NULL DEFAULT 0,
  `CardID` int(16) UNSIGNED NULL DEFAULT 0,
  `Status` int(2) UNSIGNED NOT NULL DEFAULT 0,
  `UserSeq` int(8) UNSIGNED NOT NULL DEFAULT 0,
  PRIMARY KEY (`Seq`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of EventLog
-- ----------------------------
INSERT INTO `EventLog` VALUES (1, '2021-03-26 10:48:25', 6001, NULL, 1, 1);
INSERT INTO `EventLog` VALUES (2, '2021-03-26 10:49:29', 6001, NULL, 2, 1);
INSERT INTO `EventLog` VALUES (3, '2021-03-26 11:31:11', 6001, 9001, 1, 0);

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE IF EXISTS `User`;
CREATE TABLE `User`  (
  `Seq` int(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Account` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `IsAdmin` int(1) UNSIGNED NOT NULL DEFAULT 0,
  `IsWork` int(1) UNSIGNED NOT NULL DEFAULT 1,
  `ActionTime` datetime(0) NOT NULL DEFAULT current_timestamp() ON UPDATE CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`Seq`, `Account`) USING BTREE,
  FULLTEXT INDEX `Idx_User`(`Account`, `Name`)
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO `User` VALUES (1, 'Fish', 'fish', 'fish', 1, 1, '2021-03-25 17:16:07');
INSERT INTO `User` VALUES (2, 'Test', 'test', 'test', 0, 1, '2021-03-26 09:11:45');
INSERT INTO `User` VALUES (3, 'Guest', 'guest', 'guest', 0, 0, '2021-01-01 08:00:00');
INSERT INTO `User` VALUES (4, 'b', 'bb', 'bbb', 0, 0, '2021-04-06 11:58:03');

-- ----------------------------
-- Table structure for UserLog
-- ----------------------------
DROP TABLE IF EXISTS `UserLog`;
CREATE TABLE `UserLog`  (
  `Seq` int(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `Time` datetime(0) NOT NULL DEFAULT current_timestamp(),
  `UserSeq` int(8) UNSIGNED NOT NULL DEFAULT 0,
  `Status` int(2) UNSIGNED NOT NULL DEFAULT 0,
  `Note` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Seq`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of UserLog
-- ----------------------------
INSERT INTO `UserLog` VALUES (1, '2021-03-26 10:26:34', 1, 1, NULL);
INSERT INTO `UserLog` VALUES (2, '2021-03-26 10:26:42', 2, 1, NULL);
INSERT INTO `UserLog` VALUES (3, '2021-04-06 15:50:22', 1, 2, NULL);
INSERT INTO `UserLog` VALUES (4, '2021-04-06 15:50:35', 2, 2, NULL);

SET FOREIGN_KEY_CHECKS = 1;
