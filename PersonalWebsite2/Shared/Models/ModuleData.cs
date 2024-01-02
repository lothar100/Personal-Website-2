using Amazon.DynamoDBv2.DataModel;
using PersonalWebsite2.Shared.Constants;

namespace PersonalWebsite2.Shared.Models
{
    [DynamoDBTable("personal-cloud-modules")]
    public class ModuleData
    {
        [DynamoDBHashKey] public string id { get; set; }
        [DynamoDBRangeKey] public string moduleType { get; set; }

        [DynamoDBProperty] public string subType { get; set; }
        [DynamoDBProperty] public int sortOrder { get; set; }

        [DynamoDBProperty] public string name { get; set; }
        [DynamoDBProperty] public string text { get; set; }
        [DynamoDBProperty] public string glyph { get; set; }
        [DynamoDBProperty] public string path { get; set; }
        [DynamoDBProperty] public string src { get; set; }
        [DynamoDBProperty] public string css { get; set; }
        [DynamoDBProperty] public string title { get; set; }
        [DynamoDBProperty] public string badges { get; set; }
        [DynamoDBProperty] public int count { get; set; }

        [DynamoDBProperty] public bool active { get; set; }


        public bool HasContent()
        {
            if (string.IsNullOrWhiteSpace(title) == false) return true;
            if (string.IsNullOrWhiteSpace(text) == false) return true;
            if (string.IsNullOrWhiteSpace(src) == false) return true;
            if (moduleType == ModuleTypes.Image && count > 0) return true;

            return false;
        }

        public bool HasCardContent()
        {
            if (string.IsNullOrWhiteSpace(title) == false) return true;
            if (string.IsNullOrWhiteSpace(text) == false) return true;
            if (string.IsNullOrWhiteSpace(src) == false) return true;
            if (moduleType == ModuleTypes.Image && count > 0 && subType != ImageTypes.Outside) return true;

            return false;
        }

        public IEnumerable<(string Style, string Text)> ParseBadges()
        {
            if (string.IsNullOrWhiteSpace(badges)) yield return ("danger", "Error-Parsing-Badge-Data");

            var splitBadges = badges.Split(',');

            foreach (var badge in badges.Split(','))
            {
                var info = badge.Split(':');
                yield return (info[0], info[1]);
            }
        }

    }
}
