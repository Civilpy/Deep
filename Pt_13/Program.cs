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


string unsupportedAsciiString = "😊 im in Danger!"; // in C# when we are declaring strings and they're being used this is treated as something that is not ASCII //😊 im in Danger!
byte[] unsupportedAsciiBytes = Encoding.ASCII.GetBytes(unsupportedAsciiString); // when we done the conversion back and forth this one has ?? marks ==> ?? im ....
string convertedBackFromUnsupportedAscii = Encoding.ASCII.GetString(unsupportedAsciiBytes);
Console.WriteLine("Converting to ASCII and back with unsupported characters");
Console.WriteLine($"Original: {unsupportedAsciiString}");// => ?? im ....
Console.WriteLine($"Converted: {convertedBackFromUnsupportedAscii}");// => ?? im ....
Console.WriteLine($"Original string length: {unsupportedAsciiString.Length}"); //17
Console.WriteLine($"Converted string length: {convertedBackFromUnsupportedAscii.Length}");//17
Console.WriteLine($"      ASCII Bytes length: {unsupportedAsciiString.Length}");//17
Console.WriteLine($"String Equal: {unsupportedAsciiString == convertedBackFromUnsupportedAscii}");//false
Console.WriteLine($"First Char Equals: {unsupportedAsciiString[0] == convertedBackFromUnsupportedAscii[0]}");//false
Console.WriteLine();






// to handle this, we can use "Unicode", which is a standard
// that defines a much larger character set
// and we'll use UTF-8, which is a way to encode Unicode characters
// to make this example works

byte[] unsupportedStringAsUtf8Bytes = Encoding.UTF8.GetBytes(unsupportedAsciiString);
string unsupportedStringAsUtf8 = Encoding.UTF8.GetString(unsupportedStringAsUtf8Bytes);
Console.WriteLine("Converting to UTF-8 and back with unsupported characters");
Console.WriteLine($"Original: {unsupportedAsciiString}");
Console.WriteLine($"Converted: {unsupportedStringAsUtf8}");
Console.WriteLine($"Original string length: {unsupportedAsciiString.Length}"); //17
Console.WriteLine($"Converted string length: {unsupportedStringAsUtf8.Length}");//17
Console.WriteLine($"ASCII Bytes length: {unsupportedAsciiBytes.Length}");//17
Console.WriteLine($"UTF8 Bytes length: {unsupportedStringAsUtf8Bytes.Length}");//19
Console.WriteLine($"String Equal: {unsupportedAsciiString == unsupportedStringAsUtf8}");//false
Console.WriteLine($"First Char Equals: {unsupportedAsciiString[0] == unsupportedStringAsUtf8[0]}");//false
Console.WriteLine();




