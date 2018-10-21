CREATE TABLE depot_order_equipment (
  depot_order_equipment_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  equipment_number VARCHAR(11) NOT NULL,
  depot_order_id BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY (depot_order_equipment_id),
  UNIQUE INDEX depot_order_equipment_id_UNIQUE (depot_order_equipment_id ASC) ,
  INDEX fk_depot_order_equipment_depot_order_idx (depot_order_id ASC) ,
  CONSTRAINT fk_depot_order_equipment_depot_order
    FOREIGN KEY (depot_order_id)
    REFERENCES depot_order (depot_order_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO depot_order_equipment (equipment_number,depot_order_id)
VALUES ('HLCU2323232',1)
