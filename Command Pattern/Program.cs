/*
 * 
 * The Command Pattern is a behavioral design pattern that converts actions into separate command objects,
 * allowing the invoker to store, queue, and execute them later without knowing how each action is performed.
 * 
*/
public interface ICommand
{
    void Execute();
}

public class LightOnCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("The light is ON");
    }
}

public class LightOffCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("The light is OFF");
    }
}
public class WakeUpEarlyCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Waking up early in the morning!");
    }
}

public class Invoker
{
    private List<ICommand> commands = new();
    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (var command in commands)
        {
            command.Execute();
        }
        commands.Clear();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Invoker invoker = new Invoker();
        var lightOnCommand = new LightOnCommand();
        var lightOffCommand = new LightOffCommand();
        var wakeUpEarlyCommand = new WakeUpEarlyCommand();

        invoker.AddCommand(lightOnCommand);
        invoker.AddCommand(wakeUpEarlyCommand);
        invoker.AddCommand(lightOffCommand);

        invoker.ExecuteCommands();
    }
}







