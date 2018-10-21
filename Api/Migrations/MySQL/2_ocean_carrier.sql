CREATE TABLE ocean_carrier (
  ocean_carrier_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  name VARCHAR(50) NULL,
  scac_code VARCHAR(10) NULL,
  PRIMARY KEY (ocean_carrier_id),
  UNIQUE INDEX ocean_carrier_id_UNIQUE (ocean_carrier_id ASC) ,
  UNIQUE INDEX scac_code_UNIQUE (scac_code ASC) )
ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO ocean_carrier (name,scac_code)
SELECT 'Hapag Lloyd','HLCU'
UNION
SELECT 'Mediterranean Shipping Company','MSCU'