using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class IdListDTO
    {
        public Content Characters { get; set; }
        public Content Maps { get; set; }
        public Content Chromas { get; set; }
        public Content Skins { get; set; }
        public Content SkinLevels { get; set; }
        public Content Attachments { get; set; }
        public Content Equips { get; set; }
        public Content Themes { get; set; }
        public Content GameModes { get; set; }
        public Content Sprays { get; set; }
        public Content SprayLevels { get; set; }
        public Content Charms { get; set; }
        public Content CharmLevels { get; set; }
        public Content PlayerCards { get; set; }
        public Content PlayerTitles { get; set; }
        public Content StorefrontItems { get; set; }

        public class Content
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public string AssetPath { get; set; }
            public bool IsEnabled { get; set; }
        }
    }
}
