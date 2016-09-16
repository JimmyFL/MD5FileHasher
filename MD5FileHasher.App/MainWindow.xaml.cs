using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using Microsoft.Win32;

namespace MD5FileHasher.App
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_BtnClick(object sender, RoutedEventArgs e)
        {
            var filePath = GetFilePath();

            FilePathLabel.Content = filePath;
            HashLabel.Content = GetHashFromFilePath(filePath);
        }

        private string GetFilePath()
        {
            var openFileDialog = new OpenFileDialog();
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : "";
        }

        private string GetHashFromFilePath(string filePath)
        {
            try
            {
                using (var md5 = MD5.Create())
                    using (var stream = File.OpenRead(filePath))
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToLower();
            }
            catch (Exception e)
            {
                return "you have to select a file...";
            }
        }
    }
}
