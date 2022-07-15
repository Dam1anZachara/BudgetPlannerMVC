# BudgetPlannerMVC

## Aplikacja BudgetPlannerMVC służy do planowania i dokumentowania budżetu.<br>Aplikacja składa się z pięciu głównych funkcji tj. _Budget Status, Amounts, Budget Configuration, Plan i Budget Users_.

### **1.	Budget Configuration** 

W **_„Budget Configuration”_** możemy tworzyć, edytować i usuwać typy do jakich będziemy przypisywać kwoty np. „Jedzenie, kosmetyki, ubrania, praca itd. ” oraz przypisywać je do „Expenses” lub do „Incomes” (wydatki, przychody).
<br>Domyślnie program tworzy **_„General Expenses”_** i **_„General Incomes”_**.</br>
![IndexConfiguration](https://user-images.githubusercontent.com/95985120/179177404-26e5557b-e715-438f-8bff-ac9bc74b15be.png)

### **2.	Budget Users**

W **_„Budget Users”_** możemy dodawać, usuwać, edytować, użytkowników, którzy będą korzystać z budżetu.
<br>Domyślnie jest tworzony użytkownik **_„Not Assigned”_**.</br>
![IndexBudgetUsers](https://user-images.githubusercontent.com/95985120/179177552-7f387477-cb68-4b96-b957-f188b4993ad1.png)
![AddBudgetUser](https://user-images.githubusercontent.com/95985120/179177597-dfabfaec-9603-4a54-bd82-c2ec7eb43aee.png)

### **3.	Plan**

W zakładce **_„Plan”_** możemy stworzyć, edytować, usuwać plan w dowolnym zakresie czasu.
<br>Może być to plan na każdy miesiąc lub np. roczny, kwartalny. </br>
![IndexPlan](https://user-images.githubusercontent.com/95985120/179177962-4a5e43a8-4225-4136-a569-c73bb8cb1b8b.png)
<br>Po wejściu w przycisk **_"Configuration"_** w danym planie możemy dodawać, usuwać, edytować typy wydatków, które zostały utworzone w zakładce **_„Budget Configuration”_** oraz wpisać wartość kwoty jaką chcemy przeznaczyć na ten wydatek.</br>
![IndexPlanTypeConfiguration](https://user-images.githubusercontent.com/95985120/179178008-5c15e227-2a96-43b8-b905-285224015f66.png)

Przeglądając listę utworzonych planów możemy ustawić status tylko jednego z nich na **_„Active”_**. Plan z takim statusem będzie wyświetlany w zakładce **_„Budget Status”_**.

### **4.	Amounts**

W zakładce **_„Amounts”_** wyświetlana jest lista kwot. Możemy dodawać, usuwać, edytować kwoty. Dodając kwotę możemy wybrać czas, typ wydatku jaki utworzyliśmy w **_„Budget Configuration”_** oraz przypisać kwotę do użytkownika z **_„Budget Users”_**.
![IndexAmounts](https://user-images.githubusercontent.com/95985120/179178919-807249af-1bb0-4808-8ec6-ff09df37dd19.png)
![AddAmount](https://user-images.githubusercontent.com/95985120/179178952-766d48ee-33b4-4859-86b6-8c93103a274a.png)

<br>Kwoty możemy filtrować w danym przedziale czasowym, po typie wydatku oraz po użytkowniku budżetu.</br>
![IndexAmountsFind](https://user-images.githubusercontent.com/95985120/179178969-4513a2e6-435e-4fe4-93c7-895649430b89.png)

### **5.	Budget Status**

W zakładce **_„Budget Status”_** wyświetlany jest aktywny plan utworzony w **_„Plan”_**.
![BudgetStatus1](https://user-images.githubusercontent.com/95985120/179179472-a85dc5ad-a9ae-4d5d-9acf-65454cd4e6a3.jpg)

Jeśli przekroczymy wydatki w planie, zostanie wyświetlony status czerwony **_„X”_**.
![BudgetStatusUndone](https://user-images.githubusercontent.com/95985120/179179517-2b6476e4-1c92-4145-bb43-eac942c58f3d.png)
<br>Dla przychodów jest odwrotnie. Wyświetlany jest czerwony **_„X”_** dotąd, aż nie osiągniemy planowanego przychodu.</br>

Poniżej planu wyświetlane są sumy wydatków, przychodów i bilans dla planu **_„In Plan”_**.
<br>Dla kwot z typami, które nie zostały uwzględnione w planie wyświetlane są sumy wydatków, przychodów i bilans **_„Out of Plan”_**.</br> 
**_„Total”_** jest to suma wydatków, przychodów i bilans uwzględniające razem **_„In Plan”_** i **_„Out of Plan”_**.

