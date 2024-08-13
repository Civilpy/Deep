// what if we dont want our class to have methods
// that everyone can use?
// what if we want to limit it?
// ... protected 

DerivedCalss derivedCalss = new DerivedCalss();

derivedCalss.PrintInDerivedClass();
derivedCalss.ProtectedPrintOutBaseClass(); // dastresi nadarim 


// we can also use the virtual keyword to give us
// a hybrid between abstract and non-abstract.
// ===>


class BaseClass
{
    protected void PrintInBaseClass()
    {
        Console.WriteLine("PrintInBaseClass");
    }
    public virtual void VirtualPrintInBaseClass()
    {
        Console.WriteLine("VirtualPrintInBaseClass");
    }
}

class DerivedClass2 : BaseClass
{
    public void PrintInDerivedClass()
    {
        Console.WriteLine("PrintInDerivedClass... then base");
        PrintInBaseClass();
    }

    public override void VirtualPrintInBaseClass()
    {
        Console.WriteLine("VirtualPrintInBaseClass in the derived class");
        Console.WriteLine("... and now we'll call the base class method!");
        base.VirtualPrintInBaseClass();
    }
}


/// <summary>
/// ///////////////////////////////////////////////////////////////
/// </summary>
abstract class AbstractBaseClass
{
    protected void ProtectedPrintInBaseClass()
    {
        Console.WriteLine("ProtectePrintInBaseClass");
    }

    protected abstract void ProtectedPrintOutBaseClass();
}


class DerivedCalss : AbstractBaseClass
{
    public void PrintInDerivedClass()
    {

        Console.WriteLine("We're in the derived class!");
        base.ProtectedPrintInBaseClass(); // be classe asli vasl mishe 
        Console.WriteLine("we're leaving the method in the derived class!");
    }

    protected override void ProtectedPrintOutBaseClass()
    {
        Console.WriteLine("ProtectedAbstractPrint");
    }
}