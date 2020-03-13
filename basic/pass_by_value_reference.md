# Pass by Value and Pass by Reference

After passing an object (including a primitive) into a function, the function may modify the object. The question is whether any updates are done on the original or on a copy. If updates are done on a local copy, then they do not survive exiting the function and are not available outside the function. If updates are done the same object that was passed in, then they survive exiting the function and are available outside the function.

## General Rule
### Updates performed on value types object or an immutable type object are performed on a copy of the object. Updates do not survive exiting the function.


## Immutable Objects
If an object is immutable, then its state cannot be changed. Any changes create a new object. Any changes exist only within the function and do not update the object outside the function.

In C#, the following types are immutable:
* Primitive types (int, float)
* String
* Tuple
* URI
* DateTime

## Value Types
When passing a value type, the value of the object is passed, not a reference. As with immutable objects, the changes exist only within the function and do not update the object outside the function. 

## Value Types and Immutable
Not all value types are immutable. A `struct` is a value type, but it may include functions to update the members of the struct. Therefore, it is a value type but mutable.

## Reference Types and Mutable
Not all reference types are mutable. A `String` is a reference type, but it is immutable. An custom object is a reference type, but it is immutable if all of its fields are private and there are no methods to update the fields.

## `ref` Keyword
Using the `ref` keyword, an object is passed by reference. Updates made to the object within the function update the object outside the function. The object must be initialized before passing it into the function. Updates are bidirectional - data may be passed in to the function, and updates are avaiable after the function runs.

## `out` Keyword
Using the `out` keyword, updates made to the object within the function update the object outside the function. The object must be initialized within the function. Updates are unidirectional - updates done within the function are avaialble outside the function. 

## Stack and Heap
Value types reside in the stack. Reference types reside in the heap. A pointer to a reference type resides in the stack. 

