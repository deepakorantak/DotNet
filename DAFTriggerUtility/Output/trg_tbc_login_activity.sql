DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_login_activity_RAI` $$                               
CREATE                               
TRIGGER `tbc_login_activity_RAI`                               
AFTER INSERT ON `tbc_login_activity`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_login_activity_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_session_id,
		user_cd,
		incoming_ip,
		start_time,
		end_time,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.user_session_id,
		NEW.user_cd,
		NEW.incoming_ip,
		NEW.start_time,
		NEW.end_time,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_login_activity_RAU` $$                               
CREATE                               
TRIGGER `tbc_login_activity_RAU`                               
AFTER UPDATE ON `tbc_login_activity`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_login_activity_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_session_id,
		user_cd,
		incoming_ip,
		start_time,
		end_time,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.user_session_id,
		NEW.user_cd,
		NEW.incoming_ip,
		NEW.start_time,
		NEW.end_time,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_login_activity_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_login_activity_RBD`                                 
BEFORE DELETE ON `tbc_login_activity`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_login_activity_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_session_id,
		user_cd,
		incoming_ip,
		start_time,
		end_time,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.user_session_id,
		OLD.user_cd,
		OLD.incoming_ip,
		OLD.start_time,
		OLD.end_time,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
