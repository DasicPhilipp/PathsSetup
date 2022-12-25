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
            InvalidPath = "not_a_path",
            PathWithoutAttribute = "test.json"
        };
        new PathsResolver("").Resolve(testData);
    }
}