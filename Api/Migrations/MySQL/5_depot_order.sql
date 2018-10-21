CREATE TABLE depot_order (
  depot_order_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  document_number VARCHAR(20) NOT NULL,
  request_date DATETIME NOT NULL,
  port_id BIGINT UNSIGNED NOT NULL,
  customer_id BIGINT UNSIGNED NOT NULL,
  ocean_carrier_id BIGINT UNSIGNED NOT NULL,
  currency_id BIGINT UNSIGNED NOT NULL,
  total_amount DECIMAL(16,2) NOT NULL,
  PRIMARY KEY (depot_order_id),
  UNIQUE INDEX depot_order_id_UNIQUE (depot_order_id ASC) ,
  INDEX fk_depot_order_port1_idx (port_id ASC) ,
  INDEX fk_depot_order_customer1_idx (customer_id ASC) ,
  INDEX fk_depot_order_ocean_carrier1_idx (ocean_carrier_id ASC) ,
  UNIQUE INDEX depot_order_document_number_UNIQUE (document_number ASC, ocean_carrier_id ASC) ,
  INDEX fk_depot_order_currency1_idx (currency_id ASC) ,
  CONSTRAINT fk_depot_order_port1
    FOREIGN KEY (port_id)
    REFERENCES port (port_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_depot_order_customer1
    FOREIGN KEY (customer_id)
    REFERENCES customer (customer_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_depot_order_ocean_carrier1
    FOREIGN KEY (ocean_carrier_id)
    REFERENCES ocean_carrier (ocean_carrier_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_depot_order_currency1
    FOREIGN KEY (currency_id)
    REFERENCES currency (currency_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO depot_order(document_number,request_date,total_amount,currency_id,port_id,ocean_carrier_id,customer_id)
VALUES ('HLCU2018102001','2018-10-20',1500.58,604,1,1,1)