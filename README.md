CommandQuery
============

Simple Demo of Command/Query pattern in a WebAPI solution.

Most of the hard work in the design of this demo is inspired from [DotNetJunkies](https://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=91/) [articles](https://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=92) on the subject.

If you are looking for something more comprehensive you should check out [Parramore](https://github.com/iancooper/Paramore)

Features under development 
---------------------------

* Async command dispatch
* Service Bus integration
* Azure storage for Auditing

For Consideration
-----------------

* SignalR + service bus backplane for domain event notifications


Key Concepts
============

Extensive use of decorators to apply...

* Declarative Validation using DataAnnotations
* Auditing
* Deadlock retry handler

