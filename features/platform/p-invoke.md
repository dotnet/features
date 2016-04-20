# P/Invoke

"Platform invoke" or P/Invoke is a runtime-provided service that enables managed
code to call native functions that are in dlls, including Win32 APIs. It locates
and invokes an exported function and marshals its arguments. To call a method
that is exported from a dll, it must be marked with DllImport. Default or custom
marshaling can be used.

For every .NET Framework type there is a default native type, which the common
language runtime will use to marshal data across the managed/unmanaged boundary,
to satisfy a function call. For example, the default marshaling for C# string
values is to the type LPTSTR (pointer to TCHAR char buffer). You can override
the default marshaling using the MarshalAs attribute in the  declaration of the
native function. Callback methods can also be registered. To register a managed
callback that calls a native function, declare a delegate with the same argument
list and pass an instance of it via P/Invoke. .NET delegates appear to native
code as function pointers.
