using PathsSetup;

namespace PathsSetupTest;

public struct TestData
{
    [Path] public string FolderPath { get; init; }
    [Path] public string FilePath { get; init; }
    [Path] public string FolderFilePath { get; init; }
    [Path] public string InvalidPath { get; init; }
    public string PathWithoutAttribute { get; init; }
}