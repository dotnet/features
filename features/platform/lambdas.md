# Lambdas

A lambda expression is an anonymous function that can contain expressions and
statements, and can be used to create delegates or expression tree types.

All lambda expressions use the lambda operator `=>`, which is read as *goes to*.
The left side of the lambda operator specifies the input parameters (if any) and
the right side holds the expression or statement block. The lambda expression
`x => x * x` is read *x goes to x times x*.

The `=>` operator has the same precedence as assignment (`=`) and is right-
associative.

Lambdas are used in method-based LINQ queries as arguments to standard query
operator methods such as Where.

When you use method-based syntax to call the Where method in the Enumerable
class (as you do in LINQ to Objects and LINQ to XML) the parameter is a delegate
type `System.Func<T, TResult>`. A lambda expression is the most convenient way
to create that delegate. When you call the same method in, for example, the
System.Linq.Queryable class (as you do in LINQ to SQL) then the parameter type
is an `System.Linq.Expressions.Expression<Func>` where Func is any Func
delegates with up to sixteen input parameters. Again, a lambda expression is
just a very concise way to construct that expression tree. The lambdas allow the
Where calls to look similar although in fact the type of object created from the
lambda is different.

A lambda expression with an expression on the right side is called an expression
lambda. Expression lambdas are used extensively in the construction of
Expression Trees. A statement lambda resembles an expression lambda except that
the statement(s) is enclosed in braces like this:
`(input parameters) => {statement;}`. Statement lambdas, like anonymous methods,
cannot be used to create expression trees.

When writing lambdas, you often do not have to specify a type for the input
parameters because the compiler can infer the type based on the lambda body, the
underlying delegate type, and other factors as described in the C# Language
Specification. For most of the standard query operators, the first input is the
type of the elements in the source sequence.
