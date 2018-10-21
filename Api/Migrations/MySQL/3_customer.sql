CREATE TABLE customer (
  customer_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  name VARCHAR(50) NOT NULL,
  identification_number VARCHAR(20) NOT NULL,
  PRIMARY KEY (customer_id),
  UNIQUE INDEX customer_id_UNIQUE (customer_id ASC) ,
  UNIQUE INDEX identification_number_UNIQUE (identification_number ASC) )
ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO customer (name,identification_number)
SELECT 'Ripley S.A.','20101010101'
UNION
SELECT 'Saga Falabella S.A.','20202020202'
UNION
SELECT 'Gloria del Peru','20202020203'
UNION
SELECT 'Aceros del Peru','20202020204'
UNION
SELECT 'Policia Nacional del Peru','20202020205'
UNION
SELECT 'Bomberos Voluntarios del Peru','20202020206'
UNION
SELECT 'IBM','20202020207'
UNION
SELECT 'Microsoft Peru','20202020208'
UNION
SELECT 'Alicorp','20202020209'
UNION
SELECT 'UNMSM','20202020210'