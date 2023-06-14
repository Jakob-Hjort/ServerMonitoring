using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;
using Moderndesign.DVIservice1;

namespace Moderndesign.MVVM.View
{
  
    public partial class HomeView : UserControl
    {
        private readonly DVIservice1.monitorSoapClient ds = new DVIservice1.monitorSoapClient();
        private DispatcherTimer timer;
        private DispatcherTimer newsRotationTimer;
        private List<SyndicationItem> newsItems = new List<SyndicationItem>();
        private int currentIndex = -1;

        public HomeView()
        {
            InitializeComponent();
            LoadData();
            FetchNews();

            // Initialiser og starter timeren for tid og dato
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); //Opdatere hvert sekund
            timer.Tick += Timer_Tick;
            timer.Start();

            // Initialiser and starter timeren for rotation af nyheder.
            newsRotationTimer = new DispatcherTimer();
            newsRotationTimer.Interval = TimeSpan.FromSeconds(5); // Her kan man justere hvor hurtigt nyderne skal skifte.
            newsRotationTimer.Tick += NewsRotationTimer_Tick;
            newsRotationTimer.Start();


            // Starter timeren til at opdatere temperature and luftfugtihhed hver 2 minut
            DispatcherTimer temperatureHumidityTimer = new DispatcherTimer();
            temperatureHumidityTimer.Interval = TimeSpan.FromMinutes(2);
            temperatureHumidityTimer.Tick += TemperatureHumidityTimer_Tick;
            temperatureHumidityTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Kalder medtoden for at opdatere datoen, tiden og ugendagen for de tre byer.
            UpdateDateTimeForCities();

        }

        private void NewsRotationTimer_Tick(object sender, EventArgs e)
        {
            // Kalder medtoden for at rotere nyderne.
            RotateNews();
        }

        private void UpdateDateTimeForCities()
        {
            // Hender tiden og datoen for de tre byer
            DateTime currentDateTimeCopenhagen = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
            DateTime currentDateTimeNewYork = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            DateTime currentDateTimeSingapore = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time"));

            // Formatere dato og tid til strings
            string dayOfWeekCopenhagen = currentDateTimeCopenhagen.ToString("dddd");
            string timeCopenhagen = currentDateTimeCopenhagen.ToString("HH:mm:ss");
            string dateCopenhagen = currentDateTimeCopenhagen.ToString("yyyy-MM-dd");

            string dayOfWeekNewYork = currentDateTimeNewYork.ToString("dddd");
            string timeNewYork = currentDateTimeNewYork.ToString("HH:mm:ss");
            string dateNewYork = currentDateTimeNewYork.ToString("yyyy-MM-dd");

            string dayOfWeekSingapore = currentDateTimeSingapore.ToString("dddd");
            string timeSingapore = currentDateTimeSingapore.ToString("HH:mm:ss");
            string dateSingapore = currentDateTimeSingapore.ToString("yyyy-MM-dd");


            // opdatere UI elementerne for dato, tid og ugendagen for de tre byer.
            CopenhagenDayTextBlock.Text = dayOfWeekCopenhagen;
            CopenhagenTimeTextBlock.Text = timeCopenhagen;
            CopenhagenDateTextBlock.Text = dateCopenhagen;

            NewYorkDayTextBlock.Text = dayOfWeekNewYork;
            NewYorkTimeTextBlock.Text = timeNewYork;
            NewYorkDateTextBlock.Text = dateNewYork;

            SingaporeDayTextBlock.Text = dayOfWeekSingapore;
            SingaporeTimeTextBlock.Text = timeSingapore;
            SingaporeDateTextBlock.Text = dateSingapore;
        }

        private void FetchNews()
        {
            // Henter nyderhederne ved hjælp af XmLReader og sender 
                XmlReaderSettings settings = new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Parse
                };

                using (XmlReader reader = XmlReader.Create("https://nordjyske.dk/rss/nyheder", settings))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    newsItems = feed.Items.ToList();
                    RotateNews();
                }
  
        }
        // For at få nyderne til at rotere
        private void RotateNews()
        {
            currentIndex++;
            if (currentIndex >= newsItems.Count)
                currentIndex = 0;

            SyndicationItem currentItem = newsItems[currentIndex];
            NewsHeadlineTextBlock.Text = currentItem.Title.Text;
        }

        //En eventhandler der opdatere der LoadData
        private void TemperatureHumidityTimer_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        // Her bliver temperatur og luftfugtighed omdannets til doubles og sendt til tekstboksen på xaml siden.
        private void LoadData()
        {
            double value1 = ds.OutdoorHumidity();
            double value2 = ds.OutdoorTemp();
            double value3 = ds.StockHumidity();
            double value4 = ds.StockTemp();


            value1TextBlock.Text = value1.ToString() + " %";
            value2TextBlock.Text = value2.ToString() + " °C";
            value3TextBlock.Text = value3.ToString() + " %";
            value4TextBlock.Text = value4.ToString() + " °C";
        }
    }


}
