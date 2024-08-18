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