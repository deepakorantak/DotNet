DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_mst_RAI` $$                               
CREATE                               
TRIGGER `tbc_user_mst_RAI`                               
AFTER INSERT ON `tbc_user_mst`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_user_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_cd,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		address_txt,
		custom_txt_1,
		custom_txt_2,
		custom_txt_3,
		custom_txt_4,
		custom_txt_5,
		auth_type,
		email_addr_txt,
		first_name_txt,
		last_name_txt,
		logon_cd,
		middle_name_txt,
		mobile_no_txt,
		profile_image,
		supervisor_cd,
		max_sessions ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.user_cd,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.address_txt,
		NEW.custom_txt_1,
		NEW.custom_txt_2,
		NEW.custom_txt_3,
		NEW.custom_txt_4,
		NEW.custom_txt_5,
		NEW.auth_type,
		NEW.email_addr_txt,
		NEW.first_name_txt,
		NEW.last_name_txt,
		NEW.logon_cd,
		NEW.middle_name_txt,
		NEW.mobile_no_txt,
		NEW.profile_image,
		NEW.supervisor_cd,
		NEW.max_sessions );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_mst_RAU` $$                               
CREATE                               
TRIGGER `tbc_user_mst_RAU`                               
AFTER UPDATE ON `tbc_user_mst`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_user_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_cd,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		address_txt,
		custom_txt_1,
		custom_txt_2,
		custom_txt_3,
		custom_txt_4,
		custom_txt_5,
		auth_type,
		email_addr_txt,
		first_name_txt,
		last_name_txt,
		logon_cd,
		middle_name_txt,
		mobile_no_txt,
		profile_image,
		supervisor_cd,
		max_sessions ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.user_cd,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.address_txt,
		NEW.custom_txt_1,
		NEW.custom_txt_2,
		NEW.custom_txt_3,
		NEW.custom_txt_4,
		NEW.custom_txt_5,
		NEW.auth_type,
		NEW.email_addr_txt,
		NEW.first_name_txt,
		NEW.last_name_txt,
		NEW.logon_cd,
		NEW.middle_name_txt,
		NEW.mobile_no_txt,
		NEW.profile_image,
		NEW.supervisor_cd,
		NEW.max_sessions );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_user_mst_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_user_mst_RBD`                                 
BEFORE DELETE ON `tbc_user_mst`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_user_mst_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		user_cd,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		address_txt,
		custom_txt_1,
		custom_txt_2,
		custom_txt_3,
		custom_txt_4,
		custom_txt_5,
		auth_type,
		email_addr_txt,
		first_name_txt,
		last_name_txt,
		logon_cd,
		middle_name_txt,
		mobile_no_txt,
		profile_image,
		supervisor_cd,
		max_sessions ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.user_cd,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.address_txt,
		OLD.custom_txt_1,
		OLD.custom_txt_2,
		OLD.custom_txt_3,
		OLD.custom_txt_4,
		OLD.custom_txt_5,
		OLD.auth_type,
		OLD.email_addr_txt,
		OLD.first_name_txt,
		OLD.last_name_txt,
		OLD.logon_cd,
		OLD.middle_name_txt,
		OLD.mobile_no_txt,
		OLD.profile_image,
		OLD.supervisor_cd,
		OLD.max_sessions );
 
END$$ 
