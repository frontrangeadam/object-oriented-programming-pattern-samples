# The Builder Pattern

The main strength of the builder pattern is its ability to guarantee the creation of an object in a valid state. No `NullReferenceException`s. 

Wherever the builder is invoked, the developer is guided at author time, in order, through the steps of building a complete object.

(I was originally introduced to this pattern, and many of the principles repeated here, through Zoran Horvat's article [Advances in Applying the Builder Design Pattern](http://codinghelmet.com/articles/advances-in-applying-the-builder-design-pattern), and his course, [Making Your C# Code More Object-oriented](https://www.pluralsight.com/courses/c-sharp-code-more-object-oriented).)

## Avoid This (Outside the Builder Pattern)

The object construction approach we want to avoid is something like this:

```csharp
var truck = new PickupTruck
{
    Engine = engine,
    Transmission = transmission,
    PackageType = pkgType
}
```

The code above looks fine, which is the problem.

At author time, we don't know if there are any other properties that must be assigned. If at runtime, other code tries to read the `PackageType` property of the `PickupTruck` instance, a `NullReferenceException` will result.

```csharp
var pkg = truck.PackageType;   // cue the NullReferenceException
```

Admittedly, object initialization may have to be used in some cases (ex., custom JSON serializers, legacy ORM LINQ-to-SQL, etc.) where we can't make the parameterless constructor and property setters private. 

When authoring a class, it's best to enforce property assignment through the constructor.

## Assign All Required Properties through the Constructor

We want to ensure that all instances of the class we've authored are created as valid objects. There should be no possibility of a "partially" constructed object. *Specifically, it should fail to compile before it has a chance to fail at runtime.*

Consider this example:

```csharp
public PickupTruck(
    TruckEngine engine,
    TrimType trim,
    Transmission transmission,
    PackageType packageType)
{
    if (engine == null)
        throw new ArgumentNullException(nameof(engine));

    if (trim == null)
        throw new ArgumentNullException(nameof(trim));

    if (transmission == null)
        throw new ArgumentNullException(nameof(transmission));

    if (packageType == null)
        throw new ArgumentNullException(nameof(packageType));

    Engine = engine;
    Trim = trim;
    Transmission = transmission;
    PackageType = packageType;
}
```

Values for all required properties are fed to the constuctor and initialized if not null. This requires the caller to supply arguments at object creation, so that all properties needed by relying code will be available later.

## Use `get`-only Auto-implemented Properties

Secondly, the class should use `get`-only properties, which requires that they are set within the constructor, not by object initialization syntax. (Private setters are also acceptable and often necessary, but the setter shouldn't be public if it can be avoided.)

```csharp
public class PickupTruck
{
	public TruckEngine Engine { get; }
}
```


