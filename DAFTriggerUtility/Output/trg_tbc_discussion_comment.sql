DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_discussion_comment_RAI` $$                               
CREATE                               
TRIGGER `tbc_discussion_comment_RAI`                               
AFTER INSERT ON `tbc_discussion_comment`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_discussion_comment_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		comment_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		author_txt,
		comment_desc_txt,
		created_dttm,
		parent_comment_id,
		reply_to,
		topic_id,
		vote ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.comment_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.author_txt,
		NEW.comment_desc_txt,
		NEW.created_dttm,
		NEW.parent_comment_id,
		NEW.reply_to,
		NEW.topic_id,
		NEW.vote );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_discussion_comment_RAU` $$                               
CREATE                               
TRIGGER `tbc_discussion_comment_RAU`                               
AFTER UPDATE ON `tbc_discussion_comment`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbc_discussion_comment_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		comment_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		author_txt,
		comment_desc_txt,
		created_dttm,
		parent_comment_id,
		reply_to,
		topic_id,
		vote ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.comment_id,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no,
		NEW.author_txt,
		NEW.comment_desc_txt,
		NEW.created_dttm,
		NEW.parent_comment_id,
		NEW.reply_to,
		NEW.topic_id,
		NEW.vote );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbc_discussion_comment_RBD` $$                                 
CREATE                                 
TRIGGER `tbc_discussion_comment_RBD`                                 
BEFORE DELETE ON `tbc_discussion_comment`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbc_discussion_comment_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		comment_id,
		active_flag,
		modified_by,
		modified_dttm,
		version_no,
		author_txt,
		comment_desc_txt,
		created_dttm,
		parent_comment_id,
		reply_to,
		topic_id,
		vote ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.comment_id,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no,
		OLD.author_txt,
		OLD.comment_desc_txt,
		OLD.created_dttm,
		OLD.parent_comment_id,
		OLD.reply_to,
		OLD.topic_id,
		OLD.vote );
 
END$$ 
