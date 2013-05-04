using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AskingProject
{    
    public class Question
    {
        //this property needs be output
        public int answer;

        //all various below dont need be output 
        [XmlIgnore]
        //Question ID
        public int ID;
        [XmlIgnore]
        //question body
        public string questionBody;
        [XmlIgnore]
        //question choices
        public List<string> choice=new List<string>();
        [XmlIgnore]
        //quantity of choices
        public int choiceQuantity;
        [XmlIgnore]
        //question type:
        //0: this question has multiple choices
        //1: this question has a sliderBar and 2 extreme choice
        public int questionType;
        [XmlIgnore]
        //group ID
        public int groupID;

        //onstruct method
        public Question(int qstType, int id, string qstBody, List<string> chs, int choiceQnty, int grpID)
        {
            ID = id;
            questionBody = qstBody;
            groupID = grpID;
            switch (qstType)
            {
                case 1:
                    questionType = qstType; 
                    try
                    {
                        //get 2 extreme choice and slider MaxNumber
                        choice.Add(chs[0]);
                        choice.Add(chs[1]);
                        choiceQuantity = Int32.Parse(chs[2]);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    answer = 1;
                    break;
                default:
                    questionType = 0;
                    foreach (var s in chs)
                    {
                        choice.Add(s);
                    }
                    answer = 0;
                    choiceQuantity = choiceQnty;
                    break;
            }
        }

        public Question()
        {
            ID = 0;
            questionBody = "";
            answer = 0;
            choiceQuantity = 0;
        }

        public void getAnswer(int answerInput)
        {
            if (answerInput >= 1 && answerInput <= choiceQuantity)
            {
                answer = answerInput;
            }
        }


        public override string ToString()
        {
            return answer.ToString()+"\t";
            //return "ID:" + ID.ToString() + "," + "Body:" + questionBody + "," + "A1:" + choice[1] + "," + "A2:" + choice[2] + "," + "A3:" + choice[3] + "," + "A4:" + choice[4] + "," + "A5:" + choice[5] + ".";
        }
    }
}
