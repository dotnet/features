# Dynamic

Static compile-time type checking is skipped when using a dynamic type. It makes
the assumption that any operation is supported. It will then be resolved at run
time. The dynamic type simplifies access to COM APIs such as the Office
Automation APIs, and also to dynamic APIs such as IronPython libraries, and to
the HTML Document Object Model (DOM).
