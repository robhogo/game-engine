using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Contexts.DataModels
{
    public class CharacterDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterClassType CharacterClass { get; set; }
        public int Money { get; set; }
        public string ImgUrl { get; set; }
        public List<CharacterLvlDataModel> CharacterLvls { get; set; }

        public int UserId { get; set; }
    }
}
