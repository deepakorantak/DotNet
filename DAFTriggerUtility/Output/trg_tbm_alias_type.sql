DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_alias_type_RAI` $$                               
CREATE                               
TRIGGER `tbm_alias_type_RAI`                               
AFTER INSERT ON `tbm_alias_type`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_alias_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		alias_type_code,
		description,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.alias_type_code,
		NEW.description,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_alias_type_RAU` $$                               
CREATE                               
TRIGGER `tbm_alias_type_RAU`                               
AFTER UPDATE ON `tbm_alias_type`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_alias_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		alias_type_code,
		description,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.alias_type_code,
		NEW.description,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_alias_type_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_alias_type_RBD`                                 
BEFORE DELETE ON `tbm_alias_type`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_alias_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		alias_type_code,
		description,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.alias_type_code,
		OLD.description,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
