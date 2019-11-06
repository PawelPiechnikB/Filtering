Create filtering library which can work with IQueryable<T> and IEnumerable<T>.

* We should be able to filter numbers, string, range of numbers, range of dates
* filtering operators:
  * equal, less than, more than for numbers
  * equal string trim lowercase for strings
  * contain string trim lowercase for strings
  * range for numbers
  * equal for enums

Guiding questions:

How filtering library should use IQueryable<T> and IEnumerable<T> during filtering?

Answer: Use Where() method.

What type of API in .NET we should use? 

Answer: Expression API (Expression static class).

What kind of structure will be best to represent what is being filtered?

Answer: filtering-structure.md

How composite design pattern can help to implements filtering?

Answer: https://sourcemaking.com/design_patterns/composite



# Task 1:
Write console application which show example of filtering for following parameter:

((sample.TissueType.Name == "xxx1") || (sample.TissueType.Name == "xxx2")) && sample.FixativeUsed.Name == "yyyy1"


# Task 2:
- use interface and classes to represent operators which will be responsible for doing operation
- create separate project forr yor filtering mechanism
- implement following operators: 
  - equal, 
  - not equal, 
  - contains, 
  - count, example TissueTypes.Count() == 4
    - Expresion.Call doesn't care that Count() is extension method, for Expresion.Call Count() is static method and in that way it should be called using Expresion.Call
  - "less than" or "less than or equal", example TissueSample.NumberOfSamples <= 1, TissueSample.NumberOfSamples < 1
  - "greater than" or "greater than or equal"
  - range, example TissueSample.NumberOfSamples => 1 && TissueSample.NumberOfSamples <= 1
  - I want to execute following expresions, please use existing operators:
    - TissueType.Name.Trim().ToLower().Contains("xxx1".Trim().ToLower())
    - TissueType.Name.ToLower() == "xxx1".ToLower()
    HINT:
    Find specific design pattern which solves that problem. ANSWER: Decorator
- create unit tests for each operator in separate project Filtering.Tests
- Model for filtering:

```
  class Employee
  {
      public string FirstName {get; set;}
      public string LastName {get; set;}
      public int Age { get; }
      public ICollection<Person> Subordinates {get; set;}
  }
```

 Autofixture can be helpfull to have mocked data https://github.com/AutoFixture/AutoFixture
 
 - read about design patern Composite https://sourcemaking.com/design_patterns/composite
 - read about design patern Decorator https://sourcemaking.com/design_patterns/decorator
 - very good book about design patterns: Design Patterns: Elements of Reusable Object-Oriented Software

# Task 3 Read theory about expressions in .NET

* https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions
* https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
* https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/


# Task 4 Write application in Blazor

In the future we will be using blazor as our frontend of our application in which we will be using filtering library. Right now we need to know Blazor as seperate thing more precisely.

Read about web assembly here. Can be briefly:
* https://developer.mozilla.org/en-US/docs/WebAssembly/Text_format_to_wasm

Read and do all following links:
* https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.0
* https://docs.microsoft.com/en-us/aspnet/core/blazor/get-started?view=aspnetcore-3.0&tabs=visual-studio
* https://docs.microsoft.com/en-us/aspnet/core/tutorials/build-your-first-blazor-app?view=aspnetcore-3.0

Write application which you should have by doing application described in last url. Extend this application with following features:
- add database and entitis fore todo app
- when you finish tutorial for todo app extend it with following features:
	- when you click add button new task should be saved in database
	- list with tasks should be refresh using endpoint
	- when you mark task as completed it should be also saved in database
	- add checkbox which allows to see / hide completed tasks

# Task 4.1 Add searching to todo app
- add searching to todo app using Blazored Typeahead https://github.com/Blazored/Typeahead
- watch https://www.youtube.com/watch?v=qF6ixMjCzHA

# Task 5
- Watch Robert C Martin - Clean Architecture and Design https://www.youtube.com/watch?v=Nsjsiz2A9mg
	- https://www.google.com/search?q=clean+architecture&rlz=1C1GCEA_enPL835PL835&source=lnms&tbm=isch&sa=X&ved=0ahUKEwiS-rbqv53lAhULCewKHZ0YADwQ_AUIEigB&biw=1920&bih=937#imgrc=Z36W6EF94PRRHM:
- create solution in VS in clean Architecture by Robert C Martin
	- add filtering library
	- create database based on your models
	- add page in blazor which displays data based on your Employee models
	- add filters to that page

# Task 6
- add endpoint which allows to filter Employess in full power so you could filter employes with following requirement: 
	- Employee.LastName = "O'Brian" AND (Employee.Age => 30 AND Employee.Age <= 50)
	- Employee.Occupation.Name = "Director" OR Employee.Occupation.Name = "Manager"
