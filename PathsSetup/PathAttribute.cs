namespace PathsSetup;

[AttributeUsage(AttributeTargets.Property)]
public class PathAttribute : Attribute
{
    public bool AddRootFolder { get; }
    public FileOptions FileOptions { get; }
    
    public PathAttribute(bool addRootFolder = true, FileOptions fileOptions = FileOptions.None)
    {
        AddRootFolder = addRootFolder;
        FileOptions = fileOptions;
    }
}