# Project milestone 2
Akhmetova Bayan - CSSE-1701
Entities:
1.	***Student*** [StudentID, Name, SurName, Age, virtual StudentAddress StudentAddress]
2.	***StudentAddress*** [StudentID, Address, City, Country]
3.	***Employee*** [EmployeeID, FirstName, LastName, DepartmentID, virtual Department Department]
4.	***Department*** [DepartmentID, DepartmentName, ICollection<Employee> Employees]
5.	***Author*** [AuthorID, Name, SurName, ICollection<AuthorToBook> AuthorsToBooks]
6.	***Book*** [BookID, Title, ICollection<AuthorToBook> AuthorsToBook]
7.	***AuthorToBook*** [AuthorToBookID, AuthorID, BookID, virtual Author Author, virtual Book Book]
