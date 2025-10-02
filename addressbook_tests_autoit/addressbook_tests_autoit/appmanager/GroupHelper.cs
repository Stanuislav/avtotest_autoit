using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper: HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPWINDELETE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            System.Threading.Thread.Sleep(500);
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount","#0","");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item =
                     aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                     "GetText", "#0|#" + i, "");           
                list.Add(new GroupData()
                {
                    Name = item,
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        public void Delete(int index)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#"+index, "");
            System.Threading.Thread.Sleep(500);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            System.Threading.Thread.Sleep(500);
            aux.ControlClick(GROUPWINDELETE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            System.Threading.Thread.Sleep(500);
            CloseGroupsDialogue();
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            System.Threading.Thread.Sleep(300);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            System.Threading.Thread.Sleep(300);

            aux.Send("^a"); // Ctrl+A - выделить все
            aux.Send("{DEL}"); // Удалить

            aux.Send(newGroup.Name);
            Console.WriteLine("Текст 'test' отправлен");
            System.Threading.Thread.Sleep(300);
            aux.Send("{ENTER}");
            System.Threading.Thread.Sleep(300);
            CloseGroupsDialogue();

        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}