DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_sub_document_type_new_RAI` $$                               
CREATE                               
TRIGGER `tbm_sub_document_type_new_RAI`                               
AFTER INSERT ON `tbm_sub_document_type_new`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_sub_document_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		bid,
		damar_code,
		document_type_id,
		sub_document_type_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.bid,
		NEW.damar_code,
		NEW.document_type_id,
		NEW.sub_document_type_name,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_sub_document_type_new_RAU` $$                               
CREATE                               
TRIGGER `tbm_sub_document_type_new_RAU`                               
AFTER UPDATE ON `tbm_sub_document_type_new`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_sub_document_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		bid,
		damar_code,
		document_type_id,
		sub_document_type_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.bid,
		NEW.damar_code,
		NEW.document_type_id,
		NEW.sub_document_type_name,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_sub_document_type_new_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_sub_document_type_new_RBD`                                 
BEFORE DELETE ON `tbm_sub_document_type_new`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_sub_document_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		bid,
		damar_code,
		document_type_id,
		sub_document_type_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.bid,
		OLD.damar_code,
		OLD.document_type_id,
		OLD.sub_document_type_name,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
