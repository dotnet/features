# Generics

Generics are a major addition to the original .NET type system. They enable
classes, structures, interfaces, and methods to have placeholders (type
parameters) for one or more of the types that they store or use. Generic types
are said to be *open* since their signature is not fully *closed*. This
capapability reduces the number of types that need to be created, since a given
type can be instantiated in a potentally large number of combinations.

The generic collections in the .NET Framework are typically most developers
first experience with generics. List<T> and Dictionary<K,V> are the most common
collections that developers user. A generic collection class uses a type
parameter as a placeholder for the type of objects that it stores and operates
on. The type parameters appear as the types of its fields and the parameter
types of its methods. A generic method might use its type parameter as the type
of its return value or as the type of one of its input parameters.

When you create an instance of a generic class, you specify the actual types to
substitute for the type parameters. This establishes a new generic class,
referred to as a constructed generic class, with your chosen types substituted
everywhere that the type parameters appear. The result is a type-safe class that
is tailored to your choice of types.

Generics have to some degree "taken over". Most new .NET APIs make sigificant
use of generics to model their domain area.  It is recommended that you do this
as well.
