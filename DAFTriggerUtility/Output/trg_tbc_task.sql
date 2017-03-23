DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_task_RAI` $$                               
CREATE                               
TRIGGER `tbc_task_RAI`                               
AFTER INSERT ON `tbc_task`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_task_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		task_id,
		category,
		context_id,
		context_type,
		modified_dttm,
		created_by,
		task_desc_txt,
		due_dttm,
		modified_by,
		owner_cd,
		reassign_text,
		resolution,
		status_txt,
		task_title_txt,
		task_type_txt,
		version_no,
		parent_task_id ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.task_id,
		NEW.category,
		NEW.context_id,
		NEW.context_type,
		NEW.modified_dttm,
		NEW.created_by,
		NEW.task_desc_txt,
		NEW.due_dttm,
		NEW.modified_by,
		NEW.owner_cd,
		NEW.reassign_text,
		NEW.resolution,
		NEW.status_txt,
		NEW.task_title_txt,
		NEW.task_type_txt,
		NEW.version_no,
		NEW.parent_task_id );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_task_RAU` $$                               
CREATE                               
TRIGGER `tbc_task_RAU`                               
AFTER UPDATE ON `tbc_task`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_task_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		task_id,
		category,
		context_id,
		context_type,
		modified_dttm,
		created_by,
		task_desc_txt,
		due_dttm,
		modified_by,
		owner_cd,
		reassign_text,
		resolution,
		status_txt,
		task_title_txt,
		task_type_txt,
		version_no,
		parent_task_id ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.task_id,
		NEW.category,
		NEW.context_id,
		NEW.context_type,
		NEW.modified_dttm,
		NEW.created_by,
		NEW.task_desc_txt,
		NEW.due_dttm,
		NEW.modified_by,
		NEW.owner_cd,
		NEW.reassign_text,
		NEW.resolution,
		NEW.status_txt,
		NEW.task_title_txt,
		NEW.task_type_txt,
		NEW.version_no,
		NEW.parent_task_id );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_task_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_task_RBD`                                 
BEFORE DELETE ON `tbc_task`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_task_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		task_id,
		category,
		context_id,
		context_type,
		modified_dttm,
		created_by,
		task_desc_txt,
		due_dttm,
		modified_by,
		owner_cd,
		reassign_text,
		resolution,
		status_txt,
		task_title_txt,
		task_type_txt,
		version_no,
		parent_task_id ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.task_id,
		OLD.category,
		OLD.context_id,
		OLD.context_type,
		OLD.modified_dttm,
		OLD.created_by,
		OLD.task_desc_txt,
		OLD.due_dttm,
		OLD.modified_by,
		OLD.owner_cd,
		OLD.reassign_text,
		OLD.resolution,
		OLD.status_txt,
		OLD.task_title_txt,
		OLD.task_type_txt,
		OLD.version_no,
		OLD.parent_task_id );
 
END$$ 
