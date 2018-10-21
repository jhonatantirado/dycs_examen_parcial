CREATE TABLE port (
  port_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  name VARCHAR(50) NOT NULL,
  iso_code VARCHAR(5) NOT NULL,
  PRIMARY KEY (port_id),
  UNIQUE INDEX port_id_UNIQUE (port_id ASC) ,
  UNIQUE INDEX iso_code_UNIQUE (iso_code ASC) )
ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO port (name,iso_code)
SELECT 'Callao','PECLL'
UNION
SELECT 'Ilo','PEILQ'
UNION
SELECT 'Salaverry','PESVY'