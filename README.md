# Doodad

Doodad is an opinionated DDD and CQRS framework for .NET.

Work is based largely off of Microsoft's guide [Tackling Business Complexity in a Microservice with DDD and CQRS Patterns](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/) and patterns used in the [eShopOnContainers Ordering Service](https://github.com/dotnet-architecture/eShopOnContainers/tree/dev/src/Services/Ordering), with a little added flavour.

## Doodad

The DDD package contains the common base classes and interfaces referred to as the ['seedwork'](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces). This term is used because it's usually just a small set of classes and tends to be copied and pasted between projects, but in this case, the aim is to provide a more formal structure.

- **Entity**: An object defined by its identity.
- **IAggregateRoot**: The root object of an aggregate; a collection of objects treated as one unit.
- **IDomainEvent**: Something that happened that is of interest to domain experts.
- **ValueObject**: An immutable object defined by its values, without a concept of identity.
- **Enumeration**: A set of possible named values.
- **Singleton**: A unit type that only allows one value.
- **IRepository**: Retreives an aggregate from a storage.

```csharp
public class Person : Entity, IAggregateRoot
{
    public string Name { get; set; }
}
```

### Maths

ValueObjects can often be mathematical values. The package provides ways to remove boilerplate when implementing C# operators to add, subtract, multiply and divide these values.

- **IProduct**: A value derived from multiplying two factors.
- **IQuotient**: A value derived from dividing a dividend by a divisor.

```csharp
public class Force : ProductValueObject<Force, double, Mass, Acceleration>
{
    public Force(double value) : base(value) { }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
```

## Doodad.Cqrs

The CQRS package brings in a dependency on [MediatR](https://github.com/jbogard/MediatR) and defines interfaces to better separate commands and queries.

- **ICommand**: Changes the state of a system but does not return a value.
- **IQuery**: Returns results and does not change the state of the system.
- **IEvent**: Something that has happened in the system.

```csharp
public class DoTheThingCommandHandler : ICommandHandler<DoThingCommand>
{
    public Task<CommandResult> Handle(DoThingCommand command)
    {
    }
}
```

### Subscriber

MediatR notification handlers are their own classes, but sometimes we want a way to subscribe and unsubscribe at runtime.

- **IMediatorSubscriber**: Allows subscribing to an event at runtime.

```csharp
internal class WorkMonitor
{
    public WorkMonitor(IMediatorSubscriber subscriber)
    {
        subscriber.Subscribe<WorkDoneEvent>(HandleWorkDone);
    }

    private Task HandleWorkDone(WorkDoneEvent workDoneEvent)
    {
    }
}
```