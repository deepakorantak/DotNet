DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_apn_format_RAI` $$                               
CREATE                               
TRIGGER `tbm_apn_format_RAI`                               
AFTER INSERT ON `tbm_apn_format`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_apn_format_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		apn_id,
		fips_code,
		input_format,
		special_char_input_format,
		apn_research_county_flag,
		special_char_input_flag,
		keywords_input_flag,
		default_output_format1,
		default_output_format2,
		default_output_format3,
		default_output_format4,
		default_output_format5,
		default_output_format6,
		default_output_format7,
		default_output_format8,
		default_output_format9,
		default_output_format10,
		output_format1,
		output_format2,
		output_format3,
		output_format4,
		output_format5,
		output_format6,
		output_format7,
		output_format8,
		output_format9,
		output_format10,
		output_format1_alignment,
		output_format2_alignment,
		output_format3_alignment,
		output_format4_alignment,
		output_format5_alignment,
		output_format6_alignment,
		output_format7_alignment,
		output_format8_alignment,
		output_format9_alignment,
		output_format10_alignment,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.apn_id,
		NEW.fips_code,
		NEW.input_format,
		NEW.special_char_input_format,
		NEW.apn_research_county_flag,
		NEW.special_char_input_flag,
		NEW.keywords_input_flag,
		NEW.default_output_format1,
		NEW.default_output_format2,
		NEW.default_output_format3,
		NEW.default_output_format4,
		NEW.default_output_format5,
		NEW.default_output_format6,
		NEW.default_output_format7,
		NEW.default_output_format8,
		NEW.default_output_format9,
		NEW.default_output_format10,
		NEW.output_format1,
		NEW.output_format2,
		NEW.output_format3,
		NEW.output_format4,
		NEW.output_format5,
		NEW.output_format6,
		NEW.output_format7,
		NEW.output_format8,
		NEW.output_format9,
		NEW.output_format10,
		NEW.output_format1_alignment,
		NEW.output_format2_alignment,
		NEW.output_format3_alignment,
		NEW.output_format4_alignment,
		NEW.output_format5_alignment,
		NEW.output_format6_alignment,
		NEW.output_format7_alignment,
		NEW.output_format8_alignment,
		NEW.output_format9_alignment,
		NEW.output_format10_alignment,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_apn_format_RAU` $$                               
CREATE                               
TRIGGER `tbm_apn_format_RAU`                               
AFTER UPDATE ON `tbm_apn_format`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_apn_format_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		apn_id,
		fips_code,
		input_format,
		special_char_input_format,
		apn_research_county_flag,
		special_char_input_flag,
		keywords_input_flag,
		default_output_format1,
		default_output_format2,
		default_output_format3,
		default_output_format4,
		default_output_format5,
		default_output_format6,
		default_output_format7,
		default_output_format8,
		default_output_format9,
		default_output_format10,
		output_format1,
		output_format2,
		output_format3,
		output_format4,
		output_format5,
		output_format6,
		output_format7,
		output_format8,
		output_format9,
		output_format10,
		output_format1_alignment,
		output_format2_alignment,
		output_format3_alignment,
		output_format4_alignment,
		output_format5_alignment,
		output_format6_alignment,
		output_format7_alignment,
		output_format8_alignment,
		output_format9_alignment,
		output_format10_alignment,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.apn_id,
		NEW.fips_code,
		NEW.input_format,
		NEW.special_char_input_format,
		NEW.apn_research_county_flag,
		NEW.special_char_input_flag,
		NEW.keywords_input_flag,
		NEW.default_output_format1,
		NEW.default_output_format2,
		NEW.default_output_format3,
		NEW.default_output_format4,
		NEW.default_output_format5,
		NEW.default_output_format6,
		NEW.default_output_format7,
		NEW.default_output_format8,
		NEW.default_output_format9,
		NEW.default_output_format10,
		NEW.output_format1,
		NEW.output_format2,
		NEW.output_format3,
		NEW.output_format4,
		NEW.output_format5,
		NEW.output_format6,
		NEW.output_format7,
		NEW.output_format8,
		NEW.output_format9,
		NEW.output_format10,
		NEW.output_format1_alignment,
		NEW.output_format2_alignment,
		NEW.output_format3_alignment,
		NEW.output_format4_alignment,
		NEW.output_format5_alignment,
		NEW.output_format6_alignment,
		NEW.output_format7_alignment,
		NEW.output_format8_alignment,
		NEW.output_format9_alignment,
		NEW.output_format10_alignment,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_apn_format_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_apn_format_RBD`                                 
BEFORE DELETE ON `tbm_apn_format`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_apn_format_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		apn_id,
		fips_code,
		input_format,
		special_char_input_format,
		apn_research_county_flag,
		special_char_input_flag,
		keywords_input_flag,
		default_output_format1,
		default_output_format2,
		default_output_format3,
		default_output_format4,
		default_output_format5,
		default_output_format6,
		default_output_format7,
		default_output_format8,
		default_output_format9,
		default_output_format10,
		output_format1,
		output_format2,
		output_format3,
		output_format4,
		output_format5,
		output_format6,
		output_format7,
		output_format8,
		output_format9,
		output_format10,
		output_format1_alignment,
		output_format2_alignment,
		output_format3_alignment,
		output_format4_alignment,
		output_format5_alignment,
		output_format6_alignment,
		output_format7_alignment,
		output_format8_alignment,
		output_format9_alignment,
		output_format10_alignment,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.apn_id,
		OLD.fips_code,
		OLD.input_format,
		OLD.special_char_input_format,
		OLD.apn_research_county_flag,
		OLD.special_char_input_flag,
		OLD.keywords_input_flag,
		OLD.default_output_format1,
		OLD.default_output_format2,
		OLD.default_output_format3,
		OLD.default_output_format4,
		OLD.default_output_format5,
		OLD.default_output_format6,
		OLD.default_output_format7,
		OLD.default_output_format8,
		OLD.default_output_format9,
		OLD.default_output_format10,
		OLD.output_format1,
		OLD.output_format2,
		OLD.output_format3,
		OLD.output_format4,
		OLD.output_format5,
		OLD.output_format6,
		OLD.output_format7,
		OLD.output_format8,
		OLD.output_format9,
		OLD.output_format10,
		OLD.output_format1_alignment,
		OLD.output_format2_alignment,
		OLD.output_format3_alignment,
		OLD.output_format4_alignment,
		OLD.output_format5_alignment,
		OLD.output_format6_alignment,
		OLD.output_format7_alignment,
		OLD.output_format8_alignment,
		OLD.output_format9_alignment,
		OLD.output_format10_alignment,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
