DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_role_mst_RAI` $$                               
CREATE                               
TRIGGER `tbc_user_role_mst_RAI`                               
AFTER INSERT ON `tbc_user_role_mst`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_user_role_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_role_mst_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		role_cd,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.user_role_mst_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.role_cd,
		NEW.user_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_role_mst_RAU` $$                               
CREATE                               
TRIGGER `tbc_user_role_mst_RAU`                               
AFTER UPDATE ON `tbc_user_role_mst`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_user_role_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_role_mst_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		role_cd,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.user_role_mst_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.role_cd,
		NEW.user_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_role_mst_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_user_role_mst_RBD`                                 
BEFORE DELETE ON `tbc_user_role_mst`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_user_role_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_role_mst_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		role_cd,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.user_role_mst_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.role_cd,
		OLD.user_cd );
 
END$$ 
