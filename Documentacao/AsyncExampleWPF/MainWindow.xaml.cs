﻿using System.Collections.Generic;
using System.Windows;
using System.Net.Http;
using System.Net;
using System.IO;

namespace AsyncExampleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Clear();
            SumPageSizes();
            this.textBox.Text += "\r\nControl returned to startButton_Click.";
        }

        private void SumPageSizes()
        {
            // Make a list of web addresses.  
            List<string> urlList = SetUpURLList();

            var total = 0;
            foreach (var url in urlList)
            {
                // GetURLContents returns the contents of url as a byte array.  
                byte[] urlContents = GetURLContents(url);

                DisplayResults(url, urlContents);

                // Update the total.  
                total += urlContents.Length;
            }

            // Display the total count for all of the web addresses.  
            this.textBox.Text +=
                string.Format("\r\n\r\nTotal bytes returned:  {0}\r\n", total);
        }

        private List<string> SetUpURLList()
        {
            var urls = new List<string>
    {
        "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
        "http://msdn.microsoft.com",
        "http://msdn.microsoft.com/library/hh290136.aspx",
        "http://msdn.microsoft.com/library/ee256749.aspx",
        "http://msdn.microsoft.com/library/hh290138.aspx",
        "http://msdn.microsoft.com/library/hh290140.aspx",
        "http://msdn.microsoft.com/library/dd470362.aspx",
        "http://msdn.microsoft.com/library/aa578028.aspx",
        "http://msdn.microsoft.com/library/ms404677.aspx",
        "http://msdn.microsoft.com/library/ff730837.aspx"
    };
            return urls;
        }

        private byte[] GetURLContents(string url)
        {
            // The downloaded resource ends up in the variable named content.  
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.  
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            
            
            // Send the request to the Internet resource and wait for  
            // the response.  
            // Note: you can't use HttpWebRequest.GetResponse in a Windows Store app.  
            using (WebResponse response = webReq.GetResponse())
            {
                // Get the data stream that is associated with the specified URL.  
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Read the bytes in responseStream and copy them to content.    
                    responseStream.CopyTo(content);
                }
            }

            // Return the result as a byte array.  
            return content.ToArray();
        }

        private void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format   
            // is designed to be used with a monospaced font, such as  
            // Lucida Console or Global Monospace.  
            var bytes = content.Length;
            // Strip off the "http://".  
            //var displayURL = url.Replace("http://", "");
            this.textBox.Text += string.Format("\n{0,-58} {1,8}", url, bytes);
        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
