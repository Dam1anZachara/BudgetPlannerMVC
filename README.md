# Budget Planner MVC application

## Table of contents
I. [Information](#information)

II. [Technology Used](#technology-used)

III. [Presentation of the application](#presentation-of-the-application)
1. [Registration Panel](#1registration-panel)
2. [Budget Users](#2budget-users)
3. [Budget Configuration](#3budget-configuration)
4. [Plan](#4plan)
5. [Amounts](#5amounts)
6. [Budget Status](#6budget-status)

IV. [Web API Project](#web-api-project)

## Information
The Budget Planner MVC application is used for budget planning and documenting your expenses and incomes. <br> The application consists of six main functions _Registration Panel, Budget Status, Amounts, Budget Configuration, Plan and Budget Users_.


## Technology Used
* .NET Core 5.0
* ASP.NET Core MVC
* Entity Framework Core 5.0.15
* Clean Architecture
* Repository-Service Pattern
* Dependency Injection
* LINQ
* Fluent Validation 11.0.1
* Fluent Validation.AspNetCore 11.0.1
* Fluent Validation.DependencyInjectionExtensions 11.0.1
* AutoMapper 11.0.1
* AutoMapper.Extensions.Microsoft.DependencyInjection 11.0.0
* Authentication.Facebook 5.0.17
* Authentication.Google 5.0.17
* MSSQL
* HTML5
* CSS
* Java Script
## Presentation of the application

### **1.	Registration Panel**

After the user registration, the new budget user is created.
![RegisterPanel](https://user-images.githubusercontent.com/95985120/184502174-cd2ecf82-b9d3-4636-a383-f3bc212076fd.png)

### **2.	Budget Users**

## **PreUser Panel** ##
After registration, the user gains role **_"PreUser"_**. In **_"Budget Users"_**, logged in user must create its profile. **_"PreUser"_** can see data of the other users by clicking on **_"Details"_** button.
![PreUserPanel](https://user-images.githubusercontent.com/95985120/184502402-7251f4e0-e86c-45b5-86ae-1c3858d3209d.png)
![CreateProfileAsPreUser](https://user-images.githubusercontent.com/95985120/184502414-5e633b91-22db-4dc1-a935-eca722dd6b00.png)
<br> When a profile is created, the first user gains role **_"Admin"_**. If minimum one user with role **_"Admin"_** exists, the next user gains role **_"User"_**. </br>

## **Admin Panel** ##
![AdminPanel2](https://user-images.githubusercontent.com/95985120/184503026-9e940adf-5332-44e9-83f4-a6c8541283e6.png)
**_"Admin"_** can edit users' roles in edit panel after clicking button **_"User permissions"_**. 
If there is one user with role **_"Admin"_**, that user can't downgrade himself from his **_"Admin"_** role. **_"Admin"_** can do it, if the other user is promoted to **_"Admin"_** role.
![EditRolePanel](https://user-images.githubusercontent.com/95985120/184503698-80e2810e-1c3b-4a61-8741-8e32d29c7775.png)
<br> **_"Admin"_** user can edit other users data by clicking on **_"Edit"_** and can delete the other users' profiles and accounts by clicking on **_"Delete"_** button. </br>

## **User Panel** ##
**_"User"_** can edit self profile by clicking button **_"Edit"_** and can see users data by clicking button **_"Details"_**.
![UserPanel](https://user-images.githubusercontent.com/95985120/184503847-3d3b6403-29a8-4f86-9614-d5dac5f72f30.png)

### **3.	Budget Configuration** 

In **_"Budget Configuration"_** we can create, edit and delete types to which we will assign amounts, e.g. "Food, cosmetics, clothes, work, etc." and assign them to "Expenses" or to "Incomes".
<br> By default, the program creates **_"General Expenses"_** and **_"General Incomes"_**. </br>
![IndexConfiguration3](https://user-images.githubusercontent.com/95985120/184504093-8b3399b0-1013-4e90-b6c4-88d00e3687c0.png)

### **4.	Plan**

In the tab **_"Plan"_** we can create, edit, delete a plan in any time range.
<br> It can be a plan for each month or, for example, annual or quarterly. </br>
![obraz](https://user-images.githubusercontent.com/95985120/184504197-da76e4a3-35ac-4ba2-a89f-3ed2201b4aaa.png)
<br> After "clicking" the button **_"Configuration"_** in a given plan, we can add, delete, edit the types of expenses or incomes that have been created in the **_"Budget Configuration"_** tab and enter the value of the amount we want to allocate for this type. </br>
![IndexPlanConfiguration2](https://user-images.githubusercontent.com/95985120/184504573-c772308a-d5ec-4da1-81a2-f2642b6e5b96.png)


When browsing the list of created plans, we can set the status of only one of them to **_"Active"_**. A plan with this status will be displayed in the **_"Budget Status"_** tab.

### **5.	Amounts**

In the **_"Amounts"_** tab, a list of amounts is displayed. We can add, delete and edit amounts. By adding the amount, we can choose the date, the type that we created in **_"Budget Configuration"_** and assign the amount to the user from **_"Budget Users"_**.
![IndexAmounts2](https://user-images.githubusercontent.com/95985120/184504932-ccc028f0-c53f-47bc-91cf-024a5ef3de74.png)
![AddAmount2](https://user-images.githubusercontent.com/95985120/184504938-8f4dd656-c289-42ce-9fe4-654b405d54e3.png)

<br> Amounts can be filtered in a selected date range, by expense type and by budget user. </br>
![IndexAmountsFind2](https://user-images.githubusercontent.com/95985120/184504945-fe75a820-06dd-451b-96cd-0b6a0aa47e17.png)

### **6.	Budget Status**

In the **_"Budget Status"_** tab, the active plan created in **_"Plan"_** is displayed.
![BudgetStatus1 2](https://user-images.githubusercontent.com/95985120/184505161-e332f67b-cd74-4177-b660-b98a6b88fc6c.png)

If we exceed the expenses in the plan, the status red **_"X"_** will be displayed.
![BudgetStatus2 2](https://user-images.githubusercontent.com/95985120/184505169-051d613d-0196-4503-8c8f-8d4062686a54.png)

<br> The opposite is true for incomes. Red **_"X"_** is displayed until we reach the planned income. </br>

Below the plan, the total of expenses, incomes, and balance sheet for the plan **_"In Plan"_** are displayed.
<br> For amounts with types that are not included in the plan, sums of expenses, incomes and balance are displayed **_"Out of Plan"_**. </br>
**_"Total"_** it is the sum of expenses, incomes and balance including **_"In Plan"_** and **_"Out of Plan"_**.

## Web API Project

All the functionalities from the MVC part were made available in the web API project.
![Swagger1 1](https://user-images.githubusercontent.com/95985120/196038623-005063ee-7cc2-4cb3-9f54-a3054912c302.png)
![Swagger2 1](https://user-images.githubusercontent.com/95985120/196038628-4b5ac2cb-7127-46b9-94db-cb64ed639c4a.png)
![Swagger3 1](https://user-images.githubusercontent.com/95985120/196038630-4697ea1c-c9be-4303-95a7-af198b101da2.png)

An example of getting a list of amounts
![SwaggerAmountList2](https://user-images.githubusercontent.com/95985120/196038641-597a9436-86a8-41b2-b76e-7ba3312e4859.png)

