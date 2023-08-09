using XUnit;
using nl.florentine.processing;

namespace nl.florentine.tests {
    public class FileRenameTest() {
        [Fact]
        public void FileRenameTest() {
            var testService = new TestService();
            
            var manager = new FileManager();
            bool result = manager.processFile("", "", "", true);

            if (result) {
                Assert.True(result, "File successfully renamed");
            } else if (!result) {
                Assert.False(result, "File unable to be renamed");
            }

        }
    }
}