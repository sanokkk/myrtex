DELETE FROM employees  
WHERE DATEADD(yy, 70, birthday) <= GETDATE();