# kpi-practice
free meaningful description

# Тема АПІ: Піца

### Ресурс: заклади, де готують піцу

Модель даних закладів, де готують піцу(**Cafe**)

-   ідентифікаційний номер (Int)
-   назва закладу (String), максимальна кількість символів - до 30
-   Час відриття (Timespan)
-   Час закриття (Timespan)

###### Клієнт (звичайний користувач, який може лише отримати інформацію про певний заклад, або список закладів у місті):

>   Як клієнт я хочу мати можливість дізнатися про певний заклад, де готують піцу в місті

**Get{id}** – видає всю інформацію про певний заклад, де готується піца 
- На вході у строці запиту - {id}
- на виході модель даних **Cafe**
- Якщо в id буде передаватись не integer, або число буде більшим за кількість id в цьому закладі, повертатиметься помилка 400 Bad Request і 404 Not found відповідно

>   Як клієнт я хочу мати можливість виводити список закладів, що працюють у місті  

**Get** – видає список усіх закладів, де готується піца, у місті
-	на виході список моделей даних **Cafe**
- Має сенс використовувати пагінацію, так як у місті багато закладів, де готують піцу
 
###### Менеджер закладу (користувач, який може змінювати інформацію про певний заклад, додавати та видаляти їх):

>   Як менеджер я хочу змінювати назву певного закладу 

**Put{id}** – змінює дані закладу
-	на вході у строці запиту - {id}, а у тілі запиту має передаватись назва закладу (string Name) 
-	на виході отримуємо модель даних **Cafe**, яку ми змінили (аналогічно Get{id})
-	Якщо в id буде передаватись не integer, або число буде більшим за кількість id в цьому закладі, повертатиметься помилка 400 Bad Request і 404 Not found відповідно

>   Як менеджер я хочу створювати та видаляти заклади з системи 

**Post** – створює новий заклад
-	на вході у тілі запиту має передаватись модель даних **Cafe** без id 
-	на виході отримуємо модель даних **Cafe**, яку ми створили (аналогічно Get{id})
-	Якщо нв вході в тілі запиту не модель даних **Cafe**, повертатиметься помилка 400 Bad Request 

**Delete{id}** – видаляє закоад з системи
-	на вході у строці запиту - {id}
-	на виході отримуємо id щойно видаленої моделі данних
-	Якщо в id буде передаватись не integer, або число буде більшим за кількість id в цьому закладі, повертатиметься помилка 400 Bad Request і 404 Not found відповідно

###### Приклад запитів:
-  POST/api/v1/cafe
-  PATCH/api/v1/cafe/{id}
-  GET/api/v1/cafe
-  GET/api/v1/cafe/{id}
-  DELETE/api/v1/cafe/{id}

### Ресурс: позиції меню

Модель даних піци (**Pizza**)

- ідентифікаційний номер (integer)
- назва піци (string), максимальна кількість символів - до 30
- розмір піци (в см) (int), можливі значення - 20, 30, 40
- cклад піци (List(string)), максимальна кількість елементів списку - 10, максимальна кількість символів у строках - до 30

###### Клієнт (звичайний користувач, який може лише отримати інформацію про певну піцу, або список піц):

>   Як клієнт я хочу отримувати інформацію про певну піцу

**Get{id}** – видає інформацію про певну піцу, яка готується у певному кафе
- на вході у строці запиту - {id}
- на виході модель даних **Pizza**
- Якщо в id буде передаватись не integer, або число буде більшим за кількість id в цьому закладі, повертатиметься помилка 400 Bad Request і 404 Not found відповідно

>   Як клієнт я хочу отримувати список позицій у меню піцерії

**Get** – видає список усіх піц, що є у меню
- на виході список моделей даних **Pizza**
-	Так як позиій у меню однієї піерії не перевищує 20, немає сенсу використовувати пагінацію

###### Менеджер закладу (користувач, який може змінювати інформацію про піци, додавати та видаляти їх з меню)

>   Як менеджер я хочу змінювати інформацію про певну піцу

**Put{id}** – змінює інформацію про піцу
- на вході у строці запиту - {id}, а у тілі запиту має передаватись модель даних **Pizza**
-	на виході отримуємо модель даних **Pizza**, яку ми змінили (аналогічно Get{id})
-	Якщо в id буде передаватись не integer(чи в тілі запиту не модель даних **Pizza**), або число буде більшим за кількість id в цьому закладі, повертатиметься помилка 400 Bad Request і 404 Not found відповідно

>   Як менеджер я хочу додавати та видаляти піци з меню

**Post** – додає позицію у меню
- на вході у тілі запиту має передаватись модель даних **Pizza** без id 
- на виході отримуємо модель даних **Pizza**, яку ми створили (аналогічно Get{id})
- Якщо нв вході в тілі запиту не модель даних **Pizza**, повертатиметься помилка 400 Bad Request 

**Delete{id}** – видаляє позицію з меню
- на вході у строці запиту - {id}
- на виході отримуємо id щойно видаленої моделі данних
- Якщо в id буде передаватись не integer, або число буде більшим за кількість id в цьому закладі, повертатиметься помилка 400 Bad Request і 404 Not found відповідно

###### Приклад запитів:

-  POST/api/v1/cafes/{cafeId}/pizzas
-  PUT/api/v1/cafes/{cafeId}/pizzas/{id}
-  GET/api/v1/cafes/{cafeId}/pizzas
-  GET/api/v1/cafes/{cafeId}/pizzas/{id}
-  DELETE/api/v1/cafes/{cafeId}/pizzas/{id}
