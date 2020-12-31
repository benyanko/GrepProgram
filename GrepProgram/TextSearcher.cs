using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GrepProgram
{
    public class TextSearcher
    {
        private string m_PathFile;
        private string m_Pattern;
        private StringBuilder m_Result;

        public StringBuilder Result
        {
            get
            {
                return this.m_Result;
            }
        }

        public TextSearcher(string i_PathFile, string i_WordToFind)
        {
            m_PathFile = i_PathFile;
            m_Pattern = i_WordToFind;
            m_Result = new StringBuilder();
            Sercher(m_PathFile, m_Pattern);

        }

        private void Sercher(string i_PathFile, string i_WordToFind)
        {
            try
            {
                StreamReader reader = new StreamReader(i_PathFile);
                string Line;
                int LineCounter = 0;

                while ((Line = reader.ReadLine()) != null)
                {
                    if (Line.Contains(m_Pattern))
                    {
                        m_Result.Append(string.Format("The pattern {0} is find in line number {1}", i_WordToFind, LineCounter));
                        m_Result.AppendLine();
                        m_Result.Append(Line);
                        m_Result.AppendLine();
                        m_Result.AppendLine();
                        LineCounter++;
                    }
                }

                if (LineCounter > 0)
                {
                    m_Result.AppendLine(string.Format("{0} Line Matched", LineCounter));
                }
                else
                {
                    m_Result.AppendLine("No Match");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Reading from file error");
                return;
            }
        }
    }
}
