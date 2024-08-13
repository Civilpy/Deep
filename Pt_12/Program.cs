// Tuples are a lightweight data transfer object
// that can contain multiple values of different types


// Tuples in C# come in 2 different flavors:
/*
 * 1 - System.Tuple:
 *      - reference Type
 *      - immutable
 *      - values are properties
 * 2 - System.ValueTuple: a value type
 *   - value type
 *   - mutable
 *   - values are fileds
 * 
 */



Tuple<int, string> tuple = new Tuple<int, string>(1, "one");

// System.ValueTuple

ValueTuple<int, string> valueTuple = new ValueTuple<int, string>(1, string.Empty);
ValueTuple<int, string> valueTuple2 = new(1, "one");
ValueTuple<int, string> valueTuple3 = (1, "one0");


var valueTuple4 = (1, 2, 3, 4, 5, 6, 7, 8, 9); // ... and so on 




/*
 * we have generics in both cases
 * the type  parameters are for each of the items the tuple will hold
 * we know we have reference vs value types here
 * 
 * ValueTuple can take in an arbitrary numver of elements
 */


// where and why we use tuples ???

/*
 * tuples are useful for things like:
 * returning multiple values from a method
 * passing multiple values to a method
 * grouping multiple values together
 * ... all without having to go make adedicated class!
 * 
 * how would we reruen a min AND max from a method before tuple?
 * use out parameters
 * use a custom return type
 */


int GetMinAndMaxWithOutParam(int[] numbers, out int max)
{
    if (numbers.Length == 0)
    {
        throw new ArgumentException(
            "cant find min and max of an empty array");
    }
    int min = numbers[0];
    max = numbers[0];
    for(int i = 1; i < numbers.Length; i++)
    {
        if(numbers[i] < min)
        {
            min = numbers[i];
        }
        if (numbers[i] > max)
        {
            max = numbers[i];
        };
    }
    return min;
}

// this is pretty bad
int[] numbers = { 1, 2, 3, 4, 5, 6 };
int min = GetMinAndMaxWithOutParam(numbers, out int max);
//a way to fix this is to have a custom type




// in every situation where we have a couple of things we want to return 
// we have to go declare a new typle to be able to do that 

(int, int) GetMinAndMaxWithParam(int[] numbers)
{
    if (numbers.Length == 0)
    {
        throw new ArgumentException(
            "cant find min and max of an empty array");
    }
    int min = numbers[0];
   int  max = numbers[0];
    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] < min)
        {
            min = numbers[i];
        }
        if (numbers[i] > max)
        {
            max = numbers[i];
        };
    }
    return (min, max);
}



Console.WriteLine("Min and Max with Tuple: ");
var minAndMaxTuple = GetMinAndMaxWithOutParam(numbers);
Console.WriteLine($"Min: {minAndMaxTuple.item1}, Max{minAndMaxTuple.item2}");
Console.WriteLine($"The whole Tuple: {minAndMaxTuple}");



// we can do Even better with named Tuple!

(int Min, int Max) GetMinAndMaxWithParamBetter(int[] numbers)
{
    if (numbers.Length == 0)
    {
        throw new ArgumentException(
            "cant find min and max of an empty array");
    }
    int min = numbers[0];
    int max = numbers[0];
    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] < min)
        {
            min = numbers[i];
        }
        if (numbers[i] > max)
        {
            max = numbers[i];
        };
    }
    return (min, max);
}

Console.WriteLine("Min and Max with Tuple: ");
var minAndMaxTuple1 = GetMinAndMaxWithParamBetter(numbers);
Console.WriteLine($"Min: {minAndMaxTuple1.Min}, Max{minAndMaxTuple1.Max}");
Console.WriteLine($"The whole Tuple: {minAndMaxTuple1}");



// we can also "deconstruct" tuples
(int firstThing, string secondThing) = (1, "this is the second thing!");

// we can put the keyword var out the front
// this way to infer the type at compile time

var (firstThing2, secondThing1) = (1, "this is the second thing");






