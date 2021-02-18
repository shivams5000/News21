GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'169a34dc-dd51-456d-8681-b3af622eba67', N'admin', N'admin', N'9e4c7b19-7e5e-4332-bcee-755454ca53db')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'81913215-1f60-4bd0-8784-53cd17dc12ac', N'admin@news21.com', N'ADMIN@NEWS21.COM', N'admin@news21.com', N'ADMIN@NEWS21.COM', 1, N'AQAAAAEAACcQAAAAENc7cqouhGbdemJeNDTOBsWVruk8rXQVA9eR4BI26k1psuqQyhzpSSfkD8ORVtGqEA==', N'H53BAJ6RLY3UCVKP4PUKPUO3XGJ52VNH', N'0993ff1d-97ef-44c8-8b12-2c2ac4b2fd8d', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b954472f-094b-4be6-ab47-c44ee5725568', N'johns@gmail.com', N'JOHNS@GMAIL.COM', N'johns@gmail.com', N'JOHNS@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEKvnAzFNLpgJ9mo0HEaEGDteq4w/nYdrHS6EtyfNWOOMLkXRAj8RrzKc/M4m+txbGw==', N'BFJRTEMSOTBFAOIO5PAXOPJGNNH64BNN', N'b739489e-eeca-490b-9b95-2e9fc05377da', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'81913215-1f60-4bd0-8784-53cd17dc12ac', N'169a34dc-dd51-456d-8681-b3af622eba67')
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (1, N'India')
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (2, N'New Zealand')
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (4, N'United States')
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (5, N'Australia')
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (6, N'UAE')
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (7, N'Japan')
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (8, N'England')
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsCategories] ON 
GO
INSERT [dbo].[NewsCategories] ([CategoryID], [CategoryName]) VALUES (1, N'Sports')
GO
INSERT [dbo].[NewsCategories] ([CategoryID], [CategoryName]) VALUES (2, N' Political')
GO
INSERT [dbo].[NewsCategories] ([CategoryID], [CategoryName]) VALUES (3, N'Entertainment')
GO
INSERT [dbo].[NewsCategories] ([CategoryID], [CategoryName]) VALUES (4, N'Economy')
GO
SET IDENTITY_INSERT [dbo].[NewsCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsInfos] ON 
GO
INSERT [dbo].[NewsInfos] ([NewsID], [NewsTitle], [Description], [Extension], [CountryID], [CategoryID]) VALUES (1, N'''We couldn''t be happier'': All Blacks great Dan Carter and former Black Stick Honor Carter expecting fourth child', N'All Blacks great Dan Carter and former Black Stick Honor Carter have announced they are expecting their fourth child.

The sporting couple, who already have three boys – Marco, Fox and Rocco – have announced the news on social media.

"My family is everything to me... my happiness and my greatest success," Dan Carter posted to Instagram.', N'.jpg', 2, 1)
GO
INSERT [dbo].[NewsInfos] ([NewsID], [NewsTitle], [Description], [Extension], [CountryID], [CategoryID]) VALUES (2, N'England’s tour of India could go free-to-air as Channel 4 eyes rights', N'UK free-to-air (FTA) commercial broadcaster Channel 4 is in the running for broadcast rights to the England national cricket team’s tour of India, according to The Telegraph.

The rights to the tour are owned by Disney’s Indian media brand Star, which in 2018 paid Rs6138.1 crore (US$840 million) for a global, five-year broadcast partnership with the Board of Control for Cricket in India (BCCI).

Australia v India Test series breaks Foxtel viewing figures

In December it was reported that Star was considering airing the tour’s four Test matches, five Twenty20 internationals and three one day internationals (ODIs) via its Hotstar streaming service. Now, according to The Telegraph, Star appears to be seeking a more traditional distribution model.

With significant audiences expected to tune in and a surge in Indian interest after the national team’s recent win in Australia, Star is reportedly seeking to sublicence ', N'.PNG', 1, 1)
GO
INSERT [dbo].[NewsInfos] ([NewsID], [NewsTitle], [Description], [Extension], [CountryID], [CategoryID]) VALUES (3, N'Biden economic advisor Bernstein defends Covid relief plan’s $1.9 trillion', N'1. Jared Bernstein, a longtime economic advisor to President Joe Biden, on Wednesday defended the size of the administration’s $1.9 trillion stimulus package.
2. “Reconciliation doesn’t mean no Republicans joined the plan,” Bernstein said. “There’s a lot of common ground when it comes to virus control, when it comes to helping businesses.”
3. He said the bill could still attract bipartisan support even if Congress passes it using budget reconciliation, which requires only a simple majority.', N'.PNG', 4, 4)
GO
INSERT [dbo].[NewsInfos] ([NewsID], [NewsTitle], [Description], [Extension], [CountryID], [CategoryID]) VALUES (4, N'India vs India-A in England before Test series', N'In an unprecedented build-up schedule for an overseas Test series, India will take on India-A in a four-day practice match when the two sides travel to England later this year.

The game will be played at the County Ground in Northamptonshire in July later this year. The exact dates of the match will be unveiled later.', N'.jpg', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[NewsInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsComments] ON 
GO
INSERT [dbo].[NewsComments] ([CommentID], [CommentText], [CommentDate], [ReviewerName], [NewsID]) VALUES (1, N'This is good news and hope everything is well', CAST(N'2021-02-04T09:41:00.0000000' AS DateTime2), N'admin@news21.com', 1)
GO
SET IDENTITY_INSERT [dbo].[NewsComments] OFF
GO
