INSERT INTO participant (name, surname, age)
VALUES ('Max', 'Mustermann', 30), ('Julian', 'Brandt', 25), ('Marco', 'Reus', 31), ('Stefi', 'Graf', 44), ('Boris', 'Becker', 50);

INSERT INTO jobs (job)
VALUES('Fußballspieler'), ('Tennisspieler'), ('Handballspieler'), ('Trainer'), ('Zeugwart'), ('Physiologe');

INSERT INTO team (name) 
VALUES ('Borussia Dortmund'), ('Test');

INSERT INTO player (active, participant_id, team_id, job_id) VALUES (1, 1, 2), (1, 2, 1), (1, 3, 2), (1, 4, 1), (1, 5, 1), (1, 0, 1);