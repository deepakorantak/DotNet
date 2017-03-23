DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_tax_rate_RAI` $$                               
CREATE                               
TRIGGER `tbm_tax_rate_RAI`                               
AFTER INSERT ON `tbm_tax_rate`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_tax_rate_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		tax_rate_id,
		fips_code,
		min_amount,
		min_tax_stamp_amount,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.tax_rate_id,
		NEW.fips_code,
		NEW.min_amount,
		NEW.min_tax_stamp_amount,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_tax_rate_RAU` $$                               
CREATE                               
TRIGGER `tbm_tax_rate_RAU`                               
AFTER UPDATE ON `tbm_tax_rate`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_tax_rate_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		tax_rate_id,
		fips_code,
		min_amount,
		min_tax_stamp_amount,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.tax_rate_id,
		NEW.fips_code,
		NEW.min_amount,
		NEW.min_tax_stamp_amount,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_tax_rate_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_tax_rate_RBD`                                 
BEFORE DELETE ON `tbm_tax_rate`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_tax_rate_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		tax_rate_id,
		fips_code,
		min_amount,
		min_tax_stamp_amount,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.tax_rate_id,
		OLD.fips_code,
		OLD.min_amount,
		OLD.min_tax_stamp_amount,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
