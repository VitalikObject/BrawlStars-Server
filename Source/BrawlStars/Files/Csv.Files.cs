using System;
using System.Collections.Generic;
using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;
using BrawlStars.Files.Logic;

namespace BrawlStars.Files
{
    public partial class Csv
    {
        public enum Files
        {
            Locales = 1,
            Globals = 3,
            Resources = 5,
            AllianceBadges = 8,
            Characters = 16,
            AreaEffects = 17,
            Items = 18,
            Skills = 20,
            Campaign = 21,
            Bosses = 22,
            Cards = 23,
            AllianceRoles = 25,
            Skins = 29,
        }

        public static Dictionary<Files, Type> DataTypes = new Dictionary<Files, Type>();

        static Csv()
        {
            DataTypes.Add(Files.Locales, typeof(Locale));
            DataTypes.Add(Files.Globals, typeof(Global));
            DataTypes.Add(Files.Resources, typeof(Resource));
            DataTypes.Add(Files.AllianceBadges, typeof(AllianceBadge));
            DataTypes.Add(Files.Characters, typeof(Character));
            DataTypes.Add(Files.AreaEffects, typeof(AreaEffect));
            DataTypes.Add(Files.Items, typeof(Item));
            DataTypes.Add(Files.Skills, typeof(Skill));
            DataTypes.Add(Files.Campaign, typeof(Campaign));
            DataTypes.Add(Files.Bosses, typeof(Bosses));
            DataTypes.Add(Files.Cards, typeof(Card));
            DataTypes.Add(Files.AllianceRoles, typeof(AllianceRole));
            DataTypes.Add(Files.Skins, typeof(Skin));
        }

        public static Data Create(Files file, Row row, DataTable dataTable)
        {
            if (DataTypes.ContainsKey(file)) return Activator.CreateInstance(DataTypes[file], row, dataTable) as Data;

            return null;
        }
    }
}