/*
 * Streams in C# allow  us to work with data
 * in a more abstract way than just having 
 * a byte array.
 * (so we sont have think about the implementation 
 * of whats backing from the Stream. so it does not matter to 
 * us if its a byte array or if its something coming from the network
 * if its a file ... it could be anything ..it doesnt matter if the consumer
 * of the Stream API, all we know is we have A stream API to work with
 * 
 * Stream allows us to navigate through a set of bytes and depending on the 
 * type of the Stream certain operation are not allowed 
 * )
 * Streams provide us a common API for working
 * with binary data without having to know 
 * exactly how that data is represented
 * behind the scenes!
 * 
 * 
 * Remember inheritance ? there is a base class
 * for all streams called Stream, which is abstract.
 * Stream stream = new Stream(); // won't cpmpile!
 *  
 * 
 * Streams provide  information about the data source 
 * that wee're working with, like:
 * - the length of the data
 * - the current position in the data
 * - wheter we can read from or write to the data
 * 
 * Its important to note that all Streams get 
 * these Properties/methods bcuz they inherit
 * from the base... but not all of them support
 * all of the fuctionality!
 * 
 * 
 * let's start with one of the most basic streams,
 * the MemoryStream
 * 
 */


using System.Text;

MemoryStream ms = new MemoryStream();

// we can write a data to a memory stream

Console.WriteLine("writing data to memory stream...");
Console.WriteLine($"Stream Position Before: {ms.Position}"); // position means where we pointing at with end of set of bytes that
                                                             // Stream is representing starting at zero at the very begining
                                                             // and whatever position that we happen to be at after reading 
                                                             // so as we read through Stream , that position changes  
                                                             // if we have 5 bytes  of an array that would mean the length of the memory Stream 
                                                             // is going to be 5


Console.WriteLine($"Stream Length Before: {ms.Length}");     // Capacity is going to be something on the memory string that tells
                                                             // us how much Capacity in the Array that we are using exist 

Console.WriteLine($"Stream Capacity Before: {ms.Capacity}");// its different from length its bcuz theres an optimization of a place that 
                                                            // we dont want to have the capacity alwaya excatly Equal to length ,
                                                            // bcuz if we need to change the size of the Array behind the secne to get more data , the capacity of that Array can change thats up to the implmentation of the memory Stream to manage for us 


byte[] data = Encoding.UTF8.GetBytes("Hello, world, From CivilPy");
ms.Write(
    data,
    0,
    data.Length);

Console.WriteLine($"Stream Position Before: {ms.Position}");
Console.WriteLine($"Stream Length Before: {ms.Length}");
Console.WriteLine($"Stream Capacity Before: {ms.Capacity}");
Console.WriteLine();

