#***Project Choices***
>##**Why MVC**
>>Firstly, as per Criteria of Assignment, the preferred Language of the server side was C# and Html for the interface. Secondly, I have experience with MVC from my work at dominos and that is what I was most familiar with. Also, to test my code all you need is vs code and run using IIS Express.

>##**Why Did I Handle the Query Via URL**
>>Simplicity, And I do not believe in saving Cookies unless necessary. 


#***Algorithm Design Choices***
>*This is talking about code in Number_to_Words_Web_App.ManipulateNumericMoneyData.cs*

>Based on Assignment IO example, I assumed that this page would be handling currency and should accept '$', ',' and '.'.

>##**Why Is Arrays for Converting**
>>Initially My first instinct was to add a switch statement but into my 4th case I gave up as I quickly realized how much work it was. Next, I thought of Hash tables, but again realized the set up would be too long. I remembered that previously I used the index or an array as a hash in a previous project, the powerful part of using a array is that "Hashes" that I wouldn’t need I could leave as an empty string. *Later after getting peer reviewed, I was suggested to investigate tuple now I realized may be a good way to implement*

>##**Why Do I Use 3 arrays**
>>I knew that I couldn’t handle 12 like 25 as Twenty-Five is made of Twenty and Five but if did it the same for 12 it would be Ten-Two which is not English. The Last Array "positiveExponentsOfThousand" is to append Thousand, Million etc.

>##**Input Management**
>>naturally I added a validator for the input, originally, I added to consider random characters but realized I can catch the exception from converting to an int in my try block in my controller. also considered that cents are no more than 2 decimal places, and currency can only have 1 decimal

>##**Nesting**
>>I tried to limit nesting in my code and exit out of nest as soon as possible, Unfortunately I didn’t think of a way from my Double foreach Loop on Line 38-48 of ManipulateNumericMoneyData.cs. Later after Code review, it was suggested to use regex as my method would open my code up to foreach overflow attacks.

>##**Commenting**
>>I tried to ensure relevant naming conventions and names that described what methods did or names that explain what variables was used for.


#***Test Plan***
>As what I understand test plan is an AZURE service which I'm not Hosting on I didn’t know how I would Create a Test Plan.
Instead, I create Unit Tests.


