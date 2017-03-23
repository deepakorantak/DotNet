DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_lender_RAI` $$                               
CREATE                               
TRIGGER `tbm_lender_RAI`                               
AFTER INSERT ON `tbm_lender`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_lender_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		lender_code,
		lender_name,
		misc_code,
		misc_flag,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.lender_code,
		NEW.lender_name,
		NEW.misc_code,
		NEW.misc_flag,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_lender_RAU` $$                               
CREATE                               
TRIGGER `tbm_lender_RAU`                               
AFTER UPDATE ON `tbm_lender`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_lender_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		lender_code,
		lender_name,
		misc_code,
		misc_flag,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.lender_code,
		NEW.lender_name,
		NEW.misc_code,
		NEW.misc_flag,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_lender_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_lender_RBD`                                 
BEFORE DELETE ON `tbm_lender`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_lender_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		lender_code,
		lender_name,
		misc_code,
		misc_flag,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.lender_code,
		OLD.lender_name,
		OLD.misc_code,
		OLD.misc_flag,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
