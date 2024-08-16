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