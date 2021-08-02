SELECT *
FROM dbo.data

--1)	How many unique restaurants could be found in this data set? 
--Hint: Use [Business_ID] column for this evaluation.

SELECT COUNT(Unique_Restaranes)
FROM    (
SELECT COUNT(Business_ID) as Unique_Restaranes
FROM dbo.Data
GROUP BY Business_ID
) AS Unique_Restaranes

--2)	Which restaurant received highest number of reviews? What about percentage-wise?

SELECT TOP 1 BN.Business_Name , (CAST(BC.Business_Count AS DECIMAL )*100)/CAST(T.Total AS DECIMAL) AS '%'
FROM ( 
SELECT TOP 1 Business_Name
FROM dbo.Data
WHERE Business_ID = (
SELECT TOP 1 Business_ID
FROM dbo.Data
GROUP BY Business_ID
ORDER BY COUNT(Business_ID) DESC )
) BN
cross join
(
SELECT COUNT(Business_ID) AS Business_Count
FROM dbo.Data
GROUP BY Business_ID
) BC 
cross join 
(
SELECT COUNT(*) AS Total
FROM dbo.Data
) T
ORDER BY '%' DESC


--3)	Which cities have got at least one 5 star review in Nevada (NV) state?
SELECT City
FROM dbo.Data
WHERE Avg_Business_Star_Rating = 5.0 AND dbo.Data.State = 'NV'
GROUP BY City
 
--4)	Which city has got the highest number of reviews in the Business Category of “Hotels & Travel”? What about percentage-wise? 

SELECT C.City , C.Business_Category_Count , (CAST(C.Business_Category_Count AS DECIMAL )*100)/CAST(T.Total AS DECIMAL) AS '%'
FROM 
(
SELECT TOP 1 City , COUNT(City) AS Business_Category_Count
FROM dbo.Data
WHERE Business_Category = 'Hotels & Travel'
GROUP BY City
ORDER BY COUNT(City) DESC
) C
cross join 
(
SELECT COUNT(Business_Category) AS Total
FROM dbo.Data
GROUP BY Business_Category 
HAVING  Business_Category = 'Hotels & Travel'
) T

--5)	At what day of the week people are more likely to post their reviews?
SELECT COUNT(DATENAME(dw,Review_Date)) ,DATENAME(dw,Review_Date)
FROM dbo.Data
GROUP BY DATENAME(dw,Review_Date)
ORDER BY COUNT(DATENAME(dw,Review_Date)) DESC

--6)	Showcase if there are any trends regarding restaurant performance as time goes by.

