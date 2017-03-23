DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_location_RAI` $$                               
CREATE                               
TRIGGER `tbm_location_RAI`                               
AFTER INSERT ON `tbm_location`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_location_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		location_code,
		description,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.location_code,
		NEW.description,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_location_RAU` $$                               
CREATE                               
TRIGGER `tbm_location_RAU`                               
AFTER UPDATE ON `tbm_location`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_location_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		location_code,
		description,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.location_code,
		NEW.description,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_location_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_location_RBD`                                 
BEFORE DELETE ON `tbm_location`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_location_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		location_code,
		description,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.location_code,
		OLD.description,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
