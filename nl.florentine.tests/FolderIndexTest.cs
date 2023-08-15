using XUnit;
using nl.florentine.processing;

namespace nl.florentine.tests {
    public class FolderIndexTest() {
        [Fact]
        public void FolderIndexTest() {
            var testService = new TestService();
            Directory.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "rainbow-rename-folder-test");
            var adDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "rainbow-rename-folder-test";

            File.Create(adDirectory + "\\" + "a.txt").Dispose();
            File.Create(adDirectory + "\\" + "b.txt").Dispose();
            
            var manager = new FileManager();
            ArrayList expectation = new ArrayList();
            expectation.add(adDirectory + "\\" + "b.txt");

            if (manager.queryIndex(manager.indexFolder(adDirectory), "b") == expectation) {
                Assert.True(true, "Folder successfully indexed");
            } else if (manager.queryIndex(manager.indexFolder(adDirectory), "b") != expectation) {
                Assert.False(false, "Folder unable to be indexed");
            }

        }
    }
}
