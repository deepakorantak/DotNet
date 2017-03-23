DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_allocation_RAI` $$                               
CREATE                               
TRIGGER `tbc_allocation_RAI`                               
AFTER INSERT ON `tbc_allocation`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_allocation_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		allocation_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		due_date,
		entity_id,
		entity_type,
		group_cd,
		status,
		user_cd,
		work_type_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.allocation_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.due_date,
		NEW.entity_id,
		NEW.entity_type,
		NEW.group_cd,
		NEW.status,
		NEW.user_cd,
		NEW.work_type_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_allocation_RAU` $$                               
CREATE                               
TRIGGER `tbc_allocation_RAU`                               
AFTER UPDATE ON `tbc_allocation`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_allocation_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		allocation_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		due_date,
		entity_id,
		entity_type,
		group_cd,
		status,
		user_cd,
		work_type_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.allocation_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.due_date,
		NEW.entity_id,
		NEW.entity_type,
		NEW.group_cd,
		NEW.status,
		NEW.user_cd,
		NEW.work_type_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_allocation_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_allocation_RBD`                                 
BEFORE DELETE ON `tbc_allocation`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_allocation_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		allocation_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		due_date,
		entity_id,
		entity_type,
		group_cd,
		status,
		user_cd,
		work_type_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.allocation_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.due_date,
		OLD.entity_id,
		OLD.entity_type,
		OLD.group_cd,
		OLD.status,
		OLD.user_cd,
		OLD.work_type_cd );
 
END$$ 
