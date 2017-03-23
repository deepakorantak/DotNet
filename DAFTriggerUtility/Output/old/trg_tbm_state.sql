DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_state_RBI` $$                             
CREATE                             
TRIGGER `tbm_state_RBI`                             
BEFORE INSERT ON `tbm_state`                             
FOR EACH ROW
BEGIN 
	SET NEW.modified_dttm = NOW();                                   
	SET NEW.version_no = 1;                                    
	 
	/*No trigger condition*/ 
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_state_RAI` $$                               
CREATE                               
TRIGGER `tbm_state_RAI`                               
AFTER INSERT ON `tbm_state`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_state_history ( history_id,                                                     
		operation,                                                     
		state_code,
		state_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                     
		operation_value,                                                     
		NEW.state_code,
		NEW.state_name,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_state_RBU` $$                               
CREATE                               
TRIGGER `tbm_state_RBU`                               
BEFORE UPDATE ON `tbm_state`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                     
	SELECT 'Update' INTO operation_value;                                     
	SET NEW.modified_dttm = NOW();                                                                          
	
	IF OLD.version_no != NEW.version_no THEN                                  
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Version Mismatch' ;                                 
	END IF;
                                 
	SET NEW.version_no = NEW.version_no + 1;                                  
	IF NEW.active_flag = 'D' THEN                                  
		SELECT 'SoftDelete' INTO operation_value;                                  
	END IF;

	INSERT INTO tbm_state_history ( history_id,                                                     
		operation,                                                     
		state_code,
		state_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                     
		operation_value,                                                     
		NEW.state_code,
		NEW.state_name,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_state_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_state_RBD`                                 
BEFORE DELETE ON `tbm_state`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_state_history ( history_id,                                                       
		operation,                                                       
		state_code,
		state_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		OLD.state_code,
		OLD.state_name,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
