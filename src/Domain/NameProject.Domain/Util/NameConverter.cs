using System;
using System.Collections.Generic;
using System.Linq;

namespace NameProject.Domain.Util
{
    public static class NameConverter
    {
        private static List<string> customWords = new List<string> { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };
        private static List<string> noChangeWords = new List<string> { "da", "de", "do", "das", "dos" };
        public static IEnumerable<string> ConvertNames(this IEnumerable<string> names)
        {
            var result = new List<string>();
            foreach (var name in names)
            {
                result.Add(ConvertName(name));
            }
            return result;
        }
        private static string FirstUpper(this string name)
        {
            if (name == "")
                return name;

            name = name.ToLower();

            if (noChangeWords.Contains(name))
                return name;

            return name.First().ToString().ToUpper() + name.Substring(1);
        }

        private static string ConvertName(string name)
        {
            var uniques = name.Split(' ');

            if (uniques.Count() == 0)
                return "";
            //Caso seja somente 1 nome
            else if (uniques.Count() == 1)
                return uniques.First().ToUpper();

            //Caso contenha nomes especiais definidos
            else if (uniques.Any(a => customWords.Contains(a.ToUpper())))
            {
                //Transformo a lista enumerada com indices
                var positions = uniques.Select((s, i) => new { Value = s, Index = i });
                var positionsIgnore = new List<int>();
                //Encontro a posição que possua qualquer nome customizado
                var positionTake = positions.First(f => customWords.Contains(f.Value.ToUpper()));
                //Adiciono para uma lista de remoção, para não duplicar
                positionsIgnore.Add(positionTake.Index);
                //Considerando somente mais de 2 nomes
                if (positionTake.Index > 1)
                {
                    //Encontro a palavra anterior
                    var positionUse = positions.First(f => f.Index == positionTake.Index - 1);
                    positionsIgnore.Add(positionUse.Index);
                    //Concateno tudo
                    return $"{positionUse.Value.ToUpper()} {positionTake.Value.ToUpper()}, {string.Join(" ", positions.Where(f => !positionsIgnore.Contains(f.Index)).Select(s => s.Value.FirstUpper()))}";
                }
                //Considerando somente 2 nomes
                else
                    return $"{positionTake.Value.ToUpper()}, {string.Join(" ", positions.Where(f => !positionsIgnore.Contains(f.Index)).Select(s => s.Value.FirstUpper()))}";
            }
            //Regra Principal
            else
            {
                string lastName = uniques.Last().ToUpper();
                var firstName = uniques.SkipLast(1).Select(s => s.FirstUpper()).ToList();
                return $"{lastName}, {string.Join(" ", firstName)}";
            }

        }
    }
}
