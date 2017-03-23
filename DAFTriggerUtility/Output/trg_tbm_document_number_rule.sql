DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_document_number_rule_RAI` $$                               
CREATE                               
TRIGGER `tbm_document_number_rule_RAI`                               
AFTER INSERT ON `tbm_document_number_rule`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_document_no_rule_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_number_rule_id,
		fips_code,
		doc_number_length,
		doc_number_output_legth,
		doc_year_part_count,
		doc_supress_year_part,
		doc_supress_leading_zero,
		doc_can_have_special,
		doc_can_have_alpha,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.doc_number_rule_id,
		NEW.fips_code,
		NEW.doc_number_length,
		NEW.doc_number_output_legth,
		NEW.doc_year_part_count,
		NEW.doc_supress_year_part,
		NEW.doc_supress_leading_zero,
		NEW.doc_can_have_special,
		NEW.doc_can_have_alpha,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_document_number_rule_RAU` $$                               
CREATE                               
TRIGGER `tbm_document_number_rule_RAU`                               
AFTER UPDATE ON `tbm_document_number_rule`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_document_no_rule_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_number_rule_id,
		fips_code,
		doc_number_length,
		doc_number_output_legth,
		doc_year_part_count,
		doc_supress_year_part,
		doc_supress_leading_zero,
		doc_can_have_special,
		doc_can_have_alpha,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.doc_number_rule_id,
		NEW.fips_code,
		NEW.doc_number_length,
		NEW.doc_number_output_legth,
		NEW.doc_year_part_count,
		NEW.doc_supress_year_part,
		NEW.doc_supress_leading_zero,
		NEW.doc_can_have_special,
		NEW.doc_can_have_alpha,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_document_number_rule_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_document_number_rule_RBD`                                 
BEFORE DELETE ON `tbm_document_number_rule`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_document_no_rule_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		doc_number_rule_id,
		fips_code,
		doc_number_length,
		doc_number_output_legth,
		doc_year_part_count,
		doc_supress_year_part,
		doc_supress_leading_zero,
		doc_can_have_special,
		doc_can_have_alpha,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.doc_number_rule_id,
		OLD.fips_code,
		OLD.doc_number_length,
		OLD.doc_number_output_legth,
		OLD.doc_year_part_count,
		OLD.doc_supress_year_part,
		OLD.doc_supress_leading_zero,
		OLD.doc_can_have_special,
		OLD.doc_can_have_alpha,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
