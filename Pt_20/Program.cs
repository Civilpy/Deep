/*
 * Event and Event Handlers in C# are a way that can have 
 * delegates be called by "subscribing" them to events.
 * this allows aus to create a mechanism where we can 
 * notify ither components in our system about changes 
 * they care about.
 * 
 * 
 * in the most common scenarios, events use
 * an EventHandler delegate, which accepts
 * a type called EventArgs. the delegate
 * signature is:
 * 
 * public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e)      its a void return type 
 *                                                                                 its going to be EventHandler that has some type of 
 *                                                                                 <TEventArgs> and technically we are missing a where
 *                                                                                 clause on here bcuz EventArgs need to inherite so 
 *                                                                                 we do have this inheritance relationship here where 
 *                                                                                 the EventArgs must be of type of that ARGS 
 *                                                                                 
 *                                                                                 so have this object sender which is going to be 
 *                                                                                 the person(the class that owns the Event)
 *                                                                                 that's raising the Event 
 *                                                                                 and what we are able to do is the class
 *                                                                                 that raising the Event can pass an Event arguments 
 *                                                                                 those Event arguments are passed to each Event Handler 
 *                                                                                 
 * 
 * the "sender" parameter is the object that raised the event
 * the "e" parameter is an instance of the EventArgs class
 * 
 * 
 * let's create our own EventArgs class for sending a message !
 * 
 * 
 * ----------------------------------------
 * 
 * Event is source of something occuring ,what we are able to do is hook up an EventHandler
 * so just like a callback to this Event and that way the person who owns the Event can say
 * hey look somethings happend i will invoke the event handler that you provided me now 
 * 
 * 
 * we can hookup multiple Event Handler to an Event ..in fact they're chain together ...the order we add them
 * in is the order that will be executed 
 */

public class MessageEventArgs : EventArgs // EventArgs themselves dont force us to go implement anything so its
                                          // its not an abstract class that we must override 
                                          // anything it's just going to be bcuz that's 
                                          // signature need to work with an EventArgs 
{
    public MessageEventArgs(string message)
    {
        Message = message;
    }
    public string Message { get; private set; }
}

// what we need now is a class to Raise an Event and other people be able to see that
// Event so they can subscibe to it with their own EventHandlers 






// EventSource

public class EventSource
{
    // this declares the event, and the type of the event
    // but nobody outside of this class can raise the Event
    // directly by accessing this

    public event EventHandler<MessageEventArgs> SourceChanged; // type of an EventHandler 

    // if we remove the event keyword we technically only have 
    // a variable now that's able to store one delegate in 
    // an EventHandler type and it calls SourceChanged 
    // but event keyword allow us to do couple of things 

    // 1 - from outside of the class you are able to hookup to the
    // Event with ur own eventHandler 

    // 2 - to have Invoke syntax , it calls raising an event 

    public void RaiseEvent(string message)
    {
        SourceChanged.Invoke(this, new MessageEventArgs(message)); // this : the current object we are in is the class raising the Event 

        //SourceChanged tachnically can be null and it's a little confusing 
        // cuz if we look at the line  above (public event EventHandler<MessageEventArgs> SourceChanged;)
        // we cant say by looking by default that can be null .. shouldnt an event 
        // be null? .... we dont really know ... but it is 
        // and that's sth we need to pay attention to bcuz if no one has subscribed to 
        // this Event that means that SourceChanged will be null 
        // so you will need to be look for that 

    }
}