JustEat Technical Test
======================

The code was written in Visual Studio 2013 and runs as a console app.  Type the postcode and press return to see results.  Typing 0 and pressing return exits.

##Questions

###How long did you spend on the coding test? What would you add to your solution if you had more time? 


I didn't get a contigous block of time to spend coding, but in all I would estimate I spent about three and a half hours on this. I also gave myself thirty minutes thinking before I started so that I could plan my route through and decide what nuget packages to use.

I chose

* **RestSharp** - an excellent library that I used once a few years back and knew to be a good choice for calling APIs.
* **Nunit** - my usual 'go to' test framework
* **Moq** - again my most used framework for mocking
* **FluentAssertions** - an excellent framework that provides extremely useful extensions for assertions.  In this case I wanted it primarily for the ease with which you can deep compare two objects without having to write your own override on equals.

The approach I decided to take was to create a service that wrapped the JustEat API call, returning a model that contained only the required properties. I considered that the JustEat API would be well tested and so my tests would concentrate on ensuring that the data fed to the service by the API call was correctly mapped to the new model.

The service itself would not create the RestSharp Client and Request objects but use a factory to create them.  This gives us multiple benefits;

* If we expand the program, adding other services that call the same API but for different purposes we would not be reproducing the setup each time.  
* The console program calling the service does not need to know about RestSharp.
* We can create our own factories in test.

The model mapping magic happens thanks to RestSharp which auto detects and deserialises the JSON.  It relies on naming conventions within the model and in order to deliver minimum viable product I happily used that to auto fill the service model. If there had been a requirement to allow for switching API providers we would have to add mappers on a provider basis.

I left out a few things due to time considerations, these are 

* Tidying up the way console message are displayed.
* Configuration - the api path is hard coded in the factory
* IOC - for this simple task I didn't think it necessary to introduce a container but it would be a requirement as we went further.
* Any kind of error checking that goes further than RestSharps own HttpStatusCode indicator

If I had more time I would have created a front end that was web based rather than console based. I would 

* Create a web api interface that called the service and returned the model. 
* Have a static html page based on Angular that called my API and used a restaurants directive  with a nested restaurant directive in a repeat loop to display the restaurants. 
* Add more error checking and logging of those errors.
* Make the API call async and introduce short term caching of results.

##What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.
There are actually two very useful features in C#6.0 that I like - the Null Conditional Operator and String Interpolation. Both conspire to make your code more readable.

For instance if we have a class 'Person' as follows;

    Person
        Name
        Address
            City
            Postcode

And we override the ToString method to display summary information, we can use both features (I have also cheekily thrown in an expression bodied function) as follows;

    public override string ToString() => $"Name: {Name} City: {Address?.City ?? "Unknown"}";

Note - obvious placeholders within the string for your properties and no need to null check the Address in order to get the City.
		
		
##How would you track down a performance issue in production? Have you ever had to do this?
On my last contract I monitored the main products using NewRelic which has excellent facilities to trace through your code and also list timings on calls to external services and databases. We load tested new releases using Flood.io and a JMeter script and NewRelic monitored the performance of the staging server that was being load tested.

I have been known to inject stopwatch calls into code when fine tuning too.

##How would you improve the JUST EAT APIs that you just used?
If I were using the API directly in a SPA it would be nice to have additional features such as 'radius', 'does deliveries', 'open now' so that I didn't need to write the script to do that. Also perhaps an indicator as to the validity of the outcode. I would also prefer the API to be in a more navigable format ie `restaurants/outcode/{outcode}/delivers/open`

##Please describe yourself using JSON.
    {
        "name": "Darren Hall",
        "gender": "Male",
        "roleSought": "Contract Senior Developer",
        "education": {
            "university": "Bsc (Hons) Microproceesor Engineering University of Essex",
            "college": "Harrow College of Higher Education"
        },
        "interests": [
            "Mixed martial arts",
            "Boomerangs",
            "Quadcopters",
        ],
        "strangeButTrue": {
            "workLife": [
                "Worked on several Bond films",
                "Wrote top selling computer games for the early 8 bit computers whilst at school"
            ],
            "personalLife": [
                "Been Best Man 4 times (not recommended)",
                "Went to a party on Rutger Hauers yacht",
                "Got locked in a toilet for 3 hours on my first ever job"
            ]
        }
    }
