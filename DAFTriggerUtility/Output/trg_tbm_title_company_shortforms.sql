DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_title_company_shortforms_RAI` $$                               
CREATE                               
TRIGGER `tbm_title_company_shortforms_RAI`                               
AFTER INSERT ON `tbm_title_company_shortforms`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_title_company_sf_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		short_form_id,
		short_form,
		fips_code,
		title_company_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.short_form_id,
		NEW.short_form,
		NEW.fips_code,
		NEW.title_company_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_title_company_shortforms_RAU` $$                               
CREATE                               
TRIGGER `tbm_title_company_shortforms_RAU`                               
AFTER UPDATE ON `tbm_title_company_shortforms`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_title_company_sf_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		short_form_id,
		short_form,
		fips_code,
		title_company_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.short_form_id,
		NEW.short_form,
		NEW.fips_code,
		NEW.title_company_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_title_company_shortforms_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_title_company_shortforms_RBD`                                 
BEFORE DELETE ON `tbm_title_company_shortforms`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_title_company_sf_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		short_form_id,
		short_form,
		fips_code,
		title_company_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.short_form_id,
		OLD.short_form,
		OLD.fips_code,
		OLD.title_company_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
