DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_credential_RAI` $$                               
CREATE                               
TRIGGER `tbc_user_credential_RAI`                               
AFTER INSERT ON `tbc_user_credential`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_user_credential_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		logon_cd,
		consecutive_failures,
		modified_by,
		modified_dttm,
		password_txt,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.logon_cd,
		NEW.consecutive_failures,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.password_txt,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_credential_RAU` $$                               
CREATE                               
TRIGGER `tbc_user_credential_RAU`                               
AFTER UPDATE ON `tbc_user_credential`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_user_credential_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		logon_cd,
		consecutive_failures,
		modified_by,
		modified_dttm,
		password_txt,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.logon_cd,
		NEW.consecutive_failures,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.password_txt,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_credential_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_user_credential_RBD`                                 
BEFORE DELETE ON `tbc_user_credential`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_user_credential_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		logon_cd,
		consecutive_failures,
		modified_by,
		modified_dttm,
		password_txt,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.logon_cd,
		OLD.consecutive_failures,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.password_txt,
		OLD.version_no );
 
END$$ 
