DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_county_RAI` $$                               
CREATE                               
TRIGGER `tbm_county_RAI`                               
AFTER INSERT ON `tbm_county`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_county_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.fips_code,
		NEW.state_code,
		NEW.county_code,
		NEW.county_name,
		NEW.remi_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_county_RAU` $$                               
CREATE                               
TRIGGER `tbm_county_RAU`                               
AFTER UPDATE ON `tbm_county`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_county_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.fips_code,
		NEW.state_code,
		NEW.county_code,
		NEW.county_name,
		NEW.remi_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_county_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_county_RBD`                                 
BEFORE DELETE ON `tbm_county`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_county_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.fips_code,
		OLD.state_code,
		OLD.county_code,
		OLD.county_name,
		OLD.remi_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
