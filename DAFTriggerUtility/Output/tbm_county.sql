CREATE TRIGGER tbm_county_RAI AFTER INSERT ON tbm_county FOR EACH ROW 
BEGIN 
	 @operation = 'insert'; 
	 
	\\No trigger condition 

	INSERT INTO tbm_county_history ( history_id,
		@operation,
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,
		@operation,
		NEW.fips_code,
		NEW.state_code,
		NEW.county_code,
		NEW.county_name,
		NEW.remi_code,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END; 
CREATE TRIGGER tbm_county_RAU AFTER UPDATE ON tbm_county FOR EACH ROW 
BEGIN 
	 @operation = 'update'; 
	 
	IF NEW.active_flag = 'D' THEN 
		 @operation = 'softdelete' 
	END IF;

	INSERT INTO tbm_county_history ( history_id,
		@operation,
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,
		@operation,
		OLD.fips_code,
		OLD.state_code,
		OLD.county_code,
		OLD.county_name,
		OLD.remi_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END; 
CREATE TRIGGER tbm_county_RAD AFTER DELETE ON tbm_county FOR EACH ROW 
BEGIN 
	 @operation = 'delete'; 
	 
	\\No trigger condition 

	INSERT INTO tbm_county_history ( history_id,
		@operation,
		fips_code,
		state_code,
		county_code,
		county_name,
		remi_code,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,
		@operation,
		OLD.fips_code,
		OLD.state_code,
		OLD.county_code,
		OLD.county_name,
		OLD.remi_code,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END; 
