using System;
using System.Collections.Generic;
using System.Text;

namespace AskingProjectV2
{
    class radioCheckedEventArgs:EventArgs
    {
        //qstID is ID of question of this choice, =j+1
        public int qstID;
        //chID is the No of this choice, =i+1
        public int chID;
        public radioCheckedEventArgs(int j, int i)
        {
            qstID = j + 1;
            chID = i + 1;
        }
    }
}
