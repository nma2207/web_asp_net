using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_site
{
    public class MagicConsts
    {
        public static string CURRENT_USER { get; } = "currentUser";
        public static  string BASKET { get; } = "basket";
        public static Dictionary<int , string> KIND_TO_NAME { get; } = new Dictionary<int, string>()
        {
            //{Kind.Fantasy, "Фантастика" },
            //{Kind.Detective, "Детективы" },
            //{Kind.Drama, "Драма" },
            //{Kind.Novel,  "Роман"},
            //{Kind.Computer, "Компуктеры" },
            //{Kind.Poem, "Поэмы" },
            //{Kind.Dream, "Сказки" },
            //{Kind.Technical, "Техническая" }
            {1, "Фантастика" },
            {2, "Детективы" },
            {3, "Драма" },
            {4,  "Роман"},
            {5, "Компуктеры" },
            {6, "Поэмы" },
            {7, "Сказки" },
            {8, "Техническая" }
        };
    }
    public enum Kind
    {
        Fantasy=1,
        Detective=2,
        Drama=3,
        Novel=4, //Роман
        Computer=5,
        Poem=6,
        Dream = 7, //сказка
        Technical =8, //техническая
        End = 9
    }
}