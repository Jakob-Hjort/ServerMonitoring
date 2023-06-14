using Moderndesign.DVIservice;
using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Moderndesign.MVVM.View
{
    public partial class LoadView : UserControl
    {
        private readonly monitorSoapClient ds = new monitorSoapClient();
        private Timer timer;

        public LoadView()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            // Create a timer with a 5-minute interval
            timer = new Timer(5 * 60 * 1000); // 5 minutes in milliseconds
            timer.Elapsed += TimerElapsed;
            timer.Start();

            // Trigger the updates immediately when the view is loaded
            UpdateData();
        }

        private async void UpdateData()
        {
            await UpdateStockMostSold();
            await UpdateMinimumStock();
            await UpdateMaximumStock();
        }

        private async Task UpdateStockMostSold()
        {
                ArrayOfString fetchedText = await Task.Run(() => ds.StockItemsMostSold());
                string[] textArray = fetchedText.ToArray();
                string text = string.Join(Environment.NewLine, textArray);
                UpdateMestsolgteText(text);
           
        }

        private async Task UpdateMinimumStock()
        {
       
                ArrayOfString fetchedText = await Task.Run(() => ds.StockItemsUnderMin());
                string[] textArray = fetchedText.ToArray();
                string text = string.Join(Environment.NewLine, textArray);
                UpdateMinimumLagerText(text);
        }

        private async Task UpdateMaximumStock()
        {

                ArrayOfString fetchedText = await Task.Run(() => ds.StockItemsOverMax());
                string[] textArray = fetchedText.ToArray();
                string text = string.Join(Environment.NewLine, textArray);
                UpdateMaximumLagerText(text);
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Update the data when the timer elapses
            UpdateData();
        }

        private void UpdateMestsolgteText(string text)
        {
            Dispatcher.Invoke(() =>
            {
                Mestsolgte.Text = text;
            });
        }

        private void UpdateMinimumLagerText(string text)
        {
            Dispatcher.Invoke(() =>
            {
                MinimumLager.Text = text;
            });
        }

        private void UpdateMaximumLagerText(string text)
        {
            Dispatcher.Invoke(() =>
            {
                MaximumLager.Text = text;
            });
        }
    }
}