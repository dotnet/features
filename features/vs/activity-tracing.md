# Activity Tracing

Activity Tracing enables vendors of application performance monitoring (APM)
solutions to provide request-centric performance data for a service app, even as
asynchronous programming models are adopted more widely by app developers

The feature implements the concept of Activity IDs in the EventSource class and
.NET framework Task Library. This allows APM tools to provide unified views of
all processing associated with specific requests and it ensures that existing
libraries using the .NET task library will successfully participate in activity
tracing.

Additionally, it guarantees that managed developers who write custom work
scheduling libraries can preserve the activity "flow" at the points where the
logical workflow hops threads.
