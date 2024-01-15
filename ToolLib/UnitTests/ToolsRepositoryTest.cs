using ToolLib;

namespace UnitTests
{
    [TestClass]
    public class ToolsRepositoryTest
    {
        [TestMethod]
        public void Add_ValidTool_ReturnsAddedToolWithIncrementedId()
        {
            var repository = new ToolsRepository();
            var initialItemCount = repository.GetAll().Count();
            var tool = new Tool { Type = "Saw", Price = 100 };

            var addedTool = repository.Add(tool);

            Assert.IsNotNull(addedTool);
            Assert.AreEqual(initialItemCount + 1, addedTool.Id); // Assuming nextid starts from 1
            Assert.AreEqual(initialItemCount + 1, repository.GetAll().Count()); // Ensure the tool was added to the list
        }

        [TestMethod]
        public void Update_ExistingTool_ReturnsUpdatedTool()
        {
            var repository = new ToolsRepository();
            var existingTool = repository.Add(new Tool { Type = "Saw", Price = 100 });
            var updatedTool = new Tool { Type = "Drill", Price = 150 };

            var result = repository.Update(existingTool.Id, updatedTool);

            Assert.IsNotNull(result);
            Assert.AreEqual(updatedTool.Type, existingTool.Type);
            Assert.AreEqual(updatedTool.Price, existingTool.Price);
        }

        [TestMethod]
        public void Update_NonExistingTool_ReturnsNull()
        {
            var repository = new ToolsRepository();
            var nonExistingId = 123; // Assuming this ID doesn't exist
            var updatedTool = new Tool { Type = "Drill", Price = 150 };

            var result = repository.Update(nonExistingId, updatedTool);

            Assert.IsNull(result);
        }
    }
}