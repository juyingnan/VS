using System;
using System.Collections.Generic;
using System.Text;

namespace AskingProject
{
    class Group
    {
        public int ID;
        public int fakeID;
        public int memberQuantity;

        public Group(int id, int fid, int mbQty)
        {
            ID = id;
            fakeID = fid;
            memberQuantity = mbQty;
        }
    }
}
