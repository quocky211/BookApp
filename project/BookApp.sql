CREATE TABLE TYPEBOOK(
	MALOAI CHAR(8) PRIMARY KEY,
	TENLOAI NVARCHAR(250) NOT NULL,
	HINH NVARCHAR(250) NOT NULL,
)

CREATE TABLE BOOK(
	MASACH CHAR(8) PRIMARY KEY,
	TENSACH NVARCHAR(250) NOT NULL,
	HINH NVARCHAR(250) NOT NULL,
	TACGIA NVARCHAR(250) NOT NULL,
	TOMTAT NVARCHAR(250) NOT NULL,
	NOIDUNG NVARCHAR(250) NOT NULL,
	MALOAI CHAR(8) NOT NULL,
)

---KHOA NGOAI-----
ALTER TABLE BOOK ADD CONSTRAINT FK01_BOOK FOREIGN KEY(MALOAI) REFERENCES TYPEBOOK(MALOAI)
---INSERT---
---TYPEBOOK---
INSERT INTO TYPEBOOK VALUES('LS01',N'Truyện, tiểu thuyết','truyen.jpg')
INSERT INTO TYPEBOOK VALUES('LS02',N'Đời sống - Tâm lý','doisong.jpg')
INSERT INTO TYPEBOOK VALUES('LS03',N'Thiếu nhi','thieunhi.jpg')
INSERT INTO TYPEBOOK VALUES('LS04',N'Chính trị - Pháp luật','chinhtri.jpg')
INSERT INTO TYPEBOOK VALUES('LS05',N'Kinh tế','kinhte.jpg')
INSERT INTO TYPEBOOK VALUES('LS06',N'Giáo khoa','giaokhoa.jpg')
---BOOK---
INSERT INTO BOOK VALUES('GK01',N'Tiếng anh','giaokhoa_1.jpg',N'Nhiều tác giả','nn','nn','LS06')
INSERT INTO BOOK VALUES('GK02',N'Vật lí','giaokhoa_2.jpg',N'Nhiều tác giả','nn','nn','LS06')
INSERT INTO BOOK VALUES('GK03',N'Hóa học','giaokhoa_3.jpg',N'Nhiều tác giả','nn','nn','LS06')
INSERT INTO BOOK VALUES('GK04',N'Giáo dục công dân','giaokhoa_4.jpg',N'Nhiều tác giả','nn','nn','LS06')
INSERT INTO BOOK VALUES('GK05',N'Địa lí','giaokhoa_5.jpg',N'Nhiều tác giả','nn','nn','LS06')
INSERT INTO BOOK VALUES('GK06',N'Ngữ văn','giaokhoa_6.jpg',N'Nhiều tác giả','nn','nn','LS06')
---pro---

----Laydsbook-----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LayDsBook]
as
select TENSACH,'http://192.168.1.26/BookAPI/images/'+HINH as HINH,TACGIA
from BOOK
GO

