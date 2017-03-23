DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_group_user_mst_RAI` $$                               
CREATE                               
TRIGGER `tbc_group_user_mst_RAI`                               
AFTER INSERT ON `tbc_group_user_mst`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_group_user_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		group_user_mst_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		group_cd,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.group_user_mst_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.group_cd,
		NEW.user_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_group_user_mst_RAU` $$                               
CREATE                               
TRIGGER `tbc_group_user_mst_RAU`                               
AFTER UPDATE ON `tbc_group_user_mst`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_group_user_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		group_user_mst_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		group_cd,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.group_user_mst_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.group_cd,
		NEW.user_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_group_user_mst_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_group_user_mst_RBD`                                 
BEFORE DELETE ON `tbc_group_user_mst`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_group_user_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		group_user_mst_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		group_cd,
		user_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.group_user_mst_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.group_cd,
		OLD.user_cd );
 
END$$ 
