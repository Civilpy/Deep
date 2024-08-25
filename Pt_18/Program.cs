// TREAT Methods like Variables , And use them AS Variables 

/*
 * we may write code that when something is complete,
 * we'd like something we specify to get run
 * this is called a callback => the abality for us to run code at a later point in time 
 *                              // so we can say hey look we have this method that
 *                              i want to be able to run but i want to run it after
 *                              sth else is completed 
 *                              but we dont know when that other thing is complete 
 *                              so what i like to do is to tell the thing 
 *                              hey look i have this method i want to give it to u 
 *                              when you're done and you're in a right state 
 *                              go and run that method for me ==> that's what a call Back does 
 * we'll look at passing around methods
 * as parameters and storing them as Variables
 * 
 * 
 * we have a type called a "delegate" which allows 
 * us to define a method signature == > we can take a method and put it into a variable to be 
 *                                      able to pass it around... sounds a little bit odd but
 *                                      bcuz everytime we saw methods we're calling them 
 *                                      so we talked about defining them, put them on the classes and
 *                                      things like that but whatever we were doing with them  was just calling them
 *                                      
 * 
 * the most basic form is "Action", so let's store
 * a method into an Action Variable ==> Action is a void method 
 * 
 * 
 */
Action action = AmirAction;

// now we can call the method by invoking the variable:
action();
action.Invoke(); // either way works 
// and bcuz there's no parameters passed in bcuz that's the point of an Action 

// infact we can pass in Arguments to Action 
// but the result still will be void 



void AmirAction()
{
    Console.WriteLine("Hello from Amir!");
}


// now if we want to have a return type 
// there's another type of delegate we have access to 
// and that's calls the " Func " 

/*
 * if u want to define a Function, we can use the "FUNC" type:
 * the very LAST TYPE PARAMETER provided is the RETURN TYPE
 * 
 */

Func<int, int, int> addFunction = AddFunction;
Func<int, int, int> subtractFunction = SubtractFunction;

int AddFunction(int a, int b)
{
    return a + b;
}

int SubtractFunction(int a, int b)
{
    return a - b; 
}



Func<int, int, string> addFunctionn = AddFunctionn;
Func<int, int, string> subtractFunctionn = SubtractFunctionn;

string AddFunctionn(int a, int b)
{
    return a + b;
}

int SubtractFunctionn(int a, int b) // return type inm avaz kn ....mibini ke method bala mizane ke kar mikone
                                    // va errori nemide
{
    return a - b;
}

// so how does this work with callbacks ?
// we can pass a method as a parameter to another method!

void DoSomethingAfterUserPressesEnter(Action callback) // we give it a call back so u see it's a method that
                                                       // takes a parameter that is essentioally a method
                                                       // that is going to be a call back 
{
    Console.WriteLine("Press enter for a surprise! ");
    Console.ReadLine();
    callback();
}

DoSomethingAfterUserPressesEnter(AmirAction); // dont use an extra () ... bcuz we are not calling 
                                              // AmirAction before we are going to 

/*
 * output : 
 * Hello from Amir!
 * Hello from Amir!
 * Press enter for a surprise! 
 * 
 * notice that on method above(DoSomethingAfterUserPressesEnter)
 * we did not call AmirAction again we did not see Hello from Amir!
 * 3 times and then we go see Press enter for a surprise! 
 * bcuz we did not call the method on the method above
 * passed it as a parameter and if we press Enter
 *  we will finish Console.ReadLine() (in DoSomethingAfterUserPressesEnter mrthod)
 *  and then call the callBack so we delayed the executionof the method 
 *  till we hit the Enter and the we see Hello from Amir bcuz we executed the callback
 
 */

// you may want to do this in situations where 
// you need to constrol what is executed after 
// a certain event occurs or condition is met
// - after a file is downloaded 
// - when a suer clicks a button
// - when a monitor detects an issue


// we can also pass a function as aparameter:

void Calculatee(Func<int, int, int> calculateCallback)
{
    Console.WriteLine("Enter the first integer: ");
    int a = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the second integer: ");
    int b = int.Parse(Console.ReadLine());

    int result = calculateCallback(a, b);
    Console.WriteLine($"the Result is {result}");
}

Console.WriteLine("Addition Example: ");
Calculatee(addFunction);
Console.WriteLine("Subtraction Example: ");
Calculatee(subtractFunction);


// Predicate 

/*
 * Action is simple
 * Func is convinient but does not help readability
 * we have Predicate which is essentially Func<T, bool>     // filtering on result set 
 *                                                          // like does this thing match 
 *                                                          // criteria we are interestin in
 *                                                          
 * But what if we want out own? Can we get more readability?
 */

/*
.
.
.
.
.
.
.
*/