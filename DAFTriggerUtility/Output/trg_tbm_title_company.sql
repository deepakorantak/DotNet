DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_title_company_RAI` $$                               
CREATE                               
TRIGGER `tbm_title_company_RAI`                               
AFTER INSERT ON `tbm_title_company`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_title_company_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		title_company_code,
		title_company_name,
		misc_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.title_company_code,
		NEW.title_company_name,
		NEW.misc_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_title_company_RAU` $$                               
CREATE                               
TRIGGER `tbm_title_company_RAU`                               
AFTER UPDATE ON `tbm_title_company`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_title_company_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		title_company_code,
		title_company_name,
		misc_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.title_company_code,
		NEW.title_company_name,
		NEW.misc_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_title_company_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_title_company_RBD`                                 
BEFORE DELETE ON `tbm_title_company`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_title_company_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		title_company_code,
		title_company_name,
		misc_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.title_company_code,
		OLD.title_company_name,
		OLD.misc_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
