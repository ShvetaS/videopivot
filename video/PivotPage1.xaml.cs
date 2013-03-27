using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.IO;

namespace video
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        public PivotPage1()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;
          //  webBrowser1.Navigate += webBrowser1_OnLoaded;
        //   webBrowser1.Loaded += WebBrowser_OnLoaded;
        // webBrowser2.Loaded += WebBrowser_OnLoaded;
            webBrowser1.Loaded += webBrowser1_Loaded;
            webBrowser2.Loaded += webBrowser2_Loaded;
        }

  /*    private void WebBrowser_OnLoaded(object sender, RoutedEventArgs e)
        {
              SaveFilesToIsoStore();
             webBrowser2.Navigate(new Uri("readme.htm", UriKind.Relative));
            
        }
    */    
     private void webBrowser1_Loaded(object sender, RoutedEventArgs e)
      {
          webBrowser1.Navigate(new Uri("http://www.youtube.com/watch?feature=player_embedded&v=2MfkRfuYePU#!", UriKind.Absolute));
      }
     private void webBrowser2_Loaded(object sender, RoutedEventArgs e)
     {
         SaveFilesToIsoStore();
           webBrowser2.Navigate(new Uri("readme.htm", UriKind.Relative));
     }
    
//good part
  
   /*     private void WebBrowser_OnLoaded(object sender, RoutedEventArgs e)
        {
            SaveFilesToIsoStore();
            webBrowser2.Navigate(new Uri("readme.htm", UriKind.Relative));
        }
     */   
        //HELP DOCUMENT PART
           private void SaveFilesToIsoStore()
             {
                 //These files must match what is included in the application package,
                 //or BinaryStream.Dispose below will throw an exception.
                 string[] files = {
                 "readme.htm"   };
                 IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();

                 if (false == isoStore.FileExists(files[0]))
                 {
                     foreach (string f in files)
                     {
                         StreamResourceInfo sr = Application.GetResourceStream(new Uri("readme.htm", UriKind.Relative));
                         using (BinaryReader br = new BinaryReader(sr.Stream))
                         {
                             byte[] data = br.ReadBytes((int)sr.Stream.Length);
                             SaveToIsoStore(f, data);
                         }
                     }
                 }
             }

           private void SaveToIsoStore(string fileName, byte[] data)
           {
               string strBaseDir = string.Empty;
               string delimStr = "/";
               char[] delimiter = delimStr.ToCharArray();
               string[] dirsPath = fileName.Split(delimiter);

               //Get the IsoStore.
               IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();

               //Re-create the directory structure.
               for (int i = 0; i < dirsPath.Length - 1; i++)
               {
                   strBaseDir = System.IO.Path.Combine(strBaseDir, dirsPath[i]);
                   isoStore.CreateDirectory(strBaseDir);
               }

               //Remove the existing file.
               if (isoStore.FileExists(fileName))
               {
                   isoStore.DeleteFile(fileName);
               }

               //Write the file.
               using (BinaryWriter bw = new BinaryWriter(isoStore.CreateFile(fileName)))
               {
                   bw.Write(data);
                   bw.Close();
               }
           }

         
    }
}