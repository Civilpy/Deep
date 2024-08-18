// we can read and write files using built-in classes in C#

// there are many convenience methods that we have access to :

using System.Text;

File.WriteAllText(
    "some-file.txt",
    "hello, wolrd!");
File.WriteAllBytes(
    "some-file.txt",
    Encoding.UTF8.GetBytes("Hello, wolrd from Amir bbb"));
byte[] someFileBytes = File.ReadAllBytes("some-file.txt");
string someFileString  = File.ReadAllText("some-file.txt");

// we can use similar methods to gain access to a stream !

FileStream fileStream = File.Open(
    "some-file.txt",
    FileMode.OpenOrCreate,
    FileAccess.Write,
    FileShare.Read);

byte[] buffer = Encoding.UTF8.GetBytes("Hello, world!");
fileStream.Write(buffer, 0, buffer.Length);



// but these are  the APIs directly on the Stream class!

Stream fileStreamAsStream = fileStream;
fileStreamAsStream.Seek(0, SeekOrigin.Begin);
fileStreamAsStream.Write(buffer, 0, buffer.Length);

// waht do we do when we're all done?
fileStream.Close();
//... but we'll cover a more detailed way to do this properly. 



// we can use a very similar API for reading from a file:

FileStream readingStream = File.Open(
    "some-file.txt",  
    FileMode.Open,
    FileAccess.Read,
    FileShare.None);// prevent people to get access to it 

//... but how many bytes do we need if we just want .. all of it?
// we *could* use the length of the stream...

byte[] bufferForReading = new byte[readingStream.Length];
var bytesReadFromStream = readingStream.Read(
    bufferForReading,
    0,
    bufferForReading.Length);

/*
 * if we're dealing with big files or files we dont know the size this could be 
 * and incredible dangrous....but its the same dangrous if we scroll back up 
its the same dangrous with this code :

                    byte[] someFileBytes = File.ReadAllBytes("some-file.txt");
                    string someFileString  = File.ReadAllText("some-file.txt");
 
 if we try to open a 10 GB File and read all the bytes and all of the Strings data
into the memory we propbably not gonna have a great time 

so always remember that if we want to do this kind of things you really wanna make sure 
to be aware how big that file could be ... bcuz if it's too big we gonna run into some issues


Code above is for when we know the file size is Safe 

if we didnt know how big that file could be or you were'nt sure how much you needed 
to read but you were pretty sure it wasn't going to be the whole size of the file 
this is a solution that can work if youre reading a text file 

*/



// what if the file was huge or didn't know
// excatly how much we needed to read in,
// if not the whole file?
// if we were interested in reading a text file:
readingStream.Seek(0, SeekOrigin.Begin); // here we put the stream back to the begining 
StreamReader reader = new StreamReader( // Stream reader is going to give us a different API
                                        // around the Stream and recall the Stream is really helpfull
                                        // for working with the bytes .. and Stream reader is going to
                                        // give us like a stream Interface to working with the Stream 
                                        // aand that gonna allow us to do (especially if we want to read this file
                                        // line by line ) we can have a WHILE LOOP that says while we are not at the end
                                        // of the stream let's keep trying to read lines and we can go print them out to the console
                                        // and this is just one variation we could do with the Reader
                                        // whats nice about this implementation is that this one does not Force to bring the whole 
                                        // file into the memory ...if we have a really really long line of text in our file 
                                        // perhaps we gonna have an issue...
    readingStream,
    encoding: Encoding.UTF8);
while(!reader.EndOfStream)
{
    string line = reader.ReadLine();
    Console.WriteLine(line);
}


// a more general way to handle all of this .. lets say u are not even dealing with 
// Strings in file, you just dealing with binary data , some Struct Data 
// what we can do is go ask that Stream to read what we call a chunks of Data and the way 
// that works is that we create a Read Buffer , will give it a size of we are comfortable 
//To work with , what we are able to do is Read in Buffer or part of the Buffer 
// and keep trying to see if we have more to go

/*
 * you could also write your program to read blocks
 *of bytes from the Stream at a time by "chunking"
 * it up and determining when you've read
 *enough
 */

int chunkSize = 7;
Console.WriteLine($"Reading chunk of size {chunkSize} of file...");
readingStream.Seek(0, SeekOrigin.Begin);
byte[] bufferForChunking = new byte[chunkSize];
while((bytesReadFromStream = readingStream.Read(
    bufferForChunking,
    0,
    bufferForChunking.Length)) > 0)
{
    Console.WriteLine($"Read {bytesReadFromStream} bytes for this chunk!");
}

