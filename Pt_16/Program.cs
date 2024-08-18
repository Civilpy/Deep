/* 
 * Extension methods in C# allow us to add new methods
 * to existing types without modifying the original type
 * or creating a new derived type
 * 
 * 
 * 
 * The Requirement are:
 * - we need a static class
 * - we need a static method on the class
 * - we need the "this" keyword on the parameter that we are "extending"
 * - the Parameter marked with "this" must be the first parameter
 * 
 * 
 * Extended method in C# Are a special type of static method on a static class
 * so their requirement we need to be able for this to work are 
 * 
 * 
 */


// so the name we gave to that class , it doesnt really matter as
// long as we are not trying to call it this way :
var reversedStr = Extensions.Reverse("Hello, world");
// we can infact call it this way but like a static method on any static class 
// but if we are using it like an extension method 


// but when we call it like an extension method 
// we get this really cool syntax where it looks
// like a Reverse() is a method thats built
// into the string class!
var forwardStr = reversedStr.Reverse();

// this is where it looks really powerful for us
// bcuz it looks like we now added this Reverse Method directly on to the string
// this is the same method tho like above 


// there's a popular part of dotnet that uses extension methods
// called LINQ 

IEnumerable<int> numbers = new List<int> { 1,2,3,4,5 };

// nearly all of the methods we see in intellisense
// when accessing numbers are extension methods 
// from LINQ
var evenNUmbers =  numbers.Where(n => n % 2 == 0);

/*
 * The requirements are :
 *  - WeakReference need a static class 
 *  - we need a static method on the class
 *  - we need the "this" keyword  on the parameter that we are "extending"
 *  - The Parameter marked with "this" must be the first Parameter
 */
 // these are helpful for creating some helper fuction and you wanna be able 
 // to make the code read really nicely 



public static class Extensions
{
    public static string Reverse(
        this string str)
    {
        var reversedChars = str.Reverse<char>().ToArray();
        var reversed = new string(reversedChars);
        return reversed;
    }
}