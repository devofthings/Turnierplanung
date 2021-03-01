CREATE SCHEMA IF NOT EXISTS `tournament` DEFAULT CHARACTER SET utf8;
USE `tournament` ;

CREATE TABLE `tournament`.`team` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(50) NULL DEFAULT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `tournament`.`jobs` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `job` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `tournament`.`participant` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(50) NULL DEFAULT NULL,
    `surname` VARCHAR(50) NULL DEFAULT NULL,
    `age` DATE NULL DEFAULT NULL,
    `job_id` INT(11) NULL DEFAULT NULL,
    INDEX `fk_participant_job` (`job_id`),
    CONSTRAINT `fk_participant_job` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`id`),
    PRIMARY KEY (`id`)
);

CREATE TABLE `tournament`.`player` (
    `id` INT(11) NOT NULL AUTO_INCREMENT,
    `active` TINYINT(1) NULL,
    PRIMARY KEY (`id`),
    `participant_id` INT(11) NULL DEFAULT NULL,
    INDEX `fk_player_participant` (`participant_id`),
    CONSTRAINT `fk_player_participant` FOREIGN KEY (`participant_id`) REFERENCES `participant` (`id`),
    `team_id` INT(11) NULL DEFAULT NULL,
    INDEX `fk_player_team` (`team_id`),
    CONSTRAINT `fk_player_team` FOREIGN KEY (`team_id`) REFERENCES `team` (`id`),
    `job_id` INT(11) NULL DEFAULT NULL,
    INDEX `fk_player_job` (`job_id`),
    CONSTRAINT `fk_player_job` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`id`)
);
