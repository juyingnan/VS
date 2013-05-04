using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADB_Airport_Info
{
    class AirportInfo
    {
        public AirportInfo()
        {
            for (int i = 0; i < basicInfo.Length; i++)
            {
                basicInfo[i] = "";
            }
            for (int i = 0; i < runway.Length; i++)
            {
                runway[i] = new Runway();
            }
            for (int i = 0; i < staff.Length; i++)
            {
                staff[i] = new Staff();
            }
            for (int i = 0; i < cooperation.Length; i++)
            {
                cooperation[i] = new Cooperation();
            }
            for (int i = 0; i < naviEquipment.Length; i++)
            {
                naviEquipment[i] = new NaviEquipment();
            }
            for (int i = 0; i < project.Length; i++)
            {
                project[i] = new Project();
            }
        }

        public string[] basicInfo = new string[100];
        /* basicInfo[0]=airportName_EN
         * basicInfo[1]=airportName_CH
         * basicInfo[2]=airportName_ICAO
         * basicInfo[3]=airportName_IATA
         * basicInfo[4]=airportAuthorizeName_EN
         * basicInfo[5]=airportAuthorizeName_CH
         * basicInfo[6]=runwayQtr
         * basicInfo[7]=airportUsage_EN
         * basicInfo[8]=airportUsage_CH
         * basicInfo[9]=city_EN
         * basicInfo[10]=city_CH
         * basicInfo[11]=geographyLoc_lati
         * basicInfo[12]=geographyLoc_long
         * basicInfo[13]=province_EN
         * basicInfo[14]=province_CH
         * basicInfo[15]=altitude_EN
         * basicInfo[16]=altitude_CH
         * basicInfo[17]=annualSunshine_EN
         * basicInfo[18]=annualSunshine_CH
         * basicInfo[19]=salesRegion_EN
         * basicInfo[20]=salesRegion_CH
         * basicInfo[21]=takeOffLanding
         * basicInfo[22]=subStationQtr
         * basicInfo[23]=maintenanceQtr
         * basicInfo[24]=controlTowerQtr
         * basicInfo[25]=
         * basicInfo[26]=
         * basicInfo[27]=
         * basicInfo[28]=
         * basicInfo[29]=
         * basicInfo[30]=
         */
        public Runway[] runway = new Runway[5];
        public Staff[] staff = new Staff[12];
        public Cooperation[] cooperation = new Cooperation[20];
        public NaviEquipment [] naviEquipment = new NaviEquipment[39];
        public Project[] project = new Project[3];
    }

    public class Runway 
    {
        public Runway()
        {
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = "";
            }
        }
        public string[] info = new string[20];
        /*info[0]=direction_R
        *info[1]=direction_L
        *info[2]=CAT
        *info[3]=flyZoneIndicator
        *info[4]=dimension_L
        *info[5]=dimension_W
        *info[6]=PCN
        *info[7]=largestAircraft
        *info[8]=surfaceType
        *info[9]=ActuallCAT
        *info[10]=name
        *info[11]=
        *info[12]=
        *info[13]=
        *info[14]=
        *info[15]=
        *info[16]=
        *info[17]=
        *info[18]=
        *info[19]= 
         */
    }

    public class Staff
    {
        public Staff()
        {
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = "";
            }
        }
        public string[] info = new string[10];
        /**
        *info[0]=name
        *info[1]=contact
        *info[2]=mobile
        *info[3]=description
        *info[4]=remarks
        *info[5]=
         */
    }

    public class Cooperation
    {
        public Cooperation()
        {
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = "";
            }
        }
        public string[] info = new string[10];
        /*  *info[0]=name
            *info[1]=time
            *info[2]=Budget
            *info[3]=productsInfo
            *info[4]=SAP
            *info[7]=
            *info[8]=
            *info[9]=
         */
    }

    public class NaviEquipment
    {
        public NaviEquipment()
        {
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = "";
            }
        }
        public string[] info = new string[20];
        /*info[0]=runwayNo1
        *info[1]=qtr1
        *info[2]=factory1
        *info[3]=runwayNo2
        *info[4]=qtr2
        *info[5]=factory2
        *info[6]=runwayNo3
        *info[7]=qtr3
        *info[8]=factory3
        *info[9]=runwayNo4
        *info[10]=qtr4
        *info[11]=factory4
        *info[12]=remarks
        *info[13]=
        *info[14]=
        *info[15]= 
         */
    }

    public class Project
    {
        public Project()
        {
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = "";
            }
            for (int i = 0; i < sale.Length; i++)
            {
                sale[i] = new Sales();
            }
            for (int i = 0; i < boolInfo.Length; i++)
            {
                boolInfo[i] = false;
            }
        }
        public string[] info = new string[20];
        /*
         * info[0] = isExist;
         * info[1] = Project Information
         * info[2] =Design Institute Information 
         * info[3] =Contractor Information  
         * info[4] =Airport Contact Information 
         * info[5] =Contact Information 
         * info[6] =Contact Information 
         * info[7] =招标 Bidding
         * info[8] =设备安装 Installation
         * info[9] =项目验收 FAT
         * info[10] =合同签订 Contract
         * info[11] =交货 Delivery
         * info[12] =民航行业验收 CAAC FAT
         * info[13] =Sales Strategy 销售策略
         * info[14] =Competition status   潜在竞争对手动态
         * info[15] =Purchaser Info. 采购方联系方式
         * info[16] = 流程图地址
         */
    public Sales[] sale= new Sales[10];

    public bool[] boolInfo = new bool[30];
    }

    public class Sales
    {
        public Sales()
        {
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = "";
            }
        }

        public string[] info = new string[4];
        // info[0]= date
        //info[1]=contact
        //info[2]=description
        //info[3]=responsible
    }
}
