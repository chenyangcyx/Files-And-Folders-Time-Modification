using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project4
{
    class GetFolderFileInfo
    {
        public void TestTimeCompare()
        {
            //测试时间比较
            DateTime dt1 = new DateTime(2019, 1, 1, 12, 12, 13, DateTimeKind.Local);
            DateTime dt2 = new DateTime(2020, 1, 1, 12, 12, 13, DateTimeKind.Local);
            if (DateTime.Compare(dt1, dt2) > 0)
                Console.WriteLine("时间1晚于时间2");
            else if (DateTime.Compare(dt1, dt2) < 0)
                Console.WriteLine("时间1早于时间2");
            else
                Console.WriteLine("两时间相同！");
        }
    }
}
