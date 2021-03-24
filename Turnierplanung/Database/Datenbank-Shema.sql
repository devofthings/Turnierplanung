CREATE SCHEMA IF NOT EXISTS `tournament` DEFAULT CHARACTER SET utf8;
USE `tournament`;

CREATE TABLE `tournament`.`teams` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(50) NULL DEFAULT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `tournament`.`jobs` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `job` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `tournament`.`properties` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `property` VARCHAR(50) NOT NULL,
    `job_id` INT(11) NULL DEFAULT NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `tournament`.`participants` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `firstname` VARCHAR(50) NULL DEFAULT NULL,
    `lastname` VARCHAR(50) NULL DEFAULT NULL,
    `birthday` DATE NULL DEFAULT NULL,
    `job_id` INT(11) NULL DEFAULT NULL,
    `health_status` ENUM("Gesund", "Verletzt") DEFAULT 1,
    PRIMARY KEY (`id`),
    INDEX `participant_job` (`job_id`),
    CONSTRAINT `participant_job` FOREIGN KEY (`jobs_id`) REFERENCES `jobs` (`id`),
    INDEX `participant_properties` (`id`),
    CONSTRAINT `participant_properties` FOREIGN KEY (`participant_id`) REFERENCES `participants_properties` (`participant_id`)
);

CREATE TABLE `tournament`.`participants_properties` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `participant_id` INT(11) NOT NULL,
    `property_id` INT(11) NOT NULL,
    `property_value` VARCHAR(50) NULL DEFAULT NOT NULL
);

CREATE TABLE `tournament`.`participants_teams` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `participant_id` INT(11) NOT NULL,
    `team_id` INT(11) NOT NULL,
);