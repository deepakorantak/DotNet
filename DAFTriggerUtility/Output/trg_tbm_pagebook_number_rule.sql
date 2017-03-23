DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_pagebook_number_rule_RAI` $$                               
CREATE                               
TRIGGER `tbm_pagebook_number_rule_RAI`                               
AFTER INSERT ON `tbm_pagebook_number_rule`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                    
	SELECT 'Insert' INTO operation_value;                                     
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_pagebook_no_rule_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		pagebook_number_rule_id,
		fips_code,
		book_supress_leading_zero,
		book_can_have_special,
		book_can_have_alpha,
		page_supress_leading_zero,
		page_supress_end_page,
		page_can_have_special,
		page_can_have_alpha,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.pagebook_number_rule_id,
		NEW.fips_code,
		NEW.book_supress_leading_zero,
		NEW.book_can_have_special,
		NEW.book_can_have_alpha,
		NEW.page_supress_leading_zero,
		NEW.page_supress_end_page,
		NEW.page_can_have_special,
		NEW.page_can_have_alpha,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_pagebook_number_rule_RAU` $$                               
CREATE                               
TRIGGER `tbm_pagebook_number_rule_RAU`                               
AFTER UPDATE ON `tbm_pagebook_number_rule`                               
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                      
	SELECT 'Update' INTO operation_value;                                                                                                            
	
	IF NEW.active_flag = 'D' THEN                                    
		SELECT 'SoftDelete' INTO operation_value;                                    
	END IF;

	INSERT INTO tbm_pagebook_no_rule_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		pagebook_number_rule_id,
		fips_code,
		book_supress_leading_zero,
		book_can_have_special,
		book_can_have_alpha,
		page_supress_leading_zero,
		page_supress_end_page,
		page_can_have_special,
		page_can_have_alpha,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		NEW.pagebook_number_rule_id,
		NEW.fips_code,
		NEW.book_supress_leading_zero,
		NEW.book_can_have_special,
		NEW.book_can_have_alpha,
		NEW.page_supress_leading_zero,
		NEW.page_supress_end_page,
		NEW.page_can_have_special,
		NEW.page_can_have_alpha,
		NEW.active_flag,
		NEW.modified_by,
		NEW.modified_dttm,
		NEW.version_no );
 
END$$ 
DELIMITER $$

 Use `daf2` $$

DROP TRIGGER IF EXISTS `tbm_pagebook_number_rule_RBD` $$                                 
CREATE                                 
TRIGGER `tbm_pagebook_number_rule_RBD`                                 
BEFORE DELETE ON `tbm_pagebook_number_rule`                                 
FOR EACH ROW
BEGIN 
	DECLARE operation_value VARCHAR(20);                                        
	SELECT 'Delete' INTO operation_value;                                       
	 
	/*No trigger condition*/ 

	INSERT INTO tbm_pagebook_no_rule_history ( history_id,                                                       
		operation,                                                       
		system_dttm,                                                       
		pagebook_number_rule_id,
		fips_code,
		book_supress_leading_zero,
		book_can_have_special,
		book_can_have_alpha,
		page_supress_leading_zero,
		page_supress_end_page,
		page_can_have_special,
		page_can_have_alpha,
		active_flag,
		modified_by,
		modified_dttm,
		version_no ) VALUES (  NULL,                                                       
		operation_value,                                                       
		NOW(),                                                       
		OLD.pagebook_number_rule_id,
		OLD.fips_code,
		OLD.book_supress_leading_zero,
		OLD.book_can_have_special,
		OLD.book_can_have_alpha,
		OLD.page_supress_leading_zero,
		OLD.page_supress_end_page,
		OLD.page_can_have_special,
		OLD.page_can_have_alpha,
		OLD.active_flag,
		OLD.modified_by,
		OLD.modified_dttm,
		OLD.version_no );
 
END$$ 
