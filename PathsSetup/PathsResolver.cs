using System.Reflection;
using static System.IO.File;

namespace PathsSetup;

public class PathsResolver : IPathsResolver
{
    private readonly string _rootDirectory;

    public PathsResolver(string rootDirectory = "")
    {
        _rootDirectory = rootDirectory;
    }

    public void Resolve(object obj)
    {
        foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
        {
            PathAttribute? pathAttribute = propertyInfo.GetCustomAttribute<PathAttribute>();
            if (pathAttribute == null) continue;
            
            string? path = propertyInfo.GetValue(obj)?.ToString();
            if (path == null) continue;
            
            CreateDirectory(Path.Combine(_rootDirectory, path));
            CreateFile(Path.Combine(_rootDirectory, path), pathAttribute.FileOptions);
        }
    }

    private void CreateDirectory(string? path)
    {
        if (string.IsNullOrEmpty(path)) return;
        
        string? directoryPath = Path.GetDirectoryName(path);
        if (string.IsNullOrEmpty(directoryPath)) return;
        
        Directory.CreateDirectory(directoryPath);
    }

    private void CreateFile(string? path, FileOptions fileOptions)
    {
        if (string.IsNullOrEmpty(path)) return;
        if (Exists(path)) return;
        if (Path.GetFileName(path) == string.Empty) return;
        
        Create(path, 4096, fileOptions);
    }
}