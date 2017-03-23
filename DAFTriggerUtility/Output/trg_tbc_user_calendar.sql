DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_calendar_RAI` $$                               
CREATE                               
TRIGGER `tbc_user_calendar_RAI`                               
AFTER INSERT ON `tbc_user_calendar`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_user_calendar_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		calendar_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		available_no,
		calendar_date,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.calendar_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.available_no,
		NEW.calendar_date,
		NEW.user_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_calendar_RAU` $$                               
CREATE                               
TRIGGER `tbc_user_calendar_RAU`                               
AFTER UPDATE ON `tbc_user_calendar`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_user_calendar_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		calendar_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		available_no,
		calendar_date,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.calendar_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.available_no,
		NEW.calendar_date,
		NEW.user_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_calendar_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_user_calendar_RBD`                                 
BEFORE DELETE ON `tbc_user_calendar`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_user_calendar_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		calendar_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		available_no,
		calendar_date,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.calendar_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.available_no,
		OLD.calendar_date,
		OLD.user_cd );
 
END$$ 
