using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Containerization.Tests
{
    [TestFixture]
    public sealed class TreeManagerTest
    {
        [TestCase]
        public async Task CreationTest()
        {
            var userContext = UserContextFactory.CreateUserContext();
            var treeManager = userContext.TreeManagerFactory.CreateTreeManager();
            var tree = await treeManager.CreateTree("123");
            ShowFolder(tree);
        }

        private void ShowFolder(IFolder folder)
        {
            Console.WriteLine($"folder Id:{folder.Id} name{folder.Name}");

            foreach (var subfolder in folder.Childs)
            {
                ShowFolder(subfolder);
            }

            foreach (var data in folder.Data)
            {
                ShowData(data);
            }
        }

        private void ShowData(IData data)
        {
            Console.WriteLine($"data Id:{data.Id} Value:{data.Value()} type:{data.Type.Name}");
        }
    }
}
