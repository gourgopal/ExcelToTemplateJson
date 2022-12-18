using OfficeOpenXml;

namespace ExcelToTemplateJson
{
    public class ExcelForm
    {
        public string? MandatoryOptionalVisibility { get; set; }
        public string? LabelName { get; set; }
        public string? NewLabelName { get; set; }
        public string? ElementTags { get; set; }
        public string? FieldType { get; set; }
        public string? Options { get; set; }
        public string? PlaceholderOrHelpText { get; set; }
    }
    internal class ReadExcel
    {
        public List<ExcelForm> FormFieldList { get; } = new List<ExcelForm>();
        public string TemplateName { get; }
        public ReadExcel(string fileName)
        {
            TemplateName = Path.GetFileNameWithoutExtension(fileName);
            var file = new FileInfo(fileName);
            using var package = new ExcelPackage(file);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var currentSheet = package.Workbook.Worksheets;
            var workSheet = currentSheet.First();
            var noOfCol = workSheet.Dimension.End.Column;
            var noOfRow = workSheet.Dimension.End.Row;
            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
            {
                var colIdx = 1;
                var form = new ExcelForm
                {
                    MandatoryOptionalVisibility = workSheet.Cells[rowIterator, colIdx++].Value?.ToString().Trim(),
                    LabelName = workSheet.Cells[rowIterator, colIdx++].Value?.ToString().Trim(),
                    NewLabelName = workSheet.Cells[rowIterator, colIdx++].Value?.ToString().Trim(),
                    ElementTags = workSheet.Cells[rowIterator, colIdx++].Value?.ToString().Trim(),
                    FieldType = workSheet.Cells[rowIterator, colIdx++].Value?.ToString().Trim(),
                    Options = workSheet.Cells[rowIterator, colIdx++].Value?.ToString().Trim(),
                    PlaceholderOrHelpText = workSheet.Cells[rowIterator, colIdx++].Value?.ToString().Trim(),
                };
                FormFieldList.Add(form);
            }
        }
    }
}
