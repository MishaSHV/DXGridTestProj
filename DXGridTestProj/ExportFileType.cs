using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXGridTestProj
{
    public enum FileType
    {
        Text,
        Csv
    }

    public interface IExportFileType
    {
        string Filter { get; }
        FileType FileType { get; }
        int FilterIndex { get; }
        void Export(DataViewBase dataViewBase, Stream stream);
    }

    public static class ExportFileType
    {
        private static readonly Lazy<TextFileType> _textFileType = new Lazy<TextFileType>();
        private static readonly Lazy<CsvFileType> _csvFileType = new Lazy<CsvFileType>();

        public static IExportFileType TextFileType = _textFileType.Value;
        public static IExportFileType CsvFileType = _csvFileType.Value;
    }

    class TextFileType : IExportFileType
    {
        public string Filter => "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        public FileType FileType => FileType.Text;
        public int FilterIndex => 1;

        public void Export(DataViewBase dataViewBase, Stream stream)
        {
            dataViewBase.ExportToText(stream);
        }
    }

    class CsvFileType : IExportFileType
    {
        public string Filter => "csv files (*.csv)|*.csv|All files (*.*)|*.*";
        public FileType FileType => FileType.Csv;
        public int FilterIndex => 1;

        public void Export(DataViewBase dataViewBase, Stream stream)
        {
            dataViewBase.ExportToCsv(stream);
        }
    }
}
