﻿DROP TABLE IF EXISTS SAMPLETABLE;	

CREATE TABLE SAMPLETABLE (
    ID INT IDENTITY NOT NULL PRIMARY KEY,   
	NAME nvarchar(200),
);

insert into SAMPLETABLE values ( 'Temp Name');
insert into SAMPLETABLE values ( 'Temp 2');