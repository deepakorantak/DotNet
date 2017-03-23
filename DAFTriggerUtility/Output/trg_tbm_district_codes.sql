DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_district_codes_RAI` $$                               
CREATE                               
TRIGGER `tbm_district_codes_RAI`                               
AFTER INSERT ON `tbm_district_codes`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_district_codes_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		district_id,
		fips_code,
		district_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.district_id,
		NEW.fips_code,
		NEW.district_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_district_codes_RAU` $$                               
CREATE                               
TRIGGER `tbm_district_codes_RAU`                               
AFTER UPDATE ON `tbm_district_codes`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_district_codes_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		district_id,
		fips_code,
		district_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.district_id,
		NEW.fips_code,
		NEW.district_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_district_codes_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_district_codes_RBD`                                 
BEFORE DELETE ON `tbm_district_codes`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_district_codes_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		district_id,
		fips_code,
		district_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.district_id,
		OLD.fips_code,
		OLD.district_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
