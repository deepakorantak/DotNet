DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_country_RAI` $$                               
CREATE                               
TRIGGER `tbm_country_RAI`                               
AFTER INSERT ON `tbm_country`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_country_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		country_id,
		country_code,
		country_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.country_id,
		NEW.country_code,
		NEW.country_name,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_country_RAU` $$                               
CREATE                               
TRIGGER `tbm_country_RAU`                               
AFTER UPDATE ON `tbm_country`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_country_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		country_id,
		country_code,
		country_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.country_id,
		NEW.country_code,
		NEW.country_name,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_country_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_country_RBD`                                 
BEFORE DELETE ON `tbm_country`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_country_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		country_id,
		country_code,
		country_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.country_id,
		OLD.country_code,
		OLD.country_name,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
