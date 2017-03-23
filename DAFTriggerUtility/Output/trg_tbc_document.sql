DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_document_RAI` $$                               
CREATE                               
TRIGGER `tbc_document_RAI`                               
AFTER INSERT ON `tbc_document`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_document_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_id,
		author_txt,
		context_id,
		context_type,
		modified_dttm,
		doc_title_txt,
		doc_type_txt,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.doc_id,
		NEW.author_txt,
		NEW.context_id,
		NEW.context_type,
		NEW.modified_dttm,
		NEW.doc_title_txt,
		NEW.doc_type_txt,
		NEW.modified_by,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_document_RAU` $$                               
CREATE                               
TRIGGER `tbc_document_RAU`                               
AFTER UPDATE ON `tbc_document`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_document_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_id,
		author_txt,
		context_id,
		context_type,
		modified_dttm,
		doc_title_txt,
		doc_type_txt,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.doc_id,
		NEW.author_txt,
		NEW.context_id,
		NEW.context_type,
		NEW.modified_dttm,
		NEW.doc_title_txt,
		NEW.doc_type_txt,
		NEW.modified_by,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_document_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_document_RBD`                                 
BEFORE DELETE ON `tbc_document`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_document_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_id,
		author_txt,
		context_id,
		context_type,
		modified_dttm,
		doc_title_txt,
		doc_type_txt,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.doc_id,
		OLD.author_txt,
		OLD.context_id,
		OLD.context_type,
		OLD.modified_dttm,
		OLD.doc_title_txt,
		OLD.doc_type_txt,
		OLD.modified_by,
		OLD.version_no );
 
END$$ 
