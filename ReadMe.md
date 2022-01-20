Run the database project to create the database and load the seed data
Run the API to execute the end points using swaggerUI
Run the tests in the test project to pass the tests

As a Developer give flexibility to our business users to offer different APR (Annual Percentage Rate)
per quote on different make and vehicle type. At the moment data is held in excel with below
format.
APR % Ranges

| Make | Vehicle Type | Quote Type | 0-3 Months | 3-6 Months | 6-12 Months | 12+ Months|
| ----------- | ----------- | ----------- | ----------- | ----------- | ----------- | ----------- |
Audi |Car| PCP| 5.0| 6.0| 7.0| 8.0|
Audi |Car| HP| 6.0| 7.0| 8.0| 9.0|
Audi |Van| PCP| 4.0| 4.0| 4.0| 4.0|
BMW |Bike| HP| 5.0| 6.0| 7.0| 8.0|

Acceptance Criteria:
Give the ability to add a new Make/Vehicle Type/ Quote Type and APR range with minimal code changes/database configuration.

Post: Ability to save Make/Vehicle Type/ Quote Type and APR range in database
Get: Ability to get Make/Vehicle Type/ Quote Type and APR range for all makes

Technical Task Details:
Create a Web API using the entity framework code adhering to the SOLID principles for the below

1) Consider normalising the data.
2) Give the ability to add a new Make/Vehicle Type/ Quote Type and APR range with minimal code

Tasks:
1) Web API for Post data (insert) and Get operations.
 Post: Insert Make, Vehicle Type, Quote Type and Apr details
 Get: Get Make, Vehicle Types, Quote Types and Apr details for all the makes.
2) Unit test the code (Use a unit testing framework of your choice)
We are not looking for a perfect solution as we are more interested in your approach. 