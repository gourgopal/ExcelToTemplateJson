using Microsoft.VisualBasic.FileIO;

namespace ExcelToTemplateJson;

public enum NumberTypeElements
{
    integer, percentage
}
public enum Type
{
    number, text, textonly, price, textArea, checkbox, ODsighted, tickbox, choice, slider, date, autocomplete, multipleSelect, geolocation, contact, image, imagefor, voiceRecorder, drwaing, signature, file, separator, paragraph, heading,
    ReferenceDataLookup, addresslookups, guidelineValueLookup
}
public static class DefaultDateFormateSelected
{
    public const string defaultDateFormat = "dd/MM/yyyy HH:mm:ss";
    public const string oldDefaultDateFormat = "dd/MM/YYYY hh:mm aa";
}

public class Dropdown
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class ContactArray
{
    public string Key { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public dynamic? Value { get; set; }
    public string Lable { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public string Params { get; set; } = string.Empty;
    public string? StatesFilter { get; set; }
    public string? FieldType { get; set; }
    public bool Required { get; set; }
    public bool Condtional { get; set; }
}
public class Values
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public bool Selected { get; set; } = false;
}
public class FieldType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long Timestamp { get; set; }
    public long LabelTimestamp { get; set; }
    public string Name { get; set; } = string.Empty;
    public Type Type { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public Type Subtype { get; set; }
    public bool Required { get; set; }
    public bool Lock { get; set; }
    public string Regex { get; set; } = string.Empty;
    public bool Inline { get; set; }
    public bool Handle { get; set; }
    public string ElementIdentifier { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public Dropdown[] DateFormateSelectTypes { get; set; } = Array.Empty<Dropdown>();
    public NumberTypeElements NumberTypeValue { get; set; }
    public NumberTypeElements[] NumberTypes { get; set; } = Array.Empty<NumberTypeElements>();
    public Values[] Values { get; set; } = Array.Empty<Values>();
    public bool Selected { get; set; }
    public dynamic Value { get; set; } = string.Empty;
    public ContactArray[] ContactArray { get; set; } = Array.Empty<ContactArray>();
    public string Lookuptype { get; set; } = string.Empty;
    public bool Toggle { get; set; }
    public bool ValidationError { get; set; }
    public string ElementIdentifierUniqueMessage { get; set; } = string.Empty;
}
internal class Template
{
    public Dictionary<Type, FieldType> FieldTypes { get; }
    public static Dropdown[] dateFormateSelectType = new Dropdown[] {
          new Dropdown {
            Label= "Year (yyyy)",
            Value= "yyyy"
          },
          new Dropdown{
            Label= "Month & Year (MM/yyyy)",
            Value= "MM/yyyy"
          },
          new Dropdown{
            Label= "Date Only (dd/MM/yyyy)",
            Value= "dd/MM/yyyy"
          },
          new Dropdown{
            Label= "Date & Time (dd/MM/yyyy HH=mm=ss)",
            Value= "dd/MM/yyyy HH=mm=ss"
          },
          new Dropdown{
            Label= "Time (HH=mm=ss)",
            Value= "HH=mm=ss"
          }
        };
    public Template()
    {
        var singleLineText = new FieldType
        {
            Type = Type.text,
            Icon = "Abc",
            Label = "Single Line Text",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Subtype = Type.text,
            Required = false,
            Lock = false,
            Regex = "",
            Handle = true,
            ElementIdentifier = "SingleLineText",
            Title = "This element is a short text input field which allows you to enter a label, a number or a phone number",
        };

        var number = new FieldType
        {
            Type = Type.number,
            Icon = "123",
            Label = "Number",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Subtype = Type.text,
            Required = false,
            Lock = false,
            Regex = "",
            Handle = true,
            ElementIdentifier = "Number",
            NumberTypeValue = NumberTypeElements.integer,
            NumberTypes = new NumberTypeElements[] { NumberTypeElements.integer, NumberTypeElements.percentage },
            Title = "This element is a short text input field which allows you to enter a number or a phone number",
        };

        var price = new FieldType
        {
            Type = Type.price,
            Icon = "fas fa-rupee-sign",
            Label = "Currency",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Subtype = Type.text,
            Required = false,
            Lock = false,
            Regex = "",
            Handle = true,
            ElementIdentifier = "Currency",
            Title = "This element is a short text input field which allows you to enter a amount",
        };

        var textarea = new FieldType
        {
            Type = Type.textArea,
            Icon = "fas fa-align-left",
            Label = "Text Area",
            Description = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "TextArea",
            Title = "Text Area is a simple tool that allows you to key multiple lines in a text  input field",
        };

        var checkbox = new FieldType
        {
            Type = Type.checkbox,
            Icon = "fas fa-check-square",
            Label = "Checkbox (multiple)",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "Checkbox",
            NumberTypeValue = NumberTypeElements.integer,
            NumberTypes = new NumberTypeElements[] { NumberTypeElements.integer, NumberTypeElements.percentage },
            Title = "The Check Box item allows you to either accept/check an option or not while filling the form.",
            Selected = false,
            Values = new Values[] { new Values { Label = "", Value = "", Selected = false } }
        };

        var ODsighted = new FieldType
        {
            Type = Type.ODsighted,
            Icon = "fas fa-check-square",
            Label = "Ownership document sighted",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "Sighted",
            Title = "Please select the documents used in the valuation of this property",
            Selected = false,
            Values = Array.Empty<Values>()
        };

        var tickbox = new FieldType
        {
            Type = Type.tickbox,
            Icon = "fas fa-check-square",
            Label = "Tickbox",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "Tickbox",
            Title = "The Check Box item allows you to either accept/check an option or not while filling the form.",
            Selected = false,
            Value = false
        };

        var choice = new FieldType
        {
            Type = Type.choice,
            Icon = "fas fa-check-circle",
            Label = "Choice",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "Choice",
            Title = "The choice field allows you to create a choice list, MCQs test style",
            Selected = false,
            Values = Array.Empty<Values>()
        };

        var slider = new FieldType
        {
            Type = Type.slider,
            Icon = "fas fa-sliders-h",
            Label = "Slider",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Subtype = Type.text,
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "Slider",
            Title = "This item allows you to calibrate a numeric or textual value by simply moving the cursor on a graduate scale. The measuring unit will be determined automatically. You can choose the minimum and the maximum value if it is a numerical grading scale or choose the text option under ",
            Selected = false,
            Value = 0,
            ContactArray = new ContactArray[]
            {
                    new ContactArray { Name= "minimumValue", Value = 0, Lable= "Minimum value", Placeholder= "minimum value" },
                    new ContactArray { Name= "maximumValue", Value = 1, Lable= "Maximum value", Placeholder= "maximum value" }
            }
        };

        var date = new FieldType
        {
            Type = Type.date,
            Icon = "far fa-calendar-alt",
            Label = "Date & Time",
            Description = "",
            Placeholder = DefaultDateFormateSelected.defaultDateFormat,
            ClassName = "form-control",
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "DateTime",
            Title = "This item allows you to enter a specific date and/or a time. The default value is today\'s date",
            DateFormateSelectTypes = dateFormateSelectType
        };

        var autocomplete = new FieldType
        {
            Type = Type.autocomplete,
            Icon = "fas fa-stream",
            Label = "List (Single)",
            Description = "",
            Placeholder = "Select",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "List",
            Title = "This item allows you to create a list of data. You must create at least one component",
            Values = new Values[] { new Values { Label = "", Value = "", Selected = false } }
        };

        var multipleSelect = new FieldType
        {
            Type = Type.multipleSelect,
            Icon = "fas fa-bars",
            Label = "List (Multiple)",
            Description = "",
            Placeholder = "Multiple Select",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "MultipleList",
            Title = "This item allows you to create a list of data. You must create at least one component",
            Values = new Values[] { new Values { Label = "", Value = "", Selected = false } }
        };

        var geolocation = new FieldType
        {
            Type = Type.geolocation,
            Icon = "fas fa-map-marker-alt",
            Label = "Geolocation",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            Regex = "",
            Handle = true,
            ElementIdentifier = "Geolocation",
            Title = "This Geolocation item allows you to locate yourself by recording your geographical position (latitude and longitude). A link will also appear in  the Excel file to quickly view the collected position. This tool requires a GPS. (This feature is not available on a computer)",
        };

        var contact = new FieldType
        {
            Type = Type.contact,
            Icon = "fas fa-user",
            Label = "Contact",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Subtype = Type.text,
            Required = false,
            Lock = false,
            Regex = "",
            Inline = true,
            ElementIdentifier = "Contact",
            Title = "This item allows you to save details from a contact or provide specific  information about a person, client, prospect…",
            Selected = false,
            Value = 0,
            ContactArray = new ContactArray[]
            {
                    new ContactArray { Name = "firstName", Value = "", Lable= "First Name", Placeholder = "First Name" },
                    new ContactArray { Name = "lastName", Value = "", Lable= "Last Name", Placeholder = "Last Name" },
                    new ContactArray { Name = "phoneNumber", Value = "", Lable= "Phone Number", Placeholder = "Phone Number" },
                    new ContactArray { Name = "email", Value = "", Lable= "Email", Placeholder = "Email" }
            }
        };

        var image = new FieldType
        {
            Type = Type.image,
            Icon = "fas fa-image",
            Label = "Image",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Subtype = Type.file,
            Required = false,
            Lock = false,
            ElementIdentifier = "Image",
            Title = "This item allows you to take several photos or to select an existing picture directly from the directory of your device (smartphone, tablet). You can also choose a picture from your local file if you're using a computer"
        };

        var imagefor = new FieldType
        {
            Type = Type.imagefor,
            Icon = "fas fa-images",
            Label = "Image For",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Subtype = Type.file,
            Required = false,
            Lock = false,
            ElementIdentifier = "imagefor",
            Title = "This item allows you to take several photos or to select an existing picture directly from the directory of your device (smartphone, tablet). You can also choose a picture from your local file if you're using a computer"
        };

        var voiceRecorder = new FieldType
        {
            Type = Type.voiceRecorder,
            Icon = "fas fa-microphone",
            Label = "Voice Recorder",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "VoiceRecorder",
            Title = "As it is named, the Voice Recorder item gives you the opportunity to record your own voice or a sound, to comment or notice something (This feature is not available on a computer)"
        };

        var drwaing = new FieldType
        {
            Type = Type.drwaing,
            Icon = "fas fa-paint-brush",
            Label = "Drawing",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "Drawing",
            Title = "This Drawing tool allows you to draw a sketch. You can also choose a picture from your local file and draw something on it"
        };

        var signature = new FieldType
        {
            Type = Type.signature,
            Icon = "fas fa-signature",
            Label = "Signature",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "Signature",
            Title = "Thanks to your device’s touchscreen, this item allows you to add a signature in the form. If you are using a computer, you will be able to choose a local file with a picture of their signature, logo or information to sign your document"
        };

        var file = new FieldType
        {
            Type = Type.file,
            Icon = "fas fa-file",
            Label = "Attached File",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Subtype = Type.file,
            Required = false,
            Lock = false,
            ElementIdentifier = "AttachedFile",
            Title = "The Attached File field allows users to attach a file (all file formats accepted) when entering data on a mobile device. The Attached File can also be added to automatic e-mails (optional)"
        };

        var separator = new FieldType
        {
            Type = Type.separator,
            Icon = "fas fa-square",
            Label = "Separator",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "Separator",
            Title = "The Separator is an item that allows you to separate your form into several blocks. This will help you organise your forms"
        };

        var paragraph = new FieldType
        {
            Type = Type.paragraph,
            Icon = "fas fa-paragraph",
            Label = "Text",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "Text",
            Title = "The fixed text enables you to enter an uneditable explanatory text"
        };

        var heading = new FieldType
        {
            Type = Type.heading,
            Icon = "fas fa-heading",
            Label = "Heading",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "Heading",
            Title = "The fixed text enables you to enter an uneditable explanatory text"
        };

        var textonly = new FieldType
        {
            Type = Type.textonly,
            Icon = "abc",
            Label = "Text",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "Text",
            Title = "The fixed text enables you to enter an uneditable explanatory text"
        };

        var ReferenceDataLookup = new FieldType
        {
            Type = Type.ReferenceDataLookup,
            Lookuptype = "statuses",
            Icon = "fas fa-bars",
            Label = "Reference Lookup",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "ReferenceDataLookup",
            Title = "The fixed text enables you to enter an uneditable explanatory text"
        };

        var addresslookups = new FieldType
        {
            Type = Type.addresslookups,
            Icon = "fas fa-bars",
            Label = "Address",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "Address",
            Subtype = Type.text,
            Title = "The tool allows you to enter address information from one place. Geolocation is also available to prevent user input elements that may be measurable by GPS. The Address item allows you to key manually an address. You can also be more precise with the geo-location item to locate yourself.",
            ContactArray = new ContactArray[]
            {
                    new ContactArray { Key = "State", Name = "State", Lable= "State", Placeholder = "State", Required = true },
                    new ContactArray { Key = "District", Name = "District", Lable= "District", Placeholder = "District", Required = true, Params = @"{""params"":[{""formfield"":""State"",""apifield"":""stateId""},{""formfield"":""State"",""apifield"":""stateUid""}]}" },
                    new ContactArray { Key = "SubDistrict", Name = "SubDistrict", Lable= "Sub District", Placeholder = "Sub District", Required = true, Params = @"{""params"":[{""formfield"":""District"",""apifield"":""districtId""},{""formfield"":""District"",""apifield"":""districtUid""}]}" },
                    new ContactArray { Key = "city", Name = "city", Lable= "City / Town", Placeholder = "City / Town", Required = true, Params = @"{""params"":[{""formfield"":""State"",""apifield"":""stateId""},{""formfield"":""State"",""apifield"":""stateUid""}]}" },
                    new ContactArray { Key = "Village", Name = "Village", Lable= "Village", Placeholder = "Village", Required = true, Params = @"{""params"":[{""formfield"":""State"",""apifield"":""stateId""},{""formfield"":""State"",""apifield"":""stateUid""}]}" },
                    new ContactArray { Key = "Project", Name = "Project", Lable= "Project Name", Placeholder = "Project Name", Required = true, Condtional = true, Params = @"{""params"":[{""formfield"":""city"",""apifield"":""cityId""},{""formfield"":""Village"",""apifield"":""villageId""},{""formfield"":""city"",""apifield"":""cityUid""},{""formfield"":""Village"",""apifield"":""villageUid""}]}" },
                    new ContactArray { Key = "Building", Name = "Building", Lable= "Building Name", Placeholder = "Building Name", Required = true, Params = @"{""params"":[{""formfield"":""Project"",""apifield"":""projectId""},{""formfield"":""Project"",""apifield"":""projectUid""}]}" },
                    new ContactArray { Key = "Locality", Name = "Locality", Lable= "Locality", Placeholder = "Locality", Required = true, Condtional = true, Params = @"{""params"":[{""formfield"":""State"",""apifield"":""stateId""},{""formfield"":""city"",""apifield"":""cityId""}]},{""formfield"":""Village"",""apifield"":""villageId""}]},{""formfield"":""SubDistrict"",""apifield"":""subdistrictId""}]},{""formfield"":""State"",""apifield"":""stateUid""}]},{""formfield"":""city"",""apifield"":""cityUid""},{""formfield"":""Village"",""apifield"":""villageUid""},{""formfield"":""SubDistrict"",""apifield"":""subdistrictUid""}]}" },
                    new ContactArray { Key = "SubLocality", Name = "SubLocality", Lable= "Sub locality", Placeholder = "Sub locality", Required = true, Condtional = true, Params = @"{""params"":[{""formfield"":""State"",""apifield"":""stateId""},{""formfield"":""city"",""apifield"":""cityId""}]},{""formfield"":""Village"",""apifield"":""villageId""}]},{""formfield"":""SubDistrict"",""apifield"":""subdistrictId""}]},{""formfield"":""State"",""apifield"":""stateUid""}]},{""formfield"":""city"",""apifield"":""cityUid""},{""formfield"":""Village"",""apifield"":""villageUid""},{""formfield"":""SubDistrict"",""apifield"":""subdistrictUid""}]}" },
                    new ContactArray { Key = "SubSubLocality", Name = "SubSubLocality", Lable= "Sub-sub locality", Placeholder = "SubSubLocality", Required = true, Condtional = true, Params = @"{""params"":[{""formfield"":""State"",""apifield"":""stateId""},{""formfield"":""city"",""apifield"":""cityId""}]},{""formfield"":""Village"",""apifield"":""villageId""}]},{""formfield"":""SubDistrict"",""apifield"":""subdistrictId""}]},{""formfield"":""State"",""apifield"":""stateUid""}]},{""formfield"":""city"",""apifield"":""cityUid""},{""formfield"":""Village"",""apifield"":""villageUid""},{""formfield"":""SubDistrict"",""apifield"":""subdistrictUid""}]}" },
                    new ContactArray { Key = "StreetName", Name = "StreetName", Lable= "Street Name / Road No", Placeholder = "Street Name / Road No", Required = true, Condtional = true, Params = @"{""params"":[{""formfield"":""State"",""apifield"":""stateId""},{""formfield"":""city"",""apifield"":""cityId""}]},{""formfield"":""Village"",""apifield"":""villageId""}]},{""formfield"":""SubDistrict"",""apifield"":""subdistrictId""}]},{""formfield"":""State"",""apifield"":""stateUid""}]},{""formfield"":""city"",""apifield"":""cityUid""},{""formfield"":""Village"",""apifield"":""villageUid""},{""formfield"":""SubDistrict"",""apifield"":""subdistrictUid""}]}" },
                    new ContactArray { Key = "Pincode", Name = "Pincode", Lable= "Pincode", Placeholder = "Pincode", Required = true, Condtional = true, Params = @"{""params"":[{""formfield"":""State"",""apifield"":""stateId""},{""formfield"":""city"",""apifield"":""cityId""}]},{""formfield"":""Village"",""apifield"":""villageId""}]},{""formfield"":""SubDistrict"",""apifield"":""subdistrictId""}]},{""formfield"":""State"",""apifield"":""stateUid""}]},{""formfield"":""city"",""apifield"":""cityUid""},{""formfield"":""Village"",""apifield"":""villageUid""},{""formfield"":""SubDistrict"",""apifield"":""subdistrictUid""}]}" },
                    new ContactArray { Name = "NearestLandmarkPOI", Lable= "Nearest landmark", Placeholder = "Nearest landmark" },
            }
        };

        var guidelineValueLookup = new FieldType
        {
            Type = Type.guidelineValueLookup,
            Icon = "fas fa-bars",
            Label = "Guideline Value Lookup",
            Description = "",
            Placeholder = "",
            ClassName = "form-control",
            Required = false,
            Lock = false,
            ElementIdentifier = "guidelineValueLookup",
            Subtype = Type.text,
            Title = "The tool allows you to enter Guideline Value Input information from one place.",
            ContactArray = new ContactArray[]
            {
                    new ContactArray { Key = "State", Name = "State", Lable= "State", Placeholder = "State", Required = true },
                    new ContactArray { Key = "/Values/Address/Search/Districts", Name = "District", Lable= "District", Placeholder = "District", Required = true, StatesFilter = "Rajasthan,Gujarat" },
                    new ContactArray { Key = "/ppt/api/v1/guidelinevalue/lookup/subdistricts", Name = "Taluka", Lable= "Taluka / Sub District", Placeholder = "Taluka / Sub District", StatesFilter = "Maharashtra,Gujarat", Required = true },
                    new ContactArray { Key = "/ppt/api/v1/guidelinevalue/lookup/villages", Name = "Village", Lable= "Village", Placeholder = "Village", StatesFilter = "Maharashtra", Required = true },
                    new ContactArray { Key = "/ppt/api/v1/guidelinevalue/lookup/subzones", Name = "SubZone", Lable= "Sub Zone", Placeholder = "Sub Zone", StatesFilter = "Maharashtra", Required = true },
                    new ContactArray { Key = "/Values/Address/Search/SROs", Name = "SRO", Lable= "SRO", Placeholder = "SRO", StatesFilter = "Rajasthan", Required = false },
                    new ContactArray { Key = "/Values/Address/Search/Zones", Name = "Zone", Lable= "Zone", Placeholder = "Zone", StatesFilter = "Rajasthan", Required = false },
                    new ContactArray { Key = "/Values/Address/Search/Colonies", Name = "Colony", Lable= "Colony", Placeholder = "Colony", StatesFilter = "Rajasthan", Required = false },
                    new ContactArray { Key = "/Values/Address/Search/VillagesByDistrict", Name = "RajasthanVillage", Lable= "Village", Placeholder = "Village", StatesFilter = "Rajasthan,Gujarat", Required = false },
                    new ContactArray { Key = "Location", Name = "Location", Lable = "Location", Placeholder = "Location", StatesFilter = "Rajasthan", Required = false, FieldType = "dropdown", Value = "Exterior" },
                    new ContactArray { Key = "/Values/Address/Search/LandType", Name = "LandType", Lable= "Land Type", Placeholder = "Land Type", StatesFilter = "Gujarat", Required = true },
                    new ContactArray { Key = "/Values/Address/Search/surveynumbers", Name = "SurveyNumber", Lable= "Survey Number", Placeholder = "Survey Number", StatesFilter = "Gujarat", Required = false },
                    new ContactArray { Key = "/Values/Address/Search/townplanningnumbers", Name = "TownPlanningNumber", Lable= "Town Planning Number", Placeholder = "Town Planning Number", StatesFilter = "Gujarat", Required = false },
                    new ContactArray { Key = "/Values/Address/Search/Zones", Name = "GujaratZone", Lable= "Zone", Placeholder = "Zone", StatesFilter = "Gujarat", Required = false },
                    new ContactArray { Key = "FarmLandType", Name = "FarmLandType", Lable= "Farm Land Type", Placeholder = "Farm Land Type", StatesFilter = "Gujarat", Required = false, FieldType = "dropdown" },
            }
        };

        FieldTypes = new Dictionary<Type, FieldType>
        {
            { Type.text, singleLineText },
            { Type.number, number },
            { Type.price, price },
            { Type.textArea, textarea },
            { Type.checkbox, checkbox },
            { Type.ODsighted, ODsighted },
            { Type.tickbox, tickbox },
            { Type.choice, choice },
            { Type.slider, slider },
            { Type.date, date },
            { Type.autocomplete, autocomplete },
            { Type.multipleSelect, multipleSelect },
            { Type.geolocation, geolocation },
            { Type.contact, contact },
            { Type.image, image },
            { Type.imagefor, imagefor },
            { Type.voiceRecorder, voiceRecorder },
            { Type.drwaing, drwaing },
            { Type.signature, signature },
            { Type.file, file },
            { Type.separator, separator },
            { Type.paragraph, paragraph },
            { Type.heading, heading },
            { Type.ReferenceDataLookup, ReferenceDataLookup },
            { Type.addresslookups, addresslookups },
            { Type.guidelineValueLookup, guidelineValueLookup },
            { Type.textonly, textonly }
        };
    }
}

public class RuleJson
{
    public Guid UniqueId { get; set; }
    public Guid VisibilityId { get; set; }
    public Guid FormControlId { get; set; }
    public string Label { get; set; }
    public string Operator { get; set; }
    public string Value { get; set; }
    public string Type { get; set; }
    public string ValueId { get; set; }
    public bool FieldAlwaysHidden { get; set; }

    public RuleJson(Guid uniqueId, Guid visibilityId, Guid formControlId, string label, string @operator, string value, string type, string valueId, bool fieldAlwaysHidden)
    {
        UniqueId = uniqueId;
        VisibilityId = visibilityId;
        FormControlId = formControlId;
        Label = label;
        Operator = @operator;
        Value = value;
        Type = type;
        ValueId = valueId;
        FieldAlwaysHidden = fieldAlwaysHidden;
    }
}