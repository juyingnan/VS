using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AskingProjectAnswerGenerator
{
    public class Question
    {
        //this property needs be output
        public int answer;

        //all various below dont need be output 
        [XmlIgnore]
        //Question ID
        public string ID;
        [XmlIgnore]
        //question body
        public string questionBody;
        [XmlIgnore]
        //question choices
        public List<string> choice = new List<string>();
        [XmlIgnore]
        //quantity of choices
        public int choiceQuantity;
        [XmlIgnore]
        //question type:
        //0: this question has multiple choices
        //1: this question has a sliderBar and 2 extreme choice
        public int questionType;
        [XmlIgnore]
        //whether this question is done
        public bool isDone = false;
        [XmlIgnore]
        //whether this question is ID in 2 line
        public bool isIDWithChoice = false;


        //construct method
        public Question(int qstType, string id, string qstBody, List<string> chs, int choiceQnty)
        {
            ID = id;
            questionBody = qstBody;
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
            ID = "";
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
    }
}
