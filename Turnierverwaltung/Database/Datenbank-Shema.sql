CREATE SCHEMA tournament;
USE tournament;

CREATE TABLE tournament.teams (
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(50) DEFAULT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE tournament.jobs (
    id INT NOT NULL AUTO_INCREMENT,
    job VARCHAR(50) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE tournament.properties (
    id INT NOT NULL AUTO_INCREMENT,
    property VARCHAR(50) NOT NULL,
    job_id INT NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE tournament.participants (
    id INT NOT NULL AUTO_INCREMENT,
    firstname VARCHAR(50) NULL DEFAULT NULL,
    lastname VARCHAR(50) NULL DEFAULT NULL,
    birthday DATE NULL DEFAULT NULL,
    job_id INT(11) NULL DEFAULT NULL,
    health_status ENUM("Gesund", "Verletzt") DEFAULT "Gesund",
    PRIMARY KEY (id),
    INDEX participant_job (job_id),
    CONSTRAINT participant_job FOREIGN KEY (job_id) REFERENCES jobs (id)
    /* TODO enable props
    INDEX participant_properties (id),
    CONSTRAINT participant_properties FOREIGN KEY (participant_id) REFERENCES participants_properties (participant_id)
    */
);

CREATE TABLE tournament.participants_properties (
    id INT NOT NULL AUTO_INCREMENT,
    participant_id INT NOT NULL,
    property_id INT NOT NULL,
    property_value VARCHAR(50) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE tournament.participants_teams (
    id INT NOT NULL AUTO_INCREMENT,
    participant_id INT(11) NOT NULL,
    team_id INT(11) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE tournament.tournament_participants (
    id INT NOT NULL AUTO_INCREMENT,
    participant_id INT(11),
    team_id INT(11),
    PRIMARY KEY (id)
);