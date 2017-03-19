CREATE TRIGGER tbm_state_RAI AFTER INSERT ON tbm_state FOR EACH ROW 
BEGIN 
	 @operation = 'insert'; 
	 
	\\No trigger condition 

	INSERT INTO tbm_state_history ( history_id,
		@operation,
		state_code,
		state_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,
		@operation,
		NEW.state_code,
		NEW.state_name,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END; 
CREATE TRIGGER tbm_state_RAU AFTER UPDATE ON tbm_state FOR EACH ROW 
BEGIN 
	 @operation = 'update'; 
	 
	IF NEW.active_flag = 'D' THEN 
		 @operation = 'softdelete' 
	END IF;

	INSERT INTO tbm_state_history ( history_id,
		@operation,
		state_code,
		state_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,
		@operation,
		OLD.state_code,
		OLD.state_name,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END; 
CREATE TRIGGER tbm_state_RAD AFTER DELETE ON tbm_state FOR EACH ROW 
BEGIN 
	 @operation = 'delete'; 
	 
	\\No trigger condition 

	INSERT INTO tbm_state_history ( history_id,
		@operation,
		state_code,
		state_name,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,
		@operation,
		OLD.state_code,
		OLD.state_name,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END; 
