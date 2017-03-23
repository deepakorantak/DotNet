DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_content_RAI` $$                               
CREATE                               
TRIGGER `tbc_content_RAI`                               
AFTER INSERT ON `tbc_content`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_content_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		content_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		content,
		content_cd,
		content_type,
		effective_end_dttm,
		effective_start_dttm,
		submitted_content ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.content_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.content,
		NEW.content_cd,
		NEW.content_type,
		NEW.effective_end_dttm,
		NEW.effective_start_dttm,
		NEW.submitted_content );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_content_RAU` $$                               
CREATE                               
TRIGGER `tbc_content_RAU`                               
AFTER UPDATE ON `tbc_content`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_content_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		content_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		content,
		content_cd,
		content_type,
		effective_end_dttm,
		effective_start_dttm,
		submitted_content ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.content_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.content,
		NEW.content_cd,
		NEW.content_type,
		NEW.effective_end_dttm,
		NEW.effective_start_dttm,
		NEW.submitted_content );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_content_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_content_RBD`                                 
BEFORE DELETE ON `tbc_content`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_content_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		content_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		content,
		content_cd,
		content_type,
		effective_end_dttm,
		effective_start_dttm,
		submitted_content ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.content_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.content,
		OLD.content_cd,
		OLD.content_type,
		OLD.effective_end_dttm,
		OLD.effective_start_dttm,
		OLD.submitted_content );
 
END$$ 
