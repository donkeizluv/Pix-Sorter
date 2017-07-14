using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Pix_Sorter
{
    public partial class Form1 : Form
    {
        private const string InvalidImgPath = "Img path is invalid";
        private const string InvalidOutputPath = "Output path is invalid";
        private const string InvalidExcelPath = "Excel path is invalid";
        private const string FolderNotExists = "Folder is not exists!";
        private Regex HrCodeRegex = new Regex("E([A-Z]{1})?[0-9]+");
        //private Regex HrCodeRegex = new Regex("E([A-Z]{1})?[0-9]");
        private Logger _logger = new Logger();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDoit_Click(object sender, EventArgs e)
        {
            buttonDoit.Enabled = false;
            try
            {
                if (!CheckPaths(out var checkMess))
                {
                    MessageBox.Show(checkMess);
                    return;
                }
                try
                {
                    SortPix();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                }
            }
            finally
            {
                buttonDoit.Enabled = true;
            }
        }

        private void UpdateProgressLabel(int remain, int total)
        {
            labelProgress.Text = string.Format("{0}/{1}", remain, total);
        }

        private void SortPix()
        {
            var imgPath = textBoxImgPath.Text;
            var outputPath = textBoxOutputPath.Text;
            var excelPath = textBoxExcelPath.Text;

            var excelInfo = new FileInfo(excelPath);
            if (!excelInfo.Exists)
            {
                //throw new FileNotFoundException("excel file not found.");
                return;
            }

            var dict = GetExcelDict(excelInfo, 7, 2, 9); //1 based
            if (dict.Count < 1)
            {
                //throw new InvalidDataException("excel dict contain nothing");
                return;
            }

            var files = ScanFiles(imgPath, out var scanfileMess, "*.jpg", "*.png", "*.bmp", "*.jpe", "*.jpeg", "*.doc", "*.docx").ToList();
            if(files == null)
            {
                MessageBox.Show(scanfileMess);
                return;
            }
            for (int i = 0; i < files.Count(); i++)
            {
                var file = files[i];
                UpdateProgressLabel(i + 1, files.Count());
                var fileName = file.Split('\\').Last();
                var hrCodeMatch = HrCodeRegex.Match(fileName.ToUpperInvariant());
                if(!hrCodeMatch.Success)
                {
                    //log cant find HR code
                    _logger.AddLog("", $"{fileName} -> Cant find HR CODE.");
                    continue;
                }
                var hrCode = hrCodeMatch.Value;
                if(dict.ContainsKey(hrCode))
                {
                    var folderName = dict[hrCode];
                    try
                    {
                        var folder = string.Format("{0}\\{1}", outputPath, folderName);
                        var desFilename = string.Format("{0}\\{1}", folder, fileName);
                        if (File.Exists(desFilename)) continue; //skip already exists file
                        Directory.CreateDirectory(folder);
                        File.Copy(file, desFilename, false);
                    }
                    catch (Exception ex)
                    {
                        _logger.AddLog(hrCode, ex.Message);
                        //log
                    }
                    
                }
                else
                {
                    //log not found
                    _logger.AddLog(hrCode, "Not found in excel.");
                }
            }
        }
        private Dictionary<string,string> GetExcelDict(FileInfo file, int startRow, int hrCol, int supCol)
        {
            var dict = new Dictionary<string, string>();
            //var fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
            try
            {
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    var workSheet = package.Workbook.Worksheets.First();
                    //var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;
                    for (int row = startRow; row <= end.Row; row++)
                    {
                        var hr = workSheet.Cells[row, hrCol].Text.Trim();
                        var sup = workSheet.Cells[row, supCol].Text.Trim();
                        if (string.IsNullOrEmpty(hr) || string.IsNullOrEmpty(sup))
                        {
                            //Console.WriteLine($"Row: {row - 1} is empty -> skip");
                            //log
                            //skip
                            continue;
                        }
                        if (dict.ContainsKey(hr))
                        {
                            //duplicate
                            //log
                            //skip
                        }
                        else
                        {
                            dict.Add(hr, sup);
                        }
                    }
                    //package.Save();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Excel file is aleady opened!");
                //throw;
            }
            
            return dict;
        }
        private IEnumerable<string> ScanFiles(string folderPath, out string mess, params string[] filters)
        {
            mess = string.Empty;
            List<string> files = new List<string>();
            try
            {
                foreach (var filter in filters)
                {
                    files.AddRange(Directory.GetFiles(folderPath, filter));
                }
                if (files.Count < 1)
                {
                    mess = "No imgs found.";
                    return null;
                }
            }
            catch (DirectoryNotFoundException)
            {
                mess = "Cannot find " + folderPath;
                return null;
            }
            catch (IOException ex)
            {
                mess = ex.Message;
                return null;
            }
            catch (UnauthorizedAccessException ex)
            {
                mess = "Access to the folder is unauthorized!";
                return null;
            }
            catch (Exception ex) //no
            {
                mess = "Unhandled exception on accessing scanned folder";
                throw;
            }
            return files.Distinct();
        }

        private bool CheckPaths(out string message)
        {
            message = string.Empty;
            var imgPath = textBoxImgPath.Text;
            var outputPath = textBoxOutputPath.Text;
            var excelPath = textBoxExcelPath.Text;
            if (imgPath.Length < 1)
            {
                message = InvalidImgPath;
                return false;
            }
            if (outputPath.Length < 1)
            {
                message = InvalidOutputPath;
                return false;
            }
            if (excelPath.Length < 1)
            {
                message = InvalidExcelPath;
                return false;
            }
            if(!File.Exists(excelPath))
            {
                message = InvalidExcelPath;
                return false;
            }
            if (!Directory.Exists(imgPath) || !Directory.Exists(outputPath))
            {
                message = FolderNotExists;
                return false;
            }
            return true;
        }

        private string BrowsePath(bool folder = false)
        {
            if(folder)
            {
                var folderBrowser = new FolderBrowserDialog();
                if(folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    return folderBrowser.SelectedPath;
                }
                else
                {
                    return string.Empty;
                }
            }
            var fileBrowser = new OpenFileDialog()
            {
                DefaultExt = "*.xlsx",
                Multiselect = false,
            };
            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                return fileBrowser.FileName;

            }
            else
            {
                return string.Empty;
            }
        }

        private void buttonBrowseImg_Click(object sender, EventArgs e)
        {
            textBoxImgPath.Text = BrowsePath(true);

        }

        private void buttonBrowseOutput_Click(object sender, EventArgs e)
        {
            textBoxOutputPath.Text = BrowsePath(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxExcelPath.Text = BrowsePath(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _logger.Show();
            //textBoxImgPath.Text = @"C:\Users\donke\Desktop\pix_sorter\img";
            //textBoxOutputPath.Text = @"C:\Users\donke\Desktop\pix_sorter\output";
            //textBoxExcelPath.Text = @"C:\Users\donke\Desktop\pix_sorter\dict.xlsx";
            Text = $"Pix Sorter v{Assembly.GetEntryAssembly().GetName().Version}";
        }
    }
}
