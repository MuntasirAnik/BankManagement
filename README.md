# BankManagement

# Prerequirements
 * Visula studio
 * .Net SDK 8.0.101
 * SQL Server

# How To Run
 * Clone the code
 * checkout to ```dev``` branch
 * install required nuget packages
 * command ```dotnet run``` or ```dotnet watch run``` in terminal.

# Features
* Auth
  * Registration for Admin, customer, Employee
  * Login for the user
  ## default Account
    * username: ```Admin```
    * password: ```Admin@123```
* Custoemrs
* Account Types
* Account ( Account opeing for Custoemrs)
* Transfer Type
* Transactions
* fund Transfer

# Guide Lines
  * Create other user using default ```admin credential```
      * username: ```Admin```
      * password: ```Admin@123```
  * create customer
  * create account types like (Savings, Current etc)
  * Create account for ```Customers```
  * now login as ```Customer``` use default password for login ```User@432!```
  * perform ```deposit``` and ```withdraw``` in Transaction controller
  * Perform ```fund transfer``` in ```fundTransfer``` controller
  * Check transaction history.
  * Check account statement in report controller
