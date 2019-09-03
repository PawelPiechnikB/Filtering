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
*Answer*: Use Where() method.

What type of API in .NET we should use? 
*Answer*: Expression API (Expression static class).

What kind of structure will be best to represent what is being filtered?
*Answer*: filtering-structure.md

How composite design pattern can help to implements filtering?
