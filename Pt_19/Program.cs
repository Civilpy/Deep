/*
 * Lazy<T> is a generic type that we have in C#
 * that allows us to defer the creation of a value.
 * it also acts like a singleton, without being
 * global. it's a thread-safe way to create a value
 * only when it's needed.
 *
 *
 *what we are able to do with lazy class is passed in a method or
 *delegate and that delgate is run at some point in the future when we
 *ask the instance of the lazy object that we created or its value 
 *great part is we do that once at some point in the future and the 
 *next time when we ask for that value we just get the same copy of it 
 *we dont have to go read or run the method so we essentially only run this method once 
 *ever 
 * 
 */


Lazy<int> lazyValue = new Lazy<int>(() => // anonnimous 
{
    Console.WriteLine("This will only run once.");
    Console.WriteLine("finding the max...");

    int[] numbers = [35, 20, 30, 40, 50];

    int max = int.MinValue;
    foreach (var number in numbers)
    {
        if (number > max)
        {
            max = number;
            break;
        }

        // pretend this is an expensive operation
        Thread.Sleep(1000);
    }

    Console.WriteLine("the max value is : " + max);
    return max;
});

Console.WriteLine("The value of LazyValue is: " + lazyValue.Value);
// took 5 seconds 

// after first time it just print instaintly 
Console.WriteLine("The value of LazyValue is: " + lazyValue.Value);
Console.WriteLine("The value of LazyValue is: " + lazyValue.Value);
Console.WriteLine("The value of LazyValue is: " + lazyValue.Value);
Console.WriteLine("The value of LazyValue is: " + lazyValue.Value);
Console.WriteLine("The value of LazyValue is: " + lazyValue.Value);





