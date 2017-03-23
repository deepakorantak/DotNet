DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbt_document_RAI` $$                               
CREATE                               
TRIGGER `tbt_document_RAI`                               
AFTER INSERT ON `tbt_document`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbt_document_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_id,
		mongo_doc_id,
		document_type_cd,
		fips_code,
		sla_ts,
		status,
		assigned_to,
		created_dttm,
		created_by,
		doc_version_no,
		modified_dttm,
		active_flag,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.doc_id,
		NEW.mongo_doc_id,
		NEW.document_type_cd,
		NEW.fips_code,
		NEW.sla_ts,
		NEW.status,
		NEW.assigned_to,
		NEW.created_dttm,
		NEW.created_by,
		NEW.doc_version_no,
		NEW.modified_dttm,
		NEW.active_flag,
		NEW.modified_by,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbt_document_RAU` $$                               
CREATE                               
TRIGGER `tbt_document_RAU`                               
AFTER UPDATE ON `tbt_document`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbt_document_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_id,
		mongo_doc_id,
		document_type_cd,
		fips_code,
		sla_ts,
		status,
		assigned_to,
		created_dttm,
		created_by,
		doc_version_no,
		modified_dttm,
		active_flag,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.doc_id,
		NEW.mongo_doc_id,
		NEW.document_type_cd,
		NEW.fips_code,
		NEW.sla_ts,
		NEW.status,
		NEW.assigned_to,
		NEW.created_dttm,
		NEW.created_by,
		NEW.doc_version_no,
		NEW.modified_dttm,
		NEW.active_flag,
		NEW.modified_by,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbt_document_RBD` $$                                 
CREATE                                 
TRIGGER `tbt_document_RBD`                                 
BEFORE DELETE ON `tbt_document`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbt_document_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_id,
		mongo_doc_id,
		document_type_cd,
		fips_code,
		sla_ts,
		status,
		assigned_to,
		created_dttm,
		created_by,
		doc_version_no,
		modified_dttm,
		active_flag,
		modified_by,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.doc_id,
		OLD.mongo_doc_id,
		OLD.document_type_cd,
		OLD.fips_code,
		OLD.sla_ts,
		OLD.status,
		OLD.assigned_to,
		OLD.created_dttm,
		OLD.created_by,
		OLD.doc_version_no,
		OLD.modified_dttm,
		OLD.active_flag,
		OLD.modified_by,
		OLD.version_no );
 
END$$ 
