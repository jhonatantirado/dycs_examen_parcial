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