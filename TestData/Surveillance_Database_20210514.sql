/*
 Navicat Premium Data Transfer

 Source Server         : Linode-DNA (surveillance)
 Source Server Type    : MariaDB
 Source Server Version : 100038
 Source Host           : 139.162.77.207:3306
 Source Schema         : Surveillance

 Target Server Type    : MariaDB
 Target Server Version : 100038
 File Encoding         : 65001

 Date: 14/05/2021 17:09:15
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
  `ActionTime` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Seq`, `ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Compact;

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
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Compact;

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
  `StartTime` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `EndTime` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Seq`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Compact;

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
  `BatteryTime` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `IsRemote` int(1) UNSIGNED NOT NULL DEFAULT 1,
  `ActionTime` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Seq`, `ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 14 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of Door
-- ----------------------------
INSERT INTO `Door` VALUES (13, 2746218, 0, 'S202C_feb434', 'TF-3240 黑', 2, 55, '2021-05-11 16:25:09', 1, '0001-01-01 00:00:00');

-- ----------------------------
-- Table structure for EventLog
-- ----------------------------
DROP TABLE IF EXISTS `EventLog`;
CREATE TABLE `EventLog`  (
  `Seq` int(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `Time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DoorID` int(16) UNSIGNED NOT NULL DEFAULT 0,
  `CardID` int(16) UNSIGNED NOT NULL DEFAULT 0,
  `Status` int(2) UNSIGNED NOT NULL DEFAULT 0,
  `UserSeq` int(8) UNSIGNED NOT NULL DEFAULT 0,
  PRIMARY KEY (`Seq`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of EventLog
-- ----------------------------
INSERT INTO `EventLog` VALUES (1, '2021-03-26 10:48:25', 6001, 0, 1, 1);
INSERT INTO `EventLog` VALUES (2, '2021-03-26 10:49:29', 6001, 0, 2, 1);
INSERT INTO `EventLog` VALUES (3, '2021-03-26 11:31:11', 6001, 9001, 3, 0);

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
  `ActionTime` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP(0),
  `IP` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Seq`, `Account`) USING BTREE,
  FULLTEXT INDEX `Idx_User`(`Account`, `Name`)
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO `User` VALUES (1, 'Fish', 'fish', 'fish', 1, 1, '2021-05-14 16:21:36', '::1');
INSERT INTO `User` VALUES (2, 'Test', 'test', 'test', 0, 1, '2021-05-06 15:53:19', '192.168.0.123');
INSERT INTO `User` VALUES (3, 'Guest', 'guest', 'guest', 0, 0, '2021-01-01 08:00:00', NULL);
INSERT INTO `User` VALUES (4, 'Admin', 'admin', 'admin', 1, 1, '2021-05-08 00:06:03', '::1');

-- ----------------------------
-- Table structure for UserLog
-- ----------------------------
DROP TABLE IF EXISTS `UserLog`;
CREATE TABLE `UserLog`  (
  `Seq` int(8) UNSIGNED NOT NULL AUTO_INCREMENT,
  `Time` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UserSeq` int(8) UNSIGNED NOT NULL DEFAULT 0,
  `Status` int(2) UNSIGNED NOT NULL DEFAULT 0,
  `Note` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `IP` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Seq`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 48 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of UserLog
-- ----------------------------
INSERT INTO `UserLog` VALUES (1, '2021-03-26 10:26:34', 1, 1, '', '127.0.0.1');
INSERT INTO `UserLog` VALUES (2, '2021-03-26 10:26:42', 2, 1, '', '192.168.0.123');
INSERT INTO `UserLog` VALUES (3, '2021-04-06 15:50:22', 1, 2, '', '127.0.0.1');
INSERT INTO `UserLog` VALUES (4, '2021-04-06 15:50:35', 2, 2, '', '192.168.0.123');
INSERT INTO `UserLog` VALUES (5, '2021-05-06 09:54:40', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (6, '2021-05-06 10:12:57', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (7, '2021-05-06 10:48:50', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (8, '2021-05-06 13:07:14', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (9, '2021-05-06 13:11:36', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (10, '2021-05-06 13:20:19', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (11, '2021-05-06 14:35:12', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (12, '2021-05-06 15:49:27', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (13, '2021-05-06 21:39:47', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (14, '2021-05-06 21:42:28', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (15, '2021-05-06 21:43:08', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (16, '2021-05-06 22:35:13', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (17, '2021-05-06 22:36:58', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (18, '2021-05-06 22:38:40', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (19, '2021-05-06 22:43:17', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (20, '2021-05-06 22:51:25', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (21, '2021-05-06 23:03:15', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (22, '2021-05-06 23:06:44', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (23, '2021-05-06 23:20:22', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (24, '2021-05-06 23:49:00', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (25, '2021-05-07 16:15:16', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (26, '2021-05-07 16:54:51', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (27, '2021-05-07 17:26:14', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (28, '2021-05-07 18:00:56', 1, 1, '', '::1');
INSERT INTO `UserLog` VALUES (29, '2021-05-07 18:00:59', 1, 1, '', '::1');
INSERT INTO `UserLog` VALUES (30, '2021-05-07 18:01:54', 1, 1, '', '::1');
INSERT INTO `UserLog` VALUES (31, '2021-05-07 23:02:57', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (32, '2021-05-07 23:04:48', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (33, '2021-05-07 23:05:06', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (34, '2021-05-07 23:11:28', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (35, '2021-05-07 23:17:11', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (36, '2021-05-07 23:32:47', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (37, '2021-05-07 23:34:07', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (38, '2021-05-07 23:34:47', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (39, '2021-05-07 23:35:33', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (40, '2021-05-07 23:39:01', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (41, '2021-05-07 23:51:45', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (42, '2021-05-07 23:57:14', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (43, '2021-05-08 00:02:44', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (44, '2021-05-08 00:04:16', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (45, '2021-05-08 00:06:04', 4, 1, '', '::1');
INSERT INTO `UserLog` VALUES (46, '2021-05-14 15:04:49', 1, 1, '', '::1');
INSERT INTO `UserLog` VALUES (47, '2021-05-14 16:21:36', 1, 1, '', '::1');

SET FOREIGN_KEY_CHECKS = 1;
