DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_work_assignment_RAI` $$                               
CREATE                               
TRIGGER `tbc_work_assignment_RAI`                               
AFTER INSERT ON `tbc_work_assignment`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_work_assignment_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		assignment_id,
		assigned_dttm,
		completed_dttm,
		entity_id,
		modified_by,
		modified_dttm,
		status_txt,
		user_cd,
		version_no,
		work_mgr_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.assignment_id,
		NEW.assigned_dttm,
		NEW.completed_dttm,
		NEW.entity_id,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.status_txt,
		NEW.user_cd,
		NEW.version_no,
		NEW.work_mgr_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_work_assignment_RAU` $$                               
CREATE                               
TRIGGER `tbc_work_assignment_RAU`                               
AFTER UPDATE ON `tbc_work_assignment`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_work_assignment_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		assignment_id,
		assigned_dttm,
		completed_dttm,
		entity_id,
		modified_by,
		modified_dttm,
		status_txt,
		user_cd,
		version_no,
		work_mgr_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.assignment_id,
		NEW.assigned_dttm,
		NEW.completed_dttm,
		NEW.entity_id,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.status_txt,
		NEW.user_cd,
		NEW.version_no,
		NEW.work_mgr_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_work_assignment_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_work_assignment_RBD`                                 
BEFORE DELETE ON `tbc_work_assignment`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_work_assignment_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		assignment_id,
		assigned_dttm,
		completed_dttm,
		entity_id,
		modified_by,
		modified_dttm,
		status_txt,
		user_cd,
		version_no,
		work_mgr_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.assignment_id,
		OLD.assigned_dttm,
		OLD.completed_dttm,
		OLD.entity_id,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.status_txt,
		OLD.user_cd,
		OLD.version_no,
		OLD.work_mgr_cd );
 
END$$ 
