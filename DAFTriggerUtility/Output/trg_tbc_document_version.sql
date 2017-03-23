DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_document_version_RAI` $$                               
CREATE                               
TRIGGER `tbc_document_version_RAI`                               
AFTER INSERT ON `tbc_document_version`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_document_version_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		version_id,
		author_txt,
		comments_txt,
		modified_dttm,
		doc_id,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.version_id,
		NEW.author_txt,
		NEW.comments_txt,
		NEW.modified_dttm,
		NEW.doc_id,
		NEW.modified_by,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_document_version_RAU` $$                               
CREATE                               
TRIGGER `tbc_document_version_RAU`                               
AFTER UPDATE ON `tbc_document_version`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_document_version_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		version_id,
		author_txt,
		comments_txt,
		modified_dttm,
		doc_id,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.version_id,
		NEW.author_txt,
		NEW.comments_txt,
		NEW.modified_dttm,
		NEW.doc_id,
		NEW.modified_by,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_document_version_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_document_version_RBD`                                 
BEFORE DELETE ON `tbc_document_version`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_document_version_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		version_id,
		author_txt,
		comments_txt,
		modified_dttm,
		doc_id,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.version_id,
		OLD.author_txt,
		OLD.comments_txt,
		OLD.modified_dttm,
		OLD.doc_id,
		OLD.modified_by,
		OLD.version_no );
 
END$$ 
