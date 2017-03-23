DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_sampling_strategy_RAI` $$                               
CREATE                               
TRIGGER `tbc_sampling_strategy_RAI`                               
AFTER INSERT ON `tbc_sampling_strategy`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_sampling_strategy_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		strategy_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		close_to_pct,
		confidence_level,
		fields,
		interval_size,
		sample_size_pct,
		strategy_name,
		strategy_type,
		variance_degree,
		work_type_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.strategy_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.close_to_pct,
		NEW.confidence_level,
		NEW.fields,
		NEW.interval_size,
		NEW.sample_size_pct,
		NEW.strategy_name,
		NEW.strategy_type,
		NEW.variance_degree,
		NEW.work_type_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_sampling_strategy_RAU` $$                               
CREATE                               
TRIGGER `tbc_sampling_strategy_RAU`                               
AFTER UPDATE ON `tbc_sampling_strategy`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_sampling_strategy_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		strategy_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		close_to_pct,
		confidence_level,
		fields,
		interval_size,
		sample_size_pct,
		strategy_name,
		strategy_type,
		variance_degree,
		work_type_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.strategy_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.close_to_pct,
		NEW.confidence_level,
		NEW.fields,
		NEW.interval_size,
		NEW.sample_size_pct,
		NEW.strategy_name,
		NEW.strategy_type,
		NEW.variance_degree,
		NEW.work_type_cd );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_sampling_strategy_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_sampling_strategy_RBD`                                 
BEFORE DELETE ON `tbc_sampling_strategy`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_sampling_strategy_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		strategy_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		close_to_pct,
		confidence_level,
		fields,
		interval_size,
		sample_size_pct,
		strategy_name,
		strategy_type,
		variance_degree,
		work_type_cd ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.strategy_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.close_to_pct,
		OLD.confidence_level,
		OLD.fields,
		OLD.interval_size,
		OLD.sample_size_pct,
		OLD.strategy_name,
		OLD.strategy_type,
		OLD.variance_degree,
		OLD.work_type_cd );
 
END$$ 
