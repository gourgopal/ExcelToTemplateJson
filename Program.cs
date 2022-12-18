using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ExcelToTemplateJson;

public class Program
{
    public static void Main(string[] args)
    {
        var excelObj = new ReadExcel(args[0]);
        var template = new Template();
        Console.WriteLine($"TemplateName: {excelObj.TemplateName}");

        var templateJson = new List<FieldType>();
        foreach (var excel in excelObj.FormFieldList)
        {
            var type = ExcelJsonMap.GetType(excel.FieldType, excel.ElementTags);
            if (type == null)
            {
                Console.WriteLine($"WARN: skipping {excel.LabelName} due to empty Field Type");
                continue;
            }

            //collect fields
            var field = template.FieldTypes[type.Value];

            //update field
            field.Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            field.LabelTimestamp = field.Timestamp;
            field.Name = $"{field.Type}_{field.Timestamp}";
            field.ElementIdentifier = excel.ElementTags.TrimStart('<').TrimEnd('>');
            if (!string.IsNullOrEmpty(excel.LabelName))
            {
                field.Label = excel.LabelName;
            }

            //UPDATE reference fields with required data
            //SET ruleJson

            //generate template
            templateJson.Add(field);
        }
        var serializerSettings = new JsonSerializerSettings();
        serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        var json = JsonConvert.SerializeObject(templateJson, serializerSettings);

        Console.WriteLine(json);
    }
}