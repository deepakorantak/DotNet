DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_task_note_RAI` $$                               
CREATE                               
TRIGGER `tbc_task_note_RAI`                               
AFTER INSERT ON `tbc_task_note`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_task_note_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		note_id,
		author_txt,
		context_id,
		context_type,
		modified_by,
		modified_dttm,
		notes_txt,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.note_id,
		NEW.author_txt,
		NEW.context_id,
		NEW.context_type,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.notes_txt,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_task_note_RAU` $$                               
CREATE                               
TRIGGER `tbc_task_note_RAU`                               
AFTER UPDATE ON `tbc_task_note`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_task_note_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		note_id,
		author_txt,
		context_id,
		context_type,
		modified_by,
		modified_dttm,
		notes_txt,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.note_id,
		NEW.author_txt,
		NEW.context_id,
		NEW.context_type,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.notes_txt,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_task_note_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_task_note_RBD`                                 
BEFORE DELETE ON `tbc_task_note`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_task_note_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		note_id,
		author_txt,
		context_id,
		context_type,
		modified_by,
		modified_dttm,
		notes_txt,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.note_id,
		OLD.author_txt,
		OLD.context_id,
		OLD.context_type,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.notes_txt,
		OLD.version_no );
 
END$$ 
