namespace ExcelToTemplateJson
{
    internal static class ExcelJsonMap
    {
        public static Type? GetType(string fieldType, string elementTags)
        {
            if (string.IsNullOrEmpty(fieldType)) { return null; }
            var _fieldType = fieldType.Trim().Replace(" ", string.Empty).ToLower();

            switch (_fieldType)
            {
                case "singlelinetext":
                    return Type.text;

                case "text":
                    return Type.textonly;

                case "singlechoice":
                case "choice":
                    return Type.choice;

                case "multiplechoice":
                case "multipleselect":
                case "list(multiple)":
                case "multiplelist":
                    return Type.multipleSelect;

                case "checkbox":
                    return Type.checkbox;

                case "date":
                case "datetime":
                case "dateandtime":
                    return Type.date;

                case "currency":
                case "currency(inr)":
                case "money":
                case "price":
                    return Type.price;

                case "attach":
                case "attached":
                case "attachedfile":
                case "file":
                    return Type.file;

                case "image":
                case "images":
                    return Type.image;

                case "imagefor":
                    return Type.imagefor;

                case "integer":
                case "number":
                case "integer(number)":
                case "integer(percentage)":
                    return Type.imagefor;

                case "list(single)":
                case "listsingle":
                case "list":
                case "autocomplete":
                    return Type.autocomplete;

                case "slider":
                    return Type.slider;

                case "textarea":
                case "longtext":
                    return Type.textArea;

                case "geolocation":
                case "coordinates":
                case "gpscoordinates":
                    return Type.geolocation;

                case "referencefield":
                case "reference":
                case "referencedatalookup":
                    {
                        if (string.IsNullOrEmpty(elementTags)) return Type.ReferenceDataLookup;
                        if (elementTags.ToLower().Contains("address"))
                        {
                            return Type.addresslookups; //use address
                        }
                        else if (elementTags.ToLower().Contains("guidelinevaluelookup"))
                        {
                            return Type.guidelineValueLookup; //use guidelineValue
                        }
                        return Type.ReferenceDataLookup;
                    }

                case "address":
                case "addresslookups":
                    return Type.addresslookups;

                case "guidelinevaluelookup":
                case "guidelinevalue":
                    return Type.guidelineValueLookup;

                case "tickbox":
                    return Type.tickbox;

                case "heading":
                    return Type.heading;

                case "signature":
                    return Type.signature;

                case "separator":
                    return Type.separator;

                case "odsighted":
                    return Type.ODsighted;

                case "contact":
                    return Type.contact;

                case "voicerecorder":
                    return Type.voiceRecorder;

                case "paragraph":
                    return Type.paragraph;

                case "drwaing":
                case "drawing":
                    return Type.drwaing;
            }

            return null;
        }
    }
}
