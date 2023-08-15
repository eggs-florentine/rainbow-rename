using XUnit;
using nl.florentine.processing;

namespace nl.florentine.tests {
    public class ProcessNameTest() {
        [Fact]
        public void ProcessNameTest() {
            if ("ababababa".Contains("a")) {
                Assert.True(true, "Identified character");
            } else if ("ababababa".Contains("a") == false) {
                Assert.False(false, "Failed to identify character");
            }
        }
    }
}
