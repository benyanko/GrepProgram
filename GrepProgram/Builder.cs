using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrepProgram
{
    public class Builder
    {
        private string m_FilePath;
        private TextSearcher m_TextSearcher;

        public TextSearcher TextSearcher
        {
            get
            {
                return this.m_TextSearcher;
            }
        }

        public Builder (string i_Path, string i_Pattern)
        {
            GetFilePath(i_Path);
            m_TextSearcher = new TextSearcher(m_FilePath, i_Pattern);


        }

        private void GetFilePath(string i_Path)
        {
            try
            {
                if (Uri.IsWellFormedUriString(i_Path, UriKind.RelativeOrAbsolute))
                {
                    UrlToFile urlToFile = new UrlToFile(i_Path);
                    m_FilePath = urlToFile.FilePath;
                }
                else
                {
                    m_FilePath = i_Path;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Get file path error");
                return;
            }
            
        }
    }
}
