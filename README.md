# BudgetPlannerMVC

## The BudgetPlannerMVC application is used for budget planning and documentation. <br> The application consists of five main functions ie _Budget Status, Amounts, Budget Configuration, Plan and Budget Users_.

### **1.	Budget Configuration** 

In **_"Budget Configuration"_** we can create, edit and delete types to which we will assign amounts, e.g. "Food, cosmetics, clothes, work, etc." and assign them to "Expenses" or to "Incomes".
<br> By default, the program creates **_"General Expenses"_** and **_"General Incomes"_**. </br>
![IndexConfiguration](https://user-images.githubusercontent.com/95985120/179177404-26e5557b-e715-438f-8bff-ac9bc74b15be.png)

### **2.	Budget Users**

In **_"Budget Users"_** we can add, delete, edit, users who will use the budget.
<br> By default, the user **_"Not Assigned"_** is created. </br>
![IndexBudgetUsers](https://user-images.githubusercontent.com/95985120/179177552-7f387477-cb68-4b96-b957-f188b4993ad1.png)
![AddBudgetUser](https://user-images.githubusercontent.com/95985120/179177597-dfabfaec-9603-4a54-bd82-c2ec7eb43aee.png)
![DetailsBudgetUser](https://user-images.githubusercontent.com/95985120/180276489-c8d10265-a490-40b9-90ca-292a262e5747.png)

### **3.	Plan**

In the tab **_"Plan"_** we can create, edit, delete a plan in any time range.
<br> It can be a plan for each month or, for example, annual or quarterly. </br>
![IndexPlan2](https://user-images.githubusercontent.com/95985120/180275174-65a381f8-741b-4060-87b4-502fb6d5db5c.png)
<br> After entering the button **_"Configuration"_** in a given plan, we can add, delete, edit the types of expenses that have been created in the **_"Budget Configuration"_** tab and enter the value of the amount we want to allocate for this expense. </br>
![IndexPlanTypeConfiguration](https://user-images.githubusercontent.com/95985120/179178008-5c15e227-2a96-43b8-b905-285224015f66.png)

When browsing the list of created plans, we can set the status of only one of them to **_"Active"_**. A plan with this status will be displayed in the **_"Budget Status"_** tab.

### **4.	Amounts**

In the **_"Amounts"_** tab, a list of amounts is displayed. We can add, delete and edit amounts. By adding the amount, we can choose the time, the type of expense that we created in **_"Budget Configuration"_** and assign the amount to the user from **_"Budget Users"_**.
![IndexAmounts](https://user-images.githubusercontent.com/95985120/179178919-807249af-1bb0-4808-8ec6-ff09df37dd19.png)
![AddAmount](https://user-images.githubusercontent.com/95985120/179178952-766d48ee-33b4-4859-86b6-8c93103a274a.png)

<br> Amounts can be filtered in a given time period, by expense type and by budget user. </br>
![IndexAmountsFind](https://user-images.githubusercontent.com/95985120/179178969-4513a2e6-435e-4fe4-93c7-895649430b89.png)

### **5.	Budget Status**

In the **_"Budget Status"_** tab, the active plan created in **_"Plan"_** is displayed.
![BudgetStatus1](https://user-images.githubusercontent.com/95985120/179179472-a85dc5ad-a9ae-4d5d-9acf-65454cd4e6a3.jpg)

If we exceed the expenses in the plan, the status red **_"X"_** will be displayed.
![BudgetStatus2](https://user-images.githubusercontent.com/95985120/180275284-9b992d77-fad4-44bd-8676-6409a289f0d6.png)
<br> The opposite is true for incomes. Red is displayed **_"X"_** until we reach the planned income. </br>

Below the plan, the total of expenses, incomes, and balance sheet for the plan **_"In Plan"_** are displayed.
<br> For amounts with types that are not included in the plan, sums of expenses, incomes and balance are displayed **_"Out of Plan"_**. </br>
**_"Total"_** it is the sum of expenses, incomes and balance including **_"In Plan"_** and **_"Out of Plan"_**.
