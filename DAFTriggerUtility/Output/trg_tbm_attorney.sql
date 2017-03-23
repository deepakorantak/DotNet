DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_attorney_RAI` $$                               
CREATE                               
TRIGGER `tbm_attorney_RAI`                               
AFTER INSERT ON `tbm_attorney`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_attorney_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		attorney_code,
		attorney_name,
		misc_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.attorney_code,
		NEW.attorney_name,
		NEW.misc_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_attorney_RAU` $$                               
CREATE                               
TRIGGER `tbm_attorney_RAU`                               
AFTER UPDATE ON `tbm_attorney`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_attorney_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		attorney_code,
		attorney_name,
		misc_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.attorney_code,
		NEW.attorney_name,
		NEW.misc_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_attorney_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_attorney_RBD`                                 
BEFORE DELETE ON `tbm_attorney`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_attorney_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		attorney_code,
		attorney_name,
		misc_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.attorney_code,
		OLD.attorney_name,
		OLD.misc_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
