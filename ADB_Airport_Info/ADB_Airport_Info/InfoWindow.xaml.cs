using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ADB_Airport_Info
{
    /// <summary>
    /// InfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InfoWindow : Window
    {
        string fileFolderAddress;
        string fileAddress;
        string fileName;
        XmlDocument myXml = new XmlDocument();
        AirportInfo currentAirportInfo = new AirportInfo();
        bool isCreated = false;
        bool isSaved = false;
        int projectQtr = 0;

        public InfoWindow(string fileFolderAddress, string fileName, bool isCreate)
        {
            InitializeComponent();
            this.fileFolderAddress = fileFolderAddress;
            this.fileName = fileName;
            this.fileAddress = fileFolderAddress + "\\" + fileName + ".xml"; 
            if (!isCreate)
            {
                fileRead(this.fileAddress);
            }
            else
            {
                this.isCreated = true;
                currentAirportInfo.basicInfo[1] = fileName;
            }
            writeInfoToChart();
        }

        private void writeInfoToChart()
        {

            //write the current Airport info class to the chart

            //basic info
            #region
            basicInfoContent00.Text = currentAirportInfo.basicInfo[0];
            basicInfoContent01.Text = currentAirportInfo.basicInfo[1];
            basicInfoContent02.Text = currentAirportInfo.basicInfo[2];
            basicInfoContent03.Text = currentAirportInfo.basicInfo[3];
            basicInfoContent04.Text = currentAirportInfo.basicInfo[4];
            basicInfoContent05.Text = currentAirportInfo.basicInfo[5];
            basicInfoContent06.Text = currentAirportInfo.basicInfo[6];
            basicInfoContent07.Text = currentAirportInfo.basicInfo[7];
            basicInfoContent08.Text = currentAirportInfo.basicInfo[8];
            basicInfoContent09.Text = currentAirportInfo.basicInfo[9];
            basicInfoContent10.Text = currentAirportInfo.basicInfo[10];
            basicInfoContent11.Text = currentAirportInfo.basicInfo[11];
            basicInfoContent12.Text = currentAirportInfo.basicInfo[12];
            basicInfoContent13.Text = currentAirportInfo.basicInfo[13];
            basicInfoContent14.Text = currentAirportInfo.basicInfo[14];
            basicInfoContent15.Text = currentAirportInfo.basicInfo[15];
            basicInfoContent16.Text = currentAirportInfo.basicInfo[16];
            basicInfoContent17.Text = currentAirportInfo.basicInfo[17];
            basicInfoContent18.Text = currentAirportInfo.basicInfo[18];
            basicInfoContent19.Text = currentAirportInfo.basicInfo[19];
            basicInfoContent20.Text = currentAirportInfo.basicInfo[20];
            basicInfoContent21.Text = currentAirportInfo.basicInfo[21];
            basicInfoContent22.Text = currentAirportInfo.basicInfo[22];
            basicInfoContent23.Text = currentAirportInfo.basicInfo[23];
            basicInfoContent24.Text = currentAirportInfo.basicInfo[24];
            //basicInfoContent25.Text = currentAirportInfo.basicInfo[25];
            //basicInfoContent26.Text = currentAirportInfo.basicInfo[26];
            //basicInfoContent27.Text = currentAirportInfo.basicInfo[27];
            //basicInfoContent28.Text = currentAirportInfo.basicInfo[28];
            //basicInfoContent29.Text = currentAirportInfo.basicInfo[29];
            //basicInfoContent30.Text = currentAirportInfo.basicInfo[30];
            //basicInfoContent31.Text = currentAirportInfo.basicInfo[31];
            #endregion


            //runwayinfo
            #region
            runwayInfoContent00.Text = currentAirportInfo.runway[0].info[0];
            runwayInfoContent01.Text = currentAirportInfo.runway[0].info[1];
            runwayInfoContent02.Text = currentAirportInfo.runway[0].info[2];
            runwayInfoContent03.Text = currentAirportInfo.runway[0].info[3];
            runwayInfoContent04.Text = currentAirportInfo.runway[0].info[4];
            runwayInfoContent05.Text = currentAirportInfo.runway[0].info[5];
            runwayInfoContent06.Text = currentAirportInfo.runway[0].info[6];
            runwayInfoContent07.Text = currentAirportInfo.runway[0].info[7];
            runwayInfoContent08.Text = currentAirportInfo.runway[0].info[8];
            runwayInfoContent09.Text = currentAirportInfo.runway[0].info[9];
            runwayInfoContent10.Text = currentAirportInfo.runway[1].info[0];
            runwayInfoContent11.Text = currentAirportInfo.runway[1].info[1];
            runwayInfoContent12.Text = currentAirportInfo.runway[1].info[2];
            runwayInfoContent13.Text = currentAirportInfo.runway[1].info[3];
            runwayInfoContent14.Text = currentAirportInfo.runway[1].info[4];
            runwayInfoContent15.Text = currentAirportInfo.runway[1].info[5];
            runwayInfoContent16.Text = currentAirportInfo.runway[1].info[6];
            runwayInfoContent17.Text = currentAirportInfo.runway[1].info[7];
            runwayInfoContent18.Text = currentAirportInfo.runway[1].info[8];
            runwayInfoContent19.Text = currentAirportInfo.runway[1].info[9];
            runwayInfoContent20.Text = currentAirportInfo.runway[2].info[0];
            runwayInfoContent21.Text = currentAirportInfo.runway[2].info[1];
            runwayInfoContent22.Text = currentAirportInfo.runway[2].info[2];
            runwayInfoContent23.Text = currentAirportInfo.runway[2].info[3];
            runwayInfoContent24.Text = currentAirportInfo.runway[2].info[4];
            runwayInfoContent25.Text = currentAirportInfo.runway[2].info[5];
            runwayInfoContent26.Text = currentAirportInfo.runway[2].info[6];
            runwayInfoContent27.Text = currentAirportInfo.runway[2].info[7];
            runwayInfoContent28.Text = currentAirportInfo.runway[2].info[8];
            runwayInfoContent29.Text = currentAirportInfo.runway[2].info[9];
            runwayInfoContent30.Text = currentAirportInfo.runway[3].info[0];
            runwayInfoContent31.Text = currentAirportInfo.runway[3].info[1];
            runwayInfoContent32.Text = currentAirportInfo.runway[3].info[2];
            runwayInfoContent33.Text = currentAirportInfo.runway[3].info[3];
            runwayInfoContent34.Text = currentAirportInfo.runway[3].info[4];
            runwayInfoContent35.Text = currentAirportInfo.runway[3].info[5];
            runwayInfoContent36.Text = currentAirportInfo.runway[3].info[6];
            runwayInfoContent37.Text = currentAirportInfo.runway[3].info[7];
            runwayInfoContent38.Text = currentAirportInfo.runway[3].info[8];
            runwayInfoContent39.Text = currentAirportInfo.runway[3].info[9];
            runwayInfoContent40.Text = currentAirportInfo.runway[4].info[0];
            runwayInfoContent41.Text = currentAirportInfo.runway[4].info[1];
            runwayInfoContent42.Text = currentAirportInfo.runway[4].info[2];
            runwayInfoContent43.Text = currentAirportInfo.runway[4].info[3];
            runwayInfoContent44.Text = currentAirportInfo.runway[4].info[4];
            runwayInfoContent45.Text = currentAirportInfo.runway[4].info[5];
            runwayInfoContent46.Text = currentAirportInfo.runway[4].info[6];
            runwayInfoContent47.Text = currentAirportInfo.runway[4].info[7];
            runwayInfoContent48.Text = currentAirportInfo.runway[4].info[8];
            runwayInfoContent49.Text = currentAirportInfo.runway[4].info[9];
            //runway info, additional
            runwayInfoContent010.Text = currentAirportInfo.runway[0].info[10];
            runwayInfoContent110.Text = currentAirportInfo.runway[1].info[10];
            runwayInfoContent210.Text = currentAirportInfo.runway[2].info[10];
            runwayInfoContent310.Text = currentAirportInfo.runway[3].info[10];
            runwayInfoContent410.Text = currentAirportInfo.runway[4].info[10];

            #endregion


            //staff info
            #region
            staffInfoContent00.Text = currentAirportInfo.staff[0].info[0];
            staffInfoContent01.Text = currentAirportInfo.staff[0].info[1];
            staffInfoContent02.Text = currentAirportInfo.staff[0].info[2];
            staffInfoContent03.Text = currentAirportInfo.staff[0].info[3];
            staffInfoContent04.Text = currentAirportInfo.staff[0].info[4];
            staffInfoContent10.Text = currentAirportInfo.staff[1].info[0];
            staffInfoContent11.Text = currentAirportInfo.staff[1].info[1];
            staffInfoContent12.Text = currentAirportInfo.staff[1].info[2];
            staffInfoContent13.Text = currentAirportInfo.staff[1].info[3];
            staffInfoContent14.Text = currentAirportInfo.staff[1].info[4];
            staffInfoContent20.Text = currentAirportInfo.staff[2].info[0];
            staffInfoContent21.Text = currentAirportInfo.staff[2].info[1];
            staffInfoContent22.Text = currentAirportInfo.staff[2].info[2];
            staffInfoContent23.Text = currentAirportInfo.staff[2].info[3];
            staffInfoContent24.Text = currentAirportInfo.staff[2].info[4];
            staffInfoContent30.Text = currentAirportInfo.staff[3].info[0];
            staffInfoContent31.Text = currentAirportInfo.staff[3].info[1];
            staffInfoContent32.Text = currentAirportInfo.staff[3].info[2];
            staffInfoContent33.Text = currentAirportInfo.staff[3].info[3];
            staffInfoContent34.Text = currentAirportInfo.staff[3].info[4];
            staffInfoContent40.Text = currentAirportInfo.staff[4].info[0];
            staffInfoContent41.Text = currentAirportInfo.staff[4].info[1];
            staffInfoContent42.Text = currentAirportInfo.staff[4].info[2];
            staffInfoContent43.Text = currentAirportInfo.staff[4].info[3];
            staffInfoContent44.Text = currentAirportInfo.staff[4].info[4];
            staffInfoContent50.Text = currentAirportInfo.staff[5].info[0];
            staffInfoContent51.Text = currentAirportInfo.staff[5].info[1];
            staffInfoContent52.Text = currentAirportInfo.staff[5].info[2];
            staffInfoContent53.Text = currentAirportInfo.staff[5].info[3];
            staffInfoContent54.Text = currentAirportInfo.staff[5].info[4];
            staffInfoContent60.Text = currentAirportInfo.staff[6].info[0];
            staffInfoContent61.Text = currentAirportInfo.staff[6].info[1];
            staffInfoContent62.Text = currentAirportInfo.staff[6].info[2];
            staffInfoContent63.Text = currentAirportInfo.staff[6].info[3];
            staffInfoContent64.Text = currentAirportInfo.staff[6].info[4];
            staffInfoContent70.Text = currentAirportInfo.staff[7].info[0];
            staffInfoContent71.Text = currentAirportInfo.staff[7].info[1];
            staffInfoContent72.Text = currentAirportInfo.staff[7].info[2];
            staffInfoContent73.Text = currentAirportInfo.staff[7].info[3];
            staffInfoContent74.Text = currentAirportInfo.staff[7].info[4];
            staffInfoContent80.Text = currentAirportInfo.staff[8].info[0];
            staffInfoContent81.Text = currentAirportInfo.staff[8].info[1];
            staffInfoContent82.Text = currentAirportInfo.staff[8].info[2];
            staffInfoContent83.Text = currentAirportInfo.staff[8].info[3];
            staffInfoContent84.Text = currentAirportInfo.staff[8].info[4];
            staffInfoContent90.Text = currentAirportInfo.staff[9].info[0];
            staffInfoContent91.Text = currentAirportInfo.staff[9].info[1];
            staffInfoContent92.Text = currentAirportInfo.staff[9].info[2];
            staffInfoContent93.Text = currentAirportInfo.staff[9].info[3];
            staffInfoContent94.Text = currentAirportInfo.staff[9].info[4];
            staffInfoContent100.Text = currentAirportInfo.staff[10].info[0];
            staffInfoContent101.Text = currentAirportInfo.staff[10].info[1];
            staffInfoContent102.Text = currentAirportInfo.staff[10].info[2];
            staffInfoContent103.Text = currentAirportInfo.staff[10].info[3];
            staffInfoContent104.Text = currentAirportInfo.staff[10].info[4];
            staffInfoContent110.Text = currentAirportInfo.staff[11].info[0];
            staffInfoContent111.Text = currentAirportInfo.staff[11].info[1];
            staffInfoContent112.Text = currentAirportInfo.staff[11].info[2];
            staffInfoContent113.Text = currentAirportInfo.staff[11].info[3];
            staffInfoContent114.Text = currentAirportInfo.staff[11].info[4];
            #endregion

            //cooperation info
            #region
            cooperationInfoContent00.Text = currentAirportInfo.cooperation[0].info[0];
            cooperationInfoContent01.Text = currentAirportInfo.cooperation[0].info[1];
            cooperationInfoContent02.Text = currentAirportInfo.cooperation[0].info[2];
            cooperationInfoContent03.Text = currentAirportInfo.cooperation[0].info[3];
            cooperationInfoContent04.Text = currentAirportInfo.cooperation[0].info[4];
            cooperationInfoContent10.Text = currentAirportInfo.cooperation[1].info[0];
            cooperationInfoContent11.Text = currentAirportInfo.cooperation[1].info[1];
            cooperationInfoContent12.Text = currentAirportInfo.cooperation[1].info[2];
            cooperationInfoContent13.Text = currentAirportInfo.cooperation[1].info[3];
            cooperationInfoContent14.Text = currentAirportInfo.cooperation[1].info[4];
            cooperationInfoContent20.Text = currentAirportInfo.cooperation[2].info[0];
            cooperationInfoContent21.Text = currentAirportInfo.cooperation[2].info[1];
            cooperationInfoContent22.Text = currentAirportInfo.cooperation[2].info[2];
            cooperationInfoContent23.Text = currentAirportInfo.cooperation[2].info[3];
            cooperationInfoContent24.Text = currentAirportInfo.cooperation[2].info[4];
            cooperationInfoContent30.Text = currentAirportInfo.cooperation[3].info[0];
            cooperationInfoContent31.Text = currentAirportInfo.cooperation[3].info[1];
            cooperationInfoContent32.Text = currentAirportInfo.cooperation[3].info[2];
            cooperationInfoContent33.Text = currentAirportInfo.cooperation[3].info[3];
            cooperationInfoContent34.Text = currentAirportInfo.cooperation[3].info[4];
            cooperationInfoContent40.Text = currentAirportInfo.cooperation[4].info[0];
            cooperationInfoContent41.Text = currentAirportInfo.cooperation[4].info[1];
            cooperationInfoContent42.Text = currentAirportInfo.cooperation[4].info[2];
            cooperationInfoContent43.Text = currentAirportInfo.cooperation[4].info[3];
            cooperationInfoContent44.Text = currentAirportInfo.cooperation[4].info[4];
            cooperationInfoContent50.Text = currentAirportInfo.cooperation[5].info[0];
            cooperationInfoContent51.Text = currentAirportInfo.cooperation[5].info[1];
            cooperationInfoContent52.Text = currentAirportInfo.cooperation[5].info[2];
            cooperationInfoContent53.Text = currentAirportInfo.cooperation[5].info[3];
            cooperationInfoContent54.Text = currentAirportInfo.cooperation[5].info[4];
            cooperationInfoContent60.Text = currentAirportInfo.cooperation[6].info[0];
            cooperationInfoContent61.Text = currentAirportInfo.cooperation[6].info[1];
            cooperationInfoContent62.Text = currentAirportInfo.cooperation[6].info[2];
            cooperationInfoContent63.Text = currentAirportInfo.cooperation[6].info[3];
            cooperationInfoContent64.Text = currentAirportInfo.cooperation[6].info[4];
            cooperationInfoContent70.Text = currentAirportInfo.cooperation[7].info[0];
            cooperationInfoContent71.Text = currentAirportInfo.cooperation[7].info[1];
            cooperationInfoContent72.Text = currentAirportInfo.cooperation[7].info[2];
            cooperationInfoContent73.Text = currentAirportInfo.cooperation[7].info[3];
            cooperationInfoContent74.Text = currentAirportInfo.cooperation[7].info[4];
            cooperationInfoContent80.Text = currentAirportInfo.cooperation[8].info[0];
            cooperationInfoContent81.Text = currentAirportInfo.cooperation[8].info[1];
            cooperationInfoContent82.Text = currentAirportInfo.cooperation[8].info[2];
            cooperationInfoContent83.Text = currentAirportInfo.cooperation[8].info[3];
            cooperationInfoContent84.Text = currentAirportInfo.cooperation[8].info[4];
            cooperationInfoContent90.Text = currentAirportInfo.cooperation[9].info[0];
            cooperationInfoContent91.Text = currentAirportInfo.cooperation[9].info[1];
            cooperationInfoContent92.Text = currentAirportInfo.cooperation[9].info[2];
            cooperationInfoContent93.Text = currentAirportInfo.cooperation[9].info[3];
            cooperationInfoContent94.Text = currentAirportInfo.cooperation[9].info[4];
            cooperationInfoContent100.Text = currentAirportInfo.cooperation[10].info[0];
            cooperationInfoContent101.Text = currentAirportInfo.cooperation[10].info[1];
            cooperationInfoContent102.Text = currentAirportInfo.cooperation[10].info[2];
            cooperationInfoContent103.Text = currentAirportInfo.cooperation[10].info[3];
            cooperationInfoContent104.Text = currentAirportInfo.cooperation[10].info[4];
            cooperationInfoContent110.Text = currentAirportInfo.cooperation[11].info[0];
            cooperationInfoContent111.Text = currentAirportInfo.cooperation[11].info[1];
            cooperationInfoContent112.Text = currentAirportInfo.cooperation[11].info[2];
            cooperationInfoContent113.Text = currentAirportInfo.cooperation[11].info[3];
            cooperationInfoContent114.Text = currentAirportInfo.cooperation[11].info[4];
            cooperationInfoContent120.Text = currentAirportInfo.cooperation[12].info[0];
            cooperationInfoContent121.Text = currentAirportInfo.cooperation[12].info[1];
            cooperationInfoContent122.Text = currentAirportInfo.cooperation[12].info[2];
            cooperationInfoContent123.Text = currentAirportInfo.cooperation[12].info[3];
            cooperationInfoContent124.Text = currentAirportInfo.cooperation[12].info[4];
            cooperationInfoContent130.Text = currentAirportInfo.cooperation[13].info[0];
            cooperationInfoContent131.Text = currentAirportInfo.cooperation[13].info[1];
            cooperationInfoContent132.Text = currentAirportInfo.cooperation[13].info[2];
            cooperationInfoContent133.Text = currentAirportInfo.cooperation[13].info[3];
            cooperationInfoContent134.Text = currentAirportInfo.cooperation[13].info[4];
            cooperationInfoContent140.Text = currentAirportInfo.cooperation[14].info[0];
            cooperationInfoContent141.Text = currentAirportInfo.cooperation[14].info[1];
            cooperationInfoContent142.Text = currentAirportInfo.cooperation[14].info[2];
            cooperationInfoContent143.Text = currentAirportInfo.cooperation[14].info[3];
            cooperationInfoContent144.Text = currentAirportInfo.cooperation[14].info[4];
            cooperationInfoContent150.Text = currentAirportInfo.cooperation[15].info[0];
            cooperationInfoContent151.Text = currentAirportInfo.cooperation[15].info[1];
            cooperationInfoContent152.Text = currentAirportInfo.cooperation[15].info[2];
            cooperationInfoContent153.Text = currentAirportInfo.cooperation[15].info[3];
            cooperationInfoContent154.Text = currentAirportInfo.cooperation[15].info[4];
            cooperationInfoContent160.Text = currentAirportInfo.cooperation[16].info[0];
            cooperationInfoContent161.Text = currentAirportInfo.cooperation[16].info[1];
            cooperationInfoContent162.Text = currentAirportInfo.cooperation[16].info[2];
            cooperationInfoContent163.Text = currentAirportInfo.cooperation[16].info[3];
            cooperationInfoContent164.Text = currentAirportInfo.cooperation[16].info[4];
            cooperationInfoContent170.Text = currentAirportInfo.cooperation[17].info[0];
            cooperationInfoContent171.Text = currentAirportInfo.cooperation[17].info[1];
            cooperationInfoContent172.Text = currentAirportInfo.cooperation[17].info[2];
            cooperationInfoContent173.Text = currentAirportInfo.cooperation[17].info[3];
            cooperationInfoContent174.Text = currentAirportInfo.cooperation[17].info[4];
            cooperationInfoContent180.Text = currentAirportInfo.cooperation[18].info[0];
            cooperationInfoContent181.Text = currentAirportInfo.cooperation[18].info[1];
            cooperationInfoContent182.Text = currentAirportInfo.cooperation[18].info[2];
            cooperationInfoContent183.Text = currentAirportInfo.cooperation[18].info[3];
            cooperationInfoContent184.Text = currentAirportInfo.cooperation[18].info[4];
            cooperationInfoContent190.Text = currentAirportInfo.cooperation[19].info[0];
            cooperationInfoContent191.Text = currentAirportInfo.cooperation[19].info[1];
            cooperationInfoContent192.Text = currentAirportInfo.cooperation[19].info[2];
            cooperationInfoContent193.Text = currentAirportInfo.cooperation[19].info[3];
            cooperationInfoContent194.Text = currentAirportInfo.cooperation[19].info[4];
            #endregion

            //equipment info
            #region
            equipmentInfoContent000.Text = currentAirportInfo.naviEquipment[0].info[00];
            equipmentInfoContent001.Text = currentAirportInfo.naviEquipment[0].info[01];
            equipmentInfoContent002.Text = currentAirportInfo.naviEquipment[0].info[02];
            equipmentInfoContent003.Text = currentAirportInfo.naviEquipment[0].info[03];
            equipmentInfoContent004.Text = currentAirportInfo.naviEquipment[0].info[04];
            equipmentInfoContent005.Text = currentAirportInfo.naviEquipment[0].info[05];
            equipmentInfoContent006.Text = currentAirportInfo.naviEquipment[0].info[06];
            equipmentInfoContent007.Text = currentAirportInfo.naviEquipment[0].info[07];
            equipmentInfoContent008.Text = currentAirportInfo.naviEquipment[0].info[08];
            equipmentInfoContent009.Text = currentAirportInfo.naviEquipment[0].info[09];
            equipmentInfoContent010.Text = currentAirportInfo.naviEquipment[0].info[10];
            equipmentInfoContent011.Text = currentAirportInfo.naviEquipment[0].info[11];
            equipmentInfoContent012.Text = currentAirportInfo.naviEquipment[0].info[12];
            equipmentInfoContent100.Text = currentAirportInfo.naviEquipment[1].info[00];
            equipmentInfoContent101.Text = currentAirportInfo.naviEquipment[1].info[01];
            equipmentInfoContent102.Text = currentAirportInfo.naviEquipment[1].info[02];
            equipmentInfoContent103.Text = currentAirportInfo.naviEquipment[1].info[03];
            equipmentInfoContent104.Text = currentAirportInfo.naviEquipment[1].info[04];
            equipmentInfoContent105.Text = currentAirportInfo.naviEquipment[1].info[05];
            equipmentInfoContent106.Text = currentAirportInfo.naviEquipment[1].info[06];
            equipmentInfoContent107.Text = currentAirportInfo.naviEquipment[1].info[07];
            equipmentInfoContent108.Text = currentAirportInfo.naviEquipment[1].info[08];
            equipmentInfoContent109.Text = currentAirportInfo.naviEquipment[1].info[09];
            equipmentInfoContent110.Text = currentAirportInfo.naviEquipment[1].info[10];
            equipmentInfoContent111.Text = currentAirportInfo.naviEquipment[1].info[11];
            equipmentInfoContent112.Text = currentAirportInfo.naviEquipment[1].info[12];
            equipmentInfoContent200.Text = currentAirportInfo.naviEquipment[2].info[00];
            equipmentInfoContent201.Text = currentAirportInfo.naviEquipment[2].info[01];
            equipmentInfoContent202.Text = currentAirportInfo.naviEquipment[2].info[02];
            equipmentInfoContent203.Text = currentAirportInfo.naviEquipment[2].info[03];
            equipmentInfoContent204.Text = currentAirportInfo.naviEquipment[2].info[04];
            equipmentInfoContent205.Text = currentAirportInfo.naviEquipment[2].info[05];
            equipmentInfoContent206.Text = currentAirportInfo.naviEquipment[2].info[06];
            equipmentInfoContent207.Text = currentAirportInfo.naviEquipment[2].info[07];
            equipmentInfoContent208.Text = currentAirportInfo.naviEquipment[2].info[08];
            equipmentInfoContent209.Text = currentAirportInfo.naviEquipment[2].info[09];
            equipmentInfoContent210.Text = currentAirportInfo.naviEquipment[2].info[10];
            equipmentInfoContent211.Text = currentAirportInfo.naviEquipment[2].info[11];
            equipmentInfoContent212.Text = currentAirportInfo.naviEquipment[2].info[12];
            equipmentInfoContent300.Text = currentAirportInfo.naviEquipment[3].info[00];
            equipmentInfoContent301.Text = currentAirportInfo.naviEquipment[3].info[01];
            equipmentInfoContent302.Text = currentAirportInfo.naviEquipment[3].info[02];
            equipmentInfoContent303.Text = currentAirportInfo.naviEquipment[3].info[03];
            equipmentInfoContent304.Text = currentAirportInfo.naviEquipment[3].info[04];
            equipmentInfoContent305.Text = currentAirportInfo.naviEquipment[3].info[05];
            equipmentInfoContent306.Text = currentAirportInfo.naviEquipment[3].info[06];
            equipmentInfoContent307.Text = currentAirportInfo.naviEquipment[3].info[07];
            equipmentInfoContent308.Text = currentAirportInfo.naviEquipment[3].info[08];
            equipmentInfoContent309.Text = currentAirportInfo.naviEquipment[3].info[09];
            equipmentInfoContent310.Text = currentAirportInfo.naviEquipment[3].info[10];
            equipmentInfoContent311.Text = currentAirportInfo.naviEquipment[3].info[11];
            equipmentInfoContent312.Text = currentAirportInfo.naviEquipment[3].info[12];
            equipmentInfoContent400.Text = currentAirportInfo.naviEquipment[4].info[00];
            equipmentInfoContent401.Text = currentAirportInfo.naviEquipment[4].info[01];
            equipmentInfoContent402.Text = currentAirportInfo.naviEquipment[4].info[02];
            equipmentInfoContent403.Text = currentAirportInfo.naviEquipment[4].info[03];
            equipmentInfoContent404.Text = currentAirportInfo.naviEquipment[4].info[04];
            equipmentInfoContent405.Text = currentAirportInfo.naviEquipment[4].info[05];
            equipmentInfoContent406.Text = currentAirportInfo.naviEquipment[4].info[06];
            equipmentInfoContent407.Text = currentAirportInfo.naviEquipment[4].info[07];
            equipmentInfoContent408.Text = currentAirportInfo.naviEquipment[4].info[08];
            equipmentInfoContent409.Text = currentAirportInfo.naviEquipment[4].info[09];
            equipmentInfoContent410.Text = currentAirportInfo.naviEquipment[4].info[10];
            equipmentInfoContent411.Text = currentAirportInfo.naviEquipment[4].info[11];
            equipmentInfoContent412.Text = currentAirportInfo.naviEquipment[4].info[12];
            equipmentInfoContent500.Text = currentAirportInfo.naviEquipment[5].info[00];
            equipmentInfoContent501.Text = currentAirportInfo.naviEquipment[5].info[01];
            equipmentInfoContent502.Text = currentAirportInfo.naviEquipment[5].info[02];
            equipmentInfoContent503.Text = currentAirportInfo.naviEquipment[5].info[03];
            equipmentInfoContent504.Text = currentAirportInfo.naviEquipment[5].info[04];
            equipmentInfoContent505.Text = currentAirportInfo.naviEquipment[5].info[05];
            equipmentInfoContent506.Text = currentAirportInfo.naviEquipment[5].info[06];
            equipmentInfoContent507.Text = currentAirportInfo.naviEquipment[5].info[07];
            equipmentInfoContent508.Text = currentAirportInfo.naviEquipment[5].info[08];
            equipmentInfoContent509.Text = currentAirportInfo.naviEquipment[5].info[09];
            equipmentInfoContent510.Text = currentAirportInfo.naviEquipment[5].info[10];
            equipmentInfoContent511.Text = currentAirportInfo.naviEquipment[5].info[11];
            equipmentInfoContent512.Text = currentAirportInfo.naviEquipment[5].info[12];
            equipmentInfoContent600.Text = currentAirportInfo.naviEquipment[6].info[00];
            equipmentInfoContent601.Text = currentAirportInfo.naviEquipment[6].info[01];
            equipmentInfoContent602.Text = currentAirportInfo.naviEquipment[6].info[02];
            equipmentInfoContent603.Text = currentAirportInfo.naviEquipment[6].info[03];
            equipmentInfoContent604.Text = currentAirportInfo.naviEquipment[6].info[04];
            equipmentInfoContent605.Text = currentAirportInfo.naviEquipment[6].info[05];
            equipmentInfoContent606.Text = currentAirportInfo.naviEquipment[6].info[06];
            equipmentInfoContent607.Text = currentAirportInfo.naviEquipment[6].info[07];
            equipmentInfoContent608.Text = currentAirportInfo.naviEquipment[6].info[08];
            equipmentInfoContent609.Text = currentAirportInfo.naviEquipment[6].info[09];
            equipmentInfoContent610.Text = currentAirportInfo.naviEquipment[6].info[10];
            equipmentInfoContent611.Text = currentAirportInfo.naviEquipment[6].info[11];
            equipmentInfoContent612.Text = currentAirportInfo.naviEquipment[6].info[12];
            equipmentInfoContent700.Text = currentAirportInfo.naviEquipment[7].info[00];
            equipmentInfoContent701.Text = currentAirportInfo.naviEquipment[7].info[01];
            equipmentInfoContent702.Text = currentAirportInfo.naviEquipment[7].info[02];
            equipmentInfoContent703.Text = currentAirportInfo.naviEquipment[7].info[03];
            equipmentInfoContent704.Text = currentAirportInfo.naviEquipment[7].info[04];
            equipmentInfoContent705.Text = currentAirportInfo.naviEquipment[7].info[05];
            equipmentInfoContent706.Text = currentAirportInfo.naviEquipment[7].info[06];
            equipmentInfoContent707.Text = currentAirportInfo.naviEquipment[7].info[07];
            equipmentInfoContent708.Text = currentAirportInfo.naviEquipment[7].info[08];
            equipmentInfoContent709.Text = currentAirportInfo.naviEquipment[7].info[09];
            equipmentInfoContent710.Text = currentAirportInfo.naviEquipment[7].info[10];
            equipmentInfoContent711.Text = currentAirportInfo.naviEquipment[7].info[11];
            equipmentInfoContent712.Text = currentAirportInfo.naviEquipment[7].info[12];
            equipmentInfoContent800.Text = currentAirportInfo.naviEquipment[8].info[00];
            equipmentInfoContent801.Text = currentAirportInfo.naviEquipment[8].info[01];
            equipmentInfoContent802.Text = currentAirportInfo.naviEquipment[8].info[02];
            equipmentInfoContent803.Text = currentAirportInfo.naviEquipment[8].info[03];
            equipmentInfoContent804.Text = currentAirportInfo.naviEquipment[8].info[04];
            equipmentInfoContent805.Text = currentAirportInfo.naviEquipment[8].info[05];
            equipmentInfoContent806.Text = currentAirportInfo.naviEquipment[8].info[06];
            equipmentInfoContent807.Text = currentAirportInfo.naviEquipment[8].info[07];
            equipmentInfoContent808.Text = currentAirportInfo.naviEquipment[8].info[08];
            equipmentInfoContent809.Text = currentAirportInfo.naviEquipment[8].info[09];
            equipmentInfoContent810.Text = currentAirportInfo.naviEquipment[8].info[10];
            equipmentInfoContent811.Text = currentAirportInfo.naviEquipment[8].info[11];
            equipmentInfoContent812.Text = currentAirportInfo.naviEquipment[8].info[12];
            equipmentInfoContent900.Text = currentAirportInfo.naviEquipment[9].info[00];
            equipmentInfoContent901.Text = currentAirportInfo.naviEquipment[9].info[01];
            equipmentInfoContent902.Text = currentAirportInfo.naviEquipment[9].info[02];
            equipmentInfoContent903.Text = currentAirportInfo.naviEquipment[9].info[03];
            equipmentInfoContent904.Text = currentAirportInfo.naviEquipment[9].info[04];
            equipmentInfoContent905.Text = currentAirportInfo.naviEquipment[9].info[05];
            equipmentInfoContent906.Text = currentAirportInfo.naviEquipment[9].info[06];
            equipmentInfoContent907.Text = currentAirportInfo.naviEquipment[9].info[07];
            equipmentInfoContent908.Text = currentAirportInfo.naviEquipment[9].info[08];
            equipmentInfoContent909.Text = currentAirportInfo.naviEquipment[9].info[09];
            equipmentInfoContent910.Text = currentAirportInfo.naviEquipment[9].info[10];
            equipmentInfoContent911.Text = currentAirportInfo.naviEquipment[9].info[11];
            equipmentInfoContent912.Text = currentAirportInfo.naviEquipment[9].info[12];
            equipmentInfoContent1000.Text = currentAirportInfo.naviEquipment[10].info[00];
            equipmentInfoContent1001.Text = currentAirportInfo.naviEquipment[10].info[01];
            equipmentInfoContent1002.Text = currentAirportInfo.naviEquipment[10].info[02];
            equipmentInfoContent1003.Text = currentAirportInfo.naviEquipment[10].info[03];
            equipmentInfoContent1004.Text = currentAirportInfo.naviEquipment[10].info[04];
            equipmentInfoContent1005.Text = currentAirportInfo.naviEquipment[10].info[05];
            equipmentInfoContent1006.Text = currentAirportInfo.naviEquipment[10].info[06];
            equipmentInfoContent1007.Text = currentAirportInfo.naviEquipment[10].info[07];
            equipmentInfoContent1008.Text = currentAirportInfo.naviEquipment[10].info[08];
            equipmentInfoContent1009.Text = currentAirportInfo.naviEquipment[10].info[09];
            equipmentInfoContent1010.Text = currentAirportInfo.naviEquipment[10].info[10];
            equipmentInfoContent1011.Text = currentAirportInfo.naviEquipment[10].info[11];
            equipmentInfoContent1012.Text = currentAirportInfo.naviEquipment[10].info[12];
            equipmentInfoContent1100.Text = currentAirportInfo.naviEquipment[11].info[00];
            equipmentInfoContent1101.Text = currentAirportInfo.naviEquipment[11].info[01];
            equipmentInfoContent1102.Text = currentAirportInfo.naviEquipment[11].info[02];
            equipmentInfoContent1103.Text = currentAirportInfo.naviEquipment[11].info[03];
            equipmentInfoContent1104.Text = currentAirportInfo.naviEquipment[11].info[04];
            equipmentInfoContent1105.Text = currentAirportInfo.naviEquipment[11].info[05];
            equipmentInfoContent1106.Text = currentAirportInfo.naviEquipment[11].info[06];
            equipmentInfoContent1107.Text = currentAirportInfo.naviEquipment[11].info[07];
            equipmentInfoContent1108.Text = currentAirportInfo.naviEquipment[11].info[08];
            equipmentInfoContent1109.Text = currentAirportInfo.naviEquipment[11].info[09];
            equipmentInfoContent1110.Text = currentAirportInfo.naviEquipment[11].info[10];
            equipmentInfoContent1111.Text = currentAirportInfo.naviEquipment[11].info[11];
            equipmentInfoContent1112.Text = currentAirportInfo.naviEquipment[11].info[12];
            equipmentInfoContent1200.Text = currentAirportInfo.naviEquipment[12].info[00];
            equipmentInfoContent1201.Text = currentAirportInfo.naviEquipment[12].info[01];
            equipmentInfoContent1202.Text = currentAirportInfo.naviEquipment[12].info[02];
            equipmentInfoContent1203.Text = currentAirportInfo.naviEquipment[12].info[03];
            equipmentInfoContent1204.Text = currentAirportInfo.naviEquipment[12].info[04];
            equipmentInfoContent1205.Text = currentAirportInfo.naviEquipment[12].info[05];
            equipmentInfoContent1206.Text = currentAirportInfo.naviEquipment[12].info[06];
            equipmentInfoContent1207.Text = currentAirportInfo.naviEquipment[12].info[07];
            equipmentInfoContent1208.Text = currentAirportInfo.naviEquipment[12].info[08];
            equipmentInfoContent1209.Text = currentAirportInfo.naviEquipment[12].info[09];
            equipmentInfoContent1210.Text = currentAirportInfo.naviEquipment[12].info[10];
            equipmentInfoContent1211.Text = currentAirportInfo.naviEquipment[12].info[11];
            equipmentInfoContent1212.Text = currentAirportInfo.naviEquipment[12].info[12];
            equipmentInfoContent1300.Text = currentAirportInfo.naviEquipment[13].info[00];
            equipmentInfoContent1301.Text = currentAirportInfo.naviEquipment[13].info[01];
            equipmentInfoContent1302.Text = currentAirportInfo.naviEquipment[13].info[02];
            equipmentInfoContent1303.Text = currentAirportInfo.naviEquipment[13].info[03];
            equipmentInfoContent1304.Text = currentAirportInfo.naviEquipment[13].info[04];
            equipmentInfoContent1305.Text = currentAirportInfo.naviEquipment[13].info[05];
            equipmentInfoContent1306.Text = currentAirportInfo.naviEquipment[13].info[06];
            equipmentInfoContent1307.Text = currentAirportInfo.naviEquipment[13].info[07];
            equipmentInfoContent1308.Text = currentAirportInfo.naviEquipment[13].info[08];
            equipmentInfoContent1309.Text = currentAirportInfo.naviEquipment[13].info[09];
            equipmentInfoContent1310.Text = currentAirportInfo.naviEquipment[13].info[10];
            equipmentInfoContent1311.Text = currentAirportInfo.naviEquipment[13].info[11];
            equipmentInfoContent1312.Text = currentAirportInfo.naviEquipment[13].info[12];
            equipmentInfoContent1400.Text = currentAirportInfo.naviEquipment[14].info[00];
            equipmentInfoContent1401.Text = currentAirportInfo.naviEquipment[14].info[01];
            equipmentInfoContent1402.Text = currentAirportInfo.naviEquipment[14].info[02];
            equipmentInfoContent1403.Text = currentAirportInfo.naviEquipment[14].info[03];
            equipmentInfoContent1404.Text = currentAirportInfo.naviEquipment[14].info[04];
            equipmentInfoContent1405.Text = currentAirportInfo.naviEquipment[14].info[05];
            equipmentInfoContent1406.Text = currentAirportInfo.naviEquipment[14].info[06];
            equipmentInfoContent1407.Text = currentAirportInfo.naviEquipment[14].info[07];
            equipmentInfoContent1408.Text = currentAirportInfo.naviEquipment[14].info[08];
            equipmentInfoContent1409.Text = currentAirportInfo.naviEquipment[14].info[09];
            equipmentInfoContent1410.Text = currentAirportInfo.naviEquipment[14].info[10];
            equipmentInfoContent1411.Text = currentAirportInfo.naviEquipment[14].info[11];
            equipmentInfoContent1412.Text = currentAirportInfo.naviEquipment[14].info[12];
            equipmentInfoContent1500.Text = currentAirportInfo.naviEquipment[15].info[00];
            equipmentInfoContent1501.Text = currentAirportInfo.naviEquipment[15].info[01];
            equipmentInfoContent1502.Text = currentAirportInfo.naviEquipment[15].info[02];
            equipmentInfoContent1503.Text = currentAirportInfo.naviEquipment[15].info[03];
            equipmentInfoContent1504.Text = currentAirportInfo.naviEquipment[15].info[04];
            equipmentInfoContent1505.Text = currentAirportInfo.naviEquipment[15].info[05];
            equipmentInfoContent1506.Text = currentAirportInfo.naviEquipment[15].info[06];
            equipmentInfoContent1507.Text = currentAirportInfo.naviEquipment[15].info[07];
            equipmentInfoContent1508.Text = currentAirportInfo.naviEquipment[15].info[08];
            equipmentInfoContent1509.Text = currentAirportInfo.naviEquipment[15].info[09];
            equipmentInfoContent1510.Text = currentAirportInfo.naviEquipment[15].info[10];
            equipmentInfoContent1511.Text = currentAirportInfo.naviEquipment[15].info[11];
            equipmentInfoContent1512.Text = currentAirportInfo.naviEquipment[15].info[12];
            equipmentInfoContent1600.Text = currentAirportInfo.naviEquipment[16].info[00];
            equipmentInfoContent1601.Text = currentAirportInfo.naviEquipment[16].info[01];
            equipmentInfoContent1602.Text = currentAirportInfo.naviEquipment[16].info[02];
            equipmentInfoContent1603.Text = currentAirportInfo.naviEquipment[16].info[03];
            equipmentInfoContent1604.Text = currentAirportInfo.naviEquipment[16].info[04];
            equipmentInfoContent1605.Text = currentAirportInfo.naviEquipment[16].info[05];
            equipmentInfoContent1606.Text = currentAirportInfo.naviEquipment[16].info[06];
            equipmentInfoContent1607.Text = currentAirportInfo.naviEquipment[16].info[07];
            equipmentInfoContent1608.Text = currentAirportInfo.naviEquipment[16].info[08];
            equipmentInfoContent1609.Text = currentAirportInfo.naviEquipment[16].info[09];
            equipmentInfoContent1610.Text = currentAirportInfo.naviEquipment[16].info[10];
            equipmentInfoContent1611.Text = currentAirportInfo.naviEquipment[16].info[11];
            equipmentInfoContent1612.Text = currentAirportInfo.naviEquipment[16].info[12];
            equipmentInfoContent1700.Text = currentAirportInfo.naviEquipment[17].info[00];
            equipmentInfoContent1701.Text = currentAirportInfo.naviEquipment[17].info[01];
            equipmentInfoContent1702.Text = currentAirportInfo.naviEquipment[17].info[02];
            equipmentInfoContent1703.Text = currentAirportInfo.naviEquipment[17].info[03];
            equipmentInfoContent1704.Text = currentAirportInfo.naviEquipment[17].info[04];
            equipmentInfoContent1705.Text = currentAirportInfo.naviEquipment[17].info[05];
            equipmentInfoContent1706.Text = currentAirportInfo.naviEquipment[17].info[06];
            equipmentInfoContent1707.Text = currentAirportInfo.naviEquipment[17].info[07];
            equipmentInfoContent1708.Text = currentAirportInfo.naviEquipment[17].info[08];
            equipmentInfoContent1709.Text = currentAirportInfo.naviEquipment[17].info[09];
            equipmentInfoContent1710.Text = currentAirportInfo.naviEquipment[17].info[10];
            equipmentInfoContent1711.Text = currentAirportInfo.naviEquipment[17].info[11];
            equipmentInfoContent1712.Text = currentAirportInfo.naviEquipment[17].info[12];
            equipmentInfoContent1800.Text = currentAirportInfo.naviEquipment[18].info[00];
            equipmentInfoContent1801.Text = currentAirportInfo.naviEquipment[18].info[01];
            equipmentInfoContent1802.Text = currentAirportInfo.naviEquipment[18].info[02];
            equipmentInfoContent1803.Text = currentAirportInfo.naviEquipment[18].info[03];
            equipmentInfoContent1804.Text = currentAirportInfo.naviEquipment[18].info[04];
            equipmentInfoContent1805.Text = currentAirportInfo.naviEquipment[18].info[05];
            equipmentInfoContent1806.Text = currentAirportInfo.naviEquipment[18].info[06];
            equipmentInfoContent1807.Text = currentAirportInfo.naviEquipment[18].info[07];
            equipmentInfoContent1808.Text = currentAirportInfo.naviEquipment[18].info[08];
            equipmentInfoContent1809.Text = currentAirportInfo.naviEquipment[18].info[09];
            equipmentInfoContent1810.Text = currentAirportInfo.naviEquipment[18].info[10];
            equipmentInfoContent1811.Text = currentAirportInfo.naviEquipment[18].info[11];
            equipmentInfoContent1812.Text = currentAirportInfo.naviEquipment[18].info[12];
            equipmentInfoContent1900.Text = currentAirportInfo.naviEquipment[19].info[00];
            equipmentInfoContent1901.Text = currentAirportInfo.naviEquipment[19].info[01];
            equipmentInfoContent1902.Text = currentAirportInfo.naviEquipment[19].info[02];
            equipmentInfoContent1903.Text = currentAirportInfo.naviEquipment[19].info[03];
            equipmentInfoContent1904.Text = currentAirportInfo.naviEquipment[19].info[04];
            equipmentInfoContent1905.Text = currentAirportInfo.naviEquipment[19].info[05];
            equipmentInfoContent1906.Text = currentAirportInfo.naviEquipment[19].info[06];
            equipmentInfoContent1907.Text = currentAirportInfo.naviEquipment[19].info[07];
            equipmentInfoContent1908.Text = currentAirportInfo.naviEquipment[19].info[08];
            equipmentInfoContent1909.Text = currentAirportInfo.naviEquipment[19].info[09];
            equipmentInfoContent1910.Text = currentAirportInfo.naviEquipment[19].info[10];
            equipmentInfoContent1911.Text = currentAirportInfo.naviEquipment[19].info[11];
            equipmentInfoContent1912.Text = currentAirportInfo.naviEquipment[19].info[12];
            equipmentInfoContent2000.Text = currentAirportInfo.naviEquipment[20].info[00];
            equipmentInfoContent2001.Text = currentAirportInfo.naviEquipment[20].info[01];
            equipmentInfoContent2002.Text = currentAirportInfo.naviEquipment[20].info[02];
            equipmentInfoContent2003.Text = currentAirportInfo.naviEquipment[20].info[03];
            equipmentInfoContent2004.Text = currentAirportInfo.naviEquipment[20].info[04];
            equipmentInfoContent2005.Text = currentAirportInfo.naviEquipment[20].info[05];
            equipmentInfoContent2006.Text = currentAirportInfo.naviEquipment[20].info[06];
            equipmentInfoContent2007.Text = currentAirportInfo.naviEquipment[20].info[07];
            equipmentInfoContent2008.Text = currentAirportInfo.naviEquipment[20].info[08];
            equipmentInfoContent2009.Text = currentAirportInfo.naviEquipment[20].info[09];
            equipmentInfoContent2010.Text = currentAirportInfo.naviEquipment[20].info[10];
            equipmentInfoContent2011.Text = currentAirportInfo.naviEquipment[20].info[11];
            equipmentInfoContent2012.Text = currentAirportInfo.naviEquipment[20].info[12];
            equipmentInfoContent2100.Text = currentAirportInfo.naviEquipment[21].info[00];
            equipmentInfoContent2101.Text = currentAirportInfo.naviEquipment[21].info[01];
            equipmentInfoContent2102.Text = currentAirportInfo.naviEquipment[21].info[02];
            equipmentInfoContent2103.Text = currentAirportInfo.naviEquipment[21].info[03];
            equipmentInfoContent2104.Text = currentAirportInfo.naviEquipment[21].info[04];
            equipmentInfoContent2105.Text = currentAirportInfo.naviEquipment[21].info[05];
            equipmentInfoContent2106.Text = currentAirportInfo.naviEquipment[21].info[06];
            equipmentInfoContent2107.Text = currentAirportInfo.naviEquipment[21].info[07];
            equipmentInfoContent2108.Text = currentAirportInfo.naviEquipment[21].info[08];
            equipmentInfoContent2109.Text = currentAirportInfo.naviEquipment[21].info[09];
            equipmentInfoContent2110.Text = currentAirportInfo.naviEquipment[21].info[10];
            equipmentInfoContent2111.Text = currentAirportInfo.naviEquipment[21].info[11];
            equipmentInfoContent2112.Text = currentAirportInfo.naviEquipment[21].info[12];
            equipmentInfoContent2200.Text = currentAirportInfo.naviEquipment[22].info[00];
            equipmentInfoContent2201.Text = currentAirportInfo.naviEquipment[22].info[01];
            equipmentInfoContent2202.Text = currentAirportInfo.naviEquipment[22].info[02];
            equipmentInfoContent2203.Text = currentAirportInfo.naviEquipment[22].info[03];
            equipmentInfoContent2204.Text = currentAirportInfo.naviEquipment[22].info[04];
            equipmentInfoContent2205.Text = currentAirportInfo.naviEquipment[22].info[05];
            equipmentInfoContent2206.Text = currentAirportInfo.naviEquipment[22].info[06];
            equipmentInfoContent2207.Text = currentAirportInfo.naviEquipment[22].info[07];
            equipmentInfoContent2208.Text = currentAirportInfo.naviEquipment[22].info[08];
            equipmentInfoContent2209.Text = currentAirportInfo.naviEquipment[22].info[09];
            equipmentInfoContent2210.Text = currentAirportInfo.naviEquipment[22].info[10];
            equipmentInfoContent2211.Text = currentAirportInfo.naviEquipment[22].info[11];
            equipmentInfoContent2212.Text = currentAirportInfo.naviEquipment[22].info[12];
            equipmentInfoContent2300.Text = currentAirportInfo.naviEquipment[23].info[00];
            equipmentInfoContent2301.Text = currentAirportInfo.naviEquipment[23].info[01];
            equipmentInfoContent2302.Text = currentAirportInfo.naviEquipment[23].info[02];
            equipmentInfoContent2303.Text = currentAirportInfo.naviEquipment[23].info[03];
            equipmentInfoContent2304.Text = currentAirportInfo.naviEquipment[23].info[04];
            equipmentInfoContent2305.Text = currentAirportInfo.naviEquipment[23].info[05];
            equipmentInfoContent2306.Text = currentAirportInfo.naviEquipment[23].info[06];
            equipmentInfoContent2307.Text = currentAirportInfo.naviEquipment[23].info[07];
            equipmentInfoContent2308.Text = currentAirportInfo.naviEquipment[23].info[08];
            equipmentInfoContent2309.Text = currentAirportInfo.naviEquipment[23].info[09];
            equipmentInfoContent2310.Text = currentAirportInfo.naviEquipment[23].info[10];
            equipmentInfoContent2311.Text = currentAirportInfo.naviEquipment[23].info[11];
            equipmentInfoContent2312.Text = currentAirportInfo.naviEquipment[23].info[12];
            equipmentInfoContent2400.Text = currentAirportInfo.naviEquipment[24].info[00];
            equipmentInfoContent2401.Text = currentAirportInfo.naviEquipment[24].info[01];
            equipmentInfoContent2402.Text = currentAirportInfo.naviEquipment[24].info[02];
            equipmentInfoContent2403.Text = currentAirportInfo.naviEquipment[24].info[03];
            equipmentInfoContent2404.Text = currentAirportInfo.naviEquipment[24].info[04];
            equipmentInfoContent2405.Text = currentAirportInfo.naviEquipment[24].info[05];
            equipmentInfoContent2406.Text = currentAirportInfo.naviEquipment[24].info[06];
            equipmentInfoContent2407.Text = currentAirportInfo.naviEquipment[24].info[07];
            equipmentInfoContent2408.Text = currentAirportInfo.naviEquipment[24].info[08];
            equipmentInfoContent2409.Text = currentAirportInfo.naviEquipment[24].info[09];
            equipmentInfoContent2410.Text = currentAirportInfo.naviEquipment[24].info[10];
            equipmentInfoContent2411.Text = currentAirportInfo.naviEquipment[24].info[11];
            equipmentInfoContent2412.Text = currentAirportInfo.naviEquipment[24].info[12];
            equipmentInfoContent2500.Text = currentAirportInfo.naviEquipment[25].info[00];
            equipmentInfoContent2501.Text = currentAirportInfo.naviEquipment[25].info[01];
            equipmentInfoContent2502.Text = currentAirportInfo.naviEquipment[25].info[02];
            equipmentInfoContent2503.Text = currentAirportInfo.naviEquipment[25].info[03];
            equipmentInfoContent2504.Text = currentAirportInfo.naviEquipment[25].info[04];
            equipmentInfoContent2505.Text = currentAirportInfo.naviEquipment[25].info[05];
            equipmentInfoContent2506.Text = currentAirportInfo.naviEquipment[25].info[06];
            equipmentInfoContent2507.Text = currentAirportInfo.naviEquipment[25].info[07];
            equipmentInfoContent2508.Text = currentAirportInfo.naviEquipment[25].info[08];
            equipmentInfoContent2509.Text = currentAirportInfo.naviEquipment[25].info[09];
            equipmentInfoContent2510.Text = currentAirportInfo.naviEquipment[25].info[10];
            equipmentInfoContent2511.Text = currentAirportInfo.naviEquipment[25].info[11];
            equipmentInfoContent2512.Text = currentAirportInfo.naviEquipment[25].info[12];
            equipmentInfoContent2600.Text = currentAirportInfo.naviEquipment[26].info[00];
            equipmentInfoContent2601.Text = currentAirportInfo.naviEquipment[26].info[01];
            equipmentInfoContent2602.Text = currentAirportInfo.naviEquipment[26].info[02];
            equipmentInfoContent2603.Text = currentAirportInfo.naviEquipment[26].info[03];
            equipmentInfoContent2604.Text = currentAirportInfo.naviEquipment[26].info[04];
            equipmentInfoContent2605.Text = currentAirportInfo.naviEquipment[26].info[05];
            equipmentInfoContent2606.Text = currentAirportInfo.naviEquipment[26].info[06];
            equipmentInfoContent2607.Text = currentAirportInfo.naviEquipment[26].info[07];
            equipmentInfoContent2608.Text = currentAirportInfo.naviEquipment[26].info[08];
            equipmentInfoContent2609.Text = currentAirportInfo.naviEquipment[26].info[09];
            equipmentInfoContent2610.Text = currentAirportInfo.naviEquipment[26].info[10];
            equipmentInfoContent2611.Text = currentAirportInfo.naviEquipment[26].info[11];
            equipmentInfoContent2612.Text = currentAirportInfo.naviEquipment[26].info[12];
            equipmentInfoContent2700.Text = currentAirportInfo.naviEquipment[27].info[00];
            equipmentInfoContent2701.Text = currentAirportInfo.naviEquipment[27].info[01];
            equipmentInfoContent2702.Text = currentAirportInfo.naviEquipment[27].info[02];
            equipmentInfoContent2703.Text = currentAirportInfo.naviEquipment[27].info[03];
            equipmentInfoContent2704.Text = currentAirportInfo.naviEquipment[27].info[04];
            equipmentInfoContent2705.Text = currentAirportInfo.naviEquipment[27].info[05];
            equipmentInfoContent2706.Text = currentAirportInfo.naviEquipment[27].info[06];
            equipmentInfoContent2707.Text = currentAirportInfo.naviEquipment[27].info[07];
            equipmentInfoContent2708.Text = currentAirportInfo.naviEquipment[27].info[08];
            equipmentInfoContent2709.Text = currentAirportInfo.naviEquipment[27].info[09];
            equipmentInfoContent2710.Text = currentAirportInfo.naviEquipment[27].info[10];
            equipmentInfoContent2711.Text = currentAirportInfo.naviEquipment[27].info[11];
            equipmentInfoContent2712.Text = currentAirportInfo.naviEquipment[27].info[12];
            equipmentInfoContent2800.Text = currentAirportInfo.naviEquipment[28].info[00];
            equipmentInfoContent2801.Text = currentAirportInfo.naviEquipment[28].info[01];
            equipmentInfoContent2802.Text = currentAirportInfo.naviEquipment[28].info[02];
            equipmentInfoContent2803.Text = currentAirportInfo.naviEquipment[28].info[03];
            equipmentInfoContent2804.Text = currentAirportInfo.naviEquipment[28].info[04];
            equipmentInfoContent2805.Text = currentAirportInfo.naviEquipment[28].info[05];
            equipmentInfoContent2806.Text = currentAirportInfo.naviEquipment[28].info[06];
            equipmentInfoContent2807.Text = currentAirportInfo.naviEquipment[28].info[07];
            equipmentInfoContent2808.Text = currentAirportInfo.naviEquipment[28].info[08];
            equipmentInfoContent2809.Text = currentAirportInfo.naviEquipment[28].info[09];
            equipmentInfoContent2810.Text = currentAirportInfo.naviEquipment[28].info[10];
            equipmentInfoContent2811.Text = currentAirportInfo.naviEquipment[28].info[11];
            equipmentInfoContent2812.Text = currentAirportInfo.naviEquipment[28].info[12];
            equipmentInfoContent2900.Text = currentAirportInfo.naviEquipment[29].info[00];
            equipmentInfoContent2901.Text = currentAirportInfo.naviEquipment[29].info[01];
            equipmentInfoContent2902.Text = currentAirportInfo.naviEquipment[29].info[02];
            equipmentInfoContent2903.Text = currentAirportInfo.naviEquipment[29].info[03];
            equipmentInfoContent2904.Text = currentAirportInfo.naviEquipment[29].info[04];
            equipmentInfoContent2905.Text = currentAirportInfo.naviEquipment[29].info[05];
            equipmentInfoContent2906.Text = currentAirportInfo.naviEquipment[29].info[06];
            equipmentInfoContent2907.Text = currentAirportInfo.naviEquipment[29].info[07];
            equipmentInfoContent2908.Text = currentAirportInfo.naviEquipment[29].info[08];
            equipmentInfoContent2909.Text = currentAirportInfo.naviEquipment[29].info[09];
            equipmentInfoContent2910.Text = currentAirportInfo.naviEquipment[29].info[10];
            equipmentInfoContent2911.Text = currentAirportInfo.naviEquipment[29].info[11];
            equipmentInfoContent2912.Text = currentAirportInfo.naviEquipment[29].info[12];
            equipmentInfoContent3000.Text = currentAirportInfo.naviEquipment[30].info[00];
            equipmentInfoContent3001.Text = currentAirportInfo.naviEquipment[30].info[01];
            equipmentInfoContent3002.Text = currentAirportInfo.naviEquipment[30].info[02];
            equipmentInfoContent3003.Text = currentAirportInfo.naviEquipment[30].info[03];
            equipmentInfoContent3004.Text = currentAirportInfo.naviEquipment[30].info[04];
            equipmentInfoContent3005.Text = currentAirportInfo.naviEquipment[30].info[05];
            equipmentInfoContent3006.Text = currentAirportInfo.naviEquipment[30].info[06];
            equipmentInfoContent3007.Text = currentAirportInfo.naviEquipment[30].info[07];
            equipmentInfoContent3008.Text = currentAirportInfo.naviEquipment[30].info[08];
            equipmentInfoContent3009.Text = currentAirportInfo.naviEquipment[30].info[09];
            equipmentInfoContent3010.Text = currentAirportInfo.naviEquipment[30].info[10];
            equipmentInfoContent3011.Text = currentAirportInfo.naviEquipment[30].info[11];
            equipmentInfoContent3012.Text = currentAirportInfo.naviEquipment[30].info[12];
            equipmentInfoContent3100.Text = currentAirportInfo.naviEquipment[31].info[00];
            equipmentInfoContent3101.Text = currentAirportInfo.naviEquipment[31].info[01];
            equipmentInfoContent3102.Text = currentAirportInfo.naviEquipment[31].info[02];
            equipmentInfoContent3103.Text = currentAirportInfo.naviEquipment[31].info[03];
            equipmentInfoContent3104.Text = currentAirportInfo.naviEquipment[31].info[04];
            equipmentInfoContent3105.Text = currentAirportInfo.naviEquipment[31].info[05];
            equipmentInfoContent3106.Text = currentAirportInfo.naviEquipment[31].info[06];
            equipmentInfoContent3107.Text = currentAirportInfo.naviEquipment[31].info[07];
            equipmentInfoContent3108.Text = currentAirportInfo.naviEquipment[31].info[08];
            equipmentInfoContent3109.Text = currentAirportInfo.naviEquipment[31].info[09];
            equipmentInfoContent3110.Text = currentAirportInfo.naviEquipment[31].info[10];
            equipmentInfoContent3111.Text = currentAirportInfo.naviEquipment[31].info[11];
            equipmentInfoContent3112.Text = currentAirportInfo.naviEquipment[31].info[12];
            equipmentInfoContent3200.Text = currentAirportInfo.naviEquipment[32].info[00];
            equipmentInfoContent3201.Text = currentAirportInfo.naviEquipment[32].info[01];
            equipmentInfoContent3202.Text = currentAirportInfo.naviEquipment[32].info[02];
            equipmentInfoContent3203.Text = currentAirportInfo.naviEquipment[32].info[03];
            equipmentInfoContent3204.Text = currentAirportInfo.naviEquipment[32].info[04];
            equipmentInfoContent3205.Text = currentAirportInfo.naviEquipment[32].info[05];
            equipmentInfoContent3206.Text = currentAirportInfo.naviEquipment[32].info[06];
            equipmentInfoContent3207.Text = currentAirportInfo.naviEquipment[32].info[07];
            equipmentInfoContent3208.Text = currentAirportInfo.naviEquipment[32].info[08];
            equipmentInfoContent3209.Text = currentAirportInfo.naviEquipment[32].info[09];
            equipmentInfoContent3210.Text = currentAirportInfo.naviEquipment[32].info[10];
            equipmentInfoContent3211.Text = currentAirportInfo.naviEquipment[32].info[11];
            equipmentInfoContent3212.Text = currentAirportInfo.naviEquipment[32].info[12];
            equipmentInfoContent3300.Text = currentAirportInfo.naviEquipment[33].info[00];
            equipmentInfoContent3301.Text = currentAirportInfo.naviEquipment[33].info[01];
            equipmentInfoContent3302.Text = currentAirportInfo.naviEquipment[33].info[02];
            equipmentInfoContent3303.Text = currentAirportInfo.naviEquipment[33].info[03];
            equipmentInfoContent3304.Text = currentAirportInfo.naviEquipment[33].info[04];
            equipmentInfoContent3305.Text = currentAirportInfo.naviEquipment[33].info[05];
            equipmentInfoContent3306.Text = currentAirportInfo.naviEquipment[33].info[06];
            equipmentInfoContent3307.Text = currentAirportInfo.naviEquipment[33].info[07];
            equipmentInfoContent3308.Text = currentAirportInfo.naviEquipment[33].info[08];
            equipmentInfoContent3309.Text = currentAirportInfo.naviEquipment[33].info[09];
            equipmentInfoContent3310.Text = currentAirportInfo.naviEquipment[33].info[10];
            equipmentInfoContent3311.Text = currentAirportInfo.naviEquipment[33].info[11];
            equipmentInfoContent3312.Text = currentAirportInfo.naviEquipment[33].info[12];
            equipmentInfoContent3400.Text = currentAirportInfo.naviEquipment[34].info[00];
            equipmentInfoContent3401.Text = currentAirportInfo.naviEquipment[34].info[01];
            equipmentInfoContent3402.Text = currentAirportInfo.naviEquipment[34].info[02];
            equipmentInfoContent3403.Text = currentAirportInfo.naviEquipment[34].info[03];
            equipmentInfoContent3404.Text = currentAirportInfo.naviEquipment[34].info[04];
            equipmentInfoContent3405.Text = currentAirportInfo.naviEquipment[34].info[05];
            equipmentInfoContent3406.Text = currentAirportInfo.naviEquipment[34].info[06];
            equipmentInfoContent3407.Text = currentAirportInfo.naviEquipment[34].info[07];
            equipmentInfoContent3408.Text = currentAirportInfo.naviEquipment[34].info[08];
            equipmentInfoContent3409.Text = currentAirportInfo.naviEquipment[34].info[09];
            equipmentInfoContent3410.Text = currentAirportInfo.naviEquipment[34].info[10];
            equipmentInfoContent3411.Text = currentAirportInfo.naviEquipment[34].info[11];
            equipmentInfoContent3412.Text = currentAirportInfo.naviEquipment[34].info[12];
            equipmentInfoContent3500.Text = currentAirportInfo.naviEquipment[35].info[00];
            equipmentInfoContent3501.Text = currentAirportInfo.naviEquipment[35].info[01];
            equipmentInfoContent3502.Text = currentAirportInfo.naviEquipment[35].info[02];
            equipmentInfoContent3503.Text = currentAirportInfo.naviEquipment[35].info[03];
            equipmentInfoContent3504.Text = currentAirportInfo.naviEquipment[35].info[04];
            equipmentInfoContent3505.Text = currentAirportInfo.naviEquipment[35].info[05];
            equipmentInfoContent3506.Text = currentAirportInfo.naviEquipment[35].info[06];
            equipmentInfoContent3507.Text = currentAirportInfo.naviEquipment[35].info[07];
            equipmentInfoContent3508.Text = currentAirportInfo.naviEquipment[35].info[08];
            equipmentInfoContent3509.Text = currentAirportInfo.naviEquipment[35].info[09];
            equipmentInfoContent3510.Text = currentAirportInfo.naviEquipment[35].info[10];
            equipmentInfoContent3511.Text = currentAirportInfo.naviEquipment[35].info[11];
            equipmentInfoContent3512.Text = currentAirportInfo.naviEquipment[35].info[12];
            equipmentInfoContent3600.Text = currentAirportInfo.naviEquipment[36].info[00];
            equipmentInfoContent3601.Text = currentAirportInfo.naviEquipment[36].info[01];
            equipmentInfoContent3602.Text = currentAirportInfo.naviEquipment[36].info[02];
            equipmentInfoContent3603.Text = currentAirportInfo.naviEquipment[36].info[03];
            equipmentInfoContent3604.Text = currentAirportInfo.naviEquipment[36].info[04];
            equipmentInfoContent3605.Text = currentAirportInfo.naviEquipment[36].info[05];
            equipmentInfoContent3606.Text = currentAirportInfo.naviEquipment[36].info[06];
            equipmentInfoContent3607.Text = currentAirportInfo.naviEquipment[36].info[07];
            equipmentInfoContent3608.Text = currentAirportInfo.naviEquipment[36].info[08];
            equipmentInfoContent3609.Text = currentAirportInfo.naviEquipment[36].info[09];
            equipmentInfoContent3610.Text = currentAirportInfo.naviEquipment[36].info[10];
            equipmentInfoContent3611.Text = currentAirportInfo.naviEquipment[36].info[11];
            equipmentInfoContent3612.Text = currentAirportInfo.naviEquipment[36].info[12];
            equipmentInfoContent3700.Text = currentAirportInfo.naviEquipment[37].info[00];
            equipmentInfoContent3701.Text = currentAirportInfo.naviEquipment[37].info[01];
            equipmentInfoContent3702.Text = currentAirportInfo.naviEquipment[37].info[02];
            equipmentInfoContent3703.Text = currentAirportInfo.naviEquipment[37].info[03];
            equipmentInfoContent3704.Text = currentAirportInfo.naviEquipment[37].info[04];
            equipmentInfoContent3705.Text = currentAirportInfo.naviEquipment[37].info[05];
            equipmentInfoContent3706.Text = currentAirportInfo.naviEquipment[37].info[06];
            equipmentInfoContent3707.Text = currentAirportInfo.naviEquipment[37].info[07];
            equipmentInfoContent3708.Text = currentAirportInfo.naviEquipment[37].info[08];
            equipmentInfoContent3709.Text = currentAirportInfo.naviEquipment[37].info[09];
            equipmentInfoContent3710.Text = currentAirportInfo.naviEquipment[37].info[10];
            equipmentInfoContent3711.Text = currentAirportInfo.naviEquipment[37].info[11];
            equipmentInfoContent3712.Text = currentAirportInfo.naviEquipment[37].info[12];
            equipmentInfoContent3800.Text = currentAirportInfo.naviEquipment[38].info[00];
            equipmentInfoContent3801.Text = currentAirportInfo.naviEquipment[38].info[01];
            equipmentInfoContent3802.Text = currentAirportInfo.naviEquipment[38].info[02];
            equipmentInfoContent3803.Text = currentAirportInfo.naviEquipment[38].info[03];
            equipmentInfoContent3804.Text = currentAirportInfo.naviEquipment[38].info[04];
            equipmentInfoContent3805.Text = currentAirportInfo.naviEquipment[38].info[05];
            equipmentInfoContent3806.Text = currentAirportInfo.naviEquipment[38].info[06];
            equipmentInfoContent3807.Text = currentAirportInfo.naviEquipment[38].info[07];
            equipmentInfoContent3808.Text = currentAirportInfo.naviEquipment[38].info[08];
            equipmentInfoContent3809.Text = currentAirportInfo.naviEquipment[38].info[09];
            equipmentInfoContent3810.Text = currentAirportInfo.naviEquipment[38].info[10];
            equipmentInfoContent3811.Text = currentAirportInfo.naviEquipment[38].info[11];
            equipmentInfoContent3812.Text = currentAirportInfo.naviEquipment[38].info[12];
            #endregion

            //project
            #region
            //page display
            if (currentAirportInfo.project[0].info[0] != "True")
                projectInfoTab1.Visibility = Visibility.Hidden;
            else projectQtr++;
            if (currentAirportInfo.project[1].info[0] != "True")
                projectInfoTab2.Visibility = Visibility.Hidden;
            else projectQtr++;
            if (currentAirportInfo.project[2].info[0] != "True")
                projectInfoTab3.Visibility = Visibility.Hidden;
            else projectQtr++;
            if (projectQtr == 3) { addProjectButton.IsEnabled = false; }
            if (projectQtr == 0) { deleteProjectButton.IsEnabled = false; }
            //project1
            //project info write
            project1InfoContent00.Text = currentAirportInfo.project[0].info[1];
            project1InfoContent01.Text = currentAirportInfo.project[0].info[2];
            project1InfoContent02.Text = currentAirportInfo.project[0].info[3];
            project1InfoContent03.Text = currentAirportInfo.project[0].info[4];
            project1InfoContent04.Text = currentAirportInfo.project[0].info[5];
            project1InfoContent05.Text = currentAirportInfo.project[0].info[6];
            project1InfoContent06.Text = currentAirportInfo.project[0].info[7];
            project1InfoContent07.Text = currentAirportInfo.project[0].info[8];
            project1InfoContent08.Text = currentAirportInfo.project[0].info[9];
            project1InfoContent09.Text = currentAirportInfo.project[0].info[10];
            project1InfoContent10.Text = currentAirportInfo.project[0].info[11];
            project1InfoContent11.Text = currentAirportInfo.project[0].info[12];
            project1InfoContent12.Text = currentAirportInfo.project[0].info[13];
            project1InfoContent13.Text = currentAirportInfo.project[0].info[14];
            project1InfoContent14.Text = currentAirportInfo.project[0].info[15];
            //project sales write
            project1SalesContent00.Text = currentAirportInfo.project[0].sale[0].info[0];
            project1SalesContent01.Text = currentAirportInfo.project[0].sale[0].info[1];
            project1SalesContent02.Text = currentAirportInfo.project[0].sale[0].info[2];
            project1SalesContent03.Text = currentAirportInfo.project[0].sale[0].info[3];
            project1SalesContent10.Text = currentAirportInfo.project[0].sale[1].info[0];
            project1SalesContent11.Text = currentAirportInfo.project[0].sale[1].info[1];
            project1SalesContent12.Text = currentAirportInfo.project[0].sale[1].info[2];
            project1SalesContent13.Text = currentAirportInfo.project[0].sale[1].info[3];
            project1SalesContent20.Text = currentAirportInfo.project[0].sale[2].info[0];
            project1SalesContent21.Text = currentAirportInfo.project[0].sale[2].info[1];
            project1SalesContent22.Text = currentAirportInfo.project[0].sale[2].info[2];
            project1SalesContent23.Text = currentAirportInfo.project[0].sale[2].info[3];
            project1SalesContent30.Text = currentAirportInfo.project[0].sale[3].info[0];
            project1SalesContent31.Text = currentAirportInfo.project[0].sale[3].info[1];
            project1SalesContent32.Text = currentAirportInfo.project[0].sale[3].info[2];
            project1SalesContent33.Text = currentAirportInfo.project[0].sale[3].info[3];
            project1SalesContent40.Text = currentAirportInfo.project[0].sale[4].info[0];
            project1SalesContent41.Text = currentAirportInfo.project[0].sale[4].info[1];
            project1SalesContent42.Text = currentAirportInfo.project[0].sale[4].info[2];
            project1SalesContent43.Text = currentAirportInfo.project[0].sale[4].info[3];
            project1SalesContent50.Text = currentAirportInfo.project[0].sale[5].info[0];
            project1SalesContent51.Text = currentAirportInfo.project[0].sale[5].info[1];
            project1SalesContent52.Text = currentAirportInfo.project[0].sale[5].info[2];
            project1SalesContent53.Text = currentAirportInfo.project[0].sale[5].info[3];
            project1SalesContent60.Text = currentAirportInfo.project[0].sale[6].info[0];
            project1SalesContent61.Text = currentAirportInfo.project[0].sale[6].info[1];
            project1SalesContent62.Text = currentAirportInfo.project[0].sale[6].info[2];
            project1SalesContent63.Text = currentAirportInfo.project[0].sale[6].info[3];
            project1SalesContent70.Text = currentAirportInfo.project[0].sale[7].info[0];
            project1SalesContent71.Text = currentAirportInfo.project[0].sale[7].info[1];
            project1SalesContent72.Text = currentAirportInfo.project[0].sale[7].info[2];
            project1SalesContent73.Text = currentAirportInfo.project[0].sale[7].info[3];
            project1SalesContent80.Text = currentAirportInfo.project[0].sale[8].info[0];
            project1SalesContent81.Text = currentAirportInfo.project[0].sale[8].info[1];
            project1SalesContent82.Text = currentAirportInfo.project[0].sale[8].info[2];
            project1SalesContent83.Text = currentAirportInfo.project[0].sale[8].info[3];
            project1SalesContent90.Text = currentAirportInfo.project[0].sale[9].info[0];
            project1SalesContent91.Text = currentAirportInfo.project[0].sale[9].info[1];
            project1SalesContent92.Text = currentAirportInfo.project[0].sale[9].info[2];
            project1SalesContent93.Text = currentAirportInfo.project[0].sale[9].info[3];
            //project bool info
            project1CheckBox0.IsChecked = currentAirportInfo.project[0].boolInfo[0];
            project1CheckBox1.IsChecked = currentAirportInfo.project[0].boolInfo[1];
            project1CheckBox2.IsChecked = currentAirportInfo.project[0].boolInfo[2];
            project1CheckBox3.IsChecked = currentAirportInfo.project[0].boolInfo[3];
            project1CheckBox4.IsChecked = currentAirportInfo.project[0].boolInfo[4];
            project1CheckBox5.IsChecked = currentAirportInfo.project[0].boolInfo[5];
            project1CheckBox6.IsChecked = currentAirportInfo.project[0].boolInfo[6];
            project1CheckBox7.IsChecked = currentAirportInfo.project[0].boolInfo[7];
            project1CheckBox8.IsChecked = currentAirportInfo.project[0].boolInfo[8];
            project1CheckBox9.IsChecked = currentAirportInfo.project[0].boolInfo[9];
            project1CheckBox10.IsChecked = currentAirportInfo.project[0].boolInfo[10];
            project1CheckBox11.IsChecked = currentAirportInfo.project[0].boolInfo[11];
            project1CheckBox12.IsChecked = currentAirportInfo.project[0].boolInfo[12];
            project1CheckBox13.IsChecked = currentAirportInfo.project[0].boolInfo[13];
            project1CheckBox14.IsChecked = currentAirportInfo.project[0].boolInfo[14];
            project1CheckBox15.IsChecked = currentAirportInfo.project[0].boolInfo[15];
            project1CheckBox16.IsChecked = currentAirportInfo.project[0].boolInfo[16];
            project1CheckBox17.IsChecked = currentAirportInfo.project[0].boolInfo[17];
            project1CheckBox18.IsChecked = currentAirportInfo.project[0].boolInfo[18];
            project1CheckBox19.IsChecked = currentAirportInfo.project[0].boolInfo[19];
            project1CheckBox20.IsChecked = currentAirportInfo.project[0].boolInfo[20];
            project1CheckBox21.IsChecked = currentAirportInfo.project[0].boolInfo[21];
            project1CheckBox22.IsChecked = currentAirportInfo.project[0].boolInfo[22];
            project1CheckBox23.IsChecked = currentAirportInfo.project[0].boolInfo[23];
            project1CheckBox24.IsChecked = currentAirportInfo.project[0].boolInfo[24];
            //project2
            //project info write
            project2InfoContent00.Text = currentAirportInfo.project[1].info[1];
            project2InfoContent01.Text = currentAirportInfo.project[1].info[2];
            project2InfoContent02.Text = currentAirportInfo.project[1].info[3];
            project2InfoContent03.Text = currentAirportInfo.project[1].info[4];
            project2InfoContent04.Text = currentAirportInfo.project[1].info[5];
            project2InfoContent05.Text = currentAirportInfo.project[1].info[6];
            project2InfoContent06.Text = currentAirportInfo.project[1].info[7];
            project2InfoContent07.Text = currentAirportInfo.project[1].info[8];
            project2InfoContent08.Text = currentAirportInfo.project[1].info[9];
            project2InfoContent09.Text = currentAirportInfo.project[1].info[10];
            project2InfoContent10.Text = currentAirportInfo.project[1].info[11];
            project2InfoContent11.Text = currentAirportInfo.project[1].info[12];
            project2InfoContent12.Text = currentAirportInfo.project[1].info[13];
            project2InfoContent13.Text = currentAirportInfo.project[1].info[14];
            project2InfoContent14.Text = currentAirportInfo.project[1].info[15];
            //project sales write
            project2SalesContent00.Text = currentAirportInfo.project[1].sale[0].info[0];
            project2SalesContent01.Text = currentAirportInfo.project[1].sale[0].info[1];
            project2SalesContent02.Text = currentAirportInfo.project[1].sale[0].info[2];
            project2SalesContent03.Text = currentAirportInfo.project[1].sale[0].info[3];
            project2SalesContent10.Text = currentAirportInfo.project[1].sale[1].info[0];
            project2SalesContent11.Text = currentAirportInfo.project[1].sale[1].info[1];
            project2SalesContent12.Text = currentAirportInfo.project[1].sale[1].info[2];
            project2SalesContent13.Text = currentAirportInfo.project[1].sale[1].info[3];
            project2SalesContent20.Text = currentAirportInfo.project[1].sale[2].info[0];
            project2SalesContent21.Text = currentAirportInfo.project[1].sale[2].info[1];
            project2SalesContent22.Text = currentAirportInfo.project[1].sale[2].info[2];
            project2SalesContent23.Text = currentAirportInfo.project[1].sale[2].info[3];
            project2SalesContent30.Text = currentAirportInfo.project[1].sale[3].info[0];
            project2SalesContent31.Text = currentAirportInfo.project[1].sale[3].info[1];
            project2SalesContent32.Text = currentAirportInfo.project[1].sale[3].info[2];
            project2SalesContent33.Text = currentAirportInfo.project[1].sale[3].info[3];
            project2SalesContent40.Text = currentAirportInfo.project[1].sale[4].info[0];
            project2SalesContent41.Text = currentAirportInfo.project[1].sale[4].info[1];
            project2SalesContent42.Text = currentAirportInfo.project[1].sale[4].info[2];
            project2SalesContent43.Text = currentAirportInfo.project[1].sale[4].info[3];
            project2SalesContent50.Text = currentAirportInfo.project[1].sale[5].info[0];
            project2SalesContent51.Text = currentAirportInfo.project[1].sale[5].info[1];
            project2SalesContent52.Text = currentAirportInfo.project[1].sale[5].info[2];
            project2SalesContent53.Text = currentAirportInfo.project[1].sale[5].info[3];
            project2SalesContent60.Text = currentAirportInfo.project[1].sale[6].info[0];
            project2SalesContent61.Text = currentAirportInfo.project[1].sale[6].info[1];
            project2SalesContent62.Text = currentAirportInfo.project[1].sale[6].info[2];
            project2SalesContent63.Text = currentAirportInfo.project[1].sale[6].info[3];
            project2SalesContent70.Text = currentAirportInfo.project[1].sale[7].info[0];
            project2SalesContent71.Text = currentAirportInfo.project[1].sale[7].info[1];
            project2SalesContent72.Text = currentAirportInfo.project[1].sale[7].info[2];
            project2SalesContent73.Text = currentAirportInfo.project[1].sale[7].info[3];
            project2SalesContent80.Text = currentAirportInfo.project[1].sale[8].info[0];
            project2SalesContent81.Text = currentAirportInfo.project[1].sale[8].info[1];
            project2SalesContent82.Text = currentAirportInfo.project[1].sale[8].info[2];
            project2SalesContent83.Text = currentAirportInfo.project[1].sale[8].info[3];
            project2SalesContent90.Text = currentAirportInfo.project[1].sale[9].info[0];
            project2SalesContent91.Text = currentAirportInfo.project[1].sale[9].info[1];
            project2SalesContent92.Text = currentAirportInfo.project[1].sale[9].info[2];
            project2SalesContent93.Text = currentAirportInfo.project[1].sale[9].info[3];
            //project bool info
            project2CheckBox0.IsChecked = currentAirportInfo.project[1].boolInfo[0];
            project2CheckBox1.IsChecked = currentAirportInfo.project[1].boolInfo[1];
            project2CheckBox2.IsChecked = currentAirportInfo.project[1].boolInfo[2];
            project2CheckBox3.IsChecked = currentAirportInfo.project[1].boolInfo[3];
            project2CheckBox4.IsChecked = currentAirportInfo.project[1].boolInfo[4];
            project2CheckBox5.IsChecked = currentAirportInfo.project[1].boolInfo[5];
            project2CheckBox6.IsChecked = currentAirportInfo.project[1].boolInfo[6];
            project2CheckBox7.IsChecked = currentAirportInfo.project[1].boolInfo[7];
            project2CheckBox8.IsChecked = currentAirportInfo.project[1].boolInfo[8];
            project2CheckBox9.IsChecked = currentAirportInfo.project[1].boolInfo[9];
            project2CheckBox10.IsChecked = currentAirportInfo.project[1].boolInfo[10];
            project2CheckBox11.IsChecked = currentAirportInfo.project[1].boolInfo[11];
            project2CheckBox12.IsChecked = currentAirportInfo.project[1].boolInfo[12];
            project2CheckBox13.IsChecked = currentAirportInfo.project[1].boolInfo[13];
            project2CheckBox14.IsChecked = currentAirportInfo.project[1].boolInfo[14];
            project2CheckBox15.IsChecked = currentAirportInfo.project[1].boolInfo[15];
            project2CheckBox16.IsChecked = currentAirportInfo.project[1].boolInfo[16];
            project2CheckBox17.IsChecked = currentAirportInfo.project[1].boolInfo[17];
            project2CheckBox18.IsChecked = currentAirportInfo.project[1].boolInfo[18];
            project2CheckBox19.IsChecked = currentAirportInfo.project[1].boolInfo[19];
            project2CheckBox20.IsChecked = currentAirportInfo.project[1].boolInfo[20];
            project2CheckBox21.IsChecked = currentAirportInfo.project[1].boolInfo[21];
            project2CheckBox22.IsChecked = currentAirportInfo.project[1].boolInfo[22];
            project2CheckBox23.IsChecked = currentAirportInfo.project[1].boolInfo[23];
            project2CheckBox24.IsChecked = currentAirportInfo.project[1].boolInfo[24];
            //project3
            //project info write
            project3InfoContent00.Text = currentAirportInfo.project[2].info[1];
            project3InfoContent01.Text = currentAirportInfo.project[2].info[2];
            project3InfoContent02.Text = currentAirportInfo.project[2].info[3];
            project3InfoContent03.Text = currentAirportInfo.project[2].info[4];
            project3InfoContent04.Text = currentAirportInfo.project[2].info[5];
            project3InfoContent05.Text = currentAirportInfo.project[2].info[6];
            project3InfoContent06.Text = currentAirportInfo.project[2].info[7];
            project3InfoContent07.Text = currentAirportInfo.project[2].info[8];
            project3InfoContent08.Text = currentAirportInfo.project[2].info[9];
            project3InfoContent09.Text = currentAirportInfo.project[2].info[10];
            project3InfoContent10.Text = currentAirportInfo.project[2].info[11];
            project3InfoContent11.Text = currentAirportInfo.project[2].info[12];
            project3InfoContent12.Text = currentAirportInfo.project[2].info[13];
            project3InfoContent13.Text = currentAirportInfo.project[2].info[14];
            project3InfoContent14.Text = currentAirportInfo.project[2].info[15];
            //project sales write
            project3SalesContent00.Text = currentAirportInfo.project[2].sale[0].info[0];
            project3SalesContent01.Text = currentAirportInfo.project[2].sale[0].info[1];
            project3SalesContent02.Text = currentAirportInfo.project[2].sale[0].info[2];
            project3SalesContent03.Text = currentAirportInfo.project[2].sale[0].info[3];
            project3SalesContent10.Text = currentAirportInfo.project[2].sale[1].info[0];
            project3SalesContent11.Text = currentAirportInfo.project[2].sale[1].info[1];
            project3SalesContent12.Text = currentAirportInfo.project[2].sale[1].info[2];
            project3SalesContent13.Text = currentAirportInfo.project[2].sale[1].info[3];
            project3SalesContent20.Text = currentAirportInfo.project[2].sale[2].info[0];
            project3SalesContent21.Text = currentAirportInfo.project[2].sale[2].info[1];
            project3SalesContent22.Text = currentAirportInfo.project[2].sale[2].info[2];
            project3SalesContent23.Text = currentAirportInfo.project[2].sale[2].info[3];
            project3SalesContent30.Text = currentAirportInfo.project[2].sale[3].info[0];
            project3SalesContent31.Text = currentAirportInfo.project[2].sale[3].info[1];
            project3SalesContent32.Text = currentAirportInfo.project[2].sale[3].info[2];
            project3SalesContent33.Text = currentAirportInfo.project[2].sale[3].info[3];
            project3SalesContent40.Text = currentAirportInfo.project[2].sale[4].info[0];
            project3SalesContent41.Text = currentAirportInfo.project[2].sale[4].info[1];
            project3SalesContent42.Text = currentAirportInfo.project[2].sale[4].info[2];
            project3SalesContent43.Text = currentAirportInfo.project[2].sale[4].info[3];
            project3SalesContent50.Text = currentAirportInfo.project[2].sale[5].info[0];
            project3SalesContent51.Text = currentAirportInfo.project[2].sale[5].info[1];
            project3SalesContent52.Text = currentAirportInfo.project[2].sale[5].info[2];
            project3SalesContent53.Text = currentAirportInfo.project[2].sale[5].info[3];
            project3SalesContent60.Text = currentAirportInfo.project[2].sale[6].info[0];
            project3SalesContent61.Text = currentAirportInfo.project[2].sale[6].info[1];
            project3SalesContent62.Text = currentAirportInfo.project[2].sale[6].info[2];
            project3SalesContent63.Text = currentAirportInfo.project[2].sale[6].info[3];
            project3SalesContent70.Text = currentAirportInfo.project[2].sale[7].info[0];
            project3SalesContent71.Text = currentAirportInfo.project[2].sale[7].info[1];
            project3SalesContent72.Text = currentAirportInfo.project[2].sale[7].info[2];
            project3SalesContent73.Text = currentAirportInfo.project[2].sale[7].info[3];
            project3SalesContent80.Text = currentAirportInfo.project[2].sale[8].info[0];
            project3SalesContent81.Text = currentAirportInfo.project[2].sale[8].info[1];
            project3SalesContent82.Text = currentAirportInfo.project[2].sale[8].info[2];
            project3SalesContent83.Text = currentAirportInfo.project[2].sale[8].info[3];
            project3SalesContent90.Text = currentAirportInfo.project[2].sale[9].info[0];
            project3SalesContent91.Text = currentAirportInfo.project[2].sale[9].info[1];
            project3SalesContent92.Text = currentAirportInfo.project[2].sale[9].info[2];
            project3SalesContent93.Text = currentAirportInfo.project[2].sale[9].info[3];
            //project bool info
            project3CheckBox0.IsChecked = currentAirportInfo.project[2].boolInfo[0];
            project3CheckBox1.IsChecked = currentAirportInfo.project[2].boolInfo[1];
            project3CheckBox2.IsChecked = currentAirportInfo.project[2].boolInfo[2];
            project3CheckBox3.IsChecked = currentAirportInfo.project[2].boolInfo[3];
            project3CheckBox4.IsChecked = currentAirportInfo.project[2].boolInfo[4];
            project3CheckBox5.IsChecked = currentAirportInfo.project[2].boolInfo[5];
            project3CheckBox6.IsChecked = currentAirportInfo.project[2].boolInfo[6];
            project3CheckBox7.IsChecked = currentAirportInfo.project[2].boolInfo[7];
            project3CheckBox8.IsChecked = currentAirportInfo.project[2].boolInfo[8];
            project3CheckBox9.IsChecked = currentAirportInfo.project[2].boolInfo[9];
            project3CheckBox10.IsChecked = currentAirportInfo.project[2].boolInfo[10];
            project3CheckBox11.IsChecked = currentAirportInfo.project[2].boolInfo[11];
            project3CheckBox12.IsChecked = currentAirportInfo.project[2].boolInfo[12];
            project3CheckBox13.IsChecked = currentAirportInfo.project[2].boolInfo[13];
            project3CheckBox14.IsChecked = currentAirportInfo.project[2].boolInfo[14];
            project3CheckBox15.IsChecked = currentAirportInfo.project[2].boolInfo[15];
            project3CheckBox16.IsChecked = currentAirportInfo.project[2].boolInfo[16];
            project3CheckBox17.IsChecked = currentAirportInfo.project[2].boolInfo[17];
            project3CheckBox18.IsChecked = currentAirportInfo.project[2].boolInfo[18];
            project3CheckBox19.IsChecked = currentAirportInfo.project[2].boolInfo[19];
            project3CheckBox20.IsChecked = currentAirportInfo.project[2].boolInfo[20];
            project3CheckBox21.IsChecked = currentAirportInfo.project[2].boolInfo[21];
            project3CheckBox22.IsChecked = currentAirportInfo.project[2].boolInfo[22];
            project3CheckBox23.IsChecked = currentAirportInfo.project[2].boolInfo[23];
            project3CheckBox24.IsChecked = currentAirportInfo.project[2].boolInfo[24];

            #endregion

            //chart
            #region
            //project1
            chartAddress1.Text = currentAirportInfo.project[0].info[16];
            try
            {
                chartImage1.Source = new BitmapImage(new Uri(chartAddress1.Text, UriKind.RelativeOrAbsolute));
            }
            catch (Exception)
            {
                chartAddress1.Text = "";
            }
            //project2
            chartAddress2.Text = currentAirportInfo.project[1].info[16];
            try
            {
                chartImage2.Source = new BitmapImage(new Uri(chartAddress2.Text, UriKind.RelativeOrAbsolute));
            }
            catch (Exception)
            {
                chartAddress2.Text = "";
            }
            //project3
            chartAddress3.Text = currentAirportInfo.project[2].info[16];
            try
            {
                chartImage3.Source = new BitmapImage(new Uri(chartAddress3.Text, UriKind.RelativeOrAbsolute));
            }
            catch (Exception)
            {
                chartAddress3.Text = "";
            }
            #endregion

        }

        private void fileRead(string fileAddress)
        {
            //load the xml file
            try
            {
                myXml.Load(fileAddress);           

            //get the node list
            //counter
            int i = 0;
            //mark
            int startMark = 0;
            //read basic info
            foreach (var item in myXml.FirstChild.ChildNodes[0])
            {
                XmlElement xe = (XmlElement)item;
                currentAirportInfo.basicInfo[i] = xe.InnerText;
                i++;
            }
            //mark
            startMark++;

            //read runway info
            for (int j = startMark; j < startMark + currentAirportInfo.runway.Length; j++)
            {
                //counter =0
                i = 0;
                foreach (var item in myXml.FirstChild.ChildNodes[j])
                {
                    XmlElement xe = (XmlElement)item;
                    currentAirportInfo.runway[j - startMark].info[i] = xe.InnerText;
                    i++;
                }
            }
            //mark
            startMark += currentAirportInfo.runway.Length;

            //read staff info
            for (int j = startMark; j < startMark + currentAirportInfo.staff.Length; j++)
            {
                //counter =0
                i = 0;
                foreach (var item in myXml.FirstChild.ChildNodes[j])
                {
                    XmlElement xe = (XmlElement)item;
                    currentAirportInfo.staff[j - startMark].info[i] = xe.InnerText;
                    i++;
                }
            }
            //mark
            startMark += currentAirportInfo.staff.Length;

            //read cooperation info
            for (int j = startMark; j < startMark + currentAirportInfo.cooperation.Length; j++)
            {
                //counter =0
                i = 0;
                foreach (var item in myXml.FirstChild.ChildNodes[j])
                {
                    XmlElement xe = (XmlElement)item;
                    currentAirportInfo.cooperation[j - startMark].info[i] = xe.InnerText;
                    i++;
                }
            }
            //mark
            startMark += currentAirportInfo.cooperation.Length;

            //read equipment info
            for (int j = startMark; j < startMark + currentAirportInfo.naviEquipment.Length; j++)
            {
                //counter =0
                i = 0;
                foreach (var item in myXml.FirstChild.ChildNodes[j])
                {
                    XmlElement xe = (XmlElement)item;
                    currentAirportInfo.naviEquipment[j - startMark].info[i] = xe.InnerText;
                    i++;
                }
            }
            //mark
            startMark += currentAirportInfo.naviEquipment.Length;

            //read project info
            for (int j = startMark; j < startMark + currentAirportInfo.project.Length; j++)
            {
                //counter =0
                i = 0;
                foreach (var item in myXml.FirstChild.ChildNodes[j])
                {
                    XmlElement xe = (XmlElement)item;
                    currentAirportInfo.project[j - startMark].info[i] = xe.InnerText;
                    i++;
                }
            }
            //mark
            startMark += currentAirportInfo.project.Length;

            //read project sales
            for (int k = 0; k < currentAirportInfo.project.Length; k++)
            {
                for (int j = startMark; j < startMark + currentAirportInfo.project[k].sale.Length; j++)
                {
                    //counter =0
                    i = 0;
                    foreach (var item in myXml.FirstChild.ChildNodes[j])
                    {
                        XmlElement xe = (XmlElement)item;
                        currentAirportInfo.project[k].sale[j - startMark].info[i] = xe.InnerText;
                        i++;
                    }
                }
                //mark
                startMark += currentAirportInfo.project[k].sale.Length;
            }

            //read project bool info
            for (int j = startMark; j < startMark + currentAirportInfo.project.Length; j++)
            {
                //counter =0
                i = 0;
                foreach (var item in myXml.FirstChild.ChildNodes[j])
                {
                    XmlElement xe = (XmlElement)item;
                    if (xe.InnerText == "True")
                    {
                        currentAirportInfo.project[j - startMark].boolInfo[i] = true;
                    }
                    i++;
                }
            }
            //mark
            startMark += currentAirportInfo.project.Length;



            }
            catch (Exception)
            {
                MessageBox.Show("reading file error");
                return;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveCharttoAirportInfo();
            SaveAirportInfoToFile(fileAddress);
            isSaved = true;
            this.Close();
        }

        private void SaveAirportInfoToFile(string fileAddress)
        {
            //remove all myXml content
            myXml.RemoveAll();

            //the root
            XmlElement pageList = myXml.CreateElement("pageList");
            myXml.AppendChild(pageList);

            //add the page node
            //add basicInfo
            XmlElement basicInfoPage = myXml.CreateElement("basicInfo");
            myXml.FirstChild.AppendChild(basicInfoPage);

            for (int i = 0; i < currentAirportInfo.basicInfo.Length; i++)
            {
                XmlElement basicInfoX = myXml.CreateElement("BasicInfo" + i.ToString());
                basicInfoX.InnerText = currentAirportInfo.basicInfo[i];
                basicInfoPage.AppendChild(basicInfoX);
            }
            //add runwayInfo
            for (int i = 0; i < currentAirportInfo.runway.Length; i++)
            {
                XmlElement runwayInfoPage = myXml.CreateElement("runway" + i + "Info");
                myXml.FirstChild.AppendChild(runwayInfoPage);

                for (int j = 0; j < currentAirportInfo.runway[i].info.Length; j++)
                {
                    XmlElement runwayInfoX = myXml.CreateElement("runway" + i + "Info" + j.ToString());
                    runwayInfoX.InnerText = currentAirportInfo.runway[i].info[j];
                    runwayInfoPage.AppendChild(runwayInfoX);
                }
            }
            //add StaffInfo
            for (int i = 0; i < currentAirportInfo.staff.Length; i++)
            {
                XmlElement staffInfoPage = myXml.CreateElement("staff" + i + "Info");
                myXml.FirstChild.AppendChild(staffInfoPage);

                for (int j = 0; j < currentAirportInfo.staff[i].info.Length; j++)
                {
                    XmlElement staffInfoX = myXml.CreateElement("staff" + i + "Info" + j.ToString());
                    staffInfoX.InnerText = currentAirportInfo.staff[i].info[j];
                    staffInfoPage.AppendChild(staffInfoX);
                }
            }
            //add cooperationInfo
            for (int i = 0; i < currentAirportInfo.cooperation.Length; i++)
            {
                XmlElement cooperationInfoPage = myXml.CreateElement("cooperation" + i + "Info");
                myXml.FirstChild.AppendChild(cooperationInfoPage);

                for (int j = 0; j < currentAirportInfo.cooperation[i].info.Length; j++)
                {
                    XmlElement cooperationInfoX = myXml.CreateElement("cooperation" + i + "Info" + j.ToString());
                    cooperationInfoX.InnerText = currentAirportInfo.cooperation[i].info[j];
                    cooperationInfoPage.AppendChild(cooperationInfoX);
                }
            }
           
            //add equipmentInfo
            for (int i = 0; i < currentAirportInfo.naviEquipment.Length; i++)
            {
                XmlElement naviEquipmentInfoPage = myXml.CreateElement("naviEquipment" + i + "Info");
                myXml.FirstChild.AppendChild(naviEquipmentInfoPage);

                for (int j = 0; j < currentAirportInfo.naviEquipment[i].info.Length; j++)
                {
                    XmlElement naviEquipmentInfoX = myXml.CreateElement("naviEquipment" + i + "Info" + j.ToString());
                    naviEquipmentInfoX.InnerText = currentAirportInfo.naviEquipment[i].info[j];
                    naviEquipmentInfoPage.AppendChild(naviEquipmentInfoX);
                }
            }


            //add projectInfo
            for (int i = 0; i < currentAirportInfo.project.Length; i++)
            {
                XmlElement projectInfoPage = myXml.CreateElement("project" + i + "Info");
                myXml.FirstChild.AppendChild(projectInfoPage);

                for (int j = 0; j < currentAirportInfo.project[i].info.Length; j++)
                {
                    XmlElement projectInfoX = myXml.CreateElement("project" + i + "Info" + j.ToString());
                    projectInfoX.InnerText = currentAirportInfo.project[i].info[j];
                    projectInfoPage.AppendChild(projectInfoX);
                }
            }

            //add projectSales
            for (int k = 0; k < currentAirportInfo.project.Length; k++)
            {
                for (int i = 0; i < currentAirportInfo.project[k].sale.Length; i++)
                {
                    XmlElement projectSalesPage = myXml.CreateElement("project" + k + "Sales" + i);
                    myXml.FirstChild.AppendChild(projectSalesPage);

                    for (int j = 0; j < currentAirportInfo.project[k].sale[i].info.Length; j++)
                    {
                        XmlElement projectInfoX = myXml.CreateElement("project" + k + "Sales" + i + "info" + j);
                        projectInfoX.InnerText = currentAirportInfo.project[k].sale[i].info[j];
                        projectSalesPage.AppendChild(projectInfoX);
                    }
                }
            }

            //add projectBoolInfo
            for (int i = 0; i < currentAirportInfo.project.Length; i++)
            {
                XmlElement projectBoolInfoPage = myXml.CreateElement("project" + i + "BoolInfo");
                myXml.FirstChild.AppendChild(projectBoolInfoPage);

                for (int j = 0; j < currentAirportInfo.project[i].boolInfo.Length; j++)
                {
                    XmlElement projectInfoX = myXml.CreateElement("project" + i + "BoolInfo" + j.ToString());
                    projectInfoX.InnerText = currentAirportInfo.project[i].boolInfo[j].ToString();
                    projectBoolInfoPage.AppendChild(projectInfoX);
                }
            }

            




            //save to xml file
            //en name & ch name
            //if (basicInfoContent00.Text != "" || basicInfoContent01.Text != "")
            //{
            //    //update file name
            //    wholeFileName = "\\" + basicInfoContent00.Text + " " + basicInfoContent01.Text + ".xml";
            //    //if name changed, rename the original file
            //    if (!isCreated)
            //    {
            //        if (fileAddress != fileFolderAddress + wholeFileName)
            //        {
            //            string backupFileAddress = fileFolderAddress + "\\" + basicInfoContent00.Text + " " + basicInfoContent01.Text + ".bck";
            //            //if backup exist, delete
            //            if (File.Exists(backupFileAddress))
            //            {
            //                File.Delete(backupFileAddress);
            //            }
            //            //rename the old file
            //            File.Move(fileAddress, backupFileAddress);
            //            //update the address
            //            fileAddress = fileFolderAddress + wholeFileName;
            //        }
            //    }
            //}

            //update file name
            if (basicInfoContent00.Text != "" || basicInfoContent01.Text != "")
            {
                fileName = basicInfoContent00.Text + " " + basicInfoContent01.Text;
            }
            //if not new, name changed?
            if (!isCreated)
            {
                if (fileAddress != fileFolderAddress + "\\" + fileName + ".xml") 
                {
                    //if changed, rename
                    if (File.Exists(fileFolderAddress + "\\" + fileName + ".xml"))
                    {
                        File.Delete(fileFolderAddress + "\\" + fileName + ".xml");
                    }
                    File.Move(fileAddress, fileFolderAddress + "\\" + fileName + ".xml");
                }
            }
            //update file address
            this.fileAddress = fileFolderAddress + "\\" + fileName + ".xml";

            myXml.Save(this.fileAddress);
        }

        private void SaveCharttoAirportInfo()
        {
            //write the chart to the current Airport info class

            //basic info
            #region
            currentAirportInfo.basicInfo[0] = basicInfoContent00.Text;
            currentAirportInfo.basicInfo[1] = basicInfoContent01.Text;
            currentAirportInfo.basicInfo[2] = basicInfoContent02.Text;
            currentAirportInfo.basicInfo[3] = basicInfoContent03.Text;
            currentAirportInfo.basicInfo[4] = basicInfoContent04.Text;
            currentAirportInfo.basicInfo[5] = basicInfoContent05.Text;
            currentAirportInfo.basicInfo[6] = basicInfoContent06.Text;
            currentAirportInfo.basicInfo[7] = basicInfoContent07.Text;
            currentAirportInfo.basicInfo[8] = basicInfoContent08.Text;
            currentAirportInfo.basicInfo[9] = basicInfoContent09.Text;
            currentAirportInfo.basicInfo[10] = basicInfoContent10.Text;
            currentAirportInfo.basicInfo[11] = basicInfoContent11.Text;
            currentAirportInfo.basicInfo[12] = basicInfoContent12.Text;
            currentAirportInfo.basicInfo[13] = basicInfoContent13.Text;
            currentAirportInfo.basicInfo[14] = basicInfoContent14.Text;
            currentAirportInfo.basicInfo[15] = basicInfoContent15.Text;
            currentAirportInfo.basicInfo[16] = basicInfoContent16.Text;
            currentAirportInfo.basicInfo[17] = basicInfoContent17.Text;
            currentAirportInfo.basicInfo[18] = basicInfoContent18.Text;
            currentAirportInfo.basicInfo[19] = basicInfoContent19.Text;
            currentAirportInfo.basicInfo[20] = basicInfoContent20.Text;
            currentAirportInfo.basicInfo[21] = basicInfoContent21.Text;
            currentAirportInfo.basicInfo[22] = basicInfoContent22.Text;
            currentAirportInfo.basicInfo[23] = basicInfoContent23.Text;
            currentAirportInfo.basicInfo[24] = basicInfoContent24.Text;
            //currentAirportInfo.basicInfo[25] = basicInfoContent25.Text;
            //currentAirportInfo.basicInfo[26] = basicInfoContent26.Text;
            //currentAirportInfo.basicInfo[27] = basicInfoContent27.Text;
            //currentAirportInfo.basicInfo[28] = basicInfoContent28.Text;
            //currentAirportInfo.basicInfo[29] = basicInfoContent29.Text;
            //currentAirportInfo.basicInfo[30] = basicInfoContent30.Text;
            //currentAirportInfo.basicInfo[31] = basicInfoContent31.Text;
            #endregion

            //runway info
            #region
            currentAirportInfo.runway[0].info[0] = runwayInfoContent00.Text;
            currentAirportInfo.runway[0].info[1] = runwayInfoContent01.Text;
            currentAirportInfo.runway[0].info[2] = runwayInfoContent02.Text;
            currentAirportInfo.runway[0].info[3] = runwayInfoContent03.Text;
            currentAirportInfo.runway[0].info[4] = runwayInfoContent04.Text;
            currentAirportInfo.runway[0].info[5] = runwayInfoContent05.Text;
            currentAirportInfo.runway[0].info[6] = runwayInfoContent06.Text;
            currentAirportInfo.runway[0].info[7] = runwayInfoContent07.Text;
            currentAirportInfo.runway[0].info[8] = runwayInfoContent08.Text;
            currentAirportInfo.runway[0].info[9] = runwayInfoContent09.Text;
            currentAirportInfo.runway[1].info[0] = runwayInfoContent10.Text;
            currentAirportInfo.runway[1].info[1] = runwayInfoContent11.Text;
            currentAirportInfo.runway[1].info[2] = runwayInfoContent12.Text;
            currentAirportInfo.runway[1].info[3] = runwayInfoContent13.Text;
            currentAirportInfo.runway[1].info[4] = runwayInfoContent14.Text;
            currentAirportInfo.runway[1].info[5] = runwayInfoContent15.Text;
            currentAirportInfo.runway[1].info[6] = runwayInfoContent16.Text;
            currentAirportInfo.runway[1].info[7] = runwayInfoContent17.Text;
            currentAirportInfo.runway[1].info[8] = runwayInfoContent18.Text;
            currentAirportInfo.runway[1].info[9] = runwayInfoContent19.Text;
            currentAirportInfo.runway[2].info[0] = runwayInfoContent20.Text;
            currentAirportInfo.runway[2].info[1] = runwayInfoContent21.Text;
            currentAirportInfo.runway[2].info[2] = runwayInfoContent22.Text;
            currentAirportInfo.runway[2].info[3] = runwayInfoContent23.Text;
            currentAirportInfo.runway[2].info[4] = runwayInfoContent24.Text;
            currentAirportInfo.runway[2].info[5] = runwayInfoContent25.Text;
            currentAirportInfo.runway[2].info[6] = runwayInfoContent26.Text;
            currentAirportInfo.runway[2].info[7] = runwayInfoContent27.Text;
            currentAirportInfo.runway[2].info[8] = runwayInfoContent28.Text;
            currentAirportInfo.runway[2].info[9] = runwayInfoContent29.Text;
            currentAirportInfo.runway[3].info[0] = runwayInfoContent30.Text;
            currentAirportInfo.runway[3].info[1] = runwayInfoContent31.Text;
            currentAirportInfo.runway[3].info[2] = runwayInfoContent32.Text;
            currentAirportInfo.runway[3].info[3] = runwayInfoContent33.Text;
            currentAirportInfo.runway[3].info[4] = runwayInfoContent34.Text;
            currentAirportInfo.runway[3].info[5] = runwayInfoContent35.Text;
            currentAirportInfo.runway[3].info[6] = runwayInfoContent36.Text;
            currentAirportInfo.runway[3].info[7] = runwayInfoContent37.Text;
            currentAirportInfo.runway[3].info[8] = runwayInfoContent38.Text;
            currentAirportInfo.runway[3].info[9] = runwayInfoContent39.Text;
            currentAirportInfo.runway[4].info[0] = runwayInfoContent40.Text;
            currentAirportInfo.runway[4].info[1] = runwayInfoContent41.Text;
            currentAirportInfo.runway[4].info[2] = runwayInfoContent42.Text;
            currentAirportInfo.runway[4].info[3] = runwayInfoContent43.Text;
            currentAirportInfo.runway[4].info[4] = runwayInfoContent44.Text;
            currentAirportInfo.runway[4].info[5] = runwayInfoContent45.Text;
            currentAirportInfo.runway[4].info[6] = runwayInfoContent46.Text;
            currentAirportInfo.runway[4].info[7] = runwayInfoContent47.Text;
            currentAirportInfo.runway[4].info[8] = runwayInfoContent48.Text;
            currentAirportInfo.runway[4].info[9] = runwayInfoContent49.Text;

            currentAirportInfo.runway[0].info[10] = runwayInfoContent010.Text;
            currentAirportInfo.runway[1].info[10] = runwayInfoContent110.Text;
            currentAirportInfo.runway[2].info[10] = runwayInfoContent210.Text;
            currentAirportInfo.runway[3].info[10] = runwayInfoContent310.Text;
            currentAirportInfo.runway[4].info[10] = runwayInfoContent410.Text;
            #endregion

            //staff info
            #region
            currentAirportInfo.staff[0].info[0] = staffInfoContent00.Text;
            currentAirportInfo.staff[0].info[1] = staffInfoContent01.Text;
            currentAirportInfo.staff[0].info[2] = staffInfoContent02.Text;
            currentAirportInfo.staff[0].info[3] = staffInfoContent03.Text;
            currentAirportInfo.staff[0].info[4] = staffInfoContent04.Text;
            currentAirportInfo.staff[1].info[0] = staffInfoContent10.Text;
            currentAirportInfo.staff[1].info[1] = staffInfoContent11.Text;
            currentAirportInfo.staff[1].info[2] = staffInfoContent12.Text;
            currentAirportInfo.staff[1].info[3] = staffInfoContent13.Text;
            currentAirportInfo.staff[1].info[4] = staffInfoContent14.Text;
            currentAirportInfo.staff[2].info[0] = staffInfoContent20.Text;
            currentAirportInfo.staff[2].info[1] = staffInfoContent21.Text;
            currentAirportInfo.staff[2].info[2] = staffInfoContent22.Text;
            currentAirportInfo.staff[2].info[3] = staffInfoContent23.Text;
            currentAirportInfo.staff[2].info[4] = staffInfoContent24.Text;
            currentAirportInfo.staff[3].info[0] = staffInfoContent30.Text;
            currentAirportInfo.staff[3].info[1] = staffInfoContent31.Text;
            currentAirportInfo.staff[3].info[2] = staffInfoContent32.Text;
            currentAirportInfo.staff[3].info[3] = staffInfoContent33.Text;
            currentAirportInfo.staff[3].info[4] = staffInfoContent34.Text;
            currentAirportInfo.staff[4].info[0] = staffInfoContent40.Text;
            currentAirportInfo.staff[4].info[1] = staffInfoContent41.Text;
            currentAirportInfo.staff[4].info[2] = staffInfoContent42.Text;
            currentAirportInfo.staff[4].info[3] = staffInfoContent43.Text;
            currentAirportInfo.staff[4].info[4] = staffInfoContent44.Text;
            currentAirportInfo.staff[5].info[0] = staffInfoContent50.Text;
            currentAirportInfo.staff[5].info[1] = staffInfoContent51.Text;
            currentAirportInfo.staff[5].info[2] = staffInfoContent52.Text;
            currentAirportInfo.staff[5].info[3] = staffInfoContent53.Text;
            currentAirportInfo.staff[5].info[4] = staffInfoContent54.Text;
            currentAirportInfo.staff[6].info[0] = staffInfoContent60.Text;
            currentAirportInfo.staff[6].info[1] = staffInfoContent61.Text;
            currentAirportInfo.staff[6].info[2] = staffInfoContent62.Text;
            currentAirportInfo.staff[6].info[3] = staffInfoContent63.Text;
            currentAirportInfo.staff[6].info[4] = staffInfoContent64.Text;
            currentAirportInfo.staff[7].info[0] = staffInfoContent70.Text;
            currentAirportInfo.staff[7].info[1] = staffInfoContent71.Text;
            currentAirportInfo.staff[7].info[2] = staffInfoContent72.Text;
            currentAirportInfo.staff[7].info[3] = staffInfoContent73.Text;
            currentAirportInfo.staff[7].info[4] = staffInfoContent74.Text;
            currentAirportInfo.staff[8].info[0] = staffInfoContent80.Text;
            currentAirportInfo.staff[8].info[1] = staffInfoContent81.Text;
            currentAirportInfo.staff[8].info[2] = staffInfoContent82.Text;
            currentAirportInfo.staff[8].info[3] = staffInfoContent83.Text;
            currentAirportInfo.staff[8].info[4] = staffInfoContent84.Text;
            currentAirportInfo.staff[9].info[0] = staffInfoContent90.Text;
            currentAirportInfo.staff[9].info[1] = staffInfoContent91.Text;
            currentAirportInfo.staff[9].info[2] = staffInfoContent92.Text;
            currentAirportInfo.staff[9].info[3] = staffInfoContent93.Text;
            currentAirportInfo.staff[9].info[4] = staffInfoContent94.Text;
            currentAirportInfo.staff[10].info[0] = staffInfoContent100.Text;
            currentAirportInfo.staff[10].info[1] = staffInfoContent101.Text;
            currentAirportInfo.staff[10].info[2] = staffInfoContent102.Text;
            currentAirportInfo.staff[10].info[3] = staffInfoContent103.Text;
            currentAirportInfo.staff[10].info[4] = staffInfoContent104.Text;
            currentAirportInfo.staff[11].info[0] = staffInfoContent110.Text;
            currentAirportInfo.staff[11].info[1] = staffInfoContent111.Text;
            currentAirportInfo.staff[11].info[2] = staffInfoContent112.Text;
            currentAirportInfo.staff[11].info[3] = staffInfoContent113.Text;
            currentAirportInfo.staff[11].info[4] = staffInfoContent114.Text;
            #endregion

            //cooperation info
            #region
            currentAirportInfo.cooperation[0].info[0] = cooperationInfoContent00.Text;
            currentAirportInfo.cooperation[0].info[1] = cooperationInfoContent01.Text;
            currentAirportInfo.cooperation[0].info[2] = cooperationInfoContent02.Text;
            currentAirportInfo.cooperation[0].info[3] = cooperationInfoContent03.Text;
            currentAirportInfo.cooperation[0].info[4] = cooperationInfoContent04.Text;
            currentAirportInfo.cooperation[1].info[0] = cooperationInfoContent10.Text;
            currentAirportInfo.cooperation[1].info[1] = cooperationInfoContent11.Text;
            currentAirportInfo.cooperation[1].info[2] = cooperationInfoContent12.Text;
            currentAirportInfo.cooperation[1].info[3] = cooperationInfoContent13.Text;
            currentAirportInfo.cooperation[1].info[4] = cooperationInfoContent14.Text;
            currentAirportInfo.cooperation[2].info[0] = cooperationInfoContent20.Text;
            currentAirportInfo.cooperation[2].info[1] = cooperationInfoContent21.Text;
            currentAirportInfo.cooperation[2].info[2] = cooperationInfoContent22.Text;
            currentAirportInfo.cooperation[2].info[3] = cooperationInfoContent23.Text;
            currentAirportInfo.cooperation[2].info[4] = cooperationInfoContent24.Text;
            currentAirportInfo.cooperation[3].info[0] = cooperationInfoContent30.Text;
            currentAirportInfo.cooperation[3].info[1] = cooperationInfoContent31.Text;
            currentAirportInfo.cooperation[3].info[2] = cooperationInfoContent32.Text;
            currentAirportInfo.cooperation[3].info[3] = cooperationInfoContent33.Text;
            currentAirportInfo.cooperation[3].info[4] = cooperationInfoContent34.Text;
            currentAirportInfo.cooperation[4].info[0] = cooperationInfoContent40.Text;
            currentAirportInfo.cooperation[4].info[1] = cooperationInfoContent41.Text;
            currentAirportInfo.cooperation[4].info[2] = cooperationInfoContent42.Text;
            currentAirportInfo.cooperation[4].info[3] = cooperationInfoContent43.Text;
            currentAirportInfo.cooperation[4].info[4] = cooperationInfoContent44.Text;
            currentAirportInfo.cooperation[5].info[0] = cooperationInfoContent50.Text;
            currentAirportInfo.cooperation[5].info[1] = cooperationInfoContent51.Text;
            currentAirportInfo.cooperation[5].info[2] = cooperationInfoContent52.Text;
            currentAirportInfo.cooperation[5].info[3] = cooperationInfoContent53.Text;
            currentAirportInfo.cooperation[5].info[4] = cooperationInfoContent54.Text;
            currentAirportInfo.cooperation[6].info[0] = cooperationInfoContent60.Text;
            currentAirportInfo.cooperation[6].info[1] = cooperationInfoContent61.Text;
            currentAirportInfo.cooperation[6].info[2] = cooperationInfoContent62.Text;
            currentAirportInfo.cooperation[6].info[3] = cooperationInfoContent63.Text;
            currentAirportInfo.cooperation[6].info[4] = cooperationInfoContent64.Text;
            currentAirportInfo.cooperation[7].info[0] = cooperationInfoContent70.Text;
            currentAirportInfo.cooperation[7].info[1] = cooperationInfoContent71.Text;
            currentAirportInfo.cooperation[7].info[2] = cooperationInfoContent72.Text;
            currentAirportInfo.cooperation[7].info[3] = cooperationInfoContent73.Text;
            currentAirportInfo.cooperation[7].info[4] = cooperationInfoContent74.Text;
            currentAirportInfo.cooperation[8].info[0] = cooperationInfoContent80.Text;
            currentAirportInfo.cooperation[8].info[1] = cooperationInfoContent81.Text;
            currentAirportInfo.cooperation[8].info[2] = cooperationInfoContent82.Text;
            currentAirportInfo.cooperation[8].info[3] = cooperationInfoContent83.Text;
            currentAirportInfo.cooperation[8].info[4] = cooperationInfoContent84.Text;
            currentAirportInfo.cooperation[9].info[0] = cooperationInfoContent90.Text;
            currentAirportInfo.cooperation[9].info[1] = cooperationInfoContent91.Text;
            currentAirportInfo.cooperation[9].info[2] = cooperationInfoContent92.Text;
            currentAirportInfo.cooperation[9].info[3] = cooperationInfoContent93.Text;
            currentAirportInfo.cooperation[9].info[4] = cooperationInfoContent94.Text;
            currentAirportInfo.cooperation[10].info[0] = cooperationInfoContent100.Text;
            currentAirportInfo.cooperation[10].info[1] = cooperationInfoContent101.Text;
            currentAirportInfo.cooperation[10].info[2] = cooperationInfoContent102.Text;
            currentAirportInfo.cooperation[10].info[3] = cooperationInfoContent103.Text;
            currentAirportInfo.cooperation[10].info[4] = cooperationInfoContent104.Text;
            currentAirportInfo.cooperation[11].info[0] = cooperationInfoContent110.Text;
            currentAirportInfo.cooperation[11].info[1] = cooperationInfoContent111.Text;
            currentAirportInfo.cooperation[11].info[2] = cooperationInfoContent112.Text;
            currentAirportInfo.cooperation[11].info[3] = cooperationInfoContent113.Text;
            currentAirportInfo.cooperation[11].info[4] = cooperationInfoContent114.Text;
            currentAirportInfo.cooperation[12].info[0] = cooperationInfoContent120.Text;
            currentAirportInfo.cooperation[12].info[1] = cooperationInfoContent121.Text;
            currentAirportInfo.cooperation[12].info[2] = cooperationInfoContent122.Text;
            currentAirportInfo.cooperation[12].info[3] = cooperationInfoContent123.Text;
            currentAirportInfo.cooperation[12].info[4] = cooperationInfoContent124.Text;
            currentAirportInfo.cooperation[13].info[0] = cooperationInfoContent130.Text;
            currentAirportInfo.cooperation[13].info[1] = cooperationInfoContent131.Text;
            currentAirportInfo.cooperation[13].info[2] = cooperationInfoContent132.Text;
            currentAirportInfo.cooperation[13].info[3] = cooperationInfoContent133.Text;
            currentAirportInfo.cooperation[13].info[4] = cooperationInfoContent134.Text;
            currentAirportInfo.cooperation[14].info[0] = cooperationInfoContent140.Text;
            currentAirportInfo.cooperation[14].info[1] = cooperationInfoContent141.Text;
            currentAirportInfo.cooperation[14].info[2] = cooperationInfoContent142.Text;
            currentAirportInfo.cooperation[14].info[3] = cooperationInfoContent143.Text;
            currentAirportInfo.cooperation[14].info[4] = cooperationInfoContent144.Text;
            currentAirportInfo.cooperation[15].info[0] = cooperationInfoContent150.Text;
            currentAirportInfo.cooperation[15].info[1] = cooperationInfoContent151.Text;
            currentAirportInfo.cooperation[15].info[2] = cooperationInfoContent152.Text;
            currentAirportInfo.cooperation[15].info[3] = cooperationInfoContent153.Text;
            currentAirportInfo.cooperation[15].info[4] = cooperationInfoContent154.Text;
            currentAirportInfo.cooperation[16].info[0] = cooperationInfoContent160.Text;
            currentAirportInfo.cooperation[16].info[1] = cooperationInfoContent161.Text;
            currentAirportInfo.cooperation[16].info[2] = cooperationInfoContent162.Text;
            currentAirportInfo.cooperation[16].info[3] = cooperationInfoContent163.Text;
            currentAirportInfo.cooperation[16].info[4] = cooperationInfoContent164.Text;
            currentAirportInfo.cooperation[17].info[0] = cooperationInfoContent170.Text;
            currentAirportInfo.cooperation[17].info[1] = cooperationInfoContent171.Text;
            currentAirportInfo.cooperation[17].info[2] = cooperationInfoContent172.Text;
            currentAirportInfo.cooperation[17].info[3] = cooperationInfoContent173.Text;
            currentAirportInfo.cooperation[17].info[4] = cooperationInfoContent174.Text;
            currentAirportInfo.cooperation[18].info[0] = cooperationInfoContent180.Text;
            currentAirportInfo.cooperation[18].info[1] = cooperationInfoContent181.Text;
            currentAirportInfo.cooperation[18].info[2] = cooperationInfoContent182.Text;
            currentAirportInfo.cooperation[18].info[3] = cooperationInfoContent183.Text;
            currentAirportInfo.cooperation[18].info[4] = cooperationInfoContent184.Text;
            currentAirportInfo.cooperation[19].info[0] = cooperationInfoContent190.Text;
            currentAirportInfo.cooperation[19].info[1] = cooperationInfoContent191.Text;
            currentAirportInfo.cooperation[19].info[2] = cooperationInfoContent192.Text;
            currentAirportInfo.cooperation[19].info[3] = cooperationInfoContent193.Text;
            currentAirportInfo.cooperation[19].info[4] = cooperationInfoContent194.Text;
            #endregion

            //equipment
            #region
            currentAirportInfo.naviEquipment[0].info[00] = equipmentInfoContent000.Text;
            currentAirportInfo.naviEquipment[0].info[01] = equipmentInfoContent001.Text;
            currentAirportInfo.naviEquipment[0].info[02] = equipmentInfoContent002.Text;
            currentAirportInfo.naviEquipment[0].info[03] = equipmentInfoContent003.Text;
            currentAirportInfo.naviEquipment[0].info[04] = equipmentInfoContent004.Text;
            currentAirportInfo.naviEquipment[0].info[05] = equipmentInfoContent005.Text;
            currentAirportInfo.naviEquipment[0].info[06] = equipmentInfoContent006.Text;
            currentAirportInfo.naviEquipment[0].info[07] = equipmentInfoContent007.Text;
            currentAirportInfo.naviEquipment[0].info[08] = equipmentInfoContent008.Text;
            currentAirportInfo.naviEquipment[0].info[09] = equipmentInfoContent009.Text;
            currentAirportInfo.naviEquipment[0].info[10] = equipmentInfoContent010.Text;
            currentAirportInfo.naviEquipment[0].info[11] = equipmentInfoContent011.Text;
            currentAirportInfo.naviEquipment[0].info[12] = equipmentInfoContent012.Text;
            currentAirportInfo.naviEquipment[1].info[00] = equipmentInfoContent100.Text;
            currentAirportInfo.naviEquipment[1].info[01] = equipmentInfoContent101.Text;
            currentAirportInfo.naviEquipment[1].info[02] = equipmentInfoContent102.Text;
            currentAirportInfo.naviEquipment[1].info[03] = equipmentInfoContent103.Text;
            currentAirportInfo.naviEquipment[1].info[04] = equipmentInfoContent104.Text;
            currentAirportInfo.naviEquipment[1].info[05] = equipmentInfoContent105.Text;
            currentAirportInfo.naviEquipment[1].info[06] = equipmentInfoContent106.Text;
            currentAirportInfo.naviEquipment[1].info[07] = equipmentInfoContent107.Text;
            currentAirportInfo.naviEquipment[1].info[08] = equipmentInfoContent108.Text;
            currentAirportInfo.naviEquipment[1].info[09] = equipmentInfoContent109.Text;
            currentAirportInfo.naviEquipment[1].info[10] = equipmentInfoContent110.Text;
            currentAirportInfo.naviEquipment[1].info[11] = equipmentInfoContent111.Text;
            currentAirportInfo.naviEquipment[1].info[12] = equipmentInfoContent112.Text;
            currentAirportInfo.naviEquipment[2].info[00] = equipmentInfoContent200.Text;
            currentAirportInfo.naviEquipment[2].info[01] = equipmentInfoContent201.Text;
            currentAirportInfo.naviEquipment[2].info[02] = equipmentInfoContent202.Text;
            currentAirportInfo.naviEquipment[2].info[03] = equipmentInfoContent203.Text;
            currentAirportInfo.naviEquipment[2].info[04] = equipmentInfoContent204.Text;
            currentAirportInfo.naviEquipment[2].info[05] = equipmentInfoContent205.Text;
            currentAirportInfo.naviEquipment[2].info[06] = equipmentInfoContent206.Text;
            currentAirportInfo.naviEquipment[2].info[07] = equipmentInfoContent207.Text;
            currentAirportInfo.naviEquipment[2].info[08] = equipmentInfoContent208.Text;
            currentAirportInfo.naviEquipment[2].info[09] = equipmentInfoContent209.Text;
            currentAirportInfo.naviEquipment[2].info[10] = equipmentInfoContent210.Text;
            currentAirportInfo.naviEquipment[2].info[11] = equipmentInfoContent211.Text;
            currentAirportInfo.naviEquipment[2].info[12] = equipmentInfoContent212.Text;
            currentAirportInfo.naviEquipment[3].info[00] = equipmentInfoContent300.Text;
            currentAirportInfo.naviEquipment[3].info[01] = equipmentInfoContent301.Text;
            currentAirportInfo.naviEquipment[3].info[02] = equipmentInfoContent302.Text;
            currentAirportInfo.naviEquipment[3].info[03] = equipmentInfoContent303.Text;
            currentAirportInfo.naviEquipment[3].info[04] = equipmentInfoContent304.Text;
            currentAirportInfo.naviEquipment[3].info[05] = equipmentInfoContent305.Text;
            currentAirportInfo.naviEquipment[3].info[06] = equipmentInfoContent306.Text;
            currentAirportInfo.naviEquipment[3].info[07] = equipmentInfoContent307.Text;
            currentAirportInfo.naviEquipment[3].info[08] = equipmentInfoContent308.Text;
            currentAirportInfo.naviEquipment[3].info[09] = equipmentInfoContent309.Text;
            currentAirportInfo.naviEquipment[3].info[10] = equipmentInfoContent310.Text;
            currentAirportInfo.naviEquipment[3].info[11] = equipmentInfoContent311.Text;
            currentAirportInfo.naviEquipment[3].info[12] = equipmentInfoContent312.Text;
            currentAirportInfo.naviEquipment[4].info[00] = equipmentInfoContent400.Text;
            currentAirportInfo.naviEquipment[4].info[01] = equipmentInfoContent401.Text;
            currentAirportInfo.naviEquipment[4].info[02] = equipmentInfoContent402.Text;
            currentAirportInfo.naviEquipment[4].info[03] = equipmentInfoContent403.Text;
            currentAirportInfo.naviEquipment[4].info[04] = equipmentInfoContent404.Text;
            currentAirportInfo.naviEquipment[4].info[05] = equipmentInfoContent405.Text;
            currentAirportInfo.naviEquipment[4].info[06] = equipmentInfoContent406.Text;
            currentAirportInfo.naviEquipment[4].info[07] = equipmentInfoContent407.Text;
            currentAirportInfo.naviEquipment[4].info[08] = equipmentInfoContent408.Text;
            currentAirportInfo.naviEquipment[4].info[09] = equipmentInfoContent409.Text;
            currentAirportInfo.naviEquipment[4].info[10] = equipmentInfoContent410.Text;
            currentAirportInfo.naviEquipment[4].info[11] = equipmentInfoContent411.Text;
            currentAirportInfo.naviEquipment[4].info[12] = equipmentInfoContent412.Text;
            currentAirportInfo.naviEquipment[5].info[00] = equipmentInfoContent500.Text;
            currentAirportInfo.naviEquipment[5].info[01] = equipmentInfoContent501.Text;
            currentAirportInfo.naviEquipment[5].info[02] = equipmentInfoContent502.Text;
            currentAirportInfo.naviEquipment[5].info[03] = equipmentInfoContent503.Text;
            currentAirportInfo.naviEquipment[5].info[04] = equipmentInfoContent504.Text;
            currentAirportInfo.naviEquipment[5].info[05] = equipmentInfoContent505.Text;
            currentAirportInfo.naviEquipment[5].info[06] = equipmentInfoContent506.Text;
            currentAirportInfo.naviEquipment[5].info[07] = equipmentInfoContent507.Text;
            currentAirportInfo.naviEquipment[5].info[08] = equipmentInfoContent508.Text;
            currentAirportInfo.naviEquipment[5].info[09] = equipmentInfoContent509.Text;
            currentAirportInfo.naviEquipment[5].info[10] = equipmentInfoContent510.Text;
            currentAirportInfo.naviEquipment[5].info[11] = equipmentInfoContent511.Text;
            currentAirportInfo.naviEquipment[5].info[12] = equipmentInfoContent512.Text;
            currentAirportInfo.naviEquipment[6].info[00] = equipmentInfoContent600.Text;
            currentAirportInfo.naviEquipment[6].info[01] = equipmentInfoContent601.Text;
            currentAirportInfo.naviEquipment[6].info[02] = equipmentInfoContent602.Text;
            currentAirportInfo.naviEquipment[6].info[03] = equipmentInfoContent603.Text;
            currentAirportInfo.naviEquipment[6].info[04] = equipmentInfoContent604.Text;
            currentAirportInfo.naviEquipment[6].info[05] = equipmentInfoContent605.Text;
            currentAirportInfo.naviEquipment[6].info[06] = equipmentInfoContent606.Text;
            currentAirportInfo.naviEquipment[6].info[07] = equipmentInfoContent607.Text;
            currentAirportInfo.naviEquipment[6].info[08] = equipmentInfoContent608.Text;
            currentAirportInfo.naviEquipment[6].info[09] = equipmentInfoContent609.Text;
            currentAirportInfo.naviEquipment[6].info[10] = equipmentInfoContent610.Text;
            currentAirportInfo.naviEquipment[6].info[11] = equipmentInfoContent611.Text;
            currentAirportInfo.naviEquipment[6].info[12] = equipmentInfoContent612.Text;
            currentAirportInfo.naviEquipment[7].info[00] = equipmentInfoContent700.Text;
            currentAirportInfo.naviEquipment[7].info[01] = equipmentInfoContent701.Text;
            currentAirportInfo.naviEquipment[7].info[02] = equipmentInfoContent702.Text;
            currentAirportInfo.naviEquipment[7].info[03] = equipmentInfoContent703.Text;
            currentAirportInfo.naviEquipment[7].info[04] = equipmentInfoContent704.Text;
            currentAirportInfo.naviEquipment[7].info[05] = equipmentInfoContent705.Text;
            currentAirportInfo.naviEquipment[7].info[06] = equipmentInfoContent706.Text;
            currentAirportInfo.naviEquipment[7].info[07] = equipmentInfoContent707.Text;
            currentAirportInfo.naviEquipment[7].info[08] = equipmentInfoContent708.Text;
            currentAirportInfo.naviEquipment[7].info[09] = equipmentInfoContent709.Text;
            currentAirportInfo.naviEquipment[7].info[10] = equipmentInfoContent710.Text;
            currentAirportInfo.naviEquipment[7].info[11] = equipmentInfoContent711.Text;
            currentAirportInfo.naviEquipment[7].info[12] = equipmentInfoContent712.Text;
            currentAirportInfo.naviEquipment[8].info[00] = equipmentInfoContent800.Text;
            currentAirportInfo.naviEquipment[8].info[01] = equipmentInfoContent801.Text;
            currentAirportInfo.naviEquipment[8].info[02] = equipmentInfoContent802.Text;
            currentAirportInfo.naviEquipment[8].info[03] = equipmentInfoContent803.Text;
            currentAirportInfo.naviEquipment[8].info[04] = equipmentInfoContent804.Text;
            currentAirportInfo.naviEquipment[8].info[05] = equipmentInfoContent805.Text;
            currentAirportInfo.naviEquipment[8].info[06] = equipmentInfoContent806.Text;
            currentAirportInfo.naviEquipment[8].info[07] = equipmentInfoContent807.Text;
            currentAirportInfo.naviEquipment[8].info[08] = equipmentInfoContent808.Text;
            currentAirportInfo.naviEquipment[8].info[09] = equipmentInfoContent809.Text;
            currentAirportInfo.naviEquipment[8].info[10] = equipmentInfoContent810.Text;
            currentAirportInfo.naviEquipment[8].info[11] = equipmentInfoContent811.Text;
            currentAirportInfo.naviEquipment[8].info[12] = equipmentInfoContent812.Text;
            currentAirportInfo.naviEquipment[9].info[00] = equipmentInfoContent900.Text;
            currentAirportInfo.naviEquipment[9].info[01] = equipmentInfoContent901.Text;
            currentAirportInfo.naviEquipment[9].info[02] = equipmentInfoContent902.Text;
            currentAirportInfo.naviEquipment[9].info[03] = equipmentInfoContent903.Text;
            currentAirportInfo.naviEquipment[9].info[04] = equipmentInfoContent904.Text;
            currentAirportInfo.naviEquipment[9].info[05] = equipmentInfoContent905.Text;
            currentAirportInfo.naviEquipment[9].info[06] = equipmentInfoContent906.Text;
            currentAirportInfo.naviEquipment[9].info[07] = equipmentInfoContent907.Text;
            currentAirportInfo.naviEquipment[9].info[08] = equipmentInfoContent908.Text;
            currentAirportInfo.naviEquipment[9].info[09] = equipmentInfoContent909.Text;
            currentAirportInfo.naviEquipment[9].info[10] = equipmentInfoContent910.Text;
            currentAirportInfo.naviEquipment[9].info[11] = equipmentInfoContent911.Text;
            currentAirportInfo.naviEquipment[9].info[12] = equipmentInfoContent912.Text;
            currentAirportInfo.naviEquipment[10].info[00] = equipmentInfoContent1000.Text;
            currentAirportInfo.naviEquipment[10].info[01] = equipmentInfoContent1001.Text;
            currentAirportInfo.naviEquipment[10].info[02] = equipmentInfoContent1002.Text;
            currentAirportInfo.naviEquipment[10].info[03] = equipmentInfoContent1003.Text;
            currentAirportInfo.naviEquipment[10].info[04] = equipmentInfoContent1004.Text;
            currentAirportInfo.naviEquipment[10].info[05] = equipmentInfoContent1005.Text;
            currentAirportInfo.naviEquipment[10].info[06] = equipmentInfoContent1006.Text;
            currentAirportInfo.naviEquipment[10].info[07] = equipmentInfoContent1007.Text;
            currentAirportInfo.naviEquipment[10].info[08] = equipmentInfoContent1008.Text;
            currentAirportInfo.naviEquipment[10].info[09] = equipmentInfoContent1009.Text;
            currentAirportInfo.naviEquipment[10].info[10] = equipmentInfoContent1010.Text;
            currentAirportInfo.naviEquipment[10].info[11] = equipmentInfoContent1011.Text;
            currentAirportInfo.naviEquipment[10].info[12] = equipmentInfoContent1012.Text;
            currentAirportInfo.naviEquipment[11].info[00] = equipmentInfoContent1100.Text;
            currentAirportInfo.naviEquipment[11].info[01] = equipmentInfoContent1101.Text;
            currentAirportInfo.naviEquipment[11].info[02] = equipmentInfoContent1102.Text;
            currentAirportInfo.naviEquipment[11].info[03] = equipmentInfoContent1103.Text;
            currentAirportInfo.naviEquipment[11].info[04] = equipmentInfoContent1104.Text;
            currentAirportInfo.naviEquipment[11].info[05] = equipmentInfoContent1105.Text;
            currentAirportInfo.naviEquipment[11].info[06] = equipmentInfoContent1106.Text;
            currentAirportInfo.naviEquipment[11].info[07] = equipmentInfoContent1107.Text;
            currentAirportInfo.naviEquipment[11].info[08] = equipmentInfoContent1108.Text;
            currentAirportInfo.naviEquipment[11].info[09] = equipmentInfoContent1109.Text;
            currentAirportInfo.naviEquipment[11].info[10] = equipmentInfoContent1110.Text;
            currentAirportInfo.naviEquipment[11].info[11] = equipmentInfoContent1111.Text;
            currentAirportInfo.naviEquipment[11].info[12] = equipmentInfoContent1112.Text;
            currentAirportInfo.naviEquipment[12].info[00] = equipmentInfoContent1200.Text;
            currentAirportInfo.naviEquipment[12].info[01] = equipmentInfoContent1201.Text;
            currentAirportInfo.naviEquipment[12].info[02] = equipmentInfoContent1202.Text;
            currentAirportInfo.naviEquipment[12].info[03] = equipmentInfoContent1203.Text;
            currentAirportInfo.naviEquipment[12].info[04] = equipmentInfoContent1204.Text;
            currentAirportInfo.naviEquipment[12].info[05] = equipmentInfoContent1205.Text;
            currentAirportInfo.naviEquipment[12].info[06] = equipmentInfoContent1206.Text;
            currentAirportInfo.naviEquipment[12].info[07] = equipmentInfoContent1207.Text;
            currentAirportInfo.naviEquipment[12].info[08] = equipmentInfoContent1208.Text;
            currentAirportInfo.naviEquipment[12].info[09] = equipmentInfoContent1209.Text;
            currentAirportInfo.naviEquipment[12].info[10] = equipmentInfoContent1210.Text;
            currentAirportInfo.naviEquipment[12].info[11] = equipmentInfoContent1211.Text;
            currentAirportInfo.naviEquipment[12].info[12] = equipmentInfoContent1212.Text;
            currentAirportInfo.naviEquipment[13].info[00] = equipmentInfoContent1300.Text;
            currentAirportInfo.naviEquipment[13].info[01] = equipmentInfoContent1301.Text;
            currentAirportInfo.naviEquipment[13].info[02] = equipmentInfoContent1302.Text;
            currentAirportInfo.naviEquipment[13].info[03] = equipmentInfoContent1303.Text;
            currentAirportInfo.naviEquipment[13].info[04] = equipmentInfoContent1304.Text;
            currentAirportInfo.naviEquipment[13].info[05] = equipmentInfoContent1305.Text;
            currentAirportInfo.naviEquipment[13].info[06] = equipmentInfoContent1306.Text;
            currentAirportInfo.naviEquipment[13].info[07] = equipmentInfoContent1307.Text;
            currentAirportInfo.naviEquipment[13].info[08] = equipmentInfoContent1308.Text;
            currentAirportInfo.naviEquipment[13].info[09] = equipmentInfoContent1309.Text;
            currentAirportInfo.naviEquipment[13].info[10] = equipmentInfoContent1310.Text;
            currentAirportInfo.naviEquipment[13].info[11] = equipmentInfoContent1311.Text;
            currentAirportInfo.naviEquipment[13].info[12] = equipmentInfoContent1312.Text;
            currentAirportInfo.naviEquipment[14].info[00] = equipmentInfoContent1400.Text;
            currentAirportInfo.naviEquipment[14].info[01] = equipmentInfoContent1401.Text;
            currentAirportInfo.naviEquipment[14].info[02] = equipmentInfoContent1402.Text;
            currentAirportInfo.naviEquipment[14].info[03] = equipmentInfoContent1403.Text;
            currentAirportInfo.naviEquipment[14].info[04] = equipmentInfoContent1404.Text;
            currentAirportInfo.naviEquipment[14].info[05] = equipmentInfoContent1405.Text;
            currentAirportInfo.naviEquipment[14].info[06] = equipmentInfoContent1406.Text;
            currentAirportInfo.naviEquipment[14].info[07] = equipmentInfoContent1407.Text;
            currentAirportInfo.naviEquipment[14].info[08] = equipmentInfoContent1408.Text;
            currentAirportInfo.naviEquipment[14].info[09] = equipmentInfoContent1409.Text;
            currentAirportInfo.naviEquipment[14].info[10] = equipmentInfoContent1410.Text;
            currentAirportInfo.naviEquipment[14].info[11] = equipmentInfoContent1411.Text;
            currentAirportInfo.naviEquipment[14].info[12] = equipmentInfoContent1412.Text;
            currentAirportInfo.naviEquipment[15].info[00] = equipmentInfoContent1500.Text;
            currentAirportInfo.naviEquipment[15].info[01] = equipmentInfoContent1501.Text;
            currentAirportInfo.naviEquipment[15].info[02] = equipmentInfoContent1502.Text;
            currentAirportInfo.naviEquipment[15].info[03] = equipmentInfoContent1503.Text;
            currentAirportInfo.naviEquipment[15].info[04] = equipmentInfoContent1504.Text;
            currentAirportInfo.naviEquipment[15].info[05] = equipmentInfoContent1505.Text;
            currentAirportInfo.naviEquipment[15].info[06] = equipmentInfoContent1506.Text;
            currentAirportInfo.naviEquipment[15].info[07] = equipmentInfoContent1507.Text;
            currentAirportInfo.naviEquipment[15].info[08] = equipmentInfoContent1508.Text;
            currentAirportInfo.naviEquipment[15].info[09] = equipmentInfoContent1509.Text;
            currentAirportInfo.naviEquipment[15].info[10] = equipmentInfoContent1510.Text;
            currentAirportInfo.naviEquipment[15].info[11] = equipmentInfoContent1511.Text;
            currentAirportInfo.naviEquipment[15].info[12] = equipmentInfoContent1512.Text;
            currentAirportInfo.naviEquipment[16].info[00] = equipmentInfoContent1600.Text;
            currentAirportInfo.naviEquipment[16].info[01] = equipmentInfoContent1601.Text;
            currentAirportInfo.naviEquipment[16].info[02] = equipmentInfoContent1602.Text;
            currentAirportInfo.naviEquipment[16].info[03] = equipmentInfoContent1603.Text;
            currentAirportInfo.naviEquipment[16].info[04] = equipmentInfoContent1604.Text;
            currentAirportInfo.naviEquipment[16].info[05] = equipmentInfoContent1605.Text;
            currentAirportInfo.naviEquipment[16].info[06] = equipmentInfoContent1606.Text;
            currentAirportInfo.naviEquipment[16].info[07] = equipmentInfoContent1607.Text;
            currentAirportInfo.naviEquipment[16].info[08] = equipmentInfoContent1608.Text;
            currentAirportInfo.naviEquipment[16].info[09] = equipmentInfoContent1609.Text;
            currentAirportInfo.naviEquipment[16].info[10] = equipmentInfoContent1610.Text;
            currentAirportInfo.naviEquipment[16].info[11] = equipmentInfoContent1611.Text;
            currentAirportInfo.naviEquipment[16].info[12] = equipmentInfoContent1612.Text;
            currentAirportInfo.naviEquipment[17].info[00] = equipmentInfoContent1700.Text;
            currentAirportInfo.naviEquipment[17].info[01] = equipmentInfoContent1701.Text;
            currentAirportInfo.naviEquipment[17].info[02] = equipmentInfoContent1702.Text;
            currentAirportInfo.naviEquipment[17].info[03] = equipmentInfoContent1703.Text;
            currentAirportInfo.naviEquipment[17].info[04] = equipmentInfoContent1704.Text;
            currentAirportInfo.naviEquipment[17].info[05] = equipmentInfoContent1705.Text;
            currentAirportInfo.naviEquipment[17].info[06] = equipmentInfoContent1706.Text;
            currentAirportInfo.naviEquipment[17].info[07] = equipmentInfoContent1707.Text;
            currentAirportInfo.naviEquipment[17].info[08] = equipmentInfoContent1708.Text;
            currentAirportInfo.naviEquipment[17].info[09] = equipmentInfoContent1709.Text;
            currentAirportInfo.naviEquipment[17].info[10] = equipmentInfoContent1710.Text;
            currentAirportInfo.naviEquipment[17].info[11] = equipmentInfoContent1711.Text;
            currentAirportInfo.naviEquipment[17].info[12] = equipmentInfoContent1712.Text;
            currentAirportInfo.naviEquipment[18].info[00] = equipmentInfoContent1800.Text;
            currentAirportInfo.naviEquipment[18].info[01] = equipmentInfoContent1801.Text;
            currentAirportInfo.naviEquipment[18].info[02] = equipmentInfoContent1802.Text;
            currentAirportInfo.naviEquipment[18].info[03] = equipmentInfoContent1803.Text;
            currentAirportInfo.naviEquipment[18].info[04] = equipmentInfoContent1804.Text;
            currentAirportInfo.naviEquipment[18].info[05] = equipmentInfoContent1805.Text;
            currentAirportInfo.naviEquipment[18].info[06] = equipmentInfoContent1806.Text;
            currentAirportInfo.naviEquipment[18].info[07] = equipmentInfoContent1807.Text;
            currentAirportInfo.naviEquipment[18].info[08] = equipmentInfoContent1808.Text;
            currentAirportInfo.naviEquipment[18].info[09] = equipmentInfoContent1809.Text;
            currentAirportInfo.naviEquipment[18].info[10] = equipmentInfoContent1810.Text;
            currentAirportInfo.naviEquipment[18].info[11] = equipmentInfoContent1811.Text;
            currentAirportInfo.naviEquipment[18].info[12] = equipmentInfoContent1812.Text;
            currentAirportInfo.naviEquipment[19].info[00] = equipmentInfoContent1900.Text;
            currentAirportInfo.naviEquipment[19].info[01] = equipmentInfoContent1901.Text;
            currentAirportInfo.naviEquipment[19].info[02] = equipmentInfoContent1902.Text;
            currentAirportInfo.naviEquipment[19].info[03] = equipmentInfoContent1903.Text;
            currentAirportInfo.naviEquipment[19].info[04] = equipmentInfoContent1904.Text;
            currentAirportInfo.naviEquipment[19].info[05] = equipmentInfoContent1905.Text;
            currentAirportInfo.naviEquipment[19].info[06] = equipmentInfoContent1906.Text;
            currentAirportInfo.naviEquipment[19].info[07] = equipmentInfoContent1907.Text;
            currentAirportInfo.naviEquipment[19].info[08] = equipmentInfoContent1908.Text;
            currentAirportInfo.naviEquipment[19].info[09] = equipmentInfoContent1909.Text;
            currentAirportInfo.naviEquipment[19].info[10] = equipmentInfoContent1910.Text;
            currentAirportInfo.naviEquipment[19].info[11] = equipmentInfoContent1911.Text;
            currentAirportInfo.naviEquipment[19].info[12] = equipmentInfoContent1912.Text;
            currentAirportInfo.naviEquipment[20].info[00] = equipmentInfoContent2000.Text;
            currentAirportInfo.naviEquipment[20].info[01] = equipmentInfoContent2001.Text;
            currentAirportInfo.naviEquipment[20].info[02] = equipmentInfoContent2002.Text;
            currentAirportInfo.naviEquipment[20].info[03] = equipmentInfoContent2003.Text;
            currentAirportInfo.naviEquipment[20].info[04] = equipmentInfoContent2004.Text;
            currentAirportInfo.naviEquipment[20].info[05] = equipmentInfoContent2005.Text;
            currentAirportInfo.naviEquipment[20].info[06] = equipmentInfoContent2006.Text;
            currentAirportInfo.naviEquipment[20].info[07] = equipmentInfoContent2007.Text;
            currentAirportInfo.naviEquipment[20].info[08] = equipmentInfoContent2008.Text;
            currentAirportInfo.naviEquipment[20].info[09] = equipmentInfoContent2009.Text;
            currentAirportInfo.naviEquipment[20].info[10] = equipmentInfoContent2010.Text;
            currentAirportInfo.naviEquipment[20].info[11] = equipmentInfoContent2011.Text;
            currentAirportInfo.naviEquipment[20].info[12] = equipmentInfoContent2012.Text;
            currentAirportInfo.naviEquipment[21].info[00] = equipmentInfoContent2100.Text;
            currentAirportInfo.naviEquipment[21].info[01] = equipmentInfoContent2101.Text;
            currentAirportInfo.naviEquipment[21].info[02] = equipmentInfoContent2102.Text;
            currentAirportInfo.naviEquipment[21].info[03] = equipmentInfoContent2103.Text;
            currentAirportInfo.naviEquipment[21].info[04] = equipmentInfoContent2104.Text;
            currentAirportInfo.naviEquipment[21].info[05] = equipmentInfoContent2105.Text;
            currentAirportInfo.naviEquipment[21].info[06] = equipmentInfoContent2106.Text;
            currentAirportInfo.naviEquipment[21].info[07] = equipmentInfoContent2107.Text;
            currentAirportInfo.naviEquipment[21].info[08] = equipmentInfoContent2108.Text;
            currentAirportInfo.naviEquipment[21].info[09] = equipmentInfoContent2109.Text;
            currentAirportInfo.naviEquipment[21].info[10] = equipmentInfoContent2110.Text;
            currentAirportInfo.naviEquipment[21].info[11] = equipmentInfoContent2111.Text;
            currentAirportInfo.naviEquipment[21].info[12] = equipmentInfoContent2112.Text;
            currentAirportInfo.naviEquipment[22].info[00] = equipmentInfoContent2200.Text;
            currentAirportInfo.naviEquipment[22].info[01] = equipmentInfoContent2201.Text;
            currentAirportInfo.naviEquipment[22].info[02] = equipmentInfoContent2202.Text;
            currentAirportInfo.naviEquipment[22].info[03] = equipmentInfoContent2203.Text;
            currentAirportInfo.naviEquipment[22].info[04] = equipmentInfoContent2204.Text;
            currentAirportInfo.naviEquipment[22].info[05] = equipmentInfoContent2205.Text;
            currentAirportInfo.naviEquipment[22].info[06] = equipmentInfoContent2206.Text;
            currentAirportInfo.naviEquipment[22].info[07] = equipmentInfoContent2207.Text;
            currentAirportInfo.naviEquipment[22].info[08] = equipmentInfoContent2208.Text;
            currentAirportInfo.naviEquipment[22].info[09] = equipmentInfoContent2209.Text;
            currentAirportInfo.naviEquipment[22].info[10] = equipmentInfoContent2210.Text;
            currentAirportInfo.naviEquipment[22].info[11] = equipmentInfoContent2211.Text;
            currentAirportInfo.naviEquipment[22].info[12] = equipmentInfoContent2212.Text;
            currentAirportInfo.naviEquipment[23].info[00] = equipmentInfoContent2300.Text;
            currentAirportInfo.naviEquipment[23].info[01] = equipmentInfoContent2301.Text;
            currentAirportInfo.naviEquipment[23].info[02] = equipmentInfoContent2302.Text;
            currentAirportInfo.naviEquipment[23].info[03] = equipmentInfoContent2303.Text;
            currentAirportInfo.naviEquipment[23].info[04] = equipmentInfoContent2304.Text;
            currentAirportInfo.naviEquipment[23].info[05] = equipmentInfoContent2305.Text;
            currentAirportInfo.naviEquipment[23].info[06] = equipmentInfoContent2306.Text;
            currentAirportInfo.naviEquipment[23].info[07] = equipmentInfoContent2307.Text;
            currentAirportInfo.naviEquipment[23].info[08] = equipmentInfoContent2308.Text;
            currentAirportInfo.naviEquipment[23].info[09] = equipmentInfoContent2309.Text;
            currentAirportInfo.naviEquipment[23].info[10] = equipmentInfoContent2310.Text;
            currentAirportInfo.naviEquipment[23].info[11] = equipmentInfoContent2311.Text;
            currentAirportInfo.naviEquipment[23].info[12] = equipmentInfoContent2312.Text;
            currentAirportInfo.naviEquipment[24].info[00] = equipmentInfoContent2400.Text;
            currentAirportInfo.naviEquipment[24].info[01] = equipmentInfoContent2401.Text;
            currentAirportInfo.naviEquipment[24].info[02] = equipmentInfoContent2402.Text;
            currentAirportInfo.naviEquipment[24].info[03] = equipmentInfoContent2403.Text;
            currentAirportInfo.naviEquipment[24].info[04] = equipmentInfoContent2404.Text;
            currentAirportInfo.naviEquipment[24].info[05] = equipmentInfoContent2405.Text;
            currentAirportInfo.naviEquipment[24].info[06] = equipmentInfoContent2406.Text;
            currentAirportInfo.naviEquipment[24].info[07] = equipmentInfoContent2407.Text;
            currentAirportInfo.naviEquipment[24].info[08] = equipmentInfoContent2408.Text;
            currentAirportInfo.naviEquipment[24].info[09] = equipmentInfoContent2409.Text;
            currentAirportInfo.naviEquipment[24].info[10] = equipmentInfoContent2410.Text;
            currentAirportInfo.naviEquipment[24].info[11] = equipmentInfoContent2411.Text;
            currentAirportInfo.naviEquipment[24].info[12] = equipmentInfoContent2412.Text;
            currentAirportInfo.naviEquipment[25].info[00] = equipmentInfoContent2500.Text;
            currentAirportInfo.naviEquipment[25].info[01] = equipmentInfoContent2501.Text;
            currentAirportInfo.naviEquipment[25].info[02] = equipmentInfoContent2502.Text;
            currentAirportInfo.naviEquipment[25].info[03] = equipmentInfoContent2503.Text;
            currentAirportInfo.naviEquipment[25].info[04] = equipmentInfoContent2504.Text;
            currentAirportInfo.naviEquipment[25].info[05] = equipmentInfoContent2505.Text;
            currentAirportInfo.naviEquipment[25].info[06] = equipmentInfoContent2506.Text;
            currentAirportInfo.naviEquipment[25].info[07] = equipmentInfoContent2507.Text;
            currentAirportInfo.naviEquipment[25].info[08] = equipmentInfoContent2508.Text;
            currentAirportInfo.naviEquipment[25].info[09] = equipmentInfoContent2509.Text;
            currentAirportInfo.naviEquipment[25].info[10] = equipmentInfoContent2510.Text;
            currentAirportInfo.naviEquipment[25].info[11] = equipmentInfoContent2511.Text;
            currentAirportInfo.naviEquipment[25].info[12] = equipmentInfoContent2512.Text;
            currentAirportInfo.naviEquipment[26].info[00] = equipmentInfoContent2600.Text;
            currentAirportInfo.naviEquipment[26].info[01] = equipmentInfoContent2601.Text;
            currentAirportInfo.naviEquipment[26].info[02] = equipmentInfoContent2602.Text;
            currentAirportInfo.naviEquipment[26].info[03] = equipmentInfoContent2603.Text;
            currentAirportInfo.naviEquipment[26].info[04] = equipmentInfoContent2604.Text;
            currentAirportInfo.naviEquipment[26].info[05] = equipmentInfoContent2605.Text;
            currentAirportInfo.naviEquipment[26].info[06] = equipmentInfoContent2606.Text;
            currentAirportInfo.naviEquipment[26].info[07] = equipmentInfoContent2607.Text;
            currentAirportInfo.naviEquipment[26].info[08] = equipmentInfoContent2608.Text;
            currentAirportInfo.naviEquipment[26].info[09] = equipmentInfoContent2609.Text;
            currentAirportInfo.naviEquipment[26].info[10] = equipmentInfoContent2610.Text;
            currentAirportInfo.naviEquipment[26].info[11] = equipmentInfoContent2611.Text;
            currentAirportInfo.naviEquipment[26].info[12] = equipmentInfoContent2612.Text;
            currentAirportInfo.naviEquipment[27].info[00] = equipmentInfoContent2700.Text;
            currentAirportInfo.naviEquipment[27].info[01] = equipmentInfoContent2701.Text;
            currentAirportInfo.naviEquipment[27].info[02] = equipmentInfoContent2702.Text;
            currentAirportInfo.naviEquipment[27].info[03] = equipmentInfoContent2703.Text;
            currentAirportInfo.naviEquipment[27].info[04] = equipmentInfoContent2704.Text;
            currentAirportInfo.naviEquipment[27].info[05] = equipmentInfoContent2705.Text;
            currentAirportInfo.naviEquipment[27].info[06] = equipmentInfoContent2706.Text;
            currentAirportInfo.naviEquipment[27].info[07] = equipmentInfoContent2707.Text;
            currentAirportInfo.naviEquipment[27].info[08] = equipmentInfoContent2708.Text;
            currentAirportInfo.naviEquipment[27].info[09] = equipmentInfoContent2709.Text;
            currentAirportInfo.naviEquipment[27].info[10] = equipmentInfoContent2710.Text;
            currentAirportInfo.naviEquipment[27].info[11] = equipmentInfoContent2711.Text;
            currentAirportInfo.naviEquipment[27].info[12] = equipmentInfoContent2712.Text;
            currentAirportInfo.naviEquipment[28].info[00] = equipmentInfoContent2800.Text;
            currentAirportInfo.naviEquipment[28].info[01] = equipmentInfoContent2801.Text;
            currentAirportInfo.naviEquipment[28].info[02] = equipmentInfoContent2802.Text;
            currentAirportInfo.naviEquipment[28].info[03] = equipmentInfoContent2803.Text;
            currentAirportInfo.naviEquipment[28].info[04] = equipmentInfoContent2804.Text;
            currentAirportInfo.naviEquipment[28].info[05] = equipmentInfoContent2805.Text;
            currentAirportInfo.naviEquipment[28].info[06] = equipmentInfoContent2806.Text;
            currentAirportInfo.naviEquipment[28].info[07] = equipmentInfoContent2807.Text;
            currentAirportInfo.naviEquipment[28].info[08] = equipmentInfoContent2808.Text;
            currentAirportInfo.naviEquipment[28].info[09] = equipmentInfoContent2809.Text;
            currentAirportInfo.naviEquipment[28].info[10] = equipmentInfoContent2810.Text;
            currentAirportInfo.naviEquipment[28].info[11] = equipmentInfoContent2811.Text;
            currentAirportInfo.naviEquipment[28].info[12] = equipmentInfoContent2812.Text;
            currentAirportInfo.naviEquipment[29].info[00] = equipmentInfoContent2900.Text;
            currentAirportInfo.naviEquipment[29].info[01] = equipmentInfoContent2901.Text;
            currentAirportInfo.naviEquipment[29].info[02] = equipmentInfoContent2902.Text;
            currentAirportInfo.naviEquipment[29].info[03] = equipmentInfoContent2903.Text;
            currentAirportInfo.naviEquipment[29].info[04] = equipmentInfoContent2904.Text;
            currentAirportInfo.naviEquipment[29].info[05] = equipmentInfoContent2905.Text;
            currentAirportInfo.naviEquipment[29].info[06] = equipmentInfoContent2906.Text;
            currentAirportInfo.naviEquipment[29].info[07] = equipmentInfoContent2907.Text;
            currentAirportInfo.naviEquipment[29].info[08] = equipmentInfoContent2908.Text;
            currentAirportInfo.naviEquipment[29].info[09] = equipmentInfoContent2909.Text;
            currentAirportInfo.naviEquipment[29].info[10] = equipmentInfoContent2910.Text;
            currentAirportInfo.naviEquipment[29].info[11] = equipmentInfoContent2911.Text;
            currentAirportInfo.naviEquipment[29].info[12] = equipmentInfoContent2912.Text;
            currentAirportInfo.naviEquipment[30].info[00] = equipmentInfoContent3000.Text;
            currentAirportInfo.naviEquipment[30].info[01] = equipmentInfoContent3001.Text;
            currentAirportInfo.naviEquipment[30].info[02] = equipmentInfoContent3002.Text;
            currentAirportInfo.naviEquipment[30].info[03] = equipmentInfoContent3003.Text;
            currentAirportInfo.naviEquipment[30].info[04] = equipmentInfoContent3004.Text;
            currentAirportInfo.naviEquipment[30].info[05] = equipmentInfoContent3005.Text;
            currentAirportInfo.naviEquipment[30].info[06] = equipmentInfoContent3006.Text;
            currentAirportInfo.naviEquipment[30].info[07] = equipmentInfoContent3007.Text;
            currentAirportInfo.naviEquipment[30].info[08] = equipmentInfoContent3008.Text;
            currentAirportInfo.naviEquipment[30].info[09] = equipmentInfoContent3009.Text;
            currentAirportInfo.naviEquipment[30].info[10] = equipmentInfoContent3010.Text;
            currentAirportInfo.naviEquipment[30].info[11] = equipmentInfoContent3011.Text;
            currentAirportInfo.naviEquipment[30].info[12] = equipmentInfoContent3012.Text;
            currentAirportInfo.naviEquipment[31].info[00] = equipmentInfoContent3100.Text;
            currentAirportInfo.naviEquipment[31].info[01] = equipmentInfoContent3101.Text;
            currentAirportInfo.naviEquipment[31].info[02] = equipmentInfoContent3102.Text;
            currentAirportInfo.naviEquipment[31].info[03] = equipmentInfoContent3103.Text;
            currentAirportInfo.naviEquipment[31].info[04] = equipmentInfoContent3104.Text;
            currentAirportInfo.naviEquipment[31].info[05] = equipmentInfoContent3105.Text;
            currentAirportInfo.naviEquipment[31].info[06] = equipmentInfoContent3106.Text;
            currentAirportInfo.naviEquipment[31].info[07] = equipmentInfoContent3107.Text;
            currentAirportInfo.naviEquipment[31].info[08] = equipmentInfoContent3108.Text;
            currentAirportInfo.naviEquipment[31].info[09] = equipmentInfoContent3109.Text;
            currentAirportInfo.naviEquipment[31].info[10] = equipmentInfoContent3110.Text;
            currentAirportInfo.naviEquipment[31].info[11] = equipmentInfoContent3111.Text;
            currentAirportInfo.naviEquipment[31].info[12] = equipmentInfoContent3112.Text;
            currentAirportInfo.naviEquipment[32].info[00] = equipmentInfoContent3200.Text;
            currentAirportInfo.naviEquipment[32].info[01] = equipmentInfoContent3201.Text;
            currentAirportInfo.naviEquipment[32].info[02] = equipmentInfoContent3202.Text;
            currentAirportInfo.naviEquipment[32].info[03] = equipmentInfoContent3203.Text;
            currentAirportInfo.naviEquipment[32].info[04] = equipmentInfoContent3204.Text;
            currentAirportInfo.naviEquipment[32].info[05] = equipmentInfoContent3205.Text;
            currentAirportInfo.naviEquipment[32].info[06] = equipmentInfoContent3206.Text;
            currentAirportInfo.naviEquipment[32].info[07] = equipmentInfoContent3207.Text;
            currentAirportInfo.naviEquipment[32].info[08] = equipmentInfoContent3208.Text;
            currentAirportInfo.naviEquipment[32].info[09] = equipmentInfoContent3209.Text;
            currentAirportInfo.naviEquipment[32].info[10] = equipmentInfoContent3210.Text;
            currentAirportInfo.naviEquipment[32].info[11] = equipmentInfoContent3211.Text;
            currentAirportInfo.naviEquipment[32].info[12] = equipmentInfoContent3212.Text;
            currentAirportInfo.naviEquipment[33].info[00] = equipmentInfoContent3300.Text;
            currentAirportInfo.naviEquipment[33].info[01] = equipmentInfoContent3301.Text;
            currentAirportInfo.naviEquipment[33].info[02] = equipmentInfoContent3302.Text;
            currentAirportInfo.naviEquipment[33].info[03] = equipmentInfoContent3303.Text;
            currentAirportInfo.naviEquipment[33].info[04] = equipmentInfoContent3304.Text;
            currentAirportInfo.naviEquipment[33].info[05] = equipmentInfoContent3305.Text;
            currentAirportInfo.naviEquipment[33].info[06] = equipmentInfoContent3306.Text;
            currentAirportInfo.naviEquipment[33].info[07] = equipmentInfoContent3307.Text;
            currentAirportInfo.naviEquipment[33].info[08] = equipmentInfoContent3308.Text;
            currentAirportInfo.naviEquipment[33].info[09] = equipmentInfoContent3309.Text;
            currentAirportInfo.naviEquipment[33].info[10] = equipmentInfoContent3310.Text;
            currentAirportInfo.naviEquipment[33].info[11] = equipmentInfoContent3311.Text;
            currentAirportInfo.naviEquipment[33].info[12] = equipmentInfoContent3312.Text;
            currentAirportInfo.naviEquipment[34].info[00] = equipmentInfoContent3400.Text;
            currentAirportInfo.naviEquipment[34].info[01] = equipmentInfoContent3401.Text;
            currentAirportInfo.naviEquipment[34].info[02] = equipmentInfoContent3402.Text;
            currentAirportInfo.naviEquipment[34].info[03] = equipmentInfoContent3403.Text;
            currentAirportInfo.naviEquipment[34].info[04] = equipmentInfoContent3404.Text;
            currentAirportInfo.naviEquipment[34].info[05] = equipmentInfoContent3405.Text;
            currentAirportInfo.naviEquipment[34].info[06] = equipmentInfoContent3406.Text;
            currentAirportInfo.naviEquipment[34].info[07] = equipmentInfoContent3407.Text;
            currentAirportInfo.naviEquipment[34].info[08] = equipmentInfoContent3408.Text;
            currentAirportInfo.naviEquipment[34].info[09] = equipmentInfoContent3409.Text;
            currentAirportInfo.naviEquipment[34].info[10] = equipmentInfoContent3410.Text;
            currentAirportInfo.naviEquipment[34].info[11] = equipmentInfoContent3411.Text;
            currentAirportInfo.naviEquipment[34].info[12] = equipmentInfoContent3412.Text;
            currentAirportInfo.naviEquipment[35].info[00] = equipmentInfoContent3500.Text;
            currentAirportInfo.naviEquipment[35].info[01] = equipmentInfoContent3501.Text;
            currentAirportInfo.naviEquipment[35].info[02] = equipmentInfoContent3502.Text;
            currentAirportInfo.naviEquipment[35].info[03] = equipmentInfoContent3503.Text;
            currentAirportInfo.naviEquipment[35].info[04] = equipmentInfoContent3504.Text;
            currentAirportInfo.naviEquipment[35].info[05] = equipmentInfoContent3505.Text;
            currentAirportInfo.naviEquipment[35].info[06] = equipmentInfoContent3506.Text;
            currentAirportInfo.naviEquipment[35].info[07] = equipmentInfoContent3507.Text;
            currentAirportInfo.naviEquipment[35].info[08] = equipmentInfoContent3508.Text;
            currentAirportInfo.naviEquipment[35].info[09] = equipmentInfoContent3509.Text;
            currentAirportInfo.naviEquipment[35].info[10] = equipmentInfoContent3510.Text;
            currentAirportInfo.naviEquipment[35].info[11] = equipmentInfoContent3511.Text;
            currentAirportInfo.naviEquipment[35].info[12] = equipmentInfoContent3512.Text;
            currentAirportInfo.naviEquipment[36].info[00] = equipmentInfoContent3600.Text;
            currentAirportInfo.naviEquipment[36].info[01] = equipmentInfoContent3601.Text;
            currentAirportInfo.naviEquipment[36].info[02] = equipmentInfoContent3602.Text;
            currentAirportInfo.naviEquipment[36].info[03] = equipmentInfoContent3603.Text;
            currentAirportInfo.naviEquipment[36].info[04] = equipmentInfoContent3604.Text;
            currentAirportInfo.naviEquipment[36].info[05] = equipmentInfoContent3605.Text;
            currentAirportInfo.naviEquipment[36].info[06] = equipmentInfoContent3606.Text;
            currentAirportInfo.naviEquipment[36].info[07] = equipmentInfoContent3607.Text;
            currentAirportInfo.naviEquipment[36].info[08] = equipmentInfoContent3608.Text;
            currentAirportInfo.naviEquipment[36].info[09] = equipmentInfoContent3609.Text;
            currentAirportInfo.naviEquipment[36].info[10] = equipmentInfoContent3610.Text;
            currentAirportInfo.naviEquipment[36].info[11] = equipmentInfoContent3611.Text;
            currentAirportInfo.naviEquipment[36].info[12] = equipmentInfoContent3612.Text;
            currentAirportInfo.naviEquipment[37].info[00] = equipmentInfoContent3700.Text;
            currentAirportInfo.naviEquipment[37].info[01] = equipmentInfoContent3701.Text;
            currentAirportInfo.naviEquipment[37].info[02] = equipmentInfoContent3702.Text;
            currentAirportInfo.naviEquipment[37].info[03] = equipmentInfoContent3703.Text;
            currentAirportInfo.naviEquipment[37].info[04] = equipmentInfoContent3704.Text;
            currentAirportInfo.naviEquipment[37].info[05] = equipmentInfoContent3705.Text;
            currentAirportInfo.naviEquipment[37].info[06] = equipmentInfoContent3706.Text;
            currentAirportInfo.naviEquipment[37].info[07] = equipmentInfoContent3707.Text;
            currentAirportInfo.naviEquipment[37].info[08] = equipmentInfoContent3708.Text;
            currentAirportInfo.naviEquipment[37].info[09] = equipmentInfoContent3709.Text;
            currentAirportInfo.naviEquipment[37].info[10] = equipmentInfoContent3710.Text;
            currentAirportInfo.naviEquipment[37].info[11] = equipmentInfoContent3711.Text;
            currentAirportInfo.naviEquipment[37].info[12] = equipmentInfoContent3712.Text;
            currentAirportInfo.naviEquipment[38].info[00] = equipmentInfoContent3800.Text;
            currentAirportInfo.naviEquipment[38].info[01] = equipmentInfoContent3801.Text;
            currentAirportInfo.naviEquipment[38].info[02] = equipmentInfoContent3802.Text;
            currentAirportInfo.naviEquipment[38].info[03] = equipmentInfoContent3803.Text;
            currentAirportInfo.naviEquipment[38].info[04] = equipmentInfoContent3804.Text;
            currentAirportInfo.naviEquipment[38].info[05] = equipmentInfoContent3805.Text;
            currentAirportInfo.naviEquipment[38].info[06] = equipmentInfoContent3806.Text;
            currentAirportInfo.naviEquipment[38].info[07] = equipmentInfoContent3807.Text;
            currentAirportInfo.naviEquipment[38].info[08] = equipmentInfoContent3808.Text;
            currentAirportInfo.naviEquipment[38].info[09] = equipmentInfoContent3809.Text;
            currentAirportInfo.naviEquipment[38].info[10] = equipmentInfoContent3810.Text;
            currentAirportInfo.naviEquipment[38].info[11] = equipmentInfoContent3811.Text;
            currentAirportInfo.naviEquipment[38].info[12] = equipmentInfoContent3812.Text;
            #endregion


            //project
            #region
            //project 1
            currentAirportInfo.project[0].info[0] = projectInfoTab1.IsVisible.ToString();

            //project 2
            currentAirportInfo.project[1].info[0] = projectInfoTab2.IsVisible.ToString();

            //project 3
            currentAirportInfo.project[2].info[0] = projectInfoTab3.IsVisible.ToString();

            //project1
            //info
            currentAirportInfo.project[0].info[1] = project1InfoContent00.Text;
            currentAirportInfo.project[0].info[2] = project1InfoContent01.Text;
            currentAirportInfo.project[0].info[3] = project1InfoContent02.Text;
            currentAirportInfo.project[0].info[4] = project1InfoContent03.Text;
            currentAirportInfo.project[0].info[5] = project1InfoContent04.Text;
            currentAirportInfo.project[0].info[6] = project1InfoContent05.Text;
            currentAirportInfo.project[0].info[7] = project1InfoContent06.Text;
            currentAirportInfo.project[0].info[8] = project1InfoContent07.Text;
            currentAirportInfo.project[0].info[9] = project1InfoContent08.Text;
            currentAirportInfo.project[0].info[10] = project1InfoContent09.Text;
            currentAirportInfo.project[0].info[11] = project1InfoContent10.Text;
            currentAirportInfo.project[0].info[12] = project1InfoContent11.Text;
            currentAirportInfo.project[0].info[13] = project1InfoContent12.Text;
            currentAirportInfo.project[0].info[14] = project1InfoContent13.Text;
            currentAirportInfo.project[0].info[15] = project1InfoContent14.Text;
            //sales
            currentAirportInfo.project[0].sale[0].info[0] = project1SalesContent00.Text;
            currentAirportInfo.project[0].sale[0].info[1] = project1SalesContent01.Text;
            currentAirportInfo.project[0].sale[0].info[2] = project1SalesContent02.Text;
            currentAirportInfo.project[0].sale[0].info[3] = project1SalesContent03.Text;
            currentAirportInfo.project[0].sale[1].info[0] = project1SalesContent10.Text;
            currentAirportInfo.project[0].sale[1].info[1] = project1SalesContent11.Text;
            currentAirportInfo.project[0].sale[1].info[2] = project1SalesContent12.Text;
            currentAirportInfo.project[0].sale[1].info[3] = project1SalesContent13.Text;
            currentAirportInfo.project[0].sale[2].info[0] = project1SalesContent20.Text;
            currentAirportInfo.project[0].sale[2].info[1] = project1SalesContent21.Text;
            currentAirportInfo.project[0].sale[2].info[2] = project1SalesContent22.Text;
            currentAirportInfo.project[0].sale[2].info[3] = project1SalesContent23.Text;
            currentAirportInfo.project[0].sale[3].info[0] = project1SalesContent30.Text;
            currentAirportInfo.project[0].sale[3].info[1] = project1SalesContent31.Text;
            currentAirportInfo.project[0].sale[3].info[2] = project1SalesContent32.Text;
            currentAirportInfo.project[0].sale[3].info[3] = project1SalesContent33.Text;
            currentAirportInfo.project[0].sale[4].info[0] = project1SalesContent40.Text;
            currentAirportInfo.project[0].sale[4].info[1] = project1SalesContent41.Text;
            currentAirportInfo.project[0].sale[4].info[2] = project1SalesContent42.Text;
            currentAirportInfo.project[0].sale[4].info[3] = project1SalesContent43.Text;
            currentAirportInfo.project[0].sale[5].info[0] = project1SalesContent50.Text;
            currentAirportInfo.project[0].sale[5].info[1] = project1SalesContent51.Text;
            currentAirportInfo.project[0].sale[5].info[2] = project1SalesContent52.Text;
            currentAirportInfo.project[0].sale[5].info[3] = project1SalesContent53.Text;
            currentAirportInfo.project[0].sale[6].info[0] = project1SalesContent60.Text;
            currentAirportInfo.project[0].sale[6].info[1] = project1SalesContent61.Text;
            currentAirportInfo.project[0].sale[6].info[2] = project1SalesContent62.Text;
            currentAirportInfo.project[0].sale[6].info[3] = project1SalesContent63.Text;
            currentAirportInfo.project[0].sale[7].info[0] = project1SalesContent70.Text;
            currentAirportInfo.project[0].sale[7].info[1] = project1SalesContent71.Text;
            currentAirportInfo.project[0].sale[7].info[2] = project1SalesContent72.Text;
            currentAirportInfo.project[0].sale[7].info[3] = project1SalesContent73.Text;
            currentAirportInfo.project[0].sale[8].info[0] = project1SalesContent80.Text;
            currentAirportInfo.project[0].sale[8].info[1] = project1SalesContent81.Text;
            currentAirportInfo.project[0].sale[8].info[2] = project1SalesContent82.Text;
            currentAirportInfo.project[0].sale[8].info[3] = project1SalesContent83.Text;
            currentAirportInfo.project[0].sale[9].info[0] = project1SalesContent90.Text;
            currentAirportInfo.project[0].sale[9].info[1] = project1SalesContent91.Text;
            currentAirportInfo.project[0].sale[9].info[2] = project1SalesContent92.Text;
            currentAirportInfo.project[0].sale[9].info[3] = project1SalesContent93.Text;
            //boolInfo
            currentAirportInfo.project[0].boolInfo[0] = (bool)project1CheckBox0.IsChecked;
            currentAirportInfo.project[0].boolInfo[1] = (bool)project1CheckBox1.IsChecked;
            currentAirportInfo.project[0].boolInfo[2] = (bool)project1CheckBox2.IsChecked;
            currentAirportInfo.project[0].boolInfo[3] = (bool)project1CheckBox3.IsChecked;
            currentAirportInfo.project[0].boolInfo[4] = (bool)project1CheckBox4.IsChecked;
            currentAirportInfo.project[0].boolInfo[5] = (bool)project1CheckBox5.IsChecked;
            currentAirportInfo.project[0].boolInfo[6] = (bool)project1CheckBox6.IsChecked;
            currentAirportInfo.project[0].boolInfo[7] = (bool)project1CheckBox7.IsChecked;
            currentAirportInfo.project[0].boolInfo[8] = (bool)project1CheckBox8.IsChecked;
            currentAirportInfo.project[0].boolInfo[9] = (bool)project1CheckBox9.IsChecked;
            currentAirportInfo.project[0].boolInfo[10] = (bool)project1CheckBox10.IsChecked;
            currentAirportInfo.project[0].boolInfo[11] = (bool)project1CheckBox11.IsChecked;
            currentAirportInfo.project[0].boolInfo[12] = (bool)project1CheckBox12.IsChecked;
            currentAirportInfo.project[0].boolInfo[13] = (bool)project1CheckBox13.IsChecked;
            currentAirportInfo.project[0].boolInfo[14] = (bool)project1CheckBox14.IsChecked;
            currentAirportInfo.project[0].boolInfo[15] = (bool)project1CheckBox15.IsChecked;
            currentAirportInfo.project[0].boolInfo[16] = (bool)project1CheckBox16.IsChecked;
            currentAirportInfo.project[0].boolInfo[17] = (bool)project1CheckBox17.IsChecked;
            currentAirportInfo.project[0].boolInfo[18] = (bool)project1CheckBox18.IsChecked;
            currentAirportInfo.project[0].boolInfo[19] = (bool)project1CheckBox19.IsChecked;
            currentAirportInfo.project[0].boolInfo[20] = (bool)project1CheckBox20.IsChecked;
            currentAirportInfo.project[0].boolInfo[21] = (bool)project1CheckBox21.IsChecked;
            currentAirportInfo.project[0].boolInfo[22] = (bool)project1CheckBox22.IsChecked;
            currentAirportInfo.project[0].boolInfo[23] = (bool)project1CheckBox23.IsChecked;
            currentAirportInfo.project[0].boolInfo[24] = (bool)project1CheckBox24.IsChecked;

            //project2
            //info
            currentAirportInfo.project[1].info[1] = project2InfoContent00.Text;
            currentAirportInfo.project[1].info[2] = project2InfoContent01.Text;
            currentAirportInfo.project[1].info[3] = project2InfoContent02.Text;
            currentAirportInfo.project[1].info[4] = project2InfoContent03.Text;
            currentAirportInfo.project[1].info[5] = project2InfoContent04.Text;
            currentAirportInfo.project[1].info[6] = project2InfoContent05.Text;
            currentAirportInfo.project[1].info[7] = project2InfoContent06.Text;
            currentAirportInfo.project[1].info[8] = project2InfoContent07.Text;
            currentAirportInfo.project[1].info[9] = project2InfoContent08.Text;
            currentAirportInfo.project[1].info[10] = project2InfoContent09.Text;
            currentAirportInfo.project[1].info[11] = project2InfoContent10.Text;
            currentAirportInfo.project[1].info[12] = project2InfoContent11.Text;
            currentAirportInfo.project[1].info[13] = project2InfoContent12.Text;
            currentAirportInfo.project[1].info[14] = project2InfoContent13.Text;
            currentAirportInfo.project[1].info[15] = project2InfoContent14.Text;
            //sales
            currentAirportInfo.project[1].sale[0].info[0] = project2SalesContent00.Text;
            currentAirportInfo.project[1].sale[0].info[1] = project2SalesContent01.Text;
            currentAirportInfo.project[1].sale[0].info[2] = project2SalesContent02.Text;
            currentAirportInfo.project[1].sale[0].info[3] = project2SalesContent03.Text;
            currentAirportInfo.project[1].sale[1].info[0] = project2SalesContent10.Text;
            currentAirportInfo.project[1].sale[1].info[1] = project2SalesContent11.Text;
            currentAirportInfo.project[1].sale[1].info[2] = project2SalesContent12.Text;
            currentAirportInfo.project[1].sale[1].info[3] = project2SalesContent13.Text;
            currentAirportInfo.project[1].sale[2].info[0] = project2SalesContent20.Text;
            currentAirportInfo.project[1].sale[2].info[1] = project2SalesContent21.Text;
            currentAirportInfo.project[1].sale[2].info[2] = project2SalesContent22.Text;
            currentAirportInfo.project[1].sale[2].info[3] = project2SalesContent23.Text;
            currentAirportInfo.project[1].sale[3].info[0] = project2SalesContent30.Text;
            currentAirportInfo.project[1].sale[3].info[1] = project2SalesContent31.Text;
            currentAirportInfo.project[1].sale[3].info[2] = project2SalesContent32.Text;
            currentAirportInfo.project[1].sale[3].info[3] = project2SalesContent33.Text;
            currentAirportInfo.project[1].sale[4].info[0] = project2SalesContent40.Text;
            currentAirportInfo.project[1].sale[4].info[1] = project2SalesContent41.Text;
            currentAirportInfo.project[1].sale[4].info[2] = project2SalesContent42.Text;
            currentAirportInfo.project[1].sale[4].info[3] = project2SalesContent43.Text;
            currentAirportInfo.project[1].sale[5].info[0] = project2SalesContent50.Text;
            currentAirportInfo.project[1].sale[5].info[1] = project2SalesContent51.Text;
            currentAirportInfo.project[1].sale[5].info[2] = project2SalesContent52.Text;
            currentAirportInfo.project[1].sale[5].info[3] = project2SalesContent53.Text;
            currentAirportInfo.project[1].sale[6].info[0] = project2SalesContent60.Text;
            currentAirportInfo.project[1].sale[6].info[1] = project2SalesContent61.Text;
            currentAirportInfo.project[1].sale[6].info[2] = project2SalesContent62.Text;
            currentAirportInfo.project[1].sale[6].info[3] = project2SalesContent63.Text;
            currentAirportInfo.project[1].sale[7].info[0] = project2SalesContent70.Text;
            currentAirportInfo.project[1].sale[7].info[1] = project2SalesContent71.Text;
            currentAirportInfo.project[1].sale[7].info[2] = project2SalesContent72.Text;
            currentAirportInfo.project[1].sale[7].info[3] = project2SalesContent73.Text;
            currentAirportInfo.project[1].sale[8].info[0] = project2SalesContent80.Text;
            currentAirportInfo.project[1].sale[8].info[1] = project2SalesContent81.Text;
            currentAirportInfo.project[1].sale[8].info[2] = project2SalesContent82.Text;
            currentAirportInfo.project[1].sale[8].info[3] = project2SalesContent83.Text;
            currentAirportInfo.project[1].sale[9].info[0] = project2SalesContent90.Text;
            currentAirportInfo.project[1].sale[9].info[1] = project2SalesContent91.Text;
            currentAirportInfo.project[1].sale[9].info[2] = project2SalesContent92.Text;
            currentAirportInfo.project[1].sale[9].info[3] = project2SalesContent93.Text;
            //boolInfo
            currentAirportInfo.project[1].boolInfo[0] = (bool)project2CheckBox0.IsChecked;
            currentAirportInfo.project[1].boolInfo[1] = (bool)project2CheckBox1.IsChecked;
            currentAirportInfo.project[1].boolInfo[2] = (bool)project2CheckBox2.IsChecked;
            currentAirportInfo.project[1].boolInfo[3] = (bool)project2CheckBox3.IsChecked;
            currentAirportInfo.project[1].boolInfo[4] = (bool)project2CheckBox4.IsChecked;
            currentAirportInfo.project[1].boolInfo[5] = (bool)project2CheckBox5.IsChecked;
            currentAirportInfo.project[1].boolInfo[6] = (bool)project2CheckBox6.IsChecked;
            currentAirportInfo.project[1].boolInfo[7] = (bool)project2CheckBox7.IsChecked;
            currentAirportInfo.project[1].boolInfo[8] = (bool)project2CheckBox8.IsChecked;
            currentAirportInfo.project[1].boolInfo[9] = (bool)project2CheckBox9.IsChecked;
            currentAirportInfo.project[1].boolInfo[10] = (bool)project2CheckBox10.IsChecked;
            currentAirportInfo.project[1].boolInfo[11] = (bool)project2CheckBox11.IsChecked;
            currentAirportInfo.project[1].boolInfo[12] = (bool)project2CheckBox12.IsChecked;
            currentAirportInfo.project[1].boolInfo[13] = (bool)project2CheckBox13.IsChecked;
            currentAirportInfo.project[1].boolInfo[14] = (bool)project2CheckBox14.IsChecked;
            currentAirportInfo.project[1].boolInfo[15] = (bool)project2CheckBox15.IsChecked;
            currentAirportInfo.project[1].boolInfo[16] = (bool)project2CheckBox16.IsChecked;
            currentAirportInfo.project[1].boolInfo[17] = (bool)project2CheckBox17.IsChecked;
            currentAirportInfo.project[1].boolInfo[18] = (bool)project2CheckBox18.IsChecked;
            currentAirportInfo.project[1].boolInfo[19] = (bool)project2CheckBox19.IsChecked;
            currentAirportInfo.project[1].boolInfo[20] = (bool)project2CheckBox20.IsChecked;
            currentAirportInfo.project[1].boolInfo[21] = (bool)project2CheckBox21.IsChecked;
            currentAirportInfo.project[1].boolInfo[22] = (bool)project2CheckBox22.IsChecked;
            currentAirportInfo.project[1].boolInfo[23] = (bool)project2CheckBox23.IsChecked;
            currentAirportInfo.project[1].boolInfo[24] = (bool)project2CheckBox24.IsChecked;


            //project3
            //info
            currentAirportInfo.project[2].info[1] = project3InfoContent00.Text;
            currentAirportInfo.project[2].info[2] = project3InfoContent01.Text;
            currentAirportInfo.project[2].info[3] = project3InfoContent02.Text;
            currentAirportInfo.project[2].info[4] = project3InfoContent03.Text;
            currentAirportInfo.project[2].info[5] = project3InfoContent04.Text;
            currentAirportInfo.project[2].info[6] = project3InfoContent05.Text;
            currentAirportInfo.project[2].info[7] = project3InfoContent06.Text;
            currentAirportInfo.project[2].info[8] = project3InfoContent07.Text;
            currentAirportInfo.project[2].info[9] = project3InfoContent08.Text;
            currentAirportInfo.project[2].info[10] = project3InfoContent09.Text;
            currentAirportInfo.project[2].info[11] = project3InfoContent10.Text;
            currentAirportInfo.project[2].info[12] = project3InfoContent11.Text;
            currentAirportInfo.project[2].info[13] = project3InfoContent12.Text;
            currentAirportInfo.project[2].info[14] = project3InfoContent13.Text;
            currentAirportInfo.project[2].info[15] = project3InfoContent14.Text;
            //sales
            currentAirportInfo.project[2].sale[0].info[0] = project3SalesContent00.Text;
            currentAirportInfo.project[2].sale[0].info[1] = project3SalesContent01.Text;
            currentAirportInfo.project[2].sale[0].info[2] = project3SalesContent02.Text;
            currentAirportInfo.project[2].sale[0].info[3] = project3SalesContent03.Text;
            currentAirportInfo.project[2].sale[1].info[0] = project3SalesContent10.Text;
            currentAirportInfo.project[2].sale[1].info[1] = project3SalesContent11.Text;
            currentAirportInfo.project[2].sale[1].info[2] = project3SalesContent12.Text;
            currentAirportInfo.project[2].sale[1].info[3] = project3SalesContent13.Text;
            currentAirportInfo.project[2].sale[2].info[0] = project3SalesContent20.Text;
            currentAirportInfo.project[2].sale[2].info[1] = project3SalesContent21.Text;
            currentAirportInfo.project[2].sale[2].info[2] = project3SalesContent22.Text;
            currentAirportInfo.project[2].sale[2].info[3] = project3SalesContent23.Text;
            currentAirportInfo.project[2].sale[3].info[0] = project3SalesContent30.Text;
            currentAirportInfo.project[2].sale[3].info[1] = project3SalesContent31.Text;
            currentAirportInfo.project[2].sale[3].info[2] = project3SalesContent32.Text;
            currentAirportInfo.project[2].sale[3].info[3] = project3SalesContent33.Text;
            currentAirportInfo.project[2].sale[4].info[0] = project3SalesContent40.Text;
            currentAirportInfo.project[2].sale[4].info[1] = project3SalesContent41.Text;
            currentAirportInfo.project[2].sale[4].info[2] = project3SalesContent42.Text;
            currentAirportInfo.project[2].sale[4].info[3] = project3SalesContent43.Text;
            currentAirportInfo.project[2].sale[5].info[0] = project3SalesContent50.Text;
            currentAirportInfo.project[2].sale[5].info[1] = project3SalesContent51.Text;
            currentAirportInfo.project[2].sale[5].info[2] = project3SalesContent52.Text;
            currentAirportInfo.project[2].sale[5].info[3] = project3SalesContent53.Text;
            currentAirportInfo.project[2].sale[6].info[0] = project3SalesContent60.Text;
            currentAirportInfo.project[2].sale[6].info[1] = project3SalesContent61.Text;
            currentAirportInfo.project[2].sale[6].info[2] = project3SalesContent62.Text;
            currentAirportInfo.project[2].sale[6].info[3] = project3SalesContent63.Text;
            currentAirportInfo.project[2].sale[7].info[0] = project3SalesContent70.Text;
            currentAirportInfo.project[2].sale[7].info[1] = project3SalesContent71.Text;
            currentAirportInfo.project[2].sale[7].info[2] = project3SalesContent72.Text;
            currentAirportInfo.project[2].sale[7].info[3] = project3SalesContent73.Text;
            currentAirportInfo.project[2].sale[8].info[0] = project3SalesContent80.Text;
            currentAirportInfo.project[2].sale[8].info[1] = project3SalesContent81.Text;
            currentAirportInfo.project[2].sale[8].info[2] = project3SalesContent82.Text;
            currentAirportInfo.project[2].sale[8].info[3] = project3SalesContent83.Text;
            currentAirportInfo.project[2].sale[9].info[0] = project3SalesContent90.Text;
            currentAirportInfo.project[2].sale[9].info[1] = project3SalesContent91.Text;
            currentAirportInfo.project[2].sale[9].info[2] = project3SalesContent92.Text;
            currentAirportInfo.project[2].sale[9].info[3] = project3SalesContent93.Text;
            //boolInfo
            currentAirportInfo.project[2].boolInfo[0] = (bool)project3CheckBox0.IsChecked;
            currentAirportInfo.project[2].boolInfo[1] = (bool)project3CheckBox1.IsChecked;
            currentAirportInfo.project[2].boolInfo[2] = (bool)project3CheckBox2.IsChecked;
            currentAirportInfo.project[2].boolInfo[3] = (bool)project3CheckBox3.IsChecked;
            currentAirportInfo.project[2].boolInfo[4] = (bool)project3CheckBox4.IsChecked;
            currentAirportInfo.project[2].boolInfo[5] = (bool)project3CheckBox5.IsChecked;
            currentAirportInfo.project[2].boolInfo[6] = (bool)project3CheckBox6.IsChecked;
            currentAirportInfo.project[2].boolInfo[7] = (bool)project3CheckBox7.IsChecked;
            currentAirportInfo.project[2].boolInfo[8] = (bool)project3CheckBox8.IsChecked;
            currentAirportInfo.project[2].boolInfo[9] = (bool)project3CheckBox9.IsChecked;
            currentAirportInfo.project[2].boolInfo[10] = (bool)project3CheckBox10.IsChecked;
            currentAirportInfo.project[2].boolInfo[11] = (bool)project3CheckBox11.IsChecked;
            currentAirportInfo.project[2].boolInfo[12] = (bool)project3CheckBox12.IsChecked;
            currentAirportInfo.project[2].boolInfo[13] = (bool)project3CheckBox13.IsChecked;
            currentAirportInfo.project[2].boolInfo[14] = (bool)project3CheckBox14.IsChecked;
            currentAirportInfo.project[2].boolInfo[15] = (bool)project3CheckBox15.IsChecked;
            currentAirportInfo.project[2].boolInfo[16] = (bool)project3CheckBox16.IsChecked;
            currentAirportInfo.project[2].boolInfo[17] = (bool)project3CheckBox17.IsChecked;
            currentAirportInfo.project[2].boolInfo[18] = (bool)project3CheckBox18.IsChecked;
            currentAirportInfo.project[2].boolInfo[19] = (bool)project3CheckBox19.IsChecked;
            currentAirportInfo.project[2].boolInfo[20] = (bool)project3CheckBox20.IsChecked;
            currentAirportInfo.project[2].boolInfo[21] = (bool)project3CheckBox21.IsChecked;
            currentAirportInfo.project[2].boolInfo[22] = (bool)project3CheckBox22.IsChecked;
            currentAirportInfo.project[2].boolInfo[23] = (bool)project3CheckBox23.IsChecked;
            currentAirportInfo.project[2].boolInfo[24] = (bool)project3CheckBox24.IsChecked;

            #endregion

            //chart
            #region
            currentAirportInfo.project[0].info[16] = chartAddress1.Text;
            currentAirportInfo.project[1].info[16] = chartAddress2.Text;
            currentAirportInfo.project[2].info[16] = chartAddress3.Text;
            #endregion

        }

        private void mainInfoWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isSaved)
            {
                SaveTipWindow saveTipwindow = new SaveTipWindow();
                if ((bool)saveTipwindow.ShowDialog())
                {
                    SaveCharttoAirportInfo();
                    SaveAirportInfoToFile(fileAddress);
                }
            }
        }

        private void addProjectButton_Click(object sender, RoutedEventArgs e)
        {
            //Project ++
            if (projectQtr < 3)
            {
                switch (projectQtr)
                {
                    case 0: projectInfoTab1.Visibility = Visibility.Visible;
                        projectInfoTab1.Focus();
                        break;
                    case 1: projectInfoTab2.Visibility = Visibility.Visible;
                        projectInfoTab2.Focus();
                        break;
                    case 2: projectInfoTab3.Visibility = Visibility.Visible;
                        projectInfoTab3.Focus();
                        break;
                    default:
                        break;
                }
                projectQtr++;
            }

            //button isenabled judgement
            if (projectQtr >= 3)
            { addProjectButton.IsEnabled = false; }
            else { addProjectButton.IsEnabled = true; }

            if (projectQtr <= 0)
            { deleteProjectButton.IsEnabled = false; }
            else { deleteProjectButton.IsEnabled = true; }
        }

        private void deleteProjectButton_Click(object sender, RoutedEventArgs e)
        {
            // project delete
            if (projectQtr >0)
            {
                switch (projectQtr)
                {
                    case 1: projectInfoTab1.Visibility = Visibility.Hidden;
                        equipmentInfoTab.Focus();
                        break;
                    case 2: projectInfoTab2.Visibility = Visibility.Hidden;
                        projectInfoTab1.Focus();
                        break;
                    case 3: projectInfoTab3.Visibility = Visibility.Hidden;
                        projectInfoTab2.Focus();
                        break;
                    default:
                        break;
                }
                projectQtr--;
            }

            //button isenabled judgement
            if (projectQtr >= 3)
            { addProjectButton.IsEnabled = false; }
            else { addProjectButton.IsEnabled = true; }

            if (projectQtr <= 0)
            { deleteProjectButton.IsEnabled = false; }
            else { deleteProjectButton.IsEnabled = true; }
        }

        private void chartLoadButton1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openJpgFileDialog = new Microsoft.Win32.OpenFileDialog();
            openJpgFileDialog.DefaultExt = "jpg";
            openJpgFileDialog.Filter = "JPG(.jpg)|*.jpg";
            //show dialog
            Nullable<bool> result = openJpgFileDialog.ShowDialog();

            if (result == true && openJpgFileDialog.FileName != "")
            {
                //read a new chart
                chartImage1.Source = new BitmapImage(new Uri(openJpgFileDialog.FileName, UriKind.RelativeOrAbsolute));
                chartAddress1.Text = openJpgFileDialog.FileName;
            }
        }
        private void chartLoadButton2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openJpgFileDialog = new Microsoft.Win32.OpenFileDialog();
            openJpgFileDialog.DefaultExt = "jpg";
            openJpgFileDialog.Filter = "JPG(.jpg)|*.jpg";
            //show dialog
            Nullable<bool> result = openJpgFileDialog.ShowDialog();

            if (result == true && openJpgFileDialog.FileName != "")
            {
                //read a new chart
                chartImage2.Source = new BitmapImage(new Uri(openJpgFileDialog.FileName, UriKind.RelativeOrAbsolute));
                chartAddress2.Text = openJpgFileDialog.FileName;
            }
        }
        private void chartLoadButton3_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openJpgFileDialog = new Microsoft.Win32.OpenFileDialog();
            openJpgFileDialog.DefaultExt = "jpg";
            openJpgFileDialog.Filter = "JPG(.jpg)|*.jpg";
            //show dialog
            Nullable<bool> result = openJpgFileDialog.ShowDialog();

            if (result == true && openJpgFileDialog.FileName != "")
            {
                //read a new chart
                chartImage3.Source = new BitmapImage(new Uri(openJpgFileDialog.FileName, UriKind.RelativeOrAbsolute));
                chartAddress3.Text = openJpgFileDialog.FileName;
            }
        }
    }
}
