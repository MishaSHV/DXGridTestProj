﻿using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXGridTestProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void printPrewiewItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            mainGridControl.View.ShowPrintPreview(this);
        }

        private void treeListViewItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            string viewResourceName = e.Item.Tag.ToString();
            mainGridControl.View = Resources[viewResourceName] as DevExpress.Xpf.Grid.GridDataViewBase;
        }

        private void MenuItemTxt_Click(object sender, RoutedEventArgs e)
        {
            ExportSelectedRowsToFile(ExportFileType.TextFileType);
        }

        private void MenuItemCsv_Click(object sender, RoutedEventArgs e)
        {
            ExportSelectedRowsToFile(ExportFileType.CsvFileType);
        }

        private void ExportSelectedRowsToFile(IExportFileType exportFileType)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = exportFileType.Filter;
            saveFileDialog.FilterIndex = exportFileType.FilterIndex;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fname = saveFileDialog.FileName;
                using (var stream = File.Open(fname, FileMode.OpenOrCreate))
                {
                    exportFileType.Export(mainGridControl.View, stream);
                }
            }
        }
    }
}
