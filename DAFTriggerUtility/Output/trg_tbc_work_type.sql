DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_work_type_RAI` $$                               
CREATE                               
TRIGGER `tbc_work_type_RAI`                               
AFTER INSERT ON `tbc_work_type`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_work_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		work_type_cd,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		work_size,
		work_type_name ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.work_type_cd,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.work_size,
		NEW.work_type_name );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_work_type_RAU` $$                               
CREATE                               
TRIGGER `tbc_work_type_RAU`                               
AFTER UPDATE ON `tbc_work_type`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_work_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		work_type_cd,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		work_size,
		work_type_name ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.work_type_cd,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.work_size,
		NEW.work_type_name );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_work_type_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_work_type_RBD`                                 
BEFORE DELETE ON `tbc_work_type`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_work_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		work_type_cd,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		work_size,
		work_type_name ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.work_type_cd,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.work_size,
		OLD.work_type_name );
 
END$$ 
