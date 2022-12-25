namespace PathsSetup;

[AttributeUsage(AttributeTargets.Property)]
public class PathAttribute : Attribute
{
    public FileOptions FileOptions { get; }
    
    public PathAttribute(FileOptions fileOptions = FileOptions.None)
    {
        FileOptions = fileOptions;
    }
}