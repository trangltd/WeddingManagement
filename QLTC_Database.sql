----------CREATE DATABASE
CREATE DATABASE WEDDING_MANAGEMENT
GO

USE WEDDING_MANAGEMENT
GO

create table ACCOUNT(
	AccountNo bigint primary key,
	Username varchar(64),
	Password varchar(1000),
	Priority smallint,
	Name nvarchar(100),
	Identification varchar(20),
) 
GO 

create table LOBBY_TYPE
(
	LobbyTypeNo varchar(21) primary key,
	LobbyTypeName nvarchar(100) not null,
	MinTablePrice bigint,
	Available int,
) 
GO 

create table LOBBY
(
	LobbyNo varchar(21) primary key,
	LobbyTypeNo varchar(21) not null,
	LobbyName nvarchar(40) not null,
	MaxTable int,
	Available int,
	Note nvarchar(1000),
	constraint FK_LOBBY foreign key (LobbyTypeNo) references LOBBY_TYPE (LobbyTypeNo),
) 
GO 

create table SHIFT
(
	ShiftNo varchar(21) primary key,
	Available int,
	ShiftName nvarchar(20),
	Starting time,
	Ending time,
) 
GO 

create table WEDDING
(
	WeddingNo varchar(21) primary key,
	LobbyNo varchar(21) not null,
	ShiftNo varchar(21),
	BookingDate datetime,
	WeddingDate datetime,
	PhoneNumber varchar(10),
	BroomName nvarchar(100),
	BrideName nvarchar(100),
	AmountOfTable int,
	AmountOfContingencyTable int,
	TablePrice bigint,
	Deposit bigint,
	Available int,
	Representative nvarchar(100) not null,
	constraint FK_WEDDING_01 foreign key (LobbyNo) references LOBBY (LobbyNo),
	constraint FK_WEDDING_02 foreign key (ShiftNo) references SHIFT (ShiftNo),
) 
GO 

create table MENU
(
	ItemNo varchar(21) primary key,
	ItemName nvarchar(100),
	ItemPrice bigint,
	Note nvarchar(100),
	Available int,
) 
GO 

create table SERVICE
(
	ServiceNo varchar(21) primary key,
	ServiceName nvarchar(100),
	ServicePrice bigint,
	Note nvarchar(100),
	Available int,
) 
GO 

create table TABLE_DETAIL
(
	WeddingNo varchar(21) not null,
	ItemNo varchar(21) not null,
	AmountOfItems int,
	TotalItemsPrice bigint,
	Note nvarchar(100),
	constraint PK_TABLE_DETAIL primary key (WeddingNo, ItemNo),
	constraint FK_TABLE_DETAIL_01 foreign key (WeddingNo) references WEDDING (WeddingNo),
	constraint FK_TABLE_DETAIL_02 foreign key (ItemNo) references MENU (ItemNo)
) 
GO 

create table SERVICE_DETAIL
(
	WeddingNo varchar(21) not null,
	ServiceNo varchar(21) not null,
	AmountOfServices int,
	TotalServicesPrice bigint,
	Note nvarchar(50),
	constraint PK_SERVICE_DETAIL primary key (WeddingNo, ServiceNo),
	constraint FK_SERVICE_DETAIL_01 foreign key (WeddingNo) references WEDDING (WeddingNo),
	constraint FK_SERVICE_DETAIL_02 foreign key (ServiceNo) references [SERVICE] (ServiceNo),
) 
GO 

create table BILL
(
	BillNo varchar(21) primary key,
	WeddingNo varchar(21),
	InvoiceDate datetime,
	TablePriceTotal bigint,
	ServicePriceTotal bigint,
	Total bigint,
	PaymentDate datetime,
	MoneyLeft bigint,
	constraint FK_BILL foreign key (WeddingNo) references WEDDING(WeddingNo)
) 
GO 

create table REVENUE_REPORT
(
	ReportNo varchar(21) primary key,
	Month tinyint,
	Year int,
	RevenueTotal bigint,
) 
GO 

create table REVENUE_REPORT_DETAIL
(
	ReportNo varchar(21) not null,  
	Day tinyint not null,
	DayRevenue bigint,
	Ratio float,
	AmountOfWedding int,
	constraint PK_REVENUE_REPORT_DETAIL primary key (ReportNo, Day),
	constraint FK_REVENUE_REPORT_DETAIL foreign key (ReportNo) references REVENUE_REPORT(ReportNo),
) 
GO 

create table PARAMETER
(
	ParamaterNo varchar(20) primary key,
	Value int ,
) 
GO 


-----------INSERT DATA
--ACCOUNT
insert into ACCOUNT values (0, N'admin', N'123', 0, N'Nhom8', N'079202006893') 
insert into ACCOUNT values (1, N'linhnguyen', N'linh123', 2, N'Nguyễn Hoài Linh', N'079202009175') 
insert into ACCOUNT values (2, N'kietnguyen', N'kiet123', 2, N'Nguyễn Anh Kiệt', N'079202009567') 
insert into ACCOUNT values (3, N'phatnguyen', N'phat123', 2, N'Nguyễn Thành Phát', N'079202006852') 
insert into ACCOUNT values (4, N'trangvo', N'trang123', 2, N'Võ Thị Hà Trang', N'079202007893') 
insert into ACCOUNT values (5, N'nhamtran', N'nham1256', 1, N'Trần Thành Nhâm', N'079202009678') 
insert into ACCOUNT values (6, N'minhle', N'minhminh123', 3, N'Lê Thanh Minh', N'079202006794') 
insert into ACCOUNT values (7, N'nhungcao', N'caothinhung123', 3, N'Cao Thị Thanh Nhung', N'079202008910') 
insert into ACCOUNT values (8, N'thaole', N'thaothaole245', 3, N'Lê Trần Thanh Thảo', N'079202003590') 
GO 

set dateformat dmy
GO 

--LOBBY TYPE
insert into LOBBY_TYPE values('LT0000000000000000001', N'A', 1000000, 1) 
insert into LOBBY_TYPE values('LT0000000000000000002', N'B', 1100000, 1) 
insert into LOBBY_TYPE values('LT0000000000000000003', N'C', 1200000, 1) 
insert into LOBBY_TYPE values('LT0000000000000000004', N'D', 1400000, 1) 
insert into LOBBY_TYPE values('LT0000000000000000005', N'E', 1600000, 1) 
GO 

--LOBBY
insert into LOBBY values('LB0000000000000000001', 'LT0000000000000000001', N'Sảnh A1', 20, 1, N'') 
insert into LOBBY values('LB0000000000000000002', 'LT0000000000000000002', N'Sảnh B1', 25, 1, N'') 
insert into LOBBY values('LB0000000000000000003', 'LT0000000000000000003', N'Sảnh C1', 30, 1, N'') 
insert into LOBBY values('LB0000000000000000004', 'LT0000000000000000004', N'Sảnh D1', 40, 1, N'') 
insert into LOBBY values('LB0000000000000000005', 'LT0000000000000000005', N'Sảnh E1', 50, 1, N'') 
insert into LOBBY values('LB0000000000000000006', 'LT0000000000000000005', N'Sảnh E2', 45, 1, N'') 
insert into LOBBY values('LB0000000000000000007', 'LT0000000000000000004', N'Sảnh D2', 35, 1, N'') 
insert into LOBBY values('LB0000000000000000008', 'LT0000000000000000003', N'Sảnh C2', 30, 1, N'') 
insert into LOBBY values('LB0000000000000000009', 'LT0000000000000000002', N'Sảnh B2', 25, 1, N'') 
insert into LOBBY values('LB0000000000000000010', 'LT0000000000000000001', N'Sảnh A2', 20, 1, N'') 
insert into LOBBY values('LB0000000000000000011', 'LT0000000000000000001', N'Sảnh A3', 40, 1, N'') 
insert into LOBBY values('LB0000000000000000012', 'LT0000000000000000001', N'Sảnh A4', 45, 1, N'') 
insert into LOBBY values('LB0000000000000000013', 'LT0000000000000000002', N'Sảnh B3', 35, 1, N'') 
insert into LOBBY values('LB0000000000000000014', 'LT0000000000000000002', N'Sảnh B4', 50, 1, N'') 
insert into LOBBY values('LB0000000000000000015', 'LT0000000000000000003', N'Sảnh C3', 60, 1, N'') 
insert into LOBBY values('LB0000000000000000016', 'LT0000000000000000003', N'Sảnh C4', 55, 1, N'') 
insert into LOBBY values('LB0000000000000000017', 'LT0000000000000000004', N'Sảnh D3', 45, 1, N'') 
insert into LOBBY values('LB0000000000000000018', 'LT0000000000000000004', N'Sảnh D4', 50, 1, N'') 
insert into LOBBY values('LB0000000000000000019', 'LT0000000000000000005', N'Sảnh E3', 30, 1, N'') 
insert into LOBBY values('LB0000000000000000020', 'LT0000000000000000005', N'Sảnh E4', 60, 1, N'') 
GO 

--SHIFT
insert into SHIFT values('SH0000000000000000001', 1, N'Trưa', '12:00', '16:00') 
insert into SHIFT values('SH0000000000000000002', 1, N'Tối', '17:00', '22:00') 
GO 

--MENU
insert into MENU values('MN0000000000000000001', N'Đà điểu lúc lắc', 450000, N'', 1) 
insert into MENU values('MN0000000000000000002', N'Cánh gà chiên nước mắm', 180000, N'', 1) 
insert into MENU values('MN0000000000000000003', N'Thịt gà đông tảo', 290000, N'', 1) 
insert into MENU values('MN0000000000000000004', N'Gà hấp Tứ Xuyên', 250000, N'', 1) 
insert into MENU values('MN0000000000000000005', N'Gà hấp lá chanh', 230000, N'', 1) 
insert into MENU values('MN0000000000000000006', N'Gà ta bóp rau răm', 230000, N'', 1) 
insert into MENU values('MN0000000000000000007', N'Gỏi gà măng cụt', 550000, N'', 1) 
insert into MENU values('MN0000000000000000008', N'Tôm chiên hoàng bào', 250000, N'', 1) 
insert into MENU values('MN0000000000000000009', N'Chim cút chiên bơ', 190000, N'', 1) 
insert into MENU values('MN0000000000000000010', N'Cơm gà sối mỡ', 70000, N'', 1) 
insert into MENU values('MN0000000000000000011', N'Khoai tây chiên', 30000, N'', 1) 
insert into MENU values('MN0000000000000000012', N'Cơm chiên dương châu', 50000, N'', 1) 
insert into MENU values('MN0000000000000000013', N'Trà sữa trân châu hoàng kim', 50000, N'', 1) 
insert into MENU values('MN0000000000000000014', N'Trà đào cam xả', 50000, N'', 1) 
insert into MENU values('MN0000000000000000015', N'Nước chanh', 20000, N'', 1) 
insert into MENU values('MN0000000000000000016', N'Nước cam ép', 30000, N'', 1) 
insert into MENU values('MN0000000000000000017', N'Nước ngọt các loại', 30000, N'', 1) 
insert into MENU values('MN0000000000000000018', N'Nước lọc', 10000, N'', 1) 
insert into MENU values('MN0000000000000000019', N'Bánh gạo Hàn Quốc', 80000, N'', 1) 
insert into MENU values('MN0000000000000000020', N'Bánh snack Oishi Cay', 20000, N'', 1) 
insert into MENU values('MN0000000000000000021', N'Lẩu riêu cua', 300000, N'', 1) 
insert into MENU values('MN0000000000000000022', N'Lẩu bắp bò', 500000, N'', 1) 
insert into MENU values('MN0000000000000000023', N'Bánh phồng tôm', 20000, N'', 1) 
insert into MENU values('MN0000000000000000024', N'Xôi ngũ sắc', 40000, N'', 1) 
insert into MENU values('MN0000000000000000025', N'Xôi nếp cẩm', 35000, N'', 1) 
insert into MENU values('MN0000000000000000026', N'Chuối Đà Lạt', 25000, N'', 1) 
insert into MENU values('MN0000000000000000027', N'Phile cá lóc chiên giòn', 2000000, N'', 1) 
insert into MENU values('MN0000000000000000028', N'Gà đông tảo hầm sâm', 650000, N'', 1) 
insert into MENU values('MN0000000000000000029', N'Tôm hùm nướng bơ', 600000, N'', 1) 
insert into MENU values('MN0000000000000000030', N'Cua hoàng đế hấp', 750000, N'', 1) 
insert into MENU values('MN0000000000000000031', N'Cháo tổ yến',375000, N'', 1) 
insert into MENU values('MN0000000000000000032', N'Nước yến', 500000, N'', 1) 
insert into MENU values('MN0000000000000000033', N'Sườn cừu nấu rượu vang', 1000000, N'', 1) 
insert into MENU values('MN0000000000000000034', N'Bò hầm đậu hà lan', 350000, N'', 1) 
insert into MENU values('MN0000000000000000035', N'Đậu phộng rang muối', 35000, N'', 1) 
insert into MENU values('MN0000000000000000036', N'Mì vịt tiềm', 400000, N'', 1) 
insert into MENU values('MN0000000000000000037', N'Mì gói', 5000, N'', 1) 
insert into MENU values('MN0000000000000000038', N'Mì xào hải sản', 150000, N'', 1) 
insert into MENU values('MN0000000000000000039', N'Cá basa kho tộ', 200000, N'', 1) 
insert into MENU values('MN0000000000000000040', N'Cá basa sốt cà chua', 150000, N'', 1) 
insert into MENU values('MN0000000000000000041', N'Cá basa phi lê chiên giòn', 180000, N'', 1) 
insert into MENU values('MN0000000000000000042', N'Canh khổ qua', 70000, N'', 1) 
insert into MENU values('MN0000000000000000043', N'Canh chua cá lóc', 90000, N'', 1) 
insert into MENU values('MN0000000000000000044', N'Gỏi xoài cá lóc chiên giòn', 75000, N'', 1) 
insert into MENU values('MN0000000000000000045', N'Gỏi ngó sen tôm thịt', 120000, N'', 1) 
insert into MENU values('MN0000000000000000046', N'Táo', 30000, N'', 1) 
insert into MENU values('MN0000000000000000047', N'Lê Hàn Quốc', 60000, N'', 1) 
insert into MENU values('MN0000000000000000048', N'Dưa hấu', 70000, N'', 1) 
insert into MENU values('MN0000000000000000049', N'Nước ép cà rốt', 30000, N'', 1) 
insert into MENU values('MN0000000000000000050', N'Rau câu dừa', 60000, N'', 1) 
insert into MENU values('MN0000000000000000051', N'Nước dừa', 25000, N'', 1) 
insert into MENU values('MN0000000000000000052', N'Trứng gà luộc', 20000, N'', 1) 
insert into MENU values('MN0000000000000000053', N'Trứng hấp thịt bằm', 70000, N'', 1) 
insert into MENU values('MN0000000000000000054', N'Cà chua xào trứng', 40000, N'', 1) 
insert into MENU values('MN0000000000000000055', N'Nước ép cà chua', 30000, N'', 1) 
insert into MENU values('MN0000000000000000056', N'Heo quay', 350000, N'', 1) 
insert into MENU values('MN0000000000000000057', N'Vịt quay', 300000, N'', 1) 
insert into MENU values('MN0000000000000000058', N'Gà quay', 280000, N'', 1) 
insert into MENU values('MN0000000000000000059', N'Da gà chiên mắm', 90000, N'', 1) 
insert into MENU values('MN0000000000000000060', N'Gà chiên lắc phô mai', 100000, N'', 1) 
insert into MENU values('MN0000000000000000061', N'Gỏi gan bò', 130000, N'', 1) 
insert into MENU values('MN0000000000000000062', N'Gỏi bì heo', 100000, N'', 1) 
insert into MENU values('MN0000000000000000063', N'Gà luộc', 130000, N'', 1) 
insert into MENU values('MN0000000000000000064', N'Chân gà xảo xả ớt', 80000, N'', 1) 
insert into MENU values('MN0000000000000000065', N'Chân gà rút xương', 130000, N'', 1) 
insert into MENU values('MN0000000000000000066', N'Thịt kho tàu', 170000, N'', 1) 
insert into MENU values('MN0000000000000000067', N'Bì heo xào xả ớt', 150000, N'', 1) 
insert into MENU values('MN0000000000000000068', N'Bún xào chay', 70000, N'', 1) 
insert into MENU values('MN0000000000000000069', N'Lẩu thái', 300000, N'', 1) 
insert into MENU values('MN0000000000000000070', N'Bún xào thịt bò', 90000, N'', 1) 
insert into MENU values('MN0000000000000000071', N'Tôm hấp bia', 320000, N'', 1) 
insert into MENU values('MN0000000000000000072', N'Trứng cút bách hoa', 70000, N'', 1) 
insert into MENU values('MN0000000000000000073', N'Trứng bọc gà nấm', 90000, N'', 1) 
insert into MENU values('MN0000000000000000074', N'Chả giò chiên', 75000, N'', 1) 
insert into MENU values('MN0000000000000000075', N'Súp cua tóc tiên', 100000, N'', 1) 
insert into MENU values('MN0000000000000000076', N'Hoành thánh chiên giòn', 70000, N'', 1) 
insert into MENU values('MN0000000000000000077', N'Bò hầm tiêu xanh', 400000, N'', 1) 
insert into MENU values('MN0000000000000000078', N'Bò nấu đậu', 350000, N'', 1) 
insert into MENU values('MN0000000000000000079', N'Phô mai que', 70000, N'', 1) 
insert into MENU values('MN0000000000000000080', N'Gà chiên coca', 120000, N'', 1) 
insert into MENU values('MN0000000000000000081', N'Tôm xào xả ớt', 90000, N'', 1) 
insert into MENU values('MN0000000000000000082', N'Mực xào dưa chua', 120000, N'', 1) 
insert into MENU values('MN0000000000000000083', N'Mực chiên giòn', 90000, N'', 1) 
insert into MENU values('MN0000000000000000084', N'Mực nướng muối ớt', 150000, N'', 1) 
insert into MENU values('MN0000000000000000085', N'Tôm rang me', 170000, N'', 1) 
insert into MENU values('MN0000000000000000086', N'Cá chép chiên mắm ớt', 1040000, N'', 1) 
insert into MENU values('MN0000000000000000087', N'Thịt bò nướng tảng', 600000, N'', 1) 
insert into MENU values('MN0000000000000000088', N'Mực sữa nướng', 160000, N'', 1) 
insert into MENU values('MN0000000000000000089', N'Tôm sốt mayonnaise', 160000, N'', 1) 
insert into MENU values('MN0000000000000000090', N'Cá viên chiên nước mắm', 160000, N'', 1) 
insert into MENU values('MN0000000000000000091', N'Cua rang me', 400000, N'', 1) 
insert into MENU values('MN0000000000000000092', N'Ghẹ nấu lẩu', 370000, N'', 1) 
insert into MENU values('MN0000000000000000093', N'Cá chình nướng muối ớt', 280000, N'', 1) 
insert into MENU values('MN0000000000000000094', N'Bánh flan', 30000, N'', 1) 
insert into MENU values('MN0000000000000000095', N'Canh bào ngư tiềm sò điệp', 320000, N'', 1) 
insert into MENU values('MN0000000000000000096', N'Vịt nấu chao', 420000, N'', 1) 
insert into MENU values('MN0000000000000000097', N'Cơm cà ri', 95000, N'', 1) 
insert into MENU values('MN0000000000000000098', N'Heo rừng xào lăn', 230000, N'', 1) 
insert into MENU values('MN0000000000000000099', N'Sườn heo nấu mắm', 270000, N'', 1) 
insert into MENU values('MN0000000000000000100', N'Sườn nướng mật ong', 420000, N'', 1) 
GO 

--SERVICE
insert into SERVICE values('SV0000000000000000001', N'Bưng bàn ghế', 1000000, N'', 1) 
insert into SERVICE values('SV0000000000000000002', N'Treo hoa', 500000, N'', 1) 
insert into SERVICE values('SV0000000000000000003', N'Bơm bóng bay', 100000, N'', 1) 
insert into SERVICE values('SV0000000000000000004', N'In ấn thiệp cưới', 100000, N'', 1) 
insert into SERVICE values('SV0000000000000000005', N'Thuê trang phục cưới', 100000, N'', 1) 
insert into SERVICE values('SV0000000000000000006', N'Trang trí tiệc cưới', 100000, N'', 1) 
insert into SERVICE values('SV0000000000000000007', N'Chụp hình quay phim', 1000000, N'', 1) 
insert into SERVICE values('SV0000000000000000008', N'Trang điểm ngày cưới', 100000, N'', 1) 
insert into SERVICE values('SV0000000000000000009', N'Trợ lí ngày cưới', 200000, N'', 1) 
insert into SERVICE values('SV0000000000000000010', N'Điều phối chương trình lễ cưới', 500000, N'', 1) 
insert into SERVICE values('SV0000000000000000011', N'Dịch vụ âm thanh và ánh sáng ngày cưới', 1000000, N'', 1) 
insert into SERVICE values('SV0000000000000000012', N'Ban nhạc trình diễn', 2000000, N'', 1) 
insert into SERVICE values('SV0000000000000000013', N'Dịch vụ bắn pháo hoa', 1000000, N'', 1) 
insert into SERVICE values('SV0000000000000000014', N'Dịch vụ dọn dẹp sau tiệc cưới', 1000000, N'', 1) 
insert into SERVICE values('SV0000000000000000015', N'Dịch vụ đưa đón', 1000000, N'', 1) 
insert into SERVICE values('SV0000000000000000016', N'Dịch vụ trang trí bàn thờ gia tiên', 300000, N'', 1) 
insert into SERVICE values('SV0000000000000000017', N'Dịch vụ chọn mâm ngũ quả', 100000, N'', 1) 
insert into SERVICE values('SV0000000000000000018', N'Dịch vụ trao đổi loại hình và phương án thực hiện', 500000, N'', 1) 
insert into SERVICE values('SV0000000000000000019', N'Dịch vụ tổ chức hội thảo hội nghị', 100000, N'', 1) 
insert into SERVICE values('SV0000000000000000020', N'Dịch vụ khác: sinh nhật, thôi nôi', 1000000, N'', 1) 
GO 

--WEDDING
set dateformat dmy 
INSERT INTO WEDDING VALUES ('WD0000000000000000001', 'LB0000000000000000003', 'SH0000000000000000001', '12/5/2022', 
'20/5/2022', '0978425162', N'Nguyễn Minh Quân', N'Hồ Ngọc Trúc Anh', 25, 3, null, 12000000, 1, N'Hồ Nhật Anh') 
INSERT INTO WEDDING VALUES ('WD0000000000000000002', 'LB0000000000000000002', 'SH0000000000000000002', '20/5/2022', 
'12/6/2022', '070657354', N'Lã Ngọc Nguyên', N'Trần Thị Bích Thủy', 20, 3, null, 10000000, 1, N'Lã Thị Bích Ngọc') 
INSERT INTO WEDDING VALUES ('WD0000000000000000003', 'LB0000000000000000009', 'SH0000000000000000001', '1/7/2022', 
'30/7/2022', '0975675110', N'Nguyễn Hoàng Tuấn Khanh', N'Nguyễn Tú Trinh', 20, 3, null, 17000000, 1, N'Nguyễn Hồng Phượng') 
INSERT INTO WEDDING VALUES ('WD0000000000000000004', 'LB0000000000000000001', 'SH0000000000000000001', '1/6/2022', 
'15/7/2022', '0703256781', N'Nguyễn Hoàng Thu Đông', N'Võ Thị Như Ý', 15, 4, null, 15000000, 1, N'Nguyễn Trung Hiếu') 
INSERT INTO WEDDING VALUES ('WD0000000000000000005', 'LB0000000000000000005', 'SH0000000000000000002', '23/4/2023', 
'7/5/2023', '097645782', N'Trịnh Trung Hiếu', N'Nguyễn Hồng Ân', 40, 6, null, 85000000, 1, N'Lê Thị Trường Vy') 
INSERT INTO WEDDING VALUES ('WD0000000000000000006', 'LB0000000000000000019', 'SH0000000000000000001', '2/2/2022', 
'20/2/2022', '0764313095', N'Nguyễn Thành Trung', N'Nguyễn Hồng Anh', 25, 5, null, 55000000, 1, N'Nguyễn Đăng Khoa') 
GO 

--BILL
INSERT INTO BILL VALUES ('BI0000000000000000001', 'WD0000000000000000001', '12/05/2022', null, null, null,'12/05/2022', null)  
INSERT INTO BILL VALUES ('BI0000000000000000002', 'WD0000000000000000002', '20/05/2022', null, null, null,'20/05/2022', null)  
INSERT INTO BILL VALUES ('BI0000000000000000003', 'WD0000000000000000003', '1/7/2022', null, null, null,'1/07/2022', null)  
INSERT INTO BILL VALUES ('BI0000000000000000004', 'WD0000000000000000004', '1/6/2022', null, null, null,'1/06/2022', null)  
INSERT INTO BILL VALUES ('BI0000000000000000005', 'WD0000000000000000005', '23/4/2023', null, null, null,'23/4/2023', null)  
INSERT INTO BILL VALUES ('BI0000000000000000006', 'WD0000000000000000006', '2/2/2022', null, null, null,'2/2/2022', null)  
GO 

--TABLE DETAIL
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000001', 'MN0000000000000000001', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000001', 'MN0000000000000000006', 1, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000001', 'MN0000000000000000013', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000001', 'MN0000000000000000026', 4, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000001', 'MN0000000000000000037', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000001', 'MN0000000000000000043', 7, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000002', 'MN0000000000000000078', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000002', 'MN0000000000000000056', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000002', 'MN0000000000000000023', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000002', 'MN0000000000000000063', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000002', 'MN0000000000000000098', 5, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000002', 'MN0000000000000000073', 4, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000003', 'MN0000000000000000021', 4, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000003', 'MN0000000000000000030', 1, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000003', 'MN0000000000000000006', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000003', 'MN0000000000000000016', 4, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000003', 'MN0000000000000000056', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000003', 'MN0000000000000000093', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000004', 'MN0000000000000000046', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000004', 'MN0000000000000000067', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000004', 'MN0000000000000000044', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000004', 'MN0000000000000000012', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000004', 'MN0000000000000000036', 4, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000004', 'MN0000000000000000015', 5, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000005', 'MN0000000000000000063', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000005', 'MN0000000000000000046', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000005', 'MN0000000000000000019', 4, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000005', 'MN0000000000000000025', 1, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000005', 'MN0000000000000000008', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000005', 'MN0000000000000000014', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000005', 'MN0000000000000000011', 5, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000006', 'MN0000000000000000027', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000006', 'MN0000000000000000033', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000006', 'MN0000000000000000045', 1, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000006', 'MN0000000000000000060', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000006', 'MN0000000000000000010', 2, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000006', 'MN0000000000000000003', 3, null, N'')  
INSERT INTO TABLE_DETAIL VALUES ('WD0000000000000000006', 'MN0000000000000000086', 4, null, N'') 
GO 

--SERVICE DETAIL
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000001', 'SV0000000000000000001', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000001', 'SV0000000000000000003', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000001', 'SV0000000000000000005', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000001', 'SV0000000000000000013', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000002', 'SV0000000000000000001', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000002', 'SV0000000000000000006', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000002', 'SV0000000000000000012', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000002', 'SV0000000000000000016', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000002', 'SV0000000000000000007', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000003', 'SV0000000000000000002', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000003', 'SV0000000000000000003', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000003', 'SV0000000000000000005', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000003', 'SV0000000000000000009', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000003', 'SV0000000000000000010', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000003', 'SV0000000000000000012', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000004', 'SV0000000000000000001', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000004', 'SV0000000000000000005', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000004', 'SV0000000000000000006', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000004', 'SV0000000000000000013', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000004', 'SV0000000000000000007', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000005', 'SV0000000000000000001', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000005', 'SV0000000000000000003', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000005', 'SV0000000000000000006', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000005', 'SV0000000000000000005', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000005', 'SV0000000000000000015', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000005', 'SV0000000000000000009', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000006', 'SV0000000000000000003', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000006', 'SV0000000000000000004', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000006', 'SV0000000000000000007', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000006', 'SV0000000000000000009', 1, null, N'')  
INSERT INTO SERVICE_DETAIL VALUES ('WD0000000000000000006', 'SV0000000000000000012', 1, null, N'') 
GO 

--PARAMETER
insert into PARAMETER values ('Recruiter', 1)  -- chỉ người có priority <= 1 mới có quyền thu nhận nhân viên mới
insert into PARAMETER values ('MaxTable', 50)  -- 1 phòng cưới chỉ có tối đa 50 bàn
insert into PARAMETER values ('PenaltyRate', 1)  -- tiền phạt trả trễ là 1% / ngày
insert into PARAMETER values ('RulesFollowing', 1)  -- 1 = áp dụng tiền phạt (phía trên), 0 = không áp dụng
GO 

--UPDATE TABLEITEMSPRICE
UPDATE TABLE_DETAIL 
SET TotalItemsPrice	= AmountOfItems * M.ItemPrice
FROM TABLE_DETAIL D JOIN MENU M ON M.ItemNo = D.ItemNo
GO 

--UPDATE TABLESERVICESPRICE
UPDATE SERVICE_DETAIL
SET TotalServicesPrice = AmountOfServices * ServicePrice
FROM SERVICE_DETAIL SD JOIN SERVICE S ON S.ServiceNo = SD.ServiceNo
GO 

--UPDATE TABLEPRICE
UPDATE WEDDING
SET TablePrice = (SELECT SUM(T.TotalItemsPrice)
					FROM TABLE_DETAIL T 
					WHERE T.WeddingNo = W.WeddingNo)
FROM WEDDING W
GO 

--UPDATE TABLEPRICETOTAL
UPDATE BILL
SET TablePriceTotal = (AmountOfContingencyTable + AmountOfTable) * (MinTablePrice + TablePrice)
FROM BILL B JOIN WEDDING W ON W.WeddingNo = B.WeddingNo 
	JOIN TABLE_DETAIL TD ON TD.WeddingNo = W.WeddingNo
	JOIN LOBBY L ON L.LobbyNo = W.LobbyNo
	JOIN LOBBY_TYPE LT ON L.LobbyTypeNo = LT.LobbyTypeNo
GO 

--UPDATE TABLESERVICETOTAL
UPDATE BILL
SET	ServicePriceTotal = (SELECT sum(TotalServicesPrice)
						FROM SERVICE_DETAIL SD JOIN WEDDING W ON W.WeddingNo = SD.WeddingNo
						WHERE W.WeddingNo = B.WeddingNo)
FROM BILL B
GO 

--UPDATE TOTAL
UPDATE BILL
SET Total = TablePriceTotal + ServicePriceTotal
FROM BILL B JOIN WEDDING W ON W.WeddingNo = B.WeddingNo 
GO 
	
--UPDATE MONEYLEFT
UPDATE BILL
SET MoneyLeft = Total - Deposit
FROM BILL B JOIN WEDDING W ON W.WeddingNo = B.WeddingNo
GO 
