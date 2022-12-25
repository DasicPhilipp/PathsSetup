[![Nuget](https://img.shields.io/nuget/v/PathsSetup?style=plastic)](https://www.nuget.org/packages/PathsSetup)
# PathsSetup
A simple library to generate folders and files from string properties containing paths.

## Tutorial
#### Add the ``Path`` attribute to the property in this way:
```cs
public class Data
{
    [Path] public string FilePath { get; init; } = "file.txt";
    
    // Don't forget that folder paths must end with a slash, otherwise it is a file without an extension
    [Path] public string FolderPath { get; init; } = "Folder/AnotherFolder/";
}
```
This attribute contains two parameters: ``bool addRootFolter = true`` and ``FileOptions fileOptions = FileOptions.None``.

The first one is used to modify the value of the property with the attribute if this requires merging with a root folder.
For instance, if there is a root folder ``"C:/RootFolder/"``, it modifies the ``FilePath`` value from
``"file.txt"`` to ``"C:/RootFolder/file.txt"``. Later you will learn how to configure the root directory.

The second parameter is just a bunch of options for creating a file using [File.Create()](https://learn.microsoft.com/ru-ru/dotnet/api/system.io.file.create?view=net-7.0#system-io-file-create(system-string-system-int32-system-io-fileoptions))

#### Resolve paths using ``PathsResolver``
```cs
// ...
Data data = new Data()
{
    FilePath = "file.txt",
    FolderPath = "Folder/AnotherFolder/"
};

IPathsResolver pathsResolver = new PathsResolver();
pathsResolver.Resolve(data);
// ...
```
As a result, ``"file.txt"`` and ``"Folder/AnotherFolder/"`` will be generated in the main directory of the program.

You can set up your own root folder in the ``PathsResolver`` constructor as in the example below:
```cs
Data data = new Data()
{
     FilePath = "file.txt",
     FolderPath = "Folder/AnotherFolder/"
};

IPathsResolver pathsResolver = new PathsResolver(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "PathsResolverTest"));
pathsResolver.Resolve(data);

Console.WriteLine(data.FilePath);
Console.WriteLine(data.FolderPath);

// Output:
  "C:\\ProgramData\\PathsResolverTest\\file.txt"
  "C:\\ProgramData\\PathsResolverTest\\Folder\\AnotherFolder\\"
```
