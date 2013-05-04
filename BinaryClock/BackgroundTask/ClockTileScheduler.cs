using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using TimeDefination;

namespace BackgroundTask
{
    public static class ClockTileScheduler
    {
        public static void CreateSchedule()
        {
            StaticBinaryTime bTime = new StaticBinaryTime(DateTime.Now);

            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            var plannedUpdated = tileUpdater.GetScheduledTileNotifications();

            DateTime now = DateTime.Now;
            //更新时间上限
            //DateTime planTill = now.AddHours(4);
            DateTime planTill = now.AddMinutes(20);

            //第一次计划更新从下一分钟整点开始
            DateTime updateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0).AddMinutes(1);
            if (plannedUpdated.Count > 0)
            {
                updateTime = plannedUpdated.Select(x => x.DeliveryTime.DateTime).Union(new[] { updateTime }).Max();
            }

            //TILE样式选择
            const string xml = @"<tile><visual>
                                        <binding template=""TileSquareText01""><text id=""1"">{1}</text><text id=""2"">{2}</text><text id=""3""></text><text id=""4"">{3}</text></binding>
                                        <binding template=""TileWideText01""><text id=""1"">{4}</text><text id=""2"">{5}</text><text id=""3""></text><text id=""4"">{3}</text><text id=""5""></text></binding>
                                   </visual></tile>";

            //初次更新内容
            var tileXmlNow = string.Format(xml,
                bTime.Day, //DAY
                bTime.HourHigh + " " + bTime.HourLow, //小时
                bTime.MinuteHigh + " " + bTime.MinuteLow, //分钟
                "Binary Clock", //名称
                bTime.HourHigh + " " + bTime.HourLow + " : " + bTime.MinuteHigh + " " + bTime.MinuteLow, //小时：分钟
                bTime.Day + " / " + bTime.Month);//DAY/MONTH
            //生成XML文件
            XmlDocument documentNow = new XmlDocument();
            documentNow.LoadXml(tileXmlNow);

            //初次更新，1分钟后失效
            tileUpdater.Update(new TileNotification(documentNow) { ExpirationTime = now.AddMinutes(1) });

            //计划更新，间隔为1分钟
            for (var startPlanning = updateTime; startPlanning < planTill; startPlanning = startPlanning.AddMinutes(1))
            {
                try
                {
                    //计划开始时间
                    bTime.Set(startPlanning);
                    //计划更新内容
                    var tileXml = string.Format(xml, bTime.Day, bTime.HourHigh + " " + bTime.HourLow, bTime.MinuteHigh + " " + bTime.MinuteLow, "Binary Clock", bTime.HourHigh + " " + bTime.HourLow + " : " + bTime.MinuteHigh + " " + bTime.MinuteLow, bTime.Day + "/" + bTime.Month);
                    //生成XML文件
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(tileXml);

                    //计划更新失效时间1分钟
                    ScheduledTileNotification scheduledNotification = new ScheduledTileNotification(document, new DateTimeOffset(startPlanning)) { ExpirationTime = startPlanning.AddMinutes(1) };
                    //加入计划更新列表
                    tileUpdater.AddToSchedule(scheduledNotification);
                }
                catch (Exception)
                {
                    //do nothing
                }
            }
        }
    }
}
