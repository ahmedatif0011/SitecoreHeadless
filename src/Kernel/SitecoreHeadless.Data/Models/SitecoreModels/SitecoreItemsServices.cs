using System.ComponentModel.DataAnnotations;

namespace SitecoreHeadless.Data.Models.SitecoreModels
{
    public class SitecoreItemsServices
    {
        public class RetrieveTheChildrenOfAnItem : Common
        {
            /// <summary>
            /// If true, the standard template fields are part of the data that is retrieved.
            /// bool, optional
            /// default: false
            /// </summary>
            public bool? includeStandardTemplateFields { get; set; }

            /// <summary>
            /// If true, the metadata is part of the data retrieved.
            /// bool, optional
            /// default: false
            /// </summary>
            public bool? includeMetadata { get; set; }

            /// <summary>
            /// Specify the names of the fields to retrieve in a comma-separated list.
            /// string, optional
            /// example: ItemId,ItemName,TemplateNamedefault: all fields
            /// </summary>
            public string? fields {  get; set; }    
        }
        public class RetrieveAnItem : RetrieveTheChildrenOfAnItem
        {
        }
        public class EditAnItemAsync : Common
        {
            /// <summary>
            /// Represents the JSON body that will be appended to the request, containing the fields to be edited.
            /// The request will include key-value pairs where the key is the field name, and the value is the new value for that field.
            /// Example: {"Title":"The new value of the Title field", "Description":"Updated description of the item"}
            /// </summary>
            [Required]
            public string RequestBody { get; set; }
        }


    }
}
