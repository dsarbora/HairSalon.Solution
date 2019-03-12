# _Hair Salon Manager_

#### _This website is designed to allow simple customer and employee data management for a hair salon._

#### _By **Dave Sarbora**_

## _Description_
_The website uses a database to store information about customers and employees, allows users to create new entries, and get simple information about which customers visit which employee._

## _Specifications_
#### _A user can use this program to the the following:_
* _Create an entry for a new employee and save it to a database._
* _Delete an existing employee entry._
* _See a list of all employees currently in the database._
* _View a list of all customers associated with any employee._
* _Create or delete entries for customers in the database._
* _View details (currently just name) about each customer._

## _Setup/Installation Requirements_
**Setup**
----
* Download .NET Core 1.1.4 SDK and .NET Core Runtime 1.1.2 and install.
Download Mono and install.

* Download and install MAMP.

* Open the Control Panel and visit System > Advanced System Settings > Environment Variables...

* Then select PATH..., click Edit..., then Add.

* Add the exact location of your MySQL installation, as mentioned in step two above, and click OK. (This location is likely C:\MAMP\bin\mysql\bin, but may differ depending on your specific installation.)

* If you receive error stating the command mySQL is "not recognized", the location you provided is likely inaccurate. Double-check it and try again.

**Running the project**
----

* _Clone the project from [https://github.com/dsarbora/HairSalon.Solution](https://github.com/dsarbora/HairSalon.Solution)
* _Navigate in the command line to HairSalon.Solution/HairSalon.Test/_
* _Use the command **$dotnet restore** to import the packages used for this project._
* _To run the tests, use the command **$dotnet test.**_
* _To run the program, navigate in the command line to HairSalon.Solution/HairSalon._
* _If not not previously restored, use the command **$dotnet restore,** followed by **$dotnet build,** and then **$dotnet run** to run the program in browser.
* _Unzip the databases._
* _Navigate to http://localhost:5000/ in your web browser._

## _DATABASE INFORMATION_
* _There are two databases associated with this project. If needed, they can be created under the names "dave_sarbora" and "dave_sarbora_test."_
* _Each database should be structurally identical and contain two tables: "customers" and "employees."_
* _The "employees" table should include two columns in this order: "id," a serial PRIMARY KEY, and "name," data type VARCHAR._
* _The "customers" table is comprised of three columns in this order: "id," a serial PRIMARY KEY, "name," with data type VARCHAR, and "employee_id" of type int._

## _Known Bugs_
_No known bugs at this time._

## _Support and Contact Details_
_Contact me at [dsarbora@gmail.com](dsarbora@gmail.com)_

## _Technologies Used_
* _C#_
* _HTML & CSS_
* _Bootstrap_
* _Visual Studio Code_
* _Microsoft ASP.NET Core_
* _MSTest_

### _License_

*MIT*

Copyright (c) 2019 **_Dave Sarbora_**