using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            ////链表的测试
            //queue_to_list test1 = new queue_to_list();
            //test1.test1();

            //时间的测试
            GetFolderFileInfo gff = new GetFolderFileInfo();
            gff.TestTimeCompare();
        }
    }
}
