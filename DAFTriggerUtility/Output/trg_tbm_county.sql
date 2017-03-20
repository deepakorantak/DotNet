DELIMITER $$

 Use `daf2` $$

CREATE                             
DEFINER=`daf2`@`%`                             
TRIGGER `tbm_county_RBI`                             
BEFORE INSERT ON `tbm_county`                             
FOR EACH ROW
BEGIN 
	SET NEW.modified_dttm = NOW();                                   
	SET NEW.version_no = 1;                                    
	 
	/*No trigger condition*/ 
 
END$$ 
DELIMITER $$

 Use `daf2` $$

CREATE                               
DEFINER=`daf2`@`%`                               
TRIGGER `tbm_county_RAI`                               
AFTER INSERT ON `tbm_county`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_county_history ( history_id,                                                     
		operation,                                                     
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                     
		operation_value,                                                     
		NEW.fips_code,
		NEW.state_code,
		NEW.county_code,
		NEW.county_name,
		NEW.remi_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

CREATE                               
DEFINER=`daf2`@`%`                               
TRIGGER `tbm_county_RBU`                               
BEFORE UPDATE ON `tbm_county`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                     
	SELECT 'Update' INTO operation_value;                                     
	SET NEW.modified_dttm = NOW();                                      
	SET NEW.version_no = NEW.version_no + 1;                                      
	
	IF OLD.version_no != NEW.version_no THEN                                  
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Version Mismatch' ;                                 
	END IF;
                                 
	IF NEW.active_flag = 'D' THEN                                  
		SELECT 'SoftDelete' INTO operation_value;                                  
	END IF;

	INSERT INTO tbm_county_history ( history_id,                                                     
		operation,                                                     
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                     
		operation_value,                                                     
		NEW.fips_code,
		NEW.state_code,
		NEW.county_code,
		NEW.county_name,
		NEW.remi_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

CREATE                                 
DEFINER=`daf2`@`%`                                 
TRIGGER `tbm_county_RBD`                                 
AFTER DELETE ON `tbm_county`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Update' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_county_history ( history_id,                                                       
		operation,                                                       
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		OLD.fips_code,
		OLD.state_code,
		OLD.county_code,
		OLD.county_name,
		OLD.remi_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
