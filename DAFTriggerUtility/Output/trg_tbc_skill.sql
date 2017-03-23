DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_skill_RAI` $$                               
CREATE                               
TRIGGER `tbc_skill_RAI`                               
AFTER INSERT ON `tbc_skill`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_skill_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		skill_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		capacity,
		user_cd,
		work_type_cd,
		priority,
		role_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.skill_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.capacity,
		NEW.user_cd,
		NEW.work_type_cd,
		NEW.priority,
		NEW.role_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_skill_RAU` $$                               
CREATE                               
TRIGGER `tbc_skill_RAU`                               
AFTER UPDATE ON `tbc_skill`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_skill_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		skill_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		capacity,
		user_cd,
		work_type_cd,
		priority,
		role_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.skill_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.capacity,
		NEW.user_cd,
		NEW.work_type_cd,
		NEW.priority,
		NEW.role_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_skill_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_skill_RBD`                                 
BEFORE DELETE ON `tbc_skill`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_skill_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		skill_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		capacity,
		user_cd,
		work_type_cd,
		priority,
		role_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.skill_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.capacity,
		OLD.user_cd,
		OLD.work_type_cd,
		OLD.priority,
		OLD.role_cd );
 
END$$ 
