DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_credit_line_RAI` $$                               
CREATE                               
TRIGGER `tbm_credit_line_RAI`                               
AFTER INSERT ON `tbm_credit_line`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_credit_line_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		credit_line_id,
		credit_code,
		description,
		priority,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.credit_line_id,
		NEW.credit_code,
		NEW.description,
		NEW.priority,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_credit_line_RAU` $$                               
CREATE                               
TRIGGER `tbm_credit_line_RAU`                               
AFTER UPDATE ON `tbm_credit_line`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_credit_line_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		credit_line_id,
		credit_code,
		description,
		priority,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.credit_line_id,
		NEW.credit_code,
		NEW.description,
		NEW.priority,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_credit_line_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_credit_line_RBD`                                 
BEFORE DELETE ON `tbm_credit_line`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_credit_line_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		credit_line_id,
		credit_code,
		description,
		priority,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.credit_line_id,
		OLD.credit_code,
		OLD.description,
		OLD.priority,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
