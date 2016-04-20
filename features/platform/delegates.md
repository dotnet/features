# Delegates

A delegate is a type-safe method or function pointer. It is defined with a
particular signature such that it can only reference methods that satisfy that
signature. A delegate object can  reference either a static method or an
instance method and the object to call the method on.  Delegates are used to
implement callbacks and event listeners. They are often used to enable a program
to better model the real flow of execution. They can provide an illusion of
dynamism, however they are completely static in nature.

In later version of .NET, Action, Func and lambdas were introduced, which build
on top of the delegate infastructure. Action and Func are pre-defined delegates
with specific signatures.
