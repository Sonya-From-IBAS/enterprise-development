CREATE TABLE rector (
	id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
	version TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	full_name VARCHAR(100),
	degree SMALLINT CHECK(degree >= 1 and degree <= 2),
	rank SMALLINT CHECK(rank >=1 and rank <= 2)
);

CREATE TABLE institution (
	id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
	version TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	registration_number varchar(30),
	address varchar (100),
	rector_id uuid,
	building_ownership SMALLINT CHECK(building_ownership >= 1 and building_ownership <= 3),
	institution_ownership SMALLINT CHECK(institution_ownership >= 1 and institution_ownership <= 2),
	name VARCHAR(100),
	FOREIGN KEY (rector_id) REFERENCES rector(id)
);

CREATE TABLE faculty (
	id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
	version TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	name VARCHAR(100),
	institution_id uuid,
	FOREIGN KEY (institution_id) REFERENCES institution(id)
);

CREATE TABLE department (
	id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
	version TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	name VARCHAR(100),
	faculty_id uuid,
	FOREIGN KEY (faculty_id) REFERENCES faculty(id)
);

CREATE TABLE speciality (
	id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
	version TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	name VARCHAR(100),
	code varchar(20)
);

CREATE TABLE "group" (
	id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
	version TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	name VARCHAR(100),
	number varchar(20),
	department_id uuid,
	speciality_id uuid,
	FOREIGN KEY (department_id) REFERENCES department(id),
	FOREIGN KEY (speciality_id) REFERENCES speciality(id)
);

INSERT INTO rector (full_name, degree, rank) VALUES
  ('Иванов A.Ю', 1, 1),
  ('Петров В.А', 2, 2),
  ('Сидоров Н.П', 1, 1),
  ('Бобров А.М', 2, 2);

INSERT INTO institution (registration_number, address, rector_id, building_ownership, institution_ownership, name) VALUES
  ('test register1', 'test address1', (SELECT id FROM rector where full_name = 'Иванов A.Ю'), 1, 1, 'СГАУ'),
  ('test register2', 'test address2', (SELECT id FROM rector where full_name = 'Петров В.А'), 2, 1, 'САМГТУ'),
  ('test register3', 'test address3', (SELECT id FROM rector where full_name = 'Сидоров Н.П'), 3, 2, 'ПГУТИ'),
  ('test register4', 'test address4', (SELECT id FROM rector where full_name = 'Бобров А.М'), 1, 2, 'САМГМУ');


INSERT INTO faculty (name, institution_id) VALUES
    ('FC1', (SELECT id FROM institution WHERE name = 'СГАУ')),
	('FC2', (SELECT id FROM institution WHERE name = 'СГАУ')),
	('FC3', (SELECT id FROM institution WHERE name = 'САМГТУ')),
	('FC4', (SELECT id FROM institution WHERE name = 'ПГУТИ')),
	('FC5', (SELECT id FROM institution WHERE name = 'САМГМУ'));

INSERT INTO department (name, faculty_id) VALUES
('ГИИБ', (SELECT id FROM faculty WHERE name = 'FC1')),
('ИСТ', (SELECT id FROM faculty WHERE name = 'FC2')),
('ЛБС', (SELECT id FROM faculty WHERE name = 'FC3')),
('TEST1', (SELECT id FROM faculty WHERE name = 'FC4')),
('TEST2', (SELECT id FROM faculty WHERE name = 'FC4')),
('TEST3', (SELECT id FROM faculty WHERE name = 'FC5'));

INSERT INTO speciality (name, code) VALUES 
('SPEC1', '123456'),
('SPEC2', '234567'),
('SPEC3', '345678'),
('SPEC4', '456789'),
('SPEC5', '567890'),
('SPEC6', '678901');

INSERT INTO "group" (number, department_id, speciality_id) VALUES 
('6412-100503', (SELECT id FROM department WHERE name = 'ГИИБ'), (SELECT id FROM speciality WHERE code = '123456')),
('6411-100503', (SELECT id FROM department WHERE name = 'ИСТ'), (SELECT id FROM speciality WHERE code = '234567')),
('6413-100503', (SELECT id FROM department WHERE name = 'ИСТ'), (SELECT id FROM speciality WHERE code = '345678')),
('6414-100503', (SELECT id FROM department WHERE name = 'ЛБС'), (SELECT id FROM speciality WHERE code = '123456')),
('5101-100503', (SELECT id FROM department WHERE name = 'ЛБС'), (SELECT id FROM speciality WHERE code = '234567')),
('5102-100503', (SELECT id FROM department WHERE name = 'ЛБС'), (SELECT id FROM speciality WHERE code = '345678')),
('5103-100503', (SELECT id FROM department WHERE name = 'ЛБС'), (SELECT id FROM speciality WHERE code = '456789')),
('5104-100503', (SELECT id FROM department WHERE name = 'ЛБС'), (SELECT id FROM speciality WHERE code = '123456')),
('3221-100503', (SELECT id FROM department WHERE name = 'TEST1'), (SELECT id FROM speciality WHERE code = '123456')),
('3222-100503', (SELECT id FROM department WHERE name = 'TEST1'), (SELECT id FROM speciality WHERE code = '234567')),
('3223-100503', (SELECT id FROM department WHERE name = 'TEST1'), (SELECT id FROM speciality WHERE code = '345678')),
('3223-100503', (SELECT id FROM department WHERE name = 'TEST2'), (SELECT id FROM speciality WHERE code = '456789')),
('7405-100503', (SELECT id FROM department WHERE name = 'TEST2'), (SELECT id FROM speciality WHERE code = '456789')),
('7406-100503', (SELECT id FROM department WHERE name = 'TEST3'), (SELECT id FROM speciality WHERE code = '345678')),
('7407-100503', (SELECT id FROM department WHERE name = 'TEST3'), (SELECT id FROM speciality WHERE code = '234567')),
('7408-100503', (SELECT id FROM department WHERE name = 'TEST3'), (SELECT id FROM speciality WHERE code = '456789')),
('7409-100503', (SELECT id FROM department WHERE name = 'TEST3'), (SELECT id FROM speciality WHERE code = '567890'));
