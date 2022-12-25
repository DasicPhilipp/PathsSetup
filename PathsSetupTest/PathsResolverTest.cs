using PathsSetup;

namespace PathsSetupTest;

[TestClass]
public class PathsResolverTest
{
    [TestMethod]
    public void TestPathResolve()
    {
        TestData testData = new TestData()
        {
            FolderPath = "folder/another folder/",
            FilePath = "test.json",
            FolderFilePath = "folder/another folder/test.json",
            FolderFilePathDisabledRoot = "folder/another folder/test.json",
            PathWithoutAttribute = "test.json"
        };
        new PathsResolver().Resolve(testData);
        new PathsResolver(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), nameof(PathsResolverTest))).Resolve(testData);
    }
}