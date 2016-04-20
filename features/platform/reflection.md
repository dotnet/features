# Reflection

"Mirror, mirror, on the wall. Which members of this object can I call?"

Reflection is one of the more dynamic features of .NET. It enables many key
scenarios that would not be possible without it. There are two main aspects of
and APIs for Reflection: inspection and invocation. Inspection (sometimes called
introspection) enables a program to ask questions about  parts of or extensions
to a program. The most typical questions are about asking whether a given class
implements a certain interface or base class.

Invocation enables a program to call methods that it has found via the
inspection APIs. They can also be used to interact with running code, to
determine the value of a property or field. It is very common to use the
invocation APIs to instantiate a class. A program can call arbitrary methods on
the class, also by using the Reflection invocation APIs, or by casting to a
concrete type that the instance supports.

Reflection.Emit is a separate API that enables a program to generate code at
runtime. It is an analog to the JavaScript "eval" keyword. The Reflection.Emit
takes MSIL byte code as input, not C# or other high-level .NET languages. The
API generates machine code from the input byte code, similarly to if it was read
from a .NET DLL file.
