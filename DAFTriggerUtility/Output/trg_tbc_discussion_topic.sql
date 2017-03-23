DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_discussion_topic_RAI` $$                               
CREATE                               
TRIGGER `tbc_discussion_topic_RAI`                               
AFTER INSERT ON `tbc_discussion_topic`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_discussion_topic_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		topic_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		author_txt,
		created_dttm,
		topic_category,
		topic_description_txt,
		topic_title_txt,
		viewed ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.topic_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.author_txt,
		NEW.created_dttm,
		NEW.topic_category,
		NEW.topic_description_txt,
		NEW.topic_title_txt,
		NEW.viewed );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_discussion_topic_RAU` $$                               
CREATE                               
TRIGGER `tbc_discussion_topic_RAU`                               
AFTER UPDATE ON `tbc_discussion_topic`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_discussion_topic_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		topic_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		author_txt,
		created_dttm,
		topic_category,
		topic_description_txt,
		topic_title_txt,
		viewed ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.topic_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.author_txt,
		NEW.created_dttm,
		NEW.topic_category,
		NEW.topic_description_txt,
		NEW.topic_title_txt,
		NEW.viewed );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_discussion_topic_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_discussion_topic_RBD`                                 
BEFORE DELETE ON `tbc_discussion_topic`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_discussion_topic_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		topic_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		author_txt,
		created_dttm,
		topic_category,
		topic_description_txt,
		topic_title_txt,
		viewed ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.topic_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.author_txt,
		OLD.created_dttm,
		OLD.topic_category,
		OLD.topic_description_txt,
		OLD.topic_title_txt,
		OLD.viewed );
 
END$$ 
