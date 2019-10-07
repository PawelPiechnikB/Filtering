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



Task 1:
Write console application which show example of filtering for following parameter:

((sample.TissueType.Name == "xxx1") || (sample.TissueType.Name == "xxx2")) && sample.FixativeUsed.Name == "yyyy1"



Task 2:
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

Task 3
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/
