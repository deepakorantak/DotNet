DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_document_type_RAI` $$                               
CREATE                               
TRIGGER `tbm_document_type_RAI`                               
AFTER INSERT ON `tbm_document_type`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_document_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		document_type_cd,
		sub_document_type_name,
		deed_category_code,
		damar_code,
		document_type_name,
		output_format_code,
		field_configuration_ref,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		document_type_id,
		deed_category_code,
		document_type_name,
		output_format_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.document_type_cd,
		NEW.sub_document_type_name,
		NEW.deed_category_code,
		NEW.damar_code,
		NEW.document_type_name,
		NEW.output_format_code,
		NEW.field_configuration_ref,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.document_type_id,
		NEW.deed_category_code,
		NEW.document_type_name,
		NEW.output_format_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_document_type_RAU` $$                               
CREATE                               
TRIGGER `tbm_document_type_RAU`                               
AFTER UPDATE ON `tbm_document_type`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_document_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		document_type_cd,
		sub_document_type_name,
		deed_category_code,
		damar_code,
		document_type_name,
		output_format_code,
		field_configuration_ref,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		document_type_id,
		deed_category_code,
		document_type_name,
		output_format_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.document_type_cd,
		NEW.sub_document_type_name,
		NEW.deed_category_code,
		NEW.damar_code,
		NEW.document_type_name,
		NEW.output_format_code,
		NEW.field_configuration_ref,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.document_type_id,
		NEW.deed_category_code,
		NEW.document_type_name,
		NEW.output_format_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_document_type_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_document_type_RBD`                                 
BEFORE DELETE ON `tbm_document_type`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_document_type_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		document_type_cd,
		sub_document_type_name,
		deed_category_code,
		damar_code,
		document_type_name,
		output_format_code,
		field_configuration_ref,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		document_type_id,
		deed_category_code,
		document_type_name,
		output_format_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.document_type_cd,
		OLD.sub_document_type_name,
		OLD.deed_category_code,
		OLD.damar_code,
		OLD.document_type_name,
		OLD.output_format_code,
		OLD.field_configuration_ref,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.document_type_id,
		OLD.deed_category_code,
		OLD.document_type_name,
		OLD.output_format_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
