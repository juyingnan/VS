using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinnerDecision
{
    static class Menu
    {
        //菜单列表
        public static List<string> menu;

        //设置菜单
        public static void Set(string menuString)
        {
            menu = new List<string>();
            //用空格分隔
            menuString = menuString.Trim();
            string[] m = menuString.Split(' ');
            menu.Clear();
            foreach (var item in m)
            {
                if (item != "" || item.Trim() != "")
                    menu.Add(item);
            }
        }
    }
}
