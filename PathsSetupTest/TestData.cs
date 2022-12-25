using PathsSetup;

namespace PathsSetupTest;

public class TestData
{
    [Path] public string? FolderPath { get; init; }
    [Path] public string? FilePath { get; init; }
    [Path] public string? FolderFilePath { get; init; }
    [Path(false)] public string? FolderFilePathDisabledRoot { get; init; }
    public string? PathWithoutAttribute { get; init; }
}