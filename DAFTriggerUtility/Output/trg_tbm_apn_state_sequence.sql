DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_apn_state_sequence_RAI` $$                               
CREATE                               
TRIGGER `tbm_apn_state_sequence_RAI`                               
AFTER INSERT ON `tbm_apn_state_sequence`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_apn_state_sequence_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		sequence_id,
		state_code,
		pattern,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.sequence_id,
		NEW.state_code,
		NEW.pattern,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_apn_state_sequence_RAU` $$                               
CREATE                               
TRIGGER `tbm_apn_state_sequence_RAU`                               
AFTER UPDATE ON `tbm_apn_state_sequence`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_apn_state_sequence_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		sequence_id,
		state_code,
		pattern,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.sequence_id,
		NEW.state_code,
		NEW.pattern,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_apn_state_sequence_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_apn_state_sequence_RBD`                                 
BEFORE DELETE ON `tbm_apn_state_sequence`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_apn_state_sequence_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		sequence_id,
		state_code,
		pattern,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.sequence_id,
		OLD.state_code,
		OLD.pattern,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
