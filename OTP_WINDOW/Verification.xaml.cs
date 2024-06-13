using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace OTP_WINDOW
{
    public partial class Verification : Page
    {

        private string jsonDirectory = @"C:\Users\jimin\OTP_backend\build\Debug";
        private FileSystemWatcher jsonWatcher;

        public Verification()
        {
            InitializeComponent();
            InitializeFileSystemWatcher();
        }

        private void InitializeFileSystemWatcher()
        {
            jsonWatcher = new FileSystemWatcher
            {
                Path = jsonDirectory,
                Filter = "*.json",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };

            jsonWatcher.Created += OnJsonFileCreated;
            jsonWatcher.Changed += OnJsonFileCreated;
            jsonWatcher.EnableRaisingEvents = true;
        }

        private void OpenCmdButton_Click(object sender, RoutedEventArgs e)
        {
            string initialDirectory = @"C:\Users\jimin\OTP_backend\build\Debug";
            string commands = "echo Ready to execute your command";

            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/K cd /d \"{initialDirectory}\" & {commands}",
                UseShellExecute = true
            });
        }

        private void LoadJsonButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                InitialDirectory = jsonDirectory
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string jsonContent = File.ReadAllText(openFileDialog.FileName);
                CmdPathTextBox.Text = "Cmd Path: " + openFileDialog.FileName;
                CppContentTextBox.Text = ExtractContent(openFileDialog.FileName, jsonContent);
            }
        }

        private void OnJsonFileCreated(object sender, FileSystemEventArgs e)
        {
            Dispatcher.Invoke(() => LoadLatestJsonFile());
        }

        private void LoadLatestJsonFile()
        {
            try
            {
                var files = Directory.GetFiles(jsonDirectory, "*.json");
                if (files.Length > 0)
                {
                    Array.Sort(files, (f1, f2) => File.GetLastWriteTime(f2).CompareTo(File.GetLastWriteTime(f1)));
                    string latestFile = files[0];
                    string jsonContent = File.ReadAllText(latestFile);
                    CmdPathTextBox.Text = "Cmd Path: " + latestFile;
                    CppContentTextBox.Text = ExtractContent(latestFile, jsonContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON file: {ex.Message}");
            }
        }

        private string ExtractContent(string filePath, string json)
        {
            try
            {
                JObject jsonObject = JObject.Parse(json);
                string content = "";

                foreach (var property in jsonObject.Properties())
                {
                    if (property.Name != "CMakeCXXCompilerId.cpp")
                    {
                        string cppFileName = System.IO.Path.GetFileNameWithoutExtension(property.Name);
                        JToken fileContent = property.Value["choices"][0]["message"]["content"];
                        content += $"{cppFileName} : {fileContent}\n\n";
                    }
                }

                return content;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error extracting content from JSON: {ex.Message}");
                return null;
            }
        }
    }
}
