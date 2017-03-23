DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_worktype_subdoctype_RAI` $$                               
CREATE                               
TRIGGER `tbm_worktype_subdoctype_RAI`                               
AFTER INSERT ON `tbm_worktype_subdoctype`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_worktype_subdoctyp_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		worktype_subdoc_id,
		work_type_cd,
		bid,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.worktype_subdoc_id,
		NEW.work_type_cd,
		NEW.bid,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_worktype_subdoctype_RAU` $$                               
CREATE                               
TRIGGER `tbm_worktype_subdoctype_RAU`                               
AFTER UPDATE ON `tbm_worktype_subdoctype`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_worktype_subdoctyp_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		worktype_subdoc_id,
		work_type_cd,
		bid,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.worktype_subdoc_id,
		NEW.work_type_cd,
		NEW.bid,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_worktype_subdoctype_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_worktype_subdoctype_RBD`                                 
BEFORE DELETE ON `tbm_worktype_subdoctype`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_worktype_subdoctyp_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		worktype_subdoc_id,
		work_type_cd,
		bid,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.worktype_subdoc_id,
		OLD.work_type_cd,
		OLD.bid,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
