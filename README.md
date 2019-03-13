# _Hair Salon Manager_

#### _This website is designed to allow simple customer and employee data management for a hair salon._

#### _By **Dave Sarbora**_

## _Description_
_The website uses a database to store information about customers and employees, allows users to create new entries, and get simple information about which customers visit which employee._

## _Specifications_

#### _This site is composed of a homepage and three subpages. From the homepage, a user can visit the employees, customers, or specialties homepage.
* The class homepage offers navigation to many of the other features of the website. Clicking on the buttons on the left of the screen will take you to a pa. Each button on the screen directs to a different path. It is divided into three columns.**
* In the left column are the navigational buttons which will bring you to different screens where instances of the class may be added or edited.

* For example, clicking the green "Hire a new empoloyee" button in the left column of the employees homepage will take you to a form where you can add a new employee. As much as possible, the author tried to stay consistent with this format throughout the construction of the website.

* Once employees are added they can be seen in the center column of the employee index page. Clicking on this link brings you to a "show page" that shows the customers of any individual employee, and allows the deletion of that employee from the database. 

* The "customers" show page shows which stylists they use in the center column, and the "specialties" show page shows which employees currently offer that specialty.

* 
**Each section -- employees, customers, and specialties each have this feature in common. Their navigation features appear on the left and a list of all members of their classes appear in the center.**

* If one clicks on the name of an item in the center column, they will be taken to a "show" page, where additional features can be seen. Currently the show pages are set up in a bit of a jumble, but 
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
_There are two databases associated with this project. If needed, they can be created under the names "dave_sarbora" and "dave_sarbora_test."_
_Each database should be structurally identical and contain six tables. The names of these tables are:
* _customers_
* _employees_
* _specialties_
* _customer_employee_
* _customer_specialty_
* _employee_specialty_

The column id represents an automatically incrementing primary key.

Each table is shown below as a one column, with their columns themselves depicted as rows.
**Primary tables**
|customers|employees|specialties|
|--------:|:-------:|-----------|
|id       |id       |id         |
|name     |name     |name       |

**Join tables**
|customer_employee|customer_specialty|employee_specialty|
|----------------:|:----------------:|------------------|
|id               |id                |id                |
|customer_id      |customer_id       |employee_id       |
|employee_id      |specialty_id      |specialty_id      |
|                 |current           |                  |
|

* _**id** refers to a serial PRIMARY KEY_*
* _**name** refers to a VARCHAR_
* _all **foreign id** keys refer to an INT_
* _**current**, in the customer specialty join table, refers to a BOOLEAN that is only toggled on for the last haircut a customer is associated with._

## _Known Bugs_
_User interface is not fully built, users may be unable to make use of certain methods available to each class._

## _Support and Contact Details_
_Contact me at [dsarbora@gmail.com](dsarbora@gmail.com)_

## _Technologies Used_
* _C#_
* _HTML & CSS_
* _Bootstrap_
* _MAMP_
* _Visual Studio Code_
* _Microsoft ASP.NET Core_
* _MSTest_

### _License_

*MIT*

Copyright (c) 2019 **_Dave Sarbora_**