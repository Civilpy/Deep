global using NicksColor = (byte R, byte G, byte B);
// we can use this syntax to declare a Tuple 

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
(int minVal, int maxVal) = GetMinAndMaxWithParamBetter(numbers);


// we can put the keyword var out the front
// this way to infer the type at compile time

var (firstThing2, secondThing1) = (1, "this is the second thing");



NicksColor nicksColor = (255, 0, 0);

nicksColor.R = 125;



// EQUALITY

(int, string, int) tupleA = (123, "hello", 456);
(int, int) tupleB = (123, 456);
(float, float) tupleC = (firstNumber: 123, secondNumber: 456);
(byte, string, float) tupleD = (firsNumber: 123, Name: "hello", SecondNumber: 456);
(int, int) tupleE = (456, 789);
(byte, string, float) tupleF = (123, "wolrd", 456);
(string, string) tupleG = ("hello", "wolrd");



/*
 * will not compile!
 * need to have same number of elements and compile types
 * cw($"tupleA == tupleB : " {tupleA == tupleB}) // different counts
 * cw($"tupleA == tupleC : " {tupleA == tupleC}) // different counts
 * cw($"tupleB == tupleG : " {tupleB == tupleG}) // same counts, incompatible types ,,,,, cant compare int to string ditectly
 */

Console.WriteLine($"tupleA == tupleD : {tupleA == tupleD}");// true : bcuz their values are in fact comparable, doesnt matter if their type is diffe
                                                            // if their types are different ..bcuz their types are comparable 
                                                            // a byte can be compare to an int and a float can be compared to an int 

Console.WriteLine($"tupleA == tupleF : {tupleA == tupleF}");// false
Console.WriteLine($"tupleB == tupleC : {tupleB == tupleC}");// true
Console.WriteLine($"tupleB == tupleE : {tupleB == tupleE}");// false

// tupleD and tupleC have Names ..we are able to compare the tuples with other tuples that have names and they ended up coming out to be true 
// just bcuz their values are the same ..... so names are completly disregarded when comparing to Tuple 

// the .Equal method is not supported for this kind of comparison
// ... all false!

Console.WriteLine($"tupleA.Equals(tupleD) : {tupleA.Equals(tupleD)}");
Console.WriteLine($"tupleB.Equals(tupleC) : {tupleB.Equals(tupleC)}");
Console.WriteLine($"tupleA.Equals(tupleF) : {tupleA.Equals(tupleF)}");
Console.WriteLine($"tupleB.Equals(tupleE) : {tupleB.Equals(tupleE)}");





/*
 * some interesting notes:
 * - cardinality is required to compile (same number of elements & compatible types)
 * - the names of the elements are not considered in the comparison 
 * - the order of the elements IS considered in the comparison
 * - the types do not need to be the same, but they do need to be comptible 
 */