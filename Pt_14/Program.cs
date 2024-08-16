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
    data, // a set of bytes 
    0, // offset => where to start 
    data.Length); // how many to go 

Console.WriteLine($"Stream Position Before: {ms.Position}");
Console.WriteLine($"Stream Length Before: {ms.Length}");
Console.WriteLine($"Stream Capacity Before: {ms.Capacity}");
Console.WriteLine();



/*
 * if we wanted to read the data back out of the stream,
 * it's important to note the position we're currently in now
 * 
 * let's get back to the start using "Seek", which allows
 * us to specify where we're seeking relative to
 * 
 */


/*
 * what we want to do is start at the original position and 
 * that's bcuz az we wrote data in that memory stream 
 * like we saw where we pointing to is at the end of the data that we wrote 
 * but if we want to read that data back we need to be able to 
 * move that position all the way to the begining so theres a couple of diffrenet ways 
 * to do that ... memory stream has a Method calls   Seek   
 */
Console.WriteLine("Repositioning memory stream...");
ms.Seek(0, SeekOrigin.Begin); // as we providing here 0 for the offset and
                              // seek from the beginign of the stream go over zero 
                              // when this code runs we go back to the begining of the stream 
                              // and its the same Stream that we wrote data into  

//or

ms.Position = 0;
Console.WriteLine($"Stream position After : {ms.Position}");


/*
 * now we can read out data back out!
 * ... but how much data do we need to read?
 * .. where are we putting it?
 * 
 */

/*
 * so if we want to go read some stuff out of here..how do we know 
 * how many data do we have to read and when we go to read that data 
 * like, where is it going , whats the result of getting that data out
 * do have to give it a container to go put that data into  =====> the answer is the second one , we need to be able to
 *                                                                 create a byte array , so another Buffer that we can go 
 *                                                                 read that data into 
 *                                                                 
 *                                                                 
 *                                                                 imagine like this: we have a stream and that's going to be 
 *                                                                 pointing at some data that we just wrote to the Stream , 
 *                                                                 it has its own Arraay, now when we're going to read data back out
 *                                                                 we need to be able to say, where did that data go 
 *                                                                 so we essentioally making a copy of some data back out of the stream and 
 *                                                                 bcuz we're copying data back out we need somewhere to put it we
 *                                                                 dont have our own spot to go keep that data yet 
 *                                                                 
 */



byte[] readBuffer = new byte[ms.Length];
Console.WriteLine("Reading data from memory stream ...");
int numberOfBytesRead = ms.Read(
    readBuffer, // here we give it a buffer ... this buffer can be
                // bigger than what we want to read out but it should
                // not be smaller or else we're going to have an issue 
                // so if we want to read 1000 bytes of something 
                // and u only had a 10 byte buffer that's not gonna work how u might except 
    0, // position 
    readBuffer.Length ); // length

Console.WriteLine($"Number of bytes read: {numberOfBytesRead}");

string readString = Encoding.UTF8.GetString( readBuffer );
Console.WriteLine($"Read string: {readString}");
Console.WriteLine();


// also important to note that MemoryStream
// has a little "shortcut" for getting the bytes:

Console.WriteLine("Reading data from memory Stream using ToArray()...");
byte[] memoryStreamBytes =  ms.ToArray();
readString = Encoding.UTF8.GetString( memoryStreamBytes );
Console.WriteLine($"Read String: {readString}");




