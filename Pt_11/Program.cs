

// generics are used to create things with a placeholder for the type
// this implies that the generic does not care about type
// or care onlyabout the type in a limited way
// we can use generics on classes, interfaces, method, etc...

// we can use generics to define an interface with a type parameter T


GenericClass<int> myNumericInstance = new GenericClass<int>();

GenericClass<string> myStringInstance = new GenericClass<string>();

//GenericClass instanceWithoutType = new GenericClass(); // this will not compile !!

// we could also make an implementation that specifies the type

ImplementationWithIntegerType implementationWithIntegerType = new();
// type class ro mitunim injuri ham bznim 




ClassWithGenericMethod instanceOfClassWithGGenericMethod = new();

instanceOfClassWithGGenericMethod.GenericMethod("This is a string");
instanceOfClassWithGGenericMethod.GenericMethod(42);
instanceOfClassWithGGenericMethod.GenericMethod(3.14);



int genericFunctionResult = instanceOfClassWithGGenericMethod.GenericFunction(42);



// where have we seen generics so far?

List<int> numericList = new List<int>();

List<string> stringList = new List<string>();



// this is becuz the algorithmand data structures for many
// collections simplyy do not care about the type





public class ImplementationWithIntegerType : IGenericInterface<int>
{
    // Note : the class itself also
}



// we can also use generics to define methods

public class ClassWithGenericMethod
{
    public void GenericMethod<T>(T value)
    {
        Console.WriteLine(
            $"The type of the value is {value.GetType().Name}" +
            $"and the value is {value}");
    }

    public T GenericFunction<T>(T value) // T inja return type hastesh 
    {
        Console.WriteLine(
            $"The type of the value is {value.GetType().Name}" +
            $"and the value is {value}");
        return value;
    }
}






// GenericClass


public interface IGenericInterface<T>
{
    // no methods...
}

// we can make a class that implements this interface:

public class GenericClass<T> : IGenericInterface<T>
{
    // Note : the class itself also needs to have a type parameter on it
    // to allow caller creating instances of this class to specify the type
}

