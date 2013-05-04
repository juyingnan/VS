﻿IF OBJECT_ID('StuInfoDB') IS NOT NULL 
DROP TABLE WSStudent

GO

CREATE TABLE WSStudent
(
  ID_No varchar(20) primary key,
  Name nvarchar(MAX),
  Gender nvarchar(MAX),
  Major nvarchar(MAX),
  Email_Address varchar(MAX)
  )
GO

INSERT INTO WSStudent VALUES
('1201210522',N'陈聪',N'男',N'软件开发','1201210522@pub.ss.pku.edu.cn'),
('1201210530',N'陈锐',N'男',N'软件开发','1201210530@pub.ss.pku.edu.cn'),
('1201210618',N'江超',N'男',N'软件开发','1201210618@pub.ss.pku.edu.cn'),
('1201210619',N'江梦涛',N'男',N'软件开发','1201210619@pub.ss.pku.edu.cn'),
('1201210629',N'靳娇',N'女',N'软件开发','1201210629@pub.ss.pku.edu.cn'),
('1201210631',N'鞠英男',N'男',N'软件开发','1201210631@pub.ss.pku.edu.cn'),
('1201210640',N'黎槟华',N'男',N'自然语言处理','1201210640@pub.ss.pku.edu.cn'),
('1201210653',N'李璐',N'女',N'软件开发','1201210653@pub.ss.pku.edu.cn'),
('1201210675',N'李雪娇',N'女',N'软件开发','1201210675@pub.ss.pku.edu.cn'),
('1201210711',N'刘京沅',N'男',N'软件开发','1201210711@pub.ss.pku.edu.cn'),
('1201210714',N'刘彤',N'男',N'软件开发','1201210714@pub.ss.pku.edu.cn'),
('1201210738',N'马俊',N'男',N'软件开发','1201210738@pub.ss.pku.edu.cn'),
('1201210755',N'聂同朝',N'男',N'软件开发','1201210755@pub.ss.pku.edu.cn'),
('1201210782',N'隋向阳',N'男',N'软件开发','1201210782@pub.ss.pku.edu.cn'),
('1201210801',N'唐宇辰',N'男',N'软件开发','1201210801@pub.ss.pku.edu.cn'),
('1201210803',N'田邦仪',N'女',N'软件开发','1201210803@pub.ss.pku.edu.cn'),
('1201210812',N'王聪',N'男',N'软件开发','1201210812@pub.ss.pku.edu.cn'),
('1201210831',N'王鹏',N'男',N'软件开发','1201210831@pub.ss.pku.edu.cn'),
('1201210848',N'王颖',N'男',N'软件开发','1201210848@pub.ss.pku.edu.cn'),
('1201210860',N'魏鑫',N'男',N'软件开发','1201210860@pub.ss.pku.edu.cn'),
('1201210862',N'文子龙',N'男',N'软件开发','1201210862@pub.ss.pku.edu.cn'),
('1201210901',N'徐孟春',N'女',N'软件测试与质量保证','1201210901@pub.ss.pku.edu.cn'),
('1201210941',N'杨志鹏',N'男',N'软件开发','1201210941@pub.ss.pku.edu.cn'),
('1201210947',N'叶启威',N'男',N'软件开发','1201210947@pub.ss.pku.edu.cn'),
('1201210970',N'张诚',N'男',N'软件开发','1201210970@pub.ss.pku.edu.cn'),
('1201210977',N'张鹤',N'男',N'软件开发','1201210977@pub.ss.pku.edu.cn'),
('1201210980',N'张惠',N'女',N'电子服务技术','1201210980@pub.ss.pku.edu.cn'),
('1201210987',N'张萌',N'女',N'软件开发','1201210987@pub.ss.pku.edu.cn'),
('1201210999',N'张翔飞',N'女',N'软件开发','1201210999@pub.ss.pku.edu.cn'),
('1201211004',N'张欣欣',N'女',N'软件开发','1201211004@pub.ss.pku.edu.cn'),
('1201211020',N'张瑜',N'女',N'软件测试与质量保证','1201211020@pub.ss.pku.edu.cn'),
('1201211034',N'赵玮',N'女',N'软件开发','1201211034@pub.ss.pku.edu.cn'),
('1201211056',N'周湘锦',N'男',N'软件开发','1201211056@pub.ss.pku.edu.cn'),
('1201220737',N'李柏洁',N'女',N'软件测试与质量保证','1201220737@pub.ss.pku.edu.cn'),
('1201220807',N'罗照军',N'男',N'软件开发','1201220807@pub.ss.pku.edu.cn'),
('1201220879',N'王杨之',N'男',N'软件开发','1201220879@pub.ss.pku.edu.cn'),
('1201220889',N'韦红叶',N'女',N'软件测试与质量保证','1201220889@pub.ss.pku.edu.cn'),
('1201220891',N'吴海燕',N'女',N'软件测试与质量保证','1201220891@pub.ss.pku.edu.cn'),
('1201220915',N'晏冉',N'男',N'软件开发','1201220915@pub.ss.pku.edu.cn'),
('1201220966',N'张志超',N'男',N'软件开发','1201220966@pub.ss.pku.edu.cn')

GO

