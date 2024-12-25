using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Data.Models.SitecoreModels
{
    public class Common
    {
        /// <summary>
        /// Specify the id of the Sitecore items to retrieve.
        /// guid, required
        /// example: 110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9
        /// </summary>
        [Required]
        public string ItemId { get; set; }

        /// <summary>
        /// Specify the database the item is in.
        /// example: core
        /// default: context database for the logged in user
        /// </summary>
        public string? database { get; set; }

        /// <summary>
        /// Specify a language selector. 
        /// string, optional
        /// example: ja-JP
        /// default: context language for the logged in user
        /// </summary>
        public string? language { get; set; }

        /// <summary>
        /// example: 1
        /// default: latest version
        /// </summary>
        public string? version { get; set; }
    }
}
