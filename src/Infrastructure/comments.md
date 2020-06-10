# Infraestructure or Framework layer #

It contains code that your application uses but it is not actually your 
application. This is often literally your framework, but can also include 
any third-party libraries, SDKs or other code used.

Another example is an event dispatcher. Inside the Framework Layer might 
be code to implement an event dispatcher interface defined in the application 
layer. Again, the application knows it has events to dispatch, but it 
doesn't necessarily need to have its own dispatcher - our framework likely 
already has one, or we might pull in a library to handle the implementation 
details of dispatch events.

The Framework Layer also adapts requests from the outside to our 
Application Layer. For example, it's responsible for accepting HTTP requests, 
gathering user input and routing this request/data to a controller. 
The Framework Layer can then call an application use-case, pass it the 
input data, and have the application handle the use case (rather than 
handling it itself inside of a controller).