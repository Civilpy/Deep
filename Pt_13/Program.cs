/*
 * its really common to that we have to go working with strings and binary data
 * but theres some challenges that come up when we try to do this and thats bcuz bytes dont necessary
 * map one to one with charectors inside of the strings we have a lot of tools to work around this 
*/




/*
 * strings in C# represent a sequence of characters 
 * but when it comes to sending data, computers
 * work with binary data
 * 
 * 
 * 
 * this means that we need to be able to convert between 
 * strings and binary data, and we can do tahat
 * by mapping characters to/from their binary representation!
 * 
 * 
 * the concept of an "encoding" is a way to map characters.
 * the basic one that we'll start with is called ASCII
 * - ASCII only has 128 characters that it supports
 * - this is largely bcuz of history ... 1963!!!
 * - This was enough for English characters, numbers, and some punctuation
 * 
 * we can get the bytes fo astring as ASCII encoded
 */




using System.Text;

string helloWorld = "Hello World!";
byte[] byteForHelloWolrdAsAscii = Encoding.ASCII.GetBytes(helloWorld);

// we can go backwards too!

string helloWorldConvertedBack = Encoding.ASCII.GetString(byteForHelloWolrdAsAscii);


Console.WriteLine($"Converting '{helloWorld}' to byte and back with ASCII");
Console.WriteLine($"Original: {helloWorld}");
Console.WriteLine($"Converted: {helloWorldConvertedBack}");
Console.WriteLine();


//what happens if we use characters in the string
// that aren't in the ASCII character set? 


string unsupportedAsciiString = "im in Danger!";
byte[] unsupportedAsciiBytes = Encoding.ASCII.GetBytes(unsupportedAsciiString);
string convertedBackFromUnsupportedAscii






