# ECC - EasyConsoleCommands Documentation
ECC is a simple, self-scaling command-based system for console applications that comes with some simple base-commands and allows creation of costum commands. It also has a basic scripting ability with permanent variables etc.

# Components
## 1. Users
The user can interact with the system by entering commands into the console. These commands are always follow the same format. A full list of all registered commands (including your costum ones) is available with the ``help`` command.\
**Example**
```
//Command with no variables, e.g. "help"
help

//Commands with variables, e.g. "color" (sets font color, takes valid ConsoleColor as parameter)
//Parameters are given behind a "-"
color-red

//Commands with multiple parameters, e.g. "alias" (sets alias for a command, takes current command name and new name as input)
//Multiple parameters are also seperated by "-" 
alias-color-changeFontColor

//Commands that take raw user input take it the same way as a parameter
```

## 2. Developers: Scripting
When using ECC in your framework you can also write simple scripts with it (An example script is in the Example.txt). It basically works by writting the commands that you would use in the console line by line in a .txt file and then executing it with the ``script`` command.
**Example**
```
//This is your script in a .txt
print-Hello World
color-red
print-This is printed in red!
color-white
print-This is printed in white again!

//This will be the output
script-path/to/your/script.txt
Hello World
This is printed in red!
this is printed in white again!
```
Scripting can be usefull when you want to execute the same commands over and over again (e.g. to setup your enviroment with font color, variables etc.) or even to write small programs like a calculator or similar.

## 3. Developers: Creating a costum command
To create a costum command you need to make a class that inherites from the Interface ICommand provided by ECC.
The Interface has the following structure:
```
    class CommandExample : ICommand
    {
        //This is the keyword for your command
        public string Name => "example"; 

        //This should explain your command briefly and mention all the needed parameters
        public string HelpText => "It's just an example."; 

        //This list should contain all the needed parameters as StringInfo, IntInfo or BoolInfo (Types provided by ECC). Here it takes two strings as parameters.
        public List<Type> ParameterTypes => new List<Type> (typeof(IntInfo), typeof(intInfo)); 

        //The Execute function contains the logic for your command
        //Set List<VariableInfo> as a parameter, to include your parameters
        public void Execute(List<VariableInfo> inputParameters)
        {
            //To use a parameter, get it from the list. The first variable is Position 0, the second one is 1 and so on...
            IntInfo firstParameter = inputParameters[0] as IntInfo;
            IntInfo secondParameter = inputParameters[1] as IntInfo;

            //Use it as (your variable name)firstparameter.Value to get the int value
            int aNewNumber = firstParameter.Value + secondParameter.Value
            
            Console.WriteLine("Your new number is: " + aNewNumber);
        }
    }
```

Then, after creating your command class, register it with the framework.
```
Commands.Add(new CommandExample());
```

To interact with the framework or pass any objects, write a constructor for our command class that takes the object and pass it with the registration.
```
//In your command class, put it into a constructor
    class CommandExample : ICommand
    {
        public string Name => "example"; 

        public string HelpText => "It's just an example."; 

        public List<Type> ParameterTypes => new List<Type> { typeof(IntInfo), typeof(IntInfo)}; 

        private HttpClient client;

        public CommandJokeExample()
        {
            client = new HttpClient();
        }

        public void Execute(List<VariableInfo> inputParameters)
        {
            //Do something with it...
        }
    }

//At the registration pass the object
HttpClient client = new HttpClient();
Commands.Add(new CommandExample(client));
```

# Commands
All available commands are:
- ```help``` -> Lists all available commands
- ```setcolor-[Any valid 8-Bit color]``` -> Sets the font color of the console
- ```joke [-ten]``` -> Get a random joke, or optionally ten random jokes.
- ```ip [-v4] [-v6]``` -> Get either the IPv4 or IPv6 addresses.
- ```ping-[Any valid IPv4 address]``` -> Pings the specified IP address
- ```sys- [hw -> Get hardware information] [os -> Get Operating System information] [net -> Get .Net Framework information] [programs -> Get all installed programs (from HKEY_LOCAL_MACHINE)]``` -> Get system information
- ```hacker-[Any valid 8-bit color]``` -> Makes you a Master haxxor, in any color you want
- ```clear``` -> Clears the console
- ```exit``` -> Quit the application
- ```script-[Valid file path to a text file]``` -> Run a script of commands
- ```sleep-[any valid number]``` -> wait for specified time in seconds. Mainly used in scripting
- ```print-[Text to be printed or 'var']-[variable name]``` -> Prints specified text or, if that is var-[any existing variable], prints the value of the variable
- ```add-[type]-[name]-[value]``` -> Add a new variable as 'string' 'int' or 'bool' and add a name and value
- ```get-[variable name]``` -> get any existing variable
- ```calc-[type of calculation: add, sub, div, mul]-[first number]-[second number]``` -> Do some simple calculations with two numbers
- ```rm-[Name of a existing variable]``` -> Remove any existing variable by name
- ```setvalue-[Name of existing variable]-[New value]``` -> Set a new value to an already existing variable. New value must be of the same type as the old value
- ```setname-[Name of a existing variable]-[New name of that variable]``` -> Set the name of any existing variable to a new name
- ```prcs``` -> List all currently running processes
- ```kill-[Name of any running process]``` -> Terminates the specified process. Could need Admin priviliges to execute properly
- ```read-[Type of new variable]-[Name of new variable]-[Message to be printed before the input]``` -> Creates a new variable and puts the next userinput as value, while printing a message to the user
- ```alias-[Command you want to alias]-[New command]``` -> Set the keyword for any command

# Credits
Idea, Design and Programming			    Mocbuilder (Mocbuilder Coding Creations) aka Me

Base-Code of the "hacker"-command			CollegeCode (https://www.youtube.com/watch?v=eWceJNkxbdU)

Special Thanks to rmoc81 for helping me with the programming.

If you want to use this in any public way, a little credit would be appreciated.