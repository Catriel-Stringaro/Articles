If you are asking yourself why submission API and not submission infrastructure, it's because we don't
have any infrastructure and if we had one, it would have been only to register different modules or
third parties.

It wouldn't have any kind of code.
However, we've decided to separate the persistence layer from the infrastructure, basically because
more than 90% of the infrastructure layer is the persistence layer and is not practical to have an infrastructure
layer only for the registration of other modules or third parties.