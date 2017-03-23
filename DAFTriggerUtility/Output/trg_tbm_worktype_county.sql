DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_worktype_county_RAI` $$                               
CREATE                               
TRIGGER `tbm_worktype_county_RAI`                               
AFTER INSERT ON `tbm_worktype_county`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_worktype_county_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		worktype_county_pk_id,
		work_type_cd,
		fips_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.worktype_county_pk_id,
		NEW.work_type_cd,
		NEW.fips_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_worktype_county_RAU` $$                               
CREATE                               
TRIGGER `tbm_worktype_county_RAU`                               
AFTER UPDATE ON `tbm_worktype_county`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_worktype_county_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		worktype_county_pk_id,
		work_type_cd,
		fips_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.worktype_county_pk_id,
		NEW.work_type_cd,
		NEW.fips_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_worktype_county_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_worktype_county_RBD`                                 
BEFORE DELETE ON `tbm_worktype_county`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_worktype_county_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		worktype_county_pk_id,
		work_type_cd,
		fips_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.worktype_county_pk_id,
		OLD.work_type_cd,
		OLD.fips_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
