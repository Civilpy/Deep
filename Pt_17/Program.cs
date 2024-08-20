/*
 * LINQ stands for language INtegrated Query
 * we get access to a bunch of LINQ methods in the System.Linq namespace
 *that operate on IEnumerable<T> => this means they have all of these static classes that take in this
 *                                  Ienumerable and we are able to write a method that essentioally looks 
 *                                  like its Adding new Functionality to Ienumerable 
 *They're all... extension methods!
 *
 *  LINQ Extension Method does bonch of different things for us 
 *  but Generally map these 3 Categories 
 *
 *LINQ can help us
 * - map : transform each item => transforming things as we looking through a set of items 
 *                                so going through each item in the IEnumerable and doing something with it 
 *                                
 * - filter: only take some items = which is going to be reducing what we are looking at when it comes to 
 *                                  operating on IEnumerbale 
 *                                  
 * - reduce: combine items => which is going to be going from IEnumerable to a calculated value at the End 
 * 
 * map: transform each element in a collection
 * 
 */

using System.Threading.Channels;

List<string> rawNumbers = ["1", "2", "3" , "4",  "5"]; // list implment IEnumerable 
List<int> numbers = new();
foreach(string rawNumber in rawNumbers)
{
    numbers.Add(int.Parse(rawNumber));
}
// The basi LINQ method for mapping is select:
 var number2 = rawNumbers.Select(number => int.Parse(number)).ToList();




// FIlter : remove elements from a colletion
List<int> evenNUmbers = new();
foreach(int number in numbers)
{
    if(number % 2 == 0)
    {
        evenNUmbers.Add(number);
    }
}

 // using LINQ we could do ...

var evenNumber2 = evenNUmbers.Where(x => x % 2 == 0).ToList();


// to do the reduction (average in this case) without using LINQ:
int sum = 0;

foreach (var number in numbers)
{
    sum += number;
}

double average = sum / (double)numbers.Count();

/*
 * There are many more LINQ methods
 * and we ca n chain then toghether to build
 * more complex pipelines!
 */

List<string> biggerListOfRawNumbers = [ "0", "9", "1", "8", "2", "7", "3", "6", "4", "5" ];
/*
 * here we are going to take this LINQ method and start chaining them together 
 * the reason we are able to do this is bcuz the methods from LINQ that are not just doing the reduction
 * they end up returning us another IEnumerable 
 * and bcuz IEnumerables comig back as the return type they are also available to 
 * be used in LINQ 
 * that means that we can call more LINQ method 
 */
var magicNumber = biggerListOfRawNumbers
    .Select(int.Parse) // convert everthing to int
    .OrderByDescending(number => number) // orders from the biggest to smallest number
    .TakeLast(5) // should only take 4, 3, 2, 1, 0
    .Where(number => number % 2 == 0) // should only take 4,2,0 (even number)
    .Average(); // should be 2
Console.WriteLine($"Magic numver is {magicNumber}");



// LAZY behaviour of the LINQ 
// LINQ is going to return IEnumerable , however IEnumrerable in this case is 
// goint to be backed by what called Eterators .... and what that means that each time
// you're calling these LINQ's method and it gives you an IEnumerable it has not
// been fully evaluated yet 
 

// LINQ methods are "Lazy" bcuz the are "iterators"
// they dont do anything untill you start enumerating them


Console.WriteLine("Press enter to start the lazy example.");
Console.ReadLine();
Console.WriteLine("Before the LINQ line for LazyNumbersAsStrings");
var lazyNnumberAsStrings = numbers
    .Select(number =>
    {
        Console.WriteLine($"Transforming {number} to a string");
        return number.ToString();
    });
Console.WriteLine("After the LINQ line for LAzyNumbersAsStringss");

// force enumeration

Console.WriteLine("Before forcing enumeration of LazyNumbersAsStrings.");
lazyNnumberAsStrings.ToArray();
Console.WriteLine("After forcing enumeration of LazyNumbersAsStrings");

/* when we execute this code we cant see the out put of lazyNumberAsStrings
 * being run
 * that means that actually did'nt executed 
 * this is an example of storing a function pointer and it's not obvious 
 * but iteratours are technically function pointer untill you go evaluate them 
 * 
 * it like a method and we assigning them to a variable  ... that means when we are going to do this 
 * there's no other code that's executing ...we have just taken a mthod and assign it to a variable  
 */



/*
 * an important thing to know ... when we are calling a LINQ method
 * maybe we are chaining a bunch of them together .. that could be doing alot of work
 * if you are assign it to a variable and you have not done anything with it 
 * that means that variable might still be a function Pointer ....it might have not 
 * yet evaluated anything in that point of that time 
 * 
 * 
 * if you dont call ToArray()....ToList()... or use a for Loop to go Iterate over those items 
 * that means u have not evaluated your LINQ methods yet 
 * 
 */


// this also means you need to be careful if your LINQ is expensive 
// and you keep re_evaluating it bcuz you did not store the result
// in a variable!

Console.WriteLine("Press enter to start expensive operation.");
Console.ReadLine ();

var expensiveToCalculaterr = numbers
    .Select(number =>
    {
        Console.WriteLine($"Transforming {number} to a string");
        Thread.Sleep(1000);
        return numbers.ToString();
    })
    .ToArray(); // vaghti in ro run mikonim ... in ba faseleye 1 saniye print mishe
                // va baghiyr be surate ye ja
                // hala ToArray ro bardar bebin chi mishe 

Console.WriteLine("Before first enumeration of expensive operation...");
foreach(var numberAsStringg in expensiveToCalculaterr)
{
    Console.WriteLine(numberAsStringg);
}
Console.WriteLine("After first enumeration of expensive operation...");

Console.WriteLine("Before Second enumeration of expensive operation...");
foreach (var numberAsStringg in expensiveToCalculaterr)
{
    Console.WriteLine(numberAsStringg);
}

/*
 * the reason that this happen bcuz on both foreach Line we 
 * have IEnumerable of strings and like we mentioned
 * LINQ is giving us what it calls Iterator 
 * this iterator is just a function pointer
 * and bcuz it's not been ivaluated it will go have to evaluated twice 
 * it's not saving the result anywhere 
 * unless you call something like ToArray...ToList or otherwise materialize 
 * the collection 
 */


// we can write our own LINQ Method bcuz theyre just Extension methods

var myLinqResult = numbers
    .FancyLinqMethod(number => number * 2)
    .ToArray();

foreach(var number in myLinqResult)
{
    Console.WriteLine(number);
}


public static class MyLinq
{
    public static IEnumerable<T> FancyLinqMethod<T>( // return type IEnumerable of T
        this IEnumerable<T> source, // takes in an Ienumerable of T 
        Func<T, T> selector) // takes a type T and out a type T
    {
        foreach(T item in source)
        {
            Console.WriteLine($"Applying selector to {item}");
            yield return selector(item);
        }
    }
}



