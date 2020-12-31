using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GrepProgram
{
    public class UrlToFile
    {
        private readonly string r_FilePath = @"C:\Users\נעמה\source\repos\GrepProgram\TextFileFromUrl.txt";
        private string m_TextToFile;

        public string FilePath
        {
            get
            {
                return this.r_FilePath;
            }
        }

        public UrlToFile(string i_url)
        {
            try
            {
                m_TextToFile = string.Empty;
                ReadUrlToString(i_url);
                File.WriteAllText(r_FilePath, m_TextToFile);
            }
            catch (Exception)
            {
                Console.WriteLine("Write html text to file error");
                return;
            }
        }

        private void ReadUrlToString(string i_url)
        {
            try
            {
                WebClient Client = new WebClient();
                m_TextToFile = Client.DownloadString(i_url);
                HtmlToPlainText();
            }
            catch (IOException)
            {
                Console.WriteLine("Download text from url error");
                return;
            }
        }

        private void HtmlToPlainText()
        {
            try
            {
                
                m_TextToFile = m_TextToFile.Replace("\r", " ");
                
                m_TextToFile = m_TextToFile.Replace("\n", " ");
                m_TextToFile = m_TextToFile.Replace("\t", string.Empty);
                m_TextToFile = Regex.Replace(m_TextToFile, @"( )+", " ");

                m_TextToFile = Regex.Replace(m_TextToFile, @"<( )*head([^>])*>", "<head>", RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile, @"(<( )*(/)( )*head( )*>)", "</head>", RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile, "(<head>).*(</head>)", string.Empty, RegexOptions.IgnoreCase);

                m_TextToFile = Regex.Replace(m_TextToFile, @"<( )*script([^>])*>", "<script>", RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile, @"(<( )*(/)( )*script( )*>)", "</script>", RegexOptions.IgnoreCase);
                
                m_TextToFile = Regex.Replace(m_TextToFile, @"(<script>).*(</script>)", string.Empty, RegexOptions.IgnoreCase);

                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"<( )*style([^>])*>", "<style>",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         "(<style>).*(</style>)", string.Empty,
                         RegexOptions.IgnoreCase);

                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"<( )*td([^>])*>", "\t",
                         RegexOptions.IgnoreCase);

                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"<( )*br( )*>", "\r",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"<( )*li( )*>", "\r",
                         RegexOptions.IgnoreCase);

                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"<( )*div([^>])*>", "\r\r",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"<( )*tr([^>])*>", "\r\r",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"<( )*p([^>])*>", "\r\r",
                         RegexOptions.IgnoreCase);

                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"<[^>]*>", string.Empty,
                         RegexOptions.IgnoreCase);

                m_TextToFile = Regex.Replace(m_TextToFile,
                         @" ", " ",
                         RegexOptions.IgnoreCase);

                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&bull;", " * ",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&lsaquo;", "<",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&rsaquo;", ">",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&trade;", "(tm)",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&frasl;", "/",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&lt;", "<",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&gt;", ">",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&copy;", "(c)",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&reg;", "(r)",
                         RegexOptions.IgnoreCase);
                
                m_TextToFile = Regex.Replace(m_TextToFile,
                         @"&(.{2,6});", string.Empty,
                         RegexOptions.IgnoreCase);

                
                m_TextToFile = m_TextToFile.Replace("\n", "\r");

                
                m_TextToFile = Regex.Replace(m_TextToFile,
                         "(\r)( )+(\r)", "\r\r",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         "(\t)( )+(\t)", "\t\t",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         "(\t)( )+(\r)", "\t\r",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         "(\r)( )+(\t)", "\r\t",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         "(\r)(\t)+(\r)", "\r\r",
                         RegexOptions.IgnoreCase);
                m_TextToFile = Regex.Replace(m_TextToFile,
                         "(\r)(\t)+", "\r\t",
                         RegexOptions.IgnoreCase);
                string breaks = "\r\r\r";
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < m_TextToFile.Length; index++)
                {
                    m_TextToFile = m_TextToFile.Replace(breaks, "\r\r");
                    m_TextToFile = m_TextToFile.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Html to plain text error");
                return;
            }
        }
    }
}     

