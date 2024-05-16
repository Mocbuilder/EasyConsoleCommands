using EasyConsoleCommands;

internal class CommandScript : ICommand
{
    private Framework framework;

    public CommandScript(Framework framework)
    {
        this.framework = framework;
    }

    public string Name => "script";

    public string HelpText => "script-[Valid file path to a txt file]";
    public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo) };

    public void Execute(List<VariableInfo> inputParams)
    {
        StringInfo param = inputParams[0] as StringInfo;

        foreach (var line in File.ReadAllLines(param.Value))
        {
            string ToExecute = CheckForComment(line);
            if (ToExecute != null)
            {
                framework.Execute(ToExecute);
            }
        }
    }

    public string CheckForComment(string line)
    {
        string toCheck = line.TrimStart();

        if (string.IsNullOrWhiteSpace(toCheck))
            return null;

        if (!toCheck.StartsWith("//"))
            return toCheck;

        return null;
    }
}
