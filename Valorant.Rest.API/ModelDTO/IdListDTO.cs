using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class IdListDTO
    {
        public List<Content> Characters { get; set; }
        public List<Content> Maps { get; set; }
        public List<Content> Chromas { get; set; }
        public List<Content> Skins { get; set; }
        public List<Content> SkinLevels { get; set; }
        public List<Content> Attachments { get; set; }
        public List<Content> Equips { get; set; }
        public List<Content> Themes { get; set; }
        public List<Content> GameModes { get; set; }
        public List<Content> Sprays { get; set; }
        public List<Content> SprayLevels { get; set; }
        public List<Content> Charms { get; set; }
        public List<Content> CharmLevels { get; set; }
        public List<Content> PlayerCards { get; set; }
        public List<Content> PlayerTitles { get; set; }
        public List<Content> StorefrontItems { get; set; }
        public List<Season> Seasons { get; set; }

        public class Content
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public string AssetPath { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Season
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsEnabled { get; set; }
            public bool IsActive { get; set; }
            public bool DevelopmentOnly { get; set; }
        }
    }
}
