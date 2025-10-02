using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class DeleteGroupsTest : TestBase
    {
        [Test]

    public void TestDeleteGrous()
        {
            GroupData newGroup = new GroupData()
            {
                Name = "forDelete"
            };


            List<GroupData> oldGroups = app.Groups.GetGroupList();
            System.Threading.Thread.Sleep(500);
            if (oldGroups.Count < 2 )
            {
                app.Groups.Add(newGroup);
                
            }
            List<GroupData> groupToOld = app.Groups.GetGroupList();

            System.Threading.Thread.Sleep(500);
            app.Groups.Delete(0);
            System.Threading.Thread.Sleep(500);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            //oldGroups.RemoveAt(0);
            //oldGroups.Sort();
            //newGroups.Sort();

            Assert.That(groupToOld.Count-1, Is.EqualTo(newGroups.Count));
        }

    }
}
