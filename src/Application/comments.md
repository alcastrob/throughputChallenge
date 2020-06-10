# Application layer #

This is the middle layer.

This layer orchestrates the use of the entities found in the Domain Layer. 
It also adapts requests from the Framework Layer to the Domain Layer by 
sitting between the two.

For example, it might have a handler class handle a use-case. This handler 
class in the Application Layer would accept input data brought in from the 
Framework Layer and perform the actions needed to accomplish the use-case.

It might also dispatch Domain Events raised in the Domain Layer.

This layer represents the outside layer of the code that makes up the application.