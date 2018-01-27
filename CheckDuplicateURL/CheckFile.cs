using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CheckDuplicateURL
{
    class CheckFile
    {
        private string line;
        private List<string> linesBeg;
        private List<string> linesEnd;

        public CheckFile()
        { 
            linesBeg = new List<string>();
            linesEnd = new List<string>();
        }

        private void readFile(string fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);

                line = sr.ReadLine();
                linesBeg.Add(line);

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                    linesBeg.Add(line);
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("File was read");
            }
        }

        private void writeFile(string fileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName);

                foreach (string item in linesEnd)
                {
                    sw.WriteLine(item);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("File was written");
            }
        }
        

        public void executeCheck(string fileName)
        {
            readFile(fileName);
            if (linesBeg.Count > 0)
            {
                string newFileName = createFileName(fileName);
                
                string temp = string.Empty;
                string check = string.Empty;
                foreach (string item in linesBeg)
                {
                    check = string.Empty;
                    string t = item;
                    if (!temp.Equals(item) && !string.IsNullOrEmpty(t))
                    {
                        t = t.Trim();
                        if (t.IndexOf("<DT><A HREF=") == 0)
                            check = linesEnd.FirstOrDefault(i => i == item);

                        if (string.IsNullOrEmpty(check))
                            this.linesEnd.Add(item);
                    }
                    temp = item;
                }
                writeFile(newFileName);
            }
        }


        private string createFileName(string fileName)
        {
            string getFileName = Path.GetFileName(fileName);
            string getExtension = Path.GetExtension(fileName);
            string addDate = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string newFileName = string.Format("{0}{1}",
                fileName.Replace(getFileName, ""),
                getFileName.Replace(getExtension, string.Format("_{0}{1}", addDate, getExtension)));
            return newFileName;
        }

    }
}
