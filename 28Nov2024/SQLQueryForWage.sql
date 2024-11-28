CREATE TABLE EmployeeAttendance (
    ID INT PRIMARY KEY,
    Name VARCHAR(100),
    Attendance BIT,  -- 1 for present, 0 for absent
    WorkingHours INT
);

-- Insert sample data into the table
INSERT INTO EmployeeAttendance (ID, Name, Attendance, WorkingHours)
VALUES
(1, 'John Doe', 1, 8),   -- Present, Full-time (8 hours)
(2, 'Jane Smith', 0, 0),  -- Absent, so no working hours
(3, 'Michael Brown', 1, 4), -- Present, Part-time (4 hours)
(4, 'Sarah Clark', 1, 8),  -- Present, Full-time (8 hours)
(5, 'Emily White', 0, 0);  -- Absent, so no working hours

select * from EmployeeAttendance;

CREATE FUNCTION CalculateWage (
    @WorkingHours INT  
)
RETURNS INT
AS
BEGIN

    DECLARE @Wage INT;
    
    IF @WorkingHours IS NOT NULL
        SET @Wage = @WorkingHours * 20; 
    ELSE
        SET @Wage = 0

    RETURN @Wage;
END;

SELECT 
    ID,
    Name,
    Attendance,
    WorkingHours,
    dbo.CalculateWage(WorkingHours) AS Wage
FROM EmployeeAttendance;
