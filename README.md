# ZenturyLoginsApp

Create a simple web application that has the following requirements:
- User login page with email and password fields,
- Home page with simple menu,
- Page menu with two items - Users and Logins, and a Logout button,
- Users page should have User overview list ordered by username, Add new user
button, Filter users field and Data Paging,
- Page for adding new users,
- Logins page should have User logins overview with Filter by user field, ordered by
last login first,
- REST web api using MVC pattern with controller, service and models for all web
application actions,
- Postgresql database to hold all the data,
- All code should be committed to a source code versioning system of choice.

  
Perform user input validation for all form fields (email pattern, input length). Validate
password field for minimum 6 letters, 1 Capital letter and 1 one number requirement.
Log every successful and every failed login attempt in the database table.
User list and Logins list should have sorting enabled by all appropriate columns. Paging
should be implemented on the server side. Use a fixed page size of 10 rows.
Use JWT token authentication for the communication with the REST api. The api should
have routes for every web application action. Login should be open to anyone, but every
other route should be protected and enabled only for logged in users. Login token expires
after 24 hours.
Use EF core with LINQ to access data from the db. Create a database with all the necessary
tables
