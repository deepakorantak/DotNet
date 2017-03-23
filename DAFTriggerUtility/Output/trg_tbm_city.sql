DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_city_RAI` $$                               
CREATE                               
TRIGGER `tbm_city_RAI`                               
AFTER INSERT ON `tbm_city`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_city_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		city_id,
		city_name,
		state_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.city_id,
		NEW.city_name,
		NEW.state_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_city_RAU` $$                               
CREATE                               
TRIGGER `tbm_city_RAU`                               
AFTER UPDATE ON `tbm_city`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_city_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		city_id,
		city_name,
		state_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.city_id,
		NEW.city_name,
		NEW.state_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_city_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_city_RBD`                                 
BEFORE DELETE ON `tbm_city`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_city_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		city_id,
		city_name,
		state_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.city_id,
		OLD.city_name,
		OLD.state_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
